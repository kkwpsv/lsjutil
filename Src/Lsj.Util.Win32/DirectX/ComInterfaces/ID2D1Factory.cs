using Lsj.Util.Win32.Attributes;
using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.ComInterfaces;
using Lsj.Util.Win32.DirectX.Enums;
using Lsj.Util.Win32.DirectX.Structs;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.HRESULT;
using static Lsj.Util.Win32.DirectX.Enums.D2D1_ALPHA_MODE;
using static Lsj.Util.Win32.DirectX.Enums.D2D1_FEATURE_LEVEL;
using static Lsj.Util.Win32.DirectX.Enums.D2D1_FILL_MODE;
using static Lsj.Util.Win32.DirectX.Enums.D2DERR;
using static Lsj.Util.Win32.DirectX.Enums.DXGI_FORMAT;
using static Lsj.Util.Win32.User32;

namespace Lsj.Util.Win32.DirectX.ComInterfaces
{
    /// <summary>
    /// <para>
    /// Creates Direct2D resources.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d2d1/nn-d2d1-id2d1factory"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <para>
    /// The <see cref="ID2D1Factory"/> interface is the starting point for using Direct2D;
    /// it's what you use to create other Direct2D resources that you can use to draw or describe shapes.
    /// </para>
    /// <para>
    /// A factory defines a set of CreateResource methods that can produce the following drawing resources:
    /// </para>
    /// <para>
    /// <list type="bullet">
    /// <item>
    /// <description>
    /// Render targets: objects that render drawing commands.
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// Drawing state blocks: objects that store drawing state information,
    /// such as the current transformation and antialiasing mode.
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// Geometries: objects that represent simple and potentially complex shapes.
    /// </description>
    /// </item>
    /// </list>
    /// </para>
    /// <para>
    /// To create an <see cref="ID2D1Factory"/>, you use one of the <c>CreateFactory</c> methods.
    /// You should retain the <see cref="ID2D1Factory"/> instance for as long as you use Direct2D resources;
    /// in general, you shouldn't need to recreate it when the application is running.
    /// For more information about Direct2D resources, see the Resources Overview.
    /// </para>
    /// <para>
    /// Singlethreaded and Multithreaded Factories
    /// </para>
    /// <para>
    /// When you create a factory, you can specify whether it is multithreaded or singlethreaded.
    /// A singlethreaded factory provides no serialization against any other single threaded instance within Direct2D,
    /// so, this mechanism provides a very large degree of scaling on the CPU.
    /// </para>
    /// <para>
    /// You can also create a multithreaded factory instance.
    /// In this case, the factory and all derived objects can be used from any thread
    /// and each render target can be rendered to independently.
    /// Direct2D serializes calls to these objects,
    /// so a single multithreaded Direct2D instance won't scale as well on the CPU as many single threaded instances.
    /// However, the resources can be shared within the multithreaded instance.
    /// </para>
    /// <para>
    /// Note that the qualifier "On the CPU":
    /// GPUs generally take advantage of fine-grained parallelism more so than CPUs.
    /// For example, multithreaded calls from the CPU might still end up being serialized when being sent to the GPU,
    /// however, a whole bank of pixel and vertex shaders will run in parallel to perform the rendering.
    /// </para>
    /// <para>
    /// See Multithreaded Direct2D Apps for more info.
    /// </para>
    /// </remarks>
    [WindowsVersionRequirement(WindowsVersion.Windows7)]
    [ComInterface(IID = "06152247-6f50-465a-9245-118bfd3b6007", BeginVTableSlotIndex = 3, EndVTableSlotIndex = 16, InheritedFromTypes = [typeof(IUnknown)])]
    public unsafe struct ID2D1Factory
    {
        IntPtr* _vTable;

