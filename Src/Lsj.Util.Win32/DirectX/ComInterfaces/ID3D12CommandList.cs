using Lsj.Util.Win32.Attributes;
using Lsj.Util.Win32.ComInterfaces;
using Lsj.Util.Win32.DirectX.Enums;
using System;

namespace Lsj.Util.Win32.DirectX.ComInterfaces
{
    /// <summary>
    /// <para>
    /// An interface from which <see cref="ID3D12GraphicsCommandList"/> inherits.
    /// It represents an ordered set of commands that the GPU executes,
    ///  while allowing for extension to support other command lists than just those for graphics (such as compute and copy).
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nn-d3d12-id3d12commandlist"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <para>
    /// Use <see cref="ID3D12Device.CreateCommandList"/> to create a command list object.
    /// </para>
    /// <para>
    /// See also <see cref="ID3D12GraphicsCommandList"/>, which derives from <see cref="ID3D12CommandList"/>.
    /// </para>
    /// <para>
    /// A command list corresponds to a set of commands that the graphics processing unit (GPU) executes.
    /// Commands set state, draw, clear, copy, and so on.
    /// </para>
    /// <para>
    /// Direct3D 12 command lists only support these 2 levels of indirection:
    /// </para>
    /// <para>
    /// <list type="bullet">
    /// <item>
    /// <description>
    /// A direct command list corresponds to a command buffer that the GPU can execute.
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// A bundle can be executed only directly via a direct command list.
    /// </description>
    /// </item>
    /// </list>
    /// </para>
    /// </remarks>
    [ComInterface(IID = "7116d91c-e7e4-47ce-b8c6-ec8168f437e5", BeginVTableSlotIndex = 8, EndVTableSlotIndex = 8,
        InheritedFromTypes = [typeof(IUnknown), typeof(ID3D12Object), typeof(ID3D12DeviceChild)])]
    public unsafe struct ID3D12CommandList
    {
        IntPtr* _vTable;

        /// <summary>
        /// Gets the type of the command list, such as direct, bundle, compute, or copy.
        /// </summary>
        /// <returns>
        /// This method returns the type of the command list, as a <see cref="D3D12_COMMAND_LIST_TYPE"/> enumeration constant,
        /// such as direct, bundle, compute, or copy.
        /// </returns>
        public new D3D12_COMMAND_LIST_TYPE GetType()
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, D3D12_COMMAND_LIST_TYPE>)_vTable[8])(thisPtr);
            }
        }
    }
}
