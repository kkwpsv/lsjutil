using Lsj.Util.Win32.BaseTypes;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.BOOL;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Contains menu bar information.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/ns-winuser-menubarinfo"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct MENUBARINFO
    {
        /// <summary>
        /// The size of the structure, in bytes.
        /// The caller must set this to <code>sizeof(MENUBARINFO)</code>.
        /// </summary>
        public DWORD cbSize;

        /// <summary>
        /// The coordinates of the menu bar, popup menu, or menu item.
        /// </summary>
        public RECT rcBar;

        /// <summary>
        /// A handle to the menu bar or popup menu.
        /// </summary>
        public HMENU hMenu;

        /// <summary>
        /// A handle to the submenu.
        /// </summary>
        public HWND hwndMenu;

        private int _val;

        /// <summary>
        /// If the menu bar or popup menu has the focus, this member is <see cref="TRUE"/>.
        /// Otherwise, the member is <see cref="FALSE"/>.
        /// </summary>
#pragma warning disable IDE1006
        public BOOL fBarFocused
#pragma warning restore IDE1006
        {
            get => (_val & 0x01) == 0x01;
            set
            {
                if (value)
                {
                    _val |= 0x01;
                }
                else
                {
                    _val &= 0xFFFE;
                }
            }
        }

        /// <summary>
        /// If the menu item has the focus, this member is <see cref="TRUE"/>.
        /// Otherwise, the member is <see cref="FALSE"/>.
        /// </summary>
#pragma warning disable IDE1006
        public BOOL fFocused
#pragma warning restore IDE1006
        {
            get => (_val & 0x02) == 0x02;
            set
            {
                if (value)
                {
                    _val |= 0x02;
                }
                else
                {
                    _val &= 0xFFFD;
                }
            }
        }
    }
}
