using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

// Add these two statements to all SimConnect clients
using Microsoft.FlightSimulator.SimConnect;
using System.Runtime.InteropServices;

namespace SimInterface
{
    public partial class MainForm : Form
    {
        // User-defined win32 event
        const int WM_USER_SIMCONNECT = 0x0402;

        // SimConnect object
        SimConnect simconnect = null;

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

        struct MCP
        {
            public bool ap_master;
        };

        enum NOTIFICATION_GROUPS
        {
            GROUP0,
        }

        public MainForm()
        {
            InitializeComponent();
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

                    chk_mcp_cmd_a.CheckedChanged -= chk_mcp_cmd_a_CheckedChanged;
                    chk_mcp_cmd_a.Checked = mcp.ap_master;
                    chk_mcp_cmd_a.CheckedChanged += chk_mcp_cmd_a_CheckedChanged;
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

        private void chk_mcp_cmd_a_CheckedChanged(object sender, EventArgs e)
        {
            simconnect.TransmitClientEvent(SimConnect.SIMCONNECT_OBJECT_ID_USER, EVENTS.AP_MASTER, 1, NOTIFICATION_GROUPS.GROUP0, SIMCONNECT_EVENT_FLAG.DEFAULT);
        }
    }
}
