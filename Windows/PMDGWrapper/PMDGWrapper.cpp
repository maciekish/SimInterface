#include "PMDGWrapper.h"

static enum DATA_REQUEST_ID {
	DATA_REQUEST,
	CONTROL_REQUEST,
	AIR_PATH_REQUEST
};

static enum EVENT_ID {
	EVENT_SIM_START,	// used to track the loaded aircraft
};

HANDLE  hSimConnect = NULL;
byte bQuit=false;
PMDG_NGX_Data sPmdgData;
int iPmdgUpdated=0;
PMDG_NGX_Control sControl;
void(__stdcall * airCraftLoadedCallback)(char *airPath);
HANDLE PollForDataThread;

bool InitSimConnect(bool restart)
{
	int hr=SimConnect_Open(&hSimConnect, "PMDGWrapper", NULL, 0, 0, 0);
	if (!SUCCEEDED(hr))
	{
		hSimConnect=NULL;
		return false;
	}

	// 1) Set up data connection

	SetupDataConnection();

	// 2) Set up control connection

	SetupControlConnection();

	// 3) Request current aircraft .air file path
	//hr = SimConnect_RequestSystemState(hSimConnect, AIR_PATH_REQUEST, "AircraftLoaded");
	// also request notifications on sim start and aircraft change
	if (!restart)
		hr = SimConnect_SubscribeToSystemEvent(hSimConnect, EVENT_SIM_START, "SimStart");

	// process messages
	if (PollForDataThread==NULL)
		PollForDataThread = CreateThread(NULL, 0, PollForData, 0, 0, NULL);
	
	// get the first data
	Sleep(50);

	return true;
}

void SetupDataConnection()
{
	// Associate an ID with the PMDG data area name
	int hr = SimConnect_MapClientDataNameToID (hSimConnect, PMDG_NGX_DATA_NAME, PMDG_NGX_DATA_ID);

	// Define the data area structure - this is a required step
	int size=sizeof(PMDG_NGX_Data);
	hr = SimConnect_AddToClientDataDefinition (hSimConnect, PMDG_NGX_DATA_DEFINITION, 0, sizeof(PMDG_NGX_Data), 0, 0);

	// Sign up for notification of data change.  
	// SIMCONNECT_CLIENT_DATA_REQUEST_FLAG_CHANGED flag asks for the data to be sent only when some of the data is changed.
	hr = SimConnect_RequestClientData(hSimConnect, PMDG_NGX_DATA_ID, DATA_REQUEST, PMDG_NGX_DATA_DEFINITION, 
		SIMCONNECT_CLIENT_DATA_PERIOD_ON_SET, SIMCONNECT_CLIENT_DATA_REQUEST_FLAG_CHANGED, 0, 0, 0);

}

void SetupControlConnection()
{
	// First method: control data area
	sControl.Event = 0;
	sControl.Parameter = 0;

	// Associate an ID with the PMDG control area name
	int hr = SimConnect_MapClientDataNameToID (hSimConnect, PMDG_NGX_CONTROL_NAME, PMDG_NGX_CONTROL_ID);

	// Define the control area structure - this is a required step
	hr = SimConnect_AddToClientDataDefinition (hSimConnect, PMDG_NGX_CONTROL_DEFINITION, 0, sizeof(PMDG_NGX_Control), 0, 0);

	// Sign up for notification of control change.  
	hr = SimConnect_RequestClientData(hSimConnect, PMDG_NGX_CONTROL_ID, CONTROL_REQUEST, PMDG_NGX_CONTROL_DEFINITION, 
		SIMCONNECT_CLIENT_DATA_PERIOD_ON_SET, SIMCONNECT_CLIENT_DATA_REQUEST_FLAG_CHANGED, 0, 0, 0);

}

void CloseSimConnect()
{
	SimConnect_Close(hSimConnect);
	hSimConnect=NULL;
}

DWORD WINAPI PollForData(LPVOID lpParam)
{
	while( bQuit == 0 )
	{
		// receive and process the NGX data
		SimConnect_CallDispatch(hSimConnect, MyDispatchProc, NULL);

		if (false)
		{
			CloseSimConnect();
			InitSimConnect(true);
		}
		Sleep(100);
	} 
	return 0;
}

