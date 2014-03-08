using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using MipPanels_PMDG;

// Add these two statements to all SimConnect clients
using Microsoft.FlightSimulator.SimConnect;
using System.Runtime.InteropServices;

namespace SimInterface
{
    public partial class MainForm : Form
    {
        private Thread _updateThread;
        
        // User-defined win32 event
        const int WM_USER_SIMCONNECT = 0x0402;

        // SimConnect object
        SimConnect simconnect = null;
        SDK.PMDG_NGX_Data pmdgData;
        
        enum EVENTS
        {
            AP_MASTER,
            PITOT_TOGGLE,
            FLAPS_INC,
            FLAPS_DEC,
            FLAPS_UP,
            FLAPS_DOWN,
        };

        enum DEFINITION
        {
            MCP
        }

        enum DATA_REQUESTS
        {
            REQUEST_MCP,
        };

        enum DATA_REQUEST_ID
        {
            DATA_REQUEST,
            CONTROL_REQUEST,
            AIR_PATH_REQUEST
        };

        enum REQUESTS
        {
            CLIENT_REQUEST
        }

        struct MCP
        {
            public bool ap_master;
        };

        enum NOTIFICATION_GROUPS
        {
            GROUP0,
        }

        enum CLIENT_DATA_IDS
        {
            PMDG_NGX_DATA_ID = 0x4E477831,
            PMDG_NGX_DATA_DEFINITION = 0x4E477832,
            PMDG_NGX_CONTROL_ID = 0x4E477833,
            PMDG_NGX_CONTROL_DEFINITION = 0x4E477834,
        };

        public MainForm()
        {
            // just to make sure
            int expected = 680;
            int managedSize = Marshal.SizeOf(typeof(SDK.PMDG_NGX_Data));
            Debug.Assert(managedSize == expected, string.Format("Unexpected pmdg managed struct size {0}!={1}", managedSize, expected));
            int nativeSize = NativeMethod.GetPMDGDataStructureLength();
            Debug.Assert(nativeSize == expected, String.Format("Unexpected pmdg native struct size {0}!={1}", nativeSize, expected));

            InitializeComponent();

            // start the update thread
            _updateThread = new Thread(ReadData) { IsBackground = true, Priority = ThreadPriority.BelowNormal };
            _updateThread.Start();
        }

        void ReadData()
        {
            while (true)
            {
                UpdatePMDG();
                Thread.Sleep(300);
            }
        }

        void UpdatePMDG()
        {
            this.Invoke((MethodInvoker)delegate {
                pmdgData = NativeMethod.GetPMDGData();

                mcp_cmd_a.Checked = (pmdgData.MCP_annunCMD_A == 1 ? true : false);
            });
        }

        //Handle incoming messages
        protected override void DefWndProc(ref Message m)
        {
            if (m.Msg == WM_USER_SIMCONNECT)
            {
                if (simconnect != null)
                {
                    simconnect.ReceiveMessage();
                }
            }
            else
            {
                base.DefWndProc(ref m);
            }
        }

        private void closeConnection()
        {
            if (simconnect != null)
            {
                simconnect.Dispose();
                simconnect = null;
                Debug.Write("Disconnected");
            }
            if (_updateThread != null)
            {
                _updateThread.Abort();
            }
        }

