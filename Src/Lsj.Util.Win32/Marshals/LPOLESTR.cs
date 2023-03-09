using Lsj.Util.IL;
using System;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.Marshals
{
    /// <summary>
    /// LPOLESTR implement by self-managed buffer or dirtect pointer.
    /// </summary>
    public class LPOLESTR : CriticalHandle
    {
        private bool _isSelfManager;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="str"></param>
        public LPOLESTR(string str) : base(IntPtr.Zero)
        {
            if (str != null)
            {
                _isSelfManager = true;
                SetHandle(Marshal.StringToHGlobalUni(str));
            }
            else
            {
                GC.SuppressFinalize(this);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="str"></param>
        /// <param name="bufferLength"></param>
        public LPOLESTR(string str, int bufferLength) : base(IntPtr.Zero)
        {
            if (str.Length > bufferLength)
            {
                throw new ArgumentOutOfRangeException(nameof(bufferLength), "Buffer length is smaller than string length");
            }
            if (str != null)
            {
                _isSelfManager = true;
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
            else
            {
                GC.SuppressFinalize(this);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="handle"></param>
        public LPOLESTR(IntPtr handle) : base(IntPtr.Zero)
        {
            SetHandle(handle);
            GC.SuppressFinalize(this);
        }

        /// <inheritdoc/>
        public override bool IsInvalid => IsClosed;

        /// <inheritdoc/>
        protected override bool ReleaseHandle()
        {
            if (_isSelfManager)
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
        public string? StringVal => handle != IntPtr.Zero ? Marshal.PtrToStringUni(handle) : null;

        /// <inheritdoc/>
        public override string ToString() => StringVal ?? string.Empty;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator LPOLESTR(string val) => new LPOLESTR(val);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator LPOLESTR(IntPtr val) => new LPOLESTR(val);
    }
}