void CALLBACK MyDispatchProc(SIMCONNECT_RECV* pData, DWORD cbData, void *pContext)
{
	switch(pData->dwID)
	{
	case SIMCONNECT_RECV_ID_EXCEPTION:
		break;
	case SIMCONNECT_RECV_ID_OPEN:
		break;

	case SIMCONNECT_RECV_ID_CLIENT_DATA: // Receive and process the NGX data block
		{
			SIMCONNECT_RECV_CLIENT_DATA *pObjData = (SIMCONNECT_RECV_CLIENT_DATA*)pData;

			switch(pObjData->dwRequestID)
			{
			case DATA_REQUEST:
				{
					if (iPmdgUpdated%100 == 0)
						printf("Receive and process the NGX data block count=%d\n", iPmdgUpdated);
					PMDG_NGX_Data *pS = (PMDG_NGX_Data*)&pObjData->dwData;
					sPmdgData = *pS;
					iPmdgUpdated++;
					break;
				}
			case CONTROL_REQUEST:
				{
					printf("Receive and process the NGX control block event=%d\n", ((PMDG_NGX_Control*)&pObjData->dwData)->Event);
					// keep the present state of Control area to know if the server had received and reset the command
					PMDG_NGX_Control *pS = (PMDG_NGX_Control*)&pObjData->dwData;
					//printf("Received control: %d %d\n", pS->Event, pS->Parameter);
					sControl = *pS;
					break;
				}
			}
			break;
		}
	case SIMCONNECT_RECV_ID_EVENT:	
		{
			SIMCONNECT_RECV_EVENT *evt = (SIMCONNECT_RECV_EVENT*)pData;
			switch (evt->uEventID)
			{
			case EVENT_SIM_START:	// Track aircraft changes
				{
					HRESULT hr = SimConnect_RequestSystemState(hSimConnect, AIR_PATH_REQUEST, "AircraftLoaded");
					break;
				}
			}
			break;
		}

	case SIMCONNECT_RECV_ID_SYSTEM_STATE: // Track aircraft changes
		{
			SIMCONNECT_RECV_SYSTEM_STATE *evt = (SIMCONNECT_RECV_SYSTEM_STATE*)pData;
			if (evt->dwRequestID == AIR_PATH_REQUEST)
			{
				if (airCraftLoadedCallback!=NULL)
					airCraftLoadedCallback(evt->szString);

				if (strstr(evt->szString, "PMDG 737") != NULL)
				{
					//SetupDataConnection();
					//SetupControlConnection();
				}
			}
			break;
		}

	case SIMCONNECT_RECV_ID_QUIT:
		{
			break;
		}

	default:
		printf("Received:%d\n",pData->dwID);
		break;
	}
	fflush(stdout);
}

__declspec(dllexport) void SetACLoadedCallback(void(__stdcall * callback)(char *airPath))
{
	airCraftLoadedCallback=callback;
	HRESULT hr = SimConnect_RequestSystemState(hSimConnect, AIR_PATH_REQUEST, "AircraftLoaded");
}

__declspec(dllexport) int GetPMDGDataStructureLength()
{
	int size=sizeof(PMDG_NGX_Data);
	return size;
}

__declspec(dllexport) void* GetPMDGData()
{
	return &sPmdgData;
}

void RaiseMPDGEvent(char *eventName, int parameter)
{
	int eventID = offsetof(PMDG_NGX_Data, COMM_ServiceInterphoneSw);
}

__declspec(dllexport) int RaisePMDGEvent(int pmdgEvent, int parameter)
{
	if (hSimConnect==NULL)
		return -1;

	// wait for the previous command to finish
	while (sControl.Event != 0)
		Sleep(2);

	sControl.Event = pmdgEvent;
	sControl.Parameter = parameter;
	int hr=SimConnect_SetClientData (hSimConnect, PMDG_NGX_CONTROL_ID,	PMDG_NGX_CONTROL_DEFINITION, 0, 0, sizeof(PMDG_NGX_Control), &sControl);
	return hr>0 ? 1 : 0;
}


