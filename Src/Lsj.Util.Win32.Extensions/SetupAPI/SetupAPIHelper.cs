using Lsj.Util.IL;
using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Enums;
using Lsj.Util.Win32.GUIDs;
using Lsj.Util.Win32.Marshals;
using Lsj.Util.Win32.Structs;
using System;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.SetupAPI;
using static Lsj.Util.Win32.Kernel32;
using static Lsj.Util.Win32.Enums.SystemErrorCodes;

namespace Lsj.Util.Win32.Extensions.SetupAPI
{
    /// <summary>
    /// SetupAPI helper
    /// </summary>
    public static class SetupAPIHelper
    {
        /// <summary>
        /// EnumDeviceInfo callback
        /// </summary>
        /// <param name="devInfo">
        /// <see cref="HDEVINFO"/>
        /// </param>
        /// <param name="deviceInfoData">
        /// <see cref="SP_DEVINFO_DATA"/>
        /// </param>
        /// <returns>
        /// continue
        /// </returns>
        public delegate bool EnumDeviceInfoCallback(HDEVINFO devInfo, ref SP_DEVINFO_DATA deviceInfoData);


        /// <summary>
        /// Enum DeviceInfo 
        /// </summary>
        /// <param name="ClassGuid">
        /// See <see cref="SetupDiGetClassDevs"/> param.
        /// </param>
        /// <param name="callback">
        /// enum callback
        /// </param>
        /// <returns></returns>
        public static bool EnumDeviceInfo(in GUID ClassGuid, EnumDeviceInfoCallback callback) => EnumDeviceInfo(ClassGuid, NULL, SetupDiGetClassDevsFlags.DIGCF_PRESENT, callback);

        /// <summary>
        /// Enum DeviceInfo 
        /// </summary>
        /// <param name="ClassGuid">
        /// See <see cref="SetupDiGetClassDevs"/> param.
        /// </param>
        /// <param name="Enumerator">
        /// See <see cref="SetupDiGetClassDevs"/> param.
        /// </param>
        /// <param name="Flags">
        /// See <see cref="SetupDiGetClassDevs"/> param.
        /// </param>
        /// <param name="callback">
        /// enum callback
        /// </param>
        /// <returns></returns>
        public static bool EnumDeviceInfo(in GUID ClassGuid, LPCWSTR Enumerator, SetupDiGetClassDevsFlags Flags, EnumDeviceInfoCallback callback)
        {
            var devInfo = SetupDiGetClassDevs(DeviceSetupClasses.GUID_DEVCLASS_CAMERA, NULL, IntPtr.Zero, SetupDiGetClassDevsFlags.DIGCF_PRESENT);
            if (devInfo != INVALID_HANDLE_VALUE)
            {
                try
                {
                    var index = 0u;
                    var deviceInfoData = new SP_DEVINFO_DATA { cbSize = Unsafe.SizeOf<SP_DEVINFO_DATA>() };
                    while (SetupDiEnumDeviceInfo(devInfo, index, ref deviceInfoData))
                    {
                        if (!callback(devInfo, ref deviceInfoData))
                        {
                            return true;
                        }
                        index++;
                    }
                    return true;
                }
                finally
                {
                    SetupDiDestroyDeviceInfoList(devInfo);
                }
            }
            return false;
        }

        /// <summary>
        /// GetDeviceInstanceId
        /// </summary>
        /// <param name="devInfo"></param>
        /// <param name="deviceInfoData"></param>
        /// <returns></returns>
        public static unsafe string? GetDeviceInstanceId(HDEVINFO devInfo, in SP_DEVINFO_DATA deviceInfoData)
        {
            SetupDiGetDeviceInstanceId(devInfo, deviceInfoData, IntPtr.Zero, 0, out var size);
            var status = GetLastError();
            if (status == ERROR_INSUFFICIENT_BUFFER)
            {
                var buffer = stackalloc char[(int)size];
                if (SetupDiGetDeviceInstanceId(devInfo, deviceInfoData, (IntPtr)buffer, size, out _))
                {
                    return new string(buffer);
                }
            }
            return null;
        }
    }
}
