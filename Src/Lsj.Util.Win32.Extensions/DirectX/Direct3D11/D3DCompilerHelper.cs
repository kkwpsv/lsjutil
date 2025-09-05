using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.DirectX;
using Lsj.Util.Win32.DirectX.ComInterfaces;
using System.Runtime.InteropServices;
using System.Text;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.UnsafePInvokeExtensions;

namespace Lsj.Util.Win32.Extensions.DirectX.Direct3D11
{
    /// <summary>
    /// D3DCompiler helper
    /// </summary>
    public static class D3DCompilerHelper
    {
        public static HRESULT Complie(string code, string entrypoint, string target, out P<ID3DBlob> codeBlob, out P<ID3DBlob> errorBlob)
        {
            var data = Encoding.ASCII.GetBytes(code);
            unsafe
            {
                fixed (byte* ptr = data)
                {
                    return D3dcompiler_47.D3DCompile((nint)ptr, data.Length, NULL, null, NULL, entrypoint, target, 0, 0, out codeBlob, out errorBlob);
                }
            }
        }
    }
}
