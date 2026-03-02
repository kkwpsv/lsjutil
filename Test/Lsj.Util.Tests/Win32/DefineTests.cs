using Lsj.Util.Reflection;
using Lsj.Util.Win32;
using Lsj.Util.Win32.Attributes;
using Lsj.Util.Win32.ComInterfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;

namespace Lsj.Util.Tests.Win32
{
    [TestClass]
    public partial class DefineTests
    {
        private static readonly List<string> _newApis = new List<string>
        {
            "DXGIDisableVBlankVirtualization",
            "DXGIGetDebugInterface",
            "SetThreadCursorCreationScaling",
        };

        private static readonly List<string> _missingWindowsVersionRequirementWhiteList = new List<string>
        {
            "CreateDirect3D11DeviceFromDXGIDevice",
            "D3D11CreateDevice",
            "D3D11CreateDeviceAndSwapChain",
            "D3D12CreateDevice",
            "Direct3DCreate9",
            "Direct3DCreate9Ex",
            "Direct3DCreate9On12",
            "Direct3DCreate9On12Ex",
            "D3DCompile",
            "D3DXCheckVersion",
            "D3DXCreateBuffer",
        };

        private static readonly List<string> _missingAPIDataWhiteList = new List<string>
        {
            "DXGIGetDebugInterface",
        };

