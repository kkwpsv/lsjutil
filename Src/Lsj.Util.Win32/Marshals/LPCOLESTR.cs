using System;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.Marshals
{
    /// <summary>
    /// LPCOLESTR implement by pinned string or dirtect pointer.
    /// </summary>
    public class LPCOLESTR : CriticalHandle
    {
        private GCHandle _gcHandle;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="str"></param>
        public LPCOLESTR(string str) : this()
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="handle"></param>
        public LPCOLESTR(nint handle) : this()
        {
            SetHandle(handle);
            GC.SuppressFinalize(this);
        }

        private LPCOLESTR() : base((nint)0)
        {
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
        public static implicit operator LPCOLESTR(string val) => new LPCOLESTR(val);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator LPCOLESTR(nint val) => new LPCOLESTR(val);
    }
}