        /// <summary>
        /// Forces the factory to refresh any system defaults that it might have changed since factory creation.
        /// </summary>
        /// <returns>
        /// If this method succeeds, it returns <see cref="S_OK"/>.
        /// Otherwise, it returns an <see cref="HRESULT"/> error code.
        /// </returns>
        /// <remarks>
        /// To ensure that the system DPI is current, you should call <see cref="ReloadSystemMetrics"/>
        /// before calling the <see cref="GetDesktopDpi"/> method.
        /// </remarks>
        public HRESULT ReloadSystemMetrics()
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, HRESULT>)_vTable[3])(thisPtr);
            }
        }

        /// <summary>
        /// <para>
        ///  Important
        /// </para>
        /// <para>
        /// <see cref="ID2D1Factory.GetDesktopDpi"/> is deprecated.
        /// For a desktop app, instead use <see cref="GetDpiForWindow"/>.
        /// For a Universal Windows Platform (UWP) app, instead use <c>DisplayInformation.LogicalDpi</c>.
        /// </para>
        /// <para>
        /// Retrieves the current desktop dots per inch (DPI).
        /// To refresh this value, call <see cref="ReloadSystemMetrics"/>.
        /// </para>
        /// </summary>
        /// <param name="dpiX">
        /// When this method returns, contains the horizontal DPI of the desktop.
        /// You must allocate storage for this parameter.
        /// </param>
        /// <param name="dpiY">
        /// When this method returns, contains the vertical DPI of the desktop.
        /// You must allocate storage for this parameter.
        /// </param>
        /// <remarks>
        /// Use this method to obtain the system DPI when setting physical pixel values,
        /// such as when you specify the size of a window.
        /// </remarks>
        [Obsolete]
        public void GetDesktopDpi([Out] out FLOAT dpiX, [Out] out FLOAT dpiY)
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, out FLOAT, out FLOAT, void>)_vTable[4])(thisPtr, out dpiX, out dpiY);
            }
        }

        /// <summary>
        /// Creates an <see cref="ID2D1RectangleGeometry"/>.
        /// </summary>
        /// <param name="rectangle">
        /// The coordinates of the rectangle geometry.
        /// </param>
        /// <param name="rectangleGeometry">
        /// When this method returns, contains the address of the pointer to the rectangle geometry created by this method.
        /// </param>
        /// <returns>
        /// If this method succeeds, it returns <see cref="S_OK"/>.
        /// Otherwise, it returns an <see cref="HRESULT"/> error code.
        /// </returns>
        public HRESULT CreateRectangleGeometry([In] in D2D1_RECT_F rectangle, [Out] out P<ID2D1RectangleGeometry> rectangleGeometry)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, in D2D1_RECT_F, out P<ID2D1RectangleGeometry>, HRESULT>)_vTable[5])
                    (thisPtr, rectangle, out rectangleGeometry);
            }
        }

        /// <summary>
        /// Creates an <see cref="ID2D1RoundedRectangleGeometry"/>.
        /// </summary>
        /// <param name="roundedRectangle">
        /// The coordinates and corner radii of the rounded rectangle geometry.
        /// </param>
        /// <param name="roundedRectangleGeometry">
        /// When this method returns, contains the address of the pointer to the rounded rectangle geometry created by this method.
        /// </param>
        /// <returns>
        /// If this method succeeds, it returns <see cref="S_OK"/>.
        /// Otherwise, it returns an <see cref="HRESULT"/> error code.
        /// </returns>
        public HRESULT CreateRoundedRectangleGeometry([In] in D2D1_ROUNDED_RECT roundedRectangle,
            [Out] out P<ID2D1RoundedRectangleGeometry> roundedRectangleGeometry)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, in D2D1_ROUNDED_RECT, out P<ID2D1RoundedRectangleGeometry>, HRESULT>)_vTable[6])
                    (thisPtr, roundedRectangle, out roundedRectangleGeometry);
            }
        }

        /// <summary>
        /// Creates an <see cref="ID2D1EllipseGeometry"/>.
        /// </summary>
        /// <param name="ellipse">
        /// A value that describes the center point, x-radius, and y-radius of the ellipse geometry.
        /// </param>
        /// <param name="ellipseGeometry">
        /// When this method returns, contains the address of the pointer to the ellipse geometry created by this method.
        /// </param>
        /// <returns>
        /// If this method succeeds, it returns <see cref="S_OK"/>.
        /// Otherwise, it returns an <see cref="HRESULT"/> error code.
        /// </returns>
        public HRESULT CreateEllipseGeometry([In] in D2D1_ELLIPSE ellipse, [Out] out P<ID2D1EllipseGeometry> ellipseGeometry)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, in D2D1_ELLIPSE, out P<ID2D1EllipseGeometry>, HRESULT>)_vTable[7])
                    (thisPtr, ellipse, out ellipseGeometry);
            }
        }

        /// <summary>
        /// Creates an <see cref="ID2D1GeometryGroup"/>, which is an object that holds other geometries.
        /// </summary>
        /// <param name="fillMode">
        /// A value that specifies the rule that a composite shape uses to determine whether a given point is part of the geometry.
        /// </param>
        /// <param name="geometries">
        /// An array containing the geometry objects to add to the geometry group.
        /// The number of elements in this array is indicated by the <paramref name="geometriesCount"/> parameter.
        /// </param>
        /// <param name="geometriesCount">
        /// The number of elements in <paramref name="geometries"/>.
        /// </param>
        /// <param name="geometryGroup">
        /// When this method returns, contains the address of a pointer to the geometry group created by this method.
        /// </param>
        /// <returns>
        /// If this method succeeds, it returns <see cref="S_OK"/>.
        /// Otherwise, it returns an <see cref="HRESULT"/> error code.
        /// </returns>
        /// <remarks>
        /// Geometry groups are a convenient way to group several geometries simultaneously
        /// so all figures of several distinct geometries are concatenated into one.
        /// To create a <see cref="ID2D1GeometryGroup"/> object,
        /// call the <see cref="CreateGeometryGroup"/> method on the <see cref="ID2D1Factory"/> object,
        /// passing in the <paramref name="fillMode"/> with possible values of
        /// <see cref="D2D1_FILL_MODE_ALTERNATE"/> (alternate) and <see cref="D2D1_FILL_MODE_WINDING"/>,
        /// an array of geometry objects to add to the geometry group, and the number of elements in this array.
        /// </remarks>
        public HRESULT CreateGeometryGroup([In] D2D1_FILL_MODE fillMode, [In] P<ID2D1Geometry>[] geometries, [In] UINT32 geometriesCount,
            [Out] out P<ID2D1GeometryGroup> geometryGroup)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, D2D1_FILL_MODE, P<ID2D1Geometry>[], UINT32, out P<ID2D1GeometryGroup>, HRESULT>)_vTable[8])
                    (thisPtr, fillMode, geometries, geometriesCount, out geometryGroup);
            }
        }

        /// <summary>
        /// Transforms the specified geometry and stores the result as an <see cref="ID2D1TransformedGeometry"/> object.
        /// </summary>
        /// <param name="sourceGeometry">
        /// The geometry to transform.
        /// </param>
        /// <param name="transform">
        /// The transformation to apply.
        /// </param>
        /// <param name="transformedGeometry">
        /// When this method returns, contains the address of the pointer to the new transformed geometry object.
        /// The transformed geometry stores the result of transforming <paramref name="sourceGeometry"/> by <paramref name="transform"/>.
        /// </param>
        /// <returns>
        /// If this method succeeds, it returns <see cref="S_OK"/>.
        /// Otherwise, it returns an <see cref="HRESULT"/> error code.
        /// </returns>
        /// <remarks>
        /// <para>
        /// Like other resources, a transformed geometry inherits the resource space and threading policy of the factory that created it.
        /// This object is immutable.
        /// </para>
        /// <para>
        /// When stroking a transformed geometry with the <see cref="ID2D1RenderTarget.DrawGeometry"/> method,
        /// the stroke width is not affected by the transform applied to the geometry.
        /// The stroke width is only affected by the world transform.
        /// </para>
        /// </remarks>
        public HRESULT CreateTransformedGeometry([In] P<ID2D1Geometry> sourceGeometry, [In] in D2D1_MATRIX_3X2_F transform,
            [Out] out P<ID2D1TransformedGeometry> transformedGeometry)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, P<ID2D1Geometry>, in D2D1_MATRIX_3X2_F, out P<ID2D1TransformedGeometry>, HRESULT>)_vTable[9])
                    (thisPtr, sourceGeometry, transform, out transformedGeometry);
            }
        }

        /// <summary>
        /// Creates an empty <see cref="ID2D1PathGeometry"/>.
        /// </summary>
        /// <param name="pathGeometry">
        /// When this method returns, contains the address to a pointer to the path geometry created by this method.
        /// </param>
        /// <returns>
        /// If this method succeeds, it returns <see cref="S_OK"/>.
        /// Otherwise, it returns an <see cref="HRESULT"/> error code.
        /// </returns>
        public HRESULT CreatePathGeometry([Out] out P<ID2D1PathGeometry> pathGeometry)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, out P<ID2D1PathGeometry>, HRESULT>)_vTable[10])(thisPtr, out pathGeometry);
            }
        }

        /// <summary>
        /// Creates an <see cref="ID2D1StrokeStyle"/> that describes start cap, dash pattern, and other features of a stroke.
        /// </summary>
        /// <param name="strokeStyleProperties">
        /// A structure that describes the stroke's line cap, dash offset, and other details of a stroke.
        /// </param>
        /// <param name="dashes">
        /// An array whose elements are set to the length of each dash and space in the dash pattern.
        /// The first element sets the length of a dash, the second element sets the length of a space,
        /// the third element sets the length of a dash, and so on.
        /// The length of each dash and space in the dash pattern is the product of the element value in the array and the stroke width.
        /// </param>
        /// <param name="dashesCount">
        /// The number of elements in the <paramref name="dashes"/> array.
        /// </param>
        /// <param name="strokeStyle">
        /// When this method returns, contains the address of the pointer to the stroke style created by this method.
        /// </param>
        /// <returns>
        /// If this method succeeds, it returns <see cref="S_OK"/>.
        /// Otherwise, it returns an <see cref="HRESULT"/> error code.
        /// </returns>
        public HRESULT CreateStrokeStyle([In] in D2D1_STROKE_STYLE_PROPERTIES strokeStyleProperties, [In] FLOAT[] dashes,
            [In] UINT32 dashesCount, [Out] out P<ID2D1StrokeStyle> strokeStyle)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, in D2D1_STROKE_STYLE_PROPERTIES, FLOAT[], UINT32, out P<ID2D1StrokeStyle>, HRESULT>)_vTable[11])(
                    thisPtr, strokeStyleProperties, dashes, dashesCount, out strokeStyle);
            }
        }

        /// <summary>
        /// Creates an <see cref="ID2D1DrawingStateBlock"/> that can be used with the <see cref="ID2D1RenderTarget.SaveDrawingState"/>
        /// and <see cref="ID2D1RenderTarget.RestoreDrawingState"/> methods of a render target.
        /// </summary>
        /// <param name="drawingStateDescription">
        /// A structure that contains antialiasing, transform, and tags information.
        /// </param>
        /// <param name="textRenderingParams">
        /// Optional text parameters that indicate how text should be rendered.
        /// </param>
        /// <param name="drawingStateBlock">
        /// When this method returns, contains the address of a pointer to the new drawing state block created by this method.
        /// </param>
        /// <returns>
        /// If this method succeeds, it returns <see cref="S_OK"/>.
        /// Otherwise, it returns an <see cref="HRESULT"/> error code.
        /// </returns>
        public HRESULT CreateDrawingStateBlock([In] P<D2D1_DRAWING_STATE_DESCRIPTION> drawingStateDescription,
            [In] P<IDWriteRenderingParams> textRenderingParams, [Out] out P<ID2D1DrawingStateBlock> drawingStateBlock)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, P<D2D1_DRAWING_STATE_DESCRIPTION>, P<IDWriteRenderingParams>,
                    out P<ID2D1DrawingStateBlock>, HRESULT>)_vTable[12])
                    (thisPtr, drawingStateDescription, textRenderingParams, out drawingStateBlock);
            }
        }

        /// <summary>
        /// Creates a render target that renders to a Microsoft Windows Imaging Component (WIC) bitmap.
        /// </summary>
        /// <param name="target">
        /// The bitmap that receives the rendering output of the render target.
        /// </param>
        /// <param name="renderTargetProperties">
        /// The rendering mode, pixel format, remoting options, DPI information,
        /// and the minimum DirectX support required for hardware rendering.
        /// For information about supported pixel formats, see Supported Pixel Formats and Alpha Modes.
        /// </param>
        /// <param name="renderTarget">
        /// When this method returns, contains the address of the pointer to the <see cref="ID2D1RenderTarget"/> object created by this method.
        /// </param>
        /// <returns>
        /// If this method succeeds, it returns <see cref="S_OK"/>.
        /// Otherwise, it returns an <see cref="HRESULT"/> error code.
        /// </returns>
        /// <remarks>
        /// <para>
        /// You must use <see cref="D2D1_FEATURE_LEVEL_DEFAULT"/> for the <see cref="D2D1_RENDER_TARGET_PROPERTIES.minLevel"/> member
        /// of the <paramref name="renderTargetProperties"/> parameter with this method.
        /// </para>
        /// <para>
        /// Your application should create render targets once and hold onto them for the life of the application
        /// or until the <see cref="D2DERR_RECREATE_TARGET"/> error is received.
        /// When you receive this error, you need to HDMI swingrecreate the render target (and any resources it created).
        /// </para>
        /// <para>
        /// Note
        /// </para>
        /// <para>
        /// This method isn't supported on Windows Phone and will fail when called on a device with error code 0x8899000b
        /// (“There is no hardware rendering device available for this operation”).
        /// Because the Windows Phone Emulator supports WARP rendering,
        /// this method will fail when called on the emulator with a different error code,
        /// 0x88982f80 (wincodec_err_unsupportedpixelformat).
        /// </para>
        /// </remarks>
        public HRESULT CreateWicBitmapRenderTarget([In] P<IWICBitmap> target, [In] in D2D1_RENDER_TARGET_PROPERTIES renderTargetProperties,
            [Out] out P<ID2D1RenderTarget> renderTarget)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, P<IWICBitmap>, in D2D1_RENDER_TARGET_PROPERTIES, out P<ID2D1RenderTarget>, HRESULT>)_vTable[13])
                    (thisPtr, target, renderTargetProperties, out renderTarget);
            }
        }

        /// <summary>
        /// <para>
        /// Creates an <see cref="ID2D1HwndRenderTarget"/>, a render target that renders to a window.
        /// </para>
        /// <para>
        /// When you create a render target, and hardware acceleration is available, you allocate resources on the computer's GPU.
        /// By creating a render target once and retaining it as long as possible, you gain performance benefits.
        /// Your application should create render targets once and hold onto them for the life of the application
        /// or until the <see cref="D2DERR_RECREATE_TARGET"/> error is received.
        /// When you receive this error, you need to recreate the render target (and any resources it created).
        /// </para>
        /// </summary>
        /// <param name="renderTargetProperties">
        /// The rendering mode, pixel format, remoting options, DPI information,
        /// and the minimum DirectX support required for hardware rendering.
        /// For information about supported pixel formats, see Supported Pixel Formats and Alpha Modes.
        /// </param>
        /// <param name="hwndRenderTargetProperties">
        /// The window handle, initial size (in pixels), and present options.
        /// </param>
        /// <param name="hwndRenderTarget">
        /// When this method returns, contains the address of the pointer
        /// to the <see cref="ID2D1HwndRenderTarget"/> object created by this method.
        /// </param>
        /// <returns>
        /// If this method succeeds, it returns <see cref="S_OK"/>.
        /// Otherwise, it returns an <see cref="HRESULT"/> error code.
        /// </returns>
        /// <remarks>
        /// When you create a render target and hardware acceleration is available, you allocate resources on the computer's GPU.
        /// By creating a render target once and retaining it as long as possible, you gain performance benefits.
        /// Your application should create render targets once and hold onto them for the life of the application
        /// or until the <see cref="D2DERR_RECREATE_TARGET"/> error is received.
        /// When you receive this error, you need to recreate the render target (and any resources it created).
        /// </remarks>
        public HRESULT CreateHwndRenderTarget([In] in D2D1_RENDER_TARGET_PROPERTIES renderTargetProperties,
            [In] in D2D1_HWND_RENDER_TARGET_PROPERTIES hwndRenderTargetProperties, [Out] out P<ID2D1HwndRenderTarget> hwndRenderTarget)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, in D2D1_RENDER_TARGET_PROPERTIES, in D2D1_HWND_RENDER_TARGET_PROPERTIES,
                    out P<ID2D1HwndRenderTarget>, HRESULT>)_vTable[14])
                    (thisPtr, renderTargetProperties, hwndRenderTargetProperties, out hwndRenderTarget);
            }
        }

        /// <summary>
        /// Creates a render target that draws to a DirectX Graphics Infrastructure (DXGI) surface.
        /// </summary>
        /// <param name="dxgiSurface">
        /// The <see cref="IDXGISurface"/> to which the render target will draw.
        /// </param>
        /// <param name="renderTargetProperties">
        /// The rendering mode, pixel format, remoting options, DPI information,
        /// and the minimum DirectX support required for hardware rendering.
        /// For information about supported pixel formats, see Supported Pixel Formats and Alpha Modes.
        /// </param>
        /// <param name="renderTarget">
        /// When this method returns, contains the address of the pointer
        /// to the <see cref="ID2D1RenderTarget"/> object created by this method.
        /// </param>
        /// <returns>
        /// If this method succeeds, it returns <see cref="S_OK"/>.
        /// Otherwise, it returns an <see cref="HRESULT"/> error code.
        /// </returns>
        /// <remarks>
        /// <para>
        /// To write to a Direct3D surface, you obtain an <see cref="IDXGISurface"/>
        /// and pass it to the <see cref="CreateDxgiSurfaceRenderTarget"/> method to create a DXGI surface render target;
        /// you can then use the DXGI surface render target to draw 2-D content to the DXGI surface.
        /// </para>
        /// <para>
        /// A DXGI surface render target is a type of <see cref="ID2D1RenderTarget"/>.
        /// Like other Direct2D render targets, you can use it to create resources and issue drawing commands.
        /// </para>
        /// <para>
        /// The DXGI surface render target and the DXGI surface must use the same DXGI format.
        /// If you specify the <see cref="DXGI_FORMAT_UNKNOWN"/> format when you create the render target,
        /// it will automatically use the surface's format.
        /// </para>
        /// <para>
        /// The DXGI surface render target does not perform DXGI surface synchronization.
        /// </para>
        /// <para>
        /// For more information about creating and using DXGI surface render targets,
        /// see the Direct2D and Direct3D Interoperability Overview.
        /// </para>
        /// <para>
        /// To work with Direct2D, the Direct3D device that provides the <see cref="IDXGISurface"/>
        /// must be created with the <see cref="D3D10_CREATE_DEVICE_BGRA_SUPPORT"/> flag.
        /// </para>
        /// <para>
        /// When you create a render target and hardware acceleration is available, you allocate resources on the computer's GPU.
        /// By creating a render target once and retaining it as long as possible, you gain performance benefits.
        /// Your application should create render targets once and hold onto them for the life of the application
        /// or until the render target's <see cref="ID2D1RenderTarget.EndDraw"/> method returns the <see cref="D2DERR_RECREATE_TARGET"/> error.
        /// When you receive this error, you need to recreate the render target (and any resources it created).
        /// </para>
        /// </remarks>
        public HRESULT CreateDxgiSurfaceRenderTarget([In] P<IDXGISurface> dxgiSurface, [In] in D2D1_RENDER_TARGET_PROPERTIES renderTargetProperties,
            [Out] out P<ID2D1RenderTarget> renderTarget)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, P<IDXGISurface>, in D2D1_RENDER_TARGET_PROPERTIES, out P<ID2D1RenderTarget>, HRESULT>)_vTable[15])
                    (thisPtr, dxgiSurface, renderTargetProperties, out renderTarget);
            }
        }

        /// <summary>
        /// Creates a render target that draws to a Windows Graphics Device Interface (GDI) device context.
        /// </summary>
        /// <param name="renderTargetProperties">
        /// The rendering mode, pixel format, remoting options, DPI information,
        /// and the minimum DirectX support required for hardware rendering.
        /// To enable the device context (DC) render target to work with GDI,
        /// set the DXGI format to <see cref="DXGI_FORMAT_B8G8R8A8_UNORM"/>
        /// and the alpha mode to <see cref="D2D1_ALPHA_MODE_PREMULTIPLIED"/> or <see cref="D2D1_ALPHA_MODE_IGNORE"/>.
        /// For more information about pixel formats, see Supported Pixel Formats and Alpha Modes.
        /// </param>
        /// <param name="dcRenderTarget">
        /// When this method returns, <paramref name="dcRenderTarget"/> contains the address of the pointer
        /// to the <see cref="ID2D1DCRenderTarget"/> created by the method.
        /// </param>
        /// <returns>
        /// If this method succeeds, it returns <see cref="S_OK"/>.
        /// Otherwise, it returns an <see cref="HRESULT"/> error code.
        /// </returns>
        /// <remarks>
        /// <para>
        /// Before you can render with a DC render target,
        /// you must use the render target's <see cref="ID2D1DCRenderTarget.BindDC"/> method to associate it with a GDI DC.
        /// Do this for each different DC and whenever there is a change in the size of the area you want to draw to.
        /// </para>
        /// <para>
        /// To enable the DC render target to work with GDI,
        /// set the render target's DXGI format to <see cref="DXGI_FORMAT_B8G8R8A8_UNORM"/>
        /// and alpha mode to <see cref="D2D1_ALPHA_MODE_PREMULTIPLIED"/> or <see cref="D2D1_ALPHA_MODE_IGNORE"/>.
        /// </para>
        /// <para>
        /// Your application should create render targets once and hold on to them for the life of the application
        /// or until the render target's <see cref="ID2D1RenderTarget.EndDraw"/> method returns the <see cref="D2DERR_RECREATE_TARGET"/> error.
        /// When you receive this error, recreate the render target (and any resources it created).
        /// </para>
        /// </remarks>
        public HRESULT CreateDCRenderTarget([In] in D2D1_RENDER_TARGET_PROPERTIES renderTargetProperties, [Out] out P<ID2D1DCRenderTarget> dcRenderTarget)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, in D2D1_RENDER_TARGET_PROPERTIES, out P<ID2D1DCRenderTarget>, HRESULT>)_vTable[16])
                    (thisPtr, renderTargetProperties, out dcRenderTarget);
            }
        }
    }
}