        private static readonly List<string> _genericTypeParameterWhiteList = new List<string>
        {
            "D3D11CreateDevice",
            "D3D11CreateDeviceAndSwapChain",
            "D3D12CreateDevice",
            "D3DCompile",
            "GetNumberOfPhysicalMonitorsFromIDirect3DDevice9",
            "GetPhysicalMonitorsFromIDirect3DDevice9",
            "CopyFileEx",
            "CopyFileTransacted",
            "MFGetService",
            "MFCreateSourceReaderFromURL",
            "BindMoniker",
            "CoCopyProxy",
            "CoCreateInstance",
            "CoCreateInstanceEx",
            "CoDisconnectObject",
            "CoGetInstanceFromFile",
            "CoGetInstanceFromIStorage",
            "CoGetMarshalSizeMax",
            "CoGetStandardMarshal",
            "CoMarshalInterface",
            "CoQueryProxyBlanket",
            "CoRegisterClassObject",
            "CoReleaseMarshalData",
            "CoSetProxyBlanket",
            "CreateGenericComposite",
            "MkParseDisplayName",
            "OleCreate",
            "OleCreateDefaultHandler",
            "OleCreateFromData",
            "OleCreateFromFile",
            "OleCreateLink",
            "OleLoad",
            "OleSave",
            "StgOpenStorage",
            "WriteClassStg",
            "CreateStdDispatch",
            "CreateURLMoniker",
            "CreateURLMonikerEx",
            "BackupRead",
            "BackupWrite",
            "InitializeSid",
            "SetNamedSecurityInfo",
            "SetSecurityInfo",
            "GetRawInputBuffer",
        };

 
        [TestMethod]
        public void TestMethods()
        {
            var apis = ReadFromFiles();
            var toCheckApis = apis.Where(x =>
                (x.Value.DllName == "user32" && x.Value.Version <= WindowsVersion.Windows8_1) ||
                (x.Value.DllName == "kernel32" && x.Value.Version <= WindowsVersion.WindowsXP) ||
                (x.Value.DllName == "advapi32" && x.Value.Version <= WindowsVersion.Windows2000) ||
                (x.Value.DllName == "gdi32" && x.Value.Version <= WindowsVersion.Windows7))
                .Where(x => !x.Key.EndsWith("A") && !_skipApiList.Contains(x.Key) && !_notImplemntApiList.Contains(x.Key))
                .Select(x => x.Key).ToHashSet();
            var methods = typeof(Lsj.Util.Win32.Kernel32).Assembly.GetTypes().SelectMany(t => t.GetMethods()).Where(m => m.IsStatic && m.GetCustomAttribute<DllImportAttribute>() != null);
            var methodsToEntryPoints = methods.Select(m => (Method: m, Attribute: m.GetCustomAttribute<DllImportAttribute>()!)).OrderBy(x => x.Attribute.Value).ThenBy(x => x.Attribute.EntryPoint).ToList();
            var wrongEntrypoints = new List<(MethodInfo Method, DllImportAttribute Attribute)>();
            var missingWindowsVersionRequirementMethods = new List<MethodInfo>();
            var missingAPIDataMethods = new List<MethodInfo>();
            var wrongWindowsVersionRequirementMethods = new List<(MethodInfo Method, (WindowsVersion Version, int BuildNumber, string? Note, string DllName))>();
            var hasMarshalAsAttributeMethods = new List<MethodInfo>();
            var hasStringParameterMethods = new List<MethodInfo>();
            var hasObjectParameterMethods = new List<MethodInfo>();
            var hasRawComInterfaceParameterMethods = new List<MethodInfo>();
            var hasGenericTypeParameterMethods = new List<MethodInfo>();
            foreach (var item in methodsToEntryPoints)
            {
                var entryPoint = item.Attribute.EntryPoint;
                toCheckApis.Remove(entryPoint!);
                if (item.Method.Name == entryPoint || item.Method.Name + "W" == entryPoint ||
                    "K32" + item.Method.Name == entryPoint || "K32" + item.Method.Name + "W" == entryPoint)
                {
                    if (Kernel32.GetProcAddress(Kernel32.LoadLibrary(item.Attribute.Value), entryPoint) == IntPtr.Zero)
                    {
                        if (item.Attribute.Value == "Wlanapi.dll")
                        {
                        }
                        else if (item.Attribute.Value.StartsWith("D3DX9"))
                        {
                        }
                        else if (_newApis.Contains(entryPoint))
                        {
                        }
                        else
                        {
                            wrongEntrypoints.Add(item);
                        }
                    }
                }
                else
                {
                    wrongEntrypoints.Add(item);
                }

                if (apis.TryGetValue(entryPoint!, out var version))
                {
                    var attribute = item.Method.GetCustomAttribute<WindowsVersionRequirementAttribute>();
                    if (attribute == null || attribute.Version != version.Version || attribute.BuildNumber != version.BuildNumber ||
                        (version.Note is string note && attribute.Note?.Contains(note) is not true))
                    {
                        wrongWindowsVersionRequirementMethods.Add((item.Method, version));
                    }
                }
                else
                {
                    if (item.Method.GetCustomAttribute<WindowsVersionRequirementAttribute>() == null)
                    {
                        if (!_missingWindowsVersionRequirementWhiteList.Contains(item.Method.Name))
                        {
                            missingWindowsVersionRequirementMethods.Add(item.Method);
                        }
                    }
                    else
                    {
                        if (!_missingAPIDataWhiteList.Contains(item.Method.Name))
                        {
                            missingAPIDataMethods.Add(item.Method);
                        }
                    }
                }

                if (item.Method.GetParameters().Any(x => x.GetCustomAttribute<MarshalAsAttribute>() != null))
                {
                    hasMarshalAsAttributeMethods.Add(item.Method);
                }

                if (item.Method.GetParameters().Any(x => x.ParameterType == typeof(string)))
                {
                    hasStringParameterMethods.Add(item.Method);
                }

                if (item.Method.GetParameters().Any(x => x.ParameterType == typeof(object)))
                {
                    hasObjectParameterMethods.Add(item.Method);
                }

                if (item.Method.GetParameters().Any(x => x.ParameterType.HasAttribute<ComInterfaceAttribute>()))
                {
                    hasRawComInterfaceParameterMethods.Add(item.Method);
                }

                if (item.Method.GetParameters().Any(x => x.ParameterType.IsGenericType) && !_genericTypeParameterWhiteList.Contains(item.Method.Name))
                {
                    hasGenericTypeParameterMethods.Add(item.Method);
                }
            }

            var fails = new List<string>();

            fails.AddRange(wrongEntrypoints.Select(item => $"{item.Method.DeclaringType!.Name} {item.Method.Name} entrypoint error."));
            fails.AddRange(missingAPIDataMethods.Select(item => $"{item.DeclaringType!.Name} {item.Name} missing in api data."));
            fails.AddRange(wrongWindowsVersionRequirementMethods.Select(item => $"{item.Method.DeclaringType!.Name} {item.Method.Name} windows version requirement should be {item.Item2.Version} {item.Item2.Note} BuildNumber: {item.Item2.BuildNumber}."));
            fails.AddRange(missingWindowsVersionRequirementMethods.Select(item => $"{item.DeclaringType!.Name} {item.Name} missing windows version requirement."));
            fails.AddRange(hasMarshalAsAttributeMethods.Select(item => $"{item.DeclaringType!.Name} {item.Name} has marshalas attribute."));
            fails.AddRange(hasStringParameterMethods.Select(item => $"{item.DeclaringType!.Name} {item.Name} has string parameter."));
            fails.AddRange(hasObjectParameterMethods.Select(item => $"{item.DeclaringType!.Name} {item.Name} has object parameter."));
            fails.AddRange(hasRawComInterfaceParameterMethods.Select(item => $"{item.DeclaringType!.Name} {item.Name} has raw COM interface parameter."));
            fails.AddRange(hasGenericTypeParameterMethods.Select(item => $"{item.DeclaringType!.Name} {item.Name} has generic type parameter."));
            fails.AddRange(toCheckApis.Select(item => $"{item} missing in methods."));

            if (fails.Any())
            {
                Assert.Fail(Environment.NewLine + string.Join(Environment.NewLine, fails));
            }
        }

