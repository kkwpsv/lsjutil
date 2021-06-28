using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.ComInterfaces;
using Lsj.Util.Win32.Enums;
using Lsj.Util.Win32.Marshals;
using Lsj.Util.Win32.Structs;
using System;
using System.IO;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.Enums.GetAncestorFlags;
using static Lsj.Util.Win32.Enums.GetClassLongIndexes;
using static Lsj.Util.Win32.Enums.GetWindowCommands;
using static Lsj.Util.Win32.Enums.GetWindowLongIndexes;
using static Lsj.Util.Win32.Enums.ProcessAccessRights;
using static Lsj.Util.Win32.Enums.SetWindowPosFlags;
using static Lsj.Util.Win32.Enums.SystemErrorCodes;
using static Lsj.Util.Win32.Enums.WindowStyles;
using static Lsj.Util.Win32.Enums.WindowStylesEx;
using static Lsj.Util.Win32.Kernel32;
using static Lsj.Util.Win32.UnsafePInvokeExtensions;
using static Lsj.Util.Win32.User32;
using static Lsj.Util.Win32.Dwmapi;
using static Lsj.Util.Win32.Enums.DWMWINDOWATTRIBUTE;

namespace Lsj.Util.Win32.NativeUI
{
    public partial class Win32Window
    {
        private (int ProcessID, int ThreadID) GetWindowProcessIDAndThreadID()
        {
            var threadID = GetWindowThreadProcessId(_handle, out var processID);
            if (threadID == 0)
            {
                ThrowExceptionIfError();
            }
            return (processID, threadID);
        }

        private string GetProcessName()
        {
            var process = OpenProcess(PROCESS_QUERY_LIMITED_INFORMATION, false, ProcessID);
            if (process != NULL)
            {
                var length = (DWORD)MAX_PATH;
                var path = new StringBuffer(MAX_PATH);
                if (QueryFullProcessImageName(process, 0, path, ref length))
                {
                    return Path.ChangeExtension(Path.GetFileName(path.ToString()), null);
                }
                CloseHandle(process);
            }
            return string.Empty;
        }

        private HWND GetParentWindowHandle()
        {
            return GetAncestor(_handle, GA_PARENT);
        }

        private void SetParentWindowHandle(HWND value)
        {
            var style = GetWindowStyles();
            if (value == NULL && (style & WS_CHILD) != 0)
            {
                SetWindowStyles(style & ~WS_CHILD);
            }
            else if (value != NULL)
            {
                if ((style & WS_POPUP) != 0)
                {
                    SetWindowStyles(style & ~WS_POPUP);
                }
                if ((style & WS_CHILD) == 0)
                {
                    SetWindowStyles(style | WS_CHILD);
                }
            }

            if (SetParent(_handle, value) == NULL)
            {
                ThrowExceptionIfError();
            }

            if (value == NULL && (style & WS_POPUP) == 0)
            {
                SetWindowStyles(style | WS_POPUP);
            }
        }

        private HWND GetOwnerWindowHandle()
        {
            var result = GetWindow(_handle, GW_OWNER);
            if (result == NULL)
            {
                ThrowExceptionIfError();
            }
            return result;
        }

        private void SetOwnerWindowHandle(HWND value)
        {
            if (GetParentWindowHandle() != NULL)
            {
                throw new InvalidOperationException("Cannot set owner window when has parent window");
            }

            SetLastError(ERROR_SUCCESS);
            if (SetWindowLong(_handle, GWL_HWNDPARENT, (IntPtr)value) == NULL)
            {
                ThrowExceptionIfError();
            }
        }

        private string GetText()
        {
            var textLength = GetWindowTextLength(_handle) + 1;
            if (textLength > 0)
            {
                var textBuffer = new StringBuffer(textLength);
                if (GetWindowText(_handle, textBuffer, textLength) != 0)
                {
                    return textBuffer.ToString();
                }
                else
                {
                    ThrowExceptionIfError();
                }
            }
            else
            {
                ThrowExceptionIfError();
            }
            return string.Empty;
        }

        private void SetText(string value)
        {
            if (!SetWindowText(_handle, value))
            {
                ThrowExceptionIfError();
            }
        }

        private WindowStyles GetWindowStyles()
        {
            var result = GetWindowLong(_handle, GWL_STYLE);
            if (result != NULL)
            {
                return (WindowStyles)result.SafeToUInt32();
            }
            else
            {
                ThrowExceptionIfError();
                return 0;
            }
        }

        private void SetWindowStyles(WindowStyles value)
        {
            SetLastError(ERROR_SUCCESS);
            if (SetWindowLong(_handle, GWL_STYLE, (uint)value) != NULL)
            {
                ThrowExceptionIfError();
            }
        }

        private WindowStylesEx GetWindowStylesEx()
        {
            var result = GetWindowLong(_handle, GWL_EXSTYLE);
            if (result == NULL)
            {
                return (WindowStylesEx)result.SafeToUInt32();
            }
            else
            {
                ThrowExceptionIfError();
                return 0;
            }
        }

