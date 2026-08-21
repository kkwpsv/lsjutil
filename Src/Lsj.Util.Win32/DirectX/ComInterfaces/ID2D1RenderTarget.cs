using Lsj.Util.Win32.Attributes;
using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.ComInterfaces;
using Lsj.Util.Win32.DirectX.BaseTypes;
using Lsj.Util.Win32.DirectX.Enums;
using Lsj.Util.Win32.DirectX.Structs;
using Lsj.Util.Win32.Marshals;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.BOOL;
using static Lsj.Util.Win32.BaseTypes.HRESULT;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.DirectX.Enums.D2D1_ALPHA_MODE;
using static Lsj.Util.Win32.DirectX.Enums.D2D1_ANTIALIAS_MODE;
using static Lsj.Util.Win32.DirectX.Enums.D2D1_BITMAP_INTERPOLATION_MODE;
using static Lsj.Util.Win32.DirectX.Enums.D2D1_DRAW_TEXT_OPTIONS;
using static Lsj.Util.Win32.DirectX.Enums.D2D1_EXTEND_MODE;
using static Lsj.Util.Win32.DirectX.Enums.D2D1_RENDER_TARGET_TYPE;
using static Lsj.Util.Win32.DirectX.Enums.D2DERR;
using static Lsj.Util.Win32.DirectX.Enums.DWRITE_MEASURING_MODE;
using static Lsj.Util.Win32.DirectX.Enums.DXGI_FORMAT;
using static Lsj.Util.Win32.UnsafePInvokeExtensions;

namespace Lsj.Util.Win32.DirectX.ComInterfaces
{
    /// <summary>
    /// <para>
    /// Represents an object that can receive drawing commands.
    /// Interfaces that inherit from <see cref="ID2D1RenderTarget"/> render the drawing commands they receive in different ways.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d2d1/nn-d2d1-id2d1rendertarget"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// Your application should create render targets once and hold onto them for the life of the application
    /// or until the render target's <see cref="EndDraw"/> method returns the <see cref="D2DERR_RECREATE_TARGET"/> error.
    /// When you receive this error, you need to recreate the render target (and any resources it created).
    /// </remarks>
    [WindowsVersionRequirement(WindowsVersion.Windows7)]
    [ComInterface(IID = "2cd90694-12e2-11dc-9fed-001143a055f9", BeginVTableSlotIndex = 4, EndVTableSlotIndex = 56,
        InheritedFromTypes = [typeof(IUnknown), typeof(ID2D1Resource)])]
    public unsafe struct ID2D1RenderTarget
    {
        nint* _vTable;