        [TestMethod]
        public void TestBlittableStructs()
        {
            var structs = typeof(Lsj.Util.Win32.Kernel32).Assembly.GetTypes().Where(x => x.IsValueType && !x.IsEnum);
            var wrongLayoutStructs = new List<Type>();
            var wrongFieldsStructs = new List<(Type type, List<FieldInfo> fields)>();
            foreach (var @struct in structs)
            {
                if (!@struct.IsLayoutSequential && !@struct.IsExplicitLayout)
                {
                    wrongLayoutStructs.Add(@struct);
                }

                var fields = @struct.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
                var wrongFields = fields.Where(x => (!x.FieldType.IsValueType && !x.FieldType.IsPointer) || x.FieldType.IsArray || x.GetCustomAttribute<MarshalAsAttribute>() != null);
                if (wrongFields.Any())
                {
                    wrongFieldsStructs.Add((@struct, wrongFields.ToList()));
                }
            }

            if (wrongLayoutStructs.Any())
            {
                Assert.Fail(Environment.NewLine + string.Concat(wrongLayoutStructs.Select(item => $"{item.Name} layout wrong" + Environment.NewLine)));
            }

            if (wrongFieldsStructs.Any())
            {
                Assert.Fail(Environment.NewLine + string.Concat(wrongFieldsStructs.Select(item => $"{item.type.Name} has wrong fields: {string.Join(" ", item.fields.Select(x => x.Name))}" + Environment.NewLine)));
            }
        }

