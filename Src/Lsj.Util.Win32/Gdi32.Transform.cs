using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Structs;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.BOOL;

namespace Lsj.Util.Win32
{
    public partial class Gdi32
    {
        /// <summary>
        /// <para>
        /// The <see cref="CombineTransform"/> function concatenates two world-space to page-space transformations.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-combinetransform"/>
        /// </para>
        /// </summary>
        /// <param name="lpxfOut">
        /// A pointer to an <see cref="XFORM"/> structure that receives the combined transformation.
        /// </param>
        /// <param name="lpxf1">
        /// A pointer to an <see cref="XFORM"/> structure that specifies the first transformation.
        /// </param>
        /// <param name="lpxf2">
        /// A pointer to an <see cref="XFORM"/> structure that specifies the second transformation.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// </returns>
        /// <remarks>
        /// Applying the combined transformation has the same effect
        /// as applying the first transformation and then applying the second transformation.
        /// The three transformations need not be distinct.
        /// For example, <paramref name="lpxf1"/> can point to the same <see cref="XFORM"/> structure as <paramref name="lpxfOut"/>.
        /// </remarks>
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "CombineTransform", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL CombineTransform([Out] out XFORM lpxfOut, [In] in XFORM lpxf1, [In] in XFORM lpxf2);
    }
}
