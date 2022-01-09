using Lsj.Util.IL;
using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.Marshals.ByValStructs
{
    /// <summary>
    /// By Val String Struct For Size 296
    /// </summary>
    [DebuggerDisplay("{ToString()}")]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode, Size = 296 * sizeof(char))]
    public unsafe struct ByValStringStructForSize296
    {
        char _firstChar;

        /// <inheritdoc/>
        public override string ToString()
        {
            fixed (char* charPtr = &_firstChar)
            {
                return new string(charPtr);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator ByValStringStructForSize296(string val)
        {
            if (val.Length > 296 - 1)
            {
                throw new ArgumentException("String too long");
            }
            var result = new ByValStringStructForSize296();
            fixed (char* strPtr = val)
            {
                Unsafe.CopyBlock(&result, strPtr, (uint)(val.Length * sizeof(char)));
            }
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator string(ByValStringStructForSize296 val) => val.ToString();
    }
}
