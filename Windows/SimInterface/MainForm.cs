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
using UsbHid;
using UsbHid.USB.Classes.Messaging;

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

        public UsbHidDevice efisDevice;
        
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

                mcp_crs_l.Text = Convert.ToString(pmdgData.MCP_Course[0]);
                if (pmdgData.MCP_IASBlank == 1)
                    mcp_spd.Text = "";
                else
                    mcp_spd.Text = Convert.ToString(pmdgData.MCP_IASMach);
                mcp_heading.Text = Convert.ToString(pmdgData.MCP_Heading);
                mcp_altitude.Text = Convert.ToString(pmdgData.MCP_Altitude);
                if (pmdgData.MCP_VertSpeedBlank == 1)
                    mcp_vs.Text = "";
                else
                    mcp_vs.Text = Convert.ToString(pmdgData.MCP_VertSpeed);

                mcp_cmd_a.Checked = (pmdgData.MCP_annunCMD_A == 1 ? true : false);
                mcp_cmd_b.Checked = (pmdgData.MCP_annunCMD_B == 1 ? true : false);
                mcp_cws_a.Checked = (pmdgData.MCP_annunCWS_A == 1 ? true : false);
                mcp_cws_b.Checked = (pmdgData.MCP_annunCWS_B == 1 ? true : false);
                mcp_fd.Checked = (pmdgData.MCP_FDSw[0] == 1 ? true : false);
                mcp_at.Checked = (pmdgData.MCP_ATArmSw == 1 ? true : false);
                mcp_n1.Checked = (pmdgData.MCP_annunN1 == 1 ? true : false);
                mcp_speed.Checked = (pmdgData.MCP_annunSPEED == 1 ? true : false);
                mcp_vnav.Checked = (pmdgData.MCP_annunVNAV == 1 ? true : false);
                mcp_lvlchg.Checked = (pmdgData.MCP_annunLVL_CHG == 1 ? true : false);
                mcp_hdgsel.Checked = (pmdgData.MCP_annunHDG_SEL == 1 ? true : false);
                mcp_lnav.Checked = (pmdgData.MCP_annunLNAV == 1 ? true : false);
                mcp_vorloc.Checked = (pmdgData.MCP_annunVOR_LOC == 1 ? true : false);
                mcp_app.Checked = (pmdgData.MCP_annunAPP == 1 ? true : false);
                mcp_althld.Checked = (pmdgData.MCP_annunALT_HOLD == 1 ? true : false);
                mcp_vs_on.Checked = (pmdgData.MCP_annunVS == 1 ? true : false);
                mcp_disengage.Checked = (pmdgData.MCP_DisengageBar == 1 ? true : false);

                /*CommandMessage message = new CommandMessage(1);
                message.Parameters = GetBytes((mcp_lvlchg.Checked ? "LVL_CGH_ON" : "LVL_CGH_OFF"));
                efisDevice.SendMessage(message);*/
            });
        }

        static byte[] GetBytes(string str)
        {
            byte[] bytes = new byte[str.Length * sizeof(char)];
            System.Buffer.BlockCopy(str.ToCharArray(), 0, bytes, 0, bytes.Length);
            return bytes;
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

            efisDevice = new UsbHidDevice(0x16C0, 0x0486);
            efisDevice.OnConnected += deviceOnConnected;
            efisDevice.OnDisConnected += deviceOnDisConnected;
            efisDevice.DataReceived += deviceDataReceived;
            efisDevice.Connect();
        }

        private void deviceOnDisConnected()
        {
            Debug.WriteLine("USB disconnected");
        }

        private void deviceOnConnected()
        {
            Debug.WriteLine("USB connected");

            CommandMessage message = new CommandMessage(1);
            message.Parameters = GetBytes("UPDATE");
            efisDevice.SendMessage(message);
        }

        private void deviceDataReceived(byte[] data)
        {
            byte[] chopped = new byte[64];
            Array.Copy(data, 1, chopped, 0, 64);
            String command = System.Text.Encoding.ASCII.GetString(chopped);
            command = command.Replace("\0", "");
            Debug.WriteLine(command);

            handleCommand(command);
        }

        private void handleCommand(String command)
        {
            this.Invoke((MethodInvoker)delegate
            {
                string[] commandParts = command.Split(':');
                int button = Convert.ToInt32(commandParts[1]);
                
                if (commandParts[0].Equals("EFIS.L"))
                {
                    switch (button)
                    {
                        case 1:
                            setManagedPMDGControl(SDK.PMDGEvents.EVT_EFIS_CPT_VOR_ADF_SELECTOR_L, 2);
                            break;
                        case -1:
                            setManagedPMDGControl(SDK.PMDGEvents.EVT_EFIS_CPT_VOR_ADF_SELECTOR_L, 1); //Off
                            break;
                        case 2:
                            setManagedPMDGControl(SDK.PMDGEvents.EVT_EFIS_CPT_VOR_ADF_SELECTOR_L, 0);
                            break;
                        case -2:
                            setManagedPMDGControl(SDK.PMDGEvents.EVT_EFIS_CPT_VOR_ADF_SELECTOR_L, 1); //Off
                            break;
                        case 3:
                            setManagedPMDGControl(SDK.PMDGEvents.EVT_EFIS_CPT_VOR_ADF_SELECTOR_R, 2);
                            break;
                        case -3:
                            setManagedPMDGControl(SDK.PMDGEvents.EVT_EFIS_CPT_VOR_ADF_SELECTOR_R, 1); //Off
                            break;
                        case 4:
                            setManagedPMDGControl(SDK.PMDGEvents.EVT_EFIS_CPT_VOR_ADF_SELECTOR_R, 0);
                            break;
                        case -4:
                            setManagedPMDGControl(SDK.PMDGEvents.EVT_EFIS_CPT_VOR_ADF_SELECTOR_R, 1); //Off
                            break;
                        case 5:
                            toggleManagedPMDGControl(SDK.PMDGEvents.EVT_EFIS_CPT_WXR, efis_wxr);
                            break;
                        case 6:
                            toggleManagedPMDGControl(SDK.PMDGEvents.EVT_EFIS_CPT_STA, efis_sta);
                            break;
                        case 7:
                            toggleManagedPMDGControl(SDK.PMDGEvents.EVT_EFIS_CPT_WPT, efis_wpt);
                            break;
                        case 8:
                            toggleManagedPMDGControl(SDK.PMDGEvents.EVT_EFIS_CPT_ARPT, efis_arpt);
                            break;
                        case 9:
                            toggleManagedPMDGControl(SDK.PMDGEvents.EVT_EFIS_CPT_DATA, efis_data);
                            break;
                        case 10:
                            toggleManagedPMDGControl(SDK.PMDGEvents.EVT_EFIS_CPT_POS, efis_pos);
                            break;
                        case 11:
                            toggleManagedPMDGControl(SDK.PMDGEvents.EVT_EFIS_CPT_TERR, efis_terr);
                            break;
                        case 16:
                            setManagedPMDGControl(SDK.PMDGEvents.EVT_EFIS_CPT_BARO_STD, int.MaxValue);
                            break;
                        case 22:
                            toggleManagedPMDGControl(SDK.PMDGEvents.EVT_EFIS_CPT_MTRS, efis_mtrs);
                            break;
                        case 23:
                            toggleManagedPMDGControl(SDK.PMDGEvents.EVT_EFIS_CPT_FPV, efis_fpv);
                            break;
                        /*case 2:
                            togglePMDGControl(SDK.PMDGEvents.EVT_MCP_LVL_CHG_SWITCH, pmdgData.MCP_annunLVL_CHG, mcp_lvlchg);
                            break;
                        case "HDG_DEC":
                            setManagedPMDGControl(SDK.PMDGEvents.EVT_MCP_HEADING_SELECTOR, 10000);
                            break;
                        case "HDG_INC":
                            setManagedPMDGControl(SDK.PMDGEvents.EVT_MCP_HEADING_SELECTOR, int.MinValue);
                            break;
                        case "ALT_DEC":
                            setManagedPMDGControl(SDK.PMDGEvents.EVT_MCP_ALTITUDE_SELECTOR, 10000);
                            break;
                        case "ALT_INC":
                            setManagedPMDGControl(SDK.PMDGEvents.EVT_MCP_ALTITUDE_SELECTOR, int.MinValue);
                            break;*/
                    }
                }
            });
        }

        private void toggleManagedPMDGControl(SDK.PMDGEvents pmdgEvent, CheckBox indicator)
        {
            indicator.Checked = !indicator.Checked;
            NativeMethod.RaisePMDGEvent(pmdgEvent, (indicator.Checked ? 1 : 0));
        }

        private void setManagedPMDGControl(SDK.PMDGEvents pmdgEvent, int data)
        {
            NativeMethod.RaisePMDGEvent(pmdgEvent, data);
        }

        private void togglePMDGControl(SDK.PMDGEvents pmdgEvent, int data, CheckBox indicator)
        {
            data = ~data;
            NativeMethod.RaisePMDGEvent(pmdgEvent, data);
            indicator.Checked = (data == 1 ? true : false);
        }
        
        private void btn_mcp_cmd_a_Click(object sender, EventArgs e)
        {
            //simconnect.TransmitClientEvent(SimConnect.SIMCONNECT_OBJECT_ID_USER, EVENTS.AP_MASTER, 1, NOTIFICATION_GROUPS.GROUP0, SIMCONNECT_EVENT_FLAG.DEFAULT); //Native FSX. Doesn't work with PMDG.
            togglePMDGControl(SDK.PMDGEvents.EVT_MCP_CMD_A_SWITCH, pmdgData.MCP_annunCMD_A, mcp_cmd_a);
        }

        private void btn_mcp_cmd_b_Click(object sender, EventArgs e)
        {
            togglePMDGControl(SDK.PMDGEvents.EVT_MCP_CMD_B_SWITCH, pmdgData.MCP_annunCMD_B, mcp_cmd_b);
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

        private void btn_mcp_crs_l_dec_Click(object sender, EventArgs e)
        {
            setManagedPMDGControl(SDK.PMDGEvents.EVT_MCP_COURSE_SELECTOR_L, 10000);
        }

        private void btn_mcp_crs_r_inc_Click(object sender, EventArgs e)
        {
            setManagedPMDGControl(SDK.PMDGEvents.EVT_MCP_COURSE_SELECTOR_L, int.MinValue);
        }

        private void btn_mcp_fd_on_Click(object sender, EventArgs e)
        {
            setManagedPMDGControl(SDK.PMDGEvents.EVT_MCP_FD_SWITCH_L, 0);
        }

        private void btn_mcp_fd_off_Click(object sender, EventArgs e)
        {
            setManagedPMDGControl(SDK.PMDGEvents.EVT_MCP_FD_SWITCH_L, 1);
        }

        private void btn_mcp_at_on_Click(object sender, EventArgs e)
        {
            setManagedPMDGControl(SDK.PMDGEvents.EVT_MCP_AT_ARM_SWITCH, 0);
        }

        private void btn_mcp_at_off_Click(object sender, EventArgs e)
        {
            setManagedPMDGControl(SDK.PMDGEvents.EVT_MCP_AT_ARM_SWITCH, 1);
        }

        private void btn_mcp_spd_co_Click(object sender, EventArgs e)
        {
            setManagedPMDGControl(SDK.PMDGEvents.EVT_MCP_CO_SWITCH, 1);
        }

        private void btn_mcp_spd_spdintv_Click(object sender, EventArgs e)
        {
            setManagedPMDGControl(SDK.PMDGEvents.EVT_MCP_SPD_INTV_SWITCH, 1);
        }

        private void btn_mcp_spd_dec_Click(object sender, EventArgs e)
        {
            setManagedPMDGControl(SDK.PMDGEvents.EVT_MCP_SPEED_SELECTOR, 10000);
        }

        private void btn_mcp_spd_inc_Click(object sender, EventArgs e)
        {
            setManagedPMDGControl(SDK.PMDGEvents.EVT_MCP_SPEED_SELECTOR, int.MinValue);
        }

        private void btn_mcp_heading_dec_Click(object sender, EventArgs e)
        {
            setManagedPMDGControl(SDK.PMDGEvents.EVT_MCP_HEADING_SELECTOR, 10000);
        }

        private void btn_mcp_heading_inc_Click(object sender, EventArgs e)
        {
            setManagedPMDGControl(SDK.PMDGEvents.EVT_MCP_HEADING_SELECTOR, int.MinValue);
        }

        private void btn_mcp_altitude_dec_Click(object sender, EventArgs e)
        {
            setManagedPMDGControl(SDK.PMDGEvents.EVT_MCP_ALTITUDE_SELECTOR, 10000);
        }

        private void btn_mcp_altitude_inc_Click(object sender, EventArgs e)
        {
            setManagedPMDGControl(SDK.PMDGEvents.EVT_MCP_ALTITUDE_SELECTOR, int.MinValue);
        }

        private void btn_mcp_vs_up_Click(object sender, EventArgs e)
        {
            setManagedPMDGControl(SDK.PMDGEvents.EVT_MCP_VS_SELECTOR, 10000);
        }

        private void btn_mcp_vs_dn_Click(object sender, EventArgs e)
        {
            setManagedPMDGControl(SDK.PMDGEvents.EVT_MCP_VS_SELECTOR, int.MinValue);
        }

        private void btn_mcp_altintv_Click(object sender, EventArgs e)
        {
            setManagedPMDGControl(SDK.PMDGEvents.EVT_MCP_ALT_INTV_SWITCH, 1);
        }

        private void btn_mcp_bank_30_Click(object sender, EventArgs e)
        {
            setManagedPMDGControl(SDK.PMDGEvents.EVT_MCP_BANK_ANGLE_SELECTOR, 4);
        }

        private void btn_mcp_bank_20_Click(object sender, EventArgs e)
        {
            setManagedPMDGControl(SDK.PMDGEvents.EVT_MCP_BANK_ANGLE_SELECTOR, 2);
        }

        private void btn_mcp_bank_25_Click(object sender, EventArgs e)
        {
            setManagedPMDGControl(SDK.PMDGEvents.EVT_MCP_BANK_ANGLE_SELECTOR, 3);
        }

        private void btn_mcp_bank_10_Click(object sender, EventArgs e)
        {
            setManagedPMDGControl(SDK.PMDGEvents.EVT_MCP_BANK_ANGLE_SELECTOR, 0);
        }

        private void btn_mcp_bank_15_Click(object sender, EventArgs e)
        {
            setManagedPMDGControl(SDK.PMDGEvents.EVT_MCP_BANK_ANGLE_SELECTOR, 1);
        }

        private void btn_mcp_hdgsel_Click(object sender, EventArgs e)
        {
            togglePMDGControl(SDK.PMDGEvents.EVT_MCP_HDG_SEL_SWITCH, pmdgData.MCP_annunHDG_SEL, mcp_hdgsel);
        }

        private void btn_mcp_vs_Click(object sender, EventArgs e)
        {
            togglePMDGControl(SDK.PMDGEvents.EVT_MCP_VS_SWITCH, pmdgData.MCP_annunVS, mcp_vs_on);
        }

        private void btn_mcp_althld_Click(object sender, EventArgs e)
        {
            togglePMDGControl(SDK.PMDGEvents.EVT_MCP_ALT_HOLD_SWITCH, pmdgData.MCP_annunALT_HOLD, mcp_althld);
        }

        private void btn_mcp_app_Click(object sender, EventArgs e)
        {
            togglePMDGControl(SDK.PMDGEvents.EVT_MCP_APP_SWITCH, pmdgData.MCP_annunAPP, mcp_app);
        }

        private void btn_mcp_lvlchg_Click(object sender, EventArgs e)
        {
            togglePMDGControl(SDK.PMDGEvents.EVT_MCP_LVL_CHG_SWITCH, pmdgData.MCP_annunLVL_CHG, mcp_lvlchg);
        }

        private void btn_mcp_speed_Click(object sender, EventArgs e)
        {
            togglePMDGControl(SDK.PMDGEvents.EVT_MCP_SPEED_SWITCH, pmdgData.MCP_annunSPEED, mcp_speed);
        }

        private void btn_mcp_n1_Click(object sender, EventArgs e)
        {
            togglePMDGControl(SDK.PMDGEvents.EVT_MCP_N1_SWITCH, pmdgData.MCP_annunN1, mcp_n1);
        }

        private void btn_mcp_vorloc_Click(object sender, EventArgs e)
        {
            togglePMDGControl(SDK.PMDGEvents.EVT_MCP_VOR_LOC_SWITCH, pmdgData.MCP_annunVOR_LOC, mcp_vorloc);
        }

        private void btn_mcp_lnav_Click(object sender, EventArgs e)
        {
            togglePMDGControl(SDK.PMDGEvents.EVT_MCP_LNAV_SWITCH, pmdgData.MCP_annunLNAV, mcp_lnav);
        }

        private void btn_mcp_vnav_Click(object sender, EventArgs e)
        {
            togglePMDGControl(SDK.PMDGEvents.EVT_MCP_VNAV_SWITCH, pmdgData.MCP_annunVNAV, mcp_vnav);
        }

        private void btn_mcp_disengage_Click(object sender, EventArgs e)
        {
            togglePMDGControl(SDK.PMDGEvents.EVT_MCP_DISENGAGE_BAR, pmdgData.MCP_DisengageBar, mcp_disengage);
        }

        private void btn_mcp_cws_a_Click(object sender, EventArgs e)
        {
            togglePMDGControl(SDK.PMDGEvents.EVT_MCP_CWS_A_SWITCH, pmdgData.MCP_annunCWS_A, mcp_cws_a);
        }

        private void btn_mcp_cws_b_Click(object sender, EventArgs e)
        {
            togglePMDGControl(SDK.PMDGEvents.EVT_MCP_CWS_B_SWITCH, pmdgData.MCP_annunCWS_B, mcp_cws_b);
        }
    }
}
