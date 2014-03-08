//------------------------------------------------------------------------------
//
//  PMDG 737NGX external connection SDK
//  Copyright (c) 2011 Precision Manuals Development Group
// 
//------------------------------------------------------------------------------

#ifndef PMDG_NGX_SDK_H
#define PMDG_NGX_SDK_H

// SimConnect data area definitions
#define PMDG_NGX_DATA_NAME	"PMDG_NGX_Data"
#define PMDG_NGX_DATA_ID	0x4E477831
#define PMDG_NGX_DATA_DEFINITION	0x4E477832
#define PMDG_NGX_CONTROL_NAME	"PMDG_NGX_Control"
#define PMDG_NGX_CONTROL_ID	0x4E477833
#define PMDG_NGX_CONTROL_DEFINITION	0x4E477834

// NOTE - add these lines: 
//
//[SDK]
//EnableDataBroadcast=1
//
// to enable the data sending from the NGX.

// NGX data structure
struct PMDG_NGX_Data
{
	////////////////////////////////////////////
	// Controls and indicators
	////////////////////////////////////////////

	// Aft overhead
	//------------------------------------------

	// ADIRU
	unsigned char	IRS_DisplaySelector;				// Positions 0..4
	bool			IRS_SysDisplay_R;					// false: L  true: R
	bool			IRS_annunGPS;						
	bool			IRS_annunALIGN[2];						
	bool			IRS_annunON_DC[2];						
	bool			IRS_annunFAULT[2];						
	bool			IRS_annunDC_FAIL[2];						
	unsigned char	IRS_ModeSelector[2];					// 0: OFF  1: ALIGN  2: NAV  3: ATT

	// PSEU
	bool			WARN_annunPSEU;						

	// Service Interphone
	bool			COMM_ServiceInterphoneSw;

	// Lights
	unsigned char	LTS_DomeWhiteSw;					// 0: DIM  1: OFF  2: BRIGHT

	// Engine
	bool			ENG_EECSwitch[2];
	bool			ENG_annunREVERSER[2];
	bool			ENG_annunENGINE_CONTROL[2];
	bool			ENG_annunALTN[2];

	// Oxygen
	unsigned char	OXY_Needle;							// Position 0...240
	bool			OXY_SwNormal;						// true: NORMAL  false: ON
	bool			OXY_annunPASS_OXY_ON;

	// Gear
	bool			GEAR_annunOvhdLEFT;
	bool			GEAR_annunOvhdNOSE;
	bool			GEAR_annunOvhdRIGHT;

	// Flight recorder
	bool			FLTREC_SwNormal;					// true: NORMAL  false: TEST
	bool			FLTREC_annunOFF;


	// Forward overhead
	//------------------------------------------

	// Flight Controls
	unsigned char	FCTL_FltControl_Sw[2];				// 0: STBY/RUD  1: OFF  2: ON
	bool			FCTL_Spoiler_Sw[2];					// true: ON  false: OFF  
	bool			FCTL_YawDamper_Sw;
	bool			FCTL_AltnFlaps_Sw_ARM;				// true: ARM  false: OFF
	unsigned char	FCTL_AltnFlaps_Control_Sw;			// 0: UP  1: OFF  2: DOWN
	bool			FCTL_annunFC_LOW_PRESSURE[2];		// FLT CONTROL
	bool			FCTL_annunYAW_DAMPER;	
	bool			FCTL_annunLOW_QUANTITY;	
	bool			FCTL_annunLOW_PRESSURE;	
	bool			FCTL_annunLOW_STBY_RUD_ON;	
	bool			FCTL_annunFEEL_DIFF_PRESS;	
	bool			FCTL_annunSPEED_TRIM_FAIL;	
	bool			FCTL_annunMACH_TRIM_FAIL;	
	bool			FCTL_annunAUTO_SLAT_FAIL;	

	// Navigation/Displays
	unsigned char	NAVDIS_VHFNavSelector;				// 0: BOTH ON 1  1: NORMAL  2: BOTH ON 2
	unsigned char	NAVDIS_IRSSelector;					// 0: BOTH ON L  1: NORMAL  2: BOTH ON R
	unsigned char	NAVDIS_FMCSelector;					// 0: BOTH ON L  1: NORMAL  2: BOTH ON R
	unsigned char	NAVDIS_SourceSelector;				// 0: ALL ON 1   1: AUTO    2: ALL ON 2
	unsigned char	NAVDIS_ControlPaneSelector;			// 0: BOTH ON 1  1: NORMAL  2: BOTH ON 2

	// Fuel
	float			FUEL_FuelTempNeedle;				// Value
	bool			FUEL_CrossFeedSw;
	bool			FUEL_PumpFwdSw[2];					// left fwd / right fwd
	bool			FUEL_PumpAftSw[2];					// left aft / right aft
	bool			FUEL_PumpCtrSw[2];					// ctr left / ctr right
	bool			FUEL_annunENG_VALVE_CLOSED[2];
	bool			FUEL_annunSPAR_VALVE_CLOSED[2];
	bool			FUEL_annunFILTER_BYPASS[2];
	bool			FUEL_annunXFEED_VALVE_OPEN;
	bool			FUEL_annunLOWPRESS_Fwd[2];
	bool			FUEL_annunLOWPRESS_Aft[2];
	bool			FUEL_annunLOWPRESS_Ctr[2];

	// Electrical
	bool			ELEC_annunBAT_DISCHARGE;
	bool			ELEC_annunTR_UNIT;
	bool			ELEC_annunELEC;
	unsigned char	ELEC_DCMeterSelector;				// 0: STBY PWR  1: BAT BUS ... 7: TEST
	unsigned char	ELEC_ACMeterSelector;				// 0: STBY PWR  1: GND PWR ... 6: TEST
	unsigned char	ELEC_BatSelector;					// 0: OFF  1: BAT  2: ON
	bool			ELEC_CabUtilSw;
	bool			ELEC_IFEPassSeatSw;
	bool			ELEC_annunDRIVE[2];
	bool			ELEC_annunSTANDBY_POWER_OFF;
	bool			ELEC_IDGDisconnectSw[2];
	unsigned char	ELEC_StandbyPowerSelector;			// 0: BAT  1: OFF  2: AUTO
	bool			ELEC_annunGRD_POWER_AVAILABLE;
	bool			ELEC_GrdPwrSw;
	bool			ELEC_BusTransSw_AUTO;
	bool			ELEC_GenSw[2];
	bool			ELEC_APUGenSw[2];
	bool			ELEC_annunTRANSFER_BUS_OFF[2];
	bool			ELEC_annunSOURCE_OFF[2];
	bool			ELEC_annunGEN_BUS_OFF[2];
	bool			ELEC_annunAPU_GEN_OFF_BUS;

	// APU
	float			APU_EGTNeedle;				// Value
	bool			APU_annunMAINT;
	bool			APU_annunLOW_OIL_PRESSURE;
	bool			APU_annunFAULT;
	bool			APU_annunOVERSPEED;

	// Wipers
	unsigned char	OH_WiperLSelector;			// 0: PARK  1: INT  2: LOW  3:HIGH
	unsigned char	OH_WiperRSelector;			// 0: PARK  1: INT  2: LOW  3:HIGH

	// Center overhead controls & indicators
	unsigned char	LTS_CircuitBreakerKnob;		// Position 0...150
	unsigned char	LTS_OvereadPanelKnob;		// Position 0...150
	bool			AIR_EquipCoolingSupplyNORM;
	bool			AIR_EquipCoolingExhaustNORM;
	bool			AIR_annunEquipCoolingSupplyOFF;
	bool			AIR_annunEquipCoolingExhaustOFF;
	bool			LTS_annunEmerNOT_ARMED;
	unsigned char	LTS_EmerExitSelector;		// 0: OFF  1: ARMED  2: ON
	unsigned char	COMM_NoSmokingSelector;		// 0: OFF  1: AUTO   2: ON
	unsigned char	COMM_FastenBeltsSelector;	// 0: OFF  1: AUTO   2: ON
	bool			COMM_annunCALL;
	bool			COMM_annunPA_IN_USE;

	// Anti-ice
	bool			ICE_annunOVERHEAT[4];
	bool			ICE_annunON[4];
	bool			ICE_WindowHeatSw[4];
	bool			ICE_annunCAPT_PITOT;
	bool			ICE_annunL_ELEV_PITOT;
	bool			ICE_annunL_ALPHA_VANE;
	bool			ICE_annunL_TEMP_PROBE;
	bool			ICE_annunFO_PITOT;
	bool			ICE_annunR_ELEV_PITOT;
	bool			ICE_annunR_ALPHA_VANE;
	bool			ICE_annunAUX_PITOT;
	bool			ICE_TestProbeHeatSw[2];
	bool			ICE_annunVALVE_OPEN[2];
	bool			ICE_annunCOWL_ANTI_ICE[2];
	bool			ICE_annunCOWL_VALVE_OPEN[2];
	bool			ICE_WingAntiIceSw;
	bool			ICE_EngAntiIceSw[2];

	// Hydraulics
	bool			HYD_annunLOW_PRESS_eng[2];
	bool			HYD_annunLOW_PRESS_elec[2];
	bool			HYD_annunOVERHEAT_elec[2];
	bool			HYD_PumpSw_eng[2];
	bool			HYD_PumpSw_elec[2];

	// Air systems
	unsigned char	AIR_TempSourceSelector;				// Positions 0..6
	bool			AIR_TrimAirSwitch;
	bool			AIR_annunZoneTemp[3];
	bool			AIR_annunDualBleed;		
	bool			AIR_annunRamDoorL;		
	bool			AIR_annunRamDoorR;		
	bool			AIR_RecircFanSwitch[2];			
	unsigned char   AIR_PackSwitch[2];					// 0=OFF  1=AUTO  2=HIGH
	bool			AIR_BleedAirSwitch[2];			
	bool			AIR_APUBleedAirSwitch;			
	bool			AIR_IsolationValveSwitch;			
	bool			AIR_annunPackTripOff[2];		
	bool			AIR_annunWingBodyOverheat[2];		
	bool			AIR_annunBleedTripOff[2];	

	unsigned int	AIR_FltAltWindow;			
	unsigned int	AIR_LandAltWindow;			
	unsigned int	AIR_OutflowValveSwitch;				// 0=CLOSE  1=NEUTRAL  2=OPEN
	unsigned int	AIR_PressurizationModeSelector;		// 0=AUTO  1=ALTN  2=MAN

	// Bottom overhead
	unsigned char	LTS_LandingLtRetractableSw[2];		// 0: RETRACT  1: EXTEND  2: ON
	bool			LTS_LandingLtFixedSw[2];
	bool			LTS_RunwayTurnoffSw[2];
	bool			LTS_TaxiSw;
	unsigned char	APU_Selector;						// 0: OFF  1: ON  2: START
	unsigned char	ENG_StartSelector[2];				// 0: GRD  1: OFF  2: CONT  3: FLT
	unsigned char	ENG_IgnitionSelector;				// 0: IGN L  1: BOTH  2: IGN R
	bool			LTS_LogoSw;
	unsigned char	LTS_PositionSw;						// 0: STEADY  1: OFF  2: STROBE&STEADY
	bool			LTS_AntiCollisionSw;
	bool			LTS_WingSw;
	bool			LTS_WheelWellSw;


	// Glareshield
	//------------------------------------------

	// Warnings
	bool			WARN_annunFIRE_WARN[2];
	bool			WARN_annunMASTER_CAUTION[2];
	bool			WARN_annunFLT_CONT;
	bool			WARN_annunIRS;
	bool			WARN_annunFUEL;
	bool			WARN_annunELEC;
	bool			WARN_annunAPU;
	bool			WARN_annunOVHT_DET;
	bool			WARN_annunANTI_ICE;
	bool			WARN_annunHYD;
	bool			WARN_annunDOORS;
	bool			WARN_annunENG;
	bool			WARN_annunOVERHEAD;
	bool			WARN_annunAIR_COND;

	// EFIS control panels
	bool			EFIS_MinsSelBARO[2];
	bool			EFIS_BaroSelHPA[2];
	unsigned char	EFIS_VORADFSel1[2];					// 0: VOR  1: OFF  2: ADF
	unsigned char	EFIS_VORADFSel2[2];					// 0: VOR  1: OFF  2: ADF
	unsigned char	EFIS_ModeSel[2];					// 0: APP  1: VOR  2: MAP  3: PLAn
	unsigned char	EFIS_RangeSel[2];					// 0: 5 ... 7: 640

	// Mode control panel
	unsigned short	MCP_Course[2];
	float			MCP_IASMach;						// Mach if < 10.0
	bool			MCP_IASBlank;
	bool			MCP_IASOverspeedFlash;
	bool			MCP_IASUnderspeedFlash;
	unsigned short	MCP_Heading;
	unsigned short	MCP_Altitude;
	short			MCP_VertSpeed;
	bool			MCP_VertSpeedBlank;

	bool			MCP_FDSw[2];
	bool			MCP_ATArmSw;
	unsigned char	MCP_BankLimitSel;					// 0: 10 ... 4: 30
	bool			MCP_DisengageBar;

	bool			MCP_annunFD[2];
	bool			MCP_annunATArm;
	bool			MCP_annunN1;
	bool			MCP_annunSPEED;
	bool			MCP_annunVNAV;
	bool			MCP_annunLVL_CHG;
	bool			MCP_annunHDG_SEL;
	bool			MCP_annunLNAV;
	bool			MCP_annunVOR_LOC;
	bool			MCP_annunAPP;
	bool			MCP_annunALT_HOLD;
	bool			MCP_annunVS;
	bool			MCP_annunCMD_A;
	bool			MCP_annunCWS_A;
	bool			MCP_annunCMD_B;
	bool			MCP_annunCWS_B;

	// Forward panel
	//------------------------------------------
	bool			MAIN_NoseWheelSteeringSwNORM;		// false: ALT
	bool			MAIN_annunBELOW_GS[2];
	unsigned char	MAIN_MainPanelDUSel[2];				// 0: OUTBD PFD ... 4 MFD for Capt; reverse sequence for FO
	unsigned char	MAIN_LowerDUSel[2];					// 0: ENG PRI ... 2 ND for Capt; reverse sequence for FO
	bool			MAIN_annunAP[2];
	bool			MAIN_annunAT[2];
	bool			MAIN_annunFMC[2];
	unsigned char	MAIN_DisengageTestSelector[2];			// 0: 1  1: OFF  2: 2
	bool			MAIN_annunSPEEDBRAKE_ARMED;
	bool			MAIN_annunSPEEDBRAKE_DO_NOT_ARM;
	bool			MAIN_annunSPEEDBRAKE_EXTENDED;
	bool			MAIN_annunSTAB_OUT_OF_TRIM;
	unsigned char	MAIN_LightsSelector;				// 0: TEST  1: BRT  2: DIM
	bool			MAIN_RMISelector1_VOR;
	bool			MAIN_RMISelector2_VOR;
	unsigned char	MAIN_N1SetSelector;					// 0: 2  1: 1  2: AUTO  3: BOTH
	unsigned char	MAIN_SpdRefSelector;				// 0: SET  1: AUTO  2: V1  3: VR  4: WT  5: VREF  6: Bug  
	unsigned char	MAIN_FuelFlowSelector;				// 0: RESET  1: RATE  2: USED
	unsigned char	MAIN_AutobrakeSelector;				// 0: RTO  1: OFF ... 5: MAX
	bool			MAIN_annunANTI_SKID_INOP;
	bool			MAIN_annunAUTO_BRAKE_DISARM;
	bool			MAIN_annunLE_FLAPS_TRANSIT;
	bool			MAIN_annunLE_FLAPS_EXT;
	float			MAIN_TEFlapsNeedle[2];				// Value
	bool			MAIN_annunGEAR_transit[3];
	bool			MAIN_annunGEAR_locked[3];
	unsigned char	MAIN_GearLever;						// 0: UP  1: OFF  2: DOWN
	float			MAIN_BrakePressNeedle;				// Value

