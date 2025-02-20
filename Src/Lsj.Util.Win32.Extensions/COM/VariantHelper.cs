using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Enums;
using Lsj.Util.Win32.Structs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lsj.Util.Win32.Extensions.COM
{
    /// <summary>
    /// <see cref="VARIANT"/> Helper
    /// </summary>
    public static class VariantHelper
    {
        /// <summary>
        /// <see cref="VARIANT"/> From <see cref="string"/>
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static VARIANT FromString(string str)
        {
            var result = new VARIANT();
            result.vt = VARENUM.VT_BSTR;
            result.bstrVal = OleAut32.SysAllocString(str);
            return result;
        }

        /// <summary>
        /// <see cref="VARIANT"/> From <see cref="bool"/>
        /// </summary>
        /// <param name="b"></param>
        /// <returns></returns>
        public static VARIANT FromBool(bool b)
        {
            var result = new VARIANT();
            result.vt = VARENUM.VT_BOOL;
            result.boolVal = b;
            return result;
        }

        /// <summary>
        /// Free
        /// </summary>
        /// <param name="variant"></param>
        public static void Free(ref VARIANT variant)
        {
            if (variant.vt == (VARTYPE)VARENUM.VT_BSTR)
            {
                OleAut32.SysFreeString(variant.bstrVal);
            }
            variant.vt = VARENUM.VT_EMPTY;
        }
    }
}
