using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Lsj.Util.Win32.Marshals
{
    public class StringHandle : CriticalHandle
    {
        private bool _needRelease = false;

        public StringHandle(IntPtr val) : this(val, true)
        {

        }

        public StringHandle(IntPtr val, bool needRelease) : base(val)
        {
            _needRelease = needRelease;
        }

        public StringHandle(string val) : this(val, true)
        {

        }

        public StringHandle(string val, bool needRelease) : base(IntPtr.Zero)
        {
            if (val != null)
            {
                SetHandle(Marshal.StringToHGlobalUni(val));
                _needRelease = needRelease;
            }
        }

        public override bool IsInvalid => IsClosed;

        public string StringVal => handle != IntPtr.Zero ? Marshal.PtrToStringUni(handle) : null;

        internal IntPtr InternalGetHandle() => handle;

        protected override bool ReleaseHandle()
        {
            if (handle != IntPtr.Zero)
            {
                if (_needRelease)
                {
                    Marshal.FreeHGlobal(handle);
                }
                return true;
            }
            else
            {
                return false;
            }
        }

        public static implicit operator StringHandle(string val) => new StringHandle(val);

        public static implicit operator StringHandle(IntPtr val) => new StringHandle(val);
    }
}