	bool			HGS_annun_AIII;
	bool			HGS_annun_NO_AIII;
	bool			HGS_annun_FLARE;	
	bool			HGS_annun_RO;
	bool			HGS_annun_RO_CTN;
	bool			HGS_annun_RO_ARM;
	bool			HGS_annun_TO;
	bool			HGS_annun_TO_CTN;
	bool			HGS_annun_APCH;
	bool			HGS_annun_TO_WARN;
	bool			HGS_annun_Bar;
	bool			HGS_annun_FAIL;

	// Lower forward panel
	//------------------------------------------
	unsigned char	LTS_MainPanelKnob[2];				// Position 0...150
	unsigned char	LTS_BackgroundKnob;					// Position 0...150
	unsigned char	LTS_AFDSFloodKnob;					// Position 0...150
	unsigned char	LTS_OutbdDUBrtKnob[2];				// Position 0...127
	unsigned char	LTS_InbdDUBrtKnob[2];				// Position 0...127
	unsigned char	LTS_InbdDUMapBrtKnob[2];			// Position 0...127
	unsigned char	LTS_UpperDUBrtKnob;					// Position 0...127
	unsigned char	LTS_LowerDUBrtKnob;					// Position 0...127
	unsigned char	LTS_LowerDUMapBrtKnob;				// Position 0...127

	bool			GPWS_annunINOP;
	bool			GPWS_FlapInhibitSw_NORM;
	bool			GPWS_GearInhibitSw_NORM;
	bool			GPWS_TerrInhibitSw_NORM;


	// Control Stand
	//------------------------------------------

	bool			CDU_annunEXEC[2];
	bool			CDU_annunCALL[2];
	bool			CDU_annunFAIL[2];
	bool			CDU_annunMSG[2];
	bool			CDU_annunOFST[2];
	unsigned char	CDU_BrtKnob[2];						// Position 0...127

	bool			TRIM_StabTrimMainElecSw_NORMAL;
	bool			TRIM_StabTrimAutoPilotSw_NORMAL;
	bool			PED_annunParkingBrake;

	unsigned char	FIRE_OvhtDetSw[2];					// 0: A  1: NORMAL  2: B
	bool			FIRE_annunENG_OVERHEAT[2];
	unsigned char	FIRE_DetTestSw;						// 0: FAULT/INOP  1: neutral  2: OVHT/FIRE
	unsigned char	FIRE_HandlePos[3];					// 0: In  1: Blocked  2: Out  3: Turned Left  4: Turned right
	bool			FIRE_HandleIlluminated[3];
	bool			FIRE_annunWHEEL_WELL;
	bool			FIRE_annunFAULT;
	bool			FIRE_annunAPU_DET_INOP;
	bool			FIRE_annunAPU_BOTTLE_DISCHARGE;
	bool			FIRE_annunBOTTLE_DISCHARGE[2];
	unsigned char	FIRE_ExtinguisherTestSw;			// 0: 1  1: neutral  2: 2
	bool			FIRE_annunExtinguisherTest[3];		// Left, Right, APU

	bool			CARGO_annunExtTest[2];				// Fwd, Aft
	unsigned char	CARGO_DetSelect[2];					// 0: A  1: ORM  2: B
	bool			CARGO_ArmedSw[2];				
	bool			CARGO_annunFWD;				
	bool			CARGO_annunAFT;				
	bool			CARGO_annunDETECTOR_FAULT;				
	bool			CARGO_annunDISCH;			

	bool			HGS_annunRWY;
	bool			HGS_annunGS;
	bool			HGS_annunFAULT;
	bool			HGS_annunCLR;

	bool			XPDR_XpndrSelector_2;				// false: 1  true: 2
	bool			XPDR_AltSourceSel_2;				// false: 1  true: 2
	unsigned char	XPDR_ModeSel;						// 0: STBY  1: ALT RPTG OFF ... 4: TA/RA
	bool			XPDR_annunFAIL;

	unsigned char	LTS_PedFloodKnob;					// Position 0...150
	unsigned char	LTS_PedPanelKnob;					// Position 0...150

	bool			TRIM_StabTrimSw_NORMAL;
	bool			PED_annunLOCK_FAIL;
	bool			PED_annunAUTO_UNLK;
	unsigned char	PED_FltDkDoorSel;					// 0: UNLKD  1 AUTO pushed in  2: AUTO  3: DENY

	
	// Additional variables: used by FS2Crew
	bool			ENG_StartValve[2];					// true: valve open
	float			AIR_DuctPress[2];					// PSI
	unsigned char   COMM_Attend_PressCount;				// incremented with each button press
	unsigned char   COMM_GrdCall_PressCount;			// incremented with each button press
	unsigned char   COMM_SelectedMic[3];				// array: 0=capt, 1=F/O, 2=observer.
														// values: 0=VHF1  1=VHF2  2=VHF3  3=HF1  4=HF2  5=FLT  6=SVC  7=PA
	float			FUEL_QtyCenter;						// LBS
	float			FUEL_QtyLeft;						// LBS
	float			FUEL_QtyRight;						// LBS
	bool			IRS_aligned;						// at least one IRU is aligned
	unsigned char   AircraftModel;						// 1: -600  2: -700  3: -700WL  4: -800  5: -800WL  6: -900  7: -900ER
	bool			WeightInKg;							// false: LBS  true: KG
	bool			GPWS_V1CallEnabled;					// GPWS V1 callout option enabled
	bool			GroundConnAvailable;				// can connect/disconnect ground air/electrics

	unsigned char	FMC_TakeoffFlaps;					// degrees, 0 if not set
	unsigned char	FMC_V1;								// knots, 0 if not set
	unsigned char	FMC_VR;								// knots, 0 if not set
	unsigned char	FMC_V2;								// knots, 0 if not set
	unsigned char	FMC_LandingFlaps;					// degrees, 0 if not set
	unsigned char	FMC_LandingVREF;					// knots, 0 if not set
	unsigned short  FMC_CruiseAlt;						// ft, 0 if not set
	short			FMC_LandingAltitude;				// ft; -32767 if not available
	unsigned short  FMC_TransitionAlt;					// ft
	unsigned short  FMC_TransitionLevel;				// ft
	bool			FMC_PerfInputComplete;
	float			FMC_DistanceToTOD;					// nm; 0.0 if passed, negative if n/a
	float			FMC_DistanceToDest;					// nm; negative if n/a
	char			FMC_flightNumber[9];



	// The rest of the controls and indicators match their standard FSX counterparts
	// and can be accessed using the standard SimConnect means.


	unsigned char   reserved[168];						
};

// NGX Control Structure
struct PMDG_NGX_Control
{
	unsigned int Event;
	unsigned int Parameter;
};

#define MOUSE_FLAG_RIGHTSINGLE   0x80000000
#define MOUSE_FLAG_MIDDLESINGLE  0x40000000
#define MOUSE_FLAG_LEFTSINGLE    0x20000000
#define MOUSE_FLAG_RIGHTDOUBLE   0x10000000
#define MOUSE_FLAG_MIDDLEDOUBLE  0x08000000
#define MOUSE_FLAG_LEFTDOUBLE    0x04000000
#define MOUSE_FLAG_RIGHTDRAG     0x02000000
#define MOUSE_FLAG_MIDDLEDRAG    0x01000000
#define MOUSE_FLAG_LEFTDRAG      0x00800000
#define MOUSE_FLAG_MOVE          0x00400000
#define MOUSE_FLAG_DOWN_REPEAT   0x00200000
#define MOUSE_FLAG_RIGHTRELEASE  0x00080000
#define MOUSE_FLAG_MIDDLERELEASE 0x00040000
#define MOUSE_FLAG_LEFTRELEASE   0x00020000
#define MOUSE_FLAG_WHEEL_FLIP    0x00010000   // invert direction of mouse wheel
#define MOUSE_FLAG_WHEEL_SKIP    0x00008000   // look at next 2 rect for mouse wheel commands
#define MOUSE_FLAG_WHEEL_UP      0x00004000
#define MOUSE_FLAG_WHEEL_DOWN    0x00002000


// Control Events

#ifndef THIRD_PARTY_EVENT_ID_MIN
#define THIRD_PARTY_EVENT_ID_MIN        		0x00011000		// equals to 69632
#endif


// Overhead - Electric  
#define	EVT_OH_ELEC_BATTERY_SWITCH				(THIRD_PARTY_EVENT_ID_MIN + 1)	    // 01 - BAT Switch
#define	EVT_OH_ELEC_BATTERY_GUARD				(THIRD_PARTY_EVENT_ID_MIN + 2)		// 02 - BAT Switch Guard 
#define	EVT_OH_ELEC_DC_METER					(THIRD_PARTY_EVENT_ID_MIN + 3)		// 03 - DC SOURCE Knob					
#define	EVT_OH_ELEC_AC_METER					(THIRD_PARTY_EVENT_ID_MIN + 4)		// 04 - AC SOURCE Knob					
#define	EVT_OH_ELEC_GALLEY						(THIRD_PARTY_EVENT_ID_MIN + 974)	// 974- GALLEY Switch [-600/700 only]				
#define	EVT_OH_ELEC_CAB_UTIL					(THIRD_PARTY_EVENT_ID_MIN + 5)		// 05 - CAB UTIL Switch	[-800/900 only]			
#define	EVT_OH_ELEC_IFE							(THIRD_PARTY_EVENT_ID_MIN + 6)		// 06 - IFE/PASS Switch	[-800/900 only]
#define	EVT_OH_ELEC_STBY_PWR_SWITCH				(THIRD_PARTY_EVENT_ID_MIN + 10)	    // 10 - STANDBY POWER Switch 
#define	EVT_OH_ELEC_STBY_PWR_GUARD				(THIRD_PARTY_EVENT_ID_MIN + 11)		// 11 - STANDBY POWER Switch Guard
#define	EVT_OH_ELEC_DISCONNECT_1_SWITCH			(THIRD_PARTY_EVENT_ID_MIN + 12)		// 12 - GEN DRIVE DISC Left Switch		
#define	EVT_OH_ELEC_DISCONNECT_1_GUARD			(THIRD_PARTY_EVENT_ID_MIN + 13)		// 13 - GEN DRIVE DISC Left Guard		
#define	EVT_OH_ELEC_DISCONNECT_2_SWITCH			(THIRD_PARTY_EVENT_ID_MIN + 14)		// 14 - GEN DRIVE DISC Right Switch	
#define	EVT_OH_ELEC_DISCONNECT_2_GUARD			(THIRD_PARTY_EVENT_ID_MIN + 15)		// 15 - GEN DRIVE DISC Right Guard 	
#define	EVT_OH_ELEC_GRD_PWR_SWITCH				(THIRD_PARTY_EVENT_ID_MIN + 17)		// 17 - GROUND POWER Switch
#define	EVT_OH_ELEC_BUS_TRANSFER_SWITCH			(THIRD_PARTY_EVENT_ID_MIN + 18)		// 18 - BUS TRANSFER Switch 	
#define	EVT_OH_ELEC_BUS_TRANSFER_GUARD			(THIRD_PARTY_EVENT_ID_MIN + 19)		// 19 - BUS TRANSFER Guard
#define	EVT_OH_ELEC_GEN1_SWITCH					(THIRD_PARTY_EVENT_ID_MIN + 27)		// 27 - GENERATOR Left Switch
#define	EVT_OH_ELEC_APU_GEN1_SWITCH				(THIRD_PARTY_EVENT_ID_MIN + 28)		// 28 - APU GENERATOR Left Switch
#define	EVT_OH_ELEC_APU_GEN2_SWITCH				(THIRD_PARTY_EVENT_ID_MIN + 29)		// 29 - APU GENERATOR RIGHT Switch
#define	EVT_OH_ELEC_GEN2_SWITCH					(THIRD_PARTY_EVENT_ID_MIN + 30)		// 30 - GENERATOR RIGHT Switch
#define	EVT_OH_ELEC_MAINT_SWITCH				(THIRD_PARTY_EVENT_ID_MIN + 93)		// 93 - ELEC MAINT Switch 

// Overhead - FUEL Panel
#define EVT_OH_FUEL_PUMP_1_AFT						(THIRD_PARTY_EVENT_ID_MIN + 37)		// 37 - FUEL PUMP LEFT AFT Switch 
#define EVT_OH_FUEL_PUMP_1_FORWARD					(THIRD_PARTY_EVENT_ID_MIN + 38)		// 38 - FUEL PUMP LEFT FWD Switch 
#define EVT_OH_FUEL_PUMP_2_FORWARD					(THIRD_PARTY_EVENT_ID_MIN + 39)		// 39 - FUEL PUMP RIGHT FWD Switch 
#define EVT_OH_FUEL_PUMP_2_AFT						(THIRD_PARTY_EVENT_ID_MIN + 40)		// 40 - FUEL PUMP RIGHT AFT Switch 
#define EVT_OH_FUEL_PUMP_L_CENTER					(THIRD_PARTY_EVENT_ID_MIN + 45)		// 45 - FUEL PUMP CENTER LEFT Switch 
#define EVT_OH_FUEL_PUMP_R_CENTER					(THIRD_PARTY_EVENT_ID_MIN + 46)		// 46 - FUEL PUMP CENTER LEFT Switch 
#define EVT_OH_FUEL_CROSSFEED						(THIRD_PARTY_EVENT_ID_MIN + 49)		// 49 - CROSSFEED Selector 

// Overhead - LIGHTS Panel
#define	EVT_OH_LAND_LIGHTS_GUARD					(THIRD_PARTY_EVENT_ID_MIN + 110)	
#define EVT_OH_LIGHTS_L_RETRACT						(THIRD_PARTY_EVENT_ID_MIN + 111)	
#define EVT_OH_LIGHTS_R_RETRACT						(THIRD_PARTY_EVENT_ID_MIN + 112)	
#define EVT_OH_LIGHTS_L_FIXED						(THIRD_PARTY_EVENT_ID_MIN + 113)	
#define EVT_OH_LIGHTS_R_FIXED						(THIRD_PARTY_EVENT_ID_MIN + 114)	
#define EVT_OH_LIGHTS_L_TURNOFF						(THIRD_PARTY_EVENT_ID_MIN + 115)	
#define EVT_OH_LIGHTS_R_TURNOFF						(THIRD_PARTY_EVENT_ID_MIN + 116)	
#define EVT_OH_LIGHTS_TAXI							(THIRD_PARTY_EVENT_ID_MIN + 117)	
#define EVT_OH_LIGHTS_APU_START						(THIRD_PARTY_EVENT_ID_MIN + 118)	
#define EVT_OH_LIGHTS_L_ENGINE_START				(THIRD_PARTY_EVENT_ID_MIN + 119)	
#define EVT_OH_LIGHTS_IGN_SEL						(THIRD_PARTY_EVENT_ID_MIN + 120)	
#define EVT_OH_LIGHTS_R_ENGINE_START				(THIRD_PARTY_EVENT_ID_MIN + 121)	
#define EVT_OH_LIGHTS_LOGO							(THIRD_PARTY_EVENT_ID_MIN + 122)	
#define EVT_OH_LIGHTS_POS_STROBE					(THIRD_PARTY_EVENT_ID_MIN + 123)	
#define EVT_OH_LIGHTS_ANT_COL						(THIRD_PARTY_EVENT_ID_MIN + 124)	
#define EVT_OH_LIGHTS_WING							(THIRD_PARTY_EVENT_ID_MIN + 125)	
#define EVT_OH_LIGHTS_WHEEL_WELL					(THIRD_PARTY_EVENT_ID_MIN + 126)	
#define EVT_OH_LIGHTS_COMPASS						(THIRD_PARTY_EVENT_ID_MIN + 982)	

