using Lsj.Util.Win32.Attributes;
using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.ComInterfaces;
using System;
using static Lsj.Util.Win32.BaseTypes.BOOL;
using static Lsj.Util.Win32.DirectX.Enums.DXGI_SWAP_CHAIN_FLAG;

namespace Lsj.Util.Win32.DirectX.ComInterfaces
{
    /// <summary>
    /// <para>
    /// Represents an adapter output (such as a monitor).
    /// The <see cref="IDXGIOutput2"/> interface exposes a method
    /// to check for multiplane overlay support on the primary output adapter.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/dxgi1_3/nn-dxgi1_3-idxgioutput2"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// To determine the outputs that are available from the adapter, use <see cref="IDXGIAdapter.EnumOutputs"/>.
    /// To determine the specific output that the swap chain will update,
    /// use <see cref="IDXGISwapChain.GetContainingOutput"/>.
    /// You can then call <see cref="IUnknown.QueryInterface"/> from any <see cref="IDXGIOutput"/>
    /// or <see cref="IDXGIOutput1"/> object to obtain an <see cref="IDXGIOutput2"/> object.
    /// </remarks>
    [WindowsVersionRequirement(WindowsVersion.Windows8_1)]
    [ComInterface(IID = "595e39d1-2724-4663-99b1-da969de28364", BeginVTableSlotIndex = 23, EndVTableSlotIndex = 23,
        InheritedFromTypes = [typeof(IUnknown), typeof(IDXGIObject), typeof(IDXGIOutput), typeof(IDXGIOutput1)])]
    public unsafe struct IDXGIOutput2
    {
        nint* _vTable;

        /// <summary>
        /// Queries an adapter output for multiplane overlay support.
        /// If this API returns <see cref="TRUE"/>,
        /// multiple swap chain composition takes place in a performant manner using overlay hardware.
        /// If this API returns <see cref="FALSE"/>,
        /// apps should avoid using foreground swap chains
        /// (that is, avoid using swap chains created with the <see cref="DXGI_SWAP_CHAIN_FLAG_FOREGROUND_LAYER"/> flag).
        /// </summary>
        /// <returns>
        /// <see cref="TRUE"/> if the output adapter is the primary adapter
        /// and it supports multiplane overlays, otherwise returns <see cref="FALSE"/>.
        /// </returns>
        /// <remarks>
        /// See <see cref="IDXGIFactory2.CreateSwapChainForCoreWindow"/> for info on creating a foreground swap chain.
        /// </remarks>
        public BOOL SupportsOverlays()
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, BOOL>)_vTable[23])(thisPtr);
            }
        }
    }
}
