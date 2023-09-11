using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.DirectX.Structs;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.HRESULT;
using static Lsj.Util.Win32.DirectX.D3D11;
using static Lsj.Util.Win32.UnsafePInvokeExtensions;

namespace Lsj.Util.Win32.DirectX.ComInterfaces
{
    /// <summary>
    /// <para>
    /// The device interface represents a virtual adapter; it is used to create resources.
    /// Note
    /// The latest version of this interface is <see cref="ID3D11Device5"/> introduced in the Windows 10 Creators Update.
    /// Applications targetting Windows 10 Creators Update should use the <see cref="ID3D11Device5"/> interface instead of <see cref="ID3D11Device"/>.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nn-d3d11-id3d11device"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// A device is created using <see cref="D3D11CreateDevice"/>.
    /// Windows Phone 8: This API is supported.
    /// </remarks>
    public unsafe struct ID3D11Device
    {
        IntPtr* _vTable;

        /// <summary>
        /// Creates a buffer (vertex buffer, index buffer, or shader-constant buffer).
        /// </summary>
        /// <param name="pDesc">
        /// A pointer to a <see cref="D3D11_BUFFER_DESC"/> structure that describes the buffer.
        /// </param>
        /// <param name="pInitialData">
        /// A pointer to a <see cref="D3D11_SUBRESOURCE_DATA"/> structure that describes the initialization data;
        /// use <see cref="NullRef{D3D11_SUBRESOURCE_DATA}"/> to allocate space only
        /// (with the exception that it cannot be <see cref="NullRef{D3D11_SUBRESOURCE_DATA}"/> if the usage flag is <see cref="D3D11_USAGE_IMMUTABLE"/>).
        /// If you don't pass anything to <paramref name="pInitialData"/>, the initial content of the memory for the buffer is undefined.
        /// In this case, you need to write the buffer content some other way before the resource is read.
        /// </param>
        /// <param name="ppBuffer">
        /// Address of a pointer to the <see cref="ID3D11Buffer"/> interface for the buffer object created.
        /// Set this parameter to NULL to validate the other input parameters (<see cref="S_FALSE"/> indicates a pass).
        /// </param>
        /// <returns>
        /// This method returns <see cref="E_OUTOFMEMORY"/> if there is insufficient memory to create the buffer.
        /// See Direct3D 11 Return Codes for other possible return values.
        /// </returns>
        /// <remarks>
        /// For example code, see How to: Create a Vertex Buffer, How to: Create an Index Buffer or How to: Create a Constant Buffer.
        /// For a constant buffer (<see cref="D3D11_BUFFER_DESC.BindFlags"/> of <see cref="D3D11_BUFFER_DESC"/> set to <see cref="D3D11_BIND_CONSTANT_BUFFER"/>),
        /// you must set the <see cref="D3D11_BUFFER_DESC.ByteWidth"/> value of <see cref="D3D11_BUFFER_DESC"/> in multiples of 16,
        /// and less than or equal to <see cref="D3D11_REQ_CONSTANT_BUFFER_ELEMENT_COUNT"/>.
        /// The Direct3D 11.1 runtime, which is available on Windows 8 and later operating systems,
        /// provides the following new functionality for <see cref="CreateBuffer"/>:
        /// You can create a constant buffer that is larger than the maximum constant buffer size that a shader can access (4096 32-bit*4-component constants – 64KB).
        /// When you bind the constant buffer to the pipeline (for example, via <see cref="PSSetConstantBuffers"/> or <see cref="PSSetConstantBuffers1"/>),
        /// you can define a range of the buffer that the shader can access that fits within the 4096 constant limit.
        /// The Direct3D 11.1 runtime (available in Windows 8 and later operating systems) emulates this feature for feature level 9.1, 9.2, and 9.3;
        /// therefore, this feature is supported for feature level 9.1, 9.2, and 9.3.
        /// This feature is always available on new drivers for feature level 10 and higher.
        /// On runtimes older than Direct3D 11.1, a call to <see cref="CreateBuffer"/> to request a constant buffer that is larger than 4096 fails.
        /// </remarks>
        public HRESULT CreateBuffer([In] in D3D11_BUFFER_DESC pDesc, [In] in D3D11_SUBRESOURCE_DATA pInitialData, [Out] out P<ID3D11Buffer> ppBuffer)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, in D3D11_BUFFER_DESC, in D3D11_SUBRESOURCE_DATA, out P<ID3D11Buffer>, HRESULT>)_vTable[3])
                    (thisPtr, pDesc, pInitialData, out ppBuffer);
            }
        }
    }
}
