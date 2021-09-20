using System;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.Marshals
{
    /// <summary>
    /// LPCSTR
    /// </summary>
    public class LPCSTR : CriticalHandle
    {
        private string _str;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public LPCSTR(IntPtr val) : base(IntPtr.Zero)
        {
            SetHandle(val);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public LPCSTR(string val) : base(IntPtr.Zero)
        {
            _str = val;
            SetHandle(Marshal.StringToHGlobalAnsi(_str));
        }

        /// <inheritdoc/>
        public override bool IsInvalid => IsClosed;

        /// <summary>
        /// The <see cref="string"/> val
        /// </summary>
        public string StringVal => _str ?? (handle != IntPtr.Zero ? Marshal.PtrToStringAnsi(handle) : null);

        internal IntPtr InternalGetHandle() => handle;

        /// <inheritdoc/>
        protected override bool ReleaseHandle()
        {
            if (_str != null)
            {
                Marshal.FreeHGlobal(handle);
            }
            return true;
        }

        /// <inheritdoc/>
        public override string ToString() => StringVal ?? string.Empty;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator LPCSTR(string val) => new LPCSTR(val);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator LPCSTR(IntPtr val) => new LPCSTR(val);
    }
}
