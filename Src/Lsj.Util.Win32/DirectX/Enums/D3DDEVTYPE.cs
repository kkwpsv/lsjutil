using Lsj.Util.Win32.DirectX.ComInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lsj.Util.Win32.DirectX.Enums
{
    /// <summary>
    /// <para>
    /// Defines device types.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/direct3d9/d3ddevtype"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// All methods of the <see cref="IDirect3D9"/> interface that take a <see cref="D3DDEVTYPE"/> device type will fail if <see cref="D3DDEVTYPE_NULLREF"/> is specified.
    /// To use these methods, substitute <see cref="D3DDEVTYPE_REF"/> in the method call.
    /// A <see cref="D3DDEVTYPE_REF"/> device should be created in <see cref="D3DPOOL_SCRATCH"/> memory, unless vertex and index buffers are required.
    /// To support vertex and index buffers, create the device in <see cref="D3DPOOL_SYSTEMMEM"/> memory.
    /// If D3dref9.dll is installed, Direct3D will use the reference rasterizer to create a <see cref="D3DDEVTYPE_REF"/> device type,
    /// even if <see cref="D3DDEVTYPE_NULLREF"/> is specified.
    /// If D3dref9.dll is not available and <see cref="D3DDEVTYPE_NULLREF"/> is specified, Direct3D will neither render nor present the scene.
    /// </remarks>
    public enum D3DDEVTYPE
    {
        /// <summary>
        /// Hardware rasterization.
        /// Shading is done with software, hardware, or mixed transform and lighting.
        /// </summary>
        D3DDEVTYPE_HAL = 1,

        /// <summary>
        /// Initialize Direct3D on a computer that has neither hardware nor reference rasterization available, and enable resources for 3D content creation.
        /// See Remarks.
        /// </summary>
        D3DDEVTYPE_NULLREF = 4,

        /// <summary>
        /// Direct3D features are implemented in software; however, the reference rasterizer does make use of special CPU instructions whenever it can.
        /// The reference device is installed by the Windows SDK 8.0 or later and is intended as an aid in debugging for development only.
        /// </summary>
        D3DDEVTYPE_REF = 2,

        /// <summary>
        /// A pluggable software device that has been registered with <see cref="IDirect3D9.RegisterSoftwareDevice"/>.
        /// </summary>
        D3DDEVTYPE_SW = 3,

        /// <summary>
        /// Forces this enumeration to compile to 32 bits in size.
        /// Without this value, some compilers would allow this enumeration to compile to a size other than 32 bits.
        /// This value is not used.
        /// </summary>
        D3DDEVTYPE_FORCE_DWORD = unchecked((int)0xffffffff),
    }
}
