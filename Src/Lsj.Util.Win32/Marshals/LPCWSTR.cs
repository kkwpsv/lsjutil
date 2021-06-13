using System;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.Marshals
{
    /// <summary>
    /// LPCWSTR implement by pinned string or dirtect pointer.
    /// </summary>
    public class LPCWSTR : CriticalHandle
    {
        private GCHandle _gcHandle;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="str"></param>
        public LPCWSTR(string str) : base(IntPtr.Zero)
        {
            if (str != null)
            {
                _gcHandle = GCHandle.Alloc(str, GCHandleType.Pinned);
                SetHandle(_gcHandle.AddrOfPinnedObject());
            }
            else
            {
                GC.SuppressFinalize(this);
            }
        }

        public LPCWSTR(IntPtr handle) : base(IntPtr.Zero)
        {
            SetHandle(handle);
            GC.SuppressFinalize(this);
        }

        /// <inheritdoc/>
        public override bool IsInvalid => IsClosed;

        /// <inheritdoc/>
        protected override bool ReleaseHandle()
        {
            if (_gcHandle.IsAllocated)
            {
                _gcHandle.Free();
            }
            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator LPCWSTR(string val) => new LPCWSTR(val);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator LPCWSTR(IntPtr val) => new LPCWSTR(val);
    }
}
