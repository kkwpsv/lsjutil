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
            RegisteredClass = 0x02,
            WindowProcHooked = 0x04,
            WindowProcUseThis = 0x08,
            OtherProcess = 0x10,
        }

        /// <summary>
        /// 
        /// </summary>
        protected override void CleanUpUnmanagedResources()
        {
            if (_handle != NULL && _flags == Win32WindowFlags.OwnWindow)
            {
                DestroyWindow(_handle);
                _handle = NULL;
            }
            if (_windowClassName != null && _flags == Win32WindowFlags.RegisteredClass)
            {
                UnregisterClass(_windowClassName.ToIntPtr(), _hInstance);
                _windowClassName.Dispose();
            }
        }

        private static ATOM RegisterWindowClass(in WNDCLASSEX wndClass)
        {
            var result = RegisterClassEx(wndClass);
            if (result == 0)
            {
                throw new Win32Exception();
            }
            return result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal bool CheckFlag(Win32WindowFlags flags) => (_flags & flags) != 0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal void ThrowExceptionIfError() => ThrowExceptionIfError(GetLastError());

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal void ThrowExceptionIfError(SystemErrorCodes errorCode)
        {
            if (errorCode != SystemErrorCodes.ERROR_SUCCESS)
            {
                OnWin32Exception(errorCode);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
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

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
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
