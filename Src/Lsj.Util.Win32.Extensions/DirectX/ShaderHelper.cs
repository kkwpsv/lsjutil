using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.DirectX.ComInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Lsj.Util.Win32.DirectX.D3dcompiler_47;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.DirectX.Constants;
using static Lsj.Util.Win32.UnsafePInvokeExtensions;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.Extensions.DirectX
{
    /// <summary>
    /// Shader helper
    /// </summary>
    public static class ShaderHelper
    {
        /// <summary>
        /// Compile shader
        /// </summary>
        /// <param name="str"></param>
        /// <param name="entrypoint"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public unsafe static P<ID3DBlob> CompileShader(string str, string? entrypoint, string target)
        {
            var buffer = Encoding.ASCII.GetBytes(str);
            fixed (byte* ptr = buffer)
            {
                var hr = D3DCompile((nint)ptr, buffer.Length, NULL, null, D3D_COMPILE_STANDARD_FILE_INCLUDE, entrypoint, target, 0, 0, out var blob,
#if NETFRAMEWORK
                    out NullRef<nint>()
#else
                    out NullRef<P<ID3DBlob>>()
#endif
                    );
                if (hr)
                {
                    return blob;
                }
                else
                {
                    throw Marshal.GetExceptionForHR(hr)!;
                }
            }
        }
    }
}
