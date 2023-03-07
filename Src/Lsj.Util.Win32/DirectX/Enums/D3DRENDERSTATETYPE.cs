using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.DirectX.BaseTypes;
using Lsj.Util.Win32.DirectX.ComInterfaces;
using Lsj.Util.Win32.DirectX.Structs;
using static Lsj.Util.Win32.BaseTypes.BOOL;

namespace Lsj.Util.Win32.DirectX.Enums
{
    /// <summary>
    /// <para>
    /// Render states define set-up states for all kinds of vertex and pixel processing.
    /// Some render states set up vertex processing, and some set up pixel processing (see Render States (Direct3D 9)).
    /// Render states can be saved and restored using stateblocks (see State Blocks Save and Restore State (Direct3D 9)).
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/direct3d9/d3drenderstatetype"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// Render states       Texture sampler
    /// ps_1_1 to ps_1_3    4 texture samplers
    /// Direct3D defines the <see cref="D3DRENDERSTATE_WRAPBIAS"/> constant as a convenience for applications to enable or disable texture wrapping,
    /// based on the zero-based integer of a texture coordinate set (rather than explicitly using one of the D3DRS_WRAP n state values).
    /// Add the <see cref="D3DRENDERSTATE_WRAPBIAS"/> value to the zero-based index of a texture coordinate
    /// set to calculate the <see cref="D3DRS_WRAP"/> n value that corresponds to that index, as shown in the following example.
    /// <code>
    /// // Enable U/V wrapping for textures that use the texture 
    /// // coordinate set at the index within the dwIndex variable
    /// 
    /// HRESULT hr = pd3dDevice->SetRenderState(
    /// dwIndex + D3DRENDERSTATE_WRAPBIAS,
    /// D3DWRAPCOORD_0 | D3DWRAPCOORD_1);
    /// 
    /// // If dwIndex is 3, the value that results from 
    /// // the addition equals D3DRS_WRAP3 (131)
    /// </code>
    /// </remarks>
    public enum D3DRENDERSTATETYPE
    {
        /// <summary>
        /// Depth-buffering state as one member of the <see cref="D3DZBUFFERTYPE"/> enumerated type.
        /// Set this state to <see cref="D3DZB_TRUE"/> to enable z-buffering,
        /// <see cref="D3DZB_USEW"/> to enable w-buffering, or <see cref="D3DZB_FALSE"/> to disable depth buffering.
        /// The default value for this render state is <see cref="D3DZB_TRUE"/> if a depth stencil was created
        /// along with the swap chain by setting the <see cref="D3DPRESENT_PARAMETERS.EnableAutoDepthStencil"/> member
        /// of the <see cref="D3DPRESENT_PARAMETERS"/> structure to <see cref="TRUE"/>, and <see cref="D3DZB_FALSE"/> otherwise.
        /// </summary>
        D3DRS_ZENABLE = 7,

        /// <summary>
        /// One or more members of the <see cref="D3DFILLMODE"/> enumerated type.
        /// The default value is <see cref="D3DFILL_SOLID"/>.
        /// </summary>
        D3DRS_FILLMODE = 8,

        /// <summary>
        /// One or more members of the <see cref="D3DSHADEMODE"/> enumerated type.
        /// The default value is <see cref="D3DSHADE_GOURAUD"/>.
        /// </summary>
        D3DRS_SHADEMODE = 9,

        /// <summary>
        /// <see cref="TRUE"/> to enable the application to write to the depth buffer.
        /// The default value is <see cref="TRUE"/>.
        /// This member enables an application to prevent the system from updating the depth buffer with new depth values.
        /// If <see cref="FALSE"/>, depth comparisons are still made according to the render state <see cref="D3DRS_ZFUNC"/>,
        /// assuming that depth buffering is taking place, but depth values are not written to the buffer.
        /// </summary>
        D3DRS_ZWRITEENABLE = 14,

        /// <summary>
        /// <see cref="TRUE"/> to enable per pixel alpha testing.
        /// If the test passes, the pixel is processed by the frame buffer.
        /// Otherwise, all frame-buffer processing is skipped for the pixel.
        /// The test is done by comparing the incoming alpha value with the reference alpha value,
        /// using the comparison function provided by the <see cref="D3DRS_ALPHAFUNC"/> render state.
        /// The reference alpha value is determined by the value set for <see cref="D3DRS_ALPHAREF"/>.
        /// For more information, see Alpha Testing State (Direct3D 9).
        /// The default value of this parameter is <see cref="FALSE"/>.
        /// </summary>
        D3DRS_ALPHATESTENABLE = 15,

        /// <summary>
        /// The default value is <see cref="TRUE"/>, which enables drawing of the last pixel in a line.
        /// To prevent drawing of the last pixel, set this value to <see cref="FALSE"/>.
        /// For more information, see Outline and Fill State (Direct3D 9).
        /// </summary>
        D3DRS_LASTPIXEL = 16,

        /// <summary>
        /// One member of the <see cref="D3DBLEND"/> enumerated type.
        /// The default value is <see cref="D3DBLEND_ONE"/>.
        /// </summary>
        D3DRS_SRCBLEND = 19,

        /// <summary>
        /// One member of the <see cref="D3DBLEND"/> enumerated type.
        /// The default value is <see cref="D3DBLEND_ZERO"/>.
        /// </summary>
        D3DRS_DESTBLEND = 20,

        /// <summary>
        /// Specifies how back-facing triangles are culled, if at all.
        /// This can be set to one member of the <see cref="D3DCULL"/> enumerated type.
        /// The default value is <see cref="D3DCULL_CCW"/>.
        /// </summary>
        D3DRS_CULLMODE = 22,

