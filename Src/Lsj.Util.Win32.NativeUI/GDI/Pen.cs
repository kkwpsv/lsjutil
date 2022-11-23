using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Enums;
using Lsj.Util.Win32.Structs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.Gdi32;
using static Lsj.Util.Win32.User32;
using static Lsj.Util.Win32.UnsafePInvokeExtensions;

namespace Lsj.Util.Win32.NativeUI.GDI
{
    public class Pen : GdiObject
    {
        /// <summary>
        /// Handle
        /// </summary>
        public HPEN Handle { get; private set; }

        private readonly GdiObjectReleaseMode _releaseMode;

        public Pen(HPEN hPen, GdiObjectReleaseMode releaseMode)
        {
            Handle = hPen;
            _releaseMode = releaseMode;
            if (releaseMode == GdiObjectReleaseMode.None)
            {
                GC.SuppressFinalize(this);
            }
        }

        public override GdiObjectType ObjectType => GdiObjectType.Pen;

        protected override void OnReleaseObject()
        {
            if (_releaseMode == GdiObjectReleaseMode.DeleteObject)
            {
                DeleteObject(Handle);
            }
        }

        public static Pen Create(PenStyles penStyles, int width, COLORREF color)
        {
            var result = CreatePen(penStyles, width, color);
            if (result != NULL)
            {
                return new Pen(result, GdiObjectReleaseMode.DeleteObject);
            }
            else
            {
                throw new GDIOperationFailedException(nameof(CreatePen));
            }
        }

        public static Pen CreateSolid(int width, COLORREF color)
        {
            var result = CreatePen(PenStyles.PS_SOLID, width, color);
            if (result != NULL)
            {
                return new Pen(result, GdiObjectReleaseMode.DeleteObject);
            }
            else
            {
                throw new GDIOperationFailedException(nameof(CreatePen));
            }
        }
    }
}
