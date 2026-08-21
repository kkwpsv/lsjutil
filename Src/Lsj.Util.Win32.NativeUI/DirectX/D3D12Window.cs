using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.ComInterfaces;
using Lsj.Util.Win32.DirectX.ComInterfaces;
using Lsj.Util.Win32.DirectX.Structs;
using Lsj.Util.Win32.Enums;
using Lsj.Util.Win32.Extensions.COM;
using Lsj.Util.Win32.Structs;
using System;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.DirectX.D3D12;
using static Lsj.Util.Win32.DirectX.DXGI;
using static Lsj.Util.Win32.DirectX.Enums.D3D_FEATURE_LEVEL;
using static Lsj.Util.Win32.DirectX.Enums.D3D12_COMMAND_LIST_TYPE;
using static Lsj.Util.Win32.DirectX.Enums.D3D12_COMMAND_QUEUE_FLAGS;
using static Lsj.Util.Win32.DirectX.Enums.D3D12_DESCRIPTOR_HEAP_FLAGS;
using static Lsj.Util.Win32.DirectX.Enums.D3D12_DESCRIPTOR_HEAP_TYPE;
using static Lsj.Util.Win32.DirectX.Enums.D3D12_FENCE_FLAGS;
using static Lsj.Util.Win32.DirectX.Enums.DXGI_FORMAT;
using static Lsj.Util.Win32.DirectX.Enums.DXGI_SWAP_EFFECT;
using static Lsj.Util.Win32.DirectX.Enums.DXGI_USAGE;
using static Lsj.Util.Win32.Kernel32;
using static Lsj.Util.Win32.UnsafePInvokeExtensions;

namespace Lsj.Util.Win32.NativeUI.DirectX
{
    /// <summary>
    /// Direct3D12 window
    /// </summary>
    public class D3D12Window : Win32Window
    {
        /// <summary>
        /// Number of swap chain back buffers / command allocators
        /// </summary>
        public const int FrameCount = 2;

        /// <summary>
        /// The D3D12 device
        /// </summary>
        public P<ID3D12Device> Device { get; private set; }

        /// <summary>
        /// The graphics command queue
        /// </summary>
        public P<ID3D12CommandQueue> CommandQueue { get; private set; }

        /// <summary>
        /// The swap chain
        /// </summary>
        public P<IDXGISwapChain3> SwapChain3 { get; private set; }

        /// <summary>
        /// The RTV descriptor heap
        /// </summary>
        public P<ID3D12DescriptorHeap> RtvHeap { get; private set; }

        /// <summary>
        /// The per-frame render target resources
        /// </summary>
        public P<ID3D12Resource>[] RenderTargets { get; private set; } = new P<ID3D12Resource>[FrameCount];

        /// <summary>
        /// The per-frame command allocators
        /// </summary>
        public P<ID3D12CommandAllocator>[] CommandAllocators { get; private set; } = new P<ID3D12CommandAllocator>[FrameCount];

        /// <summary>
        /// The graphics command list (reused every frame)
        /// </summary>
        public P<ID3D12GraphicsCommandList> CommandList { get; private set; }

        /// <summary>
        /// The synchronization fence
        /// </summary>
        public P<ID3D12Fence> Fence { get; private set; }

        /// <summary>
        /// Per-frame fence values for synchronization
        /// </summary>
        public ulong[] FenceValues { get; private set; } = new ulong[FrameCount];

        /// <summary>
        /// Win32 event handle used to wait for fence completion
        /// </summary>
        public IntPtr FenceEvent { get; private set; }

        /// <summary>
        /// Current back buffer index
        /// </summary>
        public uint FrameIndex { get; private set; }

        /// <summary>
        /// Is Initiated
        /// </summary>
        public bool IsInitiated { get; private set; }

