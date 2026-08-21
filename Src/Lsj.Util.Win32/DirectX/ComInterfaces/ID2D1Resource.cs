using Lsj.Util.Win32.Attributes;
using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.ComInterfaces;
using System;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.DirectX.ComInterfaces
{
    /// <summary>
    /// <para>
    /// Represents a Direct2D drawing resource.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d2d1/nn-d2d1-id2d1resource"/>
    /// </para>
    /// </summary>
    [WindowsVersionRequirement(WindowsVersion.Windows7)]
    [ComInterface(IID = "2cd90691-12e2-11dc-9fed-001143a055f9", BeginVTableSlotIndex = 3, EndVTableSlotIndex = 3, InheritedFromTypes = [typeof(IUnknown)])]
    public unsafe struct ID2D1Resource
    {
        nint* _vTable;

        /// <summary>
        /// Retrieves the factory associated with this resource.
        /// </summary>
        /// <param name="factory">
        /// When this method returns, contains a pointer to a pointer to the factory that created this resource.
        /// This parameter is passed uninitialized.
        /// </param>
        public void GetFactory([Out] out P<ID2D1Factory> factory)
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, out P<ID2D1Factory>, void>)_vTable[3])(thisPtr, out factory);
            }
        }
    }
}
