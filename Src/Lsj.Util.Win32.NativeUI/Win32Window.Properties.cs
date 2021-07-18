using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Enums;
using Lsj.Util.Win32.Structs;
using System;

namespace Lsj.Util.Win32.NativeUI
{
    public partial class Win32Window
    {
        /// <summary>
        /// Window Handle
        /// </summary>
        public HWND Handle => _handle;

        /// <summary>
        /// Process ID
        /// </summary>
        public int ProcessID => GetWindowProcessIDAndThreadID().ProcessID;

        /// <summary>
        /// Process Name
        /// </summary>
        public string ProcessName => GetProcessName();

        /// <summary>
        /// Thread ID
        /// </summary>
        public int ThreadID => GetWindowProcessIDAndThreadID().ThreadID;

        /// <summary>
        /// Parent Window Handle
        /// </summary>
        public HWND ParentWindowHandle
        {
            get => GetParentWindowHandle();
            set => SetParentWindowHandle(value);
        }

        /// <summary>
        /// Owner Window Handle
        /// </summary>
        public HWND OwnerWindowHandle
        {
            get => GetOwnerWindowHandle();
            set => SetOwnerWindowHandle(value);
        }

        /// <summary>
        /// Text
        /// </summary>
        public string Text
        {
            get => GetText();
            set => SetText(value);
        }

        /// <summary>
        /// Window Styles
        /// </summary>
        public WindowStyles WindowStyles
        {
            get => GetWindowStyles();
            set => SetWindowStyles(value);
        }

        /// <summary>
        /// Window Styles Ex
        /// </summary>
        public WindowStylesEx WindowStylesEx
        {
            get => GetWindowStylesEx();
            set => SetWindowStylesEx(value);
        }

        /// <summary>
        /// Class Styles
        /// </summary>
        public ClassStyles ClassStyles
        {
            get => GetClassStyles();
            set => SetClassStyles(value);
        }

        /// <summary>
        /// Class Name
        /// </summary>
        public string ClassName => GetClassName();

        /// <summary>
        /// Window Rect (Screen coordinates)
        /// </summary>
        public RECT Rect
        {
            get => GetRect();
            set => SetRect(value);
        }

        /// <summary>
        /// Window Show States
        /// </summary>
        public ShowWindowCommands ShowStates
        {
            get => GetShowStates();
            set => SetShowStates(value);
        }

        /// <summary>
        /// Dpi Awareness
        /// </summary>
        public DPI_AWARENESS DpiAwareness
        {
            get => GetDpiAwareness();
        }

        /// <summary>
        /// Is Touch Window
        /// </summary>
        public bool IsTouchWindow => GetIsTouchWindow();

        /// <summary>
        /// Desktop ID
        /// </summary>
        public GUID DesktopID
        {
            get => GetDesktopID();
            set => SetDesktopID(value);
        }

        /// <summary>
        /// DWM Info
        /// </summary>
        public DWMInfo DWMInfo { get; }
    }
}