        private void SetWindowStylesEx(WindowStylesEx value)
        {
            var oldStyleEx = GetWindowStylesEx();
            if ((oldStyleEx & WS_EX_TOPMOST) != 0 && (value & WS_EX_TOPMOST) == 0)
            {
                SetNoTopMost();
            }
            if ((oldStyleEx & WS_EX_TOPMOST) == 0 && (value & WS_EX_TOPMOST) != 0)
            {
                SetTopMost();
            }
            SetLastError(ERROR_SUCCESS);
            if (SetWindowLong(_handle, GWL_EXSTYLE, (uint)value) != NULL)
            {
                ThrowExceptionIfError();
            }
        }

        private ClassStyles GetClassStyles()
        {
            var result = GetClassLong(_handle, GCL_STYLE);
            if (result == NULL)
            {
                return (ClassStyles)result.SafeToUInt32();
            }
            else
            {
                ThrowExceptionIfError();
                return 0;
            }
        }

        private void SetClassStyles(ClassStyles value)
        {
            SetLastError(ERROR_SUCCESS);
            if (SetClassLong(_handle, GCL_STYLE, (uint)value) != NULL)
            {
                ThrowExceptionIfError();
            }
        }

        private string GetClassName()
        {
            var buffer = new StringBuffer(256);
            if (User32.GetClassName(_handle, buffer, 256) > 0)
            {
                return buffer;
            }
            else
            {
                ThrowExceptionIfError();
                return string.Empty;
            }
        }

        private RECT GetRect()
        {
            if (GetWindowRect(_handle, out var result))
            {
                return result;
            }
            else
            {
                ThrowExceptionIfError();
                return new RECT();
            }
        }

        private void SetRect(RECT value)
        {
            var parent = GetParentWindowHandle();
            if (parent != NULL)
            {
                var point = new POINT { x = value.left, y = value.top };
                if (!ScreenToClient(parent, ref point) || !SetWindowPos(_handle, IntPtr.Zero, point.x, point.y, value.right - value.left, value.bottom - value.top, SWP_NOZORDER))
                {
                    ThrowExceptionIfError();
                }
            }
            else
            {
                if (!SetWindowPos(_handle, IntPtr.Zero, value.left, value.top, value.right - value.left, value.bottom - value.top, SWP_NOZORDER))
                {
                    ThrowExceptionIfError();
                }
            }
        }

        private ShowWindowCommands GetShowStates()
        {
            var placement = new WINDOWPLACEMENT
            {
                length = SizeOf<WINDOWPLACEMENT>(),
            };
            if (GetWindowPlacement(_handle, ref placement))
            {
                return placement.showCmd;
            }
            else
            {
                ThrowExceptionIfError();
                return 0;
            }
        }

        private void SetShowStates(ShowWindowCommands value) => ShowWindow(_handle, value);

        private DPI_AWARENESS GetDpiAwareness()
        {
            if (Environment.OSVersion.Version >= new Version(10, 0, 14393, 0))
            {
                var dpiAwarenessContext = GetWindowDpiAwarenessContext(_handle);
                if (dpiAwarenessContext != NULL)
                {
                    var result = GetAwarenessFromDpiAwarenessContext(dpiAwarenessContext);
                    if (result != DPI_AWARENESS.DPI_AWARENESS_INVALID)
                    {
                        return result;
                    }
                    else
                    {
                        ThrowExceptionIfError();
                    }
                }
                else
                {
                    ThrowExceptionIfError();
                }
            }
            throw new PlatformNotSupportedException();
        }

        private bool GetIsTouchWindow() => User32.IsTouchWindow(_handle, out _);

        private GUID GetDesktopID()
        {
            if (_virtualDesktopManager == NULL)
            {
                throw new PlatformNotSupportedException();
            }
            unsafe
            {
                var hresult = ((IVirtualDesktopManager*)_virtualDesktopManager)->GetWindowDesktopId(_handle, out var result);
                if (!hresult)
                {
                    ThrowComException(hresult);
                }
                return result;
            }
        }

        private void SetDesktopID(GUID value)
        {
            if (_virtualDesktopManager == NULL)
            {
                throw new PlatformNotSupportedException();
            }
            unsafe
            {
                var hresult = ((IVirtualDesktopManager*)_virtualDesktopManager)->MoveWindowToDesktop(_handle, value);
                if (!hresult)
                {
                    ThrowComException(hresult);
                }
            }
        }

        private bool GetIsNonClientRenderingEnabled()
        {
            BOOL result = false;
            var hresult = DwmGetWindowAttribute(_handle, DWMWA_NCRENDERING_ENABLED, AsPointer(ref result), SizeOf<BOOL>());
            if (!hresult)
            {
                ThrowComException(hresult);
            }
            return result;
        }
    }
}
