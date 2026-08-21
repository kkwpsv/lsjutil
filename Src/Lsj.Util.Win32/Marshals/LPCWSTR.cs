using Lsj.Util.Win32.BaseTypes;
using System;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.Marshals
{
    /// <summary>
    /// LPCWSTR implement by pinned string or direct pointer.
    /// </summary>
    public class LPCWSTR : CriticalHandle, IPointer
    {
        private GCHandle _gcHandle;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="str"></param>
        public LPCWSTR(string? str) : this()
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
        public LPCWSTR(nint handle) : this()
        {
            SetHandle(handle);
            GC.SuppressFinalize(this);
        }

        private LPCWSTR() : base((nint)0)
        {
        }

        /// <inheritdoc/>
        public override bool IsInvalid => IsClosed;

        /// <inheritdoc/>
        public IntPtr ToIntPtr() => handle;

        /// <inheritdoc/>
        public nint ToNint() => handle;

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
        public static implicit operator LPCWSTR(string? val) => new LPCWSTR(val);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator LPCWSTR(nint val) => new LPCWSTR(val);
    }
}
