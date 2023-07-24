using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Enums;
using System;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.Gdi32;

namespace Lsj.Util.Win32.NativeUI.GDI
{
    /// <summary>
    /// Pen
    /// </summary>
    public class Pen : GdiObject
    {
        /// <summary>
        /// Handle
        /// </summary>
        public HPEN Handle { get; private set; }

        private readonly GdiObjectReleaseMode _releaseMode;

        /// <summary>
        /// Pen
        /// </summary>
        /// <param name="hPen"></param>
        /// <param name="releaseMode"></param>
        public Pen(HPEN hPen, GdiObjectReleaseMode releaseMode)
        {
            Handle = hPen;
            _releaseMode = releaseMode;
            if (releaseMode == GdiObjectReleaseMode.None)
            {
                GC.SuppressFinalize(this);
            }
        }

        /// <inheritdoc/>
        public override GdiObjectType ObjectType => GdiObjectType.Pen;

        /// <inheritdoc/>
        protected override void OnReleaseObject()
        {
            if (_releaseMode == GdiObjectReleaseMode.DeleteObject)
            {
                DeleteObject(Handle);
            }
        }

        /// <summary>
        /// Create Pen
        /// </summary>
        /// <param name="penStyles"></param>
        /// <param name="width"></param>
        /// <param name="color"></param>
        /// <returns></returns>
        /// <exception cref="GDIOperationFailedException"></exception>
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

        /// <summary>
        /// Create Solid Pen
        /// </summary>
        /// <param name="width"></param>
        /// <param name="color"></param>
        /// <returns></returns>
        /// <exception cref="GDIOperationFailedException"></exception>
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
