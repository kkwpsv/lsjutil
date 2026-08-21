using System.Collections.Generic;

namespace Lsj.Util.Tests.Win32
{
    public partial class DefineTests
    {
        private static readonly List<(string Api, string DllName)> _skipApiList = new List<(string Api, string DllName)>
        {
            // NT 4.0
            ("BuildAccessRequestW", "advapi32"),                                // undocument
            ("DenyAccessRightsW", "advapi32"),                                  // undocument
            ("ElfBackupEventLogFileW", "advapi32"),                             // undocument
            ("ElfChangeNotify", "advapi32"),                                    // undocument
            ("ElfClearEventLogFileW", "advapi32"),                              // undocument
            ("ElfCloseEventLog", "advapi32"),                                   // undocument
            ("ElfDeregisterEventSource", "advapi32"),                           // undocument
            ("ElfNumberOfRecords", "advapi32"),                                 // undocument
            ("ElfOldestRecord", "advapi32"),                                    // undocument
            ("ElfOpenBackupEventLogW", "advapi32"),                             // undocument
            ("ElfOpenEventLogW", "advapi32"),                                   // undocument
            ("ElfReadEventLogW", "advapi32"),                                   // undocument
            ("ElfRegisterEventSourceW", "advapi32"),                            // undocument
            ("ElfReportEventW", "advapi32"),                                    // undocument
            ("EnumServiceGroupW", "advapi32"),                                  // undocument
            ("GetAuditedPermissionsFromSDW", "advapi32"),                       // undocument
            ("GetEffectiveAccessRightsW", "advapi32"),                          // undocument
            ("GetEffectiveRightsFromSDW", "advapi32"),                          // undocument
            ("GetExplicitAccessRightsW", "advapi32"),                           // undocument
            ("GrantAccessRightsW", "advapi32"),                                 // undocument
            ("I_ScGetCurrentGroupStateW", "advapi32"),                          // undocument
            ("I_ScSetServiceBitsW", "advapi32"),                                // undocument
            ("IsAccessPermittedW", "advapi32"),                                 // undocument
            ("LsaAddPrivilegesToAccount", "advapi32"),                          // undocument
            ("LsaClearAuditLog", "advapi32"),                                   // undocument
            ("LsaCreateAccount", "advapi32"),                                   // undocument
            ("LsaCreateSecret", "advapi32"),                                    // undocument
            ("LsaDelete", "advapi32"),                                          // undocument
            ("LsaEnumerateAccounts", "advapi32"),                               // undocument
            ("LsaEnumeratePrivileges", "advapi32"),                             // undocument
            ("LsaEnumeratePrivilegesOfAccount", "advapi32"),                    // undocument
            ("LsaGetQuotasForAccount", "advapi32"),                             // undocument
            ("LsaGetSystemAccessAccount", "advapi32"),                          // undocument
            ("LsaGetUserName", "advapi32"),                                     // undocument
            ("LsaICLookupNames", "advapi32"),                                   // undocument
            ("LsaICLookupSids", "advapi32"),                                    // undocument
            ("LsaLookupPrivilegeDisplayName", "advapi32"),                      // undocument
            ("LsaLookupPrivilegeName", "advapi32"),                             // undocument
            ("LsaLookupPrivilegeValue", "advapi32"),                            // undocument
            ("LsaOpenAccount", "advapi32"),                                     // undocument
            ("LsaOpenSecret", "advapi32"),                                      // undocument
            ("LsaOpenTrustedDomain", "advapi32"),                               // undocument
            ("LsaQueryInfoTrustedDomain", "advapi32"),                          // undocument
            ("LsaQuerySecret", "advapi32"),                                     // undocument
            ("LsaQuerySecurityObject", "advapi32"),                             // undocument
            ("LsaRemovePrivilegesFromAccount", "advapi32"),                     // undocument
            ("LsaSetInformationTrustedDomain", "advapi32"),                     // undocument
            ("LsaSetQuotasForAccount", "advapi32"),                             // undocument
            ("LsaSetSecret", "advapi32"),                                       // undocument
            ("LsaSetSecurityObject", "advapi32"),                               // undocument
            ("LsaSetSystemAccessAccount", "advapi32"),                          // undocument
            ("NTAccessMaskToProvAccessRights", "advapi32"),                     // undocument
            ("ProvAccessRightsToNTAccessMask", "advapi32"),                     // undocument
            ("QueryWindows31FilesMigration", "advapi32"),                       // undocument
            ("ReplaceAllAccessRightsW", "advapi32"),                            // undocument
            ("RevokeExplicitAccessRightsW", "advapi32"),                        // undocument
            ("SetAccessRightsW", "advapi32"),                                   // undocument
            ("SynchronizeWindows31FilesAndWindowsNTRegistry", "advapi32"),      // undocument
            ("SystemFunction001", "advapi32"),                                  // undocument
            ("SystemFunction002", "advapi32"),                                  // undocument
            ("SystemFunction003", "advapi32"),                                  // undocument
            ("SystemFunction004", "advapi32"),                                  // undocument
            ("SystemFunction005", "advapi32"),                                  // undocument
            ("SystemFunction006", "advapi32"),                                  // undocument
            ("SystemFunction007", "advapi32"),                                  // undocument
            ("SystemFunction008", "advapi32"),                                  // undocument
            ("SystemFunction009", "advapi32"),                                  // undocument
            ("SystemFunction010", "advapi32"),                                  // undocument
            ("SystemFunction011", "advapi32"),                                  // undocument
            ("SystemFunction012", "advapi32"),                                  // undocument
            ("SystemFunction013", "advapi32"),                                  // undocument
            ("SystemFunction014", "advapi32"),                                  // undocument
            ("SystemFunction015", "advapi32"),                                  // undocument
            ("SystemFunction016", "advapi32"),                                  // undocument
            ("SystemFunction017", "advapi32"),                                  // undocument
            ("SystemFunction018", "advapi32"),                                  // undocument
            ("SystemFunction019", "advapi32"),                                  // undocument
            ("SystemFunction020", "advapi32"),                                  // undocument
            ("SystemFunction021", "advapi32"),                                  // undocument
            ("SystemFunction022", "advapi32"),                                  // undocument
            ("SystemFunction023", "advapi32"),                                  // undocument
            ("SystemFunction024", "advapi32"),                                  // undocument
            ("SystemFunction025", "advapi32"),                                  // undocument
            ("SystemFunction026", "advapi32"),                                  // undocument
            ("SystemFunction027", "advapi32"),                                  // undocument
            ("SystemFunction028", "advapi32"),                                  // undocument
            ("SystemFunction029", "advapi32"),                                  // undocument
            ("SystemFunction030", "advapi32"),                                  // undocument
            ("SystemFunction031", "advapi32"),                                  // undocument
            ("SystemFunction032", "advapi32"),                                  // undocument
            ("SystemFunction033", "advapi32"),                                  // undocument
            ("AddFontResourceTracking", "gdi32"),                               // undocument
            ("bInitSystemAndFontsDirectoriesW", "gdi32"),                       // undocument
            ("bMakePathNameW", "gdi32"),                                        // undocument
            ("cGetTTFFromFOT", "gdi32"),                                        // undocument
            ("DeviceCapabilitiesExW", "gdi32"),                                 // undocument
            ("GdiAddFontResourceW", "gdi32"),                                   // undocument
            ("GdiAddGlsBounds", "gdi32"),                                       // undocument
            ("GdiAddGlsRecord", "gdi32"),                                       // undocument
            ("GdiCleanCacheDC", "gdi32"),                                       // undocument
            ("GdiConsoleTextOut", "gdi32"),                                     // undocument
            ("GdiConvertAndCheckDC", "gdi32"),                                  // undocument
            ("GdiConvertBitmap", "gdi32"),                                      // undocument
            ("GdiConvertBrush", "gdi32"),                                       // undocument
            ("GdiConvertDC", "gdi32"),                                          // undocument
            ("GdiConvertEnhMetaFile", "gdi32"),                                 // undocument
            ("GdiConvertFont", "gdi32"),                                        // undocument
            ("GdiConvertMetaFilePict", "gdi32"),                                // undocument
            ("GdiConvertPalette", "gdi32"),                                     // undocument
            ("GdiConvertRegion", "gdi32"),                                      // undocument
            ("GdiConvertToDevmodeW", "gdi32"),                                  // undocument
            ("GdiCreateLocalEnhMetaFile", "gdi32"),                             // undocument
            ("GdiCreateLocalMetaFilePict", "gdi32"),                            // undocument
            ("GdiDeleteLocalDC", "gdi32"),                                      // undocument
            ("GdiDescribePixelFormat", "gdi32"),                                // undocument
            ("GdiDllInitialize", "gdi32"),                                      // undocument
            ("GdiEntry1", "gdi32"),                                             // undocument
            ("GdiEntry10", "gdi32"),                                            // undocument
            ("GdiEntry11", "gdi32"),                                            // undocument
            ("GdiEntry12", "gdi32"),                                            // undocument
            ("GdiEntry13", "gdi32"),                                            // undocument
            ("GdiEntry14", "gdi32"),                                            // undocument
            ("GdiEntry15", "gdi32"),                                            // undocument
            ("GdiEntry2", "gdi32"),                                             // undocument
            ("GdiEntry3", "gdi32"),                                             // undocument
            ("GdiEntry4", "gdi32"),                                             // undocument
            ("GdiEntry5", "gdi32"),                                             // undocument
            ("GdiEntry6", "gdi32"),                                             // undocument
            ("GdiEntry7", "gdi32"),                                             // undocument
            ("GdiEntry8", "gdi32"),                                             // undocument
            ("GdiEntry9", "gdi32"),                                             // undocument
            ("GdiFixUpHandle", "gdi32"),                                        // undocument
            ("GdiGetCharDimensions", "gdi32"),                                  // undocument
            ("GdiGetCodePage", "gdi32"),                                        // undocument
            ("GdiGetLocalBrush", "gdi32"),                                      // undocument
            ("GdiGetLocalDC", "gdi32"),                                         // undocument
            ("GdiGetLocalFont", "gdi32"),                                       // undocument
            ("GdiGetSpoolMessage", "gdi32"),                                    // undocument
            ("GdiInitSpool", "gdi32"),                                          // undocument
            ("GdiIsMetaFileDC", "gdi32"),                                       // undocument
            ("GdiIsMetaPrintDC", "gdi32"),                                      // undocument
            ("GdiPerf", "gdi32"),                                               // undocument
            ("GdiPlayDCScript", "gdi32"),                                       // undocument
            ("GdiPlayEMF", "gdi32"),                                            // undocument
            ("GdiPlayJournal", "gdi32"),                                        // undocument
            ("GdiPlayScript", "gdi32"),                                         // undocument
            ("gdiPlaySpoolStream", "gdi32"),                                    // undocument
            ("GdiProcessSetup", "gdi32"),                                       // undocument
            ("GdiQueryFonts", "gdi32"),                                         // undocument
            ("GdiQueryTable", "gdi32"),                                         // undocument
            ("GdiReleaseLocalDC", "gdi32"),                                     // undocument
            ("GdiSetAttrs", "gdi32"),                                           // undocument
            ("GdiSetPixelFormat", "gdi32"),                                     // undocument
            ("GdiSetServerAttr", "gdi32"),                                      // undocument
            ("GdiSwapBuffers", "gdi32"),                                        // undocument
            ("GdiValidateHandle", "gdi32"),                                     // undocument
            ("GetCharWidthInfo", "gdi32"),                                      // undocument
            ("GetETM", "gdi32"),                                                // undocument
            ("GetFontResourceInfoW", "gdi32"),                                  // undocument
            ("GetGlyphOutline", "gdi32"),                                       // duplicate of GetGlyphOutlineW
            ("GetGlyphOutlineWow", "gdi32"),                                    // undocument
            ("GetHFONT", "gdi32"),                                              // undocument
            ("GetKerningPairs", "gdi32"),                                       // duplicate of GetKerningPairsW
            ("GetRelAbs", "gdi32"),                                             // undocument
            ("GetTransform", "gdi32"),                                          // undocument
            ("NamedEscape", "gdi32"),                                           // undocument
            ("PolyPatBlt", "gdi32"),                                            // undocument
            ("RemoveFontResourceTracking", "gdi32"),                            // undocument
            ("SelectBrushLocal", "gdi32"),                                      // undocument
            ("SelectFontLocal", "gdi32"),                                       // undocument
            ("SetFontEnumeration", "gdi32"),                                    // undocument
            ("SetMagicColors", "gdi32"),                                        // undocument
            ("SetRelAbs", "gdi32"),                                             // undocument
            ("SetVirtualResolution", "gdi32"),                                  // undocument
            ("UnloadNetworkFonts", "gdi32"),                                    // undocument
            ("UpdateICMRegKey", "gdi32"),                                       // duplicate of UpdateICMRegKeyW
            ("BaseAttachCompleteThunk", "kernel32"),                            // undocument
            ("CloseConsoleHandle", "kernel32"),                                 // undocument
            ("CloseProfileUserMapping", "kernel32"),                            // undocument
            ("CmdBatNotification", "kernel32"),                                 // undocument
            ("ConsoleMenuControl", "kernel32"),                                 // undocument
            ("CreateVirtualBuffer", "kernel32"),                                // undocument
            ("DuplicateConsoleHandle", "kernel32"),                             // undocument
            ("ExitVDM", "kernel32"),                                            // undocument
            ("ExpungeConsoleCommandHistoryW", "kernel32"),                      // undocument
            ("ExtendVirtualBuffer", "kernel32"),                                // undocument
            ("FreeVirtualBuffer", "kernel32"),                                  // undocument
            ("GetBinaryType", "kernel32"),                                      // duplicate of GetBinaryTypeW
            ("GetConsoleCommandHistoryLengthW", "kernel32"),                    // undocument
            ("GetConsoleCommandHistoryW", "kernel32"),                          // undocument
            ("GetConsoleFontInfo", "kernel32"),                                 // undocument
            ("GetConsoleHardwareState", "kernel32"),                            // undocument
            ("GetConsoleInputExeNameW", "kernel32"),                            // undocument
            ("GetConsoleInputWaitHandle", "kernel32"),                          // undocument
            ("GetConsoleKeyboardLayoutNameW", "kernel32"),                      // undocument
            ("GetEnvironmentStrings", "kernel32"),                              // duplicate of GetEnvironmentStringsW
            ("GetLastError", "kernel32"),                                       // use Marshal.GetLastError
            ("GetNextVDMCommand", "kernel32"),                                  // undocument
            ("GetNumberOfConsoleFonts", "kernel32"),                            // undocument
            ("GetVDMCurrentDirectories", "kernel32"),                           // undocument
            ("HeapCreateTagsW", "kernel32"),                                    // undocument
            ("HeapExtend", "kernel32"),                                         // undocument
            ("HeapQueryTagW", "kernel32"),                                      // undocument
            ("HeapUsage", "kernel32"),                                          // undocument
            ("InvalidateConsoleDIBits", "kernel32"),                            // undocument
            ("lstrcat", "kernel32"),                                            // duplicate of lstrcatW
            ("lstrcmp", "kernel32"),                                            // duplicate of lstrcmpW
            ("lstrcmpi", "kernel32"),                                           // duplicate of lstrcmpiW
            ("lstrcpy", "kernel32"),                                            // duplicate of lstrcpyW
            ("lstrcpyn", "kernel32"),                                           // duplicate of lstrcpynW
            ("lstrlen", "kernel32"),                                            // duplicate of lstrlenW
            ("OpenConsoleW", "kernel32"),                                       // undocument
            ("OpenProfileUserMapping", "kernel32"),                             // undocument
            ("QueryWin31IniFilesMappedToRegistry", "kernel32"),                 // undocument
            ("RegisterConsoleVDM", "kernel32"),                                 // undocument
            ("RegisterWaitForInputIdle", "kernel32"),                           // undocument
            ("RegisterWowBaseHandlers", "kernel32"),                            // undocument
            ("RegisterWowExec", "kernel32"),                                    // undocument
            ("SetConsoleCommandHistoryMode", "kernel32"),                       // undocument
            ("SetConsoleCursor", "kernel32"),                                   // undocument
            ("SetConsoleFont", "kernel32"),                                     // undocument
            ("SetConsoleHardwareState", "kernel32"),                            // undocument
            ("SetConsoleIcon", "kernel32"),                                     // undocument
            ("SetConsoleInputExeNameW", "kernel32"),                            // undocument
            ("SetConsoleKeyShortcuts", "kernel32"),                             // undocument
            ("SetConsoleMaximumWindowSize", "kernel32"),                        // undocument
            ("SetConsoleMenuClose", "kernel32"),                                // undocument
            ("SetConsoleNumberOfCommandsW", "kernel32"),                        // undocument
            ("SetConsolePalette", "kernel32"),                                  // undocument
            ("SetLastConsoleEventActive", "kernel32"),                          // undocument
            ("SetVDMCurrentDirectories", "kernel32"),                           // undocument
            ("ShowConsoleCursor", "kernel32"),                                  // undocument
            ("TrimVirtualBuffer", "kernel32"),                                  // undocument
            ("VDMConsoleOperation", "kernel32"),                                // undocument
            ("VDMOperationStarted", "kernel32"),                                // undocument
            ("VerifyConsoleIoHandle", "kernel32"),                              // undocument
            ("VirtualBufferExceptionHandler", "kernel32"),                      // undocument
            ("WriteConsoleInputVDMW", "kernel32"),                              // undocument
            ("CheckEscapesW", "shell32"),                                       // undocument
            ("Control_FillCache_RunDLL", "shell32"),                            // undocument
            ("Control_FillCache_RunDLLW", "shell32"),                           // undocument
            ("Control_RunDLL", "shell32"),                                      // undocument
            ("Control_RunDLLW", "shell32"),                                     // undocument
            ("DllGetClassObject","shell32"),                                    // not api
            ("DragQueryFile", "shell32"),                                       // duplicate of DragQueryFileW
            ("DragQueryFileAorW", "shell32"),                                   // undocument
            ("ExtractIconEx", "shell32"),                                       // duplicate of ExtractIconExW
            ("ExtractIconResInfoW", "shell32"),                                 // undocument
            ("ExtractVersionResource16W", "shell32"),                           // undocument
            ("FindExeDlgProc", "shell32"),                                      // undocument
            ("FreeIconList", "shell32"),                                        // undocument
            ("InternalExtractIconListW", "shell32"),                            // undocument
            ("OpenAs_RunDLL", "shell32"),                                       // undocument
            ("OpenAs_RunDLLW", "shell32"),                                      // undocument
            ("PrintersGetCommand_RunDLL", "shell32"),                           // undocument
            ("PrintersGetCommand_RunDLLW", "shell32"),                          // undocument
            ("RealShellExecuteExW", "shell32"),                                 // undocument
            ("RealShellExecuteW", "shell32"),                                   // undocument
            ("RegenerateUserEnvironment", "shell32"),                           // undocument
            ("SHBrowseForFolder", "shell32"),                                   // duplicate of SHBrowseForFolderW
            ("SheChangeDirExW", "shell32"),                                     // undocument
            ("SheChangeDirW", "shell32"),                                       // undocument
            ("SheConvertPathW", "shell32"),                                     // undocument
            ("SheFullPathW", "shell32"),                                        // undocument
            ("SheGetCurDrive", "shell32"),                                      // undocument
            ("SheGetDirExW", "shell32"),                                        // undocument
            ("SheGetDirW", "shell32"),                                          // undocument
            ("SheGetPathOffsetW", "shell32"),                                   // undocument
            ("Shell_NotifyIcon", "shell32"),                                    // duplicate of Shell_NotifyIconW
            ("ShellExecuteEx", "shell32"),                                      // duplicate of ShellExecuteExW
            ("ShellHookProc", "shell32"),                                       // undocument
            ("SheRemoveQuotesW", "shell32"),                                    // undocument
            ("SheSetCurDrive", "shell32"),                                      // undocument
            ("SheShortenPathW", "shell32"),                                     // undocument
            ("SHFileOperation", "shell32"),                                     // duplicate of SHFileOperationW
            ("SHGetFileInfo", "shell32"),                                       // duplicate of SHGetFileInfoW
            ("SHGetNewLinkInfo", "shell32"),                                    // duplicate of SHGetNewLinkInfoW
            ("SHGetPathFromIDList", "shell32"),                                 // duplicate of SHGetPathFromIDListW
            ("SHHelpShortcuts_RunDLL", "shell32"),                              // undocument
            ("SHHelpShortcuts_RunDLLW", "shell32"),                             // undocument
            ("SHUpdateRecycleBinIcon", "shell32"),                              // undocument
            ("StrChrIW", "shell32"),                                            // undocument
            ("StrChrW", "shell32"),                                             // undocument
            ("StrCmpNIW", "shell32"),                                           // undocument
            ("StrCmpNW", "shell32"),                                            // undocument
            ("StrCpyNW", "shell32"),                                            // undocument
            ("StrNCmpIW", "shell32"),                                           // undocument
            ("StrNCmpW", "shell32"),                                            // undocument
            ("StrNCpyW", "shell32"),                                            // undocument
            ("StrRChrIW", "shell32"),                                           // undocument
            ("StrRChrW", "shell32"),                                            // undocument
            ("StrRStrIW", "shell32"),                                           // undocument
            ("StrRStrW", "shell32"),                                            // undocument
            ("StrStrIW", "shell32"),                                            // undocument
            ("StrStrW", "shell32"),                                             // undocument
            ("BroadcastSystemMessage", "user32"),                               // duplicate of BroadcastSystemMessageW
            ("CallMsgFilter", "user32"),                                        // undocument
            ("CascadeChildWindows", "user32"),                                  // undocument
            ("ClientThreadSetup", "user32"),                                    // undocument
            ("CreateDialogIndirectParamAorW", "user32"),                        // undocument
            ("DialogBoxIndirectParamAorW", "user32"),                           // undocument
            ("DrawCaptionTempW", "user32"),                                     // undocument
            ("DrawFrame", "user32"),                                            // undocument
            ("DrawMenuBarTemp", "user32"),                                      // undocument
            ("EditWndProc", "user32"),                                          // undocument
            ("FullScreenControl", "user32"),                                    // undocument
            ("GetAppCompatFlags", "user32"),                                    // undocument
            ("GetInputDesktop", "user32"),                                      // undocument
            ("GetInternalWindowPos", "user32"),                                 // undocument
            ("GetProgmanWindow", "user32"),                                     // undocument
            ("GetTaskmanWindow", "user32"),                                     // undocument
            ("IsDialogMessage", "user32"),                                      // duplicate of IsDialogMessageW
            ("KillSystemTimer", "user32"),                                      // undocument
            ("LoadKeyboardLayoutEx", "user32"),                                 // undocument
            ("LoadLocalFonts", "user32"),                                       // undocument
            ("LoadRemoteFonts", "user32"),                                      // undocument
            ("LockWindowStation", "user32"),                                    // undocument
            ("MBToWCSEx", "user32"),                                            // undocument
            ("MenuWindowProcW", "user32"),                                      // undocument
            ("PrivateExtractIconExW", "user32"),                                // undocument
            ("PrivateKDBreakPoint", "user32"),                                  // undocument
            ("QuerySendMessage", "user32"),                                     // undocument
            ("RegisterLogonProcess", "user32"),                                 // undocument
            ("RegisterServicesProcess", "user32"),                              // undocument
            ("RegisterSystemThread", "user32"),                                 // undocument
            ("RegisterTasklist", "user32"),                                     // undocument
            ("ScrollChildren", "user32"),                                       // undocument
            ("SetConsoleReserveKeys", "user32"),                                // undocument
            ("SetCursorContents", "user32"),                                    // undocument
            ("SetDeskWallpaper", "user32"),                                     // undocument
            ("SetInternalWindowPos", "user32"),                                 // undocument
            ("SetLogonNotifyWindow", "user32"),                                 // undocument
            ("SetProgmanWindow", "user32"),                                     // undocument
            ("SetShellWindow", "user32"),                                       // undocument
            ("SetShellWindowEx", "user32"),                                     // undocument
            ("SetSysColorsTemp", "user32"),                                     // undocument
            ("SetSystemMenu", "user32"),                                        // undocument
            ("SetSystemTimer", "user32"),                                       // undocument
            ("SetTaskmanWindow", "user32"),                                     // undocument
            ("SetWindowStationUser", "user32"),                                 // undocument
            ("ShowStartGlass", "user32"),                                       // undocument
            ("SoftModalMessageBox", "user32"),                                  // undocument
            ("TileChildWindows", "user32"),                                     // undocument
            ("TranslateAccelerator", "user32"),                                 // duplicate of TranslateAcceleratorW
            ("TranslateMessageEx", "user32"),                                   // undocument
            ("UnlockWindowStation", "user32"),                                  // undocument
            ("UpdatePerUserSystemParameters", "user32"),                        // undocument
            ("UserClientDllInitialize", "user32"),                              // undocument
            ("UserRealizePalette", "user32"),                                   // undocument
            ("UserRegisterWowHandlers", "user32"),                              // undocument
            ("WCSToMBEx", "user32"),                                            // undocument

            // 2000
            ("CancelOverlappedAccess", "advapi32"),                             // undocument
            ("CommandLineFromMsiDescriptor", "advapi32"),                       // undocument
            ("ConvertAccessToSecurityDescriptorW", "advapi32"),                 // undocument
            ("ConvertSDToStringSDRootDomainW", "advapi32"),                     // undocument
            ("ConvertSecurityDescriptorToAccessNamedW", "advapi32"),            // undocument
            ("ConvertSecurityDescriptorToAccessW", "advapi32"),                 // undocument
            ("ConvertStringSDToSDRootDomainW", "advapi32"),                     // undocument
            ("GetAccessPermissionsForObjectW", "advapi32"),                     // undocument
            ("GetMangledSiteSid", "advapi32"),                                  // undocument
            ("GetNamedSecurityInfoExW", "advapi32"),                            // undocument
            ("GetOverlappedAccessResults", "advapi32"),                         // undocument
            ("GetSecurityInfoExW", "advapi32"),                                 // undocument
            ("GetSiteDirectoryW", "advapi32"),                                  // undocument
            ("GetSiteNameFromSid", "advapi32"),                                 // undocument
            ("GetSiteSidFromToken", "advapi32"),                                // undocument
            ("GetSiteSidFromUrl", "advapi32"),                                  // undocument
            ("I_ScIsSecurityProcess", "advapi32"),                              // undocument
            ("I_ScPnPGetServiceName", "advapi32"),                              // undocument
            ("IsInSandbox", "advapi32"),                                        // undocument
            ("IsProcessRestricted", "advapi32"),                                // undocument
            ("LsaGetRemoteUserName", "advapi32"),                               // undocument
            ("MakeAbsoluteSD2", "advapi32"),                                    // undocument
            ("SetEntriesInAccessListW", "advapi32"),                            // undocument
            ("SetEntriesInAuditListW", "advapi32"),                             // undocument
            ("SetNamedSecurityInfoExW", "advapi32"),                            // undocument
            ("SetSecurityInfoExW", "advapi32"),                                 // undocument
            ("SystemFunction034", "advapi32"),                                  // undocument
            ("SystemFunction035", "advapi32"),                                  // undocument
            ("TrusteeAccessToObjectW", "advapi32"),                             // undocument
            ("WmiCloseBlock", "advapi32"),                                      // undocument
            ("WmiDevInstToInstanceNameW", "advapi32"),                          // undocument
            ("WmiEnumerateGuids", "advapi32"),                                  // undocument
            ("WmiExecuteMethodW", "advapi32"),                                  // undocument
            ("WmiFileHandleToInstanceNameW", "advapi32"),                       // undocument
            ("WmiFreeBuffer", "advapi32"),                                      // undocument
            ("WmiMofEnumerateResourcesW", "advapi32"),                          // undocument
            ("WmiNotificationRegistrationW", "advapi32"),                       // undocument
            ("WmiOpenBlock", "advapi32"),                                       // undocument
            ("WmiQueryAllDataW", "advapi32"),                                   // undocument
            ("WmiQueryGuidInformation", "advapi32"),                            // undocument
            ("WmiQuerySingleInstanceW", "advapi32"),                            // undocument
            ("WmiSetSingleInstanceW", "advapi32"),                              // undocument
            ("WmiSetSingleItemW", "advapi32"),                                  // undocument
            ("AnyLinkedFonts", "gdi32"),                                        // undocument
            ("BRUSHOBJ_hGetColorTransform", "gdi32"),                           // DDI
            ("BRUSHOBJ_pvAllocRbrush", "gdi32"),                                // DDI
            ("BRUSHOBJ_pvGetRbrush", "gdi32"),                                  // DDI
            ("BRUSHOBJ_ulGetBrushColor", "gdi32"),                              // DDI
            ("CLIPOBJ_bEnum", "gdi32"),                                         // DDI
            ("CLIPOBJ_cEnumStart", "gdi32"),                                    // DDI
            ("CLIPOBJ_ppoGetPath", "gdi32"),                                    // DDI
            ("EndFormPage", "gdi32"),                                           // undocument
            ("EngAcquireSemaphore", "gdi32"),                                   // DDI
            ("EngAlphaBlend", "gdi32"),                                         // DDI
            ("EngAssociateSurface", "gdi32"),                                   // DDI
            ("EngBitBlt", "gdi32"),                                             // DDI
            ("EngCheckAbort", "gdi32"),                                         // DDI
            ("EngComputeGlyphSet", "gdi32"),                                    // DDI
            ("EngCopyBits", "gdi32"),                                           // DDI
            ("EngCreateBitmap", "gdi32"),                                       // DDI
            ("EngCreateClip", "gdi32"),                                         // DDI
            ("EngCreateDeviceBitmap", "gdi32"),                                 // DDI
            ("EngCreateDeviceSurface", "gdi32"),                                // DDI
            ("EngCreatePalette", "gdi32"),                                      // DDI
            ("EngCreateSemaphore", "gdi32"),                                    // DDI
            ("EngDeleteClip", "gdi32"),                                         // DDI
            ("EngDeletePalette", "gdi32"),                                      // DDI
            ("EngDeletePath", "gdi32"),                                         // DDI
            ("EngDeleteSemaphore", "gdi32"),                                    // DDI
            ("EngDeleteSurface", "gdi32"),                                      // DDI
            ("EngEraseSurface", "gdi32"),                                       // DDI
            ("EngFillPath", "gdi32"),                                           // DDI
            ("EngFindResource", "gdi32"),                                       // DDI
            ("EngFreeModule", "gdi32"),                                         // DDI
            ("EngGetCurrentCodePage", "gdi32"),                                 // DDI
            ("EngGetDriverName", "gdi32"),                                      // DDI
            ("EngGetPrinterDataFileName", "gdi32"),                             // DDI
            ("EngGradientFill", "gdi32"),                                       // DDI
            ("EngLineTo", "gdi32"),                                             // DDI
            ("EngLoadModule", "gdi32"),                                         // DDI
            ("EngLockSurface", "gdi32"),                                        // DDI
            ("EngMarkBandingSurface", "gdi32"),                                 // DDI
            ("EngMultiByteToUnicodeN", "gdi32"),                                // DDI
            ("EngMultiByteToWideChar", "gdi32"),                                // DDI
            ("EngPaint", "gdi32"),                                              // DDI
            ("EngPlgBlt", "gdi32"),                                             // DDI
            ("EngQueryEMFInfo", "gdi32"),                                       // DDI
            ("EngQueryLocalTime", "gdi32"),                                     // DDI
            ("EngReleaseSemaphore", "gdi32"),                                   // DDI
            ("EngStretchBlt", "gdi32"),                                         // DDI
            ("EngStretchBltROP", "gdi32"),                                      // DDI
            ("EngStrokeAndFillPath", "gdi32"),                                  // DDI
            ("EngStrokePath", "gdi32"),                                         // DDI
            ("EngTextOut", "gdi32"),                                            // DDI
            ("EngTransparentBlt", "gdi32"),                                     // DDI
            ("EngUnicodeToMultiByteN", "gdi32"),                                // DDI
            ("EngUnlockSurface", "gdi32"),                                      // DDI
            ("EngWideCharToMultiByte", "gdi32"),                                // DDI
            ("EudcLoadLinkW", "gdi32"),                                         // undocument
            ("EudcUnloadLinkW", "gdi32"),                                       // undocument
            ("FontIsLinked", "gdi32"),                                          // undocument
            ("FONTOBJ_cGetAllGlyphHandles", "gdi32"),                           // DDI
            ("FONTOBJ_cGetGlyphs", "gdi32"),                                    // DDI
            ("FONTOBJ_pfdg", "gdi32"),                                          // DDI
            ("FONTOBJ_pifi", "gdi32"),                                          // DDI
            ("FONTOBJ_pQueryGlyphAttrs", "gdi32"),                              // DDI
            ("FONTOBJ_pvTrueTypeFontFile", "gdi32"),                            // DDI
            ("FONTOBJ_pxoGetXform", "gdi32"),                                   // DDI
            ("FONTOBJ_vGetInfo", "gdi32"),                                      // DDI
            ("GdiArtificialDecrementDriver", "gdi32"),                          // undocument
            ("GdiConvertBitmapV5", "gdi32"),                                    // undocument
            ("GdiEntry16", "gdi32"),                                            // undocument
            ("GdiFullscreenControl", "gdi32"),                                  // undocument
            ("GdiInitializeLanguagePack", "gdi32"),                             // undocument
            ("GdiIsPlayMetafileDC", "gdi32"),                                   // undocument
            ("GdiPlayPrivatePageEMF", "gdi32"),                                 // undocument
            ("GdiPrinterThunk", "gdi32"),                                       // undocument
            ("GdiRealizationInfo", "gdi32"),                                    // undocument
            ("GdiReleaseDC", "gdi32"),                                          // undocument
            ("GdiSetLastError", "gdi32"),                                       // undocument
            ("GetEUDCTimeStamp", "gdi32"),                                      // undocument
            ("GetEUDCTimeStampExW", "gdi32"),                                   // undocument
            ("GetFontAssocStatus", "gdi32"),                                    // undocument
            ("GetStringBitmapW", "gdi32"),                                      // undocument
            ("GetTextExtentExPointWPri", "gdi32"),                              // undocument
            ("GetTextFaceAliasW", "gdi32"),                                     // undocument
            ("HT_Get8BPPFormatPalette", "gdi32"),                               // DDI
            ("HT_Get8BPPMaskPalette", "gdi32"),                                 // DDI
            ("MirrorRgn", "gdi32"),                                             // undocument
            ("PATHOBJ_bEnum", "gdi32"),                                         // DDI
            ("PATHOBJ_bEnumClipLines", "gdi32"),                                // DDI
            ("PATHOBJ_vEnumStart", "gdi32"),                                    // DDI
            ("PATHOBJ_vEnumStartClipLines", "gdi32"),                           // DDI
            ("PATHOBJ_vGetBounds", "gdi32"),                                    // DDI
            ("QueryFontAssocStatus", "gdi32"),                                  // undocument
            ("SetLayoutWidth", "gdi32"),                                        // undocument
            ("StartFormPage", "gdi32"),                                         // undocument
            ("STROBJ_bEnum", "gdi32"),                                          // DDI
            ("STROBJ_bEnumPositionsOnly", "gdi32"),                             // DDI
            ("STROBJ_bGetAdvanceWidths", "gdi32"),                              // DDI
            ("STROBJ_dwGetCodePage", "gdi32"),                                  // DDI
            ("STROBJ_vEnumStart", "gdi32"),                                     // DDI
            ("XFORMOBJ_bApplyXform", "gdi32"),                                  // DDI
            ("XFORMOBJ_iGetXform", "gdi32"),                                    // DDI
            ("XLATEOBJ_cGetPalette", "gdi32"),                                  // DDI
            ("XLATEOBJ_hGetColorTransform", "gdi32"),                           // DDI
            ("XLATEOBJ_iXlate", "gdi32"),                                       // DDI
            ("XLATEOBJ_piVector", "gdi32"),                                     // DDI
            ("DelayLoadFailureHook", "kernel32"),                               // not api
            ("DosPathToSessionPathW", "kernel32"),                              // undocument
            ("GetConsoleCharType", "kernel32"),                                 // undocument
            ("GetConsoleCursorMode", "kernel32"),                               // undocument
            ("GetConsoleNlsMode", "kernel32"),                                  // undocument
            ("GetDefaultSortkeySize", "kernel32"),                              // undocument
            ("GetLinguistLangSize", "kernel32"),                                // undocument
            ("GetNlsSectionName", "kernel32"),                                  // undocument
            ("Module32First", "kernel32"),                                      // duplicate of Module32FirstW
            ("Module32Next", "kernel32"),                                       // duplicate of Module32NextW
            ("NlsConvertIntegerToString", "kernel32"),                          // undocument
            ("NlsGetCacheUpdateCount", "kernel32"),                             // undocument
            ("NlsResetProcessLocale", "kernel32"),                              // undocument
            ("OpenDataFile", "kernel32"),                                       // undocument
            ("PrivCopyFileExW", "kernel32"),                                    // undocument
            ("PrivMoveFileIdentityW", "kernel32"),                              // undocument
            ("Process32First", "kernel32"),                                     // duplicate of Process32FirstW
            ("Process32Next", "kernel32"),                                      // duplicate of Process32NextW
            ("RegisterConsoleIME", "kernel32"),                                 // undocument
            ("RegisterConsoleOS2", "kernel32"),                                 // undocument
            ("RegisterWaitForSingleObjectEx", "kernel32"),                      // undocument
            ("ReplaceFile", "kernel32"),                                        // duplicate of ReplaceFileW
            ("RequestDeviceWakeup", "kernel32"),                                // undocument
            ("RequestWakeupLatency", "kernel32"),                               // undocument
            ("SetConsoleCursorMode", "kernel32"),                               // undocument
            ("SetConsoleLocalEUDC", "kernel32"),                                // undocument
            ("SetConsoleNlsMode", "kernel32"),                                  // undocument
            ("SetConsoleOS2OemFormat", "kernel32"),                             // undocument
            ("SetCPGlobal", "kernel32"),                                        // undocument
            ("SetMessageWaitingIndicator", "kernel32"),                         // undocument
            ("SetTermsrvAppInstallMode", "kernel32"),                           // undocument
            ("SetTimerQueueTimer", "kernel32"),                                 // undocument
            ("TermsrvAppInstallMode", "kernel32"),                              // undocument
            ("UnregisterConsoleIME", "kernel32"),                               // undocument
            ("UTRegister", "kernel32"),                                         // undocument
            ("UTUnRegister", "kernel32"),                                       // undocument
            ("ValidateLCType", "kernel32"),                                     // undocument
            ("ValidateLocale", "kernel32"),                                     // undocument
            ("AlignRects", "user32"),                                           // undocument
            ("CliImmSetHotKey", "user32"),                                      // undocument
            ("CtxInitUser32", "user32"),                                        // undocument
            ("DeviceEventWorker", "user32"),                                    // undocument
            ("GetAltTabInfo", "user32"),                                        // duplicate of GetAltTabInfoW
            ("GetAppCompatFlags2", "user32"),                                   // undocument
            ("GetCursorFrameInfo", "user32"),                                   // undocument
            ("GetWindowModuleFileName", "user32"),                              // duplicate of GetWindowModuleFileNameW
            ("GetWinStationInfo", "user32"),                                    // undocument
            ("InitializeLpkHooks", "user32"),                                   // undocument
            ("InitializeWin32EntryTable", "user32"),                            // undocument
            ("PrivateSetDbgTag", "user32"),                                     // undocument
            ("PrivateSetRipFlags", "user32"),                                   // undocument
            ("QueryUserCounters", "user32"),                                    // undocument
            ("RealGetWindowClass", "user32"),                                   // duplicate of RealGetWindowClassW
            ("ResolveDesktopForWOW", "user32"),                                 // undocument
            ("User32InitializeImmEntryTable", "user32"),                        // undocument
            ("UserLpkPSMTextOut", "user32"),                                    // undocument
            ("UserLpkTabbedTextOut", "user32"),                                 // undocument
            ("VRipOutput", "user32"),                                           // undocument
            ("VTagOutput", "user32"),                                           // undocument
            ("Win32PoolAllocationStats", "user32"),                             // undocument

            // XP
            ("ClearBitmapAttributes", "gdi32"),                                 // undocument
            ("ClearBrushAttributes", "gdi32"),                                  // undocument
            ("DdEntry0", "gdi32"),                                              // undocument
            ("DdEntry1", "gdi32"),                                              // undocument
            ("DdEntry10", "gdi32"),                                             // undocument
            ("DdEntry11", "gdi32"),                                             // undocument
            ("DdEntry12", "gdi32"),                                             // undocument
            ("DdEntry13", "gdi32"),                                             // undocument
            ("DdEntry14", "gdi32"),                                             // undocument
            ("DdEntry15", "gdi32"),                                             // undocument
            ("DdEntry16", "gdi32"),                                             // undocument
            ("DdEntry17", "gdi32"),                                             // undocument
            ("DdEntry18", "gdi32"),                                             // undocument
            ("DdEntry19", "gdi32"),                                             // undocument
            ("DdEntry2", "gdi32"),                                              // undocument
            ("DdEntry20", "gdi32"),                                             // undocument
            ("DdEntry21", "gdi32"),                                             // undocument
            ("DdEntry22", "gdi32"),                                             // undocument
            ("DdEntry23", "gdi32"),                                             // undocument
            ("DdEntry24", "gdi32"),                                             // undocument
            ("DdEntry25", "gdi32"),                                             // undocument
            ("DdEntry26", "gdi32"),                                             // undocument
            ("DdEntry27", "gdi32"),                                             // undocument
            ("DdEntry28", "gdi32"),                                             // undocument
            ("DdEntry29", "gdi32"),                                             // undocument
            ("DdEntry3", "gdi32"),                                              // undocument
            ("DdEntry30", "gdi32"),                                             // undocument
            ("DdEntry31", "gdi32"),                                             // undocument
            ("DdEntry32", "gdi32"),                                             // undocument
            ("DdEntry33", "gdi32"),                                             // undocument
            ("DdEntry34", "gdi32"),                                             // undocument
            ("DdEntry35", "gdi32"),                                             // undocument
            ("DdEntry36", "gdi32"),                                             // undocument
            ("DdEntry37", "gdi32"),                                             // undocument
            ("DdEntry38", "gdi32"),                                             // undocument
            ("DdEntry39", "gdi32"),                                             // undocument
            ("DdEntry4", "gdi32"),                                              // undocument
            ("DdEntry40", "gdi32"),                                             // undocument
            ("DdEntry41", "gdi32"),                                             // undocument
            ("DdEntry42", "gdi32"),                                             // undocument
            ("DdEntry43", "gdi32"),                                             // undocument
            ("DdEntry44", "gdi32"),                                             // undocument
            ("DdEntry45", "gdi32"),                                             // undocument
            ("DdEntry46", "gdi32"),                                             // undocument
            ("DdEntry47", "gdi32"),                                             // undocument
            ("DdEntry48", "gdi32"),                                             // undocument
            ("DdEntry49", "gdi32"),                                             // undocument
            ("DdEntry5", "gdi32"),                                              // undocument
            ("DdEntry50", "gdi32"),                                             // undocument
            ("DdEntry51", "gdi32"),                                             // undocument
            ("DdEntry52", "gdi32"),                                             // undocument
            ("DdEntry53", "gdi32"),                                             // undocument
            ("DdEntry54", "gdi32"),                                             // undocument
            ("DdEntry55", "gdi32"),                                             // undocument
            ("DdEntry56", "gdi32"),                                             // undocument
            ("DdEntry6", "gdi32"),                                              // undocument
            ("DdEntry7", "gdi32"),                                              // undocument
            ("DdEntry8", "gdi32"),                                              // undocument
            ("DdEntry9", "gdi32"),                                              // undocument
            ("GdiDrawStream", "gdi32"),                                         // undocument
            ("GetBitmapAttributes", "gdi32"),                                   // undocument
            ("GetBrushAttributes", "gdi32"),                                    // undocument
            ("SetBitmapAttributes", "gdi32"),                                   // undocument
            ("SetBrushAttributes", "gdi32"),                                    // undocument
            ("BaseCheckAppcompatCache", "kernel32"),                            // undocument
            ("BaseCleanupAppcompatCache", "kernel32"),                          // undocument
            ("BaseCleanupAppcompatCacheSupport", "kernel32"),                   // undocument
            ("BaseDumpAppcompatCache", "kernel32"),                             // undocument
            ("BaseFlushAppcompatCache", "kernel32"),                            // undocument
            ("BaseInitAppcompatCache", "kernel32"),                             // undocument
            ("BaseInitAppcompatCacheSupport", "kernel32"),                      // undocument
            ("BasepCheckWinSaferRestrictions", "kernel32"),                     // undocument
            ("BaseProcessInitPostImport", "kernel32"),                          // undocument
            ("BaseQueryModuleData", "kernel32"),                                // undocument
            ("BaseUpdateAppcompatCache", "kernel32"),                           // undocument
            ("CreateJobSet", "kernel32"),                                       // undocument
            ("CreateNlsSecurityDescriptor", "kernel32"),                        // undocument
            ("CreateProcessInternalW", "kernel32"),                             // undocument
            ("CreateProcessInternalWSecure", "kernel32"),                       // undocument
            ("CreateSocketHandle", "kernel32"),                                 // undocument
            ("EnumerateLocalComputerNamesW", "kernel32"),                       // undocument
            ("GetCPFileNameFromRegistry", "kernel32"),                          // undocument
            ("GetHandleContext", "kernel32"),                                   // undocument
            ("GetNumaAvailableMemory", "kernel32"),                             // undocument
            ("GetNumaProcessorMap", "kernel32"),                                // undocument
            ("IsValidUILanguage", "kernel32"),                                  // undocument
            ("LZCloseFile", "kernel32"),                                        // undocument
            ("LZCreateFileW", "kernel32"),                                      // undocument
            ("NumaVirtualQueryNode", "kernel32"),                               // undocument
            ("RemoveLocalAlternateComputerNameW", "kernel32"),                  // undocument
            ("RestoreLastError", "kernel32"),                                   // undocument
            ("SetClientTimeZoneInformation", "kernel32"),                       // undocument
            ("SetComPlusPackageInstallStatus", "kernel32"),                     // undocument
            ("SetHandleContext", "kernel32"),                                   // undocument
            ("SetLocalPrimaryComputerNameW", "kernel32"),                       // undocument
            ("AllowForegroundActivation", "user32"),                            // undocument
            ("BuildReasonArray", "user32"),                                     // undocument
            ("CalcMenuBar", "user32"),                                          // undocument
            ("CreateSystemThreads", "user32"),                                  // undocument
            ("CsrBroadcastSystemMessageExW", "user32"),                         // undocument
            ("DestroyReasons", "user32"),                                       // undocument
            ("DisplayExitWindowsWarnings", "user32"),                           // undocument
            ("GetReasonTitleFromReasonCode", "user32"),                         // undocument
            ("IsServerSideWindow", "user32"),                                   // undocument
            ("IsWindowInDestroy", "user32"),                                    // undocument
            ("MessageBoxTimeoutW", "user32"),                                   // undocument
            ("PaintMenuBar", "user32"),                                         // undocument
            ("ReasonCodeNeedsBugID", "user32"),                                 // undocument
            ("ReasonCodeNeedsComment", "user32"),                               // undocument
            ("RecordShutdownReason", "user32"),                                 // undocument
            ("RegisterMessagePumpHook", "user32"),                              // undocument
            ("RegisterUserApiHook", "user32"),                                  // undocument
            ("UnregisterMessagePumpHook", "user32"),                            // undocument
            ("UnregisterUserApiHook", "user32"),                                // undocument

            // Vista
            ("ConfigureOPMProtectedOutput", "gdi32"),                           // Output Protection Manager
            ("CreateOPMProtectedOutputs", "gdi32"),                             // Output Protection Manager
            ("D3DKMTCheckExclusiveOwnership", "gdi32"),                         // DDI
            ("D3DKMTCheckMonitorPowerState", "gdi32"),                          // DDI
            ("D3DKMTCheckOcclusion", "gdi32"),                                  // DDI
            ("D3DKMTCloseAdapter", "gdi32"),                                    // DDI
            ("D3DKMTCreateAllocation", "gdi32"),                                // DDI
            ("D3DKMTCreateContext", "gdi32"),                                   // DDI
            ("D3DKMTCreateDCFromMemory", "gdi32"),                              // DDI
            ("D3DKMTCreateDevice", "gdi32"),                                    // DDI
            ("D3DKMTCreateOverlay", "gdi32"),                                   // DDI
            ("D3DKMTCreateSynchronizationObject", "gdi32"),                     // DDI
            ("D3DKMTDestroyAllocation", "gdi32"),                               // DDI
            ("D3DKMTDestroyContext", "gdi32"),                                  // DDI
            ("D3DKMTDestroyDCFromMemory", "gdi32"),                             // DDI
            ("D3DKMTDestroyDevice", "gdi32"),                                   // DDI
            ("D3DKMTDestroyOverlay", "gdi32"),                                  // DDI
            ("D3DKMTDestroySynchronizationObject", "gdi32"),                    // DDI
            ("D3DKMTEscape", "gdi32"),                                          // DDI
            ("D3DKMTFlipOverlay", "gdi32"),                                     // DDI
            ("D3DKMTGetContextSchedulingPriority", "gdi32"),                    // DDI
            ("D3DKMTGetDeviceState", "gdi32"),                                  // DDI
            ("D3DKMTGetDisplayModeList", "gdi32"),                              // DDI
            ("D3DKMTGetMultisampleMethodList", "gdi32"),                        // DDI
            ("D3DKMTGetPresentHistory", "gdi32"),                               // DDI
            ("D3DKMTGetProcessSchedulingPriorityClass", "gdi32"),               // DDI
            ("D3DKMTGetRuntimeData", "gdi32"),                                  // DDI
            ("D3DKMTGetScanLine", "gdi32"),                                     // DDI
            ("D3DKMTGetSharedPrimaryHandle", "gdi32"),                          // DDI
            ("D3DKMTInvalidateActiveVidPn", "gdi32"),                           // DDI
            ("D3DKMTLock", "gdi32"),                                            // DDI
            ("D3DKMTOpenAdapterFromDeviceName", "gdi32"),                       // DDI
            ("D3DKMTOpenAdapterFromGdiDisplayName", "gdi32"),                   // DDI
            ("D3DKMTOpenAdapterFromHdc", "gdi32"),                              // DDI
            ("D3DKMTOpenResource", "gdi32"),                                    // DDI
            ("D3DKMTPollDisplayChildren", "gdi32"),                             // DDI
            ("D3DKMTPresent", "gdi32"),                                         // DDI
            ("D3DKMTQueryAdapterInfo", "gdi32"),                                // DDI
            ("D3DKMTQueryAllocationResidency", "gdi32"),                        // DDI
            ("D3DKMTQueryResourceInfo", "gdi32"),                               // DDI
            ("D3DKMTQueryStatistics", "gdi32"),                                 // DDI
            ("D3DKMTReleaseProcessVidPnSourceOwners", "gdi32"),                 // DDI
            ("D3DKMTRender", "gdi32"),                                          // DDI
            ("D3DKMTSetAllocationPriority", "gdi32"),                           // DDI
            ("D3DKMTSetContextSchedulingPriority", "gdi32"),                    // DDI
            ("D3DKMTSetDisplayMode", "gdi32"),                                  // DDI
            ("D3DKMTSetDisplayPrivateDriverFormat", "gdi32"),                   // DDI
            ("D3DKMTSetGammaRamp", "gdi32"),                                    // DDI
            ("D3DKMTSetProcessSchedulingPriorityClass", "gdi32"),               // DDI
            ("D3DKMTSetQueuedLimit", "gdi32"),                                  // DDI
            ("D3DKMTSetVidPnSourceOwner", "gdi32"),                             // DDI
            ("D3DKMTSharedPrimaryLockNotification", "gdi32"),                   // DDI
            ("D3DKMTSharedPrimaryUnLockNotification", "gdi32"),                 // DDI
            ("D3DKMTSignalSynchronizationObject", "gdi32"),                     // DDI
            ("D3DKMTUnlock", "gdi32"),                                          // DDI
            ("D3DKMTUpdateOverlay", "gdi32"),                                   // DDI
            ("D3DKMTWaitForIdle", "gdi32"),                                     // DDI
            ("D3DKMTWaitForSynchronizationObject", "gdi32"),                    // DDI
            ("D3DKMTWaitForVerticalBlankEvent", "gdi32"),                       // DDI
            ("DDCCIGetCapabilitiesString", "gdi32"),                            // Monitor Configuration API used by display driver
            ("DDCCIGetCapabilitiesStringLength", "gdi32"),                      // Monitor Configuration API used by display driver
            ("DDCCIGetTimingReport", "gdi32"),                                  // Monitor Configuration API used by display driver
            ("DDCCIGetVCPFeature", "gdi32"),                                    // Monitor Configuration API used by display driver
            ("DDCCISaveCurrentSettings", "gdi32"),                              // Monitor Configuration API used by display driver
            ("DDCCISetVCPFeature", "gdi32"),                                    // Monitor Configuration API used by display driver
            ("DestroyOPMProtectedOutput", "gdi32"),                             // Output Protection Manager
            ("DestroyPhysicalMonitorInternal", "gdi32"),                        // Monitor Configuration API used by display driver
            ("DwmGetDirtyRgn", "gdi32"),                                        // undocument
            ("DwmGetSurfaceData", "gdi32"),                                     // undocument
            ("GdiGetBitmapBitsSize", "gdi32"),                                  // undocument
            ("GdiIsScreenDC", "gdi32"),                                         // undocument
            ("GetCertificate", "gdi32"),                                        // Output Protection Manager
            ("GetCertificateSize", "gdi32"),                                    // Output Protection Manager
            ("GetCOPPCompatibleOPMInformation", "gdi32"),                       // Output Protection Manager
            ("GetNumberOfPhysicalMonitors", "gdi32"),                           // Monitor Configuration API used by display driver
            ("GetOPMInformation", "gdi32"),                                     // Output Protection Manager
            ("GetOPMRandomNumber", "gdi32"),                                    // Output Protection Manager
            ("GetPhysicalMonitorDescription", "gdi32"),                         // Monitor Configuration API used by display driver
            ("GetPhysicalMonitors", "gdi32"),                                   // Monitor Configuration API used by display driver
            ("GetSuggestedOPMProtectedOutputArraySize", "gdi32"),               // Output Protection Manager
            ("IsValidEnhMetaRecord", "gdi32"),                                  // undocument
            ("IsValidEnhMetaRecordOffExt", "gdi32"),                            // undocument
            ("SetOPMSigningKeyAndSequenceNumbers", "gdi32"),                    // Output Protection Manager
            ("BaseCheckRunApp", "kernel32"),                                    // undocument
            ("BaseGenerateAppCompatData", "kernel32"),                          // undocument
            ("BaseIsAppcompatInfrastructureDisabled", "kernel32"),              // undocument
            ("BasepCheckBadapp", "kernel32"),                                   // undocument
            ("BasepFreeAppCompatData", "kernel32"),                             // undocument
            ("BaseThreadInitThunk", "kernel32"),                                // not api
            ("CheckElevation", "kernel32"),                                     // undocument
            ("CheckElevationEnabled", "kernel32"),                              // undocument
            ("CheckForReadOnlyResource", "kernel32"),                           // undocument
            ("CompareCalendarDates", "kernel32"),                               // undocument
            ("ConvertNLSDayOfWeekToWin32DayOfWeek", "kernel32"),                // undocument
            ("GetCalendarDateFormat", "kernel32"),                              // undocument
            ("GetCalendarDaysInMonth", "kernel32"),                             // undocument
            ("GetCalendarDifferenceInDays", "kernel32"),                        // undocument
            ("GetCalendarMonthsInYear", "kernel32"),                            // undocument
            ("GetCalendarWeekNumber", "kernel32"),                              // undocument
            ("GetNamedPipeAttribute", "kernel32"),                              // undocument
            ("IsCalendarLeapDay", "kernel32"),                                  // undocument
            ("IsCalendarLeapMonth", "kernel32"),                                // undocument
            ("IsTimeZoneRedirectionEnabled", "kernel32"),                       // undocument
            ("IsValidCalDateTime", "kernel32"),                                 // undocument
            ("LoadStringBaseExW", "kernel32"),                                  // undocument
            ("LoadStringBaseW", "kernel32"),                                    // undocument
            ("NlsCheckPolicy", "kernel32"),                                     // undocument
            ("NlsEventDataDescCreate", "kernel32"),                             // undocument
            ("NlsUpdateLocale", "kernel32"),                                    // undocument
            ("NlsUpdateSystemLocale", "kernel32"),                              // undocument
            ("NlsWriteEtwEvent", "kernel32"),                                   // undocument
            ("NotifyUILanguageChange", "kernel32"),                             // undocument
            ("SetNamedPipeAttribute", "kernel32"),                              // undocument
            ("WerpCleanupMessageMapping", "kernel32"),                          // undocument
            ("WerpInitiateRemoteRecovery", "kernel32"),                         // undocument
            ("WerpNotifyLoadStringResource", "kernel32"),                       // undocument
            ("WerpNotifyLoadStringResourceEx", "kernel32"),                     // undocument
            ("WerpNotifyUseStringResource", "kernel32"),                        // undocument
            ("WerpStringLookup", "kernel32"),                                   // undocument
            ("_UserTestTokenForInteractive", "user32"),                         // undocument
            ("CheckDesktopByThreadId", "user32"),                               // undocument
            ("CheckWindowThreadDesktop", "user32"),                             // undocument
            ("DoSoundConnect", "user32"),                                       // undocument
            ("DoSoundDisconnect", "user32"),                                    // undocument
            ("DwmGetDxRgn", "user32"),                                          // undocument
            ("DwmHintDxUpdate", "user32"),                                      // undocument
            ("DwmStartRedirection", "user32"),                                  // undocument
            ("DwmStopRedirection", "user32"),                                   // undocument
            ("FrostCrashedWindow", "user32"),                                   // undocument
            ("GetSendMessageReceiver", "user32"),                               // undocument
            ("GetWindowMinimizeRect", "user32"),                                // undocument
            ("GetWindowRgnEx", "user32"),                                       // undocument
            ("GhostWindowFromHungWindow", "user32"),                            // undocument
            ("HungWindowFromGhostWindow", "user32"),                            // undocument
            ("InternalGetWindowIcon", "user32"),                                // undocument
            ("IsSETEnabled", "user32"),                                         // undocument
            ("IsThreadDesktopComposited", "user32"),                            // undocument
            ("OpenThreadDesktop", "user32"),                                    // undocument
            ("PaintMonitor", "user32"),                                         // undocument
            ("PrivateRegisterICSProc", "user32"),                               // undocument
            ("RegisterErrorReportingDialog", "user32"),                         // undocument
            ("RegisterFrostWindow", "user32"),                                  // undocument
            ("RegisterGhostWindow", "user32"),                                  // undocument
            ("RegisterSessionPort", "user32"),                                  // undocument
            ("SetMirrorRendering", "user32"),                                   // undocument
            ("SetWindowRgnEx", "user32"),                                       // undocument
            ("ShowSystemCursor", "user32"),                                     // undocument
            ("SwitchDesktopWithFade", "user32"),                                // undocument
            ("UnregisterSessionPort", "user32"),                                // undocument
            ("UpdateWindowTransform", "user32"),                                // undocument

            // 7
            ("BeginGdiRendering", "gdi32"),                                     // undocument
            ("CreateBitmapFromDxSurface", "gdi32"),                             // undocument
            ("D3DKMTAcquireKeyedMutex", "gdi32"),                               // DDI
            ("D3DKMTCheckSharedResourceAccess", "gdi32"),                       // DDI
            ("D3DKMTCheckVidPnExclusiveOwnership", "gdi32"),                    // DDI
            ("D3DKMTConfigureSharedResource", "gdi32"),                         // DDI
            ("D3DKMTCreateAllocation2", "gdi32"),                               // DDI
            ("D3DKMTCreateKeyedMutex", "gdi32"),                                // DDI
            ("D3DKMTCreateSynchronizationObject2", "gdi32"),                    // DDI
            ("D3DKMTDestroyKeyedMutex", "gdi32"),                               // DDI
            ("D3DKMTGetOverlayState", "gdi32"),                                 // DDI
            ("D3DKMTGetPresentQueueEvent", "gdi32"),                            // DDI
            ("D3DKMTOpenKeyedMutex", "gdi32"),                                  // DDI
            ("D3DKMTOpenResource2", "gdi32"),                                   // DDI
            ("D3DKMTOpenSynchronizationObject", "gdi32"),                       // DDI
            ("D3DKMTReleaseKeyedMutex", "gdi32"),                               // DDI
            ("D3DKMTSignalSynchronizationObject2", "gdi32"),                    // DDI
            ("D3DKMTWaitForSynchronizationObject2", "gdi32"),                   // DDI
            ("DdCreateFullscreenSprite", "gdi32"),                              // undocument
            ("DdDestroyFullscreenSprite", "gdi32"),                             // undocument
            ("DdNotifyFullscreenSpriteUpdate", "gdi32"),                        // undocument
            ("DdQueryVisRgnUniqueness", "gdi32"),                               // undocument
            ("EndGdiRendering", "gdi32"),                                       // undocument
            ("GdiLoadType1Fonts", "gdi32"),                                     // undocument
            ("GetFontFileData", "gdi32"),                                       // undocument
            ("GetFontFileInfo", "gdi32"),                                       // undocument
            ("GetFontRealizationInfo", "gdi32"),                                // undocument
            ("BaseCheckAppcompatCacheEx", "kernel32"),                          // undocument
            ("BaseDllReadWriteIniFile", "kernel32"),                            // undocument
            ("BaseFormatObjectAttributes", "kernel32"),                         // undocument
            ("BaseFormatTimeOut", "kernel32"),                                  // undocument
            ("BaseGetNamedObjectDirectory", "kernel32"),                        // undocument
            ("Basep8BitStringToDynamicUnicodeString", "kernel32"),              // undocument
            ("BasepAllocateActivationContextActivationBlock", "kernel32"),      // undocument
            ("BasepAnsiStringToDynamicUnicodeString", "kernel32"),              // undocument
            ("BasepCheckAppCompat", "kernel32"),                                // undocument
            ("BasepFreeActivationContextActivationBlock", "kernel32"),          // undocument
            ("BasepMapModuleHandle", "kernel32"),                               // undocument
            ("BaseSetLastNTError", "kernel32"),                                 // undocument
            ("BaseVerifyUnicodeString", "kernel32"),                            // undocument
            ("CopyExtendedContext", "kernel32"),                                // undocument
            ("CreateProcessAsUserW", "kernel32"),                               // exists in advapi32
            ("CtrlRoutine", "kernel32"),                                        // undocument
            ("GetEnabledExtendedFeatures", "kernel32"),                         // This function is not supported.
            ("GetEraNameCountedString", "kernel32"),                            // undocument
            ("GetExtendedContextLength", "kernel32"),                           // undocument
            ("GetExtendedFeaturesMask", "kernel32"),                            // undocument
            ("InitializeExtendedContext", "kernel32"),                          // This function is not supported.
            ("LoadAppInitDlls", "kernel32"),                                    // undocument
            ("LocateExtendedFeature", "kernel32"),                              // undocument
            ("LocateLegacyContext", "kernel32"),                                // undocument
            ("NotifyMountMgr", "kernel32"),                                     // undocument
            ("OpenProcessToken", "kernel32"),                                   // exists in advapi32
            ("OpenThreadToken", "kernel32"),                                    // exists in advapi32
            ("RegCloseKey", "kernel32"),                                        // exists in advapi32
            ("RegCreateKeyExW", "kernel32"),                                    // exists in advapi32
            ("RegDeleteKeyExW", "kernel32"),                                    // exists in advapi32
            ("RegDeleteTreeW", "kernel32"),                                     // exists in advapi32
            ("RegDeleteValueW", "kernel32"),                                    // exists in advapi32
            ("RegDisablePredefinedCacheEx", "kernel32"),                        // exists in advapi32
            ("RegEnumKeyExW", "kernel32"),                                      // exists in advapi32
            ("RegEnumValueW", "kernel32"),                                      // exists in advapi32
            ("RegFlushKey", "kernel32"),                                        // exists in advapi32
            ("RegGetKeySecurity", "kernel32"),                                  // exists in advapi32
            ("RegGetValueW", "kernel32"),                                       // exists in advapi32
            ("RegKrnGetGlobalState", "kernel32"),                               // undocument
            ("RegKrnInitialize", "kernel32"),                                   // undocument
            ("RegLoadKeyW", "kernel32"),                                        // exists in advapi32
            ("RegLoadMUIStringW", "kernel32"),                                  // exists in advapi32
            ("RegNotifyChangeKeyValue", "kernel32"),                            // exists in advapi32
            ("RegOpenCurrentUser", "kernel32"),                                 // exists in advapi32
            ("RegOpenKeyExW", "kernel32"),                                      // exists in advapi32
            ("RegOpenUserClassesRoot", "kernel32"),                             // exists in advapi32
            ("RegQueryInfoKeyW", "kernel32"),                                   // exists in advapi32
            ("RegQueryValueExW", "kernel32"),                                   // exists in advapi32
            ("RegRestoreKeyW", "kernel32"),                                     // exists in advapi32
            ("RegSaveKeyExW", "kernel32"),                                      // exists in advapi32
            ("RegSetKeySecurity", "kernel32"),                                  // exists in advapi32
            ("RegSetValueExW", "kernel32"),                                     // exists in advapi32
            ("RegUnLoadKeyW", "kernel32"),                                      // exists in advapi32
            ("SetThreadToken", "kernel32"),                                     // exists in advapi32
            ("SetExtendedFeaturesMask", "kernel32"),                            // undocument
            ("SortCloseHandle", "kernel32"),                                    // undocument
            ("SortGetHandle", "kernel32"),                                      // undocument
            ("ControlMagnification", "user32"),                                 // undocument
            ("DwmGetDxSharedSurface", "user32"),                                // undocument
            ("gapfnScSendMessage", "user32"),                                   // undocument
            ("GetInputLocaleInfo", "user32"),                                   // undocument
            ("GetMagnificationDesktopColorEffect", "user32"),                   // undocument
            ("GetMagnificationDesktopMagnification", "user32"),                 // undocument
            ("GetMagnificationLensCtxInformation", "user32"),                   // undocument
            ("GetTopLevelWindow", "user32"),                                    // undocument
            ("GetWindowCompositionInfo", "user32"),                             // undocument
            ("gSharedInfo", "user32"),                                          // undocument
            ("IsTopLevelWindow", "user32"),                                     // undocument
            ("NotifyOverlayWindow", "user32"),                                  // undocument
            ("SetMagnificationDesktopColorEffect", "user32"),                   // undocument
            ("SetMagnificationDesktopMagnification", "user32"),                 // undocument
            ("SetMagnificationLensCtxInformation", "user32"),                   // undocument
            ("SfmDxBindSwapChain", "user32"),                                   // undocument
            ("SfmDxGetSwapChainStats", "user32"),                               // undocument
            ("SfmDxOpenSwapChain", "user32"),                                   // undocument
            ("SfmDxQuerySwapChainBindingStatus", "user32"),                     // undocument
            ("SfmDxReleaseSwapChain", "user32"),                                // undocument
            ("SfmDxReportPendingBindingsToDwm", "user32"),                      // undocument
            ("SfmDxSetSwapChainBindingStatus", "user32"),                       // undocument
            ("SfmDxSetSwapChainStats", "user32"),                               // undocument

            // 8
            ("CheckDBCSEnabledExt", "user32"),                                  // undocument
            ("CheckProcessForClipboardAccess", "user32"),                       // undocument
            ("CheckProcessSession", "user32"),                                  // undocument
            ("CreateDCompositionHwndTarget", "user32"),                         // undocument
            ("CreateWindowInBand", "user32"),                                   // undocument
            ("CreateWindowIndirect", "user32"),                                 // undocument
            ("DeferWindowPosAndBand", "user32"),                                // undocument
            ("DestroyDCompositionHwndTarget", "user32"),                        // undocument
            ("DwmGetRemoteSessionOcclusionEvent", "user32"),                    // undocument
            ("DwmGetRemoteSessionOcclusionState", "user32"),                    // undocument
            ("DwmLockScreenUpdates", "user32"),                                 // undocument
            ("DwmValidateWindow", "user32"),                                    // undocument
            ("EnableSessionForMMCSS", "user32"),                                // undocument
            ("EndDeferWindowPosEx", "user32"),                                  // undocument
            ("GetClipboardAccessToken", "user32"),                              // undocument
            ("GetDesktopID", "user32"),                                         // undocument
            ("GetProcessUIContextInformation", "user32"),                       // undocument
            ("GetWindowBand", "user32"),                                        // undocument
            ("IsInDesktopWindowBand", "user32"),                                // undocument
            ("IsQueueAttached", "user32"),                                      // undocument
            ("IsThreadMessageQueueAttached", "user32"),                         // undocument
            ("MBToWCSExt", "user32"),                                           // undocument
            ("QueryBSDRWindow", "user32"),                                      // undocument
            ("RegisterBSDRWindow", "user32"),                                   // undocument
            ("SetImmersiveBackgroundWindow", "user32"),                         // undocument
            ("SetThreadInputBlocked", "user32"),                                // undocument
            ("SetWindowBand", "user32"),                                        // undocument
            ("SetWindowCompositionTransition", "user32"),                       // undocument
            ("SignalRedirectionStartComplete", "user32"),                       // undocument
            ("UpdateDefaultDesktopThumbnail", "user32"),                        // undocument
            ("WaitForRedirectionStartComplete", "user32"),                      // undocument

            // 8.1
            ("GetDpiForMonitorInternal", "user32"),                             // undocument
            ("GetProcessDpiAwarenessInternal", "user32"),                       // undocument
            ("SetProcessDpiAwarenessInternal", "user32"),                       // undocument
            ("UpdateWindowInputSinkHints", "user32"),                           // undocument

            // 10_10240
            ("CreateWindowInBandEx", "user32"),                                 // undocument
            ("DwmKernelShutdown", "user32"),                                    // undocument
            ("DwmKernelStartup", "user32"),                                     // undocument
            ("EnableChildWindowDpiMessage", "user32"),                          // undocument
            ("GetClassLongPtrW", "user32"),                                     // x64 private
            ("GetDpiMetrics", "user32"),                                        // undocument
            ("GetPointerFrameArrivalTimes", "user32"),                          // undocument
            ("GetWindowDPI", "user32"),                                         // undocument
            ("GetWindowLongPtrW", "user32"),                                    // x64 private
            ("InitDManipHook", "user32"),                                       // undocument
            ("InitializeInputDeviceInjection", "user32"),                       // undocument
            ("InitializePointerDeviceInjection", "user32"),                     // undocument
            ("InjectDeviceInput", "user32"),                                    // undocument
            ("InjectKeyboardInput", "user32"),                                  // undocument
            ("InjectMouseInput", "user32"),                                     // undocument
            ("InjectPointerInput", "user32"),                                   // undocument
            ("IsChildWindowDpiMessageEnabled", "user32"),                       // undocument
            ("IsWindowBroadcastingDpiToChildren", "user32"),                    // undocument
            ("RegisterDManipHook", "user32"),                                   // undocument
            ("RegisterManipulationThread", "user32"),                           // undocument
            ("ReleaseDwmHitTestWaiters", "user32"),                             // undocument
            ("RIMAddInputObserver", "user32"),                                  // undocument
            ("RIMAreSiblingDevices", "user32"),                                 // undocument
            ("RIMDeviceIoControl", "user32"),                                   // undocument
            ("RIMFreeInputBuffer", "user32"),                                   // undocument
            ("RIMGetDevicePreparsedData", "user32"),                            // undocument
            ("RIMGetDevicePreparsedDataLockfree", "user32"),                    // undocument
            ("RIMGetDeviceProperties", "user32"),                               // undocument
            ("RIMObserveNextInput", "user32"),                                  // undocument
            ("RIMOnPnpNotification", "user32"),                                 // undocument
            ("RIMOnTimerNotification", "user32"),                               // undocument
            ("RIMReadInput", "user32"),                                         // undocument
            ("RIMRegisterForInput", "user32"),                                  // undocument
            ("RIMRemoveInputObserver", "user32"),                               // undocument
            ("RIMSetTestModeStatus", "user32"),                                 // undocument
            ("RIMUnregisterForInput", "user32"),                                // undocument
            ("RIMUpdateInputObserverRegistration", "user32"),                   // undocument
            ("SetClassLongPtrW", "user32"),                                     // x64 private
            ("SetFeatureReportResponse", "user32"),                             // undocument
            ("SetManipulationInputTarget", "user32"),                           // undocument
            ("SetWindowLongPtrW", "user32"),                                    // x64 private

            // 10_10586
            ("RemoveInjectionDevice", "user32"),                                // undocument
            ("RIMGetPhysicalDeviceRect", "user32"),                             // undocument

            // 10_14393
            ("RIMGetSourceProcessId", "user32"),                                // undocument

            // 10_15063
            ("DelegateInput", "user32"),                                        // undocument
            ("HandleDelegatedInput", "user32"),                                 // undocument
            ("InitializeGenericHidInjection", "user32"),                        // undocument
            ("InitializePointerDeviceInjectionEx", "user32"),                   // undocument
            ("InjectGenericHidInput", "user32"),                                // undocument
            ("MITActivateInputProcessing", "user32"),                           // undocument
            ("MITBindInputTypeToMonitors", "user32"),                           // undocument
            ("MITCoreMsgKGetConnectionHandle", "user32"),                       // undocument
            ("MITCoreMsgKOpenConnectionTo", "user32"),                          // undocument
            ("MITCoreMsgKSend", "user32"),                                      // undocument
            ("MITDeactivateInputProcessing", "user32"),                         // undocument
            ("MITDisableMouseIntercept", "user32"),                             // undocument
            ("MITEnableMouseIntercept", "user32"),                              // undocument
            ("MITInjectLegacyISMTouchFrame", "user32"),                         // undocument
            ("MITRegisterManipulationThread", "user32"),                        // undocument
            ("MITSetForegroundRoutingInfo", "user32"),                          // undocument
            ("MITSetInputCallbacks", "user32"),                                 // undocument
            ("MITSetManipulationInputTarget", "user32"),                        // undocument
            ("MITSynthesizeMouseInput", "user32"),                              // undocument
            ("MITSynthesizeMouseWheel", "user32"),                              // undocument
            ("MITSynthesizeTouchInput", "user32"),                              // undocument
            ("MITUpdateInputGlobals", "user32"),                                // undocument
            ("MITWaitForMultipleObjectsEx", "user32"),                          // undocument
            ("ReportInertia", "user32"),                                        // undocument
            ("RIMGetDevicePropertiesLockfree", "user32"),                       // undocument
            ("SetCoreWindow", "user32"),                                        // undocument
            ("UndelegateInput", "user32"),                                      // undocument

            // 10_16299
            ("DWMBindCursorToOutputConfig", "user32"),                          // undocument
            ("DWMCommitInputSystemOutputConfig", "user32"),                     // undocument
            ("DWMSetCursorOrientation", "user32"),                              // undocument
            ("DWMSetInputSystemOutputConfig", "user32"),                        // undocument
            ("GetMagnificationDesktopSamplingMode", "user32"),                  // undocument
            ("MITGetCursorUpdateHandle", "user32"),                             // undocument
            ("MITGetCursorUpdateHandlee", "user32"),                            // undocument
            ("MITStopAndEndInertia", "user32"),                                 // undocument
            ("RIMEnableMonitorMappingForDevice", "user32"),                     // undocument
            ("SetDesktopColorTransform", "user32"),                             // undocument
            ("SetMagnificationDesktopSamplingMode", "user32"),                  // undocument

            // 10_17134
            ("CreatePalmRejectionDelayZone", "user32"),                         // undocument
            ("DestroyPalmRejectionDelayZone", "user32"),                        // undocument
            ("EnableOneCoreTransformMode", "user32"),                           // undocument
            ("GetWindowProcessHandle", "user32"),                               // undocument
            ("IsOneCoreTransformMode", "user32"),                               // undocument
            ("IsThreadTSFEventAware", "user32"),                                // undocument
            ("MakeThreadTSFEventAware", "user32"),                              // undocument
            ("MapVisualRelativePoints", "user32"),                              // undocument
            ("MITDispatchCompletion", "user32"),                                // undocument
            ("MITSetInputDelegationMode", "user32"),                            // undocument
            ("MITSetLastInputRecipient", "user32"),                             // undocument
            ("RemoveThreadTSFEventAwareness", "user32"),                        // undocument

            // 10_17763
            ("CheckBannedOneCoreTransformApi", "user32"),                       // undocument
            ("GetShellChangeNotifyWindow", "user32"),                           // undocument
            ("SetPointerDeviceInputSpace", "user32"),                           // undocument
            ("SetShellChangeNotifyWindow", "user32"),                           // undocument

            // 10_18362
            ("AddVisualIdentifier", "user32"),                                  // undocument
            ("GetExtendedPointerDeviceProperty", "user32"),                     // undocument
            ("GetPointerDeviceOrientation", "user32"),                          // undocument
            ("GetPointerFrameTimes", "user32"),                                 // undocument
            ("MapPointsByVisualIdentifier", "user32"),                          // undocument
            ("RemoveVisualIdentifier", "user32"),                               // undocument
            ("RIMSetExtendedDeviceProperty", "user32"),                         // undocument
            ("SetMagnificationDesktopMagnifierOffsetsDWMUpdated", "user32"),    // undocument

            // 10_19041
            ("GetPointerDeviceInputSpace", "user32"),                           // undocument
            ("InputSpaceRegionFromPoint", "user32"),                            // undocument
            ("RIMQueryDevicePath", "user32"),                                   // undocument
            ("SetFullscreenMagnifierOffsetsDWMUpdated", "user32"),              // undocument

            // 10_19043
            ("SetWindowsHookExAW", "user32"),                                   // undocument

            // 11_22000
            ("GetDCompositionHwndBitmap", "user32"),                            // undocument
            ("RIMOnAsyncPnpWorkNotification", "user32"),                        // undocument
            ("RIMRegisterForInputEx", "user32"),                                // undocument
            ("SetForegroundRedirectionForActivationObject", "user32"),          // undocument
            ("SetProcessLaunchForegroundPolicy", "user32"),                     // undocument
            ("ShellMigrateWindow", "user32"),                                   // undocument
            ("ShellSetWindowPos", "user32"),                                    // undocument

            // 11_22621
            ("GetClipboardMetadata", "user32"),                                 // undocument
            ("RegisterForCustomDockTargets", "user32"),                         // undocument
            ("ShellHandwritingDelegateInput", "user32"),                        // undocument
            ("ShellHandwritingHandleDelegatedInput", "user32"),                 // undocument
            ("ShellHandwritingUndelegateInput", "user32"),                      // undocument
            ("ShellRegisterHotKey", "user32"),                                  // undocument
        };

    }
}