        [TestMethod]
        public void TestComInterfaces()
        {
            var iids = typeof(IIDs).GetFields();
            var interfaces = typeof(IUnknown).Assembly.GetTypes().Where(x => x.IsValueType && !x.IsEnum);

            var wrongIIDInterfaces = new List<Type>();
            var missingIIDInterfaces = new List<Type>();
            var wrongBeginVTableSlotIndexInterfaces = new List<Type>();

            var cache = new Dictionary<Type, ComInterfaceAttribute?>();

            foreach (var interfaceType in interfaces)
            {
                ComInterfaceAttribute? attribute = null;
                if (!cache.ContainsKey(interfaceType))
                {
                    attribute = interfaceType.GetCustomAttribute<ComInterfaceAttribute>();
                    cache[interfaceType] = attribute;
                }
                else
                {
                    attribute = cache[interfaceType];
                }
                if (attribute != null)
                {
                    var iidField = iids.SingleOrDefault(x => x.Name == $"IID_{interfaceType.Name}");
                    if (iidField == null)
                    {
                        missingIIDInterfaces.Add(interfaceType);
                        continue;
                    }

                    if (!iidField.GetValue(null)!.ToString()!.Equals(attribute.IID, StringComparison.OrdinalIgnoreCase))
                    {
                        wrongIIDInterfaces.Add(interfaceType);
                    }

                    if (attribute.InheritedFromTypes.LastOrDefault() is Type parentType)
                    {
                        ComInterfaceAttribute parentAttribute = null!;
                        if (!cache.ContainsKey(parentType))
                        {
                            parentAttribute = parentType.GetCustomAttribute<ComInterfaceAttribute>()!;
                            cache[parentType] = parentAttribute;
                        }
                        else
                        {
                            parentAttribute = cache[parentType]!;
                        }
                        if (attribute.BeginVTableSlotIndex != parentAttribute.EndVTableSlotIndex + 1)
                        {
                            wrongBeginVTableSlotIndexInterfaces.Add(interfaceType);
                        }
                    }
                }
            }


            var fails = new List<string>();

            fails.AddRange(missingIIDInterfaces.Select(item => $"{item.Name} missing IID in IIDs"));
            fails.AddRange(wrongIIDInterfaces.Select(item => $"{item.Name} has wrong IID"));
            fails.AddRange(wrongBeginVTableSlotIndexInterfaces.Select(item => $"{item.Name} has wrong BeginVTableSlotIndex"));

            if (fails.Any())
            {
                Assert.Fail(Environment.NewLine + string.Join(Environment.NewLine, fails));
            }
        }