        /// <summary>
        /// One member of the <see cref="D3DCMPFUNC"/> enumerated type.
        /// The default value is <see cref="D3DCMP_LESSEQUAL"/>.
        /// This member enables an application to accept or reject a pixel, based on its distance from the camera.
        /// The depth value of the pixel is compared with the depth-buffer value.
        /// If the depth value of the pixel passes the comparison function, the pixel is written.
        /// The depth value is written to the depth buffer only if the render state is <see cref="TRUE"/>.
        /// Software rasterizers and many hardware accelerators work faster if the depth test fails,
        /// because there is no need to filter and modulate the texture if the pixel is not going to be rendered.
        /// </summary>
        D3DRS_ZFUNC = 23,

        /// <summary>
        /// Value that specifies a reference alpha value against which pixels are tested when alpha testing is enabled.
        /// This is an 8-bit value placed in the low 8 bits of the DWORD render-state value.
        /// Values can range from 0x00000000 through 0x000000FF.
        /// The default value is 0.
        /// </summary>
        D3DRS_ALPHAREF = 24,

        /// <summary>
        /// One member of the <see cref="D3DCMPFUNC"/> enumerated type.
        /// The default value is <see cref="D3DCMP_ALWAYS"/>.
        /// This member enables an application to accept or reject a pixel, based on its alpha value.
        /// </summary>
        D3DRS_ALPHAFUNC = 25,

        /// <summary>
        /// <see cref="TRUE"/> to enable dithering.
        /// The default value is <see cref="FALSE"/>.
        /// </summary>
        D3DRS_DITHERENABLE = 26,

        /// <summary>
        /// <see cref="TRUE"/> to enable alpha-blended transparency.
        /// The default value is <see cref="FALSE"/>.
        /// The type of alpha blending is determined by the <see cref="D3DRS_SRCBLEND"/> and <see cref="D3DRS_DESTBLEND"/> render states.
        /// </summary>
        D3DRS_ALPHABLENDENABLE = 27,

        /// <summary>
        /// <see cref="TRUE"/> to enable fog blending.
        /// The default value is <see cref="FALSE"/>.
        /// For more information about using fog blending, see Fog.
        /// </summary>
        D3DRS_FOGENABLE = 28,

        /// <summary>
        /// <see cref="TRUE"/> to enable specular highlights.
        /// The default value is <see cref="FALSE"/>.
        /// Specular highlights are calculated as though every vertex in the object being lit is at the object's origin.
        /// This gives the expected results as long as the object is modeled
        /// around the origin and the distance from the light to the object is relatively large.
        /// In other cases, the results as undefined.
        /// When this member is set to <see cref="TRUE"/>, the specular color is added to the base color after the texture cascade but before alpha blending.
        /// </summary>
        D3DRS_SPECULARENABLE = 29,

        /// <summary>
        /// Value whose type is <see cref="D3DCOLOR"/>.
        /// The default value is 0.
        /// For more information about fog color, see Fog Color (Direct3D 9).
        /// </summary>
        D3DRS_FOGCOLOR = 34,

        /// <summary>
        /// The fog formula to be used for pixel fog.
        /// Set to one of the members of the <see cref="D3DFOGMODE"/> enumerated type.
        /// The default value is <see cref="D3DFOG_NONE"/>.
        /// For more information about pixel fog, see Pixel Fog (Direct3D 9).
        /// </summary>
        D3DRS_FOGTABLEMODE = 35,

        /// <summary>
        /// Depth at which pixel or vertex fog effects begin for linear fog mode.
        /// The default value is 0.0f.
        /// Depth is specified in world space for vertex fog and either device space [0.0, 1.0] or world space for pixel fog.
        /// For pixel fog, these values are in device space when the system uses z for fog calculations
        /// and world-world space when the system is using eye-relative fog (w-fog).
        /// For more information, see Fog Parameters (Direct3D 9) and Eye-Relative vs. Z-based Depth.
        /// Values for this render state are floating-point values.
        /// Because the <see cref="IDirect3DDevice9.SetRenderState"/> method accepts DWORD values,
        /// your application must cast a variable that contains the value, as shown in the following code example.
        /// <code>
        /// pDevice9->SetRenderState(D3DRS_FOGSTART, 
        ///                          *((DWORD*) (&amp;fFogStart)));
        /// </code>
        /// </summary>
        D3DRS_FOGSTART = 36,

        /// <summary>
        /// Depth at which pixel or vertex fog effects end for linear fog mode.
        /// The default value is 1.0f.
        /// Depth is specified in world space for vertex fog and either device space [0.0, 1.0] or world space for pixel fog.
        /// For pixel fog, these values are in device space when the system uses z for fog calculations
        /// and in world space when the system is using eye-relative fog (w-fog).
        /// For more information, see Fog Parameters (Direct3D 9) and Eye-Relative vs. Z-based Depth.
        /// Values for this render state are floating-point values.
        /// Because the <see cref="IDirect3DDevice9.SetRenderState"/> method accepts DWORD values,
        /// your application must cast a variable that contains the value, as shown in the following code example.
        /// <code>
        /// m_pDevice9->SetRenderState(D3DRS_FOGEND, *((DWORD*) (&amp;fFogEnd)));
        /// </code>
        /// </summary>
        D3DRS_FOGEND = 37,

        /// <summary>
        /// Fog density for pixel or vertex fog used in the exponential fog modes (<see cref="D3DFOG_EXP"/> and <see cref="D3DFOG_EXP2"/>).
        /// Valid density values range from 0.0 through 1.0.
        /// The default value is 1.0. For more information, see Fog Parameters (Direct3D 9).
        /// Values for this render state are floating-point values.
        /// Because the <see cref="IDirect3DDevice9.SetRenderState"/> method accepts DWORD values,
        /// your application must cast a variable that contains the value, as shown in the following code example.
        /// <code>
        /// m_pDevice9->SetRenderState(D3DRS_FOGDENSITY, *((DWORD*) (&amp;fFogDensity)));
        /// </code>
        /// </summary>
        D3DRS_FOGDENSITY = 38,

