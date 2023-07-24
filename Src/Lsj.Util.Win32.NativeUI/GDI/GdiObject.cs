using System;

namespace Lsj.Util.Win32.NativeUI.GDI
{
    /// <summary>
    /// GdiObject
    /// </summary>
    public abstract class GdiObject : IDisposable
    {
        /// <summary>
        /// Object Type
        /// </summary>
        public abstract GdiObjectType ObjectType { get; }

        private bool _hasRelase = false;

        /// <summary>
        /// 
        /// </summary>
        ~GdiObject()
        {
            ReleaseObject();
        }

        /// <summary>
        /// Dispose
        /// </summary>
        public void Dispose()
        {
            ReleaseObject();
            GC.SuppressFinalize(this);
        }

        private void ReleaseObject()
        {
            if (!_hasRelase)
            {
                _hasRelase = true;
                OnReleaseObject();
            }
        }

        /// <summary>
        /// OnReleaseObject
        /// </summary>
        protected abstract void OnReleaseObject();
    }

    /// <summary>
    /// GdiObjectType
    /// </summary>
    public enum GdiObjectType
    {
        /// <summary>
        /// Device Context
        /// </summary>
        DeviceContext,

        /// <summary>
        /// Brush
        /// </summary>
        Brush,

        /// <summary>
        /// Pen
        /// </summary>
        Pen,
    }

    /// <summary>
    /// Gdi Object Release Mode
    /// </summary>
    public enum GdiObjectReleaseMode
    {
        /// <summary>
        /// Not need
        /// </summary>
        None,

        /// <summary>
        /// Release by <see cref="Gdi32.DeleteObject"/>
        /// </summary>
        DeleteObject,
    }

}
