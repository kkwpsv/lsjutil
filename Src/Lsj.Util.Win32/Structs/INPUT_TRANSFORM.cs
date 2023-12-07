using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Defines the matrix that represents a transform on a message consumer.
    /// This matrix can be used to transform pointer input data from client coordinates to screen coordinates,
    /// while the inverse can be used to transform pointer input data from screen coordinates to client coordinates.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/ns-winuser-input_transform"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct INPUT_TRANSFORM
    {
        /// <summary>
        /// 
        /// </summary>
        public float _11;

        /// <summary>
        /// 
        /// </summary>
        public float _12;

        /// <summary>
        /// 
        /// </summary>
        public float _13;

        /// <summary>
        /// 
        /// </summary>
        public float _14;

        /// <summary>
        /// 
        /// </summary>
        public float _21;

        /// <summary>
        /// 
        /// </summary>
        public float _22;

        /// <summary>
        /// 
        /// </summary>
        public float _23;

        /// <summary>
        /// 
        /// </summary>
        public float _24;

        /// <summary>
        /// 
        /// </summary>
        public float _31;

        /// <summary>
        /// 
        /// </summary>
        public float _32;

        /// <summary>
        /// 
        /// </summary>
        public float _33;

        /// <summary>
        /// 
        /// </summary>
        public float _34;

        /// <summary>
        /// 
        /// </summary>
        public float _41;

        /// <summary>
        /// 
        /// </summary>
        public float _42;

        /// <summary>
        /// 
        /// </summary>
        public float _43;

        /// <summary>
        /// 
        /// </summary>
        public float _44;
    }
}
