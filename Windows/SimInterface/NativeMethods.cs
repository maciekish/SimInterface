using System;
using System.Runtime.InteropServices;

namespace MipPanels_PMDG
{
    public class NativeMethod
    {
        [DllImport("PMDGWrapper.dll", EntryPoint = "SetACLoadedCallback", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetACLoadedCallback(IntPtr callback);
        public delegate void ACLoadedCallback([MarshalAs(UnmanagedType.LPStr)]string airPath);

        /// <summary>
        /// get the PMDG 737NGX data structure
        /// </summary>
        /// <returns>an IntPtr to PMDG_NGX_Data</returns>
        [DllImport("PMDGWrapper.dll", EntryPoint = "GetPMDGData", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr _GetPMDGData();
        public static SDK.PMDG_NGX_Data GetPMDGData()
        {
            var pmdgDataRaw = _GetPMDGData();
            var pmdgData = (SDK.PMDG_NGX_Data)Marshal.PtrToStructure(pmdgDataRaw, typeof(SDK.PMDG_NGX_Data));
            return pmdgData;
        }

        /// <summary>
        /// get the length in bytes of the PMDG 737NGX data structure
        /// </summary>
        /// <returns>the length</returns>
        [DllImport("PMDGWrapper.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetPMDGDataStructureLength();

        /// <summary>
        /// send a PMDGEvent to the PMDG 737NGX
        /// </summary>
        /// <param name="pmdgEvent"></param>
        /// <param name="parameter"></param>
        /// <returns></returns>
        [DllImport("PMDGWrapper.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]        
        public static extern bool RaisePMDGEvent(SDK.PMDGEvents pmdgEvent, int parameter);

    }

}