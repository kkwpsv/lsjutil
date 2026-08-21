using Lsj.Util.Win32.Attributes;
using Lsj.Util.Win32.ComInterfaces;
using System;

namespace Lsj.Util.Win32.DirectX.ComInterfaces
{
    /// <summary>
    /// <para>
    /// Represents the backing store required to render a layer.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d2d1/nn-d2d1-id2d1layer"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <para>
    /// To create a layer, call the <see cref="ID2D1RenderTarget.CreateLayer"/> method of the render target where the layer will be used.
    /// To draw to a layer, push the layer to the render target stack by calling the <see cref="ID2D1RenderTarget.PushLayer"/> method.
    /// After you have finished drawing to the layer, call the <see cref="ID2D1RenderTarget.PopLayer"/> method.
    /// </para>
    /// <para>
    /// Between <see cref="ID2D1RenderTarget.PushLayer"/> and <see cref="ID2D1RenderTarget.PopLayer"/> calls,
    /// the layer is in use and cannot be used by another render target.
    /// </para>
    /// <para>
    /// If the size of the layer is not specified,
    /// the corresponding <see cref="ID2D1RenderTarget.PushLayer"/> call determines the minimum layer size,
    /// based on the layer content bounds and the geometric mask.
    /// The layer resource can be larger than the size required by <see cref="ID2D1RenderTarget.PushLayer"/> without any rendering artifacts.
    /// </para>
    /// <para>
    /// If the size of a layer is specified, or if the layer has been used and the required backing store size as calculated
    /// during <see cref="ID2D1RenderTarget.PushLayer"/> is larger than the layer,
    /// then the layer resource is expanded on each axis monotonically to ensure that it is large enough.
    /// The layer resource never shrinks in size.
    /// </para>
    /// <para>
    /// Creating ID2D1Layer Objects
    /// </para>
    /// <para>
    /// To create a layer, call the <see cref="ID2D1RenderTarget.CreateLayer"/> method of the render target where the layer will be used.
    /// </para>
    /// <para>
    /// A layer is a device-dependent resource: your application should create layers
    /// after it initializes the render target with which the layers will be used,
    /// and recreate the layers whenever the render target needs recreated.
    /// (For more information about resources, see Resources Overview.)
    /// </para>
    /// </remarks>
    [WindowsVersionRequirement(WindowsVersion.Windows7)]
    [ComInterface(IID = "2cd9069b-12e2-11dc-9fed-001143a055f9", BeginVTableSlotIndex = 4, EndVTableSlotIndex = 4,
        InheritedFromTypes = [typeof(IUnknown), typeof(ID2D1Resource)])]
    public unsafe struct ID2D1Layer
    {
        nint* _vTable;
    }
}
