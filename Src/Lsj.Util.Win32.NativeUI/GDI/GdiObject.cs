using System;

namespace Lsj.Util.Win32.NativeUI.GDI
{
    public abstract class GdiObject : IDisposable
    {
        public abstract GdiObjectType ObjectType { get; }

        private bool _hasRelase = false;

        ~GdiObject()
        {
            ReleaseObject();
        }

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

        protected abstract void OnReleaseObject();
    }

    public enum GdiObjectType
    {
        DeviceContext,

        Brush,

        Pen,
    }

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