// Overhead - Center Part
#define EVT_OH_CB_LIGHT_CONTROL						(THIRD_PARTY_EVENT_ID_MIN + 94)		// CIRCUIT BREAKER Light Control
#define EVT_OH_PANEL_LIGHT_CONTROL					(THIRD_PARTY_EVENT_ID_MIN + 95)		// PANEL Light Control Decrease
#define EVT_OH_EC_SUPPLY_SWITCH						(THIRD_PARTY_EVENT_ID_MIN + 96)		// EQUIPMENT COOLING SUPPLY Switch
#define EVT_OH_EC_EXHAUST_SWITCH					(THIRD_PARTY_EVENT_ID_MIN + 97)		// EQUIPMENT COOLING EXHAUST Switch
#define EVT_OH_EMER_EXIT_LIGHT_SWITCH				(THIRD_PARTY_EVENT_ID_MIN + 100)	// EMERGENCY EXIT LIGHTS Switch 
#define	EVT_OH_EMER_EXIT_LIGHT_GUARD				(THIRD_PARTY_EVENT_ID_MIN + 101)	// EMERGENCY EXIT LIGHTS Guard
#define EVT_OH_NO_SMOKING_LIGHT_SWITCH				(THIRD_PARTY_EVENT_ID_MIN + 103)	// NO SMOKING Switch
#define EVT_OH_FASTEN_BELTS_LIGHT_SWITCH			(THIRD_PARTY_EVENT_ID_MIN + 104)	// FASTEN BELTS Switch

// Overhead - Miscellaneous
#define EVT_OH_ATTND_CALL_SWITCH				(THIRD_PARTY_EVENT_ID_MIN + 105)	// ATTENDANT CALL Switch 
#define EVT_OH_GRND_CALL_SWITCH					(THIRD_PARTY_EVENT_ID_MIN + 106)	// GROUND CALL Switch 
#define EVT_OH_WIPER_LEFT_CONTROL				(THIRD_PARTY_EVENT_ID_MIN + 36)		// LEFT WIPER Control 
#define EVT_OH_WIPER_RIGHT_CONTROL				(THIRD_PARTY_EVENT_ID_MIN + 109)	// RIGHT WIPER Control

#define	EVT_OH_EFIS_HDG_REF_TOGGLE				(THIRD_PARTY_EVENT_ID_MIN + 6920)	// 692A - Heading Reference Switch Toggle - note: this is only for acft. with polar nav. option, e.g. BBJ


// Overhead - NAVDSP
#define EVT_OH_NAVDSP_DISPLAYS_SOURCE_SEL		(THIRD_PARTY_EVENT_ID_MIN + 58)	// DISPLAYS SOURCE Selector 
#define EVT_OH_NAVDSP_CONTROL_PANEL_SEL			(THIRD_PARTY_EVENT_ID_MIN + 59)	// CONTROL PANEL Select Switch 
#define EVT_OH_NAVDSP_FMC_SEL					(THIRD_PARTY_EVENT_ID_MIN + 60)	// FMC Source Select Switch
#define EVT_OH_NAVDSP_IRS_SEL					(THIRD_PARTY_EVENT_ID_MIN + 61)	// IRS Transfer Switch 
#define EVT_OH_NAVDSP_VHF_NAV_SEL				(THIRD_PARTY_EVENT_ID_MIN + 62)	// VHF NAV Transfer Switch 


// Overhead - FLTCTRL
#define EVT_OH_YAW_DAMPER				(THIRD_PARTY_EVENT_ID_MIN + 63)	// YAW DAMPER Switch 
#define	EVT_OH_ALT_FLAPS_MASTER_SWITCH	(THIRD_PARTY_EVENT_ID_MIN + 73)	// ALTERNATE FLAPS Master Switch 
#define	EVT_OH_ALT_FLAPS_MASTER_GUARD	(THIRD_PARTY_EVENT_ID_MIN + 74)	// ALTERNATE FLAPS Master Guard 
#define	EVT_OH_SPOILER_A_SWITCH			(THIRD_PARTY_EVENT_ID_MIN + 65)	// SPOILER A Switch 		
#define	EVT_OH_SPOILER_A_GUARD			(THIRD_PARTY_EVENT_ID_MIN + 66)	// SPOILER A Guard 
#define	EVT_OH_SPOILER_B_SWITCH			(THIRD_PARTY_EVENT_ID_MIN + 67)	// SPOILER B Switch 
#define	EVT_OH_SPOILER_B_GUARD			(THIRD_PARTY_EVENT_ID_MIN + 68)	// SPOILER B Guard 
#define	EVT_OH_ALT_FLAPS_POS_SWITCH		(THIRD_PARTY_EVENT_ID_MIN + 75)	// ALTERNATE FLAPS Position Switch
#define	EVT_OH_FCTL_A_SWITCH			(THIRD_PARTY_EVENT_ID_MIN + 78)	// FLIGHT CONTROL A Switch Decrease	
#define	EVT_OH_FCTL_A_GUARD				(THIRD_PARTY_EVENT_ID_MIN + 79)	// FLIGHT CONTROL A Guard 
#define	EVT_OH_FCTL_B_SWITCH			(THIRD_PARTY_EVENT_ID_MIN + 80)	// FLIGHT CONTROL B Switch Decrease
#define	EVT_OH_FCTL_B_GUARD				(THIRD_PARTY_EVENT_ID_MIN + 81)	// FLIGHT CONTROL B Guard 


// Overhead - CVR
#define EVT_OH_CVR_TEST					(THIRD_PARTY_EVENT_ID_MIN + 178)		
#define EVT_OH_CVR_ERASE				(THIRD_PARTY_EVENT_ID_MIN + 180)		

// Overhead - HYD
#define EVT_OH_HYD_ENG1					(THIRD_PARTY_EVENT_ID_MIN + 165)		
#define EVT_OH_HYD_ELEC2				(THIRD_PARTY_EVENT_ID_MIN + 167)		
#define EVT_OH_HYD_ELEC1				(THIRD_PARTY_EVENT_ID_MIN + 168)		
#define EVT_OH_HYD_ENG2					(THIRD_PARTY_EVENT_ID_MIN + 166)		

// Overhead - ICE
#define EVT_OH_ICE_WINDOW_HEAT_1		(THIRD_PARTY_EVENT_ID_MIN + 135)		
#define EVT_OH_ICE_WINDOW_HEAT_2		(THIRD_PARTY_EVENT_ID_MIN + 136)		
#define EVT_OH_ICE_WINDOW_HEAT_3		(THIRD_PARTY_EVENT_ID_MIN + 138)		
#define EVT_OH_ICE_WINDOW_HEAT_4		(THIRD_PARTY_EVENT_ID_MIN + 139)		
#define EVT_OH_ICE_WINDOW_HEAT_TEST		(THIRD_PARTY_EVENT_ID_MIN + 137)		
#define EVT_OH_ICE_PROBE_HEAT_1			(THIRD_PARTY_EVENT_ID_MIN + 140)		
#define EVT_OH_ICE_PROBE_HEAT_2			(THIRD_PARTY_EVENT_ID_MIN + 141)		
#define EVT_OH_ICE_TAT_TEST				(THIRD_PARTY_EVENT_ID_MIN + 142) // was used for "CAPT PITOT" annunciator light
#define EVT_OH_ICE_WING_ANTIICE			(THIRD_PARTY_EVENT_ID_MIN + 156)		
#define EVT_OH_ICE_ENGINE_ANTIICE_1		(THIRD_PARTY_EVENT_ID_MIN + 157)		
#define EVT_OH_ICE_ENGINE_ANTIICE_2		(THIRD_PARTY_EVENT_ID_MIN + 158)		

// Overhead - PNEU

// -600/700 panel only
#define EVT_OH_AIRCOND_TEMP_SOURCE_SELECTOR		(THIRD_PARTY_EVENT_ID_MIN + 187)	
#define EVT_OH_AIRCOND_TEMP_SELECTOR_CONT		(THIRD_PARTY_EVENT_ID_MIN + 191)		
#define EVT_OH_AIRCOND_TEMP_SELECTOR_CABIN		(THIRD_PARTY_EVENT_ID_MIN + 192)
#define EVT_OH_AIRCOND_TYPE_600_LAST			EVT_OH_AIRCOND_TEMP_SELECTOR_CABIN

// -800/900 panel only
#define EVT_OH_AIRCOND_TEMP_SOURCE_SELECTOR_800	(THIRD_PARTY_EVENT_ID_MIN + 313)
#define EVT_OH_AIRCOND_TEMP_SELECTOR_CONT_800	(THIRD_PARTY_EVENT_ID_MIN + 305)		
#define EVT_OH_AIRCOND_TEMP_SELECTOR_FWD_800	(THIRD_PARTY_EVENT_ID_MIN + 306)
#define EVT_OH_AIRCOND_TEMP_SELECTOR_AFT_800	(THIRD_PARTY_EVENT_ID_MIN + 307)
#define EVT_OH_AIRCOND_TRIM_AIR_SWITCH_800		(THIRD_PARTY_EVENT_ID_MIN + 311)

#define EVT_OH_BLEED_RECIRC_FAN_L_SWITCH		(THIRD_PARTY_EVENT_ID_MIN + 872)		
#define EVT_OH_BLEED_RECIRC_FAN_R_SWITCH		(THIRD_PARTY_EVENT_ID_MIN + 196)		
#define EVT_OH_BLEED_OVHT_TEST_BUTTON			(THIRD_PARTY_EVENT_ID_MIN + 199)		
#define EVT_OH_BLEED_PACK_L_SWITCH				(THIRD_PARTY_EVENT_ID_MIN + 200)		
#define EVT_OH_BLEED_PACK_R_SWITCH				(THIRD_PARTY_EVENT_ID_MIN + 201)		
#define EVT_OH_BLEED_ISOLATION_VALVE_SWITCH		(THIRD_PARTY_EVENT_ID_MIN + 202)		
#define EVT_OH_BLEED_TRIP_RESET_BUTTON			(THIRD_PARTY_EVENT_ID_MIN + 209)		
#define EVT_OH_BLEED_ENG_1_SWITCH				(THIRD_PARTY_EVENT_ID_MIN + 210)		
#define EVT_OH_BLEED_APU_SWITCH					(THIRD_PARTY_EVENT_ID_MIN + 211)		
#define EVT_OH_BLEED_ENG_2_SWITCH				(THIRD_PARTY_EVENT_ID_MIN + 212)		

// Overhead - Cabin Press
#define EVT_OH_PRESS_FLT_ALT_KNOB				(THIRD_PARTY_EVENT_ID_MIN + 218)
#define EVT_OH_PRESS_LAND_ALT_KNOB				(THIRD_PARTY_EVENT_ID_MIN + 220)
#define EVT_OH_PRESS_VALVE_SWITCH				(THIRD_PARTY_EVENT_ID_MIN + 222)
#define EVT_OH_PRESS_SELECTOR					(THIRD_PARTY_EVENT_ID_MIN + 223)

// Overhead - Cabin Alt
#define EVT_OH_CAB_ALT_HORN_CUTOUT_BUTTON		(THIRD_PARTY_EVENT_ID_MIN + 183)

// Aft Overhead - LE Devices
#define EVT_OH_LE_DEVICES_TEST_SWITCH	(THIRD_PARTY_EVENT_ID_MIN + 224)

// Aft Overhead - Service Interphone Switch
#define	EVT_OH_SERVICE_INTERPHONE_SWITCH (THIRD_PARTY_EVENT_ID_MIN + 257)

// Aft Overhead - Dome Switch
#define	EVT_OH_DOME_SWITCH				(THIRD_PARTY_EVENT_ID_MIN + 258)

// Aft Overhead - ISDU panel
#define EVT_ISDU_DSPL_SEL						(THIRD_PARTY_EVENT_ID_MIN + 229)	// ISDU DiSPLay SELector
#define EVT_ISDU_FIRST							EVT_ISDU_DSPL_SEL
#define EVT_ISDU_DSPL_SEL_BRT					(THIRD_PARTY_EVENT_ID_MIN + 230)	// ISDU DiSPLay SELector BRT (Brightness)
#define EVT_ISDU_SYS_DSPL						(THIRD_PARTY_EVENT_ID_MIN + 231)	// ISDU SYS DSPL  
#define EVT_ISDU_KBD_1							(THIRD_PARTY_EVENT_ID_MIN + 232)	// ISDU KEYBOARD 1
#define EVT_ISDU_KBD_2							(THIRD_PARTY_EVENT_ID_MIN + 233)	// ISDU KEYBOARD 2 or N
#define EVT_ISDU_KBD_3							(THIRD_PARTY_EVENT_ID_MIN + 234)	// ISDU KEYBOARD 3
#define EVT_ISDU_KBD_4							(THIRD_PARTY_EVENT_ID_MIN + 235)	// ISDU KEYBOARD 4 or W
#define EVT_ISDU_KBD_5							(THIRD_PARTY_EVENT_ID_MIN + 236)	// ISDU KEYBOARD 5 or H
#define EVT_ISDU_KBD_6							(THIRD_PARTY_EVENT_ID_MIN + 237)	// ISDU KEYBOARD 6 or E
#define EVT_ISDU_KBD_7							(THIRD_PARTY_EVENT_ID_MIN + 238)	// ISDU KEYBOARD 7
#define EVT_ISDU_KBD_8							(THIRD_PARTY_EVENT_ID_MIN + 239)	// ISDU KEYBOARD 8 or S
#define EVT_ISDU_KBD_9							(THIRD_PARTY_EVENT_ID_MIN + 240)	// ISDU KEYBOARD 9
#define EVT_ISDU_KBD_ENT						(THIRD_PARTY_EVENT_ID_MIN + 241)	// ISDU KEYBOARD ENTer
#define EVT_ISDU_KBD_0							(THIRD_PARTY_EVENT_ID_MIN + 243)	// ISDU KEYBOARD 0
#define EVT_ISDU_KBD_CLR						(THIRD_PARTY_EVENT_ID_MIN + 244)	// ISDU KEYBOARD CLR
#define EVT_IRU_MSU_LEFT						(THIRD_PARTY_EVENT_ID_MIN + 255)	// LEFT IRS Mode Selector Unit 
#define EVT_IRU_MSU_RIGHT						(THIRD_PARTY_EVENT_ID_MIN + 256)	// RIGHT IRS Mode Selector Unit
#define EVT_ISDU_LAST							EVT_IRU_MSU_RIGHT

