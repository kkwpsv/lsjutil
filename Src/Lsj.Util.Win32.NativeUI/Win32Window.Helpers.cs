using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.ComInterfaces;
using Lsj.Util.Win32.Enums;
using Lsj.Util.Win32.Structs;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.ComInterfaces.CLSIDs;
using static Lsj.Util.Win32.ComInterfaces.IIDs;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.Enums.CLSCTX;
using static Lsj.Util.Win32.Kernel32;
using static Lsj.Util.Win32.Ole32;
using static Lsj.Util.Win32.UnsafePInvokeExtensions;
using static Lsj.Util.Win32.User32;

namespace Lsj.Util.Win32.NativeUI
{
    public partial class Win32Window
    {
        static LPVOID _virtualDesktopManager;

        static Win32Window()
        {
            if (Environment.OSVersion.Version.Major >= 10)
            {
                CoCreateInstance(CLSID_VirtualDesktopManager, NullRef<IUnknown>(), CLSCTX_INPROC_SERVER, in IID_IVirtualDesktopManager, out _virtualDesktopManager);
            }
        }

        /// <summary>
        /// Custom Error Handler
        /// </summary>
        public Action<SystemErrorCodes?, HRESULT?>? CustomErrorHandler { get; set; }

        private Win32WindowFlags _flags;

        [Flags]
        internal enum Win32WindowFlags
        {
            OwnWindow = 0x1,
            OtherProcess = 0x10,
        }

        /// <summary>
        /// 
        /// </summary>
        protected override void CleanUpUnmanagedResources()
        {
            if (_handle != NULL)
            {
                DestroyWindow(_handle);
                _handle = NULL;
            }
        }

        private void RegisterWindowClass(HINSTANCE hInstance, in WNDCLASSEX wndclass)
        {
            if (RegisterClassEx(wndclass) == 0)
            {
                throw new Win32Exception();
            }
        }

#if !NET40
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
        internal bool CheckFlag(Win32WindowFlags flags) => (_flags & flags) != 0;

#if! NET40
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
        internal void ThrowExceptionIfError() => ThrowExceptionIfError(GetLastError());

#if !NET40
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
        internal void ThrowExceptionIfError(SystemErrorCodes errorCode)
        {
            if (errorCode != SystemErrorCodes.ERROR_SUCCESS)
            {
                OnWin32Exception(errorCode);
            }
        }

#if !NET40
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
        internal void OnWin32Exception(SystemErrorCodes errorCode)
        {
            if (CustomErrorHandler != null)
            {
                CustomErrorHandler.Invoke(errorCode, null);
            }
            else
            {
                throw new Win32Exception((int)errorCode);
            }
        }

#if !NET40
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
        internal void OnComException(HRESULT hresult)
        {
            if (CustomErrorHandler != null)
            {
                CustomErrorHandler.Invoke(null, hresult);
            }
            else
            {
                Marshal.ThrowExceptionForHR(hresult);
            }
        }
    }
}