        // Set up all the SimConnect related event handlers
        private void initClientEvent()
        {
            try
            {
                // listen to connect and quit msgs
                simconnect.OnRecvOpen += new SimConnect.RecvOpenEventHandler(simconnect_OnRecvOpen);
                simconnect.OnRecvQuit += new SimConnect.RecvQuitEventHandler(simconnect_OnRecvQuit);
                simconnect.OnRecvException += new SimConnect.RecvExceptionEventHandler(simconnect_OnRecvException);
                simconnect.OnRecvEvent += new SimConnect.RecvEventEventHandler(simconnect_OnRecvEvent);
                                
                //Subscribe to events. Used to trigger data requests.
                simconnect.MapClientEventToSimEvent(EVENTS.AP_MASTER, "AP_MASTER");
                simconnect.AddClientEventToNotificationGroup(NOTIFICATION_GROUPS.GROUP0, EVENTS.AP_MASTER, false);

                //Data request definitions. These are used when when we receive events.
                simconnect.AddToDataDefinition(DEFINITION.MCP, "Autopilot Master", "Boolean", SIMCONNECT_DATATYPE.INT64, 0.0f, SimConnect.SIMCONNECT_UNUSED);
                
                simconnect.RegisterDataDefineStruct<MCP>(DEFINITION.MCP);
                
                simconnect.OnRecvSimobjectDataBytype += new SimConnect.RecvSimobjectDataBytypeEventHandler(simconnect_OnRecvSimobjectDataBytype);

                // set the group priority
                simconnect.SetNotificationGroupPriority(NOTIFICATION_GROUPS.GROUP0, SimConnect.SIMCONNECT_GROUP_PRIORITY_HIGHEST);
            }
            catch (COMException ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        void simconnect_OnRecvOpen(SimConnect sender, SIMCONNECT_RECV_OPEN data)
        {
            Debug.WriteLine("Connected to FSX");
        }

        // The case where the user closes FSX
        void simconnect_OnRecvQuit(SimConnect sender, SIMCONNECT_RECV data)
        {
            Debug.WriteLine("FSX has exited");
            closeConnection();
        }

        void simconnect_OnRecvException(SimConnect sender, SIMCONNECT_RECV_EXCEPTION data)
        {
            Debug.WriteLine("Exception received: " + data.dwException);
        }

        //Event received. Should trigger a request for the actual data.
        void simconnect_OnRecvEvent(SimConnect sender, SIMCONNECT_RECV_EVENT recEvent)
        {
            switch (recEvent.uEventID)
            {
                case (uint)EVENTS.AP_MASTER:
                    simconnect.RequestDataOnSimObjectType(DATA_REQUESTS.REQUEST_MCP, DEFINITION.MCP, 0, SIMCONNECT_SIMOBJECT_TYPE.USER);
                    break;
            }
        }

        //Data received in response to a request being sent in response to an event being received. Phew.
        void simconnect_OnRecvSimobjectDataBytype(SimConnect sender, SIMCONNECT_RECV_SIMOBJECT_DATA_BYTYPE data)
        {
            switch ((DATA_REQUESTS)data.dwRequestID)
            {
                case DATA_REQUESTS.REQUEST_MCP:
                    MCP mcp = (MCP)data.dwData[0];

                    mcp_cmd_a.Checked = mcp.ap_master;
                    break;
                default:
                    Debug.WriteLine("Unknown request ID: " + data.dwRequestID);
                    break;
            }
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            closeConnection();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            if (simconnect == null)
            {
                try
                {
                    simconnect = new SimConnect("Managed Client Events", this.Handle, WM_USER_SIMCONNECT, null, 0);
                    initClientEvent();
                }
                catch (COMException ex)
                {
                    Debug.WriteLine("Unable to connect to FSX " + ex.Message);
                }
            }
            else
            {
                Debug.WriteLine("Error - try again");
                closeConnection();
            }
        }

        private void toggleManagedPMDGControl(SDK.PMDGEvents pmdgEvent, RadioButton indicator)
        {
            NativeMethod.RaisePMDGEvent(pmdgEvent, (indicator.Checked ? 0 : 1));
            indicator.Checked = !indicator.Checked;
        }

        private void setManagedPMDGControl(SDK.PMDGEvents pmdgEvent, int data)
        {
            NativeMethod.RaisePMDGEvent(pmdgEvent, data);
        }

        private void togglePMDGControl(SDK.PMDGEvents pmdgEvent, int data, RadioButton indicator)
        {
            data = ~data;
            NativeMethod.RaisePMDGEvent(SDK.PMDGEvents.EVT_MCP_CMD_A_SWITCH, data);
            indicator.Checked = (data == 1 ? true : false);
        }
        
        private void btn_mcp_cmd_a_Click(object sender, EventArgs e)
        {
            //simconnect.TransmitClientEvent(SimConnect.SIMCONNECT_OBJECT_ID_USER, EVENTS.AP_MASTER, 1, NOTIFICATION_GROUPS.GROUP0, SIMCONNECT_EVENT_FLAG.DEFAULT); //Native FSX. Doesn't work with PMDG.
            togglePMDGControl(SDK.PMDGEvents.EVT_MCP_CMD_A_SWITCH, pmdgData.MCP_annunCMD_A, mcp_cmd_a);
        }

        private void btn_efis_wxr_Click(object sender, EventArgs e)
        {
            toggleManagedPMDGControl(SDK.PMDGEvents.EVT_EFIS_CPT_WXR, efis_wxr);
        }

        private void btn_efis_sta_Click(object sender, EventArgs e)
        {
            toggleManagedPMDGControl(SDK.PMDGEvents.EVT_EFIS_CPT_STA, efis_sta);
        }

        private void btn_efis_wpt_Click(object sender, EventArgs e)
        {
            toggleManagedPMDGControl(SDK.PMDGEvents.EVT_EFIS_CPT_WPT, efis_wpt);
        }

        private void btn_efis_arpt_Click(object sender, EventArgs e)
        {
            toggleManagedPMDGControl(SDK.PMDGEvents.EVT_EFIS_CPT_ARPT, efis_arpt);
        }

        private void btn_efis_data_Click(object sender, EventArgs e)
        {
            toggleManagedPMDGControl(SDK.PMDGEvents.EVT_EFIS_CPT_DATA, efis_data);
        }

        private void btn_efis_pos_Click(object sender, EventArgs e)
        {
            toggleManagedPMDGControl(SDK.PMDGEvents.EVT_EFIS_CPT_POS, efis_pos);
        }

        private void btn_efis_terr_Click(object sender, EventArgs e)
        {
            toggleManagedPMDGControl(SDK.PMDGEvents.EVT_EFIS_CPT_TERR, efis_terr);
        }

        private void efis_mins_radio_Click(object sender, EventArgs e)
        {
            setManagedPMDGControl(SDK.PMDGEvents.EVT_EFIS_CPT_MINIMUMS_RADIO_BARO, 0);
        }

        private void efis_mins_baro_Click(object sender, EventArgs e)
        {
            setManagedPMDGControl(SDK.PMDGEvents.EVT_EFIS_CPT_MINIMUMS_RADIO_BARO, 1);
        }

        private void efis_mins_reset_Click(object sender, EventArgs e)
        {
            setManagedPMDGControl(SDK.PMDGEvents.EVT_EFIS_CPT_MINIMUMS_RST, int.MaxValue);
        }

        private void efis_mins_dec_Click(object sender, EventArgs e)
        {
            setManagedPMDGControl(SDK.PMDGEvents.EVT_EFIS_CPT_MINIMUMS, 10000);
        }

        private void efis_mins_inc_Click(object sender, EventArgs e)
        {
            setManagedPMDGControl(SDK.PMDGEvents.EVT_EFIS_CPT_MINIMUMS, int.MinValue);
        }

        private void btn_efis_sel_l_vor_Click(object sender, EventArgs e)
        {
            setManagedPMDGControl(SDK.PMDGEvents.EVT_EFIS_CPT_VOR_ADF_SELECTOR_L, 0);
        }

        private void btn_efis_sel_l_off_Click(object sender, EventArgs e)
        {
            setManagedPMDGControl(SDK.PMDGEvents.EVT_EFIS_CPT_VOR_ADF_SELECTOR_L, 1);
        }

        private void btn_efis_sel_l_adf_Click(object sender, EventArgs e)
        {
            setManagedPMDGControl(SDK.PMDGEvents.EVT_EFIS_CPT_VOR_ADF_SELECTOR_L, 2);
        }

        private void btn_efis_sel_r_vor_Click(object sender, EventArgs e)
        {
            setManagedPMDGControl(SDK.PMDGEvents.EVT_EFIS_CPT_VOR_ADF_SELECTOR_R, 0);
        }

        private void btn_efis_sel_r_off_Click(object sender, EventArgs e)
        {
            setManagedPMDGControl(SDK.PMDGEvents.EVT_EFIS_CPT_VOR_ADF_SELECTOR_R, 1);
        }

        private void btn_efis_sel_r_adf_Click(object sender, EventArgs e)
        {
            setManagedPMDGControl(SDK.PMDGEvents.EVT_EFIS_CPT_VOR_ADF_SELECTOR_R, 2);
        }

        private void btn_efis_mode_ctr_Click(object sender, EventArgs e)
        {
            Random random = new Random();
            int rnd = random.Next(int.MaxValue);
            setManagedPMDGControl(SDK.PMDGEvents.EVT_EFIS_CPT_MODE_CTR, rnd);
        }

        private void btn_efis_mode_app_Click(object sender, EventArgs e)
        {
            setManagedPMDGControl(SDK.PMDGEvents.EVT_EFIS_CPT_MODE, 0);
        }

        private void btn_efis_mode_vor_Click(object sender, EventArgs e)
        {
            setManagedPMDGControl(SDK.PMDGEvents.EVT_EFIS_CPT_MODE, 1);
        }

        private void btn_efis_mode_map_Click(object sender, EventArgs e)
        {
            setManagedPMDGControl(SDK.PMDGEvents.EVT_EFIS_CPT_MODE, 2);
        }

        private void btn_efis_mode_pln_Click(object sender, EventArgs e)
        {
            setManagedPMDGControl(SDK.PMDGEvents.EVT_EFIS_CPT_MODE, 3);
        }

        private void btn_efis_tfc_Click(object sender, EventArgs e)
        {
            toggleManagedPMDGControl(SDK.PMDGEvents.EVT_EFIS_CPT_RANGE_TFC, efis_tfc);
        }

        private void btn_efis_range_5_Click(object sender, EventArgs e)
        {
            setManagedPMDGControl(SDK.PMDGEvents.EVT_EFIS_CPT_RANGE, 0);
        }

        private void btn_efis_range_10_Click(object sender, EventArgs e)
        {
            setManagedPMDGControl(SDK.PMDGEvents.EVT_EFIS_CPT_RANGE, 1);
        }

        private void btn_efis_range_20_Click(object sender, EventArgs e)
        {
            setManagedPMDGControl(SDK.PMDGEvents.EVT_EFIS_CPT_RANGE, 2);
        }

        private void btn_efis_range_40_Click(object sender, EventArgs e)
        {
            setManagedPMDGControl(SDK.PMDGEvents.EVT_EFIS_CPT_RANGE, 3);
        }

        private void btn_efis_range_80_Click(object sender, EventArgs e)
        {
            setManagedPMDGControl(SDK.PMDGEvents.EVT_EFIS_CPT_RANGE, 4);
        }

        private void btn_efis_range_160_Click(object sender, EventArgs e)
        {
            setManagedPMDGControl(SDK.PMDGEvents.EVT_EFIS_CPT_RANGE, 5);
        }

        private void btn_efis_range_320_Click(object sender, EventArgs e)
        {
            setManagedPMDGControl(SDK.PMDGEvents.EVT_EFIS_CPT_RANGE, 6);
        }

        private void btn_efis_range_640_Click(object sender, EventArgs e)
        {
            setManagedPMDGControl(SDK.PMDGEvents.EVT_EFIS_CPT_RANGE, 7);
        }

        private void btn_efis_baro_in_Click(object sender, EventArgs e)
        {
            setManagedPMDGControl(SDK.PMDGEvents.EVT_EFIS_CPT_BARO_IN_HPA, 0);
        }

        private void btn_efis_baro_hpa_Click(object sender, EventArgs e)
        {
            setManagedPMDGControl(SDK.PMDGEvents.EVT_EFIS_CPT_BARO_IN_HPA, 1);
        }

        private void btn_efis_baro_std_Click(object sender, EventArgs e)
        {
            setManagedPMDGControl(SDK.PMDGEvents.EVT_EFIS_CPT_BARO_STD, int.MaxValue);
        }

        private void btn_efis_baro_dec_Click(object sender, EventArgs e)
        {
            setManagedPMDGControl(SDK.PMDGEvents.EVT_EFIS_CPT_BARO, 10000);
        }

        private void btn_efis_baro_inc_Click(object sender, EventArgs e)
        {
            setManagedPMDGControl(SDK.PMDGEvents.EVT_EFIS_CPT_BARO, int.MinValue);
        }
    }
}