        /// <summary>
        /// Creates a Direct2D bitmap from a pointer to in-memory source data.
        /// </summary>
        /// <param name="size">
        /// The dimensions of the bitmap to create, in pixels.
        /// </param>
        /// <param name="srcData">
        /// A pointer to the memory location of the image data, or <see cref="NULL"/> to create an uninitialized bitmap.
        /// </param>
        /// <param name="pitch">
        /// The byte count of each scanline, which is equal to (the image width in pixels × the number of bytes per pixel) + memory padding.
        /// If <paramref name="srcData"/> is <see cref="NULL"/>, this value is ignored.
        /// (Note that pitch is also sometimes called stride.)
        /// </param>
        /// <param name="bitmapProperties">
        /// The pixel format and dots per inch (DPI) of the bitmap to create.
        /// </param>
        /// <param name="bitmap">
        /// The bitmap contents of the new brush.
        /// </param>
        /// <returns>
        /// If this method succeeds, it returns <see cref="S_OK"/>.
        /// Otherwise, it returns an <see cref="HRESULT"/> error code.
        /// </returns>
        public HRESULT CreateBitmap([In] D2D1_SIZE_U size, [In] nint srcData, [In] UINT32 pitch,
            [In] in D2D1_BITMAP_PROPERTIES bitmapProperties, [Out] out P<ID2D1Bitmap> bitmap)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, D2D1_SIZE_U, nint, UINT32, in D2D1_BITMAP_PROPERTIES, out P<ID2D1Bitmap>, HRESULT>)_vTable[4])
                    (thisPtr, size, srcData, pitch, bitmapProperties, out bitmap);
            }
        }

        /// <summary>
        /// Creates an <see cref="ID2D1Bitmap"/> by copying the specified Microsoft Windows Imaging Component (WIC) bitmap.
        /// </summary>
        /// <param name="wicBitmapSource">
        /// The WIC bitmap to copy.
        /// </param>
        /// <param name="bitmapProperties">
        /// The pixel format and DPI of the bitmap to create.
        /// The pixel format must match the pixel format of <paramref name="wicBitmapSource"/>, or the method will fail.
        /// To prevent a mismatch, you can pass <see cref="NULL"/> or pass the value obtained
        /// from calling the <c>D2D1::PixelFormat</c> helper function without specifying any parameter values.
        /// If both <see cref="D2D1_BITMAP_PROPERTIES.dpiX"/> and <see cref="D2D1_BITMAP_PROPERTIES.dpiY"/> are 0.0f,
        /// the default DPI, 96, is used.
        /// DPI information embedded in <paramref name="wicBitmapSource"/> is ignored.
        /// </param>
        /// <param name="bitmap">
        /// When this method returns, contains the address of a pointer to the new bitmap.
        /// This parameter is passed uninitialized.
        /// </param>
        /// <returns>
        /// If this method succeeds, it returns <see cref="S_OK"/>.
        /// Otherwise, it returns an <see cref="HRESULT"/> error code.
        /// </returns>
        /// <remarks>
        /// Before Direct2D can load a WIC bitmap, that bitmap must be converted to a supported pixel format and alpha mode.
        /// For a list of supported pixel formats and alpha modes, see Supported Pixel Formats and Alpha Modes.
        /// </remarks>
        public HRESULT CreateBitmapFromWicBitmap([In] P<IWICBitmapSource> wicBitmapSource,
            [In] in D2D1_BITMAP_PROPERTIES bitmapProperties, [Out] out P<ID2D1Bitmap> bitmap)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, P<IWICBitmapSource>, in D2D1_BITMAP_PROPERTIES, out P<ID2D1Bitmap>, HRESULT>)_vTable[5])
                    (thisPtr, wicBitmapSource, bitmapProperties, out bitmap);
            }
        }

        /// <summary>
        /// Creates an <see cref="ID2D1Bitmap"/> whose data is shared with another resource.
        /// </summary>
        /// <param name="riid">
        /// The interface ID of the object supplying the source data.
        /// </param>
        /// <param name="data">
        /// An <see cref="ID2D1Bitmap"/>, <see cref="IDXGISurface"/>, or an <see cref="IWICBitmapLock"/>
        /// that contains the data to share with the new <see cref="ID2D1Bitmap"/>.
        /// For more information, see the Remarks section.
        /// </param>
        /// <param name="bitmapProperties">
        /// The pixel format and DPI of the bitmap to create.
        /// The <see cref="DXGI_FORMAT"/> portion of the pixel format must match the <see cref="DXGI_FORMAT"/> of <paramref name="data"/>
        /// or the method will fail, but the alpha modes don't have to match.
        /// To prevent a mismatch, you can pass <see cref="NULL"/>
        /// or the value obtained from the <c>D2D1::PixelFormat</c> helper function.
        /// The DPI settings do not have to match those of <paramref name="data"/>.
        /// If both <see cref="D2D1_BITMAP_PROPERTIES.dpiX"/> and <see cref="D2D1_BITMAP_PROPERTIES.dpiY"/> are 0.0f,
        /// the DPI of the render target is used.
        /// </param>
        /// <param name="bitmap">
        /// When this method returns, contains the address of a pointer to the new bitmap.
        /// This parameter is passed uninitialized.
        /// </param>
        /// <returns>
        /// If this method succeeds, it returns <see cref="S_OK"/>.
        /// Otherwise, it returns an <see cref="HRESULT"/> error code.
        /// </returns>
        /// <remarks>
        /// <para>
        /// The <see cref="CreateSharedBitmap"/> method is useful for efficiently reusing bitmap data
        /// and can also be used to provide interoperability with Direct3D.
        /// </para>
        /// <para>
        /// Sharing an <see cref="ID2D1Bitmap"/>
        /// </para>
        /// <para>
        /// By passing an <see cref="ID2D1Bitmap"/> created by a render target that is resource-compatible,
        /// you can share a bitmap with that render target;
        /// both the original <see cref="ID2D1Bitmap"/> and the new <see cref="ID2D1Bitmap"/> created by this method
        /// will point to the same bitmap data.
        /// For more information about when render target resources can be shared,
        /// see the Sharing Render Target Resources section of the Resources Overview.
        /// </para>
        /// <para>
        /// You may also use this method to reinterpret the data of an existing bitmap and specify a new DPI or alpha mode.
        /// For example, in the case of a bitmap atlas, an <see cref="ID2D1Bitmap"/> may contain multiple sub-images,
        /// each of which should be rendered with a different <see cref="D2D1_ALPHA_MODE"/>
        /// (<see cref="D2D1_ALPHA_MODE_PREMULTIPLIED"/> or <see cref="D2D1_ALPHA_MODE_IGNORE"/>).
        /// You could use the <see cref="CreateSharedBitmap"/> method to reinterpret the bitmap
        /// using the desired alpha mode without having to load a separate copy of the bitmap into memory.
        /// </para>
        /// <para>
        /// Sharing an IDXGISurface
        /// </para>
        /// <para>
        /// When using a DXGI surface render target (an <see cref="ID2D1RenderTarget"/> object
        /// created by the <see cref="ID2D1Factory.CreateDxgiSurfaceRenderTarget"/> method),
        /// you can pass an <see cref="IDXGISurface"/> surface to the <see cref="CreateSharedBitmap"/> method
        /// to share video memory with Direct3D and manipulate Direct3D content as an <see cref="ID2D1Bitmap"/>.
        /// As described in the Resources Overview, the render target and the <see cref="IDXGISurface"/> must be using the same Direct3D device.
        /// </para>
        /// <para>
        /// Note also that the <see cref="IDXGISurface"/> must use one of the supported pixel formats
        /// and alpha modes described in Supported Pixel Formats and Alpha Modes.
        /// </para>
        /// <para>
        /// For more information about interoperability with Direct3D, see the Direct2D and Direct3D Interoperability Overview.
        /// </para>
        /// <para>
        /// Sharing an <see cref="IWICBitmapLock"/>
        /// </para>
        /// <para>
        /// An <see cref="IWICBitmapLock"/> stores the content of a WIC bitmap and shields it from simultaneous accesses.
        /// By passing an <see cref="IWICBitmapLock"/> to the <see cref="CreateSharedBitmap"/> method,
        /// you can create an <see cref="ID2D1Bitmap"/> that points to the bitmap data already stored in the <see cref="IWICBitmapLock"/>.
        /// </para>
        /// <para>
        /// To use an <see cref="IWICBitmapLock"/> with the <see cref="CreateSharedBitmap"/> method,
        /// the render target must use software rendering.
        /// To force a render target to use software rendering, set to <see cref="D2D1_RENDER_TARGET_TYPE_SOFTWARE"/>
        /// the <see cref="D2D1_RENDER_TARGET_PROPERTIES.type"/> field of the <see cref="D2D1_RENDER_TARGET_PROPERTIES"/> structure
        /// that you use to create the render target.
        /// To check whether an existing render target uses software rendering, use the <see cref="IsSupported"/> method.
        /// </para>
        /// </remarks>
        public HRESULT CreateSharedBitmap([In] in IID riid, [In] nint data, [In] in D2D1_BITMAP_PROPERTIES bitmapProperties, [Out] out P<ID2D1Bitmap> bitmap)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, in IID, nint, in D2D1_BITMAP_PROPERTIES, out P<ID2D1Bitmap>, HRESULT>)_vTable[6])
                    (thisPtr, riid, data, bitmapProperties, out bitmap);
            }
        }

        /// <summary>
        /// Creates an <see cref="ID2D1BitmapBrush"/> from the specified bitmap.
        /// </summary>
        /// <param name="bitmap">
        /// The bitmap contents of the new brush.
        /// </param>
        /// <param name="bitmapBrushProperties">
        /// The extend modes and interpolation mode of the new brush, or <see cref="NullRef{D2D1_BITMAP_BRUSH_PROPERTIES}"/>.
        /// If you set this parameter to <see cref="NullRef{D2D1_BITMAP_BRUSH_PROPERTIES}"/>,
        /// the brush defaults to the <see cref="D2D1_EXTEND_MODE_CLAMP"/> horizontal
        /// and vertical extend modes and the <see cref="D2D1_BITMAP_INTERPOLATION_MODE_LINEAR"/> interpolation mode.
        /// </param>
        /// <param name="brushProperties">
        /// A structure that contains the opacity and transform of the new brush, or <see cref="NullRef{D2D1_BRUSH_PROPERTIES}"/>.
        /// If you set this parameter to <see cref="NullRef{D2D1_BRUSH_PROPERTIES}"/>,
        /// the brush sets the opacity member to 1.0F and the transform member to the identity matrix.
        /// </param>
        /// <param name="bitmapBrush">
        /// When this method returns, this output parameter contains a pointer to a pointer to the new brush.
        /// Pass this parameter uninitialized.
        /// </param>
        /// <returns>
        /// If this method succeeds, it returns <see cref="S_OK"/>.
        /// Otherwise, it returns an <see cref="HRESULT"/> error code.
        /// </returns>
        public HRESULT CreateBitmapBrush([In] P<ID2D1Bitmap> bitmap, [In] in D2D1_BITMAP_BRUSH_PROPERTIES bitmapBrushProperties,
            [In] in D2D1_BRUSH_PROPERTIES brushProperties, [Out] out P<ID2D1BitmapBrush> bitmapBrush)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, P<ID2D1Bitmap>, in D2D1_BITMAP_BRUSH_PROPERTIES,
                    in D2D1_BRUSH_PROPERTIES, out P<ID2D1BitmapBrush>, HRESULT>)_vTable[7])
                    (thisPtr, bitmap, bitmapBrushProperties, brushProperties, out bitmapBrush);
            }
        }

        /// <summary>
        /// Creates a new <see cref="ID2D1SolidColorBrush"/> that can be used to paint areas with a solid color.
        /// </summary>
        /// <param name="color">
        /// The red, green, blue, and alpha values of the brush's color.
        /// </param>
        /// <param name="brushProperties">
        /// The base opacity of the brush.
        /// </param>
        /// <param name="solidColorBrush">
        /// When this method returns, contains the address of a pointer to the new brush.
        /// This parameter is passed uninitialized.
        /// </param>
        /// <returns>
        /// If this method succeeds, it returns <see cref="S_OK"/>.
        /// Otherwise, it returns an <see cref="HRESULT"/> error code.
        /// </returns>
        public HRESULT CreateSolidColorBrush([In] in D2D1_COLOR_F color, [In] in D2D1_BRUSH_PROPERTIES brushProperties,
            [Out] out P<ID2D1SolidColorBrush> solidColorBrush)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, in D2D1_COLOR_F, in D2D1_BRUSH_PROPERTIES,
                    out P<ID2D1SolidColorBrush>, HRESULT>)_vTable[8])(thisPtr, color, brushProperties, out solidColorBrush);
            }
        }

        /// <summary>
        /// Creates an <see cref="ID2D1GradientStopCollection"/> from the specified array of <see cref="D2D1_GRADIENT_STOP"/> structures.
        /// </summary>
        /// <param name="gradientStops">
        /// A pointer to an array of <see cref="D2D1_GRADIENT_STOP"/> structures.
        /// </param>
        /// <param name="gradientStopsCount">
        /// A value greater than or equal to 1 that specifies the number of gradient stops in the <paramref name="gradientStops"/> array.
        /// </param>
        /// <param name="colorInterpolationGamma">
        /// The space in which color interpolation between the gradient stops is performed.
        /// </param>
        /// <param name="extendMode">
        /// The behavior of the gradient outside the [0,1] normalized range.
        /// </param>
        /// <param name="gradientStopCollection">
        /// When this method returns, contains a pointer to a pointer to the new gradient stop collection.
        /// </param>
        /// <returns>
        /// If this method succeeds, it returns <see cref="S_OK"/>.
        /// Otherwise, it returns an <see cref="HRESULT"/> error code.
        /// </returns>
        public HRESULT CreateGradientStopCollection([In] D2D1_GRADIENT_STOP[] gradientStops, [In] UINT32 gradientStopsCount,
            [In] D2D1_GAMMA colorInterpolationGamma, [In] D2D1_EXTEND_MODE extendMode, [Out] out P<ID2D1GradientStopCollection> gradientStopCollection)
        {
            fixed (void* thisPtr = &this)
            {
                fixed (D2D1_GRADIENT_STOP* gradientStopsPtr = gradientStops)
                {
                    return ((delegate* unmanaged[Stdcall]<void*, D2D1_GRADIENT_STOP*, UINT32, D2D1_GAMMA,
                        D2D1_EXTEND_MODE, out P<ID2D1GradientStopCollection>, HRESULT>)_vTable[9])
                        (thisPtr, gradientStopsPtr, gradientStopsCount, colorInterpolationGamma, extendMode, out gradientStopCollection);
                }
            }
        }

        /// <summary>
        /// Creates an <see cref="ID2D1LinearGradientBrush"/> object for painting areas with a linear gradient.
        /// </summary>
        /// <param name="linearGradientBrushProperties">
        /// The start and end points of the gradient.
        /// </param>
        /// <param name="brushProperties">
        /// The transform and base opacity of the new brush.
        /// </param>
        /// <param name="gradientStopCollection">
        /// A collection of <see cref="D2D1_GRADIENT_STOP"/> structures that describe the colors
        /// in the brush's gradient and their locations along the gradient line.
        /// </param>
        /// <param name="linearGradientBrush">
        /// When this method returns, contains the address of a pointer to the new brush.
        /// This parameter is passed uninitialized.
        /// </param>
        /// <returns>
        /// If this method succeeds, it returns <see cref="S_OK"/>.
        /// Otherwise, it returns an <see cref="HRESULT"/> error code.
        /// </returns>
        public HRESULT CreateLinearGradientBrush([In] in D2D1_LINEAR_GRADIENT_BRUSH_PROPERTIES linearGradientBrushProperties,
            [In] in D2D1_BRUSH_PROPERTIES brushProperties, [In] P<ID2D1GradientStopCollection> gradientStopCollection,
            [Out] out P<ID2D1LinearGradientBrush> linearGradientBrush)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, in D2D1_LINEAR_GRADIENT_BRUSH_PROPERTIES, in D2D1_BRUSH_PROPERTIES,
                    P<ID2D1GradientStopCollection>, out P<ID2D1LinearGradientBrush>, HRESULT>)_vTable[10])
                    (thisPtr, linearGradientBrushProperties, brushProperties, gradientStopCollection, out linearGradientBrush);
            }
        }

        /// <summary>
        /// Creates an <see cref="ID2D1RadialGradientBrush"/> object that can be used to paint areas with a radial gradient.
        /// </summary>
        /// <param name="radialGradientBrushProperties">
        /// The center, gradient origin offset, and x-radius and y-radius of the brush's gradient.
        /// </param>
        /// <param name="brushProperties">
        /// The transform and base opacity of the new brush.
        /// </param>
        /// <param name="gradientStopCollection">
        /// A collection of <see cref="D2D1_GRADIENT_STOP"/> structures
        /// that describe the colors in the brush's gradient and their locations along the gradient.
        /// </param>
        /// <param name="radialGradientBrush">
        /// When this method returns, contains a pointer to a pointer to the new brush.
        /// This parameter is passed uninitialized.
        /// </param>
        /// <returns>
        /// If this method succeeds, it returns <see cref="S_OK"/>.
        /// Otherwise, it returns an <see cref="HRESULT"/> error code.
        /// </returns>
        public HRESULT CreateRadialGradientBrush([In] in D2D1_RADIAL_GRADIENT_BRUSH_PROPERTIES radialGradientBrushProperties,
            [In] in D2D1_BRUSH_PROPERTIES brushProperties, [In] P<ID2D1GradientStopCollection> gradientStopCollection,
            [Out] out P<ID2D1RadialGradientBrush> radialGradientBrush)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, in D2D1_RADIAL_GRADIENT_BRUSH_PROPERTIES, in D2D1_BRUSH_PROPERTIES,
                    P<ID2D1GradientStopCollection>, out P<ID2D1RadialGradientBrush>, HRESULT>)_vTable[11])
                    (thisPtr, radialGradientBrushProperties, brushProperties, gradientStopCollection, out radialGradientBrush);
            }
        }

        /// <summary>
        /// Creates a bitmap render target for use during intermediate offscreen drawing that is compatible with the current render target.
        /// </summary>
        /// <param name="desiredSize">
        /// The desired size of the new render target (in device-independent pixels),
        /// if it should be different from the original render target.
        /// For more info, see the Remarks section.
        /// </param>
        /// <param name="desiredPixelSize">
        /// The desired size of the new render target in pixels if it should be different from the original render target.
        /// For more information, see the Remarks section.
        /// </param>
        /// <param name="desiredFormat">
        /// The desired pixel format and alpha mode of the new render target.
        /// If the pixel format is set to <see cref="DXGI_FORMAT_UNKNOWN"/>,
        /// the new render target uses the same pixel format as the original render target.
        /// If the alpha mode is <see cref="D2D1_ALPHA_MODE_UNKNOWN"/>,
        /// the alpha mode of the new render target defaults to <see cref="D2D1_ALPHA_MODE_PREMULTIPLIED"/>.
        /// For information about supported pixel formats, see Supported Pixel Formats and Alpha Modes.
        /// </param>
        /// <param name="options">
        /// A value that specifies whether the new render target must be compatible with GDI.
        /// </param>
        /// <param name="bitmapRenderTarget">
        /// When this method returns, contains a pointer to a pointer to a new bitmap render target.
        /// This parameter is passed uninitialized.
        /// </param>
        /// <returns>
        /// If this method succeeds, it returns <see cref="S_OK"/>.
        /// Otherwise, it returns an <see cref="HRESULT"/> error code.
        /// </returns>
        /// <remarks>
        /// <para>
        /// The pixel size and DPI of the new render target can be altered
        /// by specifying values for <paramref name="desiredSize"/> or <paramref name="desiredPixelSize"/>:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// If <paramref name="desiredSize"/> is specified but <paramref name="desiredPixelSize"/> is not,
        /// the pixel size is computed from the desired size using the parent target DPI.
        /// If the <paramref name="desiredSize"/> maps to a integer-pixel size,
        /// the DPI of the compatible render target is the same as the DPI of the parent target.
        /// If <paramref name="desiredSize"/> maps to a fractional-pixel size,
        /// the pixel size is rounded up to the nearest integer and the DPI for the compatible render target
        /// is slightly higher than the DPI of the parent render target.
        /// In all cases, the coordinate (<c>desiredSize.width</c>, <c>desiredSize.height</c>)
        /// maps to the lower-right corner of the compatible render target.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// If the <paramref name="desiredPixelSize"/> is specified and <paramref name="desiredSize"/> is not,
        /// the DPI of the new render target is the same as the original render target.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// If both <paramref name="desiredSize"/> and <paramref name="desiredPixelSize"/> are specified,
        /// the DPI of the new render target is computed to account for the difference in scale.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// If neither <paramref name="desiredSize"/> nor <paramref name="desiredPixelSize"/> is specified,
        /// the new render target size and DPI match the original render target.
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// </remarks>
        public HRESULT CreateCompatibleRenderTarget([In] in D2D1_SIZE_F desiredSize, [In] in D2D1_SIZE_U desiredPixelSize,
            [In] in D2D1_PIXEL_FORMAT desiredFormat, [In] D2D1_COMPATIBLE_RENDER_TARGET_OPTIONS options,
            [Out] out P<ID2D1BitmapRenderTarget> bitmapRenderTarget)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, in D2D1_SIZE_F, in D2D1_SIZE_U, in D2D1_PIXEL_FORMAT,
                    D2D1_COMPATIBLE_RENDER_TARGET_OPTIONS, out P<ID2D1BitmapRenderTarget>, HRESULT>)_vTable[12])
                    (thisPtr, desiredSize, desiredPixelSize, desiredFormat, options, out bitmapRenderTarget);
            }
        }

        /// <summary>
        /// Creates a layer resource that can be used with this render target and its compatible render targets.
        /// </summary>
        /// <param name="size">
        /// If (0, 0) is specified, no backing store is created behind the layer resource.
        /// The layer resource is allocated to the minimum size when <see cref="PushLayer"/> is called.
        /// </param>
        /// <param name="layer">
        /// When the method returns, contains a pointer to a pointer to the new layer.
        /// This parameter is passed uninitialized.
        /// </param>
        /// <returns>
        /// If this method succeeds, it returns <see cref="S_OK"/>.
        /// Otherwise, it returns an <see cref="HRESULT"/> error code.
        /// </returns>
        /// <remarks>
        /// The layer automatically resizes itself, as needed.
        /// </remarks>
        public HRESULT CreateLayer([In] in D2D1_SIZE_F size, [Out] out P<ID2D1Layer> layer)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, in D2D1_SIZE_F, out P<ID2D1Layer>, HRESULT>)_vTable[13])(thisPtr, size, out layer);
            }
        }

        /// <summary>
        /// Create a mesh that uses triangles to describe a shape.
        /// </summary>
        /// <param name="mesh">
        /// When this method returns, contains a pointer to a pointer to the new mesh.
        /// </param>
        /// <returns>
        /// If this method succeeds, it returns <see cref="S_OK"/>.
        /// Otherwise, it returns an <see cref="HRESULT"/> error code.
        /// </returns>
        /// <remarks>
        /// To populate a mesh, use its <see cref="ID2D1Mesh.Open"/> method to obtain an <see cref="ID2D1TessellationSink"/>.
        /// To draw the mesh, use the render target's <see cref="FillMesh"/> method.
        /// </remarks>
        public HRESULT CreateMesh([Out] out P<ID2D1Mesh> mesh)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, out P<ID2D1Mesh>, HRESULT>)_vTable[14])(thisPtr, out mesh);
            }
        }

        /// <summary>
        /// Draws a line between the specified points using the specified stroke style.
        /// </summary>
        /// <param name="point0">
        /// The start point of the line, in device-independent pixels.
        /// </param>
        /// <param name="point1">
        /// The end point of the line, in device-independent pixels.
        /// </param>
        /// <param name="brush">
        /// The brush used to paint the line's stroke.
        /// </param>
        /// <param name="strokeWidth">
        /// The width of the stroke, in device-independent pixels.
        /// The value must be greater than or equal to 0.0f.
        /// If this parameter isn't specified, it defaults to 1.0f. The stroke is centered on the line.
        /// </param>
        /// <param name="strokeStyle">
        /// The style of stroke to paint, or <see cref="NULL"/> to paint a solid line.
        /// </param>
        /// <remarks>
        /// This method doesn't return an error code if it fails.
        /// To determine whether a drawing operation (such as <see cref="DrawLine"/>) failed,
        /// check the result returned by the <see cref="EndDraw"/> or <see cref="Flush"/> methods.
        /// </remarks>
        public void DrawLine([In] D2D1_POINT_2F point0, [In] D2D1_POINT_2F point1, [In] P<ID2D1Brush> brush,
            [In] FLOAT strokeWidth, [In] P<ID2D1StrokeStyle> strokeStyle)
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, D2D1_POINT_2F, D2D1_POINT_2F, P<ID2D1Brush>, FLOAT, P<ID2D1StrokeStyle>, void>)_vTable[15])
                    (thisPtr, point0, point1, brush, strokeWidth, strokeStyle);
            }
        }

        /// <summary>
        /// Draws the outline of a rectangle that has the specified dimensions and stroke style.
        /// </summary>
        /// <param name="rect">
        /// The dimensions of the rectangle to draw, in device-independent pixels.
        /// </param>
        /// <param name="brush">
        /// The brush used to paint the rectangle's stroke.
        /// </param>
        /// <param name="strokeWidth">
        /// The width of the stroke, in device-independent pixels.
        /// The value must be greater than or equal to 0.0f. If this parameter isn't specified, it defaults to 1.0f.
        /// The stroke is centered on the line.
        /// </param>
        /// <param name="strokeStyle">
        /// The style of stroke to paint, or <see cref="NULL"/> to paint a solid stroke.
        /// </param>
        /// <remarks>
        /// When this method fails, it does not return an error code.
        /// To determine whether a drawing method (such as <see cref="DrawRectangle"/>) failed,
        /// check the result returned by the <see cref="EndDraw"/> or <see cref="Flush"/> method.
        /// </remarks>
        public void DrawRectangle([In] in D2D1_RECT_F rect, [In] P<ID2D1Brush> brush, [In] FLOAT strokeWidth, [In] P<ID2D1StrokeStyle> strokeStyle)
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, in D2D1_RECT_F, P<ID2D1Brush>, FLOAT, P<ID2D1StrokeStyle>, void>)_vTable[16])
                    (thisPtr, rect, brush, strokeWidth, strokeStyle);
            }
        }

        /// <summary>
        /// Paints the interior of the specified rectangle.
        /// </summary>
        /// <param name="rect">
        /// The dimension of the rectangle to paint, in device-independent pixels.
        /// </param>
        /// <param name="brush">
        /// The brush used to paint the rectangle's interior.
        /// </param>
        /// <remarks>
        /// This method doesn't return an error code if it fails.
        /// To determine whether a drawing operation (such as <see cref="FillRectangle"/>) failed,
        /// check the result returned by the <see cref="EndDraw"/> or <see cref="Flush"/> methods.
        /// </remarks>
        public void FillRectangle([In] in D2D1_RECT_F rect, [In] P<ID2D1Brush> brush)
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, in D2D1_RECT_F, P<ID2D1Brush>, void>)_vTable[17])(thisPtr, rect, brush);
            }
        }

        /// <summary>
        /// Draws the outline of the specified rounded rectangle using the specified stroke style.
        /// </summary>
        /// <param name="roundedRect">
        /// The dimensions of the rounded rectangle to draw, in device-independent pixels.
        /// </param>
        /// <param name="brush">
        /// The brush used to paint the rounded rectangle's outline.
        /// </param>
        /// <param name="strokeWidth">
        /// The width of the stroke, in device-independent pixels.
        /// The value must be greater than or equal to 0.0f. If this parameter isn't specified, it defaults to 1.0f.
        /// The stroke is centered on the line.
        /// </param>
        /// <param name="strokeStyle">
        /// The style of the rounded rectangle's stroke, or <see cref="NULL"/> to paint a solid stroke.
        /// The default value is <see cref="NULL"/>.
        /// </param>
        /// <remarks>
        /// This method doesn't return an error code if it fails.
        /// To determine whether a drawing operation (such as <see cref="DrawRoundedRectangle"/>) failed,
        /// check the result returned by the <see cref="EndDraw"/> or <see cref="Flush"/> methods.
        /// </remarks>
        public void DrawRoundedRectangle([In] in D2D1_ROUNDED_RECT roundedRect, [In] P<ID2D1Brush> brush,
            [In] FLOAT strokeWidth, [In] P<ID2D1StrokeStyle> strokeStyle)
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, in D2D1_ROUNDED_RECT, P<ID2D1Brush>, FLOAT, P<ID2D1StrokeStyle>, void>)_vTable[18])
                    (thisPtr, roundedRect, brush, strokeWidth, strokeStyle);
            }
        }

        /// <summary>
        /// Paints the interior of the specified rounded rectangle.
        /// </summary>
        /// <param name="roundedRect">
        /// The dimensions of the rounded rectangle to paint, in device independent pixels.
        /// </param>
        /// <param name="brush">
        /// The brush used to paint the interior of the rounded rectangle.
        /// </param>
        /// <remarks>
        /// This method doesn't return an error code if it fails.
        /// To determine whether a drawing operation (such as <see cref="FillRoundedRectangle"/>) failed,
        /// check the result returned by the <see cref="EndDraw"/> or <see cref="Flush"/> methods.
        /// </remarks>
        public void FillRoundedRectangle([In] in D2D1_ROUNDED_RECT roundedRect, [In] P<ID2D1Brush> brush)
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, in D2D1_ROUNDED_RECT, P<ID2D1Brush>, void>)_vTable[19])(thisPtr, roundedRect, brush);
            }
        }

        /// <summary>
        /// Draws the outline of the specified ellipse using the specified stroke style.
        /// </summary>
        /// <param name="ellipse">
        /// The position and radius of the ellipse to draw, in device-independent pixels.
        /// </param>
        /// <param name="brush">
        /// The brush used to paint the ellipse's outline.
        /// </param>
        /// <param name="strokeWidth">
        /// The width of the stroke, in device-independent pixels.
        /// The value must be greater than or equal to 0.0f. If this parameter isn't specified, it defaults to 1.0f.
        /// The stroke is centered on the line.
        /// </param>
        /// <param name="strokeStyle">
        /// The style of stroke to apply to the ellipse's outline, or <see cref="NULL"/> to paint a solid stroke.
        /// </param>
        /// <remarks>
        /// The <see cref="DrawEllipse"/> method doesn't return an error code if it fails.
        /// To determine whether a drawing operation (such as <see cref="DrawEllipse"/>) failed,
        /// check the result returned by the <see cref="EndDraw"/> or <see cref="Flush"/> methods.
        /// </remarks>
        public void DrawEllipse([In] in D2D1_ELLIPSE ellipse, [In] P<ID2D1Brush> brush, [In] FLOAT strokeWidth, [In] P<ID2D1StrokeStyle> strokeStyle)
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, in D2D1_ELLIPSE, P<ID2D1Brush>, FLOAT, P<ID2D1StrokeStyle>, void>)_vTable[20])
                    (thisPtr, ellipse, brush, strokeWidth, strokeStyle);
            }
        }

        /// <summary>
        /// Paints the interior of the specified ellipse.
        /// </summary>
        /// <param name="ellipse">
        /// The position and radius, in device-independent pixels, of the ellipse to paint.
        /// </param>
        /// <param name="brush">
        /// The brush used to paint the interior of the ellipse.
        /// </param>
        /// <remarks>
        /// The method doesn't return an error code if it fails.
        /// To determine whether a drawing operation (such as <see cref="FillEllipse"/>) failed,
        /// check the result returned by the <see cref="EndDraw"/> or <see cref="Flush"/> methods.
        /// </remarks>
        public void FillEllipse([In] in D2D1_ELLIPSE ellipse, [In] P<ID2D1Brush> brush)
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, in D2D1_ELLIPSE, P<ID2D1Brush>, void>)_vTable[21])(thisPtr, ellipse, brush);
            }
        }

        /// <summary>
        /// Draws the outline of the specified geometry using the specified stroke style.
        /// </summary>
        /// <param name="geometry">
        /// The geometry to draw.
        /// </param>
        /// <param name="brush">
        /// The brush used to paint the geometry's stroke.
        /// </param>
        /// <param name="strokeWidth">
        /// The width of the stroke, in device-independent pixels.
        /// The value must be greater than or equal to 0.0f.
        /// If this parameter isn't specified, it defaults to 1.0f.
        /// The stroke is centered on the line.
        /// </param>
        /// <param name="strokeStyle">
        /// The style of stroke to apply to the geometry's outline, or <see cref="NULL"/> to paint a solid stroke.
        /// </param>
        /// <remarks>
        /// This method doesn't return an error code if it fails.
        /// To determine whether a drawing operation (such as <see cref="DrawGeometry"/>) failed,
        /// check the result returned by the <see cref="EndDraw"/> or <see cref="Flush"/> methods.
        /// </remarks>
        public void DrawGeometry([In] P<ID2D1Geometry> geometry, [In] P<ID2D1Brush> brush, [In] FLOAT strokeWidth, [In] P<ID2D1StrokeStyle> strokeStyle)
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, P<ID2D1Geometry>, P<ID2D1Brush>, FLOAT, P<ID2D1StrokeStyle>, void>)_vTable[22])
                    (thisPtr, geometry, brush, strokeWidth, strokeStyle);
            }
        }

        /// <summary>
        /// Paints the interior of the specified geometry.
        /// </summary>
        /// <param name="geometry">
        /// The geometry to paint.
        /// </param>
        /// <param name="brush">
        /// The brush used to paint the geometry's interior.
        /// </param>
        /// <param name="opacityBrush">
        /// The opacity mask to apply to the geometry, or <see cref="NULL"/> for no opacity mask.
        /// If an opacity mask (the <paramref name="opacityBrush"/> parameter) is specified,
        /// <paramref name="brush"/> must be an <see cref="ID2D1BitmapBrush"/>
        /// that has its x- and y-extend modes set to <see cref="D2D1_EXTEND_MODE_CLAMP"/>.
        /// For more information, see the Remarks section.
        /// </param>
        /// <remarks>
        /// <para>
        /// If the <paramref name="opacityBrush"/> parameter is not <see cref="NULL"/>,
        /// the alpha value of each pixel of the mapped <paramref name="opacityBrush"/>
        /// is used to determine the resulting opacity of each corresponding pixel of the geometry.
        /// Only the alpha value of each color in the brush is used for this processing; all other color information is ignored.
        /// </para>
        /// <para>
        /// The alpha value specified by the brush is multiplied by the alpha value of the geometry
        /// after the geometry has been painted by <paramref name="brush"/>.
        /// </para>
        /// <para>
        /// When this method fails, it does not return an error code.
        /// To determine whether a drawing operation (such as <see cref="FillGeometry"/>) failed,
        /// check the result returned by the <see cref="EndDraw"/> or <see cref="Flush"/> method.
        /// </para>
        /// </remarks>
        public void FillGeometry([In] P<ID2D1Geometry> geometry, [In] P<ID2D1Brush> brush, [In] P<ID2D1Brush> opacityBrush)
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, P<ID2D1Geometry>, P<ID2D1Brush>, P<ID2D1Brush>, void>)_vTable[23])
                    (thisPtr, geometry, brush, opacityBrush);
            }
        }

        /// <summary>
        /// Paints the interior of the specified mesh.
        /// </summary>
        /// <param name="mesh">
        /// The mesh to paint.
        /// </param>
        /// <param name="brush">
        /// The brush used to paint the mesh.
        /// </param>
        /// <remarks>
        /// <para>
        /// The current antialias mode of the render target must be <see cref="D2D1_ANTIALIAS_MODE_ALIASED"/> when <see cref="FillMesh"/> is called.
        /// To change the render target's antialias mode, use the <see cref="SetAntialiasMode"/> method.
        /// </para>
        /// <para>
        /// <see cref="FillMesh"/> does not expect a particular winding order for the triangles in the <see cref="ID2D1Mesh"/>;
        /// both clockwise and counter-clockwise will work.
        /// </para>
        /// <para>
        /// This method doesn't return an error code if it fails.
        /// To determine whether a drawing operation (such as <see cref="FillMesh"/>) failed,
        /// check the result returned by the <see cref="EndDraw"/> or <see cref="Flush"/> methods.
        /// </para>
        /// </remarks>
        public void FillMesh([In] P<ID2D1Mesh> mesh, [In] P<ID2D1Brush> brush)
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, P<ID2D1Mesh>, P<ID2D1Brush>, void>)_vTable[24])(thisPtr, mesh, brush);
            }
        }

        /// <summary>
        /// Applies the opacity mask described by the specified bitmap to a brush
        /// and uses that brush to paint a region of the render target.
        /// </summary>
        /// <param name="opacityMask">
        /// The opacity mask to apply to the brush.
        /// The alpha value of each pixel in the region specified by <paramref name="sourceRectangle"/>
        /// is multiplied with the alpha value of the brush
        /// after the brush has been mapped to the area defined by <paramref name="destinationRectangle"/>.
        /// </param>
        /// <param name="brush">
        /// The brush used to paint the region of the render target specified by <paramref name="destinationRectangle"/>.
        /// </param>
        /// <param name="content">
        /// <para>
        /// The type of content the opacity mask contains.
        /// The value is used to determine the color space in which the opacity mask is blended.
        /// </para>
        /// <para>
        /// Note
        /// </para>
        /// <para>
        /// Starting with Windows 8, the <see cref="D2D1_OPACITY_MASK_CONTENT"/> is not required.
        /// See the <see cref="ID2D1DeviceContext.FillOpacityMask"/> method, which has no <see cref="D2D1_OPACITY_MASK_CONTENT"/> parameter.
        /// </para>
        /// </param>
        /// <param name="destinationRectangle">
        /// The region of the render target to paint, in device-independent pixels, or <see cref="NULL"/>.
        /// If <see cref="NULL"/> is specified, the brush paints a rectangle the same size as <paramref name="sourceRectangle"/>,
        /// but positioned on the origin.
        /// If <paramref name="sourceRectangle"/> isn't specified,
        /// the brush paints a rectangle the same size as the <paramref name="opacityMask"/> bitmap and positioned on the origin.
        /// </param>
        /// <param name="sourceRectangle">
        /// The region of the bitmap to use as the opacity mask, in device-independent pixels,
        /// or <see cref="NullRef{D2D1_RECT_F}"/>.
        /// If <see cref="NullRef{D2D1_RECT_F}"/> is specified, the entire bitmap is used.
        /// </param>
        /// <remarks>
        /// <para>
        /// For this method to work properly, the render target must be using the <see cref="D2D1_ANTIALIAS_MODE_ALIASED"/> antialiasing mode.
        /// You can set the antialiasing mode by calling the <see cref="SetAntialiasMode"/> method.
        /// </para>
        /// <para>
        /// This method doesn't return an error code if it fails.
        /// To determine whether a drawing operation (such as <see cref="FillOpacityMask"/>) failed,
        /// check the result returned by the <see cref="EndDraw"/> or <see cref="Flush"/> methods.
        /// </para>
        /// </remarks>
        public void FillOpacityMask([In] P<ID2D1Bitmap> opacityMask, [In] P<ID2D1Brush> brush, [In] D2D1_OPACITY_MASK_CONTENT content,
            [In] in D2D1_RECT_F destinationRectangle, [In] in D2D1_RECT_F sourceRectangle)
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, P<ID2D1Bitmap>, P<ID2D1Brush>, D2D1_OPACITY_MASK_CONTENT,
                    in D2D1_RECT_F, in D2D1_RECT_F, void>)_vTable[25])(thisPtr, opacityMask, brush, content, destinationRectangle, sourceRectangle);
            }
        }

        /// <summary>
        /// Draws the specified bitmap after scaling it to the size of the specified rectangle.
        /// </summary>
        /// <param name="bitmap">
        /// The bitmap to render.
        /// </param>
        /// <param name="destinationRectangle">
        /// The size and position, in device-independent pixels in the render target's coordinate space,
        /// of the area to which the bitmap is drawn;
        /// <see cref="NullRef{D2D1_RECT_F}"/> to draw the selected portion of the bitmap at the origin of the render target.
        /// If the rectangle is specified but not well-ordered, nothing is drawn, but the render target does not enter an error state.
        /// </param>
        /// <param name="opacity">
        /// A value between 0.0f and 1.0f, inclusive, that specifies an opacity value to apply to the bitmap;
        /// this value is multiplied against the alpha values of the bitmap's contents.
        /// The default value is 1.0f.
        /// </param>
        /// <param name="interpolationMode">
        /// The interpolation mode to use if the bitmap is scaled or rotated by the drawing operation.
        /// The default value is <see cref="D2D1_BITMAP_INTERPOLATION_MODE_LINEAR"/>.
        /// </param>
        /// <param name="sourceRectangle">
        /// The size and position, in device-independent pixels in the bitmap's coordinate space,
        /// of the area within the bitmap to be drawn;
        /// <see cref="NullRef{D2D1_RECT_F}"/> to draw the entire bitmap.
        /// </param>
        /// <remarks>
        /// This method doesn't return an error code if it fails.
        /// To determine whether a drawing operation (such as <see cref="DrawBitmap"/>) failed,
        /// check the result returned by the <see cref="EndDraw"/> or <see cref="Flush"/> methods.
        /// </remarks>
        public void DrawBitmap([In] P<ID2D1Bitmap> bitmap, [In] in D2D1_RECT_F destinationRectangle, [In] FLOAT opacity,
            [In] D2D1_BITMAP_INTERPOLATION_MODE interpolationMode, [In] in D2D1_RECT_F sourceRectangle)
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, P<ID2D1Bitmap>, in D2D1_RECT_F, FLOAT,
                    D2D1_BITMAP_INTERPOLATION_MODE, in D2D1_RECT_F, void>)_vTable[26])
                    (thisPtr, bitmap, destinationRectangle, opacity, interpolationMode, sourceRectangle);
            }
        }

        /// <summary>
        /// Draws the specified text using the format information provided by an <see cref="IDWriteTextFormat"/> object.
        /// </summary>
        /// <param name="string">
        /// A pointer to an array of Unicode characters to draw.
        /// </param>
        /// <param name="stringLength">
        /// The number of characters in <paramref name="string"/>.
        /// </param>
        /// <param name="textFormat">
        /// An object that describes formatting details of the text to draw, such as the font, the font size, and flow direction.
        /// </param>
        /// <param name="layoutRect">
        /// The size and position of the area in which the text is drawn.
        /// </param>
        /// <param name="defaultFillBrush">
        /// The brush used to paint the text.
        /// </param>
        /// <param name="options">
        /// A value that indicates whether the text should be snapped to pixel boundaries
        /// and whether the text should be clipped to the layout rectangle.
        /// The default value is <see cref="D2D1_DRAW_TEXT_OPTIONS_NONE"/>,
        /// which indicates that text should be snapped to pixel boundaries and it should not be clipped to the layout rectangle.
        /// </param>
        /// <param name="measuringMode">
        /// A value that indicates how glyph metrics are used to measure text when it is formatted.
        /// The default value is <see cref="DWRITE_MEASURING_MODE_NATURAL"/>.
        /// </param>
        /// <remarks>
        /// <para>
        /// To create an <see cref="IDWriteTextFormat"/> object,
        /// create an <see cref="IDWriteFactory"/> and call its <see cref="IDWriteFactory.CreateTextFormat"/> method.
        /// </para>
        /// <para>
        /// This method doesn't return an error code if it fails.
        /// To determine whether a drawing operation (such as <see cref="DrawText"/>) failed,
        /// check the result returned by the <see cref="EndDraw"/> or <see cref="Flush"/> methods.
        /// </para>
        /// </remarks>
        public void DrawText([In] LPCWSTR @string, [In] UINT32 stringLength, [In] P<IDWriteTextFormat> textFormat,
            [In] in D2D1_RECT_F layoutRect, [In] P<ID2D1Brush> defaultFillBrush, [In] D2D1_DRAW_TEXT_OPTIONS options,
            [In] DWRITE_MEASURING_MODE measuringMode)
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, nint, UINT32, P<IDWriteTextFormat>, in D2D1_RECT_F, P<ID2D1Brush>,
                    D2D1_DRAW_TEXT_OPTIONS, DWRITE_MEASURING_MODE, void>)_vTable[27])
                    (thisPtr, @string.ToNint(), stringLength, textFormat, layoutRect, defaultFillBrush, options, measuringMode);
            }
        }

        /// <summary>
        /// Draws the formatted text described by the specified <see cref="IDWriteTextLayout"/> object.
        /// </summary>
        /// <param name="origin">
        /// The point, described in device-independent pixels, at which the upper-left corner of the text described by textLayout is drawn.
        /// </param>
        /// <param name="textLayout">
        /// The formatted text to draw.
        /// Any drawing effects that do not inherit from <see cref="ID2D1Resource"/> are ignored.
        /// If there are drawing effects that inherit from <see cref="ID2D1Resource"/> that are not brushes,
        /// this method fails and the render target is put in an error state.
        /// </param>
        /// <param name="defaultFillBrush">
        /// The brush used to paint any text in <paramref name="textLayout"/>
        /// that does not already have a brush associated with it as a drawing effect
        /// (specified by the <see cref="IDWriteTextLayout.SetDrawingEffect"/> method).
        /// </param>
        /// <param name="options">
        /// A value that indicates whether the text should be snapped to pixel boundaries
        /// and whether the text should be clipped to the layout rectangle.
        /// The default value is <see cref="D2D1_DRAW_TEXT_OPTIONS_NONE"/>,
        /// which indicates that text should be snapped to pixel boundaries and it should not be clipped to the layout rectangle.
        /// </param>
        /// <remarks>
        /// <para>
        /// When drawing the same text repeatedly, using the <see cref="DrawTextLayout"/> method
        /// is more efficient than using the <see cref="DrawText"/> method
        /// because the text doesn't need to be formatted and the layout processed with each call.
        /// </para>
        /// <para>
        /// This method doesn't return an error code if it fails.
        /// To determine whether a drawing operation (such as <see cref="DrawTextLayout"/>) failed,
        /// check the result returned by the <see cref="EndDraw"/> or <see cref="Flush"/> methods.
        /// </para>
        /// </remarks>
        public void DrawTextLayout([In] D2D1_POINT_2F origin, [In] P<IDWriteTextLayout> textLayout,
            [In] P<ID2D1Brush> defaultFillBrush, [In] D2D1_DRAW_TEXT_OPTIONS options)
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, D2D1_POINT_2F, P<IDWriteTextLayout>, P<ID2D1Brush>, D2D1_DRAW_TEXT_OPTIONS, void>)_vTable[28])
                    (thisPtr, origin, textLayout, defaultFillBrush, options);
            }
        }

        /// <summary>
        /// Draws the specified glyphs.
        /// </summary>
        /// <param name="baselineOrigin">
        /// The origin, in device-independent pixels, of the glyphs' baseline.
        /// </param>
        /// <param name="glyphRun">
        /// The glyphs to render.
        /// </param>
        /// <param name="foregroundBrush">
        /// The brush used to paint the specified glyphs.
        /// </param>
        /// <param name="measuringMode">
        /// A value that indicates how glyph metrics are used to measure text when it is formatted.
        /// The default value is <see cref="DWRITE_MEASURING_MODE_NATURAL"/>.
        /// </param>
        /// <remarks>
        /// This method doesn't return an error code if it fails.
        /// To determine whether a drawing operation (such as <see cref="DrawGlyphRun"/>) failed,
        /// check the result returned by the <see cref="EndDraw"/> or <see cref="Flush"/> methods.
        /// </remarks>
        public void DrawGlyphRun([In] D2D1_POINT_2F baselineOrigin, [In] in DWRITE_GLYPH_RUN glyphRun,
            [In] P<ID2D1Brush> foregroundBrush, [In] DWRITE_MEASURING_MODE measuringMode)
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, D2D1_POINT_2F, in DWRITE_GLYPH_RUN, P<ID2D1Brush>, DWRITE_MEASURING_MODE, void>)_vTable[29])
                    (thisPtr, baselineOrigin, glyphRun, foregroundBrush, measuringMode);
            }
        }

        /// <summary>
        /// Applies the specified transform to the render target, replacing the existing transformation.
        /// All subsequent drawing operations occur in the transformed space.
        /// </summary>
        /// <param name="transform">
        /// The transform to apply to the render target.
        /// </param>
        public void SetTransform([In] in D2D1_MATRIX_3X2_F transform)
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, in D2D1_MATRIX_3X2_F, void>)_vTable[30])(thisPtr, transform);
            }
        }

        /// <summary>
        /// Gets the current transform of the render target.
        /// </summary>
        /// <param name="transform">
        /// When this returns, contains the current transform of the render target.
        /// This parameter is passed uninitialized.
        /// </param>
        public void GetTransform([Out] out D2D1_MATRIX_3X2_F transform)
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, out D2D1_MATRIX_3X2_F, void>)_vTable[31])(thisPtr, out transform);
            }
        }

        /// <summary>
        /// Sets the antialiasing mode of the render target.
        /// The antialiasing mode applies to all subsequent drawing operations, excluding text and glyph drawing operations.
        /// </summary>
        /// <param name="antialiasMode">
        /// The antialiasing mode for future drawing operations.
        /// </param>
        /// <remarks>
        /// To specify the antialiasing mode for text and glyph operations, use the <see cref="SetTextAntialiasMode"/> method.
        /// </remarks>
        public void SetAntialiasMode([In] D2D1_ANTIALIAS_MODE antialiasMode)
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, D2D1_ANTIALIAS_MODE, void>)_vTable[32])(thisPtr, antialiasMode);
            }
        }

        /// <summary>
        /// Retrieves the current antialiasing mode for nontext drawing operations.
        /// </summary>
        /// <returns>
        /// The current antialiasing mode for nontext drawing operations.
        /// </returns>
        public D2D1_ANTIALIAS_MODE GetAntialiasMode()
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, D2D1_ANTIALIAS_MODE>)_vTable[33])(thisPtr);
            }
        }

        /// <summary>
        /// Specifies the antialiasing mode to use for subsequent text and glyph drawing operations.
        /// </summary>
        /// <param name="textAntialiasMode">
        /// The antialiasing mode to use for subsequent text and glyph drawing operations.
        /// </param>
        public void SetTextAntialiasMode([In] D2D1_TEXT_ANTIALIAS_MODE textAntialiasMode)
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, D2D1_TEXT_ANTIALIAS_MODE, void>)_vTable[34])(thisPtr, textAntialiasMode);
            }
        }

        /// <summary>
        /// Gets the current antialiasing mode for text and glyph drawing operations.
        /// </summary>
        /// <returns>
        /// The current antialiasing mode for text and glyph drawing operations.
        /// </returns>
        public D2D1_TEXT_ANTIALIAS_MODE GetTextAntialiasMode()
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, D2D1_TEXT_ANTIALIAS_MODE>)_vTable[35])(thisPtr);
            }
        }

        /// <summary>
        /// Specifies text rendering options to be applied to all subsequent text and glyph drawing operations.
        /// </summary>
        /// <param name="textRenderingParams">
        /// The text rendering options to be applied to all subsequent text and glyph drawing operations;
        /// <see cref="NULL"/> to clear current text rendering options.
        /// </param>
        /// <remarks>
        /// If the settings specified by <paramref name="textRenderingParams"/> are incompatible with the render target's text antialiasing mode
        /// (specified by <see cref="SetTextAntialiasMode"/>),
        /// subsequent text and glyph drawing operations will fail and put the render target into an error state.
        /// </remarks>
        public void SetTextRenderingParams([In] P<IDWriteRenderingParams> textRenderingParams)
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, P<IDWriteRenderingParams>, void>)_vTable[36])(thisPtr, textRenderingParams);
            }
        }

        /// <summary>
        /// Retrieves the render target's current text rendering options.
        /// </summary>
        /// <param name="textRenderingParams">
        /// When this method returns, <paramref name="textRenderingParams"/> contains
        /// the address of a pointer to the render target's current text rendering options.
        /// </param>
        /// <remarks>
        /// If the settings specified by <paramref name="textRenderingParams"/> are incompatible with the render target's text antialiasing mode
        /// (specified by <see cref="SetTextAntialiasMode"/>),
        /// subsequent text and glyph drawing operations will fail and put the render target into an error state.
        /// </remarks>
        public void GetTextRenderingParams([Out] out P<IDWriteRenderingParams> textRenderingParams)
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, out P<IDWriteRenderingParams>, void>)_vTable[37])(thisPtr, out textRenderingParams);
            }
        }

        /// <summary>
        /// Specifies a label for subsequent drawing operations.
        /// </summary>
        /// <param name="tag1">
        /// A label to apply to subsequent drawing operations.
        /// </param>
        /// <param name="tag2">
        /// A label to apply to subsequent drawing operations.
        /// </param>
        /// <remarks>
        /// The labels specified by this method are printed by debug error messages.
        /// If no tag is set, the default value for each tag is 0.
        /// </remarks>
        public void SetTags([In] D2D1_TAG tag1, [In] D2D1_TAG tag2)
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, D2D1_TAG, D2D1_TAG, void>)_vTable[38])(thisPtr, tag1, tag2);
            }
        }

        /// <summary>
        /// Gets the label for subsequent drawing operations.
        /// </summary>
        /// <param name="tag1">
        /// When this method returns, contains the first label for subsequent drawing operations.
        /// This parameter is passed uninitialized.
        /// If <see cref="NullRef{D2D1_TAG}"/> is specified, no value is retrieved for this parameter.
        /// </param>
        /// <param name="tag2">
        /// When this method returns, contains the second label for subsequent drawing operations.
        /// This parameter is passed uninitialized.
        /// If <see cref="NullRef{D2D1_TAG}"/> is specified, no value is retrieved for this parameter.
        /// </param>
        /// <remarks>
        /// If the same address is passed for both parameters, both parameters receive the value of the second tag.
        /// </remarks>
        public void GetTags([Out] out D2D1_TAG tag1, [Out] out D2D1_TAG tag2)
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, out D2D1_TAG, out D2D1_TAG, void>)_vTable[39])(thisPtr, out tag1, out tag2);
            }
        }

        /// <summary>
        /// Adds the specified layer to the render target so that it receives all subsequent drawing operations
        /// until <see cref="PopLayer"/> is called.
        /// </summary>
        /// <param name="layerParameters">
        /// The content bounds, geometric mask, opacity, opacity mask, and antialiasing options for the layer.
        /// </param>
        /// <param name="layer">
        /// <para>
        /// The layer that receives subsequent drawing operations.
        /// </para>
        /// <para>
        /// Note
        /// </para>
        /// <para>
        /// Starting with Windows 8, this parameter is optional.
        /// If a layer is not specified, Direct2D manages the layer resource automatically.
        /// </para>
        /// </param>
        /// <remarks>
        /// <para>
        /// The <see cref="PushLayer"/> method allows a caller to begin redirecting rendering to a layer.
        /// All rendering operations are valid in a layer.
        /// The location of the layer is affected by the world transform set on the render target.
        /// </para>
        /// <para>
        /// Each <see cref="PushLayer"/> must have a matching <see cref="PopLayer"/> call.
        /// If there are more <see cref="PopLayer"/> calls than <see cref="PushLayer"/> calls,
        /// the render target is placed into an error state.
        /// If <see cref="Flush"/> is called before all outstanding layers are popped,
        /// the render target is placed into an error state, and an error is returned.
        /// The error state can be cleared by a call to <see cref="EndDraw"/>.
        /// </para>
        /// <para>
        /// A particular <see cref="ID2D1Layer"/> resource can be active only at one time.
        /// In other words, you cannot call a <see cref="PushLayer"/> method,
        /// and then immediately follow with another <see cref="PushLayer"/> method with the same layer resource.
        /// Instead, you must call the second <see cref="PushLayer"/> method with different layer resources.
        /// </para>
        /// <para>
        /// This method doesn't return an error code if it fails.
        /// To determine whether a drawing operation (such as <see cref="PushLayer"/>) failed,
        /// check the result returned by the <see cref="EndDraw"/> or <see cref="Flush"/> methods.
        /// </para>
        /// </remarks>
        public void PushLayer([In] in D2D1_LAYER_PARAMETERS layerParameters, [In] P<ID2D1Layer> layer)
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, in D2D1_LAYER_PARAMETERS, P<ID2D1Layer>, void>)_vTable[40])(thisPtr, layerParameters, layer);
            }
        }

        /// <summary>
        /// Stops redirecting drawing operations to the layer that is specified by the last <see cref="PushLayer"/> call.
        /// </summary>
        /// <remarks>
        /// <para>
        /// A <see cref="PopLayer"/> must match a previous <see cref="PushLayer"/> call.
        /// </para>
        /// <para>
        /// This method doesn't return an error code if it fails.
        /// To determine whether a drawing operation (such as <see cref="PopLayer"/>) failed,
        /// check the result returned by the <see cref="EndDraw"/> or <see cref="Flush"/> methods.
        /// </para>
        /// </remarks>
        public void PopLayer()
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, void>)_vTable[41])(thisPtr);
            }
        }

        /// <summary>
        /// Executes all pending drawing commands.
        /// </summary>
        /// <param name="tag1">
        /// When this method returns, contains the tag for drawing operations that caused errors or 0 if there were no errors.
        /// This parameter is passed uninitialized.
        /// </param>
        /// <param name="tag2">
        /// When this method returns, contains the tag for drawing operations that caused errors or 0 if there were no errors.
        /// This parameter is passed uninitialized.
        /// </param>
        /// <returns>
        /// If the method succeeds, it returns <see cref="S_OK"/>.
        /// Otherwise, it returns an <see cref="HRESULT"/> error code
        /// and sets <paramref name="tag1"/> and <paramref name="tag2"/> to the tags that were active when the error occurred.
        /// If no error occurred, this method sets the error tag state to be (0,0).
        /// </returns>
        /// <remarks>
        /// <para>
        /// This command does not flush the Direct3D device context that is associated with the render target.
        /// </para>
        /// <para>
        /// Calling this method resets the error state of the render target.
        /// </para>
        /// </remarks>
        public HRESULT Flush([Out] out D2D1_TAG tag1, [Out] out D2D1_TAG tag2)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, out D2D1_TAG, out D2D1_TAG, HRESULT>)_vTable[42])(thisPtr, out tag1, out tag2);
            }
        }

        /// <summary>
        /// Saves the current drawing state to the specified <see cref="ID2D1DrawingStateBlock"/>.
        /// </summary>
        /// <param name="drawingStateBlock">
        /// When this method returns, contains the current drawing state of the render target.
        /// This parameter must be initialized before passing it to the method.
        /// </param>
        public void SaveDrawingState([In] P<ID2D1DrawingStateBlock> drawingStateBlock)
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, P<ID2D1DrawingStateBlock>, void>)_vTable[43])(thisPtr, drawingStateBlock);
            }
        }

        /// <summary>
        /// Sets the render target's drawing state to that of the specified <see cref="ID2D1DrawingStateBlock"/>.
        /// </summary>
        /// <param name="drawingStateBlock">
        /// The new drawing state of the render target.
        /// </param>
        public void RestoreDrawingState([In] P<ID2D1DrawingStateBlock> drawingStateBlock)
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, P<ID2D1DrawingStateBlock>, void>)_vTable[44])(thisPtr, drawingStateBlock);
            }
        }

        /// <summary>
        /// Specifies a rectangle to which all subsequent drawing operations are clipped.
        /// </summary>
        /// <param name="clipRect">
        /// The size and position of the clipping area, in device-independent pixels.
        /// </param>
        /// <param name="antialiasMode">
        /// The antialiasing mode that is used to draw the edges of clip rects that have subpixel boundaries,
        /// and to blend the clip with the scene contents.
        /// The blending is performed once when the <see cref="PopAxisAlignedClip"/> method is called,
        /// and does not apply to each primitive within the layer.
        /// </param>
        /// <remarks>
        /// <para>
        /// The <paramref name="clipRect"/> is transformed by the current world transform set on the render target.
        /// After the transform is applied to the <paramref name="clipRect"/> that is passed in,
        /// the axis-aligned bounding box for the <paramref name="clipRect"/> is computed.
        /// For efficiency, the contents are clipped to this axis-aligned bounding box
        /// and not to the original <paramref name="clipRect"/> that is passed in.
        /// </para>
        /// <para>
        /// The following diagrams show how a rotation transform is applied to the render target,
        /// the resulting <paramref name="clipRect"/>, and a calculated axis-aligned bounding box.
        /// </para>
        /// <para>
        /// <list type="number">
        /// <item>
        /// <description>
        /// Assume the rectangle in the following illustration is a render target that is aligned to the screen pixels. 
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Apply a rotation transform to the render target.
        /// In the following illustration, the black rectangle represents the original render target
        /// and the red dashed rectangle represents the transformed render target. 
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// After calling <see cref="PushAxisAlignedClip"/>, the rotation transform is applied to the <paramref name="clipRect"/>.
        /// In the following illustration, the blue rectangle represents the transformed <paramref name="clipRect"/>. 
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// The axis-aligned bounding box is calculated.
        /// The green dashed rectangle represents the bounding box in the following illustration.
        /// All contents are clipped to this axis-aligned bounding box. 
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// Note
        /// </para>
        /// <para>
        /// If rendering operations fail or if <see cref="PopAxisAlignedClip"/> is not called,
        /// clip rects may cause some artifacts on the render target.
        /// <see cref="PopAxisAlignedClip"/> can be considered a drawing operation
        /// that is designed to fix the borders of a clipping region.
        /// Without this call, the borders of a clipped area may be not antialiased or otherwise corrected.
        /// The <see cref="PushAxisAlignedClip"/> and <see cref="PopAxisAlignedClip"/> must match.
        /// Otherwise, the error state is set. For the render target to continue receiving new commands,
        /// you can call <see cref="Flush"/> to clear the error.
        /// </para>
        /// <para>
        /// A <see cref="PushAxisAlignedClip"/> and <see cref="PopAxisAlignedClip"/> pair can occur around
        /// or within a <see cref="PushLayer"/> and <see cref="PopLayer"/>, but cannot overlap.
        /// For example, the sequence of <see cref="PushAxisAlignedClip"/>, <see cref="PushLayer"/>,
        /// <see cref="PopLayer"/>, <see cref="PopAxisAlignedClip"/> is valid,
        /// but the sequence of <see cref="PushAxisAlignedClip"/>, <see cref="PushLayer"/>,
        /// <see cref="PopAxisAlignedClip"/>, <see cref="PopLayer"/> is invalid.
        /// </para>
        /// <para>
        /// This method doesn't return an error code if it fails.
        /// To determine whether a drawing operation (such as <see cref="PushAxisAlignedClip"/>) failed,
        /// check the result returned by the <see cref="EndDraw"/> or <see cref="Flush"/> methods.
        /// </para>
        /// </remarks>
        public void PushAxisAlignedClip([In] in D2D1_RECT_F clipRect, [In] D2D1_ANTIALIAS_MODE antialiasMode)
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, in D2D1_RECT_F, D2D1_ANTIALIAS_MODE, void>)_vTable[45])(thisPtr, clipRect, antialiasMode);
            }
        }

        /// <summary>
        /// Removes the last axis-aligned clip from the render target.
        /// After this method is called, the clip is no longer applied to subsequent drawing operations.
        /// </summary>
        /// <remarks>
        /// <para>
        /// A <see cref="PushAxisAlignedClip"/>/<see cref="PopAxisAlignedClip"/> pair can occur around
        /// or within a <see cref="PushLayer"/>/<see cref="PopLayer"/> pair, but may not overlap.
        /// For example, a <see cref="PushAxisAlignedClip"/>, <see cref="PushLayer"/>,
        /// <see cref="PopLayer"/>, <see cref="PopAxisAlignedClip"/> sequence is valid,
        /// but a <see cref="PushAxisAlignedClip"/>, <see cref="PushLayer"/>,
        /// <see cref="PopAxisAlignedClip"/>, <see cref="PopLayer"/> sequence is not.
        /// </para>
        /// <para>
        /// <see cref="PopAxisAlignedClip"/> must be called once for every call to <see cref="PushAxisAlignedClip"/>.
        /// </para>
        /// <para>
        /// For an example, see How to Clip with an Axis-Aligned Clip Rectangle.
        /// </para>
        /// <para>
        /// This method doesn't return an error code if it fails.
        /// To determine whether a drawing operation (such as <see cref="PopAxisAlignedClip"/>) failed,
        /// check the result returned by the <see cref="EndDraw"/> or <see cref="Flush"/> methods.
        /// </para>
        /// </remarks>
        public void PopAxisAlignedClip()
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, void>)_vTable[46])(thisPtr);
            }
        }

        /// <summary>
        /// Clears the drawing area to the specified color.
        /// </summary>
        /// <param name="clearColor">
        /// The color to which the drawing area is cleared,
        /// or <see cref="NullRef{D2D1_COLOR_F}"/> for transparent black.
        /// </param>
        /// <remarks>
        /// <para>
        /// Direct2D interprets the <paramref name="clearColor"/> as straight alpha (not premultiplied).
        /// If the render target's alpha mode is <see cref="D2D1_ALPHA_MODE_IGNORE"/>,
        /// the alpha channel of <paramref name="clearColor"/> is ignored and replaced with 1.0f (fully opaque).
        /// </para>
        /// <para>
        /// If the render target has an active clip (specified by <see cref="PushAxisAlignedClip"/>),
        /// the clear command is applied only to the area within the clip region.
        /// </para>
        /// </remarks>
        public void Clear([In] in D2D1_COLOR_F clearColor)
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, in D2D1_COLOR_F, void>)_vTable[47])(thisPtr, clearColor);
            }
        }

        /// <summary>
        /// Initiates drawing on this render target.
        /// </summary>
        /// <remarks>
        /// <para>
        /// Drawing operations can only be issued between a <see cref="BeginDraw"/> and <see cref="EndDraw"/> call.
        /// </para>
        /// <para>
        /// BeginDraw and EndDraw are used to indicate that a render target is in use by the Direct2D system.
        /// Different implementations of <see cref="ID2D1RenderTarget"/> might behave differently when <see cref="BeginDraw"/> is called.
        /// An <see cref="ID2D1BitmapRenderTarget"/> may be locked between <see cref="BeginDraw"/>/<see cref="EndDraw"/> calls,
        /// a DXGI surface render target might be acquired on <see cref="BeginDraw"/> and released on <see cref="EndDraw"/>,
        /// while an <see cref="ID2D1HwndRenderTarget"/> may begin batching at <see cref="BeginDraw"/>
        /// and may present on <see cref="EndDraw"/>, for example.
        /// </para>
        /// <para>
        /// The BeginDraw method must be called before rendering operations can be called,
        /// though state-setting and state-retrieval operations can be performed even outside of <see cref="BeginDraw"/>/<see cref="EndDraw"/>.
        /// </para>
        /// <para>
        /// After <see cref="BeginDraw"/> is called, a render target will normally build up a batch of rendering commands,
        /// but defer processing of these commands until either an internal buffer is full,
        /// the <see cref="Flush"/> method is called, or until <see cref="EndDraw"/> is called.
        /// The <see cref="EndDraw"/> method causes any batched drawing operations to complete,
        /// and then returns an <see cref="HRESULT"/> indicating the success of the operations and,
        /// optionally, the tag state of the render target at the time the error occurred.
        /// The <see cref="EndDraw"/> method always succeeds:
        /// it should not be called twice even if a previous <see cref="EndDraw"/> resulted in a failing <see cref="HRESULT"/>.
        /// </para>
        /// <para>
        /// If <see cref="EndDraw"/> is called without a matched call to <see cref="BeginDraw"/>,
        /// it returns an error indicating that <see cref="BeginDraw"/> must be called before <see cref="EndDraw"/>.
        /// </para>
        /// <para>
        /// Calling <see cref="BeginDraw"/> twice on a render target puts the target into an error state where nothing further is drawn,
        /// and returns an appropriate <see cref="HRESULT"/> and error information when <see cref="EndDraw"/> is called.
        /// </para>
        /// </remarks>
        public void BeginDraw()
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, void>)_vTable[48])(thisPtr);
            }
        }

        /// <summary>
        /// Ends drawing operations on the render target and indicates the current error state and associated tags.
        /// </summary>
        /// <param name="tag1">
        /// When this method returns, contains the tag for drawing operations
        /// that caused errors or 0 if there were no errors.
        /// This parameter is passed uninitialized.
        /// </param>
        /// <param name="tag2">
        /// When this method returns, contains the tag for drawing operations
        /// that caused errors or 0 if there were no errors.
        /// This parameter is passed uninitialized.
        /// </param>
        /// <returns>
        /// If the method succeeds, it returns <see cref="S_OK"/>.
        /// Otherwise, it returns an <see cref="HRESULT"/> error code
        /// and sets <paramref name="tag1"/> and <paramref name="tag2"/> to the tags that were active when the error occurred.
        /// </returns>
        /// <remarks>
        /// <para>
        /// Drawing operations can only be issued between a <see cref="BeginDraw"/> and <see cref="EndDraw"/> call.
        /// </para>
        /// <para>
        /// <see cref="BeginDraw"/> and <see cref="EndDraw"/> are use to indicate that a render target is in use by the Direct2D system.
        /// Different implementations of <see cref="ID2D1RenderTarget"/> might behave differently when <see cref="BeginDraw"/> is called.
        /// An <see cref="ID2D1BitmapRenderTarget"/> may be locked between <see cref="BeginDraw"/>/<see cref="EndDraw"/> calls,
        /// a DXGI surface render target might be acquired on <see cref="BeginDraw"/> and released on <see cref="EndDraw"/>,
        /// while an <see cref="ID2D1HwndRenderTarget"/> may begin batching at <see cref="BeginDraw"/>
        /// and may present on <see cref="EndDraw"/>, for example.
        /// </para>
        /// <para>
        /// The <see cref="BeginDraw"/> method must be called before rendering operations can be called,
        /// though state-setting and state-retrieval operations can be performed
        /// even outside of <see cref="BeginDraw"/>/<see cref="EndDraw"/>.
        /// </para>
        /// <para>
        /// After <see cref="BeginDraw"/> is called, a render target will normally build up a batch of rendering commands,
        /// but defer processing of these commands until either an internal buffer is full,
        /// the <see cref="Flush"/> method is called, or until <see cref="EndDraw"/> is called.
        /// The <see cref="EndDraw"/> method causes any batched drawing operations to complete,
        /// and then returns an <see cref="HRESULT"/> indicating the success of the operations and,
        /// optionally, the tag state of the render target at the time the error occurred.
        /// The <see cref="EndDraw"/> method always succeeds:
        /// it should not be called twice even if a previous <see cref="EndDraw"/> resulted in a failing <see cref="HRESULT"/>.
        /// </para>
        /// <para>
        /// If <see cref="EndDraw"/> is called without a matched call to <see cref="BeginDraw"/>,
        /// it returns an error indicating that <see cref="BeginDraw"/> must be called before <see cref="EndDraw"/>.
        /// </para>
        /// <para>
        /// Calling <see cref="BeginDraw"/> twice on a render target
        /// puts the target into an error state where nothing further is drawn,
        /// and returns an appropriate <see cref="HRESULT"/> and error information when <see cref="EndDraw"/> is called.
        /// </para>
        /// </remarks>
        public HRESULT EndDraw([Out] out D2D1_TAG tag1, [Out] out D2D1_TAG tag2)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, out D2D1_TAG, out D2D1_TAG, HRESULT>)_vTable[49])(thisPtr, out tag1, out tag2);
            }
        }

        /// <summary>
        /// Retrieves the pixel format and alpha mode of the render target.
        /// </summary>
        /// <returns>
        /// The pixel format and alpha mode of the render target.
        /// </returns>
        public D2D1_PIXEL_FORMAT GetPixelFormat()
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, D2D1_PIXEL_FORMAT>)_vTable[50])(thisPtr);
            }
        }

        /// <summary>
        /// Sets the dots per inch (DPI) of the render target.
        /// </summary>
        /// <param name="dpiX">
        /// A value greater than or equal to zero that specifies the horizontal DPI of the render target.
        /// </param>
        /// <param name="dpiY">
        /// A value greater than or equal to zero that specifies the vertical DPI of the render target.
        /// </param>
        /// <remarks>
        /// <para>
        /// This method specifies the mapping from pixel space to device-independent space for the render target.
        /// If both <paramref name="dpiX"/> and <paramref name="dpiY"/> are 0, the factory-read system DPI is chosen.
        /// If one parameter is zero and the other unspecified, the DPI is not changed.
        /// </para>
        /// <para>
        /// For <see cref="ID2D1HwndRenderTarget"/>, the DPI defaults to the most recently factory-read system DPI.
        /// The default value for all other render targets is 96 DPI.
        /// </para>
        /// </remarks>
        public void SetDpi([In] FLOAT dpiX, [In] FLOAT dpiY)
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, FLOAT, FLOAT, void>)_vTable[51])(thisPtr, dpiX, dpiY);
            }
        }

        /// <summary>
        /// Return the render target's dots per inch (DPI).
        /// </summary>
        /// <param name="dpiX">
        /// When this method returns, contains the horizontal DPI of the render target.
        /// This parameter is passed uninitialized.
        /// </param>
        /// <param name="dpiY">
        /// When this method returns, contains the vertical DPI of the render target.
        /// This parameter is passed uninitialized.
        /// </param>
        /// <remarks>
        /// <para>
        /// This method indicates the mapping from pixel space to device-independent space for the render target.
        /// </para>
        /// <para>
        /// For <see cref="ID2D1HwndRenderTarget"/>, the DPI defaults to the most recently factory-read system DPI.
        /// The default value for all other render targets is 96 DPI.
        /// </para>
        /// </remarks>
        public void GetDpi([Out] out FLOAT dpiX, [Out] out FLOAT dpiY)
        {
            fixed (void* thisPtr = &this)
            {
                ((delegate* unmanaged[Stdcall]<void*, out FLOAT, out FLOAT, void>)_vTable[52])(thisPtr, out dpiX, out dpiY);
            }
        }

        /// <summary>
        /// Returns the size of the render target in device-independent pixels.
        /// </summary>
        /// <returns>
        /// The current size of the render target in device-independent pixels.
        /// </returns>
        public D2D1_SIZE_F GetSize()
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, D2D1_SIZE_F>)_vTable[53])(thisPtr);
            }
        }

        /// <summary>
        /// Returns the size of the render target in device pixels.
        /// </summary>
        /// <returns>
        /// The size of the render target in device pixels.
        /// </returns>
        public D2D1_SIZE_U GetPixelSize()
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, D2D1_SIZE_U>)_vTable[54])(thisPtr);
            }
        }

        /// <summary>
        /// Gets the maximum size, in device-dependent units (pixels), of any one bitmap dimension supported by the render target.
        /// </summary>
        /// <returns>
        /// The maximum size, in pixels, of any one bitmap dimension supported by the render target.
        /// </returns>
        /// <remarks>
        /// <para>
        /// This method returns the maximum texture size of the Direct3D device.
        /// </para>
        /// <para>
        /// Note
        /// </para>
        /// <para>
        /// The software renderer and WARP devices return the value of 16 megapixels (16*1024*1024).
        /// You can create a Direct2D texture that is this size, but not a Direct3D texture that is this size.
        /// </para>
        /// </remarks>
        public UINT32 GetMaximumBitmapSize()
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, UINT32>)_vTable[55])(thisPtr);
            }
        }

        /// <summary>
        /// Indicates whether the render target supports the specified properties.
        /// </summary>
        /// <param name="renderTargetProperties">
        /// The render target properties to test.
        /// </param>
        /// <returns>
        /// <see cref="TRUE"/> if the specified render target properties are supported by this render target;
        /// otherwise, <see cref="FALSE"/>.
        /// </returns>
        /// <remarks>
        /// This method does not evaluate the DPI settings
        /// specified by the <paramref name="renderTargetProperties"/> parameter.
        /// </remarks>
        public BOOL IsSupported([In] in D2D1_RENDER_TARGET_PROPERTIES renderTargetProperties)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, in D2D1_RENDER_TARGET_PROPERTIES, BOOL>)_vTable[56])(thisPtr, renderTargetProperties);
            }
        }
    }
}