        /// <summary>
        /// TRUE to enable range-based vertex fog.
        /// The default value is <see cref="FALSE"/>, in which case the system uses depth-based fog.
        /// In range-based fog, the distance of an object from the viewer is used to compute fog effects,
        /// not the depth of the object (that is, the z-coordinate) in the scene.
        /// In range-based fog, all fog methods work as usual, except that they use range instead of depth in the computations.
        /// Range is the correct factor to use for fog computations,
        /// but depth is commonly used instead because range is time-consuming to compute and depth is generally already available.
        /// Using depth to calculate fog has the undesirable effect of having the fogginess of peripheral objects change
        /// as the viewer's eye moves - in this case, the depth changes and the range remains constant.
        /// Because no hardware currently supports per-pixel range-based fog, range correction is offered only for vertex fog.
        /// For more information, see Vertex Fog (Direct3D 9).
        /// </summary>
        D3DRS_RANGEFOGENABLE = 48,

        /// <summary>
        /// <see cref="TRUE"/> to enable stenciling, or <see cref="FALSE"/> to disable stenciling.
        /// The default value is <see cref="FALSE"/>.
        /// For more information, see Stencil Buffer Techniques (Direct3D 9).
        /// </summary>
        D3DRS_STENCILENABLE = 52,

        /// <summary>
        /// Stencil operation to perform if the stencil test fails.
        /// Values are from the <see cref="D3DSTENCILOP"/> enumerated type.
        /// The default value is <see cref="D3DSTENCILOP_KEEP"/>.
        /// </summary>
        D3DRS_STENCILFAIL = 53,

        /// <summary>
        /// Stencil operation to perform if the stencil test passes and the depth test (z-test) fails.
        /// Values are from the <see cref="D3DSTENCILOP"/> enumerated type.
        /// The default value is <see cref="D3DSTENCILOP_KEEP"/>.
        /// </summary>
        D3DRS_STENCILZFAIL = 54,

        /// <summary>
        /// Stencil operation to perform if both the stencil and the depth (z) tests pass.
        /// Values are from the <see cref="D3DSTENCILOP"/> enumerated type.
        /// The default value is <see cref="D3DSTENCILOP_KEEP"/>.
        /// </summary>
        D3DRS_STENCILPASS = 55,

        /// <summary>
        /// Comparison function for the stencil test.
        /// Values are from the <see cref="D3DCMPFUNC"/> enumerated type.
        /// The default value is <see cref="D3DCMP_ALWAYS"/>.
        /// The comparison function is used to compare the reference value to a stencil buffer entry.
        /// This comparison applies only to the bits in the reference value and stencil buffer entry
        /// that are set in the stencil mask (set by the <see cref="D3DRS_STENCILMASK"/> render state).
        /// If <see cref="TRUE"/>, the stencil test passes.
        /// </summary>
        D3DRS_STENCILFUNC = 56,

        /// <summary>
        /// An int reference value for the stencil test.
        /// The default value is 0.
        /// </summary>
        D3DRS_STENCILREF = 57,

        /// <summary>
        /// Mask applied to the reference value and each stencil buffer entry to determine the significant bits for the stencil test.
        /// The default mask is 0xFFFFFFFF.
        /// </summary>
        D3DRS_STENCILMASK = 58,

        /// <summary>
        /// Write mask applied to values written into the stencil buffer.
        /// The default mask is 0xFFFFFFFF.
        /// </summary>
        D3DRS_STENCILWRITEMASK = 59,

        /// <summary>
        /// Color used for multiple-texture blending with the <see cref="D3DTA_TFACTOR"/> texture-blending argument
        /// or the <see cref="D3DTOP_BLENDFACTORALPHA"/> texture-blending operation.
        /// The associated value is a <see cref="D3DCOLOR"/> variable.
        /// The default value is opaque white (0xFFFFFFFF).
        /// </summary>
        D3DRS_TEXTUREFACTOR = 60,

        /// <summary>
        /// Texture-wrapping behavior for multiple sets of texture coordinates.
        /// Valid values for this render state can be any combination of the <see cref="D3DWRAPCOORD_0"/> (or <see cref="D3DWRAP_U"/>),
        /// <see cref="D3DWRAPCOORD_1"/> (or <see cref="D3DWRAP_V"/>), <see cref="D3DWRAPCOORD_2"/> (or <see cref="D3DWRAP_W"/>), and <see cref="D3DWRAPCOORD_3"/> flags.
        /// These cause the system to wrap in the direction of the first, second, third, and fourth dimensions,
        /// sometimes referred to as the s, t, r, and q directions, for a given texture.
        /// The default value for this render state is 0 (wrapping disabled in all directions).
        /// </summary>
        D3DRS_WRAP0 = 128,

        /// <summary>
        /// See <see cref="D3DRS_WRAP0"/>.
        /// </summary>
        D3DRS_WRAP1 = 129,

        /// <summary>
        /// See <see cref="D3DRS_WRAP0"/>.
        /// </summary>
        D3DRS_WRAP2 = 130,

        /// <summary>
        /// See <see cref="D3DRS_WRAP0"/>.
        /// </summary>
        D3DRS_WRAP3 = 131,

        /// <summary>
        /// See <see cref="D3DRS_WRAP0"/>.
        /// </summary>
        D3DRS_WRAP4 = 132,

        /// <summary>
        /// See <see cref="D3DRS_WRAP0"/>.
        /// </summary>
        D3DRS_WRAP5 = 133,

        /// <summary>
        /// See <see cref="D3DRS_WRAP0"/>.
        /// </summary>
        D3DRS_WRAP6 = 134,