#define EVT_WLAN_SWITCH							(THIRD_PARTY_EVENT_ID_MIN + 888)	
#define EVT_WLAN_GUARD							(THIRD_PARTY_EVENT_ID_MIN + 889)	

// Aft Overhead - Engine control
#define	EVT_OH_EEC_L_GUARD						(THIRD_PARTY_EVENT_ID_MIN + 267)
#define	EVT_OH_EEC_L_SWITCH						(THIRD_PARTY_EVENT_ID_MIN + 268)
#define	EVT_OH_EEC_R_GUARD						(THIRD_PARTY_EVENT_ID_MIN + 270)
#define	EVT_OH_EEC_R_SWITCH						(THIRD_PARTY_EVENT_ID_MIN + 271)

// Aft Overhead - Oxygen
#define	EVT_OH_OXY_PASS_SWITCH					(THIRD_PARTY_EVENT_ID_MIN + 264)
#define	EVT_OH_OXY_PASS_GUARD					(THIRD_PARTY_EVENT_ID_MIN + 265)
#define	EVT_OH_OXY_TEST_RESET_SWITCH_L			(THIRD_PARTY_EVENT_ID_MIN + 983)
#define	EVT_OH_OXY_TEST_RESET_SWITCH_R			(THIRD_PARTY_EVENT_ID_MIN + 9832)
#define	EVT_OH_OXY_RED_BUTTON_L					(THIRD_PARTY_EVENT_ID_MIN + 9831)
#define	EVT_OH_OXY_RED_BUTTON_R					(THIRD_PARTY_EVENT_ID_MIN + 9833)

// Aft Overhead - Flt Rec & Warning
#define	EVT_OH_FLTREC_SWITCH					(THIRD_PARTY_EVENT_ID_MIN + 298)
#define	EVT_OH_FLTREC_GUARD						(THIRD_PARTY_EVENT_ID_MIN + 299)
#define	EVT_OH_WARNING_TEST_MACH_IAS_1_PUSH		(THIRD_PARTY_EVENT_ID_MIN + 301)
#define	EVT_OH_WARNING_TEST_MACH_IAS_2_PUSH		(THIRD_PARTY_EVENT_ID_MIN + 302)
#define	EVT_OH_WARNING_TEST_STALL_1_PUSH		(THIRD_PARTY_EVENT_ID_MIN + 303)
#define	EVT_OH_WARNING_TEST_STALL_2_PUSH		(THIRD_PARTY_EVENT_ID_MIN + 304)

// Overhead - test gauge
#define	EVT_OH_TRIM_AIR_SWITCH_TOGGLE			(THIRD_PARTY_EVENT_ID_MIN + 15200)	// user clicks a switch
#define	EVT_OH_WING_BODY_OVERHEAT_TEST_PUSH		(THIRD_PARTY_EVENT_ID_MIN + 15201)	// user pushes a pushbutton 


// Integrated Standby Flight Display - ISFD
#define	EVT_ISFD_APP							(THIRD_PARTY_EVENT_ID_MIN + 987)	// 	
#define	EVT_ISFD_HP_IN							(THIRD_PARTY_EVENT_ID_MIN + 986)	//	
#define	EVT_ISFD_PLUS							(THIRD_PARTY_EVENT_ID_MIN + 988)	//	
#define	EVT_ISFD_MINUS							(THIRD_PARTY_EVENT_ID_MIN + 989)	//	
#define	EVT_ISFD_ATT_RST						(THIRD_PARTY_EVENT_ID_MIN + 990)	//	
#define	EVT_ISFD_BARO							(THIRD_PARTY_EVENT_ID_MIN + 991)	//	
#define	EVT_ISFD_BARO_PUSH						(THIRD_PARTY_EVENT_ID_MIN + 993)	//	

// Analog standby instruments
#define	EVT_STANDBY_ADI_APPR_MODE				(THIRD_PARTY_EVENT_ID_MIN + 474)	// 	
#define	EVT_STANDBY_ADI_CAGE_KNOB				(THIRD_PARTY_EVENT_ID_MIN + 476)	// 	
#define	EVT_STANDBY_ALT_BARO_KNOB				(THIRD_PARTY_EVENT_ID_MIN + 492)	// 	
#define	EVT_RMI_LEFT_SELECTOR					(THIRD_PARTY_EVENT_ID_MIN + 497)	// 	
#define	EVT_RMI_RIGHT_SELECTOR					(THIRD_PARTY_EVENT_ID_MIN + 498)	// 	


// MCP
//
#define	EVT_MCP_COURSE_SELECTOR_L				(THIRD_PARTY_EVENT_ID_MIN + 376)	
#define	EVT_MCP_FD_SWITCH_L						(THIRD_PARTY_EVENT_ID_MIN + 378)	
#define	EVT_MCP_AT_ARM_SWITCH					(THIRD_PARTY_EVENT_ID_MIN + 380)	
#define	EVT_MCP_N1_SWITCH						(THIRD_PARTY_EVENT_ID_MIN + 381)	
#define	EVT_MCP_SPEED_SWITCH					(THIRD_PARTY_EVENT_ID_MIN + 382)	
#define	EVT_MCP_CO_SWITCH						(THIRD_PARTY_EVENT_ID_MIN + 383)	
#define	EVT_MCP_SPEED_SELECTOR					(THIRD_PARTY_EVENT_ID_MIN + 384)	
#define	EVT_MCP_VNAV_SWITCH						(THIRD_PARTY_EVENT_ID_MIN + 386)	
#define	EVT_MCP_SPD_INTV_SWITCH					(THIRD_PARTY_EVENT_ID_MIN + 387)
#define	EVT_MCP_BANK_ANGLE_SELECTOR				(THIRD_PARTY_EVENT_ID_MIN + 389)	
#define	EVT_MCP_HEADING_SELECTOR				(THIRD_PARTY_EVENT_ID_MIN + 390)
#define	EVT_MCP_LVL_CHG_SWITCH					(THIRD_PARTY_EVENT_ID_MIN + 391)	
#define	EVT_MCP_HDG_SEL_SWITCH					(THIRD_PARTY_EVENT_ID_MIN + 392)	
#define	EVT_MCP_APP_SWITCH						(THIRD_PARTY_EVENT_ID_MIN + 393)	
#define	EVT_MCP_ALT_HOLD_SWITCH					(THIRD_PARTY_EVENT_ID_MIN + 394)	
#define	EVT_MCP_VS_SWITCH						(THIRD_PARTY_EVENT_ID_MIN + 395)	
#define	EVT_MCP_VOR_LOC_SWITCH					(THIRD_PARTY_EVENT_ID_MIN + 396)	
#define	EVT_MCP_LNAV_SWITCH						(THIRD_PARTY_EVENT_ID_MIN + 397)
#define	EVT_MCP_ALTITUDE_SELECTOR				(THIRD_PARTY_EVENT_ID_MIN + 400)	
#define	EVT_MCP_VS_SELECTOR						(THIRD_PARTY_EVENT_ID_MIN + 401)
#define	EVT_MCP_CMD_A_SWITCH					(THIRD_PARTY_EVENT_ID_MIN + 402)
#define	EVT_MCP_CMD_B_SWITCH					(THIRD_PARTY_EVENT_ID_MIN + 403)
#define	EVT_MCP_CWS_A_SWITCH					(THIRD_PARTY_EVENT_ID_MIN + 404)
#define	EVT_MCP_CWS_B_SWITCH					(THIRD_PARTY_EVENT_ID_MIN + 405)
#define	EVT_MCP_DISENGAGE_BAR					(THIRD_PARTY_EVENT_ID_MIN + 406)
#define	EVT_MCP_FD_SWITCH_R						(THIRD_PARTY_EVENT_ID_MIN + 407)	
#define	EVT_MCP_COURSE_SELECTOR_R				(THIRD_PARTY_EVENT_ID_MIN + 409)	
#define	EVT_MCP_ALT_INTV_SWITCH					(THIRD_PARTY_EVENT_ID_MIN + 885)	

// EFIS Captain control panel
//
// NOTE: Order in captain and F/O sides must be same, and events in both sides must increase by 1
//
#define	EVT_EFIS_CPT_MINIMUMS					(THIRD_PARTY_EVENT_ID_MIN + 355)
#define EVT_EFIS_CPT_FIRST						EVT_EFIS_CPT_MINIMUMS
#define	EVT_EFIS_CPT_MINIMUMS_RADIO_BARO		(THIRD_PARTY_EVENT_ID_MIN + 356)	
#define	EVT_EFIS_CPT_MINIMUMS_RST				(THIRD_PARTY_EVENT_ID_MIN + 357)	
#define	EVT_EFIS_CPT_VOR_ADF_SELECTOR_L			(THIRD_PARTY_EVENT_ID_MIN + 358)	
#define	EVT_EFIS_CPT_MODE						(THIRD_PARTY_EVENT_ID_MIN + 359)	
#define	EVT_EFIS_CPT_MODE_CTR					(THIRD_PARTY_EVENT_ID_MIN + 360)	
#define	EVT_EFIS_CPT_RANGE						(THIRD_PARTY_EVENT_ID_MIN + 361)	
#define	EVT_EFIS_CPT_RANGE_TFC					(THIRD_PARTY_EVENT_ID_MIN + 362)	
#define	EVT_EFIS_CPT_FPV						(THIRD_PARTY_EVENT_ID_MIN + 363)	
#define	EVT_EFIS_CPT_MTRS						(THIRD_PARTY_EVENT_ID_MIN + 364)	
#define	EVT_EFIS_CPT_BARO						(THIRD_PARTY_EVENT_ID_MIN + 365)	
#define	EVT_EFIS_CPT_BARO_IN_HPA				(THIRD_PARTY_EVENT_ID_MIN + 366)	
#define	EVT_EFIS_CPT_BARO_STD					(THIRD_PARTY_EVENT_ID_MIN + 367)			
#define	EVT_EFIS_CPT_VOR_ADF_SELECTOR_R			(THIRD_PARTY_EVENT_ID_MIN + 368)	
#define	EVT_EFIS_CPT_WXR						(THIRD_PARTY_EVENT_ID_MIN + 369)	
#define	EVT_EFIS_CPT_STA						(THIRD_PARTY_EVENT_ID_MIN + 370)	
#define	EVT_EFIS_CPT_WPT						(THIRD_PARTY_EVENT_ID_MIN + 371)	
#define	EVT_EFIS_CPT_ARPT						(THIRD_PARTY_EVENT_ID_MIN + 372)	
#define	EVT_EFIS_CPT_DATA						(THIRD_PARTY_EVENT_ID_MIN + 373)	
#define	EVT_EFIS_CPT_POS						(THIRD_PARTY_EVENT_ID_MIN + 374)	
#define	EVT_EFIS_CPT_TERR						(THIRD_PARTY_EVENT_ID_MIN + 375)	
#define EVT_EFIS_CPT_LAST						EVT_EFIS_CPT_TERR

// EFIS F/O control panels
//
#define	EVT_EFIS_FO_MINIMUMS					(THIRD_PARTY_EVENT_ID_MIN + 411)	
#define EVT_EFIS_FO_FIRST						EVT_EFIS_FO_MINIMUMS
#define	EVT_EFIS_FO_MINIMUMS_RADIO_BARO			(THIRD_PARTY_EVENT_ID_MIN + 412)	
#define	EVT_EFIS_FO_MINIMUMS_RST				(THIRD_PARTY_EVENT_ID_MIN + 413)	
#define	EVT_EFIS_FO_VOR_ADF_SELECTOR_L			(THIRD_PARTY_EVENT_ID_MIN + 414)	
#define	EVT_EFIS_FO_MODE						(THIRD_PARTY_EVENT_ID_MIN + 415)	
#define	EVT_EFIS_FO_MODE_CTR					(THIRD_PARTY_EVENT_ID_MIN + 416)	
#define	EVT_EFIS_FO_RANGE						(THIRD_PARTY_EVENT_ID_MIN + 417)	
#define	EVT_EFIS_FO_RANGE_TFC					(THIRD_PARTY_EVENT_ID_MIN + 418)	
#define	EVT_EFIS_FO_FPV							(THIRD_PARTY_EVENT_ID_MIN + 419)	
#define	EVT_EFIS_FO_MTRS						(THIRD_PARTY_EVENT_ID_MIN + 420)	
#define	EVT_EFIS_FO_BARO						(THIRD_PARTY_EVENT_ID_MIN + 421)	
#define	EVT_EFIS_FO_BARO_IN_HPA					(THIRD_PARTY_EVENT_ID_MIN + 422)	
#define	EVT_EFIS_FO_BARO_STD					(THIRD_PARTY_EVENT_ID_MIN + 423)			
#define	EVT_EFIS_FO_VOR_ADF_SELECTOR_R			(THIRD_PARTY_EVENT_ID_MIN + 424)	
#define	EVT_EFIS_FO_WXR							(THIRD_PARTY_EVENT_ID_MIN + 425)	
#define	EVT_EFIS_FO_STA							(THIRD_PARTY_EVENT_ID_MIN + 426)	
#define	EVT_EFIS_FO_WPT							(THIRD_PARTY_EVENT_ID_MIN + 427)	
#define	EVT_EFIS_FO_ARPT						(THIRD_PARTY_EVENT_ID_MIN + 428)	
#define	EVT_EFIS_FO_DATA						(THIRD_PARTY_EVENT_ID_MIN + 429)	
#define	EVT_EFIS_FO_POS							(THIRD_PARTY_EVENT_ID_MIN + 430)	
#define	EVT_EFIS_FO_TERR						(THIRD_PARTY_EVENT_ID_MIN + 431)
#define EVT_EFIS_FO_LAST						EVT_EFIS_FO_TERR


// Display select panels
// 
#define	EVT_DSP_CPT_BELOW_GS_INHIBIT_SWITCH		(THIRD_PARTY_EVENT_ID_MIN + 327)	// CAPT Side BELOW GS INHIBIT Pushbutton
#define	EVT_DSP_CPT_MAIN_DU_SELECTOR			(THIRD_PARTY_EVENT_ID_MIN + 335)	// CAPT side MAIN PANEL DISPLAY UNITS (MAIN PANEL DUs) Selector 
#define	EVT_DSP_CPT_LOWER_DU_SELECTOR			(THIRD_PARTY_EVENT_ID_MIN + 336)	// CAPT side LOWER DISPLAY UNIT (LOWER DU) Selector 
#define	EVT_DSP_CPT_DISENGAGE_TEST_SWITCH		(THIRD_PARTY_EVENT_ID_MIN + 342)	// CAPT side DISENGAGE LIGHTS TEST switch
#define	EVT_DSP_CPT_AP_RESET_SWITCH				(THIRD_PARTY_EVENT_ID_MIN + 339)	// CAPT Side AP RESET Pushbutton
#define	EVT_DSP_CPT_AT_RESET_SWITCH				(THIRD_PARTY_EVENT_ID_MIN + 340)	// CAPT Side AT RESET Pushbutton
#define	EVT_DSP_CPT_FMC_RESET_SWITCH			(THIRD_PARTY_EVENT_ID_MIN + 341)	// CAPT Side FMC RESET Pushbutton
#define	EVT_DSP_CPT_MASTER_LIGHTS_SWITCH		(THIRD_PARTY_EVENT_ID_MIN + 346)	// MASTER LIGHTS & TEST switch
#define EVT_DSP_CPT_LAST						EVT_DSP_CPT_MASTER_LIGHTS_SWITCH	// Keep this the last of CAPT side DSP panel items and before the F/O DSP panel items start

