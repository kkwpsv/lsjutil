using Lsj.Util.Win32.Attributes;
using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.ComInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Lsj.Util.Win32.DirectX.ComInterfaces
{
    /// <summary>
    /// <para>
    /// This interface is used to return data of arbitrary length.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/previous-versions/windows/desktop/legacy/ff728743(v=vs.85)"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <para>
    /// An <see cref="ID3DBlob"/> is obtained by calling the <see cref="D3DCreateBlob"/> function.
    /// <see cref="D3DCreateBlob"/> is contained in D3dcompiler.lib or D3dcompiler_nn.dll.
    /// </para>
    /// <para>
    /// The <see cref="ID3DBlob"/> interface is type-defined in the D3DCommon.h header file
    /// as a <see cref="ID3D10Blob"/> interface, which is fully defined in the D3DCommon.h header file.
    /// </para>
    /// <para>
    /// <see cref="ID3DBlob"/> is version-neutral and can be used in code for any Direct3D version.
    /// </para>
    /// <para>
    /// Blobs can be used as data buffers.
    /// Blobs can also be used for storing vertex, adjacency,
    /// and material information during mesh optimization, and for loading operations.
    /// Also, these objects are used to return object code and error messages
    /// in APIs that compile vertex, geometry, and pixel shaders.
    /// </para>
    /// </remarks>
    [WindowsVersionRequirement(WindowsVersion.Windows7)]
    [ComInterface(IID = "8BA5FB08-5195-40e2-AC58-0D989C3A0102", BeginVTableSlotIndex = 3, EndVTableSlotIndex = 4, InheritedFromTypes = [typeof(IUnknown)])]
    public unsafe struct ID3DBlob
    {
        IntPtr* _vTable;

        /// <summary>
        /// Retrieves a pointer to the blob's data.
        /// </summary>
        /// <returns>
        /// Returns a pointer to the blob's data.
        /// </returns>
        /// <remarks>
        /// <para>
        /// The <see cref="ID3DBlob"/> interface is type defined in the D3DCommon.h header file
        /// as a <see cref="ID3D10Blob"/> interface, which is fully defined in the D3DCommon.h header file.
        /// </para>
        /// <code>
        /// typedef ID3D10Blob ID3DBlob;
        /// </code>
        /// <para>
        /// <see cref="ID3DBlob"/> is version neutral and can be used in code for any Direct3D version.
        /// </para>
        /// </remarks>
        public LPVOID GetBufferPointer()
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, LPVOID>)_vTable[3])(thisPtr);
            }
        }

        /// <summary>
        /// Retrieves the size, in bytes, of the blob's data.
        /// </summary>
        /// <returns>
        /// Returns the size of the blob's data, in bytes.
        /// </returns>
        /// <remarks>
        /// <para>
        /// The <see cref="ID3DBlob"/> interface is type defined in the D3DCommon.h header file
        /// as a <see cref="ID3D10Blob"/> interface, which is fully defined in the D3DCommon.h header file.
        /// </para>
        /// <code>
        /// typedef ID3D10Blob ID3DBlob;
        /// </code>
        /// <para>
        /// <see cref="ID3DBlob"/> is version neutral and can be used in code for any Direct3D version.
        /// </para>
        /// </remarks>
        public SIZE_T GetBufferSize()
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, SIZE_T>)_vTable[4])(thisPtr);
            }
        }
    }
}