        /// <summary>
        /// Init D3D12
        /// </summary>
        public bool InitD3D12()
        {
            if (IsInitiated)
            {
                return false;
            }

            if (Device != NULL)
            {
                Device.AsIUnknown().Value.Release();
            }
            var device = CreateD3D12Device();
            if (device == NULL)
            {
                return false;
            }
            Device = device;

            var queueDesc = new D3D12_COMMAND_QUEUE_DESC
            {
                Type = D3D12_COMMAND_LIST_TYPE_DIRECT,
                Flags = D3D12_COMMAND_QUEUE_FLAG_NONE,
            };
            var hr = device.Value.CreateCommandQueue(queueDesc, IIDs.IID_ID3D12CommandQueue, out var pCommandQueue);
            if (!hr)
            {
                return false;
            }
            if (CommandQueue != NULL)
            {
                CommandQueue.AsIUnknown().Value.Release();
            }
            CommandQueue = (P<ID3D12CommandQueue>)pCommandQueue;

            hr = CreateDXGIFactory2(0, IIDs.IID_IDXGIFactory2, out var factory);
            if (!hr)
            {
                return false;
            }

            var swapChainDesc = new DXGI_SWAP_CHAIN_DESC1
            {
                BufferCount = FrameCount,
                BufferUsage = DXGI_USAGE_RENDER_TARGET_OUTPUT,
                Format = DXGI_FORMAT_R8G8B8A8_UNORM,
                SwapEffect = DXGI_SWAP_EFFECT_FLIP_DISCARD,
                SampleDesc = new DXGI_SAMPLE_DESC { Count = 1 },
            };
            hr = factory.Value.CreateSwapChainForHwnd(
                CommandQueue.AsIUnknown(), Handle, swapChainDesc,
                NullRef<DXGI_SWAP_CHAIN_FULLSCREEN_DESC>(), NULL, out var swapChain1);
            factory.AsIUnknown().Value.Release();
            if (!hr)
            {
                return false;
            }
            SwapChain3 = swapChain1.AsIUnknown().ToInterface<IDXGISwapChain3>(IIDs.IID_IDXGISwapChain3, true, true);
            FrameIndex = SwapChain3.Value.GetCurrentBackBufferIndex();

            var rtvHeapDesc = new D3D12_DESCRIPTOR_HEAP_DESC
            {
                NumDescriptors = FrameCount,
                Type = D3D12_DESCRIPTOR_HEAP_TYPE_RTV,
                Flags = D3D12_DESCRIPTOR_HEAP_FLAG_NONE,
            };
            hr = device.Value.CreateDescriptorHeap(rtvHeapDesc, IIDs.IID_ID3D12DescriptorHeap, out var pRtvHeap);
            if (!hr)
            {
                return false;
            }
            RtvHeap = (P<ID3D12DescriptorHeap>)pRtvHeap;

            if (!CreateRenderTargets())
            {
                return false;
            }

            for (int i = 0; i < FrameCount; i++)
            {
                hr = device.Value.CreateCommandAllocator(D3D12_COMMAND_LIST_TYPE_DIRECT,
                    IIDs.IID_ID3D12CommandAllocator, out var pAlloc);
                if (!hr)
                {
                    return false;
                }
                CommandAllocators[i] = (P<ID3D12CommandAllocator>)pAlloc;
            }

            hr = device.Value.CreateCommandList(0, D3D12_COMMAND_LIST_TYPE_DIRECT,
                CommandAllocators[FrameIndex], NULL, IIDs.IID_ID3D12GraphicsCommandList, out var pCommandList);
            if (!hr)
            {
                return false;
            }
            CommandList = (P<ID3D12GraphicsCommandList>)pCommandList;
            CommandList.Value.Close();

            hr = device.Value.CreateFence(0, D3D12_FENCE_FLAG_NONE, IIDs.IID_ID3D12Fence, out var pFence);
            if (!hr)
            {
                return false;
            }
            Fence = (P<ID3D12Fence>)pFence;

            FenceEvent = CreateEvent(NullRef<SECURITY_ATTRIBUTES>(), false, false, NULL);
            if (FenceEvent == IntPtr.Zero)
            {
                return false;
            }

            FenceValues[FrameIndex] = 1;

            if (!OnAfterInitD3D12(Handle))
            {
                return false;
            }

            IsInitiated = true;
            return true;
        }

        /// <summary>
        /// Called after D3D12 has been fully initialized. Override to create app-specific resources.
        /// </summary>
        protected virtual bool OnAfterInitD3D12(HWND hWnd)
        {
            return true;
        }

        /// <summary>
        /// Waits until all pending GPU work is finished.
        /// </summary>
        public void WaitForGpu()
        {
            if (CommandQueue == NULL || Fence == NULL || FenceEvent == IntPtr.Zero)
            {
                return;
            }

            var waitValue = FenceValues[FrameIndex];
            CommandQueue.Value.Signal(Fence, waitValue);
            Fence.Value.SetEventOnCompletion(waitValue, FenceEvent);
            WaitForSingleObject(FenceEvent, unchecked((uint)-1));
            FenceValues[FrameIndex]++;
        }

