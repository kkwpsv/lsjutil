using Lsj.Util.Win32.Attributes;
using Lsj.Util.Win32.ComInterfaces;
using System;

namespace Lsj.Util.Win32.DirectX.ComInterfaces
{
    /// <summary>
    /// <para>
    /// Represents a set of vertices that form a list of triangles.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d2d1/nn-d2d1-id2d1mesh"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <para>
    /// Creating <see cref="ID2D1Mesh"/> Objects
    /// </para>
    /// <para>
    /// To create a mesh, call the <see cref="ID2D1RenderTarget.CreateMesh"/> method on the render target with which the mesh will be used.
    /// A mesh can only be used with the render target that created it and the render target's compatible targets.
    /// </para>
    /// <para>
    /// A mesh is a device-dependent resource:
    /// your application should create meshes after it initializes the render target with which the meshes will be used,
    /// and recreate the meshes whenever the render target needs recreated.
    /// (For more information about resources, see Resources Overview.)
    /// </para>
    /// </remarks>
    [WindowsVersionRequirement(WindowsVersion.Windows7)]
    [ComInterface(IID = "2cd906c2-12e2-11dc-9fed-001143a055f9", BeginVTableSlotIndex = 4, EndVTableSlotIndex = 4,
        InheritedFromTypes = [typeof(IUnknown), typeof(ID2D1Resource)])]
    public unsafe struct ID2D1Mesh
    {
        nint* _vTable;
    }
}