#define	EVT_DSP_FO_MAIN_DU_SELECTOR				(THIRD_PARTY_EVENT_ID_MIN + 440)	// FO side MAIN PANEL DISPLAY UNITS (MAIN PANEL DUs) Selector 
#define	EVT_DSP_FO_LOWER_DU_SELECTOR			(THIRD_PARTY_EVENT_ID_MIN + 441)	// FO side LOWER DISPLAY UNIT (LOWER DU) Selector 
#define	EVT_DSP_FO_DISENGAGE_TEST_SWITCH		(THIRD_PARTY_EVENT_ID_MIN + 442)	// FO side DISENGAGE LIGHTS TEST switch
#define	EVT_DSP_FO_FMC_RESET_SWITCH				(THIRD_PARTY_EVENT_ID_MIN + 443)	// FO Side FMC RESET Pushbutton
#define	EVT_DSP_FO_AT_RESET_SWITCH				(THIRD_PARTY_EVENT_ID_MIN + 444)	// FO Side AT RESET Pushbutton
#define	EVT_DSP_FO_AP_RESET_SWITCH				(THIRD_PARTY_EVENT_ID_MIN + 445)	// FO Side AP RESET Pushbutton
#define	EVT_DSP_FO_BELOW_GS_INHIBIT_SWITCH		(THIRD_PARTY_EVENT_ID_MIN + 446)	// FO Side BELOW GS INHIBIT Pushbutton


// Main panel misc
#define	EVT_MPM_AUTOBRAKE_SELECTOR				(THIRD_PARTY_EVENT_ID_MIN + 460)	
#define	EVT_MPM_MFD_SYS_BUTTON					(THIRD_PARTY_EVENT_ID_MIN + 462)	
#define	EVT_MPM_MFD_ENG_BUTTON					(THIRD_PARTY_EVENT_ID_MIN + 463)	
#define	EVT_MPM_MFD_C_R_BUTTON					(THIRD_PARTY_EVENT_ID_MIN + 4621)	
#define	EVT_MPM_SPEED_REFERENCE_SELECTOR		(THIRD_PARTY_EVENT_ID_MIN + 464)	
#define	EVT_MPM_SPEED_REFERENCE_CONTROL			(THIRD_PARTY_EVENT_ID_MIN + 465)	
#define	EVT_MPM_N1SET_SELECTOR					(THIRD_PARTY_EVENT_ID_MIN + 466)	
#define	EVT_MPM_N1SET_CONTROL					(THIRD_PARTY_EVENT_ID_MIN + 467)	
#define	EVT_MPM_FUEL_FLOW_SWITCH				(THIRD_PARTY_EVENT_ID_MIN + 468)	

// Gear panel
#define	EVT_GEAR_LEVER							(THIRD_PARTY_EVENT_ID_MIN + 455)
#define	EVT_GEAR_LEVER_OFF						(THIRD_PARTY_EVENT_ID_MIN + 4551)
#define	EVT_GEAR_LEVER_UNLOCK					(THIRD_PARTY_EVENT_ID_MIN + 4552)

// Nose Wheel Steering
#define	EVT_NOSE_WHEEL_STEERING_SWITCH			(THIRD_PARTY_EVENT_ID_MIN + 325)	
#define	EVT_NOSE_WHEEL_STEERING_SWITCH_GUARD	(THIRD_PARTY_EVENT_ID_MIN + 326)	
#define	EVT_TILLER								(THIRD_PARTY_EVENT_ID_MIN + 975)	

// Warning/caution
#define EVT_FIRE_WARN_LIGHT_LEFT				(THIRD_PARTY_EVENT_ID_MIN + 347)	// 347 - Master Fire Warning (FIRE WARN) Light Left Switch Toggle
#define EVT_MASTER_CAUTION_LIGHT_LEFT			(THIRD_PARTY_EVENT_ID_MIN + 348)	// 348 - MASTER CAUTION Light Left Switch Toggle

#define EVT_FIRE_WARN_LIGHT_RIGHT				(THIRD_PARTY_EVENT_ID_MIN + 439)	// 
#define EVT_MASTER_CAUTION_LIGHT_RIGHT			(THIRD_PARTY_EVENT_ID_MIN + 438)	// 

#define EVT_SYSTEM_ANNUNCIATOR_PANEL_LEFT		(THIRD_PARTY_EVENT_ID_MIN + 349)	// 
#define EVT_SYSTEM_ANNUNCIATOR_PANEL_RIGHT		(THIRD_PARTY_EVENT_ID_MIN + 437)	// 

// Lower Main
#define EVT_LWRMAIN_CAPT_MAIN_PANEL_BRT			(THIRD_PARTY_EVENT_ID_MIN + 328)	
#define EVT_LWRMAIN_CAPT_OUTBD_DU_BRT			(THIRD_PARTY_EVENT_ID_MIN + 329)	
#define EVT_LWRMAIN_CAPT_INBD_DU_BRT			(THIRD_PARTY_EVENT_ID_MIN + 330)
#define EVT_LWRMAIN_CAPT_INBD_DU_INNER_BRT		(THIRD_PARTY_EVENT_ID_MIN + 331)
#define EVT_LWRMAIN_CAPT_LOWER_DU_BRT			(THIRD_PARTY_EVENT_ID_MIN + 332)	
#define EVT_LWRMAIN_CAPT_LOWER_DU_INNER_BRT		(THIRD_PARTY_EVENT_ID_MIN + 333)
#define EVT_LWRMAIN_CAPT_UPPER_DU_BRT			(THIRD_PARTY_EVENT_ID_MIN + 334)
#define EVT_LWRMAIN_CAPT_BACKGROUND_BRT			(THIRD_PARTY_EVENT_ID_MIN + 337)	
#define EVT_LWRMAIN_CAPT_AFDS_BRT				(THIRD_PARTY_EVENT_ID_MIN + 338)

#define EVT_LWRMAIN_FO_INBD_DU_BRT				(THIRD_PARTY_EVENT_ID_MIN + 507)
#define EVT_LWRMAIN_FO_INBD_DU_INNER_BRT		(THIRD_PARTY_EVENT_ID_MIN + 508)
#define EVT_LWRMAIN_FO_MAIN_PANEL_BRT			(THIRD_PARTY_EVENT_ID_MIN + 510)	
#define EVT_LWRMAIN_FO_OUTBD_DU_BRT				(THIRD_PARTY_EVENT_ID_MIN + 509)	


// GPWS
#define EVT_GPWS_SYS_TEST_BTN					(THIRD_PARTY_EVENT_ID_MIN + 500)	
#define EVT_GPWS_FLAP_INHIBIT_SWITCH			(THIRD_PARTY_EVENT_ID_MIN + 501)	
#define EVT_GPWS_FLAP_INHIBIT_GUARD				(THIRD_PARTY_EVENT_ID_MIN + 502)	
#define EVT_GPWS_GEAR_INHIBIT_SWITCH			(THIRD_PARTY_EVENT_ID_MIN + 503)	
#define EVT_GPWS_GEAR_INHIBIT_GUARD				(THIRD_PARTY_EVENT_ID_MIN + 504)	
#define EVT_GPWS_TERR_INHIBIT_SWITCH			(THIRD_PARTY_EVENT_ID_MIN + 505)	
#define EVT_GPWS_TERR_INHIBIT_GUARD				(THIRD_PARTY_EVENT_ID_MIN + 506)	

// Chronometers
#define EVT_CHRONO_L_CHR						(THIRD_PARTY_EVENT_ID_MIN + 314)	
#define EVT_CHRONO_L_TIME_DATE					(THIRD_PARTY_EVENT_ID_MIN + 315)	
#define EVT_CHRONO_L_SET						(THIRD_PARTY_EVENT_ID_MIN + 316)	
#define EVT_CHRONO_L_PLUS						(THIRD_PARTY_EVENT_ID_MIN + 317)	
#define EVT_CHRONO_L_MINUS						(THIRD_PARTY_EVENT_ID_MIN + 318)	
#define EVT_CHRONO_L_RESET						(THIRD_PARTY_EVENT_ID_MIN + 320)	
#define EVT_CHRONO_L_ET							(THIRD_PARTY_EVENT_ID_MIN + 321)	
#define EVT_CHRONO_R_CHR						(THIRD_PARTY_EVENT_ID_MIN + 523)	
#define EVT_CHRONO_R_TIME_DATE					(THIRD_PARTY_EVENT_ID_MIN + 524)	
#define EVT_CHRONO_R_SET						(THIRD_PARTY_EVENT_ID_MIN + 525)	
#define EVT_CHRONO_R_PLUS						(THIRD_PARTY_EVENT_ID_MIN + 526)	
#define EVT_CHRONO_R_MINUS						(THIRD_PARTY_EVENT_ID_MIN + 527)	
#define EVT_CHRONO_R_RESET						(THIRD_PARTY_EVENT_ID_MIN + 529)	
#define EVT_CHRONO_R_ET							(THIRD_PARTY_EVENT_ID_MIN + 530)	
#define EVT_CLOCK_L								(THIRD_PARTY_EVENT_ID_MIN + 890)	
#define EVT_CLOCK_R								(THIRD_PARTY_EVENT_ID_MIN + 893)	

// Control Stand
//
#define EVT_CONTROL_STAND_TRIM_WHEEL					(THIRD_PARTY_EVENT_ID_MIN + 678)
#define EVT_CONTROL_STAND_SPEED_BRAKE_LEVER				(THIRD_PARTY_EVENT_ID_MIN + 679)
#define EVT_CONTROL_STAND_SPEED_BRAKE_LEVER_DOWN		(THIRD_PARTY_EVENT_ID_MIN + 6791)
#define EVT_CONTROL_STAND_SPEED_BRAKE_LEVER_ARM			(THIRD_PARTY_EVENT_ID_MIN + 6792)
#define EVT_CONTROL_STAND_SPEED_BRAKE_LEVER_50PCT		(THIRD_PARTY_EVENT_ID_MIN + 6793)
#define EVT_CONTROL_STAND_SPEED_BRAKE_LEVER_FLT_DET		(THIRD_PARTY_EVENT_ID_MIN + 6794)
#define EVT_CONTROL_STAND_SPEED_BRAKE_LEVER_UP			(THIRD_PARTY_EVENT_ID_MIN + 6795)
#define EVT_CONTROL_STAND_REV_THRUST1_LEVER				(THIRD_PARTY_EVENT_ID_MIN + 680)
#define EVT_CONTROL_STAND_REV_THRUST2_LEVER				(THIRD_PARTY_EVENT_ID_MIN + 681)
#define EVT_CONTROL_STAND_FWD_THRUST1_LEVER				(THIRD_PARTY_EVENT_ID_MIN + 683)
#define EVT_CONTROL_STAND_FWD_THRUST2_LEVER				(THIRD_PARTY_EVENT_ID_MIN + 686)
#define EVT_CONTROL_STAND_TOGA1_SWITCH					(THIRD_PARTY_EVENT_ID_MIN + 684)
#define EVT_CONTROL_STAND_TOGA2_SWITCH					(THIRD_PARTY_EVENT_ID_MIN + 687)
#define EVT_CONTROL_STAND_AT1_DISENGAGE_SWITCH			(THIRD_PARTY_EVENT_ID_MIN + 682)
#define EVT_CONTROL_STAND_AT2_DISENGAGE_SWITCH			(THIRD_PARTY_EVENT_ID_MIN + 685)
#define EVT_CONTROL_STAND_ENG1_START_LEVER				(THIRD_PARTY_EVENT_ID_MIN + 688)	
#define EVT_CONTROL_STAND_ENG2_START_LEVER				(THIRD_PARTY_EVENT_ID_MIN + 689)	
#define EVT_CONTROL_STAND_PARK_BRAKE_LEVER				(THIRD_PARTY_EVENT_ID_MIN + 693)
#define EVT_CONTROL_STAND_STABTRIM_ELEC_SWITCH			(THIRD_PARTY_EVENT_ID_MIN + 709)	
#define EVT_CONTROL_STAND_STABTRIM_ELEC_SWITCH_GUARD	(THIRD_PARTY_EVENT_ID_MIN + 710)	
#define EVT_CONTROL_STAND_STABTRIM_AP_SWITCH			(THIRD_PARTY_EVENT_ID_MIN + 711)	
#define EVT_CONTROL_STAND_STABTRIM_AP_SWITCH_GUARD		(THIRD_PARTY_EVENT_ID_MIN + 712)	
#define EVT_CONTROL_STAND_HORN_CUTOUT_SWITCH			(THIRD_PARTY_EVENT_ID_MIN + 713)
#define EVT_CONTROL_STAND_FLAPS_LEVER					(THIRD_PARTY_EVENT_ID_MIN + 714)
#define EVT_CONTROL_STAND_FLAPS_LEVER_0					(THIRD_PARTY_EVENT_ID_MIN + 7141)
#define EVT_CONTROL_STAND_FLAPS_LEVER_1					(THIRD_PARTY_EVENT_ID_MIN + 7142)
#define EVT_CONTROL_STAND_FLAPS_LEVER_2					(THIRD_PARTY_EVENT_ID_MIN + 7143)
#define EVT_CONTROL_STAND_FLAPS_LEVER_5					(THIRD_PARTY_EVENT_ID_MIN + 7144)
#define EVT_CONTROL_STAND_FLAPS_LEVER_10				(THIRD_PARTY_EVENT_ID_MIN + 7145)
#define EVT_CONTROL_STAND_FLAPS_LEVER_15				(THIRD_PARTY_EVENT_ID_MIN + 7146)
#define EVT_CONTROL_STAND_FLAPS_LEVER_25				(THIRD_PARTY_EVENT_ID_MIN + 7147)
#define EVT_CONTROL_STAND_FLAPS_LEVER_30				(THIRD_PARTY_EVENT_ID_MIN + 7148)
#define EVT_CONTROL_STAND_FLAPS_LEVER_40				(THIRD_PARTY_EVENT_ID_MIN + 7149)

// FLT  DK DOOR Panel
#define EVT_FLT_DK_DOOR_KNOB			(THIRD_PARTY_EVENT_ID_MIN + 834)
#define EVT_STAB_TRIM_OVRD_SWITCH_GUARD	(THIRD_PARTY_EVENT_ID_MIN + 830)
#define EVT_STAB_TRIM_OVRD_SWITCH		(THIRD_PARTY_EVENT_ID_MIN + 831)


// VHF Panels
#define EVT_NAV1_TRANSFER_SWITCH		(THIRD_PARTY_EVENT_ID_MIN + 729)
#define EVT_NAV1_FIRST					EVT_NAV1_TRANSFER_SWITCH
#define EVT_NAV1_TEST_SWICTH			(THIRD_PARTY_EVENT_ID_MIN + 731)
#define EVT_NAV1_INNER_SELECTOR			(THIRD_PARTY_EVENT_ID_MIN + 732)
#define EVT_NAV1_OUTER_SELECTOR			(THIRD_PARTY_EVENT_ID_MIN + 733)
#define EVT_NAV1_LAST					EVT_NAV1_OUTER_SELECTOR