        /// <summary>
        /// See <see cref="D3DRS_WRAP0"/>.
        /// </summary>
        D3DRS_WRAP7 = 135,

        /// <summary>
        /// <see cref="TRUE"/> to enable primitive clipping by Direct3D, or <see cref="FALSE"/> to disable it.
        /// The default value is <see cref="TRUE"/>.
        /// </summary>
        D3DRS_CLIPPING = 136,

        /// <summary>
        /// <see cref="TRUE"/> to enable Direct3D lighting, or <see cref="FALSE"/> to disable it.
        /// The default value is <see cref="TRUE"/>.
        /// Only vertices that include a vertex normal are properly lit; vertices that do not contain a normal employ a dot product of 0 in all lighting calculations.
        /// </summary>
        D3DRS_LIGHTING = 137,

        /// <summary>
        /// Ambient light color.
        /// This value is of type <see cref="D3DCOLOR"/>.
        /// The default value is 0.
        /// </summary>
        D3DRS_AMBIENT = 139,

        /// <summary>
        /// Fog formula to be used for vertex fog.
        /// Set to one member of the <see cref="D3DFOGMODE"/> enumerated type.
        /// The default value is <see cref="D3DFOG_NONE"/>.
        /// </summary>
        D3DRS_FOGVERTEXMODE = 140,

        /// <summary>
        /// <see cref="TRUE"/> to enable per-vertex color or <see cref="FALSE"/> to disable it.
        /// The default value is <see cref="TRUE"/>.
        /// Enabling per-vertex color allows the system to include the color defined for individual vertices in its lighting calculations.
        /// For more information, see the following render states:
        /// <see cref="D3DRS_DIFFUSEMATERIALSOURCE"/>, <see cref="D3DRS_SPECULARMATERIALSOURCE"/>,
        /// <see cref="D3DRS_AMBIENTMATERIALSOURCE"/>, <see cref="D3DRS_EMISSIVEMATERIALSOURCE"/>
        /// </summary>
        D3DRS_COLORVERTEX = 141,

        /// <summary>
        /// <see cref="TRUE"/> to enable camera-relative specular highlights, or <see cref="FALSE"/> to use orthogonal specular highlights.
        /// The default value is <see cref="TRUE"/>.
        /// Applications that use orthogonal projection should specify <see cref="FALSE"/>.
        /// </summary>
        D3DRS_LOCALVIEWER = 142,

        /// <summary>
        /// <see cref="TRUE"/> to enable automatic normalization of vertex normals, or <see cref="FALSE"/> to disable it.
        /// The default value is <see cref="FALSE"/>.
        /// Enabling this feature causes the system to normalize the vertex normals for vertices after transforming them to camera space,
        /// which can be computationally time-consuming.
        /// </summary>
        D3DRS_NORMALIZENORMALS = 143,

        /// <summary>
        /// Diffuse color source for lighting calculations.
        /// Valid values are members of the <see cref="D3DMATERIALCOLORSOURCE"/> enumerated type.
        /// The default value is <see cref="D3DMCS_COLOR1"/>.
        /// The value for this render state is used only if the <see cref="D3DRS_COLORVERTEX"/> render state is set to <see cref="TRUE"/>.
        /// </summary>
        D3DRS_DIFFUSEMATERIALSOURCE = 145,

        /// <summary>
        /// Specular color source for lighting calculations.
        /// Valid values are members of the <see cref="D3DMATERIALCOLORSOURCE"/> enumerated type.
        /// The default value is <see cref="D3DMCS_COLOR2"/>.
        /// </summary>
        D3DRS_SPECULARMATERIALSOURCE = 146,

        /// <summary>
        /// Ambient color source for lighting calculations.
        /// Valid values are members of the <see cref="D3DMATERIALCOLORSOURCE"/> enumerated type.
        /// The default value is <see cref="D3DMCS_MATERIAL"/>.
        /// </summary>
        D3DRS_AMBIENTMATERIALSOURCE = 147,

        /// <summary>
        /// Emissive color source for lighting calculations.
        /// Valid values are members of the <see cref="D3DMATERIALCOLORSOURCE"/> enumerated type.
        /// The default value is <see cref="D3DMCS_MATERIAL"/>.
        /// </summary>
        D3DRS_EMISSIVEMATERIALSOURCE = 148,

        /// <summary>
        /// Number of matrices to use to perform geometry blending, if any.
        /// Valid values are members of the <see cref="D3DVERTEXBLENDFLAGS"/> enumerated type.
        /// The default value is <see cref="D3DVBF_DISABLE"/>.
        /// </summary>
        D3DRS_VERTEXBLEND = 151,

        /// <summary>
        /// Enables or disables user-defined clipping planes.
        /// Valid values are any <see cref="DWORD"/> in which the status of each bit (set or not set)
        /// toggles the activation state of a corresponding user-defined clipping plane.
        /// The least significant bit (bit 0) controls the first clipping plane at index 0,
        /// and subsequent bits control the activation of clipping planes at higher indexes.
        /// If a bit is set, the system applies the appropriate clipping plane during scene rendering.
        /// The default value is 0.
        /// The <see cref="D3DCLIPPLANEn"/> macros are defined to provide a convenient way to enable clipping planes.
        /// </summary>
        D3DRS_CLIPPLANEENABLE = 152,

        /// <summary>
        /// D3DRS_SOFTWAREVERTEXPROCESSING
        /// </summary>
        D3DRS_SOFTWAREVERTEXPROCESSING = 153,

