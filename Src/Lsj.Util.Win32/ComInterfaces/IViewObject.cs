using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Enums;
using Lsj.Util.Win32.Structs;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.BOOL;
using static Lsj.Util.Win32.BaseTypes.HRESULT;
using static Lsj.Util.Win32.ComInterfaces.IIDs;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.Enums.ADVF;
using static Lsj.Util.Win32.Enums.CLIPFORMAT;
using static Lsj.Util.Win32.Enums.DVASPECT;
using static Lsj.Util.Win32.Enums.DVASPECT2;
using static Lsj.Util.Win32.Enums.MappingModes;
using static Lsj.Util.Win32.Enums.WindowsMessages;
using static Lsj.Util.Win32.Gdi32;
using static Lsj.Util.Win32.UnsafePInvokeExtensions;

namespace Lsj.Util.Win32.ComInterfaces
{
    /// <summary>
    /// <para>
    /// Enables an object to display itself directly without passing a data object to the caller.
    /// In addition, this interface can create and manage a connection with an advise sink so the caller can be notified of changes in the view object.
    /// The caller can request specific representations and specific target devices.
    /// For example, a caller can ask for either an object's content or an iconic representation.
    /// Also, the caller can ask the object to compose a picture for a target device that is independent of the drawing device context.
    /// As a result, the picture can be composed for one target device and drawn on another device context.
    /// For example, to provide a print preview operation, you can compose the drawing for a printer target device
    /// but actually draw the representation on the display.
    /// The <see cref="IViewObject"/> interface is similar to <see cref="IDataObject"/>;
    /// except that <see cref="IViewObject"/> places a representation of the data onto a device context
    /// while <see cref="IDataObject"/> places the representation onto a transfer medium.
    /// Unlike most other interfaces, <see cref="IViewObject"/> cannot be marshaled to another process.
    /// This is because device contexts are only effective in the context of one process.
    /// </para>
    /// <para>
    /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/oleidl/nn-oleidl-iviewobject
    /// </para>
    /// </summary>
    [ComImport]
    [Guid(IID_IViewObject)]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IViewObject
    {
        /// <summary>
        /// Draws a representation of an object onto the specified device context.
        /// </summary>
        /// <param name="dwDrawAspect">
        /// Specifies the aspect to be drawn, that is, how the object is to be represented.
        /// Representations include content, an icon, a thumbnail, or a printed document.
        /// Valid values are taken from the enumerations <see cref="DVASPECT"/> and <see cref="DVASPECT2"/>.
        /// Note that newer objects and containers that support optimized drawing interfaces support the <see cref="DVASPECT2"/> enumeration values.
        /// Older objects and containers that do not support optimized drawing interfaces may not support <see cref="DVASPECT2"/>.
        /// Windowless objects allow only <see cref="DVASPECT_CONTENT"/>, <see cref="DVASPECT_OPAQUE"/>, and <see cref="DVASPECT_TRANSPARENT"/>.
        /// </param>
        /// <param name="lindex">
        /// Portion of the object that is of interest for the draw operation.
        /// Its interpretation varies depending on the value in the <paramref name="dwDrawAspect"/> parameter.
        /// See the <see cref="DVASPECT"/> enumeration for more information.
        /// </param>
        /// <param name="pvAspect">
        /// Pointer to additional information in a <see cref="DVASPECTINFO"/> structure
        /// that enables drawing optimizations depending on the aspect specified.
        /// Note that newer objects and containers that support optimized drawing interfaces support this parameter as well.
        /// Older objects and containers that do not support optimized drawing interfaces always specify <see cref="NULL"/> for this parameter.
        /// </param>
        /// <param name="ptd">
        /// Pointer to the <see cref="DVTARGETDEVICE"/> structure that describes the device for which the object is to be rendered.
        /// If <see cref="NULL"/>, the view should be rendered for the default target device (typically the display).
        /// A value other than <see cref="NULL"/> is interpreted in conjunction with <paramref name="hdcTargetDev"/> and <paramref name="hdcDraw"/>.
        /// For example, if <paramref name="hdcDraw"/> specifies a printer as the device context,
        /// the <paramref name="ptd"/> parameter points to a structure describing that printer device.
        /// The data may actually be printed if <paramref name="hdcTargetDev"/> is a valid value
        /// or it may be displayed in print preview mode if <paramref name="hdcTargetDev"/> is <see cref="NULL"/>.
        /// </param>
        /// <param name="hdcTargetDev">
        /// Information context for the target device indicated by the <paramref name="ptd"/> parameter
        /// from which the object can extract device metrics and test the device's capabilities.
        /// If <paramref name="ptd"/> is <see cref="NULL"/>; the object should ignore the value in the <paramref name="hdcTargetDev"/> parameter.
        /// </param>
        /// <param name="hdcDraw">
        /// Device context on which to draw.
        /// For a windowless object, the <paramref name="hdcDraw"/> parameter should be in <see cref="MM_TEXT"/> mapping mode
        /// with its logical coordinates matching the client coordinates of the containing window.
        /// For a windowless object, the device context should be in the same state as the one normally passed by a <see cref="WM_PAINT"/> message.
        /// </param>
        /// <param name="lprcBounds">
        /// Pointer to a <see cref="RECTL"/> structure specifying the rectangle on <paramref name="hdcDraw"/> and in which the object should be drawn.
        /// This parameter controls the positioning and stretching of the object.
        /// This parameter should be <see cref="NULL"/> to draw a windowless in-place active object.
        /// In every other situation, <see cref="NULL"/> is not a legal value and should result in an <see cref="E_INVALIDARG"/> error code.
        /// If the container passes a non-NULL value to a windowless object,
        /// the object should render the requested aspect into the specified device context and rectangle.
        /// A container can request this from a windowless object to render a second, non-active view of the object or to print the object.
        /// </param>
        /// <param name="lprcWBounds">
        /// If <paramref name="hdcDraw"/> is a metafile device context,
        /// pointer to a <see cref="RECTL"/> structure specifying the bounding rectangle in the underlying metafile.
        /// The rectangle structure contains the window extent and window origin.
        /// These values are useful for drawing metafiles.
        /// The rectangle indicated by <paramref name="lprcBounds"/> is nested inside this <paramref name="lprcWBounds"/> rectangle;
        /// they are in the same coordinate space.
        /// If <paramref name="hdcDraw"/> is not a metafile device context; <paramref name="lprcWBounds"/> will be <see cref="NULL"/>.
        /// </param>
        /// <param name="pfnContinue">
        /// Pointer to a callback function that the view object should call periodically during a lengthy drawing operation
        /// to determine whether the operation should continue or be canceled.
        /// This function returns <see cref="TRUE"/> to continue drawing.
        /// It returns <see cref="FALSE"/> to stop the drawing in which case <see cref="Draw"/> returns <see cref="DRAW_E_ABORT"/>.
        /// </param>
        /// <param name="dwContinue">
        /// Value to pass as a parameter to the function pointed to by the <paramref name="pfnContinue"/> parameter.
        /// Typically, <paramref name="dwContinue"/> is a pointer to an application-defined structure needed inside the callback function.
        /// </param>
        /// <returns>
        /// This method returns <see cref="S_OK"/> on success. Other possible return values include the following.
        /// <see cref="OLE_E_BLANK"/>: No data to draw from.
        /// <see cref="DRAW_E_ABORT"/>: Draw operation aborted.
        /// <see cref="VIEW_E_DRAW"/>: Error in drawing.
        /// <see cref="DV_E_LINDEX"/>: Invalid value for <paramref name="lindex"/>; currently only -1 is supported.
        /// <see cref="DV_E_DVASPECT"/>: Invalid value for <paramref name="dwDrawAspect"/>.
        /// <see cref="OLE_E_INVALIDRECT"/>: Invalid rectangle. 
        /// </returns>
        /// <remarks>
        /// A container application issues a call to <see cref="Draw"/> to create a representation of a contained object.
        /// This method draws the specified piece (<paramref name="lindex"/>) of the specified view
        /// (<paramref name="dwDrawAspect"/> and <paramref name="pvAspect"/>) on the specified device context (<paramref name="hdcDraw"/>).
        /// Formatting, fonts, and other rendering decisions are made on the basis of the target device
        /// specified by the <paramref name="ptd"/> parameter.
        /// There is a relationship between the <paramref name="dwDrawAspect"/> value and the <paramref name="lprcBounds"/> value.
        /// The <paramref name="lprcBounds"/> value specifies the rectangle on <paramref name="hdcDraw"/> into which the drawing is to be mapped.
        /// For <see cref="DVASPECT_THUMBNAIL"/>, <see cref="DVASPECT_ICON"/>, and <see cref="DVASPECT_SMALLICON"/>,
        /// the object draws whatever it wants to draw, and it maps it into the space given in the best way.
        /// Some objects might scale to fit while some might scale to fit but preserve the aspect ratio.
        /// In addition, some might scale so the drawing appears at full width, but the bottom is cropped.
        /// The container can suggest a size via <see cref="IOleObject.SetExtent"/>, but it has no control over the rendering size.
        /// In the case of <see cref="DVASPECT_CONTENT"/>, the <see cref="Draw"/> implementation should either use the extents
        /// given by <see cref="IOleObject.SetExtent"/> or use the bounding rectangle given in the <paramref name="lprcBounds"/> parameter.
        /// For newer objects that support optimized drawing techniques and for windowless objects, this method should be used as follows:
        /// New drawing aspects are supported in <paramref name="dwDrawAspect"/> as defined in <see cref="DVASPECT2"/>.
        /// The <paramref name="pvAspect"/> parameter can be used to pass additional information
        /// allowing drawing optimizations through the <see cref="DVASPECTINFO"/> structure.
        /// The <see cref="Draw"/> method can be called to redraw a windowless in-place active object
        /// by setting the <paramref name="lprcBounds"/> parameter to <see cref="NULL"/>.
        /// In every other situation, <see cref="NULL"/> is an illegal value and should result in an <see cref="E_INVALIDARG"/> error code.
        /// A windowless object uses the rectangle passed by the activation verb
        /// or calls <see cref="IOleInPlaceObject.SetObjectRects"/> instead of using this parameter.
        /// If the container passes a non-NULL value to a windowless object,
        /// the object should render the requested aspect into the specified device context and rectangle.
        /// A container can request this from a windowless object to render a second, non-active view of the object or to print the object.
        /// See the <see cref="IOleInPlaceSiteWindowless"/> interface for more information on drawing windowless objects.
        /// For windowless objects, the <paramref name="dwDrawAspect"/> parameter only allows the <see cref="DVASPECT_CONTENT"/>,
        /// <see cref="DVASPECT_OPAQUE"/>, and <see cref="DVASPECT_TRANSPARENT"/> aspects.
        /// For a windowless object, the <paramref name="hdcDraw"/> parameter should be in <see cref="MM_TEXT"/> mapping mode
        /// with its logical coordinates matching the client coordinates of the containing window.
        /// For a windowless object, the device context should be in the same state as the one normally passed by a <see cref="WM_PAINT"/> message.
        /// To maintain compatibility with older objects and containers that do not support drawing optimizations, 
        /// all objects, rectangular or not, are required to maintain an origin and a rectangular extent.
        /// This allows the container to still consider all its embedded objects as rectangles
        /// and to pass them appropriate rendering rectangles in <see cref="Draw"/>.
        /// An object's extent depends on the drawing aspect.
        /// For non-rectangular objects, the extent should be the size of a rectangle covering the entire aspect.
        /// By convention, the origin of an object is the top-left corner of the rectangle of the <see cref="DVASPECT_CONTENT"/> aspect.
        /// In other words, the origin always coincides with the top-left corner of the rectangle maintained by the object's site,
        /// even for a non-rectangular object.
        /// </remarks>
        [PreserveSig]
        HRESULT Draw([In] DVASPECT dwDrawAspect, [In] LONG lindex, [In] IntPtr pvAspect, [In] in DVTARGETDEVICE ptd, [In] HDC hdcTargetDev,
            [In] HDC hdcDraw, [In] in RECTL lprcBounds, [In] in RECTL lprcWBounds, [In] IntPtr pfnContinue, [In] ULONG_PTR dwContinue);

        /// <summary>
        /// Returns the logical palette that the object will use for drawing in its <see cref="Draw"/> method with the corresponding parameters.
        /// </summary>
        /// <param name="dwDrawAspect">
        /// Specifies how the object is to be represented.
        /// Representations include content, an icon, a thumbnail, or a printed document.
        /// Valid values are taken from the enumeration <see cref="DVASPECT"/>.
        /// See the <see cref="DVASPECT"/> enumeration for more information.
        /// </param>
        /// <param name="lindex">
        /// Portion of the object that is of interest for the draw operation.
        /// Its interpretation varies with <paramref name="dwDrawAspect"/>.
        /// See the <see cref="DVASPECT"/> enumeration for more information.
        /// </param>
        /// <param name="pvAspect">
        /// Pointer to additional information about the view of the object specified in <paramref name="dwDrawAspect"/>.
        /// Since none of the current aspects support additional information, <paramref name="pvAspect"/> must always be <see cref="NULL"/>.
        /// </param>
        /// <param name="ptd">
        /// Pointer to the <see cref="DVTARGETDEVICE"/> structure that describes the device for which the object is to be rendered.
        /// If <see cref="NULL"/>, the view should be rendered for the default target device (typically the display).
        /// A value other than <see cref="NULL"/> is interpreted in conjunction with <paramref name="hicTargetDev"/> and hdcDraw.
        /// For example, if hdcDraw specifies a printer as the device context,
        /// <paramref name="ptd"/> points to a structure describing that printer device.
        /// The data may actually be printed if <paramref name="hicTargetDev"/> is a valid value
        /// or it may be displayed in print preview mode if <paramref name="hicTargetDev"/> is <see cref="NULL"/>.
        /// </param>
        /// <param name="hicTargetDev">
        /// Information context for the target device indicated by the <paramref name="ptd"/> parameter
        /// from which the object can extract device metrics and test the device's capabilities.
        /// If <paramref name="ptd"/> is <see cref="NULL"/>, the object should ignore the <paramref name="hicTargetDev"/> parameter.
        /// </param>
        /// <param name="ppColorSet">
        /// Address of <see cref="LOGPALETTE"/> pointer variable that receives a pointer to the <see cref="LOGPALETTE"/> structure.
        /// The <see cref="LOGPALETTE"/> structure contains the set of colors that would be used if <see cref="Draw"/> were called
        /// with the same parameters for <paramref name="dwDrawAspect"/>, <paramref name="lindex"/>, <paramref name="pvAspect"/>,
        /// <paramref name="ptd"/>, and <paramref name="hicTargetDev"/>.
        /// If <paramref name="ppColorSet"/> is <see cref="NullRef{IntPtr}"/>, the object does not use a palette.
        /// </param>
        /// <returns>
        /// This method returns <see cref="S_OK"/> on success. Other possible return values include the following.
        /// <see cref="S_FALSE"/>: Set of colors is empty or the object will not give out the information.
        /// <see cref="OLE_E_BLANK"/>: No presentation data for object.
        /// <see cref="DV_E_LINDEX"/>: Invalid value for <paramref name="lindex"/>; currently only -1 is supported.
        /// <see cref="DV_E_DVASPECT"/>: Invalid value for <paramref name="dwDrawAspect"/>.
        /// <see cref="E_INVALIDARG"/>: One or more of the supplied parameter values is invalid.
        /// <see cref="E_OUTOFMEMORY"/>: Insufficient memory available for this operation.
        /// </returns>
        /// <remarks>
        /// The <see cref="GetColorSet"/> method recursively queries any nested objects and returns a color set
        /// that represents the union of all colors requested.
        /// The color set eventually percolates to the top-level container that owns the window frame.
        /// This container can call <see cref="GetColorSet"/> on each of its embedded objects
        /// to obtain all the colors needed to draw the embedded objects.
        /// The container can use the color sets obtained in conjunction with other colors it needs for itself to set the overall color palette.
        /// The OLE-provided implementation of <see cref="GetColorSet"/> looks at the data it has on hand to draw the picture.
        /// If <see cref="CF_DIB"/> is the drawing format, the palette found in the bitmap is used.
        /// For a regular bitmap, no color information is returned.
        /// If the drawing format is a metafile, the object handler enumerates the metafile looking for a <see cref="CreatePalette"/> metafile record.
        /// If one is found, the handler uses it as the color set.
        /// </remarks>
        [PreserveSig]
        HRESULT GetColorSet([In] DVASPECT dwDrawAspect, [In] LONG lindex, [In] IntPtr pvAspect, [In] in DVTARGETDEVICE ptd,
            [In] HDC hicTargetDev, [Out] out IntPtr ppColorSet);

        /// <summary>
        /// Freezes the drawn representation of an object so that it will not change until the <see cref="Unfreeze"/> method is called.
        /// The most common use of this method is for banded printing.
        /// </summary>
        /// <param name="dwDrawAspect">
        /// Specifies how the object is to be represented.
        /// Representations include content, an icon, a thumbnail, or a printed document.
        /// Valid values are taken from the enumeration <see cref="DVASPECT"/>.
        /// See the <see cref="DVASPECT"/> enumeration for more information.
        /// </param>
        /// <param name="lindex">
        /// Portion of the object that is of interest for the draw operation.
        /// Its interpretation varies with <paramref name="dwDrawAspect"/>.
        /// See the <see cref="DVASPECT"/> enumeration for more information.
        /// </param>
        /// <param name="pvAspect">
        /// Pointer to additional information about the view of the object specified in <paramref name="dwDrawAspect"/>.
        /// Since none of the current aspects support additional information, <paramref name="pvAspect"/> must always be <see cref="NULL"/>.
        /// </param>
        /// <param name="pdwFreeze">
        /// Pointer to where an identifying <see cref="DWORD"/> key is returned.
        /// This unique key is later used to cancel the freeze by calling <see cref="Unfreeze"/>.
        /// This key is an index that the default cache uses to keep track of which object is frozen.
        /// </param>
        /// <returns>
        /// This method returns <see cref="S_OK"/> on success. Other possible return values include the following.
        /// <see cref="VIEW_S_ALREADY_FROZEN"/>:
        /// Presentation has already been frozen. The value of <paramref name="pdwFreeze"/> is the identifying key of the already frozen object.
        /// <see cref="OLE_E_BLANK"/>: Presentation not in cache.
        /// <see cref="DV_E_LINDEX"/>: Invalid value for lindex; currently; only -1 is supported.
        /// <see cref="DV_E_DVASPECT"/>: Invalid value for <paramref name="dwDrawAspect"/>. 
        /// </returns>
        /// <remarks>
        /// The <see cref="Freeze"/> method causes the view object to freeze its drawn representation
        /// until a subsequent call to <see cref="Unfreeze"/> releases it.
        /// After calling <see cref="Freeze"/>, successive calls to :<see cref="Draw"/> with the same parameters
        /// produce the same picture until <see cref="Unfreeze"/> is called.
        /// <see cref="Freeze"/> is not part of the persistent state of the object and does not continue across unloads and reloads of the object.
        /// The most common use of this method is for banded printing.
        /// While in a frozen state, view notifications are not sent.
        /// Pending view notifications are deferred to the subsequent call to <see cref="Unfreeze"/>.
        /// </remarks>
        [PreserveSig]
        HRESULT Freeze([In] DVASPECT dwDrawAspect, [In] LONG lindex, [In] IntPtr pvAspect, [Out] out DWORD pdwFreeze);

        /// <summary>
        /// Releases a drawing that was previously frozen using <see cref="Freeze"/>. 
        /// The most common use of this method is for banded printing.
        /// </summary>
        /// <param name="dwFreeze">
        /// Contains a key previously returned from <see cref="Freeze"/> that determines which view object to unfreeze.
        /// </param>
        /// <returns>
        /// This method returns <see cref="S_OK"/> on success. Other possible return values include the following.
        /// <see cref="OLE_E_NOCONNECTION"/>: Error in the unfreezing process or the object is currently not frozen. 
        /// </returns>
        [PreserveSig]
        HRESULT Unfreeze([In] DWORD dwFreeze);

        /// <summary>
        /// Establishes a connection between the view object and an advise sink
        /// so that the advise sink can be notified about changes in the object's view.
        /// </summary>
        /// <param name="aspects">
        /// View for which the advisory connection is being set up.
        /// Valid values are taken from the enumeration <see cref="DVASPECT"/>.
        /// See the <see cref="DVASPECT"/> enumeration for more information.
        /// </param>
        /// <param name="advf">
        /// Contains a group of flags for controlling the advisory connection.
        /// Valid values are from the enumeration <see cref="ADVF"/>.
        /// However, only some of the possible <see cref="ADVF"/> values are relevant for this method.
        /// The following table briefly describes the relevant values.
        /// See the <see cref="ADVF"/> enumeration for a more detailed description.
        /// <see cref="ADVF_ONLYONCE"/>: Causes the advisory connection to be destroyed after the first notification is sent.
        /// <see cref="ADVF_PRIMEFIRST"/>: Causes an initial notification to be sent regardless of whether data has changed from its current state. 
        /// Note  The <see cref="ADVF_ONLYONCE"/> and <see cref="ADVF_PRIMEFIRST"/> can be combined
        /// to provide an asynchronous call to <see cref="IDataObject.GetData"/>. 
        /// </param>
        /// <param name="pAdvSink">
        /// Pointer to the <see cref="IAdviseSink"/> interface on the advisory sink that is to be informed of changes.
        /// A <see langword="null"/> value deletes any existing advisory connection.
        /// </param>
        /// <returns>
        /// This method returns <see cref="S_OK"/> on success. Other possible return values include the following.
        /// <see cref="OLE_E_ADVISENOTSUPPORTED"/>: Advisory notifications are not supported. 
        /// <see cref="DV_E_DVASPECT"/>: Invalid value for <paramref name="aspects"/>.
        /// <see cref="E_INVALIDARG"/>: One or more of the supplied values is invalid.
        /// <see cref="E_OUTOFMEMORY"/>: Insufficient memory available for this operation.
        /// </returns>
        /// <remarks>
        /// A container application that is requesting a draw operation on a view object can also register
        /// with the <see cref="IViewObject.SetAdvise"/> method to be notified when the presentation of the view object changes.
        /// To find out about when an object's underlying data changes, you must call <see cref="IDataObject.DAdvise"/> separately.
        /// To remove an existing advisory connection, call the <see cref="SetAdvise"/> method
        /// with <paramref name="pAdvSink"/> set to <see langword="null"/>.
        /// If the view object changes, a call is made to the appropriate advise sink through its <see cref="IAdviseSink.OnViewChange"/> method.
        /// At any time, a given view object can support only one advisory connection.
        /// Therefore, when <see cref="IViewObject.SetAdvise"/> is called and the view object is already holding on to an advise sink pointer,
        /// OLE releases the existing pointer before the new one is registered.
        /// </remarks>
        [PreserveSig]
        HRESULT SetAdvise([In] DVASPECT aspects, [In] ADVF advf, [In] IAdviseSink pAdvSink);

        /// <summary>
        /// etrieves the advisory connection on the object that was used in the most recent call to <see cref="SetAdvise"/>.
        /// </summary>
        /// <param name="pAspects">
        /// Pointer to where the dwAspect parameter from the previous <see cref="SetAdvise"/> call is returned.
        /// If this pointer is <see cref="NullRef{DVASPECT}"/>, the caller does not permit this value to be returned.
        /// </param>
        /// <param name="pAdvf">
        /// Pointer to where the advf parameter from the previous <see cref="SetAdvise"/> call is returned.
        /// If this pointer is <see cref="NullRef{ADVF}"/>, the caller does not permit this value to be returned.
        /// </param>
        /// <param name="ppAdvSink">
        /// Address of <see cref="IAdviseSink"/> pointer variable that receives the interface pointer to the advise sink.
        /// The connection to this advise sink must have been established with a previous <see cref="SetAdvise"/> call,
        /// which provides the pAdvSink parameter.
        /// If <paramref name="ppAdvSink"/> is <see cref="NullRef{IAdviseSink}"/>, there is no established advisory connection.
        /// </param>
        /// <returns>
        /// This method returns <see cref="S_OK"/> on success.
        /// </returns>
        [PreserveSig]
        HRESULT GetAdvise([Out] out DVASPECT pAspects, [Out] out ADVF pAdvf, [Out] out IAdviseSink ppAdvSink);
    }
}
