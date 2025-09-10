using Lsj.Util.IL;
using Lsj.Util.Win32.BaseTypes;
using System;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.Marshals
{
    /// <summary>
    /// LPSTR implement by self-managed buffer or direct pointer.
    /// </summary>
    public class LPSTR : CriticalHandle, IPointer
    {
        private bool _isSelfManaged;

        /// <summary>
        /// Initialize from a string.
        /// </summary>
        /// <param name="str"></param>
        public LPSTR(string? str) : base(IntPtr.Zero)
        {
            if (str != null)
            {
                _isSelfManaged = true;
                SetHandle(Marshal.StringToHGlobalAnsi(str));
            }
            else
            {
                GC.SuppressFinalize(this);
            }
        }

        /// <summary>
        /// Initialize from a string with specific buffer length in char.
        /// </summary>
        /// <param name="str"></param>
        /// <param name="bufferLength"></param>
        public LPSTR(string str, int bufferLength) : base(IntPtr.Zero)
        {
            if (str.Length > bufferLength)
            {
                throw new ArgumentOutOfRangeException(nameof(bufferLength), "Buffer length is smaller than string length");
            }
            _isSelfManaged = true;
            var buffer = Marshal.AllocHGlobal(bufferLength);
            unsafe
            {
                fixed (char* ptr = str)
                {
                    Unsafe.CopyBlock((void*)buffer, ptr, (uint)str.Length * 2);
                }
            }
            SetHandle(buffer);
        }

        /// <summary>
        /// Initialize an empty LPSTR with specific buffer length in char.
        /// </summary>
        /// <param name="bufferLength"></param>
        public LPSTR(int bufferLength) : base(IntPtr.Zero)
        {
            if (bufferLength <= 0)
            {
                throw new ArgumentOutOfRangeException("Buffer length must be larger than zero");
            }

            _isSelfManaged = true;
            var buffer = Marshal.AllocHGlobal(bufferLength);
            SetHandle(buffer);
        }

        /// <summary>
        /// Initialize from a pointer.
        /// </summary>
        /// <param name="handle"></param>
        /// <remarks>
        /// The memory will not be release.
        /// </remarks>
        public LPSTR(IntPtr handle) : base(IntPtr.Zero)
        {
            SetHandle(handle);
            GC.SuppressFinalize(this);
        }

        /// <inheritdoc/>
        public override bool IsInvalid => IsClosed;

        /// <inheritdoc/>
        public IntPtr ToIntPtr() => handle;

        /// <inheritdoc/>
        protected override bool ReleaseHandle()
        {
            if (_isSelfManaged)
            {
                Marshal.FreeHGlobal(handle);
            }
            return true;
        }

        /// <summary>
        /// The handle.
        /// </summary>
        public IntPtr Handle => handle;

        /// <summary>
        /// The <see cref="string"/> val
        /// </summary>
        public string? StringVal => handle != IntPtr.Zero ? Marshal.PtrToStringAnsi(handle) : null;

        /// <inheritdoc/>
        public override string ToString() => StringVal ?? string.Empty;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator LPSTR(string? val) => new LPSTR(val);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator LPSTR(IntPtr val) => new LPSTR(val);
    }
}