        private Dictionary<string, (WindowsVersion Version, int BuildNumber, string? Note, string DllName)> ReadFromFiles()
        {
            var result = new Dictionary<string, (WindowsVersion version, int buildNumber, string? note, string dllName)>();
            var dataDir = GetDataDir();
            var apiDir = Path.Combine(dataDir, "apis");
            foreach (var file in new DirectoryInfo(Path.Combine(apiDir, "NT40")).EnumerateFiles())
            {
                var lines = File.ReadAllLines(file.FullName);
                foreach (var line in lines)
                {
                    if (!result.ContainsKey(line))
                    {
                        result[line] = (WindowsVersion.WindowsNT40, BuildNumbers.WindowsNT4_0, null, Path.GetFileNameWithoutExtension(file.Name));
                    }
                }
            }

            foreach (var file in new DirectoryInfo(Path.Combine(apiDir, "2000")).EnumerateFiles())
            {
                var lines = File.ReadAllLines(file.FullName);
                foreach (var line in lines)
                {
                    if (!result.ContainsKey(line))
                    {
                        result[line] = (WindowsVersion.Windows2000, BuildNumbers.Windows2000, null, Path.GetFileNameWithoutExtension(file.Name));
                    }
                }
            }

            foreach (var file in new DirectoryInfo(Path.Combine(apiDir, "XP")).EnumerateFiles())
            {
                var lines = File.ReadAllLines(file.FullName);
                foreach (var line in lines)
                {
                    if (!result.ContainsKey(line))
                    {
                        result[line] = (WindowsVersion.WindowsXP, BuildNumbers.WindowsXP, null, Path.GetFileNameWithoutExtension(file.Name));
                    }
                }
            }

            foreach (var file in new DirectoryInfo(Path.Combine(apiDir, "XPSP1")).EnumerateFiles())
            {
                var lines = File.ReadAllLines(file.FullName);
                foreach (var line in lines)
                {
                    if (!result.ContainsKey(line))
                    {
                        result[line] = (WindowsVersion.WindowsXP, BuildNumbers.WindowsXP, "SP1", Path.GetFileNameWithoutExtension(file.Name));
                    }
                }
            }

            foreach (var file in new DirectoryInfo(Path.Combine(apiDir, "XPSP2")).EnumerateFiles())
            {
                var lines = File.ReadAllLines(file.FullName);
                foreach (var line in lines)
                {
                    if (!result.ContainsKey(line))
                    {
                        result[line] = (WindowsVersion.WindowsXP, BuildNumbers.WindowsXP, "SP2", Path.GetFileNameWithoutExtension(file.Name));
                    }
                }
            }

            foreach (var file in new DirectoryInfo(Path.Combine(apiDir, "XPSP3")).EnumerateFiles())
            {
                var lines = File.ReadAllLines(file.FullName);
                foreach (var line in lines)
                {
                    if (!result.ContainsKey(line))
                    {
                        result[line] = (WindowsVersion.WindowsXP, BuildNumbers.WindowsXP, "SP3", Path.GetFileNameWithoutExtension(file.Name));
                    }
                }
            }

            foreach (var file in new DirectoryInfo(Path.Combine(apiDir, "XPKB959426")).EnumerateFiles())
            {
                var lines = File.ReadAllLines(file.FullName);
                foreach (var line in lines)
                {
                    if (!result.ContainsKey(line))
                    {
                        result[line] = (WindowsVersion.WindowsXP, BuildNumbers.WindowsXP, "KB959426", Path.GetFileNameWithoutExtension(file.Name));
                    }
                }
            }

            foreach (var file in new DirectoryInfo(Path.Combine(apiDir, "Vista")).EnumerateFiles())
            {
                var lines = File.ReadAllLines(file.FullName);
                foreach (var line in lines)
                {
                    if (!result.ContainsKey(line))
                    {
                        result[line] = (WindowsVersion.WindowsVista, BuildNumbers.WindowsVista, null, Path.GetFileNameWithoutExtension(file.Name));
                    }
                }
            }

            foreach (var file in new DirectoryInfo(Path.Combine(apiDir, "VistaSP1")).EnumerateFiles())
            {
                var lines = File.ReadAllLines(file.FullName);
                foreach (var line in lines)
                {
                    if (!result.ContainsKey(line))
                    {
                        result[line] = (WindowsVersion.WindowsVista, BuildNumbers.WindowsVistaSP1, null, Path.GetFileNameWithoutExtension(file.Name));
                    }
                }
            }

            foreach (var file in new DirectoryInfo(Path.Combine(apiDir, "VistaSP1KB2533623")).EnumerateFiles())
            {
                var lines = File.ReadAllLines(file.FullName);
                foreach (var line in lines)
                {
                    if (!result.ContainsKey(line))
                    {
                        result[line] = (WindowsVersion.WindowsVista, BuildNumbers.WindowsVistaSP1, "KB2533623", Path.GetFileNameWithoutExtension(file.Name));
                    }
                }
            }

            foreach (var file in new DirectoryInfo(Path.Combine(apiDir, "VistaPlatformUpdateSupplement")).EnumerateFiles())
            {
                var lines = File.ReadAllLines(file.FullName);
                foreach (var line in lines)
                {
                    if (!result.ContainsKey(line))
                    {
                        result[line] = (WindowsVersion.WindowsVista, BuildNumbers.WindowsVistaSP2, "Platform Update Supplement", Path.GetFileNameWithoutExtension(file.Name));
                    }
                }
            }

            foreach (var file in new DirectoryInfo(Path.Combine(apiDir, "7")).EnumerateFiles())
            {
                var lines = File.ReadAllLines(file.FullName);
                foreach (var line in lines)
                {
                    if (!result.ContainsKey(line))
                    {
                        result[line] = (WindowsVersion.Windows7, BuildNumbers.Windows7, null, Path.GetFileNameWithoutExtension(file.Name));
                    }
                }
            }

            foreach (var file in new DirectoryInfo(Path.Combine(apiDir, "8")).EnumerateFiles())
            {
                var lines = File.ReadAllLines(file.FullName);
                foreach (var line in lines)
                {
                    if (!result.ContainsKey(line))
                    {
                        result[line] = (WindowsVersion.Windows8, BuildNumbers.Windows8, null, Path.GetFileNameWithoutExtension(file.Name));
                    }
                }
            }

            foreach (var file in new DirectoryInfo(Path.Combine(apiDir, "8.1")).EnumerateFiles())
            {
                var lines = File.ReadAllLines(file.FullName);
                foreach (var line in lines)
                {
                    if (!result.ContainsKey(line))
                    {
                        result[line] = (WindowsVersion.Windows8_1, BuildNumbers.Windows8_1, null, Path.GetFileNameWithoutExtension(file.Name));
                    }
                }
            }

            foreach (var file in new DirectoryInfo(Path.Combine(apiDir, "10")).EnumerateFiles())
            {
                var lines = File.ReadAllLines(file.FullName);
                foreach (var line in lines)
                {
                    if (!result.ContainsKey(line))
                    {
                        result[line] = (WindowsVersion.Windows10, BuildNumbers.Windows10_1507, null, Path.GetFileNameWithoutExtension(file.Name));
                    }
                }
            }

            foreach (var file in new DirectoryInfo(Path.Combine(apiDir, "10_1511")).EnumerateFiles())
            {
                var lines = File.ReadAllLines(file.FullName);
                foreach (var line in lines)
                {
                    if (!result.ContainsKey(line))
                    {
                        result[line] = (WindowsVersion.Windows10, BuildNumbers.Windows10_1511, null, Path.GetFileNameWithoutExtension(file.Name));
                    }
                }
            }

            foreach (var file in new DirectoryInfo(Path.Combine(apiDir, "10_1607")).EnumerateFiles())
            {
                var lines = File.ReadAllLines(file.FullName);
                foreach (var line in lines)
                {
                    if (!result.ContainsKey(line))
                    {
                        result[line] = (WindowsVersion.Windows10, BuildNumbers.Windows10_1607, null, Path.GetFileNameWithoutExtension(file.Name));
                    }
                }
            }

            foreach (var file in new DirectoryInfo(Path.Combine(apiDir, "10_1703")).EnumerateFiles())
            {
                var lines = File.ReadAllLines(file.FullName);
                foreach (var line in lines)
                {
                    if (!result.ContainsKey(line))
                    {
                        result[line] = (WindowsVersion.Windows10, BuildNumbers.Windows10_1703, null, Path.GetFileNameWithoutExtension(file.Name));
                    }
                }
            }

            foreach (var file in new DirectoryInfo(Path.Combine(apiDir, "10_1709")).EnumerateFiles())
            {
                var lines = File.ReadAllLines(file.FullName);
                foreach (var line in lines)
                {
                    if (!result.ContainsKey(line))
                    {
                        result[line] = (WindowsVersion.Windows10, BuildNumbers.Windows10_1709, null, Path.GetFileNameWithoutExtension(file.Name));
                    }
                }
            }

            foreach (var file in new DirectoryInfo(Path.Combine(apiDir, "10_1803")).EnumerateFiles())
            {
                var lines = File.ReadAllLines(file.FullName);
                foreach (var line in lines)
                {
                    if (!result.ContainsKey(line))
                    {
                        result[line] = (WindowsVersion.Windows10, BuildNumbers.Windows10_1803, null, Path.GetFileNameWithoutExtension(file.Name));
                    }
                }
            }

            foreach (var file in new DirectoryInfo(Path.Combine(apiDir, "10_1809")).EnumerateFiles())
            {
                var lines = File.ReadAllLines(file.FullName);
                foreach (var line in lines)
                {
                    if (!result.ContainsKey(line))
                    {
                        result[line] = (WindowsVersion.Windows10, BuildNumbers.Windows10_1809, null, Path.GetFileNameWithoutExtension(file.Name));
                    }
                }
            }

            foreach (var file in new DirectoryInfo(Path.Combine(apiDir, "10_1903")).EnumerateFiles())
            {
                var lines = File.ReadAllLines(file.FullName);
                foreach (var line in lines)
                {
                    if (!result.ContainsKey(line))
                    {
                        result[line] = (WindowsVersion.Windows10, BuildNumbers.Windows10_1903, null, Path.GetFileNameWithoutExtension(file.Name));
                    }
                }
            }

            foreach (var file in new DirectoryInfo(Path.Combine(apiDir, "10_21H1")).EnumerateFiles())
            {
                var lines = File.ReadAllLines(file.FullName);
                foreach (var line in lines)
                {
                    if (!result.ContainsKey(line))
                    {
                        result[line] = (WindowsVersion.Windows10, BuildNumbers.Windows10_21H1, null, Path.GetFileNameWithoutExtension(file.Name));
                    }
                }
            }

            foreach (var file in new DirectoryInfo(Path.Combine(apiDir, "10_21H2")).EnumerateFiles())
            {
                var lines = File.ReadAllLines(file.FullName);
                foreach (var line in lines)
                {
                    if (!result.ContainsKey(line))
                    {
                        result[line] = (WindowsVersion.Windows10, BuildNumbers.Windows10_21H2, null, Path.GetFileNameWithoutExtension(file.Name));
                    }
                }
            }

            foreach (var file in new DirectoryInfo(Path.Combine(apiDir, "10_22H2")).EnumerateFiles())
            {
                var lines = File.ReadAllLines(file.FullName);
                foreach (var line in lines)
                {
                    if (!result.ContainsKey(line))
                    {
                        result[line] = (WindowsVersion.Windows10, BuildNumbers.Windows10_22H2, null, Path.GetFileNameWithoutExtension(file.Name));
                    }
                }
            }

            foreach (var file in new DirectoryInfo(Path.Combine(apiDir, "11")).EnumerateFiles())
            {
                var lines = File.ReadAllLines(file.FullName);
                foreach (var line in lines)
                {
                    if (!result.ContainsKey(line))
                    {
                        result[line] = (WindowsVersion.Windows11, BuildNumbers.Windows11_21H2, null, Path.GetFileNameWithoutExtension(file.Name));
                    }
                }
            }

            foreach (var file in new DirectoryInfo(Path.Combine(apiDir, "11_22H2")).EnumerateFiles())
            {
                var lines = File.ReadAllLines(file.FullName);
                foreach (var line in lines)
                {
                    if (!result.ContainsKey(line))
                    {
                        result[line] = (WindowsVersion.Windows11, BuildNumbers.Windows11_22H2, null, Path.GetFileNameWithoutExtension(file.Name));
                    }
                }
            }

            foreach (var file in new DirectoryInfo(Path.Combine(apiDir, "11_23H2")).EnumerateFiles())
            {
                var lines = File.ReadAllLines(file.FullName);
                foreach (var line in lines)
                {
                    if (!result.ContainsKey(line))
                    {
                        result[line] = (WindowsVersion.Windows11, BuildNumbers.Windows11_23H2, null, Path.GetFileNameWithoutExtension(file.Name));
                    }
                }
            }

            return result;
        }

        private static string GetDataDir()
        {
            return new DirectoryInfo(Path.Combine(typeof(DefineTests).Assembly.Location, "..", "..", "..", "..", "..", "Data")).FullName;
        }
    }
}
