using Lsj.Util.IL;
using Lsj.Util.Win32.BaseTypes;
using System;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.Marshals
{
    /// <summary>
    /// LPWSTR implement by self-managed buffer or direct pointer.
    /// </summary>
    public class LPWSTR : CriticalHandle, IPointer
    {
        private bool _isSelfManaged;

        /// <summary>
        /// Initialize from a string.
        /// </summary>
        /// <param name="str"></param>
        public LPWSTR(string? str) : this()
        {
            if (str != null)
            {
                _isSelfManaged = true;
                SetHandle(Marshal.StringToHGlobalUni(str));
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
        public LPWSTR(string str, int bufferLength) : this()
        {
            if (str.Length > bufferLength)
            {
                throw new ArgumentOutOfRangeException(nameof(bufferLength), "Buffer length is smaller than string length");
            }
            _isSelfManaged = true;
            var buffer = Marshal.AllocHGlobal(bufferLength * sizeof(char));
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
        /// Initialize an empty LPWSTR with specific buffer length in char.
        /// </summary>
        /// <param name="bufferLength"></param>
        public LPWSTR(int bufferLength) : this()
        {
            if (bufferLength <= 0)
            {
                throw new ArgumentOutOfRangeException("Buffer length must be larger than zero");
            }

            _isSelfManaged = true;
            var buffer = Marshal.AllocHGlobal(bufferLength * sizeof(char));
            SetHandle(buffer);
        }

        /// <summary>
        /// Initialize from a pointer.
        /// </summary>
        /// <param name="handle"></param>
        /// <remarks>
        /// The memory will not be release.
        /// </remarks>
        public LPWSTR(nint handle) : this()
        {
            SetHandle(handle);
            GC.SuppressFinalize(this);
        }

        private LPWSTR() : base((nint)0)
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
            if (_isSelfManaged)
            {
                Marshal.FreeHGlobal(handle);
            }
            return true;
        }

        /// <summary>
        /// The handle.
        /// </summary>
        public nint Handle => handle;

        /// <summary>
        /// The <see cref="string"/> val
        /// </summary>
        public string? StringVal => handle != (nint)0 ? Marshal.PtrToStringUni(handle) : null;

        /// <inheritdoc/>
        public override string ToString() => StringVal ?? string.Empty;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator LPWSTR(string? val) => new LPWSTR(val);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator LPWSTR(nint val) => new LPWSTR(val);
    }
}