        /// <summary>
        /// A float value that specifies the size to use for point size computation in cases where point size is not specified for each vertex.
        /// This value is not used when the vertex contains point size.
        /// This value is in screen space units if <see cref="D3DRS_POINTSCALEENABLE"/> is <see cref="FALSE"/>; otherwise this value is in world space units.
        /// The default value is the value a driver returns.
        /// If a driver returns 0 or 1, the default value is 64, which allows software point size emulation.
        /// Because the <see cref="IDirect3DDevice9.SetRenderState"/> method accepts <see cref="DWORD"/> values,
        /// your application must cast a variable that contains the value, as shown in the following code example.
        /// <code>
        /// m_pDevice9->SetRenderState(D3DRS_POINTSIZE, *((DWORD*)&amp;pointSize));
        /// </code>
        /// </summary>
        D3DRS_POINTSIZE = 154,

        /// <summary>
        /// A float value that specifies the minimum size of point primitives.
        /// Point primitives are clamped to this size during rendering.
        /// Setting this to values smaller than 1.0 results in points dropping out when the point does not cover a pixel center
        /// and antialiasing is disabled or being rendered with reduced intensity when antialiasing is enabled.
        /// The default value is 1.0f.
        /// The range for this value is greater than or equal to 0.0f.
        /// Because the <see cref="IDirect3DDevice9.SetRenderState"/> method accepts <see cref="DWORD"/> values,
        /// your application must cast a variable that contains the value, as shown in the following code example.
        /// <code>
        /// m_pDevice9->SetRenderState(D3DRS_POINTSIZE_MIN, *((DWORD*)&amp;pointSizeMin));
        /// </code>
        /// </summary>
        D3DRS_POINTSIZE_MIN = 155,

        /// <summary>
        /// bool value.
        /// When <see cref="TRUE"/>, texture coordinates of point primitives are set so that full textures are mapped on each point.
        /// When <see cref="FALSE"/>, the vertex texture coordinates are used for the entire point.
        /// The default value is <see cref="FALSE"/>.
        /// You can achieve DirectX 7 style single-pixel points by setting <see cref="D3DRS_POINTSCALEENABLE"/> to <see cref="FALSE"/>
        /// and <see cref="D3DRS_POINTSIZE"/> to 1.0, which are the default values.
        /// </summary>
        D3DRS_POINTSPRITEENABLE = 156,

        /// <summary>
        /// bool value that controls computation of size for point primitives.
        /// When <see cref="TRUE"/>, the point size is interpreted as a camera space value and is scaled by the distance function
        /// and the frustum to viewport y-axis scaling to compute the final screen-space point size.
        /// When <see cref="FALSE"/>, the point size is interpreted as screen space and used directly.
        /// The default value is <see cref="FALSE"/>.
        /// </summary>
        D3DRS_POINTSCALEENABLE = 157,

        /// <summary>
        /// A float value that controls for distance-based size attenuation for point primitives.
        /// Active only when <see cref="D3DRS_POINTSCALEENABLE"/> is <see cref="TRUE"/>.
        /// The default value is 1.0f. The range for this value is greater than or equal to 0.0f.
        /// Because the <see cref="IDirect3DDevice9.SetRenderState"/> method accepts DWORD values,
        /// your application must cast a variable that contains the value, as shown in the following code example.
        /// <code>
        /// m_pDevice9->SetRenderState(D3DRS_POINTSCALE_A, *((DWORD*)&amp;pointScaleA));
        /// </code>
        /// </summary>
        D3DRS_POINTSCALE_A = 158,

        /// <summary>
        /// A float value that controls for distance-based size attenuation for point primitives.
        /// Active only when <see cref="D3DRS_POINTSCALEENABLE"/> is <see cref="TRUE"/>.
        /// The default value is 0.0f. The range for this value is greater than or equal to 0.0f.
        /// Because the <see cref="IDirect3DDevice9.SetRenderState"/> method accepts DWORD values,
        /// your application must cast a variable that contains the value, as shown in the following code example.
        /// <code>
        /// m_pDevice9->SetRenderState(D3DRS_POINTSCALE_B, *((DWORD*)&amp;pointScaleB));
        /// </code>
        /// </summary>
        D3DRS_POINTSCALE_B = 159,

        /// <summary>
        /// A float value that controls for distance-based size attenuation for point primitives.
        /// Active only when <see cref="D3DRS_POINTSCALEENABLE"/> is <see cref="TRUE"/>.
        /// The default value is 0.0f. The range for this value is greater than or equal to 0.0f.
        /// Because the <see cref="IDirect3DDevice9.SetRenderState"/> method accepts DWORD values,
        /// your application must cast a variable that contains the value, as shown in the following code example.
        /// <code>
        /// m_pDevice9->SetRenderState(D3DRS_POINTSCALE_C, *((DWORD*)&amp;pointScaleC));
        /// </code>
        /// </summary>
        D3DRS_POINTSCALE_C = 160,

        /// <summary>
        /// bool value that determines how individual samples are computed when using a multisample render-target buffer.
        /// When set to <see cref="TRUE"/>, the multiple samples are computed so that full-scene antialiasing is performed
        /// by sampling at different sample positions for each multiple sample.
        /// When set to <see cref="FALSE"/>, the multiple samples are all written with the same sample value,
        /// sampled at the pixel center, which allows non-antialiased rendering to a multisample buffer.
        /// This render state has no effect when rendering to a single sample buffer.
        /// The default value is <see cref="TRUE"/>.
        /// </summary>
        D3DRS_MULTISAMPLEANTIALIAS = 161,

        /// <summary>
        /// Each bit in this mask, starting at the least significant bit (LSB), controls modification of one of the samples in a multisample render target.
        /// Thus, for an 8-sample render target, the low byte contains the eight write enables for each of the eight samples.
        /// This render state has no effect when rendering to a single sample buffer.
        /// The default value is 0xFFFFFFFF.
        /// This render state enables use of a multisample buffer as an accumulation buffer,
        /// doing multipass rendering of geometry where each pass updates a subset of samples.
        /// If there are n multisamples and k enabled samples, the resulting intensity of the rendered image should be k/n.
        /// Each component RGB of every pixel is factored by k/n.
        /// </summary>
        D3DRS_MULTISAMPLEMASK = 162,

