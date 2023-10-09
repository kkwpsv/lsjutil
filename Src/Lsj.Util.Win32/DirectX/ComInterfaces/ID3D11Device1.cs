using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.ComInterfaces;
using Lsj.Util.Win32.DirectX.Enums;
using Lsj.Util.Win32.DirectX.Structs;
using Lsj.Util.Win32.Marshals;
using System;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.DirectX.ComInterfaces
{
    /// <summary>
    /// <para>
    /// The device interface represents a virtual adapter; it is used to create resources.
    /// <see cref="ID3D11Device1"/> adds new methods to those in <see cref="ID3D11Device"/>.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d11_1/nn-d3d11_1-id3d11device1"/>
    /// </para>
    /// </summary>
    public unsafe struct ID3D11Device1
    {
        IntPtr* _vTable;

        /// <summary>
        /// Gets an immediate context, which can play back command lists.
        /// </summary>
        /// <param name="ppImmediateContext">
        /// Upon completion of the method, the passed pointer to an <see cref="ID3D11DeviceContext1"/> interface pointer is initialized.
        /// </param>
        /// <remarks>
        /// <see cref="GetImmediateContext1"/> returns an <see cref="ID3D11DeviceContext1"/> object that represents an immediate context.
        /// You can use this immediate context to perform rendering that you want immediately submitted to a device.
        /// For most applications, an immediate context is the primary object that is used to draw your scene.
        /// <see cref="GetImmediateContext1"/> increments the reference count of the immediate context by one.
        /// So, call <see cref="IUnknown.Release"/> on the returned interface pointer when you are done with it to avoid a memory leak.
        /// </remarks>
        public void GetImmediateContext1([Out] out P<ID3D11DeviceContext1> ppImmediateContext)
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, out P<ID3D11DeviceContext1>, HRESULT>)_vTable[42])(thisPtr, out ppImmediateContext);
            }
        }

        /// <summary>
        /// Creates a deferred context, which can record command lists.
        /// </summary>
        /// <param name="ContextFlags">
        /// Reserved for future use.
        /// Pass 0.
        /// </param>
        /// <param name="ppDeferredContext">
        /// Upon completion of the method, the passed pointer to an <see cref="ID3D11DeviceContext1"/> interface pointer is initialized.
        /// </param>
        /// <returns>
        /// Returns <see cref="S_OK"/> if successful; otherwise, returns one of the following:
        /// Returns <see cref="DXGI_ERROR_DEVICE_REMOVED"/> if the graphics adapter has been physically removed from the computer
        /// or a driver upgrade for the graphics adapter has occurred.
        /// If this error occurs, you should destroy and re-create the device.
        /// Returns <see cref="DXGI_ERROR_INVALID_CALL"/> if the <see cref="CreateDeferredContext1"/> method cannot be called from the current context.
        /// For example, if the device was created with the <see cref="D3D11_CREATE_DEVICE_SINGLETHREADED"/> value,
        /// <see cref="CreateDeferredContext1"/> returns <see cref="DXGI_ERROR_INVALID_CALL"/>.
        /// Returns <see cref="E_INVALIDARG"/> if the <paramref name="ContextFlags"/> parameter is invalid.
        /// Returns <see cref="E_OUTOFMEMORY"/> if the application has exhausted available memory.
        /// </returns>
        /// <remarks>
        /// A deferred context is a thread-safe context that you can use to record graphics commands on a thread other than the main rendering thread.
        /// By using a deferred context, you can record graphics commands into a command list that is encapsulated by the <see cref="ID3D11CommandList"/> interface.
        /// After you record all scene items, you can then submit them to the main render thread for final rendering.
        /// In this manner, you can perform rendering tasks concurrently across multiple threads and potentially improve performance in multi-core CPU scenarios.
        /// You can create multiple deferred contexts.
        /// Note
        /// If you use the <see cref="D3D11_CREATE_DEVICE_SINGLETHREADED"/> value to create the device that is represented by <see cref="ID3D11Device1"/>,
        /// the <see cref="CreateDeferredContext1"/> method will fail, and you will not be able to create a deferred context.
        /// For more information about deferred contexts, see Immediate and Deferred Rendering.
        /// Windows Phone 8: This API is supported.
        /// </remarks>
        public HRESULT CreateDeferredContext1([In] UINT ContextFlags, [Out] out P<ID3D11DeviceContext1> ppDeferredContext)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, UINT, out P<ID3D11DeviceContext1>, HRESULT>)_vTable[43])
                    (thisPtr, ContextFlags, out ppDeferredContext);
            }
        }

        /// <summary>
        /// Creates a blend-state object that encapsulates blend state for the output-merger stage and allows the configuration of logic operations.
        /// </summary>
        /// <param name="pBlendStateDesc">
        /// A pointer to a <see cref="D3D11_BLEND_DESC1"/> structure that describes blend state.
        /// </param>
        /// <param name="ppBlendState">
        /// Address of a pointer to the <see cref="ID3D11BlendState1"/> interface for the blend-state object created.
        /// </param>
        /// <returns>
        /// This method returns <see cref="E_OUTOFMEMORY"/> if there is insufficient memory to create the blend-state object.
        /// See Direct3D 11 Return Codes for other possible return values.
        /// </returns>
        /// <remarks>
        /// The logical operations (those that enable bitwise logical operations between pixel shader output and render target contents,
        /// refer to <see cref="D3D11_RENDER_TARGET_BLEND_DESC1"/> ) are only available on certain feature levels;
        /// call <see cref="ID3D11Device.CheckFeatureSupport"/> with <see cref="D3D11_FEATURE_D3D11_OPTIONS"/> set,
        /// to ensure support by checking the boolean field <see cref="D3D11_FEATURE_DATA_D3D11_OPTIONS.OutputMergerLogicOp"/>
        /// of <see cref="D3D11_FEATURE_DATA_D3D11_OPTIONS"/>.
        /// An app can create up to 4096 unique blend-state objects.
        /// For each object created, the runtime checks to see if a previous object has the same state.
        /// If such a previous object exists, the runtime will return a pointer to previous instance instead of creating a duplicate object.
        /// </remarks>
        public HRESULT CreateBlendState1([In] in D3D11_BLEND_DESC1 pBlendStateDesc, [Out] out P<ID3D11BlendState1> ppBlendState)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, in D3D11_BLEND_DESC1, out P<ID3D11BlendState1>, HRESULT>)_vTable[44])
                    (thisPtr, pBlendStateDesc, out ppBlendState);
            }
        }

        /// <summary>
        /// Creates a rasterizer state object that informs the rasterizer stage how to behave and forces the sample count while UAV rendering or rasterizing.
        /// </summary>
        /// <param name="pRasterizerDesc">
        /// A pointer to a <see cref="D3D11_RASTERIZER_DESC1"/> structure that describes the rasterizer state.
        /// </param>
        /// <param name="ppRasterizerState">
        /// Address of a pointer to the <see cref="ID3D11RasterizerState1"/> interface for the rasterizer state object created.
        /// </param>
        /// <returns>
        /// This method returns <see cref="E_OUTOFMEMORY"/> if there is insufficient memory to create the rasterizer state object.
        /// See Direct3D 11 Return Codes for other possible return values.
        /// </returns>
        /// <remarks>
        /// An app can create up to 4096 unique rasterizer state objects.
        /// For each object created, the runtime checks to see if a previous object has the same state.
        /// If such a previous object exists, the runtime will return a pointer to previous instance instead of creating a duplicate object.
        /// </remarks>
        public HRESULT CreateRasterizerState1([In] in D3D11_RASTERIZER_DESC1 pRasterizerDesc, [Out] out P<ID3D11RasterizerState1> ppRasterizerState)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, in D3D11_RASTERIZER_DESC1, out P<ID3D11RasterizerState1>, HRESULT>)_vTable[45])
                    (thisPtr, pRasterizerDesc, out ppRasterizerState);
            }
        }

        /// <summary>
        /// Creates a context state object that holds all Microsoft Direct3D state and some Direct3D behavior.
        /// </summary>
        /// <param name="Flags">
        /// A combination of <see cref="D3D11_1_CREATE_DEVICE_CONTEXT_STATE_FLAG"/> values that are combined by using a bitwise OR operation.
        /// The resulting value specifies how to create the context state object.
        /// The <see cref="D3D11_1_CREATE_DEVICE_CONTEXT_STATE_SINGLETHREADED"/> flag is currently the only defined flag.
        /// If the original device was created with <see cref="D3D11_CREATE_DEVICE_SINGLETHREADED"/>,
        /// you must create all context state objects from that device with the <see cref="D3D11_1_CREATE_DEVICE_CONTEXT_STATE_SINGLETHREADED"/> flag.
        /// If you set the single-threaded flag for both the context state object and the device,
        /// you guarantee that you will call the whole set of context methods and device methods only from one thread.
        /// You therefore do not need to use critical sections to synchronize access to the device context,
        /// and the runtime can avoid working with those processor-intensive critical sections.
        /// </param>
        /// <param name="pFeatureLevels">
        /// A pointer to an array of <see cref="D3D_FEATURE_LEVEL"/> values.
        /// The array can contain elements from the following list and determines the order of feature levels for which creation is attempted.
        /// Unlike <see cref="D3D11CreateDevice"/>, you can't set <paramref name="pFeatureLevels"/> to <see langword="null"/>
        /// because there is no default feature level array.
        /// <code>
        /// {
        ///     D3D_FEATURE_LEVEL_11_1,
        ///     D3D_FEATURE_LEVEL_11_0,
        ///     D3D_FEATURE_LEVEL_10_1,
        ///     D3D_FEATURE_LEVEL_10_0,
        ///     D3D_FEATURE_LEVEL_9_3,
        ///     D3D_FEATURE_LEVEL_9_2,
        ///     D3D_FEATURE_LEVEL_9_1,
        /// };
        /// </code>
        /// </param>
        /// <param name="FeatureLevels">
        /// The number of elements in <paramref name="pFeatureLevels"/>.
        /// Unlike <see cref="D3D11CreateDevice"/>, you must set <paramref name="FeatureLevels"/> to greater than 0
        /// because you can't set <paramref name="pFeatureLevels"/> to <see langword="null"/>.
        /// </param>
        /// <param name="SDKVersion">
        /// The SDK version.
        /// You must set this parameter to <see cref="D3D11_SDK_VERSION"/>.
        /// </param>
        /// <param name="EmulatedInterface">
        /// The globally unique identifier (GUID) for the emulated interface.
        /// This value specifies the behavior of the device when the context state object is active.
        /// Valid values are obtained by using the __uuidof operator on the <see cref="ID3D10Device"/>,
        /// <see cref="ID3D10Device1"/>, <see cref="ID3D11Device"/>, and <see cref="ID3D11Device1"/> interfaces.
        /// See Remarks.
        /// </param>
        /// <param name="pChosenFeatureLevel">
        /// A pointer to a variable that receives a <see cref="D3D_FEATURE_LEVEL"/> value from the <paramref name="pFeatureLevels"/> array.
        /// This is the first array value with which <see cref="CreateDeviceContextState"/> succeeded in creating the context state object.
        /// If the call to <see cref="CreateDeviceContextState"/> fails, the variable pointed to by <paramref name="pChosenFeatureLevel"/> is set to zero.
        /// </param>
        /// <param name="ppContextState">
        /// The address of a pointer to an <see cref="ID3DDeviceContextState"/> object that represents the state of a Direct3D device.
        /// </param>
        /// <returns>
        /// This method returns one of the Direct3D 11 Return Codes.
        /// </returns>
        /// <remarks>
        /// The REFIID value of the emulated interface is a GUID obtained by use of the __uuidof operator.
        /// For example, __uuidof(ID3D11Device) gets the GUID of the interface to a Microsoft Direct3D 11 device.
        /// Call the <see cref="ID3D11DeviceContext1.SwapDeviceContextState"/> method to activate the context state object.
        /// When the context state object is active, the device behaviors that are associated with both the context state object's feature level
        /// and its compatible interface are activated on the Direct3D device until the next call to <see cref="ID3D11DeviceContext1.SwapDeviceContextState"/>.
        /// When a context state object is active, the runtime disables certain methods on the device and context interfaces.
        /// For example, a context state object that is created with __uuidof(ID3D11Device)
        /// will cause the runtime to turn off most of the Microsoft Direct3D 10 device interfaces,
        /// and a context state object that is created with <code>__uuidof(ID3D10Device1)</code> or <code>__uuidof(ID3D10Device)</code>
        /// will cause the runtime to turn off most of the <see cref="ID3D11DeviceContext"/> methods.
        /// This behavior ensures that a user of either emulated interface cannot set device state that the other emulated interface is unable to express.
        /// This restriction helps guarantee that the <see cref="ID3D10Device1"/> emulated interface accurately reflects the full state of the pipeline
        /// and that the emulated interface will not operate contrary to its original interface definition.
        /// For example, suppose the tessellation stage is made active through the <see cref="ID3D11DeviceContext"/> interface
        /// when you create the device through <see cref="D3D11CreateDevice"/> or <see cref="D3D11CreateDeviceAndSwapChain"/>,
        /// instead of through the Direct3D 10 equivalents.
        /// Because the Direct3D 11 context is active, a Direct3D 10 interface is inactive when you first retrieve it via <see cref="IUnknown.QueryInterface"/>.
        /// This means that you cannot immediately pass a Direct3D 10 interface that you retrieved from a Direct3D 11 device to a function.
        /// You must first call <see cref="ID3D11DeviceContext1.SwapDeviceContextState"/> to activate a Direct3D 10-compatible context state object.
        /// </remarks>
        public HRESULT CreateDeviceContextState([In] D3D11_1_CREATE_DEVICE_CONTEXT_STATE_FLAG Flags, [In] D3D_FEATURE_LEVEL[] pFeatureLevels, [In] UINT FeatureLevels,
            [In] UINT SDKVersion, [In] in IID EmulatedInterface, [Out] out D3D_FEATURE_LEVEL pChosenFeatureLevel, [Out] out P<ID3DDeviceContextState> ppContextState)
        {
            fixed (void* thisPtr = &this)
            {
                fixed (D3D_FEATURE_LEVEL* pFeatureLevelsPtr = pFeatureLevels)
                {
                    return ((delegate* unmanaged[Stdcall]<void*, D3D11_1_CREATE_DEVICE_CONTEXT_STATE_FLAG, D3D_FEATURE_LEVEL*, UINT, UINT,
                        in IID, out D3D_FEATURE_LEVEL, out P<ID3DDeviceContextState>, HRESULT>)_vTable[45])
                        (thisPtr, Flags, pFeatureLevelsPtr, FeatureLevels, SDKVersion, EmulatedInterface, out pChosenFeatureLevel, out ppContextState);
                }
            }
        }

        /// <summary>
        /// Gives a device access to a shared resource that is referenced by a handle and that was created on a different device.
        /// You must have previously created the resource as shared and specified that it uses NT handles
        /// (that is, you set the <see cref="D3D11_RESOURCE_MISC_SHARED_NTHANDLE"/> flag).
        /// </summary>
        /// <param name="hResource">
        /// A handle to the resource to open.
        /// For more info about this parameter, see Remarks.
        /// </param>
        /// <param name="ReturnedInterface">
        /// The globally unique identifier (GUID) for the resource interface.
        /// For more info about this parameter, see Remarks.
        /// </param>
        /// <param name="ppResource">
        /// A pointer to a variable that receives a pointer to the interface for the shared resource object to access.
        /// </param>
        /// <returns>
        /// This method returns one of the Direct3D 11 return codes.
        /// This method also returns <see cref="E_ACCESSDENIED"/> if the permissions to access the resource aren't valid.
        /// Platform Update for Windows 7:
        /// On Windows 7 or Windows Server 2008 R2 with the Platform Update for Windows 7 installed,
        /// <see cref="OpenSharedResource1"/> fails with <see cref="E_NOTIMPL"/> because NTHANDLES are used.
        /// For more info about the Platform Update for Windows 7, see Platform Update for Windows 7.
        /// </returns>
        /// <remarks>
        /// The behavior of <see cref="OpenSharedResource1"/> is similar to the behavior of the <see cref="ID3D11Device.OpenSharedResource"/> method;
        /// each call to <see cref="OpenSharedResource1"/> to access a resource creates a new resource object.
        /// In other words, if you call <see cref="OpenSharedResource1"/> twice and pass the same resource handle to <paramref name="hResource"/>,
        /// you receive two resource objects with different <see cref="IUnknown"/> pointers.
        /// To share a resource between two devices
        /// Create the resource as shared and specify that it uses NT handles, by setting the <see cref="D3D11_RESOURCE_MISC_SHARED_NTHANDLE"/> flag.
        /// Obtain the REFIID, or GUID, of the interface to the resource by using the __uuidof() macro.
        /// For example, __uuidof(ID3D11Texture2D) retrieves the GUID of the interface to a 2D texture.
        /// Query the resource for the <see cref="IDXGIResource1"/> interface.
        /// Call the <see cref="IDXGIResource1.CreateSharedHandle"/> method to obtain the unique handle to the resource.
        /// </remarks>
        public HRESULT OpenSharedResource1([In] HANDLE hResource, [In] in IID ReturnedInterface, [Out] out IntPtr ppResource)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, HANDLE, in IID, out IntPtr, HRESULT>)_vTable[46])
                    (thisPtr, hResource, in ReturnedInterface, out ppResource);
            }
        }

        /// <summary>
        /// Gives a device access to a shared resource that is referenced by name and that was created on a different device.
        /// You must have previously created the resource as shared and specified that it uses NT handles
        /// (that is, you set the <see cref="D3D11_RESOURCE_MISC_SHARED_NTHANDLE"/> flag).
        /// </summary>
        /// <param name="lpName">
        /// The name of the resource to open.
        /// This parameter cannot be <see cref="NULL"/>.
        /// </param>
        /// <param name="dwDesiredAccess">
        /// The requested access rights to the resource.
        /// In addition to the generic access rights, DXGI defines the following values:
        /// <see cref="DXGI_SHARED_RESOURCE_READ"/>( 0x80000000L ) - specifies read access to the resource.
        /// <see cref="DXGI_SHARED_RESOURCE_WRITE"/> ( 1 ) - specifies write access to the resource.
        /// You can combine values by using a bitwise OR operation.
        /// </param>
        /// <param name="ReturnedInterface">
        /// The globally unique identifier (GUID) for the resource interface.
        /// For more info, see Remarks.
        /// </param>
        /// <param name="ppResource">
        /// A pointer to a variable that receives a pointer to the interface for the shared resource object to access.
        /// </param>
        /// <returns>
        /// This method returns one of the Direct3D 11 return codes.
        /// This method also returns <see cref="E_ACCESSDENIED"/> if the permissions to access the resource aren't valid.
        /// Platform Update for Windows 7:
        /// On Windows 7 or Windows Server 2008 R2 with the Platform Update for Windows 7 installed,
        /// <see cref="OpenSharedResourceByName"/> fails with <see cref="E_NOTIMPL"/> because NTHANDLES are used.
        /// For more info about the Platform Update for Windows 7, see Platform Update for Windows 7.
        /// </returns>
        /// <remarks>
        /// The behavior of <see cref="OpenSharedResourceByName"/> is similar to the behavior of the <see cref="OpenSharedResource1"/> method;
        /// each call to <see cref="OpenSharedResourceByName"/> to access a resource creates a new resource object.
        /// In other words, if you call <see cref="OpenSharedResourceByName"/> twice and pass the same resource name  to <paramref name="lpName"/>,
        /// you receive two resource objects with different <see cref="IUnknown"/> pointers.
        /// To share a resource between two devices
        /// Create the resource as shared and specify that it uses NT handles, by setting the <see cref="D3D11_RESOURCE_MISC_SHARED_NTHANDLE"/> flag.
        /// Obtain the REFIID, or GUID, of the interface to the resource by using the __uuidof() macro.
        /// For example, __uuidof(ID3D11Texture2D) retrieves the GUID of the interface to a 2D texture.
        /// Query the resource for the <see cref="IDXGIResource1"/> interface.
        /// Call the <see cref="IDXGIResource1.CreateSharedHandle"/> method to obtain the unique handle to the resource.
        /// In this <see cref="IDXGIResource1.CreateSharedHandle"/> call, you must pass a name for the resource
        /// if you want to subsequently call <see cref="OpenSharedResourceByName"/> to access the resource by name.
        /// </remarks>
        public HRESULT OpenSharedResourceByName([In] LPCWSTR lpName, [In] DWORD dwDesiredAccess, [In] in IID ReturnedInterface, [Out] out IntPtr ppResource)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, IntPtr, DWORD, in IID, out IntPtr, HRESULT>)_vTable[47])
                    (thisPtr, lpName.ToIntPtr(), dwDesiredAccess, in ReturnedInterface, out ppResource);
            }
        }
    }
}