#define EVT_NAV2_TRANSFER_SWITCH		(THIRD_PARTY_EVENT_ID_MIN + 845)
#define EVT_NAV2_FIRST					EVT_NAV2_TRANSFER_SWITCH
#define EVT_NAV2_TEST_SWICTH			(THIRD_PARTY_EVENT_ID_MIN + 847)
#define EVT_NAV2_OUTER_SELECTOR			(THIRD_PARTY_EVENT_ID_MIN + 848)
#define EVT_NAV2_INNER_SELECTOR			(THIRD_PARTY_EVENT_ID_MIN + 849)
#define EVT_NAV2_LAST					EVT_NAV2_INNER_SELECTOR

// ADF Panel
#define EVT_ADF_MODE_SELECTOR			(THIRD_PARTY_EVENT_ID_MIN + 818)
#define EVT_ADF_TONE_SWITCH				(THIRD_PARTY_EVENT_ID_MIN + 820)
#define EVT_ADF_INNER_SELECTOR			(THIRD_PARTY_EVENT_ID_MIN + 822)
#define EVT_ADF_MIDDLE_SELECTOR			(THIRD_PARTY_EVENT_ID_MIN + 823)
#define EVT_ADF_OUTER_SELECTOR			(THIRD_PARTY_EVENT_ID_MIN + 824)
#define EVT_ADF_TRANSFER_SWITCH			(THIRD_PARTY_EVENT_ID_MIN + 827)

// SELCAL Panel
#define EVT_SELCAL_VHF1_SWITCH			(THIRD_PARTY_EVENT_ID_MIN + 812)
#define EVT_SELCAL_VHF2_SWITCH			(THIRD_PARTY_EVENT_ID_MIN + 813)
#define EVT_SELCAL_VHF3_SWITCH			(THIRD_PARTY_EVENT_ID_MIN + 814)
#define EVT_SELCAL_HF1_SWITCH			(THIRD_PARTY_EVENT_ID_MIN + 937)
#define EVT_SELCAL_HF2_SWITCH			(THIRD_PARTY_EVENT_ID_MIN + 938)

// COMM Panels
#define EVT_COM1_TRANSFER_SWITCH		(THIRD_PARTY_EVENT_ID_MIN + 721)
#define EVT_COM1_START_RANGE1			EVT_COM1_TRANSFER_SWITCH
#define EVT_COM1_HF_SENSOR_KNOB			(THIRD_PARTY_EVENT_ID_MIN + 724)
#define EVT_COM1_TEST_SWICTH			(THIRD_PARTY_EVENT_ID_MIN + 725)
#define EVT_COM1_OUTER_SELECTOR			(THIRD_PARTY_EVENT_ID_MIN + 726)
#define EVT_COM1_INNER_SELECTOR			(THIRD_PARTY_EVENT_ID_MIN + 727)
#define EVT_COM1_END_RANGE1				EVT_COM1_INNER_SELECTOR
#define EVT_COM1_PNL_OFF_SWITCH			(THIRD_PARTY_EVENT_ID_MIN + 903)
#define EVT_COM1_START_RANGE2			EVT_COM1_PNL_OFF_SWITCH
#define EVT_COM1_VHF1_SWITCH			(THIRD_PARTY_EVENT_ID_MIN + 904)
#define EVT_COM1_VHF2_SWITCH			(THIRD_PARTY_EVENT_ID_MIN + 906)
#define EVT_COM1_VHF3_SWITCH			(THIRD_PARTY_EVENT_ID_MIN + 908)
#define EVT_COM1_HF1_SWITCH				(THIRD_PARTY_EVENT_ID_MIN + 910)
#define EVT_COM1_AM_SWITCH				(THIRD_PARTY_EVENT_ID_MIN + 912)
#define EVT_COM1_HF2_SWITCH				(THIRD_PARTY_EVENT_ID_MIN + 914)
#define EVT_COM1_END_RANGE2				EVT_COM1_HF2_SWITCH


#define EVT_COM2_TRANSFER_SWITCH		(THIRD_PARTY_EVENT_ID_MIN + 837)
#define EVT_COM2_START_RANGE1			EVT_COM2_TRANSFER_SWITCH
#define EVT_COM2_HF_SENSOR_KNOB			(THIRD_PARTY_EVENT_ID_MIN + 840)
#define EVT_COM2_TEST_SWICTH			(THIRD_PARTY_EVENT_ID_MIN + 841)
#define EVT_COM2_OUTER_SELECTOR			(THIRD_PARTY_EVENT_ID_MIN + 842)
#define EVT_COM2_INNER_SELECTOR			(THIRD_PARTY_EVENT_ID_MIN + 843)
#define EVT_COM2_END_RANGE1				EVT_COM2_INNER_SELECTOR
#define EVT_COM2_PNL_OFF_SWITCH			(THIRD_PARTY_EVENT_ID_MIN + 924)
#define EVT_COM2_START_RANGE2			EVT_COM2_PNL_OFF_SWITCH
#define EVT_COM2_VHF1_SWITCH			(THIRD_PARTY_EVENT_ID_MIN + 925)
#define EVT_COM2_VHF2_SWITCH			(THIRD_PARTY_EVENT_ID_MIN + 927)
#define EVT_COM2_VHF3_SWITCH			(THIRD_PARTY_EVENT_ID_MIN + 929)
#define EVT_COM2_HF1_SWITCH				(THIRD_PARTY_EVENT_ID_MIN + 931)
#define EVT_COM2_AM_SWITCH				(THIRD_PARTY_EVENT_ID_MIN + 933)
#define EVT_COM2_HF2_SWITCH				(THIRD_PARTY_EVENT_ID_MIN + 935)
#define EVT_COM2_END_RANGE2				EVT_COM2_HF2_SWITCH

#define EVT_COM3_TRANSFER_SWITCH		(THIRD_PARTY_EVENT_ID_MIN + 946)
#define EVT_COM3_START_RANGE1			EVT_COM3_TRANSFER_SWITCH
#define EVT_COM3_HF_SENSOR_KNOB			(THIRD_PARTY_EVENT_ID_MIN + 949)
#define EVT_COM3_TEST_SWICTH			(THIRD_PARTY_EVENT_ID_MIN + 950)
#define EVT_COM3_OUTER_SELECTOR			(THIRD_PARTY_EVENT_ID_MIN + 951)
#define EVT_COM3_INNER_SELECTOR			(THIRD_PARTY_EVENT_ID_MIN + 952)
#define EVT_COM3_END_RANGE1				EVT_COM3_INNER_SELECTOR
#define EVT_COM3_PNL_OFF_SWITCH			(THIRD_PARTY_EVENT_ID_MIN + 953)
#define EVT_COM3_START_RANGE2			EVT_COM3_PNL_OFF_SWITCH
#define EVT_COM3_VHF1_SWITCH			(THIRD_PARTY_EVENT_ID_MIN + 954)
#define EVT_COM3_VHF2_SWITCH			(THIRD_PARTY_EVENT_ID_MIN + 956)
#define EVT_COM3_VHF3_SWITCH			(THIRD_PARTY_EVENT_ID_MIN + 958)
#define EVT_COM3_HF1_SWITCH				(THIRD_PARTY_EVENT_ID_MIN + 960)
#define EVT_COM3_AM_SWITCH				(THIRD_PARTY_EVENT_ID_MIN + 962)
#define EVT_COM3_HF2_SWITCH				(THIRD_PARTY_EVENT_ID_MIN + 964)
#define EVT_COM3_END_RANGE2				EVT_COM3_HF2_SWITCH

// Audio Control Panels
//
// Captain ACP (at aft electronic panel)
#define EVT_ACP_CAPT_MIC_VHF1			(THIRD_PARTY_EVENT_ID_MIN + 734)
#define EVT_ACP_CAPT_MIC_VHF2			(THIRD_PARTY_EVENT_ID_MIN + 735)
#define EVT_ACP_CAPT_MIC_VHF3			(THIRD_PARTY_EVENT_ID_MIN + 877) // out of order
#define EVT_ACP_CAPT_MIC_HF1			(THIRD_PARTY_EVENT_ID_MIN + 878) // out of order
#define EVT_ACP_CAPT_MIC_HF2			(THIRD_PARTY_EVENT_ID_MIN + 879) // out of order
#define EVT_ACP_CAPT_MIC_FLT			(THIRD_PARTY_EVENT_ID_MIN + 736)
#define EVT_ACP_CAPT_MIC_SVC			(THIRD_PARTY_EVENT_ID_MIN + 737)
#define EVT_ACP_CAPT_MIC_PA				(THIRD_PARTY_EVENT_ID_MIN + 738)

#define EVT_ACP_CAPT_REC_VHF1			(THIRD_PARTY_EVENT_ID_MIN + 739)
#define EVT_ACP_CAPT_REC_VHF2			(THIRD_PARTY_EVENT_ID_MIN + 740)
#define EVT_ACP_CAPT_REC_VHF3			(THIRD_PARTY_EVENT_ID_MIN + 741)
#define EVT_ACP_CAPT_REC_HF1			(THIRD_PARTY_EVENT_ID_MIN + 742)
#define EVT_ACP_CAPT_REC_HF2			(THIRD_PARTY_EVENT_ID_MIN + 880) // out of order
#define EVT_ACP_CAPT_REC_FLT			(THIRD_PARTY_EVENT_ID_MIN + 743)
#define EVT_ACP_CAPT_REC_SVC			(THIRD_PARTY_EVENT_ID_MIN + 744)
#define EVT_ACP_CAPT_REC_PA				(THIRD_PARTY_EVENT_ID_MIN + 745)
#define EVT_ACP_CAPT_REC_NAV1			(THIRD_PARTY_EVENT_ID_MIN + 746)
#define EVT_ACP_CAPT_REC_NAV2			(THIRD_PARTY_EVENT_ID_MIN + 747)
#define EVT_ACP_CAPT_REC_ADF1			(THIRD_PARTY_EVENT_ID_MIN + 748)
#define EVT_ACP_CAPT_REC_ADF2			(THIRD_PARTY_EVENT_ID_MIN + 749)
#define EVT_ACP_CAPT_REC_MKR			(THIRD_PARTY_EVENT_ID_MIN + 750)
#define EVT_ACP_CAPT_REC_SPKR			(THIRD_PARTY_EVENT_ID_MIN + 751)

#define EVT_ACP_CAPT_RT_IC_SWITCH		(THIRD_PARTY_EVENT_ID_MIN + 752)
#define EVT_ACP_CAPT_MASK_BOOM_SWITCH	(THIRD_PARTY_EVENT_ID_MIN + 753)
#define EVT_ACP_CAPT_FILTER_SWITCH		(THIRD_PARTY_EVENT_ID_MIN + 754)
#define EVT_ACP_CAPT_ALT_NORM_SWITCH	(THIRD_PARTY_EVENT_ID_MIN + 755)

#define EVT_ACP_CAPT_FIRST1		EVT_ACP_CAPT_MIC_VHF1
#define EVT_ACP_CAPT_LAST1		EVT_ACP_CAPT_ALT_NORM_SWITCH
#define EVT_ACP_CAPT_FIRST2		EVT_ACP_CAPT_MIC_VHF3
#define EVT_ACP_CAPT_LAST2		EVT_ACP_CAPT_REC_HF2

// F/O ACP (at aft electronic panel)
#define EVT_ACP_FO_MIC_VHF1			(THIRD_PARTY_EVENT_ID_MIN + 850)
#define EVT_ACP_FO_MIC_VHF2			(THIRD_PARTY_EVENT_ID_MIN + 851)
#define EVT_ACP_FO_MIC_VHF3			(THIRD_PARTY_EVENT_ID_MIN + 881) // out of order
#define EVT_ACP_FO_MIC_HF1			(THIRD_PARTY_EVENT_ID_MIN + 882) // out of order
#define EVT_ACP_FO_MIC_HF2			(THIRD_PARTY_EVENT_ID_MIN + 883) // out of order
#define EVT_ACP_FO_MIC_FLT			(THIRD_PARTY_EVENT_ID_MIN + 852)
#define EVT_ACP_FO_MIC_SVC			(THIRD_PARTY_EVENT_ID_MIN + 853)
#define EVT_ACP_FO_MIC_PA			(THIRD_PARTY_EVENT_ID_MIN + 854)

#define EVT_ACP_FO_REC_VHF1			(THIRD_PARTY_EVENT_ID_MIN + 855)
#define EVT_ACP_FO_REC_VHF2			(THIRD_PARTY_EVENT_ID_MIN + 856)
#define EVT_ACP_FO_REC_VHF3			(THIRD_PARTY_EVENT_ID_MIN + 857)
#define EVT_ACP_FO_REC_HF1			(THIRD_PARTY_EVENT_ID_MIN + 858)
#define EVT_ACP_FO_REC_HF2			(THIRD_PARTY_EVENT_ID_MIN + 884) // out of order
#define EVT_ACP_FO_REC_FLT			(THIRD_PARTY_EVENT_ID_MIN + 859)
#define EVT_ACP_FO_REC_SVC			(THIRD_PARTY_EVENT_ID_MIN + 860)
#define EVT_ACP_FO_REC_PA			(THIRD_PARTY_EVENT_ID_MIN + 861)
#define EVT_ACP_FO_REC_NAV1			(THIRD_PARTY_EVENT_ID_MIN + 862)
#define EVT_ACP_FO_REC_NAV2			(THIRD_PARTY_EVENT_ID_MIN + 863)
#define EVT_ACP_FO_REC_ADF1			(THIRD_PARTY_EVENT_ID_MIN + 864)
#define EVT_ACP_FO_REC_ADF2			(THIRD_PARTY_EVENT_ID_MIN + 865)
#define EVT_ACP_FO_REC_MKR			(THIRD_PARTY_EVENT_ID_MIN + 866)
#define EVT_ACP_FO_REC_SPKR			(THIRD_PARTY_EVENT_ID_MIN + 867)

#define EVT_ACP_FO_VOL_NAV1			(THIRD_PARTY_EVENT_ID_MIN + 1862) // 1000 added for volume rotation event
#define EVT_ACP_FO_VOL_NAV2			(THIRD_PARTY_EVENT_ID_MIN + 1863)
#define EVT_ACP_FO_VOL_ADF1			(THIRD_PARTY_EVENT_ID_MIN + 1864)
#define EVT_ACP_FO_VOL_ADF2			(THIRD_PARTY_EVENT_ID_MIN + 1865)
#define EVT_ACP_FO_VOL_MKR			(THIRD_PARTY_EVENT_ID_MIN + 1866)

#define EVT_ACP_FO_RT_IC_SWITCH		(THIRD_PARTY_EVENT_ID_MIN + 868)
#define EVT_ACP_FO_MASK_BOOM_SWITCH	(THIRD_PARTY_EVENT_ID_MIN + 869)
#define EVT_ACP_FO_FILTER_SWITCH	(THIRD_PARTY_EVENT_ID_MIN + 870)
#define EVT_ACP_FO_ALT_NORM_SWITCH	(THIRD_PARTY_EVENT_ID_MIN + 871)

#define EVT_ACP_FO_FIRST1		EVT_ACP_FO_MIC_VHF1
#define EVT_ACP_FO_LAST1		EVT_ACP_FO_ALT_NORM_SWITCH
#define EVT_ACP_FO_FIRST2		EVT_ACP_FO_MIC_VHF3
#define EVT_ACP_FO_LAST2		EVT_ACP_FO_REC_HF2