        /// <summary>
        /// Sets whether patch edges will use float style tessellation.
        /// Possible values are defined by the <see cref="D3DPATCHEDGESTYLE"/> enumerated type.
        /// The default value is <see cref="D3DPATCHEDGE_DISCRETE"/>.
        /// </summary>
        D3DRS_PATCHEDGESTYLE = 163,

        /// <summary>
        /// Set only for debugging the monitor.
        /// Possible values are defined by the <see cref="D3DDEBUGMONITORTOKENS"/> enumerated type.
        /// Note that if <see cref="D3DRS_DEBUGMONITORTOKEN"/> is set, the call is treated as passing a token to the debug monitor.
        /// For example, if - after passing <see cref="D3DDMT_ENABLE"/> or <see cref="D3DDMT_DISABLE"/> to <see cref="D3DRS_DEBUGMONITORTOKEN"/>
        /// - other token values are passed in, the state (enabled or disabled) of the debug monitor will still persist.
        /// This state is only useful for debug builds.
        /// The debug monitor defaults to <see cref="D3DDMT_ENABLE"/>.
        /// </summary>
        D3DRS_DEBUGMONITORTOKEN = 165,

        /// <summary>
        /// A float value that specifies the maximum size to which point sprites will be clamped.
        /// The value must be less than or equal to the <see cref="D3DCAPS9.MaxPointSize"/> member of <see cref="D3DCAPS9"/>
        /// and greater than or equal to <see cref="D3DRS_POINTSIZE_MIN"/>.
        /// The default value is 64.0.
        /// Because the <see cref="IDirect3DDevice9.SetRenderState"/>method accepts <see cref="DWORD"/> values,
        /// your application must cast a variable that contains the value, as shown in the following code example.
        /// <code>
        /// m_pDevice9->SetRenderState(D3DRS_PONTSIZE_MAX, *((DWORD*)&amp;pointSizeMax));
        /// </code>
        /// </summary>
        D3DRS_POINTSIZE_MAX = 166,

        /// <summary>
        /// bool value that enables or disables indexed vertex blending.
        /// The default value is <see cref="FALSE"/>.
        /// When set to <see cref="TRUE"/>, indexed vertex blending is enabled.
        /// When set to <see cref="FALSE"/>, indexed vertex blending is disabled.
        /// If this render state is enabled, the user must pass matrix indices as a packed <see cref="DWORD"/> with every vertex.
        /// When the render state is disabled and vertex blending is enabled through the <see cref="D3DRS_VERTEXBLEND"/> state,
        /// it is equivalent to having matrix indices 0, 1, 2, 3 in every vertex.
        /// </summary>
        D3DRS_INDEXEDVERTEXBLENDENABLE = 167,

        /// <summary>
        /// <see cref="UINT"/> value that enables a per-channel write for the render-target color buffer.
        /// A set bit results in the color channel being updated during 3D rendering.
        /// A clear bit results in the color channel being unaffected.
        /// This functionality is available if the <see cref="D3DPMISCCAPS_COLORWRITEENABLE"/> capabilities bit is set
        /// in the <see cref="D3DCAPS9.PrimitiveMiscCaps"/> member of the <see cref="D3DCAPS9"/> structure for the device.
        /// This render state does not affect the clear operation.
        /// The default value is 0x0000000F.
        /// Valid values for this render state can be any combination of the <see cref="D3DCOLORWRITEENABLE_ALPHA"/>,
        /// <see cref="D3DCOLORWRITEENABLE_BLUE"/>, <see cref="D3DCOLORWRITEENABLE_GREEN"/>, or <see cref="D3DCOLORWRITEENABLE_RED"/> flags.
        /// </summary>
        D3DRS_COLORWRITEENABLE = 168,

        /// <summary>
        /// A float value that controls the tween factor.
        /// The default value is 0.0f.
        /// Because the <see cref="IDirect3DDevice9.SetRenderState"/> method accepts <see cref="DWORD"/> values,
        /// your application must cast a variable that contains the value, as shown in the following code example.
        /// <code>
        /// m_pDevice9->SetRenderState(D3DRS_TWEENFACTOR, *((DWORD*)&amp;TweenFactor));
        /// </code>
        /// </summary>
        D3DRS_TWEENFACTOR = 170,

        /// <summary>
        /// Value used to select the arithmetic operation applied when the alpha blending render state,
        /// <see cref="D3DRS_ALPHABLENDENABLE"/>, is set to <see cref="TRUE"/>.
        /// Valid values are defined by the <see cref="D3DBLENDOP"/> enumerated type.
        /// The default value is <see cref="D3DBLENDOP_ADD"/>.
        /// If the <see cref="D3DPMISCCAPS_BLENDOP"/> device capability is not supported, then <see cref="D3DBLENDOP_ADD"/> is performed.
        /// </summary>
        D3DRS_BLENDOP = 171,

        /// <summary>
        /// N-patch position interpolation degree.
        /// The values can be <see cref="D3DDEGREE_CUBIC"/> (default) or <see cref="D3DDEGREE_LINEAR"/>.
        /// For more information, see <see cref="D3DDEGREETYPE"/>.
        /// </summary>
        D3DRS_POSITIONDEGREE = 172,

        /// <summary>
        /// N-patch normal interpolation degree.
        /// The values can be <see cref="D3DDEGREE_LINEAR"/> (default) or <see cref="D3DDEGREE_QUADRATIC"/>.
        /// For more information, see <see cref="D3DDEGREETYPE"/>.
        /// </summary>
        D3DRS_NORMALDEGREE = 173,

        /// <summary>
        /// <see cref="TRUE"/> to enable scissor testing and <see cref="FALSE"/> to disable it.
        /// The default value is <see cref="FALSE"/>.
        /// </summary>
        D3DRS_SCISSORTESTENABLE = 174,

