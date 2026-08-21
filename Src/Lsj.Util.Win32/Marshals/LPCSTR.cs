using Lsj.Util.Win32.BaseTypes;
using System;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.Marshals
{
    /// <summary>
    /// LPCSTR
    /// </summary>
    public class LPCSTR : CriticalHandle, IPointer
    {
        private string? _str;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public LPCSTR(nint val) : this()
        {
            SetHandle(val);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public LPCSTR(string? val) : this()
        {
            _str = val;
            if (_str != null)
            {
                SetHandle(Marshal.StringToHGlobalAnsi(_str));
            }
        }

        private LPCSTR() : base((nint)0)
        {
        }

        /// <inheritdoc/>
        public override bool IsInvalid => IsClosed;

        /// <inheritdoc/>
        public IntPtr ToIntPtr() => handle;

        /// <inheritdoc/>
        public nint ToNint() => handle;

        /// <summary>
        /// The <see cref="string"/> val
        /// </summary>
        public string? StringVal => _str ?? (handle != (nint)0 ? Marshal.PtrToStringAnsi(handle) : null);

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
        public static implicit operator LPCSTR(string? val) => new LPCSTR(val);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator LPCSTR(nint val) => new LPCSTR(val);
    }
}
