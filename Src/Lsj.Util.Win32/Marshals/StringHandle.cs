using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Lsj.Util.Win32.Marshals
{
    /// <summary>
    /// String Handle For P/Invoke
    /// </summary>
    public class StringHandle : CriticalHandle
    {
        private bool _needRelease = false;

        /// <summary>
        /// Initialize a <see cref="StringHandle"/> with <see cref="IntPtr.Zero"/>
        /// </summary>
        public StringHandle() : this(IntPtr.Zero, false)
        {

        }

        /// <summary>
        /// Initialize a <see cref="StringHandle"/> with a <see cref="IntPtr"/> which is not need to release.
        /// </summary>
        /// <param name="val">The <see cref="IntPtr"/> value.</param>
        public StringHandle(IntPtr val) : this(val, false)
        {

        }

        /// <summary>
        /// Initialize a <see cref="StringHandle"/> with a <see cref="IntPtr"/>.
        /// </summary>
        /// <param name="val">The <see cref="IntPtr"/> value.</param>
        /// <param name="needRelease">If need to release this handle.</param>
        public StringHandle(IntPtr val, bool needRelease) : base(val)
        {
            _needRelease = needRelease;
        }

        /// <summary>
        /// Initialize a <see cref="StringHandle"/> with a <see cref="string"/> which is need to release.
        /// </summary>
        /// <param name="val">The <see cref="string"/> value.</param>
        public StringHandle(string val) : this(val, true)
        {

        }

        /// <summary>
        /// Initialize a <see cref="StringHandle"/> with a <see cref="string"/>.
        /// </summary>
        /// <param name="val">The <see cref="string"/> value.</param>
        /// <param name="needRelease">If need to release this handle.</param>
        public StringHandle(string val, bool needRelease) : base(IntPtr.Zero)
        {
            if (val != null)
            {
                SetHandle(Marshal.StringToHGlobalUni(val));
                _needRelease = needRelease;
            }
        }

        /// <inheritdoc/>
        public override bool IsInvalid => IsClosed;

        /// <summary>
        /// If need to release this handle.
        /// </summary>
        public bool NeedRelease => _needRelease;

        /// <summary>
        /// The <see cref="string"/> val
        /// </summary>
        public string StringVal => handle != IntPtr.Zero ? Marshal.PtrToStringUni(handle) : null;

        internal IntPtr InternalGetHandle() => handle;

        /// <inheritdoc/>
        protected override bool ReleaseHandle()
        {
            if (handle != IntPtr.Zero && _needRelease)
            {
                Marshal.FreeHGlobal(handle);
                return true;
            }
            else
            {
                return false;
            }
        }

        public override string ToString() => StringVal ?? string.Empty;

        /// <summary>
        /// Return a <see cref="StringHandle"/> with a <see cref="string"/> which is need to release.
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator StringHandle(string val) => new StringHandle(val);

        /// <summary>
        /// Return a <see cref="StringHandle"/> with a <see cref="IntPtr"/> which is not need to release.
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator StringHandle(IntPtr val) => new StringHandle(val);
    }
}
