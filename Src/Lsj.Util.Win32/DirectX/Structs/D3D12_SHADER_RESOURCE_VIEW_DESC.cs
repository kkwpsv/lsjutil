using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.DirectX.ComInterfaces;
using Lsj.Util.Win32.DirectX.Enums;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.DirectX.Enums.DXGI_FORMAT;
using static Lsj.Util.Win32.DirectX.Macros;

namespace Lsj.Util.Win32.DirectX.Structs
{
    /// <summary>
    /// <para>
    /// Describes a shader-resource view (SRV).
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_shader_resource_view_desc"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <para>
    /// A view is a format-specific way to look at the data in a resource.
    /// The view determines what data to look at, and how it is cast when read.
    /// </para>
    /// <para>
    /// When viewing a resource, the resource-view description must specify a typed format, that is compatible with the resource format.
    /// So that means that you can't create a resource-view description using any format with <c>_TYPELESS</c> in the name.
    /// You can however view a typeless resource by specifying a typed format for the view.
    /// For example, a <see cref="DXGI_FORMAT_R32G32B32_TYPELESS"/> resource can be viewed with one of these typed formats:
    /// <see cref="DXGI_FORMAT_R32G32B32_FLOAT"/>, <see cref="DXGI_FORMAT_R32G32B32_UINT"/>, and <see cref="DXGI_FORMAT_R32G32B32_SINT"/>,
    /// since these typed formats are compatible with the typeless resource.
    /// </para>
    /// <para>
    /// Create a shader-resource-view description by calling <see cref="ID3D12Device.CreateShaderResourceView"/>.
    /// </para>
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct D3D12_SHADER_RESOURCE_VIEW_DESC
    {
        /// <summary>
        /// A <see cref="DXGI_FORMAT"/>-typed value that specifies the viewing format. See remarks.
        /// </summary>
        public DXGI_FORMAT Format;

        /// <summary>
        /// A <see cref="D3D12_SRV_DIMENSION"/>-typed value that specifies the resource type of the view.
        /// This type is the same as the resource type of the underlying resource.
        /// This member also determines which _SRV to use in the union below.
        /// </summary>
        public D3D12_SRV_DIMENSION ViewDimension;

        /// <summary>
        /// A value, constructed using the <see cref="D3D12_ENCODE_SHADER_4_COMPONENT_MAPPING"/> macro.
        /// The <see cref="D3D12_SHADER_COMPONENT_MAPPING"/> enumeration specifies what values from memory should be returned
        /// when the texture is accessed in a shader via this shader resource view (SRV).
        /// For example, it can route component 1 (green) from memory, or the constant <c>0</c>,
        /// into component 2 (<c>.b</c>) of the value given to the shader.
        /// </summary>
        public UINT Shader4ComponentMapping;

        private D3D12_SHADER_RESOURCE_VIEW_DESC_UNION _union;

        /// <summary>
        /// A <see cref="D3D12_BUFFER_SRV"/> structure that views the resource as a buffer.
        /// </summary>
        [UnscopedRef]
        public ref D3D12_BUFFER_SRV Buffer => ref _union.Buffer;

        /// <summary>
        /// A <see cref="D3D12_TEX1D_SRV"/> structure that views the resource as a 1D texture.
        /// </summary>
        [UnscopedRef]
        public ref D3D12_TEX1D_SRV Texture1D => ref _union.Texture1D;

        /// <summary>
        /// A <see cref="D3D12_TEX1D_ARRAY_SRV"/> structure that views the resource as a 1D-texture array.
        /// </summary>
        [UnscopedRef]
        public ref D3D12_TEX1D_ARRAY_SRV Texture1DArray => ref _union.Texture1DArray;

        /// <summary>
        /// A <see cref="D3D12_TEX2D_SRV"/> structure that views the resource as a 2D-texture.
        /// </summary>
        [UnscopedRef]
        public ref D3D12_TEX2D_SRV Texture2D => ref _union.Texture2D;

        /// <summary>
        /// A <see cref="D3D12_TEX2D_ARRAY_SRV"/> structure that views the resource as a 2D-texture array.
        /// </summary>
        [UnscopedRef]
        public ref D3D12_TEX2D_ARRAY_SRV Texture2DArray => ref _union.Texture2DArray;

        /// <summary>
        /// A <see cref="D3D12_TEX2DMS_SRV"/> structure that views the resource as a 2D-multisampled texture.
        /// </summary>
        [UnscopedRef]
        public ref D3D12_TEX2DMS_SRV Texture2DMS => ref _union.Texture2DMS;

        /// <summary>
        /// A <see cref="D3D12_TEX2DMS_ARRAY_SRV"/> structure that views the resource as a 2D-multisampled-texture array.
        /// </summary>
        [UnscopedRef]
        public ref D3D12_TEX2DMS_ARRAY_SRV Texture2DMSArray => ref _union.Texture2DMSArray;

        /// <summary>
        /// A <see cref="D3D12_TEX3D_SRV"/> structure that views the resource as a 3D texture.
        /// </summary>
        [UnscopedRef]
        public ref D3D12_TEX3D_SRV Texture3D => ref _union.Texture3D;

        /// <summary>
        /// A <see cref="D3D12_TEXCUBE_SRV"/> structure that views the resource as a 3D-cube texture.
        /// </summary>
        [UnscopedRef]
        public ref D3D12_TEXCUBE_SRV TextureCube => ref _union.TextureCube;

        /// <summary>
        /// A <see cref="D3D12_TEXCUBE_ARRAY_SRV"/> structure that views the resource as a 3D-cube-texture array.
        /// </summary>
        [UnscopedRef]
        public ref D3D12_TEXCUBE_ARRAY_SRV TextureCubeArray => ref _union.TextureCubeArray;

        /// <summary>
        /// A <see cref="D3D12_RAYTRACING_ACCELERATION_STRUCTURE_SRV"/> structure
        /// that views the resource as a raytracing acceleration structure.
        /// </summary>
        [UnscopedRef]
        public ref D3D12_RAYTRACING_ACCELERATION_STRUCTURE_SRV RaytracingAccelerationStructure
            => ref _union.RaytracingAccelerationStructure;

        internal struct D3D12_SHADER_RESOURCE_VIEW_DESC_UNION
        {
            public D3D12_BUFFER_SRV Buffer;
            public D3D12_TEX1D_SRV Texture1D;
            public D3D12_TEX1D_ARRAY_SRV Texture1DArray;
            public D3D12_TEX2D_SRV Texture2D;
            public D3D12_TEX2D_ARRAY_SRV Texture2DArray;
            public D3D12_TEX2DMS_SRV Texture2DMS;
            public D3D12_TEX2DMS_ARRAY_SRV Texture2DMSArray;
            public D3D12_TEX3D_SRV Texture3D;
            public D3D12_TEXCUBE_SRV TextureCube;
            public D3D12_TEXCUBE_ARRAY_SRV TextureCubeArray;
            public D3D12_RAYTRACING_ACCELERATION_STRUCTURE_SRV RaytracingAccelerationStructure;
        }
    }
}
