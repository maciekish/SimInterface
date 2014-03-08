using System;
using System.Runtime.InteropServices;

namespace MipPanels_PMDG
{
    // we should change most bytes back into [MarshalAs(UnmanagedType.I1)] public bool
    // but that doesn't work for bool[] ????

    public class SDK
    {
        public const string PMDG_NGX_DATA_NAME = "PMDG_NGX_Data";
        public const string PMDG_NGX_CONTROL_NAME = "PMDG_NGX_Control";

        //public enum PMDGIds : uint
        //{
        //    PMDG_NGX_DATA_ID = 0x4E477831,
        //    PMDG_NGX_DATA_DEFINITION = 0x4E477832,
        //    PMDG_NGX_CONTROL_ID = 0x4E477833,
        //    PMDG_NGX_CONTROL_DEFINITION = 0x4E477834,
        //}

        // N O T E - add these lines: 
        //
        //[SDK]
        //EnableDataBroadcast=1
        //
        // to enable the data sending from the NGX.


        // NGX data structure
        [StructLayout(LayoutKind.Sequential, Pack=4, CharSet = CharSet.Ansi)]
        public struct PMDG_NGX_Data
        {

            ////////////////////////////////////////////
            // Controls and indicators
            ////////////////////////////////////////////

            // Aft overhead
            //------------------------------------------

