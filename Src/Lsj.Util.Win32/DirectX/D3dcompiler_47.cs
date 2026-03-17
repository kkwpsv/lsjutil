using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.DirectX.ComInterfaces;
using Lsj.Util.Win32.DirectX.Enums;
using Lsj.Util.Win32.DirectX.Structs;
using Lsj.Util.Win32.Marshals;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.DirectX.Constants;
using static Lsj.Util.Win32.UnsafePInvokeExtensions;

namespace Lsj.Util.Win32.DirectX
{
    /// <summary>
    /// D3dcompiler_47.cs
    /// </summary>
    public static class D3dcompiler_47
    {
        /// <summary>
        /// <para>
        /// Compile HLSL code or an effect file into bytecode for a given target.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3dcompiler/nf-d3dcompiler-d3dcompile"/>
        /// </para>
        /// </summary>
        /// <param name="pSrcData">
        /// A pointer to uncompiled shader data; either ASCII HLSL code or a compiled effect.
        /// </param>
        /// <param name="SrcDataSize">
        /// Length of <paramref name="pSrcData"/>.
        /// </param>
        /// <param name="pSourceName">
        /// You can use this parameter for strings that specify error messages.
        /// If not used, set to <see cref="NULL"/>.
        /// </param>
        /// <param name="pDefines">
        /// An optional array of <see cref="D3D_SHADER_MACRO"/> structures that define shader macros.
        /// Each macro definition contains a name and a null-terminated definition.
        /// If not used, set to <see langword="null"/>.
        /// The last structure in the array serves as a terminator and must have all members set to <see cref="NULL"/>.
        /// </param>
        /// <param name="pInclude">
        /// <para>
        /// Optional.
        /// A pointer to an <see cref="ID3DInclude"/> for handling include files.
        /// Setting this to <see cref="NULL"/> will cause a compile error if a shader contains a #include.
        /// You can pass the <see cref="D3D_COMPILE_STANDARD_FILE_INCLUDE"/> macro,
        /// which is a pointer to a default include handler.
        /// This default include handler includes files that are relative to the current directory and files
        /// that are relative to the directory of the initial source file.
        /// When you use <see cref="D3D_COMPILE_STANDARD_FILE_INCLUDE"/>,
        /// you must specify the source file name in the <paramref name="pSourceName"/> parameter;
        /// the compiler will derive the initial relative directory from <paramref name="pSourceName"/>.
        /// </para>
        /// <code>
        /// #define D3D_COMPILE_STANDARD_FILE_INCLUDE ((ID3DInclude*)(UINT_PTR)1)
        /// </code>
        /// </param>
        /// <param name="pEntrypoint">
        /// The name of the shader entry point function where shader execution begins.
        /// When you compile using a fx profile (for example, fx_4_0, fx_5_0, and so on),
        /// <see cref="D3DCompile"/> ignores <paramref name="pEntrypoint"/>.
        /// In this case, we recommend that you set <paramref name="pEntrypoint"/> to <see cref="NULL"/>
        /// because it is good programming practice to set a pointer parameter to <see cref="NULL"/>
        /// if the called function will not use it.
        /// For all other shader profiles, a valid <paramref name="pEntrypoint"/> is required.
        /// </param>
        /// <param name="pTarget">
        /// A string that specifies the shader target or set of shader features to compile against.
        /// The shader target can be shader model 2, shader model 3, shader model 4, or shader model 5.
        /// The target can also be an effect type (for example, fx_4_1).
        /// For info about the targets that various profiles support, see Specifying Compiler Targets.
        /// </param>
        /// <param name="Flags1">
        /// Flags defined by D3D compile constants.
        /// </param>
        /// <param name="Flags2">
        /// Flags defined by D3D compile effect constants.
        /// When you compile a shader and not an effect file, <see cref="D3DCompile"/> ignores <paramref name="Flags2"/>;
        /// we recommend that you set <paramref name="Flags2"/> to zero
        /// because it is good programming practice to set a nonpointer parameter to zero
        /// if the called function will not use it.
        /// </param>
        /// <param name="ppCode">
        /// A pointer to a variable that receives a pointer to the <see cref="ID3DBlob"/> interface
        /// that you can use to access the compiled code.
        /// </param>
        /// <param name="ppErrorMsgs">
        /// A pointer to a variable that receives a pointer to the <see cref="ID3DBlob"/> interface
        /// that you can use to access compiler error messages,
        /// or <see cref="NullRef{ID3DBlob}"/> if there are no errors.
        /// </param>
        /// <returns>
        /// Returns one of the Direct3D 11 return codes.
        /// </returns>
        /// <remarks>
        /// The difference between <see cref="D3DCompile"/> and <see cref="D3DCompile2"/>
        /// is that the latter method takes some optional parameters
        /// that can be used to control some aspects of how bytecode is generated.
        /// If this extra flexibility is not required,
        /// there is no performance gain from using <see cref="D3DCompile2"/>.
        /// </remarks>
        [DllImport("d3dcompiler_47.dll", CharSet = CharSet.Unicode, EntryPoint = "D3DCompile", ExactSpelling = true)]
        public static extern HRESULT D3DCompile([In] LPCVOID pSrcData, [In] SIZE_T SrcDataSize, [In] LPCSTR pSourceName,
            [In] D3D_SHADER_MACRO[]? pDefines,
#if NETFRAMEWORK
            [In] nint pInclude,
#else
            [In] P<ID3DInclude> pInclude,
#endif
            [In] LPCSTR pEntrypoint, [In] LPCSTR pTarget, [In] D3DCOMPILE Flags1, [In] D3DCOMPILE_EFFECT Flags2,
#if NETFRAMEWORK
            [Out] out nint ppCode, [Out] out nint ppErrorMsgs
#else
            [Out] out P<ID3DBlob> ppCode, [Out] out P<ID3DBlob> ppErrorMsgs
#endif
            );
    }
}
