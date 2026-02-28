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

        private static readonly List<string> _skipApiList = new List<string>
        {
            // NT 4.0
            "AddFontResourceTracking",                          // undocument
            "BaseAttachCompleteThunk",                          // undocument
            "bInitSystemAndFontsDirectoriesW",                  // undocument
            "bMakePathNameW",                                   // undocument
            "BroadcastSystemMessage",                           // duplicate of BroadcastSystemMessageW
            "BuildAccessRequestW",                              // undocument
            "CallMsgFilter",                                    // undocument
            "CascadeChildWindows",                              // undocument
            "cGetTTFFromFOT",                                   // undocument
            "ClientThreadSetup",                                // undocument
            "CloseConsoleHandle",                               // undocument
            "CloseProfileUserMapping",                          // undocument
            "CmdBatNotification",                               // undocument
            "ConsoleMenuControl",                               // undocument
            "CreateDialogIndirectParamAorW",                    // undocument
            "CreateVirtualBuffer",                              // undocument
            "DenyAccessRightsW",                                // undocument
            "DeviceCapabilitiesExW",                            // undocument
            "DialogBoxIndirectParamAorW",                       // undocument
            "DrawCaptionTempW",                                 // undocument
            "DrawFrame",                                        // undocument
            "DrawMenuBarTemp",                                  // undocument
            "DuplicateConsoleHandle",                           // undocument
            "EditWndProc",                                      // undocument
            "ElfBackupEventLogFileW",                           // undocument
            "ElfChangeNotify",                                  // undocument
            "ElfClearEventLogFileW",                            // undocument
            "ElfCloseEventLog",                                 // undocument
            "ElfDeregisterEventSource",                         // undocument
            "ElfNumberOfRecords",                               // undocument
            "ElfOldestRecord",                                  // undocument
            "ElfOpenBackupEventLogW",                           // undocument
            "ElfOpenEventLogW",                                 // undocument
            "ElfReadEventLogW",                                 // undocument
            "ElfRegisterEventSourceW",                          // undocument
            "ElfReportEventW",                                  // undocument
            "EnumServiceGroupW",                                // undocument
            "ExitVDM",                                          // undocument
            "ExpungeConsoleCommandHistoryW",                    // undocument
            "ExtendVirtualBuffer",                              // undocument
            "FreeVirtualBuffer",                                // undocument
            "FullScreenControl",                                // undocument
            "GdiAddFontResourceW",                              // undocument
            "GdiAddGlsBounds",                                  // undocument
            "GdiAddGlsRecord",                                  // undocument
            "GdiCleanCacheDC",                                  // undocument
            "GdiConsoleTextOut",                                // undocument
            "GdiConvertAndCheckDC",                             // undocument
            "GdiConvertBitmap",                                 // undocument
            "GdiConvertBrush",                                  // undocument
            "GdiConvertDC",                                     // undocument
            "GdiConvertEnhMetaFile",                            // undocument
            "GdiConvertFont",                                   // undocument
            "GdiConvertMetaFilePict",                           // undocument
            "GdiConvertPalette",                                // undocument
            "GdiConvertRegion",                                 // undocument
            "GdiConvertToDevmodeW",                             // undocument
            "GdiCreateLocalEnhMetaFile",                        // undocument
            "GdiCreateLocalMetaFilePict",                       // undocument
            "GdiDeleteLocalDC",                                 // undocument
            "GdiDescribePixelFormat",                           // undocument
            "GdiDllInitialize",                                 // undocument
            "GdiEntry1",                                        // undocument
            "GdiEntry2",                                        // undocument
            "GdiEntry3",                                        // undocument
            "GdiEntry4",                                        // undocument
            "GdiEntry5",                                        // undocument
            "GdiEntry6",                                        // undocument
            "GdiEntry7",                                        // undocument
            "GdiEntry8",                                        // undocument
            "GdiEntry9",                                        // undocument
            "GdiEntry10",                                       // undocument
            "GdiEntry11",                                       // undocument
            "GdiEntry12",                                       // undocument
            "GdiEntry13",                                       // undocument
            "GdiEntry14",                                       // undocument
            "GdiEntry15",                                       // undocument
            "GdiFixUpHandle",                                   // undocument
            "GdiGetCharDimensions",                             // undocument
            "GdiGetCodePage",                                   // undocument
            "GdiGetLocalBrush",                                 // undocument
            "GdiGetLocalDC",                                    // undocument
            "GdiGetLocalFont",                                  // undocument
            "GdiGetSpoolMessage",                               // undocument
            "GdiInitSpool",                                     // undocument
            "GdiIsMetaFileDC",                                  // undocument
            "GdiIsMetaPrintDC",                                 // undocument
            "GdiPerf",                                          // undocument
            "GdiPlayDCScript",                                  // undocument
            "GdiPlayEMF",                                       // undocument
            "GdiPlayJournal",                                   // undocument
            "GdiPlayScript",                                    // undocument
            "GdiProcessSetup",                                  // undocument
            "gdiPlaySpoolStream",                               // undocument
            "GdiQueryFonts",                                    // undocument
            "GdiQueryTable",                                    // undocument
            "GdiReleaseLocalDC",                                // undocument
            "GdiSetAttrs",                                      // undocument
            "GdiSetPixelFormat",                                // undocument
            "GdiSetServerAttr",                                 // undocument
            "GdiSwapBuffers",                                   // undocument
            "GdiValidateHandle",                                // undocument
            "GetAuditedPermissionsFromSDW",                     // undocument
            "GetAppCompatFlags",                                // undocument
            "GetBinaryType",                                    // duplicate of GetBinaryTypeW
            "GetCharWidthInfo",                                 // undocument
            "GetConsoleCommandHistoryLengthW",                  // undocument
            "GetConsoleCommandHistoryW",                        // undocument
            "GetConsoleFontInfo",                               // undocument
            "GetConsoleHardwareState",                          // undocument
            "GetConsoleInputExeNameW",                          // undocument
            "GetConsoleInputWaitHandle",                        // undocument
            "GetConsoleKeyboardLayoutNameW",                    // undocument
            "GetEffectiveAccessRightsW",                        // undocument
            "GetEffectiveRightsFromSDW",                        // undocument
            "GetEnvironmentStrings",                            // duplicate of GetEnvironmentStringsW
            "GetExplicitAccessRightsW",                         // undocument
            "GetETM",                                           // undocument
            "GetFontResourceInfoW",                             // undocument
            "GetGlyphOutline",                                  // duplicate of GetGlyphOutlineW
            "GetGlyphOutlineWow",                               // undocument
            "GetHFONT",                                         // undocument
            "GetInputDesktop",                                  // undocument
            "GetInternalWindowPos",                             // undocument
            "GetKerningPairs",                                  // duplicate of GetKerningPairsW
            "GetLastError",                                     // use Marshal.GetLastError
            "GetNextVDMCommand",                                // undocument
            "GetNumberOfConsoleFonts",                          // undocument
            "GetProgmanWindow",                                 // undocument
            "GetRelAbs",                                        // undocument
            "GetTaskmanWindow",                                 // undocument
            "GetTransform",                                     // undocument
            "GetVDMCurrentDirectories",                         // undocument
            "GrantAccessRightsW",                               // undocument
            "HeapCreateTagsW",                                  // undocument
            "HeapExtend",                                       // undocument
            "HeapQueryTagW",                                    // undocument
            "HeapUsage",                                        // undocument
            "I_ScGetCurrentGroupStateW",                        // undocument
            "I_ScSetServiceBitsW",                              // undocument
            "InvalidateConsoleDIBits",                          // undocument
            "IsAccessPermittedW",                               // undocument
            "IsDialogMessage",                                  // duplicate of IsDialogMessageW
            "KillSystemTimer",                                  // undocument
            "LoadKeyboardLayoutEx",                             // undocument
            "LoadLocalFonts",                                   // undocument
            "LoadRemoteFonts",                                  // undocument
            "LockWindowStation",                                // undocument
            "LsaAddPrivilegesToAccount",                        // undocument
            "LsaClearAuditLog",                                 // undocument
            "LsaCreateAccount",                                 // undocument
            "LsaCreateSecret",                                  // undocument
            "LsaDelete",                                        // undocument
            "LsaEnumerateAccounts",                             // undocument
            "LsaEnumeratePrivileges",                           // undocument
            "LsaEnumeratePrivilegesOfAccount",                  // undocument
            "LsaGetQuotasForAccount",                           // undocument
            "LsaGetSystemAccessAccount",                        // undocument
            "LsaGetUserName",                                   // undocument
            "LsaICLookupNames",                                 // undocument
            "LsaICLookupSids",                                  // undocument
            "LsaLookupPrivilegeDisplayName",                    // undocument
            "LsaLookupPrivilegeName",                           // undocument
            "LsaLookupPrivilegeValue",                          // undocument
            "LsaOpenAccount",                                   // undocument
            "LsaOpenSecret",                                    // undocument
            "LsaOpenTrustedDomain",                             // undocument
            "LsaQueryInfoTrustedDomain",                        // undocument
            "LsaQuerySecret",                                   // undocument
            "LsaQuerySecurityObject",                           // undocument
            "LsaRemovePrivilegesFromAccount",                   // undocument
            "LsaSetInformationTrustedDomain",                   // undocument
            "LsaSetQuotasForAccount",                           // undocument
            "LsaSetSecret",                                     // undocument
            "LsaSetSecurityObject",                             // undocument
            "LsaSetSystemAccessAccount",                        // undocument
            "NTAccessMaskToProvAccessRights",                   // undocument
            "MBToWCSEx",                                        // undocument
            "MenuWindowProcW",                                  // undocument
            "NamedEscape",                                      // undocument
            "OpenConsoleW",                                     // undocument
            "OpenProfileUserMapping",                           // undocument
            "PrivateExtractIconExW",                            // undocument
            "PrivateKDBreakPoint",                              // undocument
            "ProvAccessRightsToNTAccessMask",                   // undocument
            "PolyPatBlt",                                       // undocument
            "QuerySendMessage",                                 // undocument
            "QueryWindows31FilesMigration",                     // undocument
            "QueryWin31IniFilesMappedToRegistry",               // undocument
            "RegisterConsoleVDM",                               // undocument
            "RegisterLogonProcess",                             // undocument
            "RegisterServicesProcess",                          // undocument
            "RegisterSystemThread",                             // undocument
            "RegisterTasklist",                                 // undocument
            "RegisterWaitForInputIdle",                         // undocument
            "RegisterWowBaseHandlers",                          // undocument
            "RegisterWowExec",                                  // undocument
            "RemoveFontResourceTracking",                       // undocument
            "ReplaceAllAccessRightsW",                          // undocument
            "RevokeExplicitAccessRightsW",                      // undocument
            "ScrollChildren",                                   // undocument
            "SelectBrushLocal",                                 // undocument
            "SelectFontLocal",                                  // undocument
            "SetAccessRightsW",                                 // undocument
            "SetConsoleCommandHistoryMode",                     // undocument
            "SetConsoleCursor",                                 // undocument
            "SetConsoleFont",                                   // undocument
            "SetConsoleHardwareState",                          // undocument
            "SetConsoleIcon",                                   // undocument
            "SetConsoleInputExeNameW",                          // undocument
            "SetConsoleKeyShortcuts",                           // undocument
            "SetConsoleMaximumWindowSize",                      // undocument
            "SetConsoleMenuClose",                              // undocument
            "SetConsoleNumberOfCommandsW",                      // undocument
            "SetConsolePalette",                                // undocument
            "SetConsoleReserveKeys",                            // undocument
            "SetCursorContents",                                // undocument
            "SetDeskWallpaper",                                 // undocument
            "SetFontEnumeration",                               // undocument
            "SetInternalWindowPos",                             // undocument
            "SetLastConsoleEventActive",                        // undocument
            "SetLogonNotifyWindow",                             // undocument
            "SetMagicColors",                                   // undocument
            "SetProgmanWindow",                                 // undocument
            "SetRelAbs",                                        // undocument
            "SetShellWindow",                                   // undocument
            "SetShellWindowEx",                                 // undocument
            "SetSysColorsTemp",                                 // undocument
            "SetSystemMenu",                                    // undocument
            "SetSystemTimer",                                   // undocument
            "SetTaskmanWindow",                                 // undocument
            "SetVDMCurrentDirectories",                         // undocument
            "SetVirtualResolution",                             // undocument
            "SetWindowStationUser",                             // undocument
            "ShowConsoleCursor",                                // undocument
            "ShowStartGlass",                                   // undocument
            "SoftModalMessageBox",                              // undocument
            "SynchronizeWindows31FilesAndWindowsNTRegistry",    // undocument
            "SystemFunction001",                                // undocument
            "SystemFunction002",                                // undocument
            "SystemFunction003",                                // undocument
            "SystemFunction004",                                // undocument
            "SystemFunction005",                                // undocument
            "SystemFunction006",                                // undocument
            "SystemFunction007",                                // undocument
            "SystemFunction008",                                // undocument
            "SystemFunction009",                                // undocument
            "SystemFunction010",                                // undocument
            "SystemFunction011",                                // undocument
            "SystemFunction012",                                // undocument
            "SystemFunction013",                                // undocument
            "SystemFunction014",                                // undocument
            "SystemFunction015",                                // undocument
            "SystemFunction016",                                // undocument
            "SystemFunction017",                                // undocument
            "SystemFunction018",                                // undocument
            "SystemFunction019",                                // undocument
            "SystemFunction020",                                // undocument
            "SystemFunction021",                                // undocument
            "SystemFunction022",                                // undocument
            "SystemFunction023",                                // undocument
            "SystemFunction024",                                // undocument
            "SystemFunction025",                                // undocument
            "SystemFunction026",                                // undocument
            "SystemFunction027",                                // undocument
            "SystemFunction028",                                // undocument
            "SystemFunction029",                                // undocument
            "SystemFunction030",                                // undocument
            "SystemFunction031",                                // undocument
            "SystemFunction032",                                // undocument
            "SystemFunction033",                                // undocument
            "TileChildWindows",                                 // undocument
            "TranslateAccelerator",                             // duplicate of TranslateAcceleratorW
            "TranslateMessageEx",                               // undocument
            "TrimVirtualBuffer",                                // undocument
            "UnloadNetworkFonts",                               // undocument
            "UnlockWindowStation",                              // undocument
            "UpdateICMRegKey",                                  // duplicate of UpdateICMRegKeyW
            "UpdatePerUserSystemParameters",                    // undocument
            "UserClientDllInitialize",                          // undocument
            "UserRealizePalette",                               // undocument
            "UserRegisterWowHandlers",                          // undocument
            "VDMConsoleOperation",                              // undocument
            "VDMOperationStarted",                              // undocument
            "VerifyConsoleIoHandle",                            // undocument
            "VirtualBufferExceptionHandler",                    // undocument
            "WCSToMBEx",                                        // undocument
            "WriteConsoleInputVDMW",                            // undocument
            "lstrcat",                                          // duplicate of lstrcatW
            "lstrcmp",                                          // duplicate of lstrcmpW
            "lstrcmpi",                                         // duplicate of lstrcmpiW
            "lstrcpy",                                          // duplicate of lstrcpyW
            "lstrcpyn",                                         // duplicate of lstrcpynW
            "lstrlen",                                          // duplicate of lstrlenW
            
            // 2000
            "AlignRects",                                       // undocument
            "AnyLinkedFonts",                                   // undocument
            "BRUSHOBJ_hGetColorTransform",                      // DDI
            "BRUSHOBJ_pvAllocRbrush",                           // DDI
            "BRUSHOBJ_pvGetRbrush",                             // DDI
            "BRUSHOBJ_ulGetBrushColor",                         // DDI
            "CancelOverlappedAccess",                           // undocument
            "CLIPOBJ_bEnum",                                    // DDI
            "CLIPOBJ_cEnumStart",                               // DDI
            "CLIPOBJ_ppoGetPath",                               // DDI
            "CliImmSetHotKey",                                  // undocument
            "CommandLineFromMsiDescriptor",                     // undocument
            "ConvertAccessToSecurityDescriptorW",               // undocument
            "ConvertSDToStringSDRootDomainW",                   // undocument
            "ConvertSecurityDescriptorToAccessNamedW",          // undocument
            "ConvertSecurityDescriptorToAccessW",               // undocument
            "ConvertStringSDToSDRootDomainW",                   // undocument
            "CtxInitUser32",                                    // undocument
            "DelayLoadFailureHook",                             // not api
            "DeviceEventWorker",                                // undocument
            "DosPathToSessionPathW",                            // undocument
            "EndFormPage",                                      // undocument
            "EngAcquireSemaphore",                              // DDI
            "EngAlphaBlend",                                    // DDI
            "EngAssociateSurface",                              // DDI
            "EngBitBlt",                                        // DDI
            "EngCheckAbort",                                    // DDI
            "EngComputeGlyphSet",                               // DDI
            "EngCopyBits",                                      // DDI
            "EngCreateBitmap",                                  // DDI
            "EngCreateClip",                                    // DDI
            "EngCreateDeviceBitmap",                            // DDI
            "EngCreateDeviceSurface",                           // DDI
            "EngCreatePalette",                                 // DDI
            "EngCreateSemaphore",                               // DDI
            "EngDeleteClip",                                    // DDI
            "EngDeletePalette",                                 // DDI
            "EngDeletePath",                                    // DDI
            "EngDeleteSemaphore",                               // DDI
            "EngDeleteSurface",                                 // DDI
            "EngEraseSurface",                                  // DDI
            "EngFillPath",                                      // DDI
            "EngFindResource",                                  // DDI
            "EngFreeModule",                                    // DDI
            "EngGetCurrentCodePage",                            // DDI
            "EngGetDriverName",                                 // DDI
            "EngGetPrinterDataFileName",                        // DDI
            "EngGradientFill",                                  // DDI
            "EngLineTo",                                        // DDI
            "EngLoadModule",                                    // DDI
            "EngLockSurface",                                   // DDI
            "EngMarkBandingSurface",                            // DDI
            "EngMultiByteToUnicodeN",                           // DDI
            "EngMultiByteToWideChar",                           // DDI
            "EngPaint",                                         // DDI
            "EngPlgBlt",                                        // DDI
            "EngQueryEMFInfo",                                  // DDI
            "EngQueryLocalTime",                                // DDI
            "EngReleaseSemaphore",                              // DDI
            "EngStretchBlt",                                    // DDI
            "EngStretchBltROP",                                 // DDI
            "EngStrokeAndFillPath",                             // DDI
            "EngStrokePath",                                    // DDI
            "EngTextOut",                                       // DDI
            "EngTransparentBlt",                                // DDI
            "EngUnicodeToMultiByteN",                           // DDI
            "EngUnlockSurface",                                 // DDI
            "EngWideCharToMultiByte",                           // DDI
            "EudcLoadLinkW",                                    // undocument
            "EudcUnloadLinkW",                                  // undocument
            "FONTOBJ_cGetAllGlyphHandles",                      // DDI
            "FONTOBJ_cGetGlyphs",                               // DDI
            "FONTOBJ_pQueryGlyphAttrs",                         // DDI
            "FONTOBJ_pfdg",                                     // DDI
            "FONTOBJ_pifi",                                     // DDI
            "FONTOBJ_pvTrueTypeFontFile",                       // DDI
            "FONTOBJ_pxoGetXform",                              // DDI
            "FONTOBJ_vGetInfo",                                 // DDI
            "FontIsLinked",                                     // undocument
            "GdiArtificialDecrementDriver",                     // undocument
            "GdiConvertBitmapV5",                               // undocument
            "GdiEntry16",                                       // undocument
            "GdiFullscreenControl",                             // undocument
            "GdiInitializeLanguagePack",                        // undocument
            "GdiIsPlayMetafileDC",                              // undocument
            "GdiPlayPrivatePageEMF",                            // undocument
            "GdiPrinterThunk",                                  // undocument
            "GdiRealizationInfo",                               // undocument
            "GdiReleaseDC",                                     // undocument
            "GdiSetLastError",                                  // undocument
            "GetAccessPermissionsForObjectW",                   // undocument
            "GetAltTabInfo",                                    // duplicate of GetAltTabInfoW
            "GetAppCompatFlags2",                               // undocument
            "GetConsoleCharType",                               // undocument
            "GetConsoleCursorMode",                             // undocument
            "GetConsoleNlsMode",                                // undocument
            "GetCursorFrameInfo",                               // undocument 
            "GetDefaultSortkeySize",                            // undocument
            "GetEUDCTimeStamp",                                 // undocument
            "GetEUDCTimeStampExW",                              // undocument
            "GetFontAssocStatus",                               // undocument
            "GetLinguistLangSize",                              // undocument
            "GetMangledSiteSid",                                // undocument
            "GetNamedSecurityInfoExW",                          // undocument
            "GetNlsSectionName",                                // undocument
            "GetOverlappedAccessResults",                       // undocument
            "GetSecurityInfoExW",                               // undocument
            "GetSiteDirectoryW",                                // undocument
            "GetSiteNameFromSid",                               // undocument
            "GetSiteSidFromToken",                              // undocument
            "GetSiteSidFromUrl",                                // undocument
            "GetStringBitmapW",                                 // undocument
            "GetTextExtentExPointWPri",                         // undocument
            "GetTextFaceAliasW",                                // undocument
            "GetWinStationInfo",                                // undocument
            "GetWindowModuleFileName",                          // duplicate of GetWindowModuleFileNameW
            "HT_Get8BPPFormatPalette",                          // DDI
            "HT_Get8BPPMaskPalette",                            // DDI
            "I_ScIsSecurityProcess",                            // undocument
            "I_ScPnPGetServiceName",                            // undocument
            "InitializeLpkHooks",                               // undocument
            "InitializeWin32EntryTable",                        // undocument
            "IsInSandbox",                                      // undocument
            "IsProcessRestricted",                              // undocument
            "LsaGetRemoteUserName",                             // undocument
            "MakeAbsoluteSD2",                                  // undocument
            "MirrorRgn",                                        // undocument
            "Module32First",                                    // duplicate of Module32FirstW
            "Module32Next",                                     // duplicate of Module32NextW
            "NlsConvertIntegerToString",                        // undocument
            "NlsGetCacheUpdateCount",                           // undocument
            "NlsResetProcessLocale",                            // undocument
            "OpenDataFile",                                     // undocument
            "PATHOBJ_bEnum",                                    // DDI
            "PATHOBJ_bEnumClipLines",                           // DDI
            "PATHOBJ_vEnumStart",                               // DDI
            "PATHOBJ_vEnumStartClipLines",                      // DDI
            "PATHOBJ_vGetBounds",                               // DDI
            "PrivCopyFileExW",                                  // undocument
            "PrivateSetDbgTag",                                 // undocument
            "PrivateSetRipFlags",                               // undocument
            "PrivMoveFileIdentityW",                            // undocument
            "Process32First",                                   // duplicate of Process32FirstW
            "Process32Next",                                    // duplicate of Process32NextW
            "QueryUserCounters",                                // undocument
            "QueryFontAssocStatus",                             // undocument
            "RealGetWindowClass",                               // duplicate of RealGetWindowClassW
            "RegisterConsoleIME",                               // undocument
            "RegisterConsoleOS2",                               // undocument
            "RegisterWaitForSingleObjectEx",                    // undocument
            "ReplaceFile",                                      // duplicate of ReplaceFileW
            "RequestDeviceWakeup",                              // undocument
            "RequestWakeupLatency",                             // undocument
            "ResolveDesktopForWOW",                             // undocument
            "SetCPGlobal",                                      // undocument
            "SetConsoleCursorMode",                             // undocument
            "SetConsoleLocalEUDC",                              // undocument
            "SetConsoleNlsMode",                                // undocument
            "SetConsoleOS2OemFormat",                           // undocument
            "SetEntriesInAccessListW",                          // undocument
            "SetEntriesInAuditListW",                           // undocument
            "SetLayoutWidth",                                   // undocument
            "SetMessageWaitingIndicator",                       // undocument
            "SetNamedSecurityInfoExW",                          // undocument
            "SetSecurityInfoExW",                               // undocument
            "SetTermsrvAppInstallMode",                         // undocument
            "SetTimerQueueTimer",                               // undocument
            "StartFormPage",                                    // undocument
            "STROBJ_bEnum",                                     // DDI
            "STROBJ_bEnumPositionsOnly",                        // DDI
            "STROBJ_bGetAdvanceWidths",                         // DDI
            "STROBJ_dwGetCodePage",                             // DDI
            "STROBJ_vEnumStart",                                // DDI
            "SystemFunction034",                                // undocument
            "SystemFunction035",                                // undocument
            "TermsrvAppInstallMode",                            // undocument
            "TrusteeAccessToObjectW",                           // undocument
            "User32InitializeImmEntryTable",                    // undocument
            "UserLpkPSMTextOut",                                // undocument
            "UserLpkTabbedTextOut",                             // undocument
            "UTRegister",                                       // undocument
            "UTUnRegister",                                     // undocument
            "UnregisterConsoleIME",                             // undocument
            "ValidateLCType",                                   // undocument
            "ValidateLocale",                                   // undocument
            "VRipOutput",                                       // undocument
            "VTagOutput",                                       // undocument
            "Win32PoolAllocationStats",                         // undocument
            "WmiCloseBlock",                                    // undocument
            "WmiDevInstToInstanceNameW",                        // undocument
            "WmiEnumerateGuids",                                // undocument
            "WmiExecuteMethodW",                                // undocument
            "WmiFileHandleToInstanceNameW",                     // undocument
            "WmiFreeBuffer",                                    // undocument
            "WmiMofEnumerateResourcesW",                        // undocument
            "WmiNotificationRegistrationW",                     // undocument
            "WmiOpenBlock",                                     // undocument
            "WmiQueryAllDataW",                                 // undocument
            "WmiQueryGuidInformation",                          // undocument
            "WmiQuerySingleInstanceW",                          // undocument
            "WmiSetSingleInstanceW",                            // undocument
            "WmiSetSingleItemW",                                // undocument
            "XFORMOBJ_bApplyXform",                             // DDI
            "XFORMOBJ_iGetXform",                               // DDI
            "XLATEOBJ_cGetPalette",                             // DDI
            "XLATEOBJ_hGetColorTransform",                      // DDI
            "XLATEOBJ_iXlate",                                  // DDI
            "XLATEOBJ_piVector",                                // DDI

            // XP
            "AllowForegroundActivation",                        // undocument
            "BaseCheckAppcompatCache",                          // undocument
            "BaseCleanupAppcompatCache",                        // undocument
            "BaseCleanupAppcompatCacheSupport",                 // undocument
            "BaseDumpAppcompatCache",                           // undocument
            "BaseFlushAppcompatCache",                          // undocument
            "BaseInitAppcompatCache",                           // undocument
            "BaseInitAppcompatCacheSupport",                    // undocument
            "BasepCheckWinSaferRestrictions",                   // undocument
            "BaseProcessInitPostImport",                        // undocument
            "BaseQueryModuleData",                              // undocument
            "BaseUpdateAppcompatCache",                         // undocument
            "BuildReasonArray",                                 // undocument
            "CalcMenuBar",                                      // undocument
            "CreateJobSet",                                     // undocument
            "CreateNlsSecurityDescriptor",                      // undocument
            "CreateProcessInternalW",                           // undocument
            "CreateProcessInternalWSecure",                     // undocument
            "CreateSocketHandle",                               // undocument
            "CreateSystemThreads",                              // undocument
            "CsrBroadcastSystemMessageExW",                     // undocument
            "DestroyReasons",                                   // undocument
            "DisplayExitWindowsWarnings",                       // undocument
            "EnumerateLocalComputerNamesW",                     // undocument
            "GetCPFileNameFromRegistry",                        // undocument
            "GetHandleContext",                                 // undocument
            "GetNumaAvailableMemory",                           // undocument
            "GetNumaProcessorMap",                              // undocument
            "GetReasonTitleFromReasonCode",                     // undocument
            "IsServerSideWindow",                               // undocument
            "IsValidUILanguage",                                // undocument
            "IsWindowInDestroy",                                // undocument
            "LZCloseFile",                                      // undocument
            "LZCreateFileW",                                    // undocument
            "MessageBoxTimeoutW",                               // undocument
            "NumaVirtualQueryNode",                             // undocument
            "RemoveLocalAlternateComputerNameW",                // undocument
            "RestoreLastError",                                 // undocument
            "PaintMenuBar",                                     // undocument
            "ReasonCodeNeedsBugID",                             // undocument
            "ReasonCodeNeedsComment",                           // undocument
            "RecordShutdownReason",                             // undocument
            "RegisterMessagePumpHook",                          // undocument
            "RegisterUserApiHook",                              // undocument
            "SetClientTimeZoneInformation",                     // undocument
            "SetComPlusPackageInstallStatus",                   // undocument
            "SetHandleContext",                                 // undocument
            "SetLocalPrimaryComputerNameW",                     // undocument
            "UnregisterMessagePumpHook",                        // undocument
            "UnregisterUserApiHook",                            // undocument
        };

        [TestMethod]
        public void TestMethods()
        {
            var apis = ReadFromFiles();
            var toCheckApis = apis.Where(x =>
                (x.Value.DllName == "user32" && x.Value.Version <= WindowsVersion.WindowsXP) ||
                (x.Value.DllName == "kernel32" && x.Value.Version <= WindowsVersion.WindowsXP) ||
                (x.Value.DllName == "advapi32" && x.Value.Version <= WindowsVersion.Windows2000) ||
                (x.Value.DllName == "gdi32" && x.Value.Version <= WindowsVersion.Windows2000))
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
