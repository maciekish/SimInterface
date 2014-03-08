#include <windows.h>
#include <stdio.h>
#include <stddef.h>

#include "SimConnect.h"
#include "PMDG_NGX_SDK.h"

// public

__declspec(dllexport) void SetACLoadedCallback(void(* callback)(char *airPath));
__declspec(dllexport) void* GetPMDGData();
__declspec(dllexport) int GetPMDGDataStructureLength();
__declspec(dllexport) int RaisePMDGEvent(int pmdgEvent, int parameter);

// private

bool InitSimConnect(bool restart);
void CloseSimConnect();
DWORD WINAPI PollForData(LPVOID lpParam);
void CALLBACK MyDispatchProc(SIMCONNECT_RECV* pData, DWORD cbData, void *pContext);
void SetupDataConnection();
void SetupControlConnection();
