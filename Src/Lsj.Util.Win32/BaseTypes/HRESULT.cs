using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Constants;

namespace Lsj.Util.Win32.BaseTypes
{
    /// <summary>
    /// <para>
    /// An <see cref="HRESULT"/> is a 32-bit value that is used to describe an error or warning and contains the following fields:
    /// A 1-bit code that indicates severity, where 0 represents success and 1 represents failure.
    /// A 4-bit reserved value.
    /// An 11-bit code, also known as a facility code, that indicates responsibility for the error or warning.
    /// A 16-bit code that describes the error or warning.
    /// For details on <see cref="HRESULT"/> values, see [MS-ERREF].
    /// </para>
    /// <para>
    /// From: https://docs.microsoft.com/zh-cn/openspecs/windows_protocols/ms-dtyp/a9046ed2-bfb2-4d56-a719-2824afce59ac
    /// From: https://docs.microsoft.com/zh-cn/windows/win32/learnwin32/error-handling-in-com
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Explicit, Size = 4)]
    public struct HRESULT
    {
        /// <summary>
        /// CACHE_E_NOCACHE_UPDATED
        /// </summary>
        public static readonly HRESULT CACHE_E_NOCACHE_UPDATED = new HRESULT { _value = unchecked((int)0x80040170) };

        /// <summary>
        /// CACHE_S_FORMATETC_NOTSUPPORTED
        /// </summary>
        public static readonly HRESULT CACHE_S_FORMATETC_NOTSUPPORTED = new HRESULT { _value = 0x00040170 };

        /// <summary>
        /// CACHE_S_SAMECACHE
        /// </summary>
        public static readonly HRESULT CACHE_S_SAMECACHE = new HRESULT { _value = 0x00040171 };

        /// <summary>
        /// CACHE_S_SOMECACHES_NOTUPDATED
        /// </summary>
        public static readonly HRESULT CACHE_S_SOMECACHES_NOTUPDATED = new HRESULT { _value = 0x00040172 };

        /// <summary>
        /// CLASS_E_NOAGGREGATION
        /// </summary>
        public static readonly HRESULT CLASS_E_NOAGGREGATION = new HRESULT { _value = unchecked((int)0x80040110) };

        /// <summary>
        /// CO_E_NOTINITIALIZED
        /// </summary>
        public static readonly HRESULT CO_E_NOTINITIALIZED = new HRESULT { _value = unchecked((int)0x800401F0) };

        /// <summary>
        /// DV_E_CLIPFORMAT
        /// </summary>
        public static readonly HRESULT DV_E_CLIPFORMAT = new HRESULT { _value = unchecked((int)0x8004006A) };

        /// <summary>
        /// DV_E_DVASPECT
        /// </summary>
        public static readonly HRESULT DV_E_DVASPECT = new HRESULT { _value = unchecked((int)0x8004006B) };

        /// <summary>
        /// DV_E_DVTARGETDEVICE
        /// </summary>
        public static readonly HRESULT DV_E_DVTARGETDEVICE = new HRESULT { _value = unchecked((int)0x80040065) };

        /// <summary>
        /// DV_E_FORMATETC
        /// </summary>
        public static readonly HRESULT DV_E_FORMATETC = new HRESULT { _value = unchecked((int)0x80040064) };

        /// <summary>
        /// DV_E_LINDEX
        /// </summary>
        public static readonly HRESULT DV_E_LINDEX = new HRESULT { _value = unchecked((int)0x80040068) };

        /// <summary>
        /// DV_E_TYMED
        /// </summary>
        public static readonly HRESULT DV_E_TYMED = new HRESULT { _value = unchecked((int)0x80040069) };

        /// <summary>
        /// Access denied.
        /// </summary>
        public static readonly HRESULT E_ACCESSDENIED = new HRESULT { _value = unchecked((int)0x80070005) };

        /// <summary>
        /// Unspecified error.
        /// </summary>
        public static readonly HRESULT E_FAIL = new HRESULT { _value = unchecked((int)0x80004005) };

        /// <summary>
        /// Invalid parameter value.
        /// </summary>
        public static readonly HRESULT E_INVALIDARG = new HRESULT { _value = unchecked((int)0x80070057) };

        /// <summary>
        /// E_NOINTERFACE
        /// </summary>
        public static readonly HRESULT E_NOINTERFACE = new HRESULT { _value = unchecked((int)0x80004002) };

        /// <summary>
        /// E_NOTIMPL
        /// </summary>
        public static readonly HRESULT E_NOTIMPL = new HRESULT { _value = unchecked((int)0x80004001) };

        /// <summary>
        /// Out of memory.
        /// </summary>
        public static readonly HRESULT E_OUTOFMEMORY = new HRESULT { _value = unchecked((int)0x8007000E) };

        /// <summary>
        /// <see cref="NULL"/> was passed incorrectly for a pointer value.
        /// </summary>
        public static readonly HRESULT E_POINTER = new HRESULT { _value = unchecked((int)0x80004003) };

        /// <summary>
        /// Unexpected condition.
        /// </summary>
        public static readonly HRESULT E_UNEXPECTED = new HRESULT { _value = unchecked((int)0x8000FFFF) };

        /// <summary>
        /// Success.
        /// </summary>
        public static readonly HRESULT S_OK = new HRESULT();

        /// <summary>
        /// Success.
        /// </summary>
        public static readonly HRESULT S_FALSE = new HRESULT { _value = 0x1 };

        [FieldOffset(0)]
        private int _value;

        /// <inheritdoc/>
        public override string ToString() => _value.ToString("X");

        /// <summary>
        /// Is Succeed
        /// </summary>
        public bool Succeed => _value >= 0;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator bool(HRESULT val) => val.Succeed;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator uint(HRESULT val) => unchecked((uint)val._value);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator int(HRESULT val) => val._value;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator HRESULT(int val) => new HRESULT { _value = val };

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator HRESULT(uint val) => new HRESULT { _value = unchecked((int)val) };
    }
}