// Observer ACP(at aft electronic panel)
#define EVT_ACP_OBS_MIC_VHF1		(THIRD_PARTY_EVENT_ID_MIN + 291)
#define EVT_ACP_OBS_MIC_VHF2		(THIRD_PARTY_EVENT_ID_MIN + 292)
#define EVT_ACP_OBS_MIC_VHF3		(THIRD_PARTY_EVENT_ID_MIN + 293) 
#define EVT_ACP_OBS_MIC_HF1			(THIRD_PARTY_EVENT_ID_MIN + 294) 
#define EVT_ACP_OBS_MIC_HF2			(THIRD_PARTY_EVENT_ID_MIN + 295) 
#define EVT_ACP_OBS_MIC_FLT			(THIRD_PARTY_EVENT_ID_MIN + 296)
#define EVT_ACP_OBS_MIC_SVC			(THIRD_PARTY_EVENT_ID_MIN + 297)
#define EVT_ACP_OBS_MIC_PA			(THIRD_PARTY_EVENT_ID_MIN + 873) // out of order

#define EVT_ACP_OBS_REC_VHF1		(THIRD_PARTY_EVENT_ID_MIN + 286)
#define EVT_ACP_OBS_REC_VHF2		(THIRD_PARTY_EVENT_ID_MIN + 287)
#define EVT_ACP_OBS_REC_VHF3		(THIRD_PARTY_EVENT_ID_MIN + 874) // out of order
#define EVT_ACP_OBS_REC_HF1			(THIRD_PARTY_EVENT_ID_MIN + 875) // out of order
#define EVT_ACP_OBS_REC_HF2			(THIRD_PARTY_EVENT_ID_MIN + 876) // out of order
#define EVT_ACP_OBS_REC_FLT			(THIRD_PARTY_EVENT_ID_MIN + 288)
#define EVT_ACP_OBS_REC_SVC			(THIRD_PARTY_EVENT_ID_MIN + 289)
#define EVT_ACP_OBS_REC_PA			(THIRD_PARTY_EVENT_ID_MIN + 290)
#define EVT_ACP_OBS_REC_NAV1		(THIRD_PARTY_EVENT_ID_MIN + 280)
#define EVT_ACP_OBS_REC_NAV2		(THIRD_PARTY_EVENT_ID_MIN + 281)
#define EVT_ACP_OBS_REC_ADF1		(THIRD_PARTY_EVENT_ID_MIN + 282)
#define EVT_ACP_OBS_REC_ADF2		(THIRD_PARTY_EVENT_ID_MIN + 283)
#define EVT_ACP_OBS_REC_MKR			(THIRD_PARTY_EVENT_ID_MIN + 284)
#define EVT_ACP_OBS_REC_SPKR		(THIRD_PARTY_EVENT_ID_MIN + 285)

#define EVT_ACP_OBS_VOL_NAV1		(THIRD_PARTY_EVENT_ID_MIN + 1280) // 1000 added for volume rotation event
#define EVT_ACP_OBS_VOL_NAV2		(THIRD_PARTY_EVENT_ID_MIN + 1281)
#define EVT_ACP_OBS_VOL_ADF1		(THIRD_PARTY_EVENT_ID_MIN + 1282)
#define EVT_ACP_OBS_VOL_ADF2		(THIRD_PARTY_EVENT_ID_MIN + 1283)
#define EVT_ACP_OBS_VOL_MKR			(THIRD_PARTY_EVENT_ID_MIN + 1284)

#define EVT_ACP_OBS_RT_IC_SWITCH		(THIRD_PARTY_EVENT_ID_MIN + 276)
#define EVT_ACP_OBS_MASK_BOOM_SWITCH	(THIRD_PARTY_EVENT_ID_MIN + 277)
#define EVT_ACP_OBS_FILTER_SWITCH		(THIRD_PARTY_EVENT_ID_MIN + 278)
#define EVT_ACP_OBS_ALT_NORM_SWITCH		(THIRD_PARTY_EVENT_ID_MIN + 279)

#define EVT_ACP_OBS_FIRST1		EVT_ACP_OBS_RT_IC_SWITCH
#define EVT_ACP_OBS_LAST1		EVT_ACP_OBS_MIC_SVC
#define EVT_ACP_OBS_FIRST2		EVT_ACP_OBS_MIC_PA
#define EVT_ACP_OBS_LAST2		EVT_ACP_OBS_REC_HF2

// TCAS
#define EVT_TCAS_XPNDR				(THIRD_PARTY_EVENT_ID_MIN + 798)
#define EVT_TCAS_MODE				(THIRD_PARTY_EVENT_ID_MIN + 800)
#define EVT_TCAS_TEST				(THIRD_PARTY_EVENT_ID_MIN + 801)
#define EVT_TCAS_ALTSOURCE			(THIRD_PARTY_EVENT_ID_MIN + 803)
#define EVT_TCAS_KNOB1				(THIRD_PARTY_EVENT_ID_MIN + 804)
#define EVT_TCAS_KNOB2				(THIRD_PARTY_EVENT_ID_MIN + 805)
#define EVT_TCAS_IDENT				(THIRD_PARTY_EVENT_ID_MIN + 806)
#define EVT_TCAS_KNOB4				(THIRD_PARTY_EVENT_ID_MIN + 807)
#define EVT_TCAS_KNOB3				(THIRD_PARTY_EVENT_ID_MIN + 808)

// HUD control panel
#define EVT_HUD_MODE				(THIRD_PARTY_EVENT_ID_MIN + 770)	// 
#define EVT_HUD_STB					(THIRD_PARTY_EVENT_ID_MIN + 771)	// 
#define EVT_HUD_RWY					(THIRD_PARTY_EVENT_ID_MIN + 772)	// 
#define EVT_HUD_GS					(THIRD_PARTY_EVENT_ID_MIN + 773)	// 
#define EVT_HUD_CLR					(THIRD_PARTY_EVENT_ID_MIN + 775)	// 
#define EVT_HUD_BRT					(THIRD_PARTY_EVENT_ID_MIN + 776)	// 
#define EVT_HUD_DIM					(THIRD_PARTY_EVENT_ID_MIN + 777)	// 
#define EVT_HUD_1					(THIRD_PARTY_EVENT_ID_MIN + 778)	// 
#define EVT_HUD_2					(THIRD_PARTY_EVENT_ID_MIN + 779)	// 
#define EVT_HUD_3					(THIRD_PARTY_EVENT_ID_MIN + 780)	// 
#define EVT_HUD_4					(THIRD_PARTY_EVENT_ID_MIN + 781)	// 
#define EVT_HUD_5					(THIRD_PARTY_EVENT_ID_MIN + 782)	// 
#define EVT_HUD_6					(THIRD_PARTY_EVENT_ID_MIN + 783)	// 
#define EVT_HUD_7					(THIRD_PARTY_EVENT_ID_MIN + 784)	// 
#define EVT_HUD_8					(THIRD_PARTY_EVENT_ID_MIN + 785)	// 
#define EVT_HUD_9					(THIRD_PARTY_EVENT_ID_MIN + 786)	// 
#define EVT_HUD_0					(THIRD_PARTY_EVENT_ID_MIN + 788)	// 
#define EVT_HUD_ENTER				(THIRD_PARTY_EVENT_ID_MIN + 787)	// 
#define EVT_HUD_TEST				(THIRD_PARTY_EVENT_ID_MIN + 789)	// 
#define EVT_HUD_STOW				(THIRD_PARTY_EVENT_ID_MIN + 979)	// 
#define EVT_HUD_BRIGTHNESS			(THIRD_PARTY_EVENT_ID_MIN + 980)	//
#define EVT_HUD_AUTO_MAN			(THIRD_PARTY_EVENT_ID_MIN + 981)	//

// HUD Annunciator Panel
#define EVT_HGS_FAIL_SWITCH			(THIRD_PARTY_EVENT_ID_MIN + 522)	//


// CDU
#define EVT_CDU_L_L1								(THIRD_PARTY_EVENT_ID_MIN + 534)	
#define EVT_CDU_L_L2								(THIRD_PARTY_EVENT_ID_MIN + 535)	
#define EVT_CDU_L_L3								(THIRD_PARTY_EVENT_ID_MIN + 536)	
#define EVT_CDU_L_L4								(THIRD_PARTY_EVENT_ID_MIN + 537)	
#define EVT_CDU_L_L5								(THIRD_PARTY_EVENT_ID_MIN + 538)	
#define EVT_CDU_L_L6								(THIRD_PARTY_EVENT_ID_MIN + 539)	
#define EVT_CDU_L_R1								(THIRD_PARTY_EVENT_ID_MIN + 540)	
#define EVT_CDU_L_R2								(THIRD_PARTY_EVENT_ID_MIN + 541)	
#define EVT_CDU_L_R3								(THIRD_PARTY_EVENT_ID_MIN + 542)	
#define EVT_CDU_L_R4								(THIRD_PARTY_EVENT_ID_MIN + 543)	
#define EVT_CDU_L_R5								(THIRD_PARTY_EVENT_ID_MIN + 544)	
#define EVT_CDU_L_R6								(THIRD_PARTY_EVENT_ID_MIN + 545)	
#define EVT_CDU_L_INIT_REF							(THIRD_PARTY_EVENT_ID_MIN + 546)	
#define EVT_CDU_L_RTE								(THIRD_PARTY_EVENT_ID_MIN + 547)	
#define EVT_CDU_L_CLB								(THIRD_PARTY_EVENT_ID_MIN + 548)	
#define EVT_CDU_L_CRZ								(THIRD_PARTY_EVENT_ID_MIN + 549)	
#define EVT_CDU_L_DES								(THIRD_PARTY_EVENT_ID_MIN + 550)	
#define EVT_CDU_L_MENU								(THIRD_PARTY_EVENT_ID_MIN + 551)	
#define EVT_CDU_L_LEGS								(THIRD_PARTY_EVENT_ID_MIN + 552)	
#define EVT_CDU_L_DEP_ARR							(THIRD_PARTY_EVENT_ID_MIN + 553)	
#define EVT_CDU_L_HOLD								(THIRD_PARTY_EVENT_ID_MIN + 554)	
#define EVT_CDU_L_PROG								(THIRD_PARTY_EVENT_ID_MIN + 555)	
#define EVT_CDU_L_EXEC								(THIRD_PARTY_EVENT_ID_MIN + 556)	
#define EVT_CDU_L_N1_LIMIT							(THIRD_PARTY_EVENT_ID_MIN + 557)	
#define EVT_CDU_L_FIX								(THIRD_PARTY_EVENT_ID_MIN + 558)	
#define EVT_CDU_L_PREV_PAGE							(THIRD_PARTY_EVENT_ID_MIN + 559)	
#define EVT_CDU_L_NEXT_PAGE							(THIRD_PARTY_EVENT_ID_MIN + 560)	
#define EVT_CDU_L_1									(THIRD_PARTY_EVENT_ID_MIN + 561)	
#define EVT_CDU_L_2									(THIRD_PARTY_EVENT_ID_MIN + 562)	
#define EVT_CDU_L_3									(THIRD_PARTY_EVENT_ID_MIN + 563)	
#define EVT_CDU_L_4									(THIRD_PARTY_EVENT_ID_MIN + 564)	
#define EVT_CDU_L_5									(THIRD_PARTY_EVENT_ID_MIN + 565)	
#define EVT_CDU_L_6									(THIRD_PARTY_EVENT_ID_MIN + 566)	
#define EVT_CDU_L_7									(THIRD_PARTY_EVENT_ID_MIN + 567)	
#define EVT_CDU_L_8									(THIRD_PARTY_EVENT_ID_MIN + 568)	
#define EVT_CDU_L_9									(THIRD_PARTY_EVENT_ID_MIN + 569)	
#define EVT_CDU_L_DOT								(THIRD_PARTY_EVENT_ID_MIN + 570)	
#define EVT_CDU_L_0									(THIRD_PARTY_EVENT_ID_MIN + 571)	
#define EVT_CDU_L_PLUS_MINUS						(THIRD_PARTY_EVENT_ID_MIN + 572)	
#define EVT_CDU_L_A									(THIRD_PARTY_EVENT_ID_MIN + 573)	
#define EVT_CDU_L_B									(THIRD_PARTY_EVENT_ID_MIN + 574)	
#define EVT_CDU_L_C									(THIRD_PARTY_EVENT_ID_MIN + 575)	
#define EVT_CDU_L_D									(THIRD_PARTY_EVENT_ID_MIN + 576)	
#define EVT_CDU_L_E									(THIRD_PARTY_EVENT_ID_MIN + 577)	
#define EVT_CDU_L_F									(THIRD_PARTY_EVENT_ID_MIN + 578)	
#define EVT_CDU_L_G									(THIRD_PARTY_EVENT_ID_MIN + 579)	
#define EVT_CDU_L_H									(THIRD_PARTY_EVENT_ID_MIN + 580)	
#define EVT_CDU_L_I									(THIRD_PARTY_EVENT_ID_MIN + 581)	
#define EVT_CDU_L_J									(THIRD_PARTY_EVENT_ID_MIN + 582)	
#define EVT_CDU_L_K									(THIRD_PARTY_EVENT_ID_MIN + 583)	
#define EVT_CDU_L_L									(THIRD_PARTY_EVENT_ID_MIN + 584)	
#define EVT_CDU_L_M									(THIRD_PARTY_EVENT_ID_MIN + 585)	
#define EVT_CDU_L_N									(THIRD_PARTY_EVENT_ID_MIN + 586)	
#define EVT_CDU_L_O									(THIRD_PARTY_EVENT_ID_MIN + 587)	
#define EVT_CDU_L_P									(THIRD_PARTY_EVENT_ID_MIN + 588)	
#define EVT_CDU_L_Q									(THIRD_PARTY_EVENT_ID_MIN + 589)	
#define EVT_CDU_L_R									(THIRD_PARTY_EVENT_ID_MIN + 590)	
#define EVT_CDU_L_S									(THIRD_PARTY_EVENT_ID_MIN + 591)	
#define EVT_CDU_L_T									(THIRD_PARTY_EVENT_ID_MIN + 592)	
#define EVT_CDU_L_U									(THIRD_PARTY_EVENT_ID_MIN + 593)	
#define EVT_CDU_L_V									(THIRD_PARTY_EVENT_ID_MIN + 594)	
#define EVT_CDU_L_W									(THIRD_PARTY_EVENT_ID_MIN + 595)	
#define EVT_CDU_L_X									(THIRD_PARTY_EVENT_ID_MIN + 596)	
#define EVT_CDU_L_Y									(THIRD_PARTY_EVENT_ID_MIN + 597)	
#define EVT_CDU_L_Z									(THIRD_PARTY_EVENT_ID_MIN + 598)	
#define EVT_CDU_L_SPACE								(THIRD_PARTY_EVENT_ID_MIN + 599)	
#define EVT_CDU_L_DEL								(THIRD_PARTY_EVENT_ID_MIN + 600)	
#define EVT_CDU_L_SLASH								(THIRD_PARTY_EVENT_ID_MIN + 601)	
#define EVT_CDU_L_CLR								(THIRD_PARTY_EVENT_ID_MIN + 602)	
#define EVT_CDU_L_BRITENESS							(THIRD_PARTY_EVENT_ID_MIN + 605)	