        /// <summary>
        /// Signals fence for the current frame and advances to the next frame index.
        /// Call this after Present.
        /// </summary>
        public void MoveToNextFrame()
        {
            var currentFenceValue = FenceValues[FrameIndex];
            CommandQueue.Value.Signal(Fence, currentFenceValue);

            FrameIndex = SwapChain3.Value.GetCurrentBackBufferIndex();

            // If the next frame's previous work is not yet done, wait
            if (Fence.Value.GetCompletedValue() < FenceValues[FrameIndex])
            {
                Fence.Value.SetEventOnCompletion(FenceValues[FrameIndex], FenceEvent);
                WaitForSingleObject(FenceEvent, unchecked((uint)-1));
            }

            FenceValues[FrameIndex] = currentFenceValue + 1;
        }

        /// <inheritdoc/>
        protected override LRESULT OnDestroy(HWND hWnd, WPARAM wParam, LPARAM lParam)
        {
            WaitForGpu();

            if (FenceEvent != IntPtr.Zero)
            {
                CloseHandle(FenceEvent);
                FenceEvent = IntPtr.Zero;
            }

            for (int i = 0; i < FrameCount; i++)
            {
                if (RenderTargets[i] != NULL)
                {
                    RenderTargets[i].AsIUnknown().Value.Release();
                    RenderTargets[i] = NULL;
                }
                if (CommandAllocators[i] != NULL)
                {
                    CommandAllocators[i].AsIUnknown().Value.Release();
                    CommandAllocators[i] = NULL;
                }
            }

            if (CommandList != NULL)
            {
                CommandList.AsIUnknown().Value.Release();
                CommandList = NULL;
            }
            if (Fence != NULL)
            {
                Fence.AsIUnknown().Value.Release();
                Fence = NULL;
            }
            if (RtvHeap != NULL)
            {
                RtvHeap.AsIUnknown().Value.Release();
                RtvHeap = NULL;
            }
            if (SwapChain3 != NULL)
            {
                SwapChain3.AsIUnknown().Value.Release();
                SwapChain3 = NULL;
            }
            if (CommandQueue != NULL)
            {
                CommandQueue.AsIUnknown().Value.Release();
                CommandQueue = NULL;
            }
            if (Device != NULL)
            {
                Device.AsIUnknown().Value.Release();
                Device = NULL;
            }

            return base.OnDestroy(hWnd, wParam, lParam);
        }

        /// <inheritdoc/>
        protected override LRESULT OnSize(HWND hWnd, WPARAM wParam, LPARAM lParam, WindowSizingTypes sizingType, int width, int height)
        {
            if (sizingType == WindowSizingTypes.SIZE_MINIMIZED)
            {
                return 0;
            }

            if (!IsInitiated)
            {
                return 0;
            }

            WaitForGpu();

            for (int i = 0; i < FrameCount; i++)
            {
                if (RenderTargets[i] != NULL)
                {
                    RenderTargets[i].AsIUnknown().Value.Release();
                    RenderTargets[i] = NULL;
                }
                FenceValues[i] = FenceValues[FrameIndex];
            }

            SwapChain3.As<IDXGISwapChain>().ResizeBuffers(FrameCount, (uint)width, (uint)height, DXGI_FORMAT_UNKNOWN, default);

            FrameIndex = SwapChain3.Value.GetCurrentBackBufferIndex();
            CreateRenderTargets();

            return 0;
        }

        private bool CreateRenderTargets()
        {
            var rtvDescriptorSize = Device.Value.GetDescriptorHandleIncrementSize(D3D12_DESCRIPTOR_HEAP_TYPE_RTV);
            var rtvHandle = RtvHeap.Value.GetCPUDescriptorHandleForHeapStart();
            for (uint i = 0; i < FrameCount; i++)
            {
                var hr = SwapChain3.As<IDXGISwapChain>().GetBuffer(i, IIDs.IID_ID3D12Resource, out var pBuffer);
                if (!hr)
                {
                    return false;
                }

                P<ID3D12Resource> buffer = (P<ID3D12Resource>)pBuffer;
                var handle = new D3D12_CPU_DESCRIPTOR_HANDLE
                {
                    ptr = (nint)rtvHandle.ptr + i * rtvDescriptorSize,
                };

                Device.Value.CreateRenderTargetView(buffer, NullRef<D3D12_RENDER_TARGET_VIEW_DESC>(), handle);
                RenderTargets[i] = buffer;
            }
            return true;
        }

        /// <summary>
        /// Create the D3D12 device. Override to customize feature level or adapter selection.
        /// </summary>
        protected virtual P<ID3D12Device> CreateD3D12Device()
        {
            D3D12CreateDevice(NULL, D3D_FEATURE_LEVEL_11_0, IIDs.IID_ID3D12Device, out var pDevice);
            return (P<ID3D12Device>)pDevice;
        }
    }
}
