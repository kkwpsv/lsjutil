using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Enums;
using System;
using System.ComponentModel;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.Gdi32;
using static Lsj.Util.Win32.User32;

namespace Lsj.Util.Win32.NativeUI.GDI
{
    /// <summary>
    /// Brush
    /// </summary>
    public class Brush : GdiObject
    {
        /// <summary>
        /// Handle
        /// </summary>
        public HBRUSH Handle { get; private set; }

        private readonly GdiObjectReleaseMode _releaseMode;

        public Brush(HBRUSH hBrush, GdiObjectReleaseMode releaseMode)
        {
            Handle = hBrush;
            _releaseMode = releaseMode;
            if (releaseMode == GdiObjectReleaseMode.None)
            {
                GC.SuppressFinalize(this);
            }
        }

        public override GdiObjectType ObjectType => GdiObjectType.Brush;

        protected override void OnReleaseObject()
        {
            if (_releaseMode == GdiObjectReleaseMode.DeleteObject)
            {
                DeleteObject(Handle);
            }
        }

        public static Brush FromColor(COLORREF color)
        {
            var result = CreateSolidBrush(color);
            if (result != NULL)
            {
                return new Brush(result, GdiObjectReleaseMode.DeleteObject);
            }
            else
            {
                throw new Win32Exception();
            }
        }

        public static Brush FromSysColor(SystemColors systemColors)
        {
            var result = GetSysColorBrush(systemColors);
            if (result != NULL)
            {
                return new Brush(result, GdiObjectReleaseMode.None);
            }
            else
            {
                throw new Win32Exception();
            }
        }
    }
}
