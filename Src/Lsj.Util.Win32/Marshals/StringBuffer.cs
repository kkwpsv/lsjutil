using System;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.Marshals
{
    /// <summary>
    /// String Buffer 
    /// </summary>
    public class StringBuffer : CriticalFinalizerObject, IDisposable
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="bufferLength">
        /// buffer length in char count. (With '\0')
        /// </param>
        public StringBuffer(int bufferLength)
        {
            _length = bufferLength;
            _handle = Marshal.AllocHGlobal(ByteLength);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bufferLength">
        /// Buffer length in char count. (With '\0')
        /// </param>
        /// <param name="initContent">
        /// Init content
        /// </param>
        public StringBuffer(string initContent, int bufferLength)
        {
            if (initContent.Length > bufferLength + 1)
            {
                throw new ArgumentException("String is too long than buffer length");
            }
            _length = bufferLength;
            _handle = Marshal.AllocHGlobal(ByteLength);
            unsafe
            {
                fixed (char* ptr = initContent)
                {
                    UnsafeHelper.Copy(ptr, (char*)(void*)_handle, ByteLength);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        ~StringBuffer()
        {
            Dispose(disposing: false);
        }

        private readonly IntPtr _handle;
        private readonly int _length;

        /// <summary>
        /// Length in char count.
        /// </summary>
        public int Length => _length;

        /// <summary>
        /// Length in byte count.
        /// </summary>
        public int ByteLength => _length * 2;

        /// <summary>
        /// Dispose
        /// </summary>
        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        private bool _disposedValue;

        /// <summary>
        /// Dispose
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                }

                Marshal.FreeHGlobal(_handle);
                _disposedValue = true;
            }
        }

        /// <summary>
        /// To String
        /// </summary>
        /// <returns></returns>
        public unsafe override string ToString() => new string((char*)(void*)_handle);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator string(StringBuffer val) => val.ToString();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator IntPtr(StringBuffer val) => val._handle;
    }
}