        /// <summary>
        /// Used to determine how much bias can be applied to co-planar primitives to reduce z-fighting. The default value is 0.
        /// bias = (max * <see cref="D3DRS_SLOPESCALEDEPTHBIAS"/>) + <see cref="D3DRS_DEPTHBIAS"/>.
        /// where max is the maximum depth slope of the triangle being rendered.
        /// </summary>
        D3DRS_SLOPESCALEDEPTHBIAS = 175,

        /// <summary>
        /// <see cref="TRUE"/> to enable line antialiasing, <see cref="FALSE"/> to disable line antialiasing.
        /// The default value is <see cref="FALSE"/>.
        /// When rendering to a multisample render target, <see cref="D3DRS_ANTIALIASEDLINEENABLE"/> is ignored and all lines are rendered aliased.
        /// Use <see cref="ID3DXLine"/> for antialiased line rendering in a multisample render target.
        /// </summary>
        D3DRS_ANTIALIASEDLINEENABLE = 176,

        /// <summary>
        /// Minimum tessellation level.
        /// The default value is 1.0f.
        /// See Tessellation (Direct3D 9).
        /// </summary>
        D3DRS_MINTESSELLATIONLEVEL = 178,

        /// <summary>
        /// Maximum tessellation level.
        /// The default value is 1.0f.
        /// See Tessellation (Direct3D 9).
        /// </summary>
        D3DRS_MAXTESSELLATIONLEVEL = 179,

        /// <summary>
        /// Amount to adaptively tessellate, in the x direction.
        /// Default value is 0.0f.
        /// See Adaptive Tessellation.
        /// </summary>
        D3DRS_ADAPTIVETESS_X = 180,

        /// <summary>
        /// Amount to adaptively tessellate, in the y direction.
        /// Default value is 0.0f.
        /// See Adaptive_Tessellation.
        /// </summary>
        D3DRS_ADAPTIVETESS_Y = 181,

        /// <summary>
        /// Amount to adaptively tessellate, in the z direction.
        /// Default value is 1.0f.
        /// See Adaptive_Tessellation.
        /// </summary>
        D3DRS_ADAPTIVETESS_Z = 182,

        /// <summary>
        /// Amount to adaptively tessellate, in the w direction.
        /// Default value is 0.0f.
        /// See Adaptive_Tessellation.
        /// </summary>
        D3DRS_ADAPTIVETESS_W = 183,

        /// <summary>
        /// <see cref="TRUE"/> to enable adaptive tessellation, <see cref="FALSE"/> to disable it.
        /// The default value is <see cref="FALSE"/>.
        /// See Adaptive_Tessellation.
        /// </summary>
        D3DRS_ENABLEADAPTIVETESSELLATION = 184,

        /// <summary>
        /// <see cref="TRUE"/> enables two-sided stenciling, <see cref="FALSE"/> disables it.
        /// The default value is <see cref="FALSE"/>.
        /// The application should set <see cref="D3DRS_CULLMODE"/> to <see cref="D3DCULL_NONE"/> to enable two-sided stencil mode.
        /// If the triangle winding order is clockwise, the D3DRS_STENCIL* operations will be used.
        /// If the winding order is counterclockwise, the D3DRS_CCW_STENCIL* operations will be used.
        /// To see if two-sided stencil is supported, check the <see cref="D3DCAPS9.StencilCaps"/> member
        /// of <see cref="D3DCAPS9"/> for <see cref="D3DSTENCILCAPS_TWOSIDED"/>.
        /// See also <see cref="D3DSTENCILCAPS"/>.
        /// </summary>
        D3DRS_TWOSIDEDSTENCILMODE = 185,

        /// <summary>
        /// Stencil operation to perform if CCW stencil test fails.
        /// Values are from the <see cref="D3DSTENCILOP"/> enumerated type.
        /// The default value is <see cref="D3DSTENCILOP_KEEP"/>.
        /// </summary>
        D3DRS_CCW_STENCILFAIL = 186,

        /// <summary>
        /// Stencil operation to perform if CCW stencil test passes and z-test fails.
        /// Values are from the <see cref="D3DSTENCILOP"/> enumerated type.
        /// The default value is <see cref="D3DSTENCILOP_KEEP"/>.
        /// </summary>
        D3DRS_CCW_STENCILZFAIL = 187,

        /// <summary>
        /// Stencil operation to perform if both CCW stencil and z-tests pass.
        /// Values are from the <see cref="D3DSTENCILOP"/> enumerated type.
        /// The default value is <see cref="D3DSTENCILOP_KEEP"/>.
        /// </summary>
        D3DRS_CCW_STENCILPASS = 188,

        /// <summary>
        /// The comparison function.
        /// CCW stencil test passes if ((ref &amp; mask) stencil function (stencil &amp; mask)) is <see cref="TRUE"/>.
        /// Values are from the <see cref="D3DCMPFUNC"/> enumerated type.
        /// The default value is <see cref="D3DCMP_ALWAYS"/>.
        /// </summary>
        D3DRS_CCW_STENCILFUNC = 189,

        /// <summary>
        /// Additional ColorWriteEnable values for the devices.
        /// See <see cref="D3DRS_COLORWRITEENABLE"/>.
        /// This functionality is available if the <see cref="D3DPMISCCAPS_INDEPENDENTWRITEMASKS"/> capabilities bit is set
        /// in the <see cref="D3DCAPS9.PrimitiveMiscCaps"/> member of the <see cref="D3DCAPS9"/> structure for the device.
        /// The default value is 0x0000000f.
        /// </summary>
        D3DRS_COLORWRITEENABLE1 = 190,