#define EVT_CDU_R_L1								(THIRD_PARTY_EVENT_ID_MIN + 606)	
#define EVT_CDU_R_L2								(THIRD_PARTY_EVENT_ID_MIN + 607)	
#define EVT_CDU_R_L3								(THIRD_PARTY_EVENT_ID_MIN + 608)	
#define EVT_CDU_R_L4								(THIRD_PARTY_EVENT_ID_MIN + 609)	
#define EVT_CDU_R_L5								(THIRD_PARTY_EVENT_ID_MIN + 610)	
#define EVT_CDU_R_L6								(THIRD_PARTY_EVENT_ID_MIN + 611)	
#define EVT_CDU_R_R1								(THIRD_PARTY_EVENT_ID_MIN + 612)	
#define EVT_CDU_R_R2								(THIRD_PARTY_EVENT_ID_MIN + 613)	
#define EVT_CDU_R_R3								(THIRD_PARTY_EVENT_ID_MIN + 614)	
#define EVT_CDU_R_R4								(THIRD_PARTY_EVENT_ID_MIN + 615)	
#define EVT_CDU_R_R5								(THIRD_PARTY_EVENT_ID_MIN + 616)	
#define EVT_CDU_R_R6								(THIRD_PARTY_EVENT_ID_MIN + 617)	
#define EVT_CDU_R_INIT_REF							(THIRD_PARTY_EVENT_ID_MIN + 618)	
#define EVT_CDU_R_RTE								(THIRD_PARTY_EVENT_ID_MIN + 619)	
#define EVT_CDU_R_CLB								(THIRD_PARTY_EVENT_ID_MIN + 620)	
#define EVT_CDU_R_CRZ								(THIRD_PARTY_EVENT_ID_MIN + 621)	
#define EVT_CDU_R_DES								(THIRD_PARTY_EVENT_ID_MIN + 622)	
#define EVT_CDU_R_MENU								(THIRD_PARTY_EVENT_ID_MIN + 623)	
#define EVT_CDU_R_LEGS								(THIRD_PARTY_EVENT_ID_MIN + 624)	
#define EVT_CDU_R_DEP_ARR							(THIRD_PARTY_EVENT_ID_MIN + 625)	
#define EVT_CDU_R_HOLD								(THIRD_PARTY_EVENT_ID_MIN + 626)	
#define EVT_CDU_R_PROG								(THIRD_PARTY_EVENT_ID_MIN + 627)	
#define EVT_CDU_R_EXEC								(THIRD_PARTY_EVENT_ID_MIN + 628)	
#define EVT_CDU_R_N1_LIMIT							(THIRD_PARTY_EVENT_ID_MIN + 629)	
#define EVT_CDU_R_FIX								(THIRD_PARTY_EVENT_ID_MIN + 630)	
#define EVT_CDU_R_PREV_PAGE							(THIRD_PARTY_EVENT_ID_MIN + 631)	
#define EVT_CDU_R_NEXT_PAGE							(THIRD_PARTY_EVENT_ID_MIN + 632)	
#define EVT_CDU_R_1									(THIRD_PARTY_EVENT_ID_MIN + 633)	
#define EVT_CDU_R_2									(THIRD_PARTY_EVENT_ID_MIN + 634)	
#define EVT_CDU_R_3									(THIRD_PARTY_EVENT_ID_MIN + 635)	
#define EVT_CDU_R_4									(THIRD_PARTY_EVENT_ID_MIN + 636)	
#define EVT_CDU_R_5									(THIRD_PARTY_EVENT_ID_MIN + 637)	
#define EVT_CDU_R_6									(THIRD_PARTY_EVENT_ID_MIN + 638)	
#define EVT_CDU_R_7									(THIRD_PARTY_EVENT_ID_MIN + 639)	
#define EVT_CDU_R_8									(THIRD_PARTY_EVENT_ID_MIN + 640)	
#define EVT_CDU_R_9									(THIRD_PARTY_EVENT_ID_MIN + 641)	
#define EVT_CDU_R_DOT								(THIRD_PARTY_EVENT_ID_MIN + 642)	
#define EVT_CDU_R_0									(THIRD_PARTY_EVENT_ID_MIN + 643)	
#define EVT_CDU_R_PLUS_MINUS						(THIRD_PARTY_EVENT_ID_MIN + 644)	
#define EVT_CDU_R_A									(THIRD_PARTY_EVENT_ID_MIN + 645)	
#define EVT_CDU_R_B									(THIRD_PARTY_EVENT_ID_MIN + 646)	
#define EVT_CDU_R_C									(THIRD_PARTY_EVENT_ID_MIN + 647)	
#define EVT_CDU_R_D									(THIRD_PARTY_EVENT_ID_MIN + 648)	
#define EVT_CDU_R_E									(THIRD_PARTY_EVENT_ID_MIN + 649)	
#define EVT_CDU_R_F									(THIRD_PARTY_EVENT_ID_MIN + 650)	
#define EVT_CDU_R_G									(THIRD_PARTY_EVENT_ID_MIN + 651)	
#define EVT_CDU_R_H									(THIRD_PARTY_EVENT_ID_MIN + 652)	
#define EVT_CDU_R_I									(THIRD_PARTY_EVENT_ID_MIN + 653)	
#define EVT_CDU_R_J									(THIRD_PARTY_EVENT_ID_MIN + 654)	
#define EVT_CDU_R_K									(THIRD_PARTY_EVENT_ID_MIN + 655)	
#define EVT_CDU_R_L									(THIRD_PARTY_EVENT_ID_MIN + 656)	
#define EVT_CDU_R_M									(THIRD_PARTY_EVENT_ID_MIN + 657)	
#define EVT_CDU_R_N									(THIRD_PARTY_EVENT_ID_MIN + 658)	
#define EVT_CDU_R_O									(THIRD_PARTY_EVENT_ID_MIN + 659)	
#define EVT_CDU_R_P									(THIRD_PARTY_EVENT_ID_MIN + 660)	
#define EVT_CDU_R_Q									(THIRD_PARTY_EVENT_ID_MIN + 661)	
#define EVT_CDU_R_R									(THIRD_PARTY_EVENT_ID_MIN + 662)	
#define EVT_CDU_R_S									(THIRD_PARTY_EVENT_ID_MIN + 663)	
#define EVT_CDU_R_T									(THIRD_PARTY_EVENT_ID_MIN + 664)	
#define EVT_CDU_R_U									(THIRD_PARTY_EVENT_ID_MIN + 665)	
#define EVT_CDU_R_V									(THIRD_PARTY_EVENT_ID_MIN + 666)	
#define EVT_CDU_R_W									(THIRD_PARTY_EVENT_ID_MIN + 667)	
#define EVT_CDU_R_X									(THIRD_PARTY_EVENT_ID_MIN + 668)	
#define EVT_CDU_R_Y									(THIRD_PARTY_EVENT_ID_MIN + 669)	
#define EVT_CDU_R_Z									(THIRD_PARTY_EVENT_ID_MIN + 670)	
#define EVT_CDU_R_SPACE								(THIRD_PARTY_EVENT_ID_MIN + 671)	
#define EVT_CDU_R_DEL								(THIRD_PARTY_EVENT_ID_MIN + 672)	
#define EVT_CDU_R_SLASH								(THIRD_PARTY_EVENT_ID_MIN + 673)	
#define EVT_CDU_R_CLR								(THIRD_PARTY_EVENT_ID_MIN + 674)	
#define EVT_CDU_R_BRITENESS							(THIRD_PARTY_EVENT_ID_MIN + 677)	

// Fire protection panel
#define EVT_FIRE_OVHT_DET_SWITCH_1					(THIRD_PARTY_EVENT_ID_MIN + 694)
#define EVT_FIRE_DETECTION_TEST_SWITCH				(THIRD_PARTY_EVENT_ID_MIN + 696)
#define EVT_FIRE_HANDLE_ENGINE_1_TOP				(THIRD_PARTY_EVENT_ID_MIN + 697)
#define EVT_FIRE_HANDLE_ENGINE_1_BOTTOM				(THIRD_PARTY_EVENT_ID_MIN + 6971)
#define EVT_FIRE_HANDLE_APU_TOP						(THIRD_PARTY_EVENT_ID_MIN + 698)
#define EVT_FIRE_HANDLE_APU_BOTTOM					(THIRD_PARTY_EVENT_ID_MIN + 6981)
#define EVT_FIRE_HANDLE_ENGINE_2_TOP				(THIRD_PARTY_EVENT_ID_MIN + 699)
#define EVT_FIRE_HANDLE_ENGINE_2_BOTTOM				(THIRD_PARTY_EVENT_ID_MIN + 6991)
#define EVT_FIRE_BELL_CUTOUT_SWITCH					(THIRD_PARTY_EVENT_ID_MIN + 704)
#define EVT_FIRE_OVHT_DET_SWITCH_2					(THIRD_PARTY_EVENT_ID_MIN + 705)	
#define EVT_FIRE_EXTINGUISHER_TEST_SWITCH			(THIRD_PARTY_EVENT_ID_MIN + 715)
#define EVT_FIRE_UNLOCK_SWITCH_ENGINE_1				(THIRD_PARTY_EVENT_ID_MIN + 976)
#define EVT_FIRE_UNLOCK_SWITCH_APU					(THIRD_PARTY_EVENT_ID_MIN + 977)
#define EVT_FIRE_UNLOCK_SWITCH_ENGINE_2				(THIRD_PARTY_EVENT_ID_MIN + 978)

// Cargo Fire
#define EVT_CARGO_FIRE_DET_SEL_SWITCH_FWD			(THIRD_PARTY_EVENT_ID_MIN + 760)
#define EVT_CARGO_FIRE_DET_SEL_SWITCH_AFT			(THIRD_PARTY_EVENT_ID_MIN + 761)
#define EVT_CARGO_FIRE_ARM_SWITCH_FWD				(THIRD_PARTY_EVENT_ID_MIN + 764)
#define EVT_CARGO_FIRE_ARM_SWITCH_AFT				(THIRD_PARTY_EVENT_ID_MIN + 766)
#define EVT_CARGO_FIRE_DISC_SWITCH_GUARD			(THIRD_PARTY_EVENT_ID_MIN + 767)
#define EVT_CARGO_FIRE_DISC_SWITCH					(THIRD_PARTY_EVENT_ID_MIN + 768)
#define EVT_CARGO_FIRE_TEST_SWITCH					(THIRD_PARTY_EVENT_ID_MIN + 769)

// Flight controls - pedestal
#define EVT_FCTL_AILERON_TRIM						(THIRD_PARTY_EVENT_ID_MIN + 810)	
#define EVT_FCTL_RUDDER_TRIM						(THIRD_PARTY_EVENT_ID_MIN + 811)

// Pedestal Lights Controls
#define EVT_PED_FLOOD_CONTROL						(THIRD_PARTY_EVENT_ID_MIN + 756)
#define EVT_PED_PANEL_CONTROL						(THIRD_PARTY_EVENT_ID_MIN + 757)

// Custom shortcut special events
#define EVT_LDG_LIGHTS_TOGGLE						(THIRD_PARTY_EVENT_ID_MIN + 14000)
#define EVT_TURNOFF_LIGHTS_TOGGLE					(THIRD_PARTY_EVENT_ID_MIN + 14001)
#define EVT_COCKPIT_LIGHTS_TOGGLE					(THIRD_PARTY_EVENT_ID_MIN + 14002)
#define EVT_COCKPIT_LIGHTS_ON						(THIRD_PARTY_EVENT_ID_MIN + 14003)
#define EVT_COCKPIT_LIGHTS_OFF						(THIRD_PARTY_EVENT_ID_MIN + 14004)
#define EVT_DOOR_FWD_L								(THIRD_PARTY_EVENT_ID_MIN + 14005)
#define EVT_DOOR_FWD_R								(THIRD_PARTY_EVENT_ID_MIN + 14006)
#define EVT_DOOR_AFT_L								(THIRD_PARTY_EVENT_ID_MIN + 14007)
#define EVT_DOOR_AFT_R								(THIRD_PARTY_EVENT_ID_MIN + 14008)
#define EVT_DOOR_OVERWING_EXIT_L					(THIRD_PARTY_EVENT_ID_MIN + 14009)
#define EVT_DOOR_OVERWING_EXIT_R					(THIRD_PARTY_EVENT_ID_MIN + 14010)
#define EVT_DOOR_CARGO_FWD							(THIRD_PARTY_EVENT_ID_MIN + 14013)  // note number skip to match eDoors enum
#define EVT_DOOR_CARGO_AFT							(THIRD_PARTY_EVENT_ID_MIN + 14014)
#define EVT_DOOR_EQUIPMENT_HATCH					(THIRD_PARTY_EVENT_ID_MIN + 14015)
#define EVT_DOOR_AIRSTAIR							(THIRD_PARTY_EVENT_ID_MIN + 14016)

// Yoke Animations
#define EVT_YOKE_L_COUNTER_1						(THIRD_PARTY_EVENT_ID_MIN + 998)	// Counters (digits left to right)  
#define EVT_YOKE_L_COUNTER_2						(THIRD_PARTY_EVENT_ID_MIN + 999)
#define EVT_YOKE_L_COUNTER_3						(THIRD_PARTY_EVENT_ID_MIN + 1000)
#define EVT_YOKE_R_COUNTER_1						(THIRD_PARTY_EVENT_ID_MIN + 1001)
#define EVT_YOKE_R_COUNTER_2						(THIRD_PARTY_EVENT_ID_MIN + 1002)
#define EVT_YOKE_R_COUNTER_3						(THIRD_PARTY_EVENT_ID_MIN + 1003)
#define EVT_YOKE_L_AP_DISC_SWITCH					(THIRD_PARTY_EVENT_ID_MIN + 1004)	// AP Disconnect switches
#define EVT_YOKE_R_AP_DISC_SWITCH					(THIRD_PARTY_EVENT_ID_MIN + 1005)

// MCP Direct Control 
#define EVT_MCP_CRS_L_SET							(THIRD_PARTY_EVENT_ID_MIN + 14500)	// Sets MCP course specified by the event parameter
#define EVT_MCP_CRS_R_SET							(THIRD_PARTY_EVENT_ID_MIN + 14501)	
#define EVT_MCP_IAS_SET								(THIRD_PARTY_EVENT_ID_MIN + 14502)	// Sets MCP IAS, if IAS mode is active
#define EVT_MCP_MACH_SET							(THIRD_PARTY_EVENT_ID_MIN + 14503)	// Sets MCP MACH (if active) to parameter*0.01 (e.g. send 78 to set M0.78)
#define EVT_MCP_HDG_SET								(THIRD_PARTY_EVENT_ID_MIN + 14504)	// Sets new heading, commands the shortest turn
#define EVT_MCP_ALT_SET								(THIRD_PARTY_EVENT_ID_MIN + 14505)	
#define EVT_MCP_VS_SET								(THIRD_PARTY_EVENT_ID_MIN + 14506)	// Sets MCP VS (if VS window open) to parameter-10000 (e.g. send 8200 for -1800fpm)

// Panel system events
#define EVT_CTRL_ACCELERATION_DISABLE				(THIRD_PARTY_EVENT_ID_MIN + 14600)
#define EVT_CTRL_ACCELERATION_ENABLE				(THIRD_PARTY_EVENT_ID_MIN + 14600)

#endif