            // ADIRU
            public byte IRS_DisplaySelector; // Positions 0..4
            public byte IRS_SysDisplay_R; // false: L  true: R
            public byte IRS_annunGPS;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)] public byte[] IRS_annunALIGN;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)] public byte[] IRS_annunON_DC;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)] public byte[] IRS_annunFAULT;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)] public byte[] IRS_annunDC_FAIL;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)] public byte[] IRS_ModeSelector; // 0: OFF  1: ALIGN  2: NAV  3: ATT

            // PSEU
            public byte WARN_annunPSEU;

            // Service Interphone
            public byte COMM_ServiceInterphoneSw;

            // Lights
            public byte LTS_DomeWhiteSw; // 0: DIM  1: OFF  2: BRIGHT

            // Engine
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)] public byte[] ENG_EECSwitch;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)] public byte[] ENG_annunREVERSER;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)] public byte[] ENG_annunENGINE_CONTROL;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)] public byte[] ENG_annunALTN;

            // Oxygen
            public byte OXY_Needle; // Position 0...240
            public byte OXY_SwNormal; // true: NORMAL  false: ON
            public byte OXY_annunPASS_OXY_ON;

            // Gear
            public byte GEAR_annunOvhdLEFT;
            public byte GEAR_annunOvhdNOSE;
            public byte GEAR_annunOvhdRIGHT;

            // Flight recorder
            public byte FLTREC_SwNormal; // true: NORMAL  false: TEST
            public byte FLTREC_annunOFF;


            // Forward overhead
            //------------------------------------------

            // Flight Controls
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)] public byte[] FCTL_FltControl_Sw; // 0: STBY/RUD  1: OFF  2: ON
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)] public byte[] FCTL_Spoiler_Sw; // true: ON  false: OFF  
            public byte FCTL_YawDamper_Sw;
            public byte FCTL_AltnFlaps_Sw_ARM; // true: ARM  false: OFF
            public byte FCTL_AltnFlaps_Control_Sw; // 0: UP  1: OFF  2: DOWN
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)] public byte[] FCTL_annunFC_LOW_PRESSURE; // FLT CONTROL
            public byte FCTL_annunYAW_DAMPER;
            public byte FCTL_annunLOW_QUANTITY;
            public byte FCTL_annunLOW_PRESSURE;
            public byte FCTL_annunLOW_STBY_RUD_ON;
            public byte FCTL_annunFEEL_DIFF_PRESS;
            public byte FCTL_annunSPEED_TRIM_FAIL;
            public byte FCTL_annunMACH_TRIM_FAIL;
            public byte FCTL_annunAUTO_SLAT_FAIL;

            // Navigation/Displays
            public byte NAVDIS_VHFNavSelector; // 0: BOTH ON 1  1: NORMAL  2: BOTH ON 2
            public byte NAVDIS_IRSSelector; // 0: BOTH ON L  1: NORMAL  2: BOTH ON R
            public byte NAVDIS_FMCSelector; // 0: BOTH ON L  1: NORMAL  2: BOTH ON R
            public byte NAVDIS_SourceSelector; // 0: ALL ON 1   1: AUTO    2: ALL ON 2
            public byte NAVDIS_ControlPaneSelector; // 0: BOTH ON 1  1: NORMAL  2: BOTH ON 2

            // Fuel
            public float FUEL_FuelTempNeedle; // Value
            public byte FUEL_CrossFeedSw;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)] public byte[] FUEL_PumpFwdSw; // left fwd / right fwd
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)] public byte[] FUEL_PumpAftSw; // left aft / right aft
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)] public byte[] FUEL_PumpCtrSw; // ctr left / ctr right
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)] public byte[] FUEL_annunENG_VALVE_CLOSED;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)] public byte[] FUEL_annunSPAR_VALVE_CLOSED;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)] public byte[] FUEL_annunFILTER_BYPASS;
            public byte FUEL_annunXFEED_VALVE_OPEN;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)] public byte[] FUEL_annunLOWPRESS_Fwd;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)] public byte[] FUEL_annunLOWPRESS_Aft;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)] public byte[] FUEL_annunLOWPRESS_Ctr;

            // Electrical
            public byte ELEC_annunBAT_DISCHARGE;
            public byte ELEC_annunTR_UNIT;
            public byte ELEC_annunELEC;
            public byte ELEC_DCMeterSelector; // 0: STBY PWR  1: BAT BUS ... 7: TEST
            public byte ELEC_ACMeterSelector; // 0: STBY PWR  1: GND PWR ... 6: TEST
            public byte ELEC_BatSelector; // 0: OFF  1: BAT  2: ON
            public byte ELEC_CabUtilSw;
            public byte ELEC_IFEPassSeatSw;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)] public byte[] ELEC_annunDRIVE;
            public byte ELEC_annunSTANDBY_POWER_OFF;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)] public byte[] ELEC_IDGDisconnectSw;
            public byte ELEC_StandbyPowerSelector; // 0: BAT  1: OFF  2: AUTO
            public byte ELEC_annunGRD_POWER_AVAILABLE;
            public byte ELEC_GrdPwrSw;
            public byte ELEC_BusTransSw_AUTO;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)] public byte[] ELEC_GenSw;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)] public byte[] ELEC_APUGenSw;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)] public byte[] ELEC_annunTRANSFER_BUS_OFF;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)] public byte[] ELEC_annunSOURCE_OFF;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)] public byte[] ELEC_annunGEN_BUS_OFF;
            public byte ELEC_annunAPU_GEN_OFF_BUS;

            // APU
            public float APU_EGTNeedle; // Value
            public byte APU_annunMAINT;
            public byte APU_annunLOW_OIL_PRESSURE;
            public byte APU_annunFAULT;
            public byte APU_annunOVERSPEED;

            // Wipers
            public byte OH_WiperLSelector; // 0: PARK  1: INT  2: LOW  3:HIGH
            public byte OH_WiperRSelector; // 0: PARK  1: INT  2: LOW  3:HIGH

            // Center overhead controls & indicators
            public byte LTS_CircuitBreakerKnob; // Position 0...150
            public byte LTS_OvereadPanelKnob; // Position 0...150
            public byte AIR_EquipCoolingSupplyNORM;
            public byte AIR_EquipCoolingExhaustNORM;
            public byte AIR_annunEquipCoolingSupplyOFF;
            public byte AIR_annunEquipCoolingExhaustOFF;
            public byte LTS_annunEmerNOT_ARMED;
            public byte LTS_EmerExitSelector; // 0: OFF  1: ARMED  2: ON
            public byte COMM_NoSmokingSelector; // 0: OFF  1: AUTO   2: ON
            public byte COMM_FastenBeltsSelector; // 0: OFF  1: AUTO   2: ON
            public byte COMM_annunCALL;
            public byte COMM_annunPA_IN_USE;

            // Anti-ice
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)] public byte[] ICE_annunOVERHEAT;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)] public byte[] ICE_annunON;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)] public byte[] ICE_WindowHeatSw;
            public byte ICE_annunCAPT_PITOT;
            public byte ICE_annunL_ELEV_PITOT;
            public byte ICE_annunL_ALPHA_VANE;
            public byte ICE_annunL_TEMP_PROBE;
            public byte ICE_annunFO_PITOT;
            public byte ICE_annunR_ELEV_PITOT;
            public byte ICE_annunR_ALPHA_VANE;
            public byte ICE_annunAUX_PITOT;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)] public byte[] ICE_TestProbeHeatSw;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)] public byte[] ICE_annunVALVE_OPEN;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)] public byte[] ICE_annunCOWL_ANTI_ICE;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)] public byte[] ICE_annunCOWL_VALVE_OPEN;
            public byte ICE_WingAntiIceSw;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)] public byte[] ICE_EngAntiIceSw;

            // Hydraulics
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)] public byte[] HYD_annunLOW_PRESS_eng;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)] public byte[] HYD_annunLOW_PRESS_elec;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)] public byte[] HYD_annunOVERHEAT_elec;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)] public byte[] HYD_PumpSw_eng;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)] public byte[] HYD_PumpSw_elec;

            // Air systems
            public byte AIR_TempSourceSelector; // Positions 0..6
            public byte AIR_TrimAirSwitch;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)] public byte[] AIR_annunZoneTemp;
            public byte AIR_annunDualBleed;
            public byte AIR_annunRamDoorL;
            public byte AIR_annunRamDoorR;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)] public byte[] AIR_RecircFanSwitch;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)] public byte[] AIR_PackSwitch; // 0=OFF  1=AUTO  2=HIGH
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)] public byte[] AIR_BleedAirSwitch;
            public byte AIR_APUBleedAirSwitch;
            public byte AIR_IsolationValveSwitch;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)] public byte[] AIR_annunPackTripOff;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)] public byte[] AIR_annunWingBodyOverheat;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)] public byte[] AIR_annunBleedTripOff;

            public uint AIR_FltAltWindow;
            public uint AIR_LandAltWindow;
            public uint AIR_OutflowValveSwitch; // 0=CLOSE  1=NEUTRAL  2=OPEN
            public uint AIR_PressurizationModeSelector; // 0=AUTO  1=ALTN  2=MAN

            // Bottom overhead
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)] public byte[] LTS_LandingLtRetractableSw; // 0: RETRACT  1: EXTEND  2: ON
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)] public byte[] LTS_LandingLtFixedSw;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)] public byte[] LTS_RunwayTurnoffSw;
            public byte LTS_TaxiSw;
            public byte APU_Selector; // 0: OFF  1: ON  2: START
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)] public byte[] ENG_StartSelector; // 0: GRD  1: OFF  2: CONT  3: FLT
            public byte ENG_IgnitionSelector; // 0: IGN L  1: BOTH  2: IGN R
            public byte LTS_LogoSw;
            public byte LTS_PositionSw; // 0: STEADY  1: OFF  2: STROBE&STEADY
            public byte LTS_AntiCollisionSw;
            public byte LTS_WingSw;
            public byte LTS_WheelWellSw;

            // Glareshield
            //------------------------------------------

            // Warnings
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)] public byte[] WARN_annunFIRE_WARN;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)] public byte[] WARN_annunMASTER_CAUTION;
            public byte WARN_annunFLT_CONT;
            public byte WARN_annunIRS;
            public byte WARN_annunFUEL;
            public byte WARN_annunELEC;
            public byte WARN_annunAPU;
            public byte WARN_annunOVHT_DET;
            public byte WARN_annunANTI_ICE;
            public byte WARN_annunHYD;
            public byte WARN_annunDOORS;
            public byte WARN_annunENG;
            public byte WARN_annunOVERHEAD;
            public byte WARN_annunAIR_COND;

            // EFIS control panels
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)] public byte[] EFIS_MinsSelBARO;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)] public byte[] EFIS_BaroSelHPA;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)] public byte[] EFIS_VORADFSel1; // 0: VOR  1: OFF  2: ADF
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)] public byte[] EFIS_VORADFSel2; // 0: VOR  1: OFF  2: ADF
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)] public byte[] EFIS_ModeSel; // 0: APP  1: VOR  2: MAP  3: PLAn
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)] public byte[] EFIS_RangeSel; // 0: 5 ... 7: 640

            // Mode control panel
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)] public ushort[] MCP_Course;
            public float MCP_IASMach; // Mach if < 10.0
            public byte MCP_IASBlank;
            public byte MCP_IASOverspeedFlash;
            public byte MCP_IASUnderspeedFlash;
            public ushort MCP_Heading;
            public ushort MCP_Altitude;
            public short MCP_VertSpeed;
            public byte MCP_VertSpeedBlank;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)] public byte[] MCP_FDSw;
            public byte MCP_ATArmSw;
            public byte MCP_BankLimitSel; // 0: 10 ... 4: 30
            public byte MCP_DisengageBar;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)] public byte[] MCP_annunFD;
            public byte MCP_annunATArm;
            public byte MCP_annunN1;
            public byte MCP_annunSPEED;
            public byte MCP_annunVNAV;
            public byte MCP_annunLVL_CHG;
            public byte MCP_annunHDG_SEL;
            public byte MCP_annunLNAV;
            public byte MCP_annunVOR_LOC;
            public byte MCP_annunAPP;
            public byte MCP_annunALT_HOLD;
            public byte MCP_annunVS;
            public byte MCP_annunCMD_A;
            public byte MCP_annunCWS_A;
            public byte MCP_annunCMD_B;
            public byte MCP_annunCWS_B;

            // Forward panel
            //------------------------------------------
            public byte MAIN_NoseWheelSteeringSwNORM; // false: ALT
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)] public byte[] MAIN_annunBELOW_GS;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)] public byte[] MAIN_MainPanelDUSel; // 0: OUTBD PFD ... 4 MFD for Capt; reverse sequence for FO
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)] public byte[] MAIN_LowerDUSel; // 0: ENG PRI ... 2 ND for Capt; reverse sequence for FO
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)] public byte[] MAIN_annunAP;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)] public byte[] MAIN_annunAT;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)] public byte[] MAIN_annunFMC;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)] public byte[] MAIN_DisengageTestSelector; // 0: 1  1: OFF  2: 2
            public byte MAIN_annunSPEEDBRAKE_ARMED;
            public byte MAIN_annunSPEEDBRAKE_DO_NOT_ARM;
            public byte MAIN_annunSPEEDBRAKE_EXTENDED;
            public byte MAIN_annunSTAB_OUT_OF_TRIM;
            public byte MAIN_LightsSelector; // 0: TEST  1: BRT  2: DIM
            public byte MAIN_RMISelector1_VOR;
            public byte MAIN_RMISelector2_VOR;
            public byte MAIN_N1SetSelector; // 0: 2  1: 1  2: AUTO  3: BOTH
            public byte MAIN_SpdRefSelector; // 0: SET  1: AUTO  2: V1  3: VR  4: WT  5: VREF  6: B ug  
            public byte MAIN_FuelFlowSelector; // 0: RESET  1: RATE  2: USED
            public byte MAIN_AutobrakeSelector; // 0: RTO  1: OFF ... 5: MAX
            public byte MAIN_annunANTI_SKID_INOP;
            public byte MAIN_annunAUTO_BRAKE_DISARM;
            public byte MAIN_annunLE_FLAPS_TRANSIT;
            public byte MAIN_annunLE_FLAPS_EXT;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)] public float[] MAIN_TEFlapsNeedle; // Value
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)] public byte[] MAIN_annunGEAR_transit;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)] public byte[] MAIN_annunGEAR_locked;
            public byte MAIN_GearLever; // 0: UP  1: OFF  2: DOWN
            public float MAIN_BrakePressNeedle; // Value

            public byte HGS_annun_AIII;
            public byte HGS_annun_NO_AIII;
            public byte HGS_annun_FLARE;
            public byte HGS_annun_RO;
            public byte HGS_annun_RO_CTN;
            public byte HGS_annun_RO_ARM;
            public byte HGS_annun_TO;
            public byte HGS_annun_TO_CTN;
            public byte HGS_annun_APCH;
            public byte HGS_annun_TO_WARN;
            public byte HGS_annun_Bar;
            public byte HGS_annun_FAIL;

            // Lower forward panel
            //------------------------------------------
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)] public byte[] LTS_MainPanelKnob; // Position 0...150
            public byte LTS_BackgroundKnob; // Position 0...150
            public byte LTS_AFDSFloodKnob; // Position 0...150
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)] public byte[] LTS_OutbdDUBrtKnob; // Position 0...127
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)] public byte[] LTS_InbdDUBrtKnob; // Position 0...127
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)] public byte[] LTS_InbdDUMapBrtKnob; // Position 0...127
            public byte LTS_UpperDUBrtKnob; // Position 0...127
            public byte LTS_LowerDUBrtKnob; // Position 0...127
            public byte LTS_LowerDUMapBrtKnob; // Position 0...127

            public byte GPWS_annunINOP;
            public byte GPWS_FlapInhibitSw_NORM;
            public byte GPWS_GearInhibitSw_NORM;
            public byte GPWS_TerrInhibitSw_NORM;


            // Control Stand
            //------------------------------------------

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)] public byte[] CDU_annunEXEC;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)] public byte[] CDU_annunCALL;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)] public byte[] CDU_annunFAIL;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)] public byte[] CDU_annunMSG;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)] public byte[] CDU_annunOFST;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)] public byte[] CDU_BrtKnob; // Position 0...127

            public byte TRIM_StabTrimMainElecSw_NORMAL;
            public byte TRIM_StabTrimAutoPilotSw_NORMAL;
            public byte PED_annunParkingBrake;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)] public byte[] FIRE_OvhtDetSw; // 0: A  1: NORMAL  2: B
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)] public byte[] FIRE_annunENG_OVERHEAT;
            public byte FIRE_DetTestSw; // 0: FAULT/INOP  1: neutral  2: OVHT/FIRE
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)] public byte[] FIRE_HandlePos; // 0: In  1: Blocked  2: Out  3: Turned Left  4: Turned right
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)] public byte[] FIRE_HandleIlluminated;
            public byte FIRE_annunWHEEL_WELL;
            public byte FIRE_annunFAULT;
            public byte FIRE_annunAPU_DET_INOP;
            public byte FIRE_annunAPU_BOTTLE_DISCHARGE;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)] public byte[] FIRE_annunBOTTLE_DISCHARGE;
            public byte FIRE_ExtinguisherTestSw; // 0: 1  1: neutral  2: 2
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)] public byte[] FIRE_annunExtinguisherTest; // Left, Right, APU

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)] public byte[] CARGO_annunExtTest; // Fwd, Aft
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)] public byte[] CARGO_DetSelect; // 0: A  1: ORM  2: B
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)] public byte[] CARGO_ArmedSw;
            public byte CARGO_annunFWD;
            public byte CARGO_annunAFT;
            public byte CARGO_annunDETECTOR_FAULT;
            public byte CARGO_annunDISCH;

            public byte HGS_annunRWY;
            public byte HGS_annunGS;
            public byte HGS_annunFAULT;
            public byte HGS_annunCLR;

            public byte XPDR_XpndrSelector_2; // false: 1  true: 2
            public byte XPDR_AltSourceSel_2; // false: 1  true: 2
            public byte XPDR_ModeSel; // 0: STBY  1: ALT RPTG OFF ... 4: TA/RA
            public byte XPDR_annunFAIL;

            public byte LTS_PedFloodKnob; // Position 0...150
            public byte LTS_PedPanelKnob; // Position 0...150

            public byte TRIM_StabTrimSw_NORMAL;
            public byte PED_annunLOCK_FAIL;
            public byte PED_annunAUTO_UNLK;
            public byte PED_FltDkDoorSel; // 0: UNLKD  1 AUTO pushed in  2: AUTO  3: DENY


            // Additional variables: used by FS2Crew
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)] public byte[] ENG_StartValve; // true: valve open
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)] public float[] AIR_DuctPress; // PSI
            public byte COMM_Attend_PressCount; // incremented with each button press
            public byte COMM_GrdCall_PressCount; // incremented with each button press
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)] public byte[] COMM_SelectedMic; // array: 0=capt, 1=F/O, 2=observer.
            // values: 0=VHF1  1=VHF2  2=VHF3  3=HF1  4=HF2  5=FLT  6=SVC  7=PA
            public float FUEL_QtyCenter; // LBS
            public float FUEL_QtyLeft; // LBS
            public float FUEL_QtyRight; // LBS
            public byte IRS_aligned; // at least one IRU is aligned
            public byte AircraftModel; // 1: -600  2: -700  3: -700WL  4: -800  5: -800WL  6: -900  7: -900ER
            public byte WeightInKg; // false: LBS  true: KG
            public byte GPWS_V1CallEnabled; // GPWS V1 callout option enabled
            public byte GroundConnAvailable; // can connect/disconnect ground air/electrics

            public byte FMC_TakeoffFlaps; // degrees, 0 if not set
            public byte FMC_V1; // knots, 0 if not set
            public byte FMC_VR; // knots, 0 if not set
            public byte FMC_V2; // knots, 0 if not set
            public byte FMC_LandingFlaps; // degrees, 0 if not set
            public byte FMC_LandingVREF; // knots, 0 if not set
            public ushort FMC_CruiseAlt; // ft, 0 if not set
            public short FMC_LandingAltitude; // ft; -32767 if not available
            public ushort FMC_TransitionAlt; // ft
            public ushort FMC_TransitionLevel; // ft
            public byte FMC_PerfInputComplete;
            public float FMC_DistanceToTOD; // nm; 0.0 if passed, negative if n/a
            public float FMC_DistanceToDest; // nm; negative if n/a
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 9)] public byte[] FMC_flightNumber;



            // The rest of the controls and indicators match their standard FSX counterparts
            // and can be accessed using the standard SimConnect means.


            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 168)] public byte[] reserved;
            // ReSharper restore FieldCanBeMadeReadOnly.Local
        }

        // NGX Control Structure
        [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
        public struct PMDG_NGX_Control
        {
            public PMDGEvents Event;
            public UInt32 Parameter;
        }

        public const UInt32 MOUSE_FLAG_RIGHTSINGLE = 0x80000000;
        public const UInt32 MOUSE_FLAG_MIDDLESINGLE = 0x40000000;
        public const UInt32 MOUSE_FLAG_LEFTSINGLE = 0x20000000;
        public const UInt32 MOUSE_FLAG_RIGHTDOUBLE = 0x10000000;
        public const UInt32 MOUSE_FLAG_MIDDLEDOUBLE = 0x08000000;
        public const UInt32 MOUSE_FLAG_LEFTDOUBLE = 0x04000000;
        public const UInt32 MOUSE_FLAG_RIGHTDRAG = 0x02000000;
        public const UInt32 MOUSE_FLAG_MIDDLEDRAG = 0x01000000;
        public const UInt32 MOUSE_FLAG_LEFTDRAG = 0x00800000;
        public const UInt32 MOUSE_FLAG_MOVE = 0x00400000;
        public const UInt32 MOUSE_FLAG_DOWN_REPEAT = 0x00200000;
        public const UInt32 MOUSE_FLAG_RIGHTRELEASE = 0x00080000;
        public const UInt32 MOUSE_FLAG_MIDDLERELEASE = 0x00040000;
        public const UInt32 MOUSE_FLAG_LEFTRELEASE = 0x00020000;
        public const UInt32 MOUSE_FLAG_WHEEL_FLIP = 0x00010000;   // invert direction of mouse wheel
        public const UInt32 UMOUSE_FLAG_WHEEL_SKIP = 0x00008000;   // look at next 2 rect for mouse wheel commands
        public const UInt32 MOUSE_FLAG_WHEEL_UP = 0x00004000;
        public const UInt32 MOUSE_FLAG_WHEEL_DOWN = 0x00002000;

        // Control Events
        public const UInt32 THIRD_PARTY_EVENT_ID_MIN = 0x00011000;		// equals to 69632

        public enum PMDGEvents : uint
        {
            // Overhead - Electric  
            EVT_OH_ELEC_BATTERY_SWITCH = (THIRD_PARTY_EVENT_ID_MIN + 1),	    // 01 - BAT Switch
            EVT_OH_ELEC_BATTERY_GUARD = (THIRD_PARTY_EVENT_ID_MIN + 2),		// 02 - BAT Switch Guard 
            EVT_OH_ELEC_DC_METER = (THIRD_PARTY_EVENT_ID_MIN + 3),		// 03 - DC SOURCE Knob					
            EVT_OH_ELEC_AC_METER = (THIRD_PARTY_EVENT_ID_MIN + 4),		// 04 - AC SOURCE Knob					
            EVT_OH_ELEC_GALLEY = (THIRD_PARTY_EVENT_ID_MIN + 974),	// 974- GALLEY Switch [-600/700 only]				
            EVT_OH_ELEC_CAB_UTIL = (THIRD_PARTY_EVENT_ID_MIN + 5),		// 05 - CAB UTIL Switch	[-800/900 only]			
            EVT_OH_ELEC_IFE = (THIRD_PARTY_EVENT_ID_MIN + 6),		// 06 - IFE/PASS Switch	[-800/900 only]
            EVT_OH_ELEC_STBY_PWR_SWITCH = (THIRD_PARTY_EVENT_ID_MIN + 10),	    // 10 - STANDBY POWER Switch 
            EVT_OH_ELEC_STBY_PWR_GUARD = (THIRD_PARTY_EVENT_ID_MIN + 11),		// 11 - STANDBY POWER Switch Guard
            EVT_OH_ELEC_DISCONNECT_1_SWITCH = (THIRD_PARTY_EVENT_ID_MIN + 12),		// 12 - GEN DRIVE DISC Left Switch		
            EVT_OH_ELEC_DISCONNECT_1_GUARD = (THIRD_PARTY_EVENT_ID_MIN + 13),		// 13 - GEN DRIVE DISC Left Guard		
            EVT_OH_ELEC_DISCONNECT_2_SWITCH = (THIRD_PARTY_EVENT_ID_MIN + 14),		// 14 - GEN DRIVE DISC Right Switch	
            EVT_OH_ELEC_DISCONNECT_2_GUARD = (THIRD_PARTY_EVENT_ID_MIN + 15),		// 15 - GEN DRIVE DISC Right Guard 	
            EVT_OH_ELEC_GRD_PWR_SWITCH = (THIRD_PARTY_EVENT_ID_MIN + 17),		// 17 - GROUND POWER Switch
            EVT_OH_ELEC_BUS_TRANSFER_SWITCH = (THIRD_PARTY_EVENT_ID_MIN + 18),		// 18 - BUS TRANSFER Switch 	
            EVT_OH_ELEC_BUS_TRANSFER_GUARD = (THIRD_PARTY_EVENT_ID_MIN + 19),		// 19 - BUS TRANSFER Guard
            EVT_OH_ELEC_GEN1_SWITCH = (THIRD_PARTY_EVENT_ID_MIN + 27),		// 27 - GENERATOR Left Switch
            EVT_OH_ELEC_APU_GEN1_SWITCH = (THIRD_PARTY_EVENT_ID_MIN + 28),		// 28 - APU GENERATOR Left Switch
            EVT_OH_ELEC_APU_GEN2_SWITCH = (THIRD_PARTY_EVENT_ID_MIN + 29),		// 29 - APU GENERATOR RIGHT Switch
            EVT_OH_ELEC_GEN2_SWITCH = (THIRD_PARTY_EVENT_ID_MIN + 30),		// 30 - GENERATOR RIGHT Switch
            EVT_OH_ELEC_MAINT_SWITCH = (THIRD_PARTY_EVENT_ID_MIN + 93),		// 93 - ELEC MAINT Switch 

            // Overhead - FUEL Panel
            EVT_OH_FUEL_PUMP_1_AFT = (THIRD_PARTY_EVENT_ID_MIN + 37),		// 37 - FUEL PUMP LEFT AFT Switch 
            EVT_OH_FUEL_PUMP_1_FORWARD = (THIRD_PARTY_EVENT_ID_MIN + 38),		// 38 - FUEL PUMP LEFT FWD Switch 
            EVT_OH_FUEL_PUMP_2_FORWARD = (THIRD_PARTY_EVENT_ID_MIN + 39),		// 39 - FUEL PUMP RIGHT FWD Switch 
            EVT_OH_FUEL_PUMP_2_AFT = (THIRD_PARTY_EVENT_ID_MIN + 40),		// 40 - FUEL PUMP RIGHT AFT Switch 
            EVT_OH_FUEL_PUMP_L_CENTER = (THIRD_PARTY_EVENT_ID_MIN + 45),		// 45 - FUEL PUMP CENTER LEFT Switch 
            EVT_OH_FUEL_PUMP_R_CENTER = (THIRD_PARTY_EVENT_ID_MIN + 46),		// 46 - FUEL PUMP CENTER LEFT Switch 
            EVT_OH_FUEL_CROSSFEED = (THIRD_PARTY_EVENT_ID_MIN + 49),		// 49 - CROSSFEED Selector 

            // Overhead - LIGHTS Panel
            EVT_OH_LAND_LIGHTS_GUARD = (THIRD_PARTY_EVENT_ID_MIN + 110),
            EVT_OH_LIGHTS_L_RETRACT = (THIRD_PARTY_EVENT_ID_MIN + 111),
            EVT_OH_LIGHTS_R_RETRACT = (THIRD_PARTY_EVENT_ID_MIN + 112),
            EVT_OH_LIGHTS_L_= (THIRD_PARTY_EVENT_ID_MIN + 113),
            EVT_OH_LIGHTS_R_= (THIRD_PARTY_EVENT_ID_MIN + 114),
            EVT_OH_LIGHTS_L_TURNOFF = (THIRD_PARTY_EVENT_ID_MIN + 115),
            EVT_OH_LIGHTS_R_TURNOFF = (THIRD_PARTY_EVENT_ID_MIN + 116),
            EVT_OH_LIGHTS_TAXI = (THIRD_PARTY_EVENT_ID_MIN + 117),
            EVT_OH_LIGHTS_APU_START = (THIRD_PARTY_EVENT_ID_MIN + 118),
            EVT_OH_LIGHTS_L_ENGINE_START = (THIRD_PARTY_EVENT_ID_MIN + 119),
            EVT_OH_LIGHTS_IGN_SEL = (THIRD_PARTY_EVENT_ID_MIN + 120),
            EVT_OH_LIGHTS_R_ENGINE_START = (THIRD_PARTY_EVENT_ID_MIN + 121),
            EVT_OH_LIGHTS_LOGO = (THIRD_PARTY_EVENT_ID_MIN + 122),
            EVT_OH_LIGHTS_POS_STROBE = (THIRD_PARTY_EVENT_ID_MIN + 123),
            EVT_OH_LIGHTS_ANT_COL = (THIRD_PARTY_EVENT_ID_MIN + 124),
            EVT_OH_LIGHTS_WING = (THIRD_PARTY_EVENT_ID_MIN + 125),
            EVT_OH_LIGHTS_WHEEL_WELL = (THIRD_PARTY_EVENT_ID_MIN + 126),
            EVT_OH_LIGHTS_COMPASS = (THIRD_PARTY_EVENT_ID_MIN + 982),

            // Overhead - Center Part
            EVT_OH_CB_LIGHT_CONTROL = (THIRD_PARTY_EVENT_ID_MIN + 94),		// CIRCUIT BREAKER Light Control
            EVT_OH_PANEL_LIGHT_CONTROL = (THIRD_PARTY_EVENT_ID_MIN + 95),		// PANEL Light Control Decrease
            EVT_OH_EC_SUPPLY_SWITCH = (THIRD_PARTY_EVENT_ID_MIN + 96),		// EQUIPMENT COOLING SUPPLY Switch
            EVT_OH_EC_EXHAUST_SWITCH = (THIRD_PARTY_EVENT_ID_MIN + 97),		// EQUIPMENT COOLING EXHAUST Switch
            EVT_OH_EMER_EXIT_LIGHT_SWITCH = (THIRD_PARTY_EVENT_ID_MIN + 100),	// EMERGENCY EXIT LIGHTS Switch 
            EVT_OH_EMER_EXIT_LIGHT_GUARD = (THIRD_PARTY_EVENT_ID_MIN + 101),	// EMERGENCY EXIT LIGHTS Guard
            EVT_OH_NO_SMOKING_LIGHT_SWITCH = (THIRD_PARTY_EVENT_ID_MIN + 103),	// NO SMOKING Switch
            EVT_OH_FASTEN_BELTS_LIGHT_SWITCH = (THIRD_PARTY_EVENT_ID_MIN + 104),	// FASTEN BELTS Switch

            // Overhead - Miscellaneous
            EVT_OH_ATTND_CALL_SWITCH = (THIRD_PARTY_EVENT_ID_MIN + 105),	// ATTENDANT CALL Switch 
            EVT_OH_GRND_CALL_SWITCH = (THIRD_PARTY_EVENT_ID_MIN + 106),	// GROUND CALL Switch 
            EVT_OH_WIPER_LEFT_CONTROL = (THIRD_PARTY_EVENT_ID_MIN + 36),		// LEFT WIPER Control 
            EVT_OH_WIPER_RIGHT_CONTROL = (THIRD_PARTY_EVENT_ID_MIN + 109),	// RIGHT WIPER Control

            EVT_OH_EFIS_HDG_REF_TOGGLE = (THIRD_PARTY_EVENT_ID_MIN + 6920),	// 692A - Heading Reference Switch Toggle - n o t e: this is only for acft. with polar nav. option, e.g. BBJ


            // Overhead - NAVDSP
            EVT_OH_NAVDSP_DISPLAYS_SOURCE_SEL = (THIRD_PARTY_EVENT_ID_MIN + 58),	// DISPLAYS SOURCE Selector 
            EVT_OH_NAVDSP_CONTROL_PANEL_SEL = (THIRD_PARTY_EVENT_ID_MIN + 59),	// CONTROL PANEL Select Switch 
            EVT_OH_NAVDSP_FMC_SEL = (THIRD_PARTY_EVENT_ID_MIN + 60),	// FMC Source Select Switch
            EVT_OH_NAVDSP_IRS_SEL = (THIRD_PARTY_EVENT_ID_MIN + 61),	// IRS Transfer Switch 
            EVT_OH_NAVDSP_VHF_NAV_SEL = (THIRD_PARTY_EVENT_ID_MIN + 62),	// VHF NAV Transfer Switch 


            // Overhead - FLTCTRL
            EVT_OH_YAW_DAMPER = (THIRD_PARTY_EVENT_ID_MIN + 63),	// YAW DAMPER Switch 
            EVT_OH_ALT_FLAPS_MASTER_SWITCH = (THIRD_PARTY_EVENT_ID_MIN + 73),	// ALTERNATE FLAPS Master Switch 
            EVT_OH_ALT_FLAPS_MASTER_GUARD = (THIRD_PARTY_EVENT_ID_MIN + 74),	// ALTERNATE FLAPS Master Guard 
            EVT_OH_SPOILER_A_SWITCH = (THIRD_PARTY_EVENT_ID_MIN + 65),	// SPOILER A Switch 		
            EVT_OH_SPOILER_A_GUARD = (THIRD_PARTY_EVENT_ID_MIN + 66),	// SPOILER A Guard 
            EVT_OH_SPOILER_B_SWITCH = (THIRD_PARTY_EVENT_ID_MIN + 67),	// SPOILER B Switch 
            EVT_OH_SPOILER_B_GUARD = (THIRD_PARTY_EVENT_ID_MIN + 68),	// SPOILER B Guard 
            EVT_OH_ALT_FLAPS_POS_SWITCH = (THIRD_PARTY_EVENT_ID_MIN + 75),	// ALTERNATE FLAPS Position Switch
            EVT_OH_FCTL_A_SWITCH = (THIRD_PARTY_EVENT_ID_MIN + 78),	// FLIGHT CONTROL A Switch Decrease	
            EVT_OH_FCTL_A_GUARD = (THIRD_PARTY_EVENT_ID_MIN + 79),	// FLIGHT CONTROL A Guard 
            EVT_OH_FCTL_B_SWITCH = (THIRD_PARTY_EVENT_ID_MIN + 80),	// FLIGHT CONTROL B Switch Decrease
            EVT_OH_FCTL_B_GUARD = (THIRD_PARTY_EVENT_ID_MIN + 81),	// FLIGHT CONTROL B Guard 


            // Overhead - CVR
            EVT_OH_CVR_TEST = (THIRD_PARTY_EVENT_ID_MIN + 178),
            EVT_OH_CVR_ERASE = (THIRD_PARTY_EVENT_ID_MIN + 180),

            // Overhead - HYD
            EVT_OH_HYD_ENG1 = (THIRD_PARTY_EVENT_ID_MIN + 165),
            EVT_OH_HYD_ELEC2 = (THIRD_PARTY_EVENT_ID_MIN + 167),
            EVT_OH_HYD_ELEC1 = (THIRD_PARTY_EVENT_ID_MIN + 168),
            EVT_OH_HYD_ENG2 = (THIRD_PARTY_EVENT_ID_MIN + 166),

            // Overhead - ICE
            EVT_OH_ICE_WINDOW_HEAT_1 = (THIRD_PARTY_EVENT_ID_MIN + 135),
            EVT_OH_ICE_WINDOW_HEAT_2 = (THIRD_PARTY_EVENT_ID_MIN + 136),
            EVT_OH_ICE_WINDOW_HEAT_3 = (THIRD_PARTY_EVENT_ID_MIN + 138),
            EVT_OH_ICE_WINDOW_HEAT_4 = (THIRD_PARTY_EVENT_ID_MIN + 139),
            EVT_OH_ICE_WINDOW_HEAT_TEST = (THIRD_PARTY_EVENT_ID_MIN + 137),
            EVT_OH_ICE_PROBE_HEAT_1 = (THIRD_PARTY_EVENT_ID_MIN + 140),
            EVT_OH_ICE_PROBE_HEAT_2 = (THIRD_PARTY_EVENT_ID_MIN + 141),
            EVT_OH_ICE_TAT_TEST = (THIRD_PARTY_EVENT_ID_MIN + 142), // was used for "CAPT PITOT" annunciator light
            EVT_OH_ICE_WING_ANTIICE = (THIRD_PARTY_EVENT_ID_MIN + 156),
            EVT_OH_ICE_ENGINE_ANTIICE_1 = (THIRD_PARTY_EVENT_ID_MIN + 157),
            EVT_OH_ICE_ENGINE_ANTIICE_2 = (THIRD_PARTY_EVENT_ID_MIN + 158),

            // Overhead - PNEU

            // -600/700 panel only
            EVT_OH_AIRCOND_TEMP_SOURCE_SELECTOR = (THIRD_PARTY_EVENT_ID_MIN + 187),
            EVT_OH_AIRCOND_TEMP_SELECTOR_CONT = (THIRD_PARTY_EVENT_ID_MIN + 191),
            EVT_OH_AIRCOND_TEMP_SELECTOR_CABIN = (THIRD_PARTY_EVENT_ID_MIN + 192),
            EVT_OH_AIRCOND_TYPE_600_LAST = EVT_OH_AIRCOND_TEMP_SELECTOR_CABIN,

            // -800/900 panel only
            EVT_OH_AIRCOND_TEMP_SOURCE_SELECTOR_800 = (THIRD_PARTY_EVENT_ID_MIN + 313),
            EVT_OH_AIRCOND_TEMP_SELECTOR_CONT_800 = (THIRD_PARTY_EVENT_ID_MIN + 305),
            EVT_OH_AIRCOND_TEMP_SELECTOR_FWD_800 = (THIRD_PARTY_EVENT_ID_MIN + 306),
            EVT_OH_AIRCOND_TEMP_SELECTOR_AFT_800 = (THIRD_PARTY_EVENT_ID_MIN + 307),
            EVT_OH_AIRCOND_TRIM_AIR_SWITCH_800 = (THIRD_PARTY_EVENT_ID_MIN + 311),

            EVT_OH_BLEED_RECIRC_FAN_L_SWITCH = (THIRD_PARTY_EVENT_ID_MIN + 872),
            EVT_OH_BLEED_RECIRC_FAN_R_SWITCH = (THIRD_PARTY_EVENT_ID_MIN + 196),
            EVT_OH_BLEED_OVHT_TEST_BUTTON = (THIRD_PARTY_EVENT_ID_MIN + 199),
            EVT_OH_BLEED_PACK_L_SWITCH = (THIRD_PARTY_EVENT_ID_MIN + 200),
            EVT_OH_BLEED_PACK_R_SWITCH = (THIRD_PARTY_EVENT_ID_MIN + 201),
            EVT_OH_BLEED_ISOLATION_VALVE_SWITCH = (THIRD_PARTY_EVENT_ID_MIN + 202),
            EVT_OH_BLEED_TRIP_RESET_BUTTON = (THIRD_PARTY_EVENT_ID_MIN + 209),
            EVT_OH_BLEED_ENG_1_SWITCH = (THIRD_PARTY_EVENT_ID_MIN + 210),
            EVT_OH_BLEED_APU_SWITCH = (THIRD_PARTY_EVENT_ID_MIN + 211),
            EVT_OH_BLEED_ENG_2_SWITCH = (THIRD_PARTY_EVENT_ID_MIN + 212),

            // Overhead - Cabin Press
            EVT_OH_PRESS_FLT_ALT_KNOB = (THIRD_PARTY_EVENT_ID_MIN + 218),
            EVT_OH_PRESS_LAND_ALT_KNOB = (THIRD_PARTY_EVENT_ID_MIN + 220),
            EVT_OH_PRESS_VALVE_SWITCH = (THIRD_PARTY_EVENT_ID_MIN + 222),
            EVT_OH_PRESS_SELECTOR = (THIRD_PARTY_EVENT_ID_MIN + 223),

            // Overhead - Cabin Alt
            EVT_OH_CAB_ALT_HORN_CUTOUT_BUTTON = (THIRD_PARTY_EVENT_ID_MIN + 183),

            // Aft Overhead - LE Devices
            EVT_OH_LE_DEVICES_TEST_SWITCH = (THIRD_PARTY_EVENT_ID_MIN + 224),

            // Aft Overhead - Service Interphone Switch
            EVT_OH_SERVICE_INTERPHONE_SWITCH = (THIRD_PARTY_EVENT_ID_MIN + 257),

            // Aft Overhead - Dome Switch
            EVT_OH_DOME_SWITCH = (THIRD_PARTY_EVENT_ID_MIN + 258),

            // Aft Overhead - ISDU panel
            EVT_ISDU_DSPL_SEL = (THIRD_PARTY_EVENT_ID_MIN + 229),	// ISDU DiSPLay SELector
            EVT_ISDU_FIRST = EVT_ISDU_DSPL_SEL,
            EVT_ISDU_DSPL_SEL_BRT = (THIRD_PARTY_EVENT_ID_MIN + 230),	// ISDU DiSPLay SELector BRT =(Brightness),
            EVT_ISDU_SYS_DSPL = (THIRD_PARTY_EVENT_ID_MIN + 231),	// ISDU SYS DSPL  
            EVT_ISDU_KBD_1 = (THIRD_PARTY_EVENT_ID_MIN + 232),	// ISDU KEYBOARD 1
            EVT_ISDU_KBD_2 = (THIRD_PARTY_EVENT_ID_MIN + 233),	// ISDU KEYBOARD 2 or N
            EVT_ISDU_KBD_3 = (THIRD_PARTY_EVENT_ID_MIN + 234),	// ISDU KEYBOARD 3
            EVT_ISDU_KBD_4 = (THIRD_PARTY_EVENT_ID_MIN + 235),	// ISDU KEYBOARD 4 or W
            EVT_ISDU_KBD_5 = (THIRD_PARTY_EVENT_ID_MIN + 236),	// ISDU KEYBOARD 5 or H
            EVT_ISDU_KBD_6 = (THIRD_PARTY_EVENT_ID_MIN + 237),	// ISDU KEYBOARD 6 or E
            EVT_ISDU_KBD_7 = (THIRD_PARTY_EVENT_ID_MIN + 238),	// ISDU KEYBOARD 7
            EVT_ISDU_KBD_8 = (THIRD_PARTY_EVENT_ID_MIN + 239),	// ISDU KEYBOARD 8 or S
            EVT_ISDU_KBD_9 = (THIRD_PARTY_EVENT_ID_MIN + 240),	// ISDU KEYBOARD 9
            EVT_ISDU_KBD_ENT = (THIRD_PARTY_EVENT_ID_MIN + 241),	// ISDU KEYBOARD ENTer
            EVT_ISDU_KBD_0 = (THIRD_PARTY_EVENT_ID_MIN + 243),	// ISDU KEYBOARD 0
            EVT_ISDU_KBD_CLR = (THIRD_PARTY_EVENT_ID_MIN + 244),	// ISDU KEYBOARD CLR
            EVT_IRU_MSU_LEFT = (THIRD_PARTY_EVENT_ID_MIN + 255),	// LEFT IRS Mode Selector Unit 
            EVT_IRU_MSU_RIGHT = (THIRD_PARTY_EVENT_ID_MIN + 256),	// RIGHT IRS Mode Selector Unit
            EVT_ISDU_LAST = EVT_IRU_MSU_RIGHT,

            EVT_WLAN_SWITCH = (THIRD_PARTY_EVENT_ID_MIN + 888),
            EVT_WLAN_GUARD = (THIRD_PARTY_EVENT_ID_MIN + 889),

            // Aft Overhead - Engine control
            EVT_OH_EEC_L_GUARD = (THIRD_PARTY_EVENT_ID_MIN + 267),
            EVT_OH_EEC_L_SWITCH = (THIRD_PARTY_EVENT_ID_MIN + 268),
            EVT_OH_EEC_R_GUARD = (THIRD_PARTY_EVENT_ID_MIN + 270),
            EVT_OH_EEC_R_SWITCH = (THIRD_PARTY_EVENT_ID_MIN + 271),

            // Aft Overhead - Oxygen
            EVT_OH_OXY_PASS_SWITCH = (THIRD_PARTY_EVENT_ID_MIN + 264),
            EVT_OH_OXY_PASS_GUARD = (THIRD_PARTY_EVENT_ID_MIN + 265),
            EVT_OH_OXY_TEST_RESET_SWITCH_L = (THIRD_PARTY_EVENT_ID_MIN + 983),
            EVT_OH_OXY_TEST_RESET_SWITCH_R = (THIRD_PARTY_EVENT_ID_MIN + 9832),
            EVT_OH_OXY_RED_BUTTON_L = (THIRD_PARTY_EVENT_ID_MIN + 9831),
            EVT_OH_OXY_RED_BUTTON_R = (THIRD_PARTY_EVENT_ID_MIN + 9833),

            // Aft Overhead - Flt Rec & Warning
            EVT_OH_FLTREC_SWITCH = (THIRD_PARTY_EVENT_ID_MIN + 298),
            EVT_OH_FLTREC_GUARD = (THIRD_PARTY_EVENT_ID_MIN + 299),
            EVT_OH_WARNING_TEST_MACH_IAS_1_PUSH = (THIRD_PARTY_EVENT_ID_MIN + 301),
            EVT_OH_WARNING_TEST_MACH_IAS_2_PUSH = (THIRD_PARTY_EVENT_ID_MIN + 302),
            EVT_OH_WARNING_TEST_STALL_1_PUSH = (THIRD_PARTY_EVENT_ID_MIN + 303),
            EVT_OH_WARNING_TEST_STALL_2_PUSH = (THIRD_PARTY_EVENT_ID_MIN + 304),

            // Overhead - test gauge
            EVT_OH_TRIM_AIR_SWITCH_TOGGLE = (THIRD_PARTY_EVENT_ID_MIN + 15200),	// user clicks a switch
            EVT_OH_WING_BODY_OVERHEAT_TEST_PUSH = (THIRD_PARTY_EVENT_ID_MIN + 15201),	// user pushes a pushbutton 


            // Integrated Standby Flight Display - ISFD
            EVT_ISFD_APP = (THIRD_PARTY_EVENT_ID_MIN + 987),	// 	
            EVT_ISFD_HP_IN = (THIRD_PARTY_EVENT_ID_MIN + 986),	//	
            EVT_ISFD_PLUS = (THIRD_PARTY_EVENT_ID_MIN + 988),	//	
            EVT_ISFD_MINUS = (THIRD_PARTY_EVENT_ID_MIN + 989),	//	
            EVT_ISFD_ATT_RST = (THIRD_PARTY_EVENT_ID_MIN + 990),	//	
            EVT_ISFD_BARO = (THIRD_PARTY_EVENT_ID_MIN + 991),	//	
            EVT_ISFD_BARO_PUSH = (THIRD_PARTY_EVENT_ID_MIN + 993),	//	

            // Analog standby instruments
            EVT_STANDBY_ADI_APPR_MODE = (THIRD_PARTY_EVENT_ID_MIN + 474),	// 	
            EVT_STANDBY_ADI_CAGE_KNOB = (THIRD_PARTY_EVENT_ID_MIN + 476),	// 	
            EVT_STANDBY_ALT_BARO_KNOB = (THIRD_PARTY_EVENT_ID_MIN + 492),	// 	
            EVT_RMI_LEFT_SELECTOR = (THIRD_PARTY_EVENT_ID_MIN + 497),	// 	
            EVT_RMI_RIGHT_SELECTOR = (THIRD_PARTY_EVENT_ID_MIN + 498),	// 	


            // MCP
            //
            EVT_MCP_COURSE_SELECTOR_L = (THIRD_PARTY_EVENT_ID_MIN + 376),
            EVT_MCP_FD_SWITCH_L = (THIRD_PARTY_EVENT_ID_MIN + 378),
            EVT_MCP_AT_ARM_SWITCH = (THIRD_PARTY_EVENT_ID_MIN + 380),
            EVT_MCP_N1_SWITCH = (THIRD_PARTY_EVENT_ID_MIN + 381),
            EVT_MCP_SPEED_SWITCH = (THIRD_PARTY_EVENT_ID_MIN + 382),
            EVT_MCP_CO_SWITCH = (THIRD_PARTY_EVENT_ID_MIN + 383),
            EVT_MCP_SPEED_SELECTOR = (THIRD_PARTY_EVENT_ID_MIN + 384),
            EVT_MCP_VNAV_SWITCH = (THIRD_PARTY_EVENT_ID_MIN + 386),
            EVT_MCP_SPD_INTV_SWITCH = (THIRD_PARTY_EVENT_ID_MIN + 387),
            EVT_MCP_BANK_ANGLE_SELECTOR = (THIRD_PARTY_EVENT_ID_MIN + 389),
            EVT_MCP_HEADING_SELECTOR = (THIRD_PARTY_EVENT_ID_MIN + 390),
            EVT_MCP_LVL_CHG_SWITCH = (THIRD_PARTY_EVENT_ID_MIN + 391),
            EVT_MCP_HDG_SEL_SWITCH = (THIRD_PARTY_EVENT_ID_MIN + 392),
            EVT_MCP_APP_SWITCH = (THIRD_PARTY_EVENT_ID_MIN + 393),
            EVT_MCP_ALT_HOLD_SWITCH = (THIRD_PARTY_EVENT_ID_MIN + 394),
            EVT_MCP_VS_SWITCH = (THIRD_PARTY_EVENT_ID_MIN + 395),
            EVT_MCP_VOR_LOC_SWITCH = (THIRD_PARTY_EVENT_ID_MIN + 396),
            EVT_MCP_LNAV_SWITCH = (THIRD_PARTY_EVENT_ID_MIN + 397),
            EVT_MCP_ALTITUDE_SELECTOR = (THIRD_PARTY_EVENT_ID_MIN + 400),
            EVT_MCP_VS_SELECTOR = (THIRD_PARTY_EVENT_ID_MIN + 401),
            EVT_MCP_CMD_A_SWITCH = (THIRD_PARTY_EVENT_ID_MIN + 402),
            EVT_MCP_CMD_B_SWITCH = (THIRD_PARTY_EVENT_ID_MIN + 403),
            EVT_MCP_CWS_A_SWITCH = (THIRD_PARTY_EVENT_ID_MIN + 404),
            EVT_MCP_CWS_B_SWITCH = (THIRD_PARTY_EVENT_ID_MIN + 405),
            EVT_MCP_DISENGAGE_BAR = (THIRD_PARTY_EVENT_ID_MIN + 406),
            EVT_MCP_FD_SWITCH_R = (THIRD_PARTY_EVENT_ID_MIN + 407),
            EVT_MCP_COURSE_SELECTOR_R = (THIRD_PARTY_EVENT_ID_MIN + 409),
            EVT_MCP_ALT_INTV_SWITCH = (THIRD_PARTY_EVENT_ID_MIN + 885),

            // EFIS Captain control panel
            //
            // N O T E: Order in captain and F/O sides must be same, and events in both sides must increase by 1
            //
            EVT_EFIS_CPT_MINIMUMS = (THIRD_PARTY_EVENT_ID_MIN + 355),
            EVT_EFIS_CPT_FIRST = EVT_EFIS_CPT_MINIMUMS,
            EVT_EFIS_CPT_MINIMUMS_RADIO_BARO = (THIRD_PARTY_EVENT_ID_MIN + 356),
            EVT_EFIS_CPT_MINIMUMS_RST = (THIRD_PARTY_EVENT_ID_MIN + 357),
            EVT_EFIS_CPT_VOR_ADF_SELECTOR_L = (THIRD_PARTY_EVENT_ID_MIN + 358),
            EVT_EFIS_CPT_MODE = (THIRD_PARTY_EVENT_ID_MIN + 359),
            EVT_EFIS_CPT_MODE_CTR = (THIRD_PARTY_EVENT_ID_MIN + 360),
            EVT_EFIS_CPT_RANGE = (THIRD_PARTY_EVENT_ID_MIN + 361),
            EVT_EFIS_CPT_RANGE_TFC = (THIRD_PARTY_EVENT_ID_MIN + 362),
            EVT_EFIS_CPT_FPV = (THIRD_PARTY_EVENT_ID_MIN + 363),
            EVT_EFIS_CPT_MTRS = (THIRD_PARTY_EVENT_ID_MIN + 364),
            EVT_EFIS_CPT_BARO = (THIRD_PARTY_EVENT_ID_MIN + 365),
            EVT_EFIS_CPT_BARO_IN_HPA = (THIRD_PARTY_EVENT_ID_MIN + 366),
            EVT_EFIS_CPT_BARO_STD = (THIRD_PARTY_EVENT_ID_MIN + 367),
            EVT_EFIS_CPT_VOR_ADF_SELECTOR_R = (THIRD_PARTY_EVENT_ID_MIN + 368),
            EVT_EFIS_CPT_WXR = (THIRD_PARTY_EVENT_ID_MIN + 369),
            EVT_EFIS_CPT_STA = (THIRD_PARTY_EVENT_ID_MIN + 370),
            EVT_EFIS_CPT_WPT = (THIRD_PARTY_EVENT_ID_MIN + 371),
            EVT_EFIS_CPT_ARPT = (THIRD_PARTY_EVENT_ID_MIN + 372),
            EVT_EFIS_CPT_DATA = (THIRD_PARTY_EVENT_ID_MIN + 373),
            EVT_EFIS_CPT_POS = (THIRD_PARTY_EVENT_ID_MIN + 374),
            EVT_EFIS_CPT_TERR = (THIRD_PARTY_EVENT_ID_MIN + 375),
            EVT_EFIS_CPT_LAST = EVT_EFIS_CPT_TERR,

            // EFIS F/O control panels
            //
            EVT_EFIS_FO_MINIMUMS = (THIRD_PARTY_EVENT_ID_MIN + 411),
            EVT_EFIS_FO_FIRST = EVT_EFIS_FO_MINIMUMS,
            EVT_EFIS_FO_MINIMUMS_RADIO_BARO = (THIRD_PARTY_EVENT_ID_MIN + 412),
            EVT_EFIS_FO_MINIMUMS_RST = (THIRD_PARTY_EVENT_ID_MIN + 413),
            EVT_EFIS_FO_VOR_ADF_SELECTOR_L = (THIRD_PARTY_EVENT_ID_MIN + 414),
            EVT_EFIS_FO_MODE = (THIRD_PARTY_EVENT_ID_MIN + 415),
            EVT_EFIS_FO_MODE_CTR = (THIRD_PARTY_EVENT_ID_MIN + 416),
            EVT_EFIS_FO_RANGE = (THIRD_PARTY_EVENT_ID_MIN + 417),
            EVT_EFIS_FO_RANGE_TFC = (THIRD_PARTY_EVENT_ID_MIN + 418),
            EVT_EFIS_FO_FPV = (THIRD_PARTY_EVENT_ID_MIN + 419),
            EVT_EFIS_FO_MTRS = (THIRD_PARTY_EVENT_ID_MIN + 420),
            EVT_EFIS_FO_BARO = (THIRD_PARTY_EVENT_ID_MIN + 421),
            EVT_EFIS_FO_BARO_IN_HPA = (THIRD_PARTY_EVENT_ID_MIN + 422),
            EVT_EFIS_FO_BARO_STD = (THIRD_PARTY_EVENT_ID_MIN + 423),
            EVT_EFIS_FO_VOR_ADF_SELECTOR_R = (THIRD_PARTY_EVENT_ID_MIN + 424),
            EVT_EFIS_FO_WXR = (THIRD_PARTY_EVENT_ID_MIN + 425),
            EVT_EFIS_FO_STA = (THIRD_PARTY_EVENT_ID_MIN + 426),
            EVT_EFIS_FO_WPT = (THIRD_PARTY_EVENT_ID_MIN + 427),
            EVT_EFIS_FO_ARPT = (THIRD_PARTY_EVENT_ID_MIN + 428),
            EVT_EFIS_FO_DATA = (THIRD_PARTY_EVENT_ID_MIN + 429),
            EVT_EFIS_FO_POS = (THIRD_PARTY_EVENT_ID_MIN + 430),
            EVT_EFIS_FO_TERR = (THIRD_PARTY_EVENT_ID_MIN + 431),
            EVT_EFIS_FO_LAST = EVT_EFIS_FO_TERR,


            // Display select panels
            // 
            EVT_DSP_CPT_BELOW_GS_INHIBIT_SWITCH = (THIRD_PARTY_EVENT_ID_MIN + 327),	// CAPT Side BELOW GS INHIBIT Pushbutton
            EVT_DSP_CPT_MAIN_DU_SELECTOR = (THIRD_PARTY_EVENT_ID_MIN + 335),	// CAPT side MAIN PANEL DISPLAY UNITS =(MAIN PANEL DUs), Selector 
            EVT_DSP_CPT_LOWER_DU_SELECTOR = (THIRD_PARTY_EVENT_ID_MIN + 336),	// CAPT side LOWER DISPLAY UNIT =(LOWER DU), Selector 
            EVT_DSP_CPT_DISENGAGE_TEST_SWITCH = (THIRD_PARTY_EVENT_ID_MIN + 342),	// CAPT side DISENGAGE LIGHTS TEST switch
            EVT_DSP_CPT_AP_RESET_SWITCH = (THIRD_PARTY_EVENT_ID_MIN + 339),	// CAPT Side AP RESET Pushbutton
            EVT_DSP_CPT_AT_RESET_SWITCH = (THIRD_PARTY_EVENT_ID_MIN + 340),	// CAPT Side AT RESET Pushbutton
            EVT_DSP_CPT_FMC_RESET_SWITCH = (THIRD_PARTY_EVENT_ID_MIN + 341),	// CAPT Side FMC RESET Pushbutton
            EVT_DSP_CPT_MASTER_LIGHTS_SWITCH = (THIRD_PARTY_EVENT_ID_MIN + 346),	// MASTER LIGHTS & TEST switch
            EVT_DSP_CPT_LAST = EVT_DSP_CPT_MASTER_LIGHTS_SWITCH,	// Keep this the last of CAPT side DSP panel items and before the F/O DSP panel items start

            EVT_DSP_FO_MAIN_DU_SELECTOR = (THIRD_PARTY_EVENT_ID_MIN + 440),	// FO side MAIN PANEL DISPLAY UNITS =(MAIN PANEL DUs), Selector 
            EVT_DSP_FO_LOWER_DU_SELECTOR = (THIRD_PARTY_EVENT_ID_MIN + 441),	// FO side LOWER DISPLAY UNIT =(LOWER DU), Selector 
            EVT_DSP_FO_DISENGAGE_TEST_SWITCH = (THIRD_PARTY_EVENT_ID_MIN + 442),	// FO side DISENGAGE LIGHTS TEST switch
            EVT_DSP_FO_FMC_RESET_SWITCH = (THIRD_PARTY_EVENT_ID_MIN + 443),	// FO Side FMC RESET Pushbutton
            EVT_DSP_FO_AT_RESET_SWITCH = (THIRD_PARTY_EVENT_ID_MIN + 444),	// FO Side AT RESET Pushbutton
            EVT_DSP_FO_AP_RESET_SWITCH = (THIRD_PARTY_EVENT_ID_MIN + 445),	// FO Side AP RESET Pushbutton
            EVT_DSP_FO_BELOW_GS_INHIBIT_SWITCH = (THIRD_PARTY_EVENT_ID_MIN + 446),	// FO Side BELOW GS INHIBIT Pushbutton


            // Main panel misc
            EVT_MPM_AUTOBRAKE_SELECTOR = (THIRD_PARTY_EVENT_ID_MIN + 460),
            EVT_MPM_MFD_SYS_BUTTON = (THIRD_PARTY_EVENT_ID_MIN + 462),
            EVT_MPM_MFD_ENG_BUTTON = (THIRD_PARTY_EVENT_ID_MIN + 463),
            EVT_MPM_MFD_C_R_BUTTON = (THIRD_PARTY_EVENT_ID_MIN + 4621),
            EVT_MPM_SPEED_REFERENCE_SELECTOR = (THIRD_PARTY_EVENT_ID_MIN + 464),
            EVT_MPM_SPEED_REFERENCE_CONTROL = (THIRD_PARTY_EVENT_ID_MIN + 465),
            EVT_MPM_N1SET_SELECTOR = (THIRD_PARTY_EVENT_ID_MIN + 466),
            EVT_MPM_N1SET_CONTROL = (THIRD_PARTY_EVENT_ID_MIN + 467),
            EVT_MPM_FUEL_FLOW_SWITCH = (THIRD_PARTY_EVENT_ID_MIN + 468),

            // Gear panel
            EVT_GEAR_LEVER = (THIRD_PARTY_EVENT_ID_MIN + 455),
            EVT_GEAR_LEVER_OFF = (THIRD_PARTY_EVENT_ID_MIN + 4551),
            EVT_GEAR_LEVER_UNLOCK = (THIRD_PARTY_EVENT_ID_MIN + 4552),

            // Nose Wheel Steering
            EVT_NOSE_WHEEL_STEERING_SWITCH = (THIRD_PARTY_EVENT_ID_MIN + 325),
            EVT_NOSE_WHEEL_STEERING_SWITCH_GUARD = (THIRD_PARTY_EVENT_ID_MIN + 326),
            EVT_TILLER = (THIRD_PARTY_EVENT_ID_MIN + 975),

            // Warning/caution
            EVT_FIRE_WARN_LIGHT_LEFT = (THIRD_PARTY_EVENT_ID_MIN + 347),	// 347 - Master Fire Warning =(FIRE WARN), Light Left Switch Toggle
            EVT_MASTER_CAUTION_LIGHT_LEFT = (THIRD_PARTY_EVENT_ID_MIN + 348),	// 348 - MASTER CAUTION Light Left Switch Toggle

            EVT_FIRE_WARN_LIGHT_RIGHT = (THIRD_PARTY_EVENT_ID_MIN + 439),	// 
            EVT_MASTER_CAUTION_LIGHT_RIGHT = (THIRD_PARTY_EVENT_ID_MIN + 438),	// 

            EVT_SYSTEM_ANNUNCIATOR_PANEL_LEFT = (THIRD_PARTY_EVENT_ID_MIN + 349),	// 
            EVT_SYSTEM_ANNUNCIATOR_PANEL_RIGHT = (THIRD_PARTY_EVENT_ID_MIN + 437),	// 

            // Lower Main
            EVT_LWRMAIN_CAPT_MAIN_PANEL_BRT = (THIRD_PARTY_EVENT_ID_MIN + 328),
            EVT_LWRMAIN_CAPT_OUTBD_DU_BRT = (THIRD_PARTY_EVENT_ID_MIN + 329),
            EVT_LWRMAIN_CAPT_INBD_DU_BRT = (THIRD_PARTY_EVENT_ID_MIN + 330),
            EVT_LWRMAIN_CAPT_INBD_DU_INNER_BRT = (THIRD_PARTY_EVENT_ID_MIN + 331),
            EVT_LWRMAIN_CAPT_LOWER_DU_BRT = (THIRD_PARTY_EVENT_ID_MIN + 332),
            EVT_LWRMAIN_CAPT_LOWER_DU_INNER_BRT = (THIRD_PARTY_EVENT_ID_MIN + 333),
            EVT_LWRMAIN_CAPT_UPPER_DU_BRT = (THIRD_PARTY_EVENT_ID_MIN + 334),
            EVT_LWRMAIN_CAPT_BACKGROUND_BRT = (THIRD_PARTY_EVENT_ID_MIN + 337),
            EVT_LWRMAIN_CAPT_AFDS_BRT = (THIRD_PARTY_EVENT_ID_MIN + 338),

            EVT_LWRMAIN_FO_INBD_DU_BRT = (THIRD_PARTY_EVENT_ID_MIN + 507),
            EVT_LWRMAIN_FO_INBD_DU_INNER_BRT = (THIRD_PARTY_EVENT_ID_MIN + 508),
            EVT_LWRMAIN_FO_MAIN_PANEL_BRT = (THIRD_PARTY_EVENT_ID_MIN + 510),
            EVT_LWRMAIN_FO_OUTBD_DU_BRT = (THIRD_PARTY_EVENT_ID_MIN + 509),


            // GPWS
            EVT_GPWS_SYS_TEST_BTN = (THIRD_PARTY_EVENT_ID_MIN + 500),
            EVT_GPWS_FLAP_INHIBIT_SWITCH = (THIRD_PARTY_EVENT_ID_MIN + 501),
            EVT_GPWS_FLAP_INHIBIT_GUARD = (THIRD_PARTY_EVENT_ID_MIN + 502),
            EVT_GPWS_GEAR_INHIBIT_SWITCH = (THIRD_PARTY_EVENT_ID_MIN + 503),
            EVT_GPWS_GEAR_INHIBIT_GUARD = (THIRD_PARTY_EVENT_ID_MIN + 504),
            EVT_GPWS_TERR_INHIBIT_SWITCH = (THIRD_PARTY_EVENT_ID_MIN + 505),
            EVT_GPWS_TERR_INHIBIT_GUARD = (THIRD_PARTY_EVENT_ID_MIN + 506),

            // Chronometers
            EVT_CHRONO_L_CHR = (THIRD_PARTY_EVENT_ID_MIN + 314),
            EVT_CHRONO_L_TIME_DATE = (THIRD_PARTY_EVENT_ID_MIN + 315),
            EVT_CHRONO_L_SET = (THIRD_PARTY_EVENT_ID_MIN + 316),
            EVT_CHRONO_L_PLUS = (THIRD_PARTY_EVENT_ID_MIN + 317),
            EVT_CHRONO_L_MINUS = (THIRD_PARTY_EVENT_ID_MIN + 318),
            EVT_CHRONO_L_RESET = (THIRD_PARTY_EVENT_ID_MIN + 320),
            EVT_CHRONO_L_ET = (THIRD_PARTY_EVENT_ID_MIN + 321),
            EVT_CHRONO_R_CHR = (THIRD_PARTY_EVENT_ID_MIN + 523),
            EVT_CHRONO_R_TIME_DATE = (THIRD_PARTY_EVENT_ID_MIN + 524),
            EVT_CHRONO_R_SET = (THIRD_PARTY_EVENT_ID_MIN + 525),
            EVT_CHRONO_R_PLUS = (THIRD_PARTY_EVENT_ID_MIN + 526),
            EVT_CHRONO_R_MINUS = (THIRD_PARTY_EVENT_ID_MIN + 527),
            EVT_CHRONO_R_RESET = (THIRD_PARTY_EVENT_ID_MIN + 529),
            EVT_CHRONO_R_ET = (THIRD_PARTY_EVENT_ID_MIN + 530),
            EVT_CLOCK_L = (THIRD_PARTY_EVENT_ID_MIN + 890),
            EVT_CLOCK_R = (THIRD_PARTY_EVENT_ID_MIN + 893),

            // Control Stand
            //
            EVT_CONTROL_STAND_TRIM_WHEEL = (THIRD_PARTY_EVENT_ID_MIN + 678),
            EVT_CONTROL_STAND_SPEED_BRAKE_LEVER = (THIRD_PARTY_EVENT_ID_MIN + 679),
            EVT_CONTROL_STAND_SPEED_BRAKE_LEVER_DOWN = (THIRD_PARTY_EVENT_ID_MIN + 6791),
            EVT_CONTROL_STAND_SPEED_BRAKE_LEVER_ARM = (THIRD_PARTY_EVENT_ID_MIN + 6792),
            EVT_CONTROL_STAND_SPEED_BRAKE_LEVER_50PCT = (THIRD_PARTY_EVENT_ID_MIN + 6793),
            EVT_CONTROL_STAND_SPEED_BRAKE_LEVER_FLT_DET = (THIRD_PARTY_EVENT_ID_MIN + 6794),
            EVT_CONTROL_STAND_SPEED_BRAKE_LEVER_UP = (THIRD_PARTY_EVENT_ID_MIN + 6795),
            EVT_CONTROL_STAND_REV_THRUST1_LEVER = (THIRD_PARTY_EVENT_ID_MIN + 680),
            EVT_CONTROL_STAND_REV_THRUST2_LEVER = (THIRD_PARTY_EVENT_ID_MIN + 681),
            EVT_CONTROL_STAND_FWD_THRUST1_LEVER = (THIRD_PARTY_EVENT_ID_MIN + 683),
            EVT_CONTROL_STAND_FWD_THRUST2_LEVER = (THIRD_PARTY_EVENT_ID_MIN + 686),
            EVT_CONTROL_STAND_TOGA1_SWITCH = (THIRD_PARTY_EVENT_ID_MIN + 684),
            EVT_CONTROL_STAND_TOGA2_SWITCH = (THIRD_PARTY_EVENT_ID_MIN + 687),
            EVT_CONTROL_STAND_AT1_DISENGAGE_SWITCH = (THIRD_PARTY_EVENT_ID_MIN + 682),
            EVT_CONTROL_STAND_AT2_DISENGAGE_SWITCH = (THIRD_PARTY_EVENT_ID_MIN + 685),
            EVT_CONTROL_STAND_ENG1_START_LEVER = (THIRD_PARTY_EVENT_ID_MIN + 688),
            EVT_CONTROL_STAND_ENG2_START_LEVER = (THIRD_PARTY_EVENT_ID_MIN + 689),
            EVT_CONTROL_STAND_PARK_BRAKE_LEVER = (THIRD_PARTY_EVENT_ID_MIN + 693),
            EVT_CONTROL_STAND_STABTRIM_ELEC_SWITCH = (THIRD_PARTY_EVENT_ID_MIN + 709),
            EVT_CONTROL_STAND_STABTRIM_ELEC_SWITCH_GUARD = (THIRD_PARTY_EVENT_ID_MIN + 710),
            EVT_CONTROL_STAND_STABTRIM_AP_SWITCH = (THIRD_PARTY_EVENT_ID_MIN + 711),
            EVT_CONTROL_STAND_STABTRIM_AP_SWITCH_GUARD = (THIRD_PARTY_EVENT_ID_MIN + 712),
            EVT_CONTROL_STAND_HORN_CUTOUT_SWITCH = (THIRD_PARTY_EVENT_ID_MIN + 713),
            EVT_CONTROL_STAND_FLAPS_LEVER = (THIRD_PARTY_EVENT_ID_MIN + 714),
            EVT_CONTROL_STAND_FLAPS_LEVER_0 = (THIRD_PARTY_EVENT_ID_MIN + 7141),
            EVT_CONTROL_STAND_FLAPS_LEVER_1 = (THIRD_PARTY_EVENT_ID_MIN + 7142),
            EVT_CONTROL_STAND_FLAPS_LEVER_2 = (THIRD_PARTY_EVENT_ID_MIN + 7143),
            EVT_CONTROL_STAND_FLAPS_LEVER_5 = (THIRD_PARTY_EVENT_ID_MIN + 7144),
            EVT_CONTROL_STAND_FLAPS_LEVER_10 = (THIRD_PARTY_EVENT_ID_MIN + 7145),
            EVT_CONTROL_STAND_FLAPS_LEVER_15 = (THIRD_PARTY_EVENT_ID_MIN + 7146),
            EVT_CONTROL_STAND_FLAPS_LEVER_25 = (THIRD_PARTY_EVENT_ID_MIN + 7147),
            EVT_CONTROL_STAND_FLAPS_LEVER_30 = (THIRD_PARTY_EVENT_ID_MIN + 7148),
            EVT_CONTROL_STAND_FLAPS_LEVER_40 = (THIRD_PARTY_EVENT_ID_MIN + 7149),

            // FLT  DK DOOR Panel
            EVT_FLT_DK_DOOR_KNOB = (THIRD_PARTY_EVENT_ID_MIN + 834),
            EVT_STAB_TRIM_OVRD_SWITCH_GUARD = (THIRD_PARTY_EVENT_ID_MIN + 830),
            EVT_STAB_TRIM_OVRD_SWITCH = (THIRD_PARTY_EVENT_ID_MIN + 831),


            // VHF Panels
            EVT_NAV1_TRANSFER_SWITCH = (THIRD_PARTY_EVENT_ID_MIN + 729),
            EVT_NAV1_FIRST = EVT_NAV1_TRANSFER_SWITCH,
            EVT_NAV1_TEST_SWICTH = (THIRD_PARTY_EVENT_ID_MIN + 731),
            EVT_NAV1_INNER_SELECTOR = (THIRD_PARTY_EVENT_ID_MIN + 732),
            EVT_NAV1_OUTER_SELECTOR = (THIRD_PARTY_EVENT_ID_MIN + 733),
            EVT_NAV1_LAST = EVT_NAV1_OUTER_SELECTOR,

            EVT_NAV2_TRANSFER_SWITCH = (THIRD_PARTY_EVENT_ID_MIN + 845),
            EVT_NAV2_FIRST = EVT_NAV2_TRANSFER_SWITCH,
            EVT_NAV2_TEST_SWICTH = (THIRD_PARTY_EVENT_ID_MIN + 847),
            EVT_NAV2_OUTER_SELECTOR = (THIRD_PARTY_EVENT_ID_MIN + 848),
            EVT_NAV2_INNER_SELECTOR = (THIRD_PARTY_EVENT_ID_MIN + 849),
            EVT_NAV2_LAST = EVT_NAV2_INNER_SELECTOR,

            // ADF Panel
            EVT_ADF_MODE_SELECTOR = (THIRD_PARTY_EVENT_ID_MIN + 818),
            EVT_ADF_TONE_SWITCH = (THIRD_PARTY_EVENT_ID_MIN + 820),
            EVT_ADF_INNER_SELECTOR = (THIRD_PARTY_EVENT_ID_MIN + 822),
            EVT_ADF_MIDDLE_SELECTOR = (THIRD_PARTY_EVENT_ID_MIN + 823),
            EVT_ADF_OUTER_SELECTOR = (THIRD_PARTY_EVENT_ID_MIN + 824),
            EVT_ADF_TRANSFER_SWITCH = (THIRD_PARTY_EVENT_ID_MIN + 827),

            // SELCAL Panel
            EVT_SELCAL_VHF1_SWITCH = (THIRD_PARTY_EVENT_ID_MIN + 812),
            EVT_SELCAL_VHF2_SWITCH = (THIRD_PARTY_EVENT_ID_MIN + 813),
            EVT_SELCAL_VHF3_SWITCH = (THIRD_PARTY_EVENT_ID_MIN + 814),
            EVT_SELCAL_HF1_SWITCH = (THIRD_PARTY_EVENT_ID_MIN + 937),
            EVT_SELCAL_HF2_SWITCH = (THIRD_PARTY_EVENT_ID_MIN + 938),

            // COMM Panels
            EVT_COM1_TRANSFER_SWITCH = (THIRD_PARTY_EVENT_ID_MIN + 721),
            EVT_COM1_START_RANGE1 = EVT_COM1_TRANSFER_SWITCH,
            EVT_COM1_HF_SENSOR_KNOB = (THIRD_PARTY_EVENT_ID_MIN + 724),
            EVT_COM1_TEST_SWICTH = (THIRD_PARTY_EVENT_ID_MIN + 725),
            EVT_COM1_OUTER_SELECTOR = (THIRD_PARTY_EVENT_ID_MIN + 726),
            EVT_COM1_INNER_SELECTOR = (THIRD_PARTY_EVENT_ID_MIN + 727),
            EVT_COM1_END_RANGE1 = EVT_COM1_INNER_SELECTOR,
            EVT_COM1_PNL_OFF_SWITCH = (THIRD_PARTY_EVENT_ID_MIN + 903),
            EVT_COM1_START_RANGE2 = EVT_COM1_PNL_OFF_SWITCH,
            EVT_COM1_VHF1_SWITCH = (THIRD_PARTY_EVENT_ID_MIN + 904),
            EVT_COM1_VHF2_SWITCH = (THIRD_PARTY_EVENT_ID_MIN + 906),
            EVT_COM1_VHF3_SWITCH = (THIRD_PARTY_EVENT_ID_MIN + 908),
            EVT_COM1_HF1_SWITCH = (THIRD_PARTY_EVENT_ID_MIN + 910),
            EVT_COM1_AM_SWITCH = (THIRD_PARTY_EVENT_ID_MIN + 912),
            EVT_COM1_HF2_SWITCH = (THIRD_PARTY_EVENT_ID_MIN + 914),
            EVT_COM1_END_RANGE2 = EVT_COM1_HF2_SWITCH,


            EVT_COM2_TRANSFER_SWITCH = (THIRD_PARTY_EVENT_ID_MIN + 837),
            EVT_COM2_START_RANGE1 = EVT_COM2_TRANSFER_SWITCH,
            EVT_COM2_HF_SENSOR_KNOB = (THIRD_PARTY_EVENT_ID_MIN + 840),
            EVT_COM2_TEST_SWICTH = (THIRD_PARTY_EVENT_ID_MIN + 841),
            EVT_COM2_OUTER_SELECTOR = (THIRD_PARTY_EVENT_ID_MIN + 842),
            EVT_COM2_INNER_SELECTOR = (THIRD_PARTY_EVENT_ID_MIN + 843),
            EVT_COM2_END_RANGE1 = EVT_COM2_INNER_SELECTOR,
            EVT_COM2_PNL_OFF_SWITCH = (THIRD_PARTY_EVENT_ID_MIN + 924),
            EVT_COM2_START_RANGE2 = EVT_COM2_PNL_OFF_SWITCH,
            EVT_COM2_VHF1_SWITCH = (THIRD_PARTY_EVENT_ID_MIN + 925),
            EVT_COM2_VHF2_SWITCH = (THIRD_PARTY_EVENT_ID_MIN + 927),
            EVT_COM2_VHF3_SWITCH = (THIRD_PARTY_EVENT_ID_MIN + 929),
            EVT_COM2_HF1_SWITCH = (THIRD_PARTY_EVENT_ID_MIN + 931),
            EVT_COM2_AM_SWITCH = (THIRD_PARTY_EVENT_ID_MIN + 933),
            EVT_COM2_HF2_SWITCH = (THIRD_PARTY_EVENT_ID_MIN + 935),
            EVT_COM2_END_RANGE2 = EVT_COM2_HF2_SWITCH,

            EVT_COM3_TRANSFER_SWITCH = (THIRD_PARTY_EVENT_ID_MIN + 946),
            EVT_COM3_START_RANGE1 = EVT_COM3_TRANSFER_SWITCH,
            EVT_COM3_HF_SENSOR_KNOB = (THIRD_PARTY_EVENT_ID_MIN + 949),
            EVT_COM3_TEST_SWICTH = (THIRD_PARTY_EVENT_ID_MIN + 950),
            EVT_COM3_OUTER_SELECTOR = (THIRD_PARTY_EVENT_ID_MIN + 951),
            EVT_COM3_INNER_SELECTOR = (THIRD_PARTY_EVENT_ID_MIN + 952),
            EVT_COM3_END_RANGE1 = EVT_COM3_INNER_SELECTOR,
            EVT_COM3_PNL_OFF_SWITCH = (THIRD_PARTY_EVENT_ID_MIN + 953),
            EVT_COM3_START_RANGE2 = EVT_COM3_PNL_OFF_SWITCH,
            EVT_COM3_VHF1_SWITCH = (THIRD_PARTY_EVENT_ID_MIN + 954),
            EVT_COM3_VHF2_SWITCH = (THIRD_PARTY_EVENT_ID_MIN + 956),
            EVT_COM3_VHF3_SWITCH = (THIRD_PARTY_EVENT_ID_MIN + 958),
            EVT_COM3_HF1_SWITCH = (THIRD_PARTY_EVENT_ID_MIN + 960),
            EVT_COM3_AM_SWITCH = (THIRD_PARTY_EVENT_ID_MIN + 962),
            EVT_COM3_HF2_SWITCH = (THIRD_PARTY_EVENT_ID_MIN + 964),
            EVT_COM3_END_RANGE2 = EVT_COM3_HF2_SWITCH,

            // Audio Control Panels
            //
            // Captain ACP =(at aft electronic panel),
            EVT_ACP_CAPT_MIC_VHF1 = (THIRD_PARTY_EVENT_ID_MIN + 734),
            EVT_ACP_CAPT_MIC_VHF2 = (THIRD_PARTY_EVENT_ID_MIN + 735),
            EVT_ACP_CAPT_MIC_VHF3 = (THIRD_PARTY_EVENT_ID_MIN + 877), // out of order
            EVT_ACP_CAPT_MIC_HF1 = (THIRD_PARTY_EVENT_ID_MIN + 878), // out of order
            EVT_ACP_CAPT_MIC_HF2 = (THIRD_PARTY_EVENT_ID_MIN + 879), // out of order
            EVT_ACP_CAPT_MIC_FLT = (THIRD_PARTY_EVENT_ID_MIN + 736),
            EVT_ACP_CAPT_MIC_SVC = (THIRD_PARTY_EVENT_ID_MIN + 737),
            EVT_ACP_CAPT_MIC_PA = (THIRD_PARTY_EVENT_ID_MIN + 738),

            EVT_ACP_CAPT_REC_VHF1 = (THIRD_PARTY_EVENT_ID_MIN + 739),
            EVT_ACP_CAPT_REC_VHF2 = (THIRD_PARTY_EVENT_ID_MIN + 740),
            EVT_ACP_CAPT_REC_VHF3 = (THIRD_PARTY_EVENT_ID_MIN + 741),
            EVT_ACP_CAPT_REC_HF1 = (THIRD_PARTY_EVENT_ID_MIN + 742),
            EVT_ACP_CAPT_REC_HF2 = (THIRD_PARTY_EVENT_ID_MIN + 880), // out of order
            EVT_ACP_CAPT_REC_FLT = (THIRD_PARTY_EVENT_ID_MIN + 743),
            EVT_ACP_CAPT_REC_SVC = (THIRD_PARTY_EVENT_ID_MIN + 744),
            EVT_ACP_CAPT_REC_PA = (THIRD_PARTY_EVENT_ID_MIN + 745),
            EVT_ACP_CAPT_REC_NAV1 = (THIRD_PARTY_EVENT_ID_MIN + 746),
            EVT_ACP_CAPT_REC_NAV2 = (THIRD_PARTY_EVENT_ID_MIN + 747),
            EVT_ACP_CAPT_REC_ADF1 = (THIRD_PARTY_EVENT_ID_MIN + 748),
            EVT_ACP_CAPT_REC_ADF2 = (THIRD_PARTY_EVENT_ID_MIN + 749),
            EVT_ACP_CAPT_REC_MKR = (THIRD_PARTY_EVENT_ID_MIN + 750),
            EVT_ACP_CAPT_REC_SPKR = (THIRD_PARTY_EVENT_ID_MIN + 751),

            EVT_ACP_CAPT_RT_IC_SWITCH = (THIRD_PARTY_EVENT_ID_MIN + 752),
            EVT_ACP_CAPT_MASK_BOOM_SWITCH = (THIRD_PARTY_EVENT_ID_MIN + 753),
            EVT_ACP_CAPT_FILTER_SWITCH = (THIRD_PARTY_EVENT_ID_MIN + 754),
            EVT_ACP_CAPT_ALT_NORM_SWITCH = (THIRD_PARTY_EVENT_ID_MIN + 755),

            EVT_ACP_CAPT_FIRST1 = EVT_ACP_CAPT_MIC_VHF1,
            EVT_ACP_CAPT_LAST1 = EVT_ACP_CAPT_ALT_NORM_SWITCH,
            EVT_ACP_CAPT_FIRST2 = EVT_ACP_CAPT_MIC_VHF3,
            EVT_ACP_CAPT_LAST2 = EVT_ACP_CAPT_REC_HF2,

            // F/O ACP =(at aft electronic panel),
            EVT_ACP_FO_MIC_VHF1 = (THIRD_PARTY_EVENT_ID_MIN + 850),
            EVT_ACP_FO_MIC_VHF2 = (THIRD_PARTY_EVENT_ID_MIN + 851),
            EVT_ACP_FO_MIC_VHF3 = (THIRD_PARTY_EVENT_ID_MIN + 881), // out of order
            EVT_ACP_FO_MIC_HF1 = (THIRD_PARTY_EVENT_ID_MIN + 882), // out of order
            EVT_ACP_FO_MIC_HF2 = (THIRD_PARTY_EVENT_ID_MIN + 883), // out of order
            EVT_ACP_FO_MIC_FLT = (THIRD_PARTY_EVENT_ID_MIN + 852),
            EVT_ACP_FO_MIC_SVC = (THIRD_PARTY_EVENT_ID_MIN + 853),
            EVT_ACP_FO_MIC_PA = (THIRD_PARTY_EVENT_ID_MIN + 854),

            EVT_ACP_FO_REC_VHF1 = (THIRD_PARTY_EVENT_ID_MIN + 855),
            EVT_ACP_FO_REC_VHF2 = (THIRD_PARTY_EVENT_ID_MIN + 856),
            EVT_ACP_FO_REC_VHF3 = (THIRD_PARTY_EVENT_ID_MIN + 857),
            EVT_ACP_FO_REC_HF1 = (THIRD_PARTY_EVENT_ID_MIN + 858),
            EVT_ACP_FO_REC_HF2 = (THIRD_PARTY_EVENT_ID_MIN + 884), // out of order
            EVT_ACP_FO_REC_FLT = (THIRD_PARTY_EVENT_ID_MIN + 859),
            EVT_ACP_FO_REC_SVC = (THIRD_PARTY_EVENT_ID_MIN + 860),
            EVT_ACP_FO_REC_PA = (THIRD_PARTY_EVENT_ID_MIN + 861),
            EVT_ACP_FO_REC_NAV1 = (THIRD_PARTY_EVENT_ID_MIN + 862),
            EVT_ACP_FO_REC_NAV2 = (THIRD_PARTY_EVENT_ID_MIN + 863),
            EVT_ACP_FO_REC_ADF1 = (THIRD_PARTY_EVENT_ID_MIN + 864),
            EVT_ACP_FO_REC_ADF2 = (THIRD_PARTY_EVENT_ID_MIN + 865),
            EVT_ACP_FO_REC_MKR = (THIRD_PARTY_EVENT_ID_MIN + 866),
            EVT_ACP_FO_REC_SPKR = (THIRD_PARTY_EVENT_ID_MIN + 867),

            EVT_ACP_FO_VOL_NAV1 = (THIRD_PARTY_EVENT_ID_MIN + 1862), // 1000 added for volume rotation event
            EVT_ACP_FO_VOL_NAV2 = (THIRD_PARTY_EVENT_ID_MIN + 1863),
            EVT_ACP_FO_VOL_ADF1 = (THIRD_PARTY_EVENT_ID_MIN + 1864),
            EVT_ACP_FO_VOL_ADF2 = (THIRD_PARTY_EVENT_ID_MIN + 1865),
            EVT_ACP_FO_VOL_MKR = (THIRD_PARTY_EVENT_ID_MIN + 1866),

            EVT_ACP_FO_RT_IC_SWITCH = (THIRD_PARTY_EVENT_ID_MIN + 868),
            EVT_ACP_FO_MASK_BOOM_SWITCH = (THIRD_PARTY_EVENT_ID_MIN + 869),
            EVT_ACP_FO_FILTER_SWITCH = (THIRD_PARTY_EVENT_ID_MIN + 870),
            EVT_ACP_FO_ALT_NORM_SWITCH = (THIRD_PARTY_EVENT_ID_MIN + 871),

            EVT_ACP_FO_FIRST1 = EVT_ACP_FO_MIC_VHF1,
            EVT_ACP_FO_LAST1 = EVT_ACP_FO_ALT_NORM_SWITCH,
            EVT_ACP_FO_FIRST2 = EVT_ACP_FO_MIC_VHF3,
            EVT_ACP_FO_LAST2 = EVT_ACP_FO_REC_HF2,

            // Observer ACP=(at aft electronic panel),
            EVT_ACP_OBS_MIC_VHF1 = (THIRD_PARTY_EVENT_ID_MIN + 291),
            EVT_ACP_OBS_MIC_VHF2 = (THIRD_PARTY_EVENT_ID_MIN + 292),
            EVT_ACP_OBS_MIC_VHF3 = (THIRD_PARTY_EVENT_ID_MIN + 293),
            EVT_ACP_OBS_MIC_HF1 = (THIRD_PARTY_EVENT_ID_MIN + 294),
            EVT_ACP_OBS_MIC_HF2 = (THIRD_PARTY_EVENT_ID_MIN + 295),
            EVT_ACP_OBS_MIC_FLT = (THIRD_PARTY_EVENT_ID_MIN + 296),
            EVT_ACP_OBS_MIC_SVC = (THIRD_PARTY_EVENT_ID_MIN + 297),
            EVT_ACP_OBS_MIC_PA = (THIRD_PARTY_EVENT_ID_MIN + 873), // out of order

            EVT_ACP_OBS_REC_VHF1 = (THIRD_PARTY_EVENT_ID_MIN + 286),
            EVT_ACP_OBS_REC_VHF2 = (THIRD_PARTY_EVENT_ID_MIN + 287),
            EVT_ACP_OBS_REC_VHF3 = (THIRD_PARTY_EVENT_ID_MIN + 874), // out of order
            EVT_ACP_OBS_REC_HF1 = (THIRD_PARTY_EVENT_ID_MIN + 875), // out of order
            EVT_ACP_OBS_REC_HF2 = (THIRD_PARTY_EVENT_ID_MIN + 876), // out of order
            EVT_ACP_OBS_REC_FLT = (THIRD_PARTY_EVENT_ID_MIN + 288),
            EVT_ACP_OBS_REC_SVC = (THIRD_PARTY_EVENT_ID_MIN + 289),
            EVT_ACP_OBS_REC_PA = (THIRD_PARTY_EVENT_ID_MIN + 290),
            EVT_ACP_OBS_REC_NAV1 = (THIRD_PARTY_EVENT_ID_MIN + 280),
            EVT_ACP_OBS_REC_NAV2 = (THIRD_PARTY_EVENT_ID_MIN + 281),
            EVT_ACP_OBS_REC_ADF1 = (THIRD_PARTY_EVENT_ID_MIN + 282),
            EVT_ACP_OBS_REC_ADF2 = (THIRD_PARTY_EVENT_ID_MIN + 283),
            EVT_ACP_OBS_REC_MKR = (THIRD_PARTY_EVENT_ID_MIN + 284),
            EVT_ACP_OBS_REC_SPKR = (THIRD_PARTY_EVENT_ID_MIN + 285),

            EVT_ACP_OBS_VOL_NAV1 = (THIRD_PARTY_EVENT_ID_MIN + 1280), // 1000 added for volume rotation event
            EVT_ACP_OBS_VOL_NAV2 = (THIRD_PARTY_EVENT_ID_MIN + 1281),
            EVT_ACP_OBS_VOL_ADF1 = (THIRD_PARTY_EVENT_ID_MIN + 1282),
            EVT_ACP_OBS_VOL_ADF2 = (THIRD_PARTY_EVENT_ID_MIN + 1283),
            EVT_ACP_OBS_VOL_MKR = (THIRD_PARTY_EVENT_ID_MIN + 1284),

            EVT_ACP_OBS_RT_IC_SWITCH = (THIRD_PARTY_EVENT_ID_MIN + 276),
            EVT_ACP_OBS_MASK_BOOM_SWITCH = (THIRD_PARTY_EVENT_ID_MIN + 277),
            EVT_ACP_OBS_FILTER_SWITCH = (THIRD_PARTY_EVENT_ID_MIN + 278),
            EVT_ACP_OBS_ALT_NORM_SWITCH = (THIRD_PARTY_EVENT_ID_MIN + 279),

            EVT_ACP_OBS_FIRST1 = EVT_ACP_OBS_RT_IC_SWITCH,
            EVT_ACP_OBS_LAST1 = EVT_ACP_OBS_MIC_SVC,
            EVT_ACP_OBS_FIRST2 = EVT_ACP_OBS_MIC_PA,
            EVT_ACP_OBS_LAST2 = EVT_ACP_OBS_REC_HF2,

            // TCAS
            EVT_TCAS_XPNDR = (THIRD_PARTY_EVENT_ID_MIN + 798),
            EVT_TCAS_MODE = (THIRD_PARTY_EVENT_ID_MIN + 800),
            EVT_TCAS_TEST = (THIRD_PARTY_EVENT_ID_MIN + 801),
            EVT_TCAS_ALTSOURCE = (THIRD_PARTY_EVENT_ID_MIN + 803),
            EVT_TCAS_KNOB1 = (THIRD_PARTY_EVENT_ID_MIN + 804),
            EVT_TCAS_KNOB2 = (THIRD_PARTY_EVENT_ID_MIN + 805),
            EVT_TCAS_IDENT = (THIRD_PARTY_EVENT_ID_MIN + 806),
            EVT_TCAS_KNOB4 = (THIRD_PARTY_EVENT_ID_MIN + 807),
            EVT_TCAS_KNOB3 = (THIRD_PARTY_EVENT_ID_MIN + 808),

            // HUD control panel
            EVT_HUD_MODE = (THIRD_PARTY_EVENT_ID_MIN + 770),	// 
            EVT_HUD_STB = (THIRD_PARTY_EVENT_ID_MIN + 771),	// 
            EVT_HUD_RWY = (THIRD_PARTY_EVENT_ID_MIN + 772),	// 
            EVT_HUD_GS = (THIRD_PARTY_EVENT_ID_MIN + 773),	// 
            EVT_HUD_CLR = (THIRD_PARTY_EVENT_ID_MIN + 775),	// 
            EVT_HUD_BRT = (THIRD_PARTY_EVENT_ID_MIN + 776),	// 
            EVT_HUD_DIM = (THIRD_PARTY_EVENT_ID_MIN + 777),	// 
            EVT_HUD_1 = (THIRD_PARTY_EVENT_ID_MIN + 778),	// 
            EVT_HUD_2 = (THIRD_PARTY_EVENT_ID_MIN + 779),	// 
            EVT_HUD_3 = (THIRD_PARTY_EVENT_ID_MIN + 780),	// 
            EVT_HUD_4 = (THIRD_PARTY_EVENT_ID_MIN + 781),	// 
            EVT_HUD_5 = (THIRD_PARTY_EVENT_ID_MIN + 782),	// 
            EVT_HUD_6 = (THIRD_PARTY_EVENT_ID_MIN + 783),	// 
            EVT_HUD_7 = (THIRD_PARTY_EVENT_ID_MIN + 784),	// 
            EVT_HUD_8 = (THIRD_PARTY_EVENT_ID_MIN + 785),	// 
            EVT_HUD_9 = (THIRD_PARTY_EVENT_ID_MIN + 786),	// 
            EVT_HUD_0 = (THIRD_PARTY_EVENT_ID_MIN + 788),	// 
            EVT_HUD_ENTER = (THIRD_PARTY_EVENT_ID_MIN + 787),	// 
            EVT_HUD_TEST = (THIRD_PARTY_EVENT_ID_MIN + 789),	// 
            EVT_HUD_STOW = (THIRD_PARTY_EVENT_ID_MIN + 979),	// 
            EVT_HUD_BRIGTHNESS = (THIRD_PARTY_EVENT_ID_MIN + 980),	//
            EVT_HUD_AUTO_MAN = (THIRD_PARTY_EVENT_ID_MIN + 981),	//

            // HUD Annunciator Panel
            EVT_HGS_FAIL_SWITCH = (THIRD_PARTY_EVENT_ID_MIN + 522),	//


            // CDU
            EVT_CDU_L_L1 = (THIRD_PARTY_EVENT_ID_MIN + 534),
            EVT_CDU_L_L2 = (THIRD_PARTY_EVENT_ID_MIN + 535),
            EVT_CDU_L_L3 = (THIRD_PARTY_EVENT_ID_MIN + 536),
            EVT_CDU_L_L4 = (THIRD_PARTY_EVENT_ID_MIN + 537),
            EVT_CDU_L_L5 = (THIRD_PARTY_EVENT_ID_MIN + 538),
            EVT_CDU_L_L6 = (THIRD_PARTY_EVENT_ID_MIN + 539),
            EVT_CDU_L_R1 = (THIRD_PARTY_EVENT_ID_MIN + 540),
            EVT_CDU_L_R2 = (THIRD_PARTY_EVENT_ID_MIN + 541),
            EVT_CDU_L_R3 = (THIRD_PARTY_EVENT_ID_MIN + 542),
            EVT_CDU_L_R4 = (THIRD_PARTY_EVENT_ID_MIN + 543),
            EVT_CDU_L_R5 = (THIRD_PARTY_EVENT_ID_MIN + 544),
            EVT_CDU_L_R6 = (THIRD_PARTY_EVENT_ID_MIN + 545),
            EVT_CDU_L_INIT_REF = (THIRD_PARTY_EVENT_ID_MIN + 546),
            EVT_CDU_L_RTE = (THIRD_PARTY_EVENT_ID_MIN + 547),
            EVT_CDU_L_CLB = (THIRD_PARTY_EVENT_ID_MIN + 548),
            EVT_CDU_L_CRZ = (THIRD_PARTY_EVENT_ID_MIN + 549),
            EVT_CDU_L_DES = (THIRD_PARTY_EVENT_ID_MIN + 550),
            EVT_CDU_L_MENU = (THIRD_PARTY_EVENT_ID_MIN + 551),
            EVT_CDU_L_LEGS = (THIRD_PARTY_EVENT_ID_MIN + 552),
            EVT_CDU_L_DEP_ARR = (THIRD_PARTY_EVENT_ID_MIN + 553),
            EVT_CDU_L_HOLD = (THIRD_PARTY_EVENT_ID_MIN + 554),
            EVT_CDU_L_PROG = (THIRD_PARTY_EVENT_ID_MIN + 555),
            EVT_CDU_L_EXEC = (THIRD_PARTY_EVENT_ID_MIN + 556),
            EVT_CDU_L_N1_LIMIT = (THIRD_PARTY_EVENT_ID_MIN + 557),
            EVT_CDU_L_FIX = (THIRD_PARTY_EVENT_ID_MIN + 558),
            EVT_CDU_L_PREV_PAGE = (THIRD_PARTY_EVENT_ID_MIN + 559),
            EVT_CDU_L_NEXT_PAGE = (THIRD_PARTY_EVENT_ID_MIN + 560),
            EVT_CDU_L_1 = (THIRD_PARTY_EVENT_ID_MIN + 561),
            EVT_CDU_L_2 = (THIRD_PARTY_EVENT_ID_MIN + 562),
            EVT_CDU_L_3 = (THIRD_PARTY_EVENT_ID_MIN + 563),
            EVT_CDU_L_4 = (THIRD_PARTY_EVENT_ID_MIN + 564),
            EVT_CDU_L_5 = (THIRD_PARTY_EVENT_ID_MIN + 565),
            EVT_CDU_L_6 = (THIRD_PARTY_EVENT_ID_MIN + 566),
            EVT_CDU_L_7 = (THIRD_PARTY_EVENT_ID_MIN + 567),
            EVT_CDU_L_8 = (THIRD_PARTY_EVENT_ID_MIN + 568),
            EVT_CDU_L_9 = (THIRD_PARTY_EVENT_ID_MIN + 569),
            EVT_CDU_L_DOT = (THIRD_PARTY_EVENT_ID_MIN + 570),
            EVT_CDU_L_0 = (THIRD_PARTY_EVENT_ID_MIN + 571),
            EVT_CDU_L_PLUS_MINUS = (THIRD_PARTY_EVENT_ID_MIN + 572),
            EVT_CDU_L_A = (THIRD_PARTY_EVENT_ID_MIN + 573),
            EVT_CDU_L_B = (THIRD_PARTY_EVENT_ID_MIN + 574),
            EVT_CDU_L_C = (THIRD_PARTY_EVENT_ID_MIN + 575),
            EVT_CDU_L_D = (THIRD_PARTY_EVENT_ID_MIN + 576),
            EVT_CDU_L_E = (THIRD_PARTY_EVENT_ID_MIN + 577),
            EVT_CDU_L_F = (THIRD_PARTY_EVENT_ID_MIN + 578),
            EVT_CDU_L_G = (THIRD_PARTY_EVENT_ID_MIN + 579),
            EVT_CDU_L_H = (THIRD_PARTY_EVENT_ID_MIN + 580),
            EVT_CDU_L_I = (THIRD_PARTY_EVENT_ID_MIN + 581),
            EVT_CDU_L_J = (THIRD_PARTY_EVENT_ID_MIN + 582),
            EVT_CDU_L_K = (THIRD_PARTY_EVENT_ID_MIN + 583),
            EVT_CDU_L_L = (THIRD_PARTY_EVENT_ID_MIN + 584),
            EVT_CDU_L_M = (THIRD_PARTY_EVENT_ID_MIN + 585),
            EVT_CDU_L_N = (THIRD_PARTY_EVENT_ID_MIN + 586),
            EVT_CDU_L_O = (THIRD_PARTY_EVENT_ID_MIN + 587),
            EVT_CDU_L_P = (THIRD_PARTY_EVENT_ID_MIN + 588),
            EVT_CDU_L_Q = (THIRD_PARTY_EVENT_ID_MIN + 589),
            EVT_CDU_L_R = (THIRD_PARTY_EVENT_ID_MIN + 590),
            EVT_CDU_L_S = (THIRD_PARTY_EVENT_ID_MIN + 591),
            EVT_CDU_L_T = (THIRD_PARTY_EVENT_ID_MIN + 592),
            EVT_CDU_L_U = (THIRD_PARTY_EVENT_ID_MIN + 593),
            EVT_CDU_L_V = (THIRD_PARTY_EVENT_ID_MIN + 594),
            EVT_CDU_L_W = (THIRD_PARTY_EVENT_ID_MIN + 595),
            EVT_CDU_L_X = (THIRD_PARTY_EVENT_ID_MIN + 596),
            EVT_CDU_L_Y = (THIRD_PARTY_EVENT_ID_MIN + 597),
            EVT_CDU_L_Z = (THIRD_PARTY_EVENT_ID_MIN + 598),
            EVT_CDU_L_SPACE = (THIRD_PARTY_EVENT_ID_MIN + 599),
            EVT_CDU_L_DEL = (THIRD_PARTY_EVENT_ID_MIN + 600),
            EVT_CDU_L_SLASH = (THIRD_PARTY_EVENT_ID_MIN + 601),
            EVT_CDU_L_CLR = (THIRD_PARTY_EVENT_ID_MIN + 602),
            EVT_CDU_L_BRITENESS = (THIRD_PARTY_EVENT_ID_MIN + 605),

            EVT_CDU_R_L1 = (THIRD_PARTY_EVENT_ID_MIN + 606),
            EVT_CDU_R_L2 = (THIRD_PARTY_EVENT_ID_MIN + 607),
            EVT_CDU_R_L3 = (THIRD_PARTY_EVENT_ID_MIN + 608),
            EVT_CDU_R_L4 = (THIRD_PARTY_EVENT_ID_MIN + 609),
            EVT_CDU_R_L5 = (THIRD_PARTY_EVENT_ID_MIN + 610),
            EVT_CDU_R_L6 = (THIRD_PARTY_EVENT_ID_MIN + 611),
            EVT_CDU_R_R1 = (THIRD_PARTY_EVENT_ID_MIN + 612),
            EVT_CDU_R_R2 = (THIRD_PARTY_EVENT_ID_MIN + 613),
            EVT_CDU_R_R3 = (THIRD_PARTY_EVENT_ID_MIN + 614),
            EVT_CDU_R_R4 = (THIRD_PARTY_EVENT_ID_MIN + 615),
            EVT_CDU_R_R5 = (THIRD_PARTY_EVENT_ID_MIN + 616),
            EVT_CDU_R_R6 = (THIRD_PARTY_EVENT_ID_MIN + 617),
            EVT_CDU_R_INIT_REF = (THIRD_PARTY_EVENT_ID_MIN + 618),
            EVT_CDU_R_RTE = (THIRD_PARTY_EVENT_ID_MIN + 619),
            EVT_CDU_R_CLB = (THIRD_PARTY_EVENT_ID_MIN + 620),
            EVT_CDU_R_CRZ = (THIRD_PARTY_EVENT_ID_MIN + 621),
            EVT_CDU_R_DES = (THIRD_PARTY_EVENT_ID_MIN + 622),
            EVT_CDU_R_MENU = (THIRD_PARTY_EVENT_ID_MIN + 623),
            EVT_CDU_R_LEGS = (THIRD_PARTY_EVENT_ID_MIN + 624),
            EVT_CDU_R_DEP_ARR = (THIRD_PARTY_EVENT_ID_MIN + 625),
            EVT_CDU_R_HOLD = (THIRD_PARTY_EVENT_ID_MIN + 626),
            EVT_CDU_R_PROG = (THIRD_PARTY_EVENT_ID_MIN + 627),
            EVT_CDU_R_EXEC = (THIRD_PARTY_EVENT_ID_MIN + 628),
            EVT_CDU_R_N1_LIMIT = (THIRD_PARTY_EVENT_ID_MIN + 629),
            EVT_CDU_R_FIX = (THIRD_PARTY_EVENT_ID_MIN + 630),
            EVT_CDU_R_PREV_PAGE = (THIRD_PARTY_EVENT_ID_MIN + 631),
            EVT_CDU_R_NEXT_PAGE = (THIRD_PARTY_EVENT_ID_MIN + 632),
            EVT_CDU_R_1 = (THIRD_PARTY_EVENT_ID_MIN + 633),
            EVT_CDU_R_2 = (THIRD_PARTY_EVENT_ID_MIN + 634),
            EVT_CDU_R_3 = (THIRD_PARTY_EVENT_ID_MIN + 635),
            EVT_CDU_R_4 = (THIRD_PARTY_EVENT_ID_MIN + 636),
            EVT_CDU_R_5 = (THIRD_PARTY_EVENT_ID_MIN + 637),
            EVT_CDU_R_6 = (THIRD_PARTY_EVENT_ID_MIN + 638),
            EVT_CDU_R_7 = (THIRD_PARTY_EVENT_ID_MIN + 639),
            EVT_CDU_R_8 = (THIRD_PARTY_EVENT_ID_MIN + 640),
            EVT_CDU_R_9 = (THIRD_PARTY_EVENT_ID_MIN + 641),
            EVT_CDU_R_DOT = (THIRD_PARTY_EVENT_ID_MIN + 642),
            EVT_CDU_R_0 = (THIRD_PARTY_EVENT_ID_MIN + 643),
            EVT_CDU_R_PLUS_MINUS = (THIRD_PARTY_EVENT_ID_MIN + 644),
            EVT_CDU_R_A = (THIRD_PARTY_EVENT_ID_MIN + 645),
            EVT_CDU_R_B = (THIRD_PARTY_EVENT_ID_MIN + 646),
            EVT_CDU_R_C = (THIRD_PARTY_EVENT_ID_MIN + 647),
            EVT_CDU_R_D = (THIRD_PARTY_EVENT_ID_MIN + 648),
            EVT_CDU_R_E = (THIRD_PARTY_EVENT_ID_MIN + 649),
            EVT_CDU_R_F = (THIRD_PARTY_EVENT_ID_MIN + 650),
            EVT_CDU_R_G = (THIRD_PARTY_EVENT_ID_MIN + 651),
            EVT_CDU_R_H = (THIRD_PARTY_EVENT_ID_MIN + 652),
            EVT_CDU_R_I = (THIRD_PARTY_EVENT_ID_MIN + 653),
            EVT_CDU_R_J = (THIRD_PARTY_EVENT_ID_MIN + 654),
            EVT_CDU_R_K = (THIRD_PARTY_EVENT_ID_MIN + 655),
            EVT_CDU_R_L = (THIRD_PARTY_EVENT_ID_MIN + 656),
            EVT_CDU_R_M = (THIRD_PARTY_EVENT_ID_MIN + 657),
            EVT_CDU_R_N = (THIRD_PARTY_EVENT_ID_MIN + 658),
            EVT_CDU_R_O = (THIRD_PARTY_EVENT_ID_MIN + 659),
            EVT_CDU_R_P = (THIRD_PARTY_EVENT_ID_MIN + 660),
            EVT_CDU_R_Q = (THIRD_PARTY_EVENT_ID_MIN + 661),
            EVT_CDU_R_R = (THIRD_PARTY_EVENT_ID_MIN + 662),
            EVT_CDU_R_S = (THIRD_PARTY_EVENT_ID_MIN + 663),
            EVT_CDU_R_T = (THIRD_PARTY_EVENT_ID_MIN + 664),
            EVT_CDU_R_U = (THIRD_PARTY_EVENT_ID_MIN + 665),
            EVT_CDU_R_V = (THIRD_PARTY_EVENT_ID_MIN + 666),
            EVT_CDU_R_W = (THIRD_PARTY_EVENT_ID_MIN + 667),
            EVT_CDU_R_X = (THIRD_PARTY_EVENT_ID_MIN + 668),
            EVT_CDU_R_Y = (THIRD_PARTY_EVENT_ID_MIN + 669),
            EVT_CDU_R_Z = (THIRD_PARTY_EVENT_ID_MIN + 670),
            EVT_CDU_R_SPACE = (THIRD_PARTY_EVENT_ID_MIN + 671),
            EVT_CDU_R_DEL = (THIRD_PARTY_EVENT_ID_MIN + 672),
            EVT_CDU_R_SLASH = (THIRD_PARTY_EVENT_ID_MIN + 673),
            EVT_CDU_R_CLR = (THIRD_PARTY_EVENT_ID_MIN + 674),
            EVT_CDU_R_BRITENESS = (THIRD_PARTY_EVENT_ID_MIN + 677),

            // Fire protection panel
            EVT_FIRE_OVHT_DET_SWITCH_1 = (THIRD_PARTY_EVENT_ID_MIN + 694),
            EVT_FIRE_DETECTION_TEST_SWITCH = (THIRD_PARTY_EVENT_ID_MIN + 696),
            EVT_FIRE_HANDLE_ENGINE_1_TOP = (THIRD_PARTY_EVENT_ID_MIN + 697),
            EVT_FIRE_HANDLE_ENGINE_1_BOTTOM = (THIRD_PARTY_EVENT_ID_MIN + 6971),
            EVT_FIRE_HANDLE_APU_TOP = (THIRD_PARTY_EVENT_ID_MIN + 698),
            EVT_FIRE_HANDLE_APU_BOTTOM = (THIRD_PARTY_EVENT_ID_MIN + 6981),
            EVT_FIRE_HANDLE_ENGINE_2_TOP = (THIRD_PARTY_EVENT_ID_MIN + 699),
            EVT_FIRE_HANDLE_ENGINE_2_BOTTOM = (THIRD_PARTY_EVENT_ID_MIN + 6991),
            EVT_FIRE_BELL_CUTOUT_SWITCH = (THIRD_PARTY_EVENT_ID_MIN + 704),
            EVT_FIRE_OVHT_DET_SWITCH_2 = (THIRD_PARTY_EVENT_ID_MIN + 705),
            EVT_FIRE_EXTINGUISHER_TEST_SWITCH = (THIRD_PARTY_EVENT_ID_MIN + 715),
            EVT_FIRE_UNLOCK_SWITCH_ENGINE_1 = (THIRD_PARTY_EVENT_ID_MIN + 976),
            EVT_FIRE_UNLOCK_SWITCH_APU = (THIRD_PARTY_EVENT_ID_MIN + 977),
            EVT_FIRE_UNLOCK_SWITCH_ENGINE_2 = (THIRD_PARTY_EVENT_ID_MIN + 978),

            // Cargo Fire
            EVT_CARGO_FIRE_DET_SEL_SWITCH_FWD = (THIRD_PARTY_EVENT_ID_MIN + 760),
            EVT_CARGO_FIRE_DET_SEL_SWITCH_AFT = (THIRD_PARTY_EVENT_ID_MIN + 761),
            EVT_CARGO_FIRE_ARM_SWITCH_FWD = (THIRD_PARTY_EVENT_ID_MIN + 764),
            EVT_CARGO_FIRE_ARM_SWITCH_AFT = (THIRD_PARTY_EVENT_ID_MIN + 766),
            EVT_CARGO_FIRE_DISC_SWITCH_GUARD = (THIRD_PARTY_EVENT_ID_MIN + 767),
            EVT_CARGO_FIRE_DISC_SWITCH = (THIRD_PARTY_EVENT_ID_MIN + 768),
            EVT_CARGO_FIRE_TEST_SWITCH = (THIRD_PARTY_EVENT_ID_MIN + 769),

            // Flight controls - pedestal
            EVT_FCTL_AILERON_TRIM = (THIRD_PARTY_EVENT_ID_MIN + 810),
            EVT_FCTL_RUDDER_TRIM = (THIRD_PARTY_EVENT_ID_MIN + 811),

            // Pedestal Lights Controls
            EVT_PED_FLOOD_CONTROL = (THIRD_PARTY_EVENT_ID_MIN + 756),
            EVT_PED_PANEL_CONTROL = (THIRD_PARTY_EVENT_ID_MIN + 757),

            // Custom shortcut special events
            EVT_LDG_LIGHTS_TOGGLE = (THIRD_PARTY_EVENT_ID_MIN + 14000),
            EVT_TURNOFF_LIGHTS_TOGGLE = (THIRD_PARTY_EVENT_ID_MIN + 14001),
            EVT_COCKPIT_LIGHTS_TOGGLE = (THIRD_PARTY_EVENT_ID_MIN + 14002),
            EVT_COCKPIT_LIGHTS_ON = (THIRD_PARTY_EVENT_ID_MIN + 14003),
            EVT_COCKPIT_LIGHTS_OFF = (THIRD_PARTY_EVENT_ID_MIN + 14004),
            EVT_DOOR_FWD_L = (THIRD_PARTY_EVENT_ID_MIN + 14005),
            EVT_DOOR_FWD_R = (THIRD_PARTY_EVENT_ID_MIN + 14006),
            EVT_DOOR_AFT_L = (THIRD_PARTY_EVENT_ID_MIN + 14007),
            EVT_DOOR_AFT_R = (THIRD_PARTY_EVENT_ID_MIN + 14008),
            EVT_DOOR_OVERWING_EXIT_L = (THIRD_PARTY_EVENT_ID_MIN + 14009),
            EVT_DOOR_OVERWING_EXIT_R = (THIRD_PARTY_EVENT_ID_MIN + 14010),
            EVT_DOOR_CARGO_FWD = (THIRD_PARTY_EVENT_ID_MIN + 14013),  // n ote number skip to match eDoors enum
            EVT_DOOR_CARGO_AFT = (THIRD_PARTY_EVENT_ID_MIN + 14014),
            EVT_DOOR_EQUIPMENT_HATCH = (THIRD_PARTY_EVENT_ID_MIN + 14015),
            EVT_DOOR_AIRSTAIR = (THIRD_PARTY_EVENT_ID_MIN + 14016),

            // Yoke Animations
            EVT_YOKE_L_COUNTER_1 = (THIRD_PARTY_EVENT_ID_MIN + 998),	// Counters =(digits left to right),  
            EVT_YOKE_L_COUNTER_2 = (THIRD_PARTY_EVENT_ID_MIN + 999),
            EVT_YOKE_L_COUNTER_3 = (THIRD_PARTY_EVENT_ID_MIN + 1000),
            EVT_YOKE_R_COUNTER_1 = (THIRD_PARTY_EVENT_ID_MIN + 1001),
            EVT_YOKE_R_COUNTER_2 = (THIRD_PARTY_EVENT_ID_MIN + 1002),
            EVT_YOKE_R_COUNTER_3 = (THIRD_PARTY_EVENT_ID_MIN + 1003),
            EVT_YOKE_L_AP_DISC_SWITCH = (THIRD_PARTY_EVENT_ID_MIN + 1004),	// AP Disconnect switches
            EVT_YOKE_R_AP_DISC_SWITCH = (THIRD_PARTY_EVENT_ID_MIN + 1005),

            // MCP Direct Control 
            EVT_MCP_CRS_L_SET = (THIRD_PARTY_EVENT_ID_MIN + 14500),	// Sets MCP course specified by the event parameter
            EVT_MCP_CRS_R_SET = (THIRD_PARTY_EVENT_ID_MIN + 14501),
            EVT_MCP_IAS_SET = (THIRD_PARTY_EVENT_ID_MIN + 14502),	// Sets MCP IAS, if IAS mode is active
            EVT_MCP_MACH_SET = (THIRD_PARTY_EVENT_ID_MIN + 14503),	// Sets MCP MACH =(if active), to parameter*0.01 =(e.g. send 78 to set M0.78),
            EVT_MCP_HDG_SET = (THIRD_PARTY_EVENT_ID_MIN + 14504),	// Sets new heading, commands the shortest turn
            EVT_MCP_ALT_SET = (THIRD_PARTY_EVENT_ID_MIN + 14505),
            EVT_MCP_VS_SET = (THIRD_PARTY_EVENT_ID_MIN + 14506),	// Sets MCP VS =(if VS window open), to parameter-10000 =(e.g. send 8200 for -1800fpm),

            // Panel system events
            EVT_CTRL_ACCELERATION_DISABLE = (THIRD_PARTY_EVENT_ID_MIN + 14600),
            EVT_CTRL_ACCELERATION_ENABLE = (THIRD_PARTY_EVENT_ID_MIN + 14600),
        }

        // Notification Group priority values (not in managed simmconnect ?)
        public enum SIMCONNECT_GROUP_PRIORITY : uint
        {
            HIGHEST = 1,      // highest priority
            HIGHEST_MASKABLE = 10000000,      // highest priority that allows events to be masked
            STANDARD = 1900000000,      // standard priority
            DEFAULT = 2000000000,      // default priority
            LOWEST = 4000000000,      // priorities lower than this will be ignored
        }
    }

}