        /// <summary>
        /// Additional ColorWriteEnable values for the devices.
        /// See <see cref="D3DRS_COLORWRITEENABLE"/>.
        /// This functionality is available if the <see cref="D3DPMISCCAPS_INDEPENDENTWRITEMASKS"/> capabilities bit is set
        /// in the <see cref="D3DCAPS9.PrimitiveMiscCaps"/> member of the <see cref="D3DCAPS9"/> structure for the device.
        /// The default value is 0x0000000f.
        /// </summary>
        D3DRS_COLORWRITEENABLE2 = 191,

        /// <summary>
        /// Additional ColorWriteEnable values for the devices.
        /// See <see cref="D3DRS_COLORWRITEENABLE"/>.
        /// This functionality is available if the <see cref="D3DPMISCCAPS_INDEPENDENTWRITEMASKS"/> capabilities bit is set
        /// in the <see cref="D3DCAPS9.PrimitiveMiscCaps"/> member of the <see cref="D3DCAPS9"/> structure for the device.
        /// The default value is 0x0000000f.
        /// </summary>
        D3DRS_COLORWRITEENABLE3 = 192,

        /// <summary>
        /// <see cref="D3DCOLOR"/> used for a constant blend-factor during alpha blending.
        /// This functionality is available if the <see cref="D3DPBLENDCAPS_BLENDFACTOR"/> capabilities bit is set
        /// in the <see cref="D3DCAPS9.SrcBlendCaps"/> member of <see cref="D3DCAPS9"/> or the <see cref="D3DCAPS9.DestBlendCaps"/> member of <see cref="D3DCAPS9"/>.
        /// See <see cref="D3DRENDERSTATETYPE"/>.
        /// The default value is 0xffffffff.
        /// </summary>
        D3DRS_BLENDFACTOR = 193,

        /// <summary>
        /// Enable render-target writes to be gamma corrected to sRGB.
        /// The format must expose <see cref="D3DUSAGE_SRGBWRITE"/>.
        /// The default value is 0.
        /// </summary>
        D3DRS_SRGBWRITEENABLE = 194,

        /// <summary>
        /// A floating-point value that is used for comparison of depth values.
        /// See Depth Bias (Direct3D 9).
        /// The default value is 0.
        /// </summary>
        D3DRS_DEPTHBIAS = 195,

        /// <summary>
        /// See D3DRS_WRAP0.
        /// </summary>
        D3DRS_WRAP8 = 198,

        /// <summary>
        /// See D3DRS_WRAP0.
        /// </summary>
        D3DRS_WRAP9 = 199,

        /// <summary>
        /// See D3DRS_WRAP0.
        /// </summary>
        D3DRS_WRAP10 = 200,

        /// <summary>
        /// See D3DRS_WRAP0.
        /// </summary>
        D3DRS_WRAP11 = 201,

        /// <summary>
        /// See D3DRS_WRAP0.
        /// </summary>
        D3DRS_WRAP12 = 202,

        /// <summary>
        /// See D3DRS_WRAP0.
        /// </summary>
        D3DRS_WRAP13 = 203,

        /// <summary>
        /// See D3DRS_WRAP0.
        /// </summary>
        D3DRS_WRAP14 = 204,

        /// <summary>
        /// See D3DRS_WRAP0.
        /// </summary>
        D3DRS_WRAP15 = 205,

        /// <summary>
        /// <see cref="TRUE"/> enables the separate blend mode for the alpha channel.
        /// The default value is <see cref="FALSE"/>.
        /// When set to <see cref="FALSE"/>, the render-target blending factors
        /// and operations applied to alpha are forced to be the same as those defined for color.
        /// This mode is effectively hardwired to <see cref="FALSE"/> on implementations that don't set the cap <see cref="D3DPMISCCAPS_SEPARATEALPHABLEND"/>.
        /// See <see cref="D3DPMISCCAPS"/>.
        /// The type of separate alpha blending is determined by the <see cref="D3DRS_SRCBLENDALPHA"/> and <see cref="D3DRS_DESTBLENDALPHA"/> render states.
        /// </summary>
        D3DRS_SEPARATEALPHABLENDENABLE = 206,

        /// <summary>
        /// One member of the <see cref="D3DBLEND"/> enumerated type.
        /// This value is ignored unless <see cref="D3DRS_SEPARATEALPHABLENDENABLE"/> is <see cref="TRUE"/>.
        /// The default value is <see cref="D3DBLEND_ONE"/>.
        /// </summary>
        D3DRS_SRCBLENDALPHA = 207,

        /// <summary>
        /// One member of the <see cref="D3DBLEND"/> enumerated type.
        /// This value is ignored unless <see cref="D3DRS_SEPARATEALPHABLENDENABLE"/> is <see cref="TRUE"/>.
        /// The default value is <see cref="D3DBLEND_ZERO"/>.
        /// </summary>
        D3DRS_DESTBLENDALPHA = 208,

        /// <summary>
        /// Value used to select the arithmetic operation applied to separate alpha blending
        /// when the render state, <see cref="D3DRS_SEPARATEALPHABLENDENABLE"/>, is set to <see cref="TRUE"/>.
        /// Valid values are defined by the <see cref="D3DBLENDOP"/> enumerated type. The default value is <see cref="D3DBLENDOP_ADD"/>.
        /// If the <see cref="D3DPMISCCAPS_BLENDOP"/> device capability is not supported, then <see cref="D3DBLENDOP_ADD"/> is performed.
        /// See <see cref="D3DPMISCCAPS"/>.
        /// </summary>
        D3DRS_BLENDOPALPHA = 209,

        /// <summary>
        /// Forces this enumeration to compile to 32 bits in size.
        /// Without this value, some compilers would allow this enumeration to compile to a size other than 32 bits.
        /// This value is not used.
        /// </summary>
        D3DRS_FORCE_DWORD = 0x7fffffff
    }
}
