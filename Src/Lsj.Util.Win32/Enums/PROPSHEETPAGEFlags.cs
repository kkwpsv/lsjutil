﻿using Lsj.Util.Win32.Structs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// <see cref="PROPSHEETPAGE"/> Flags
    /// </para>
    /// <para>
    /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/controls/pss-propsheetpage"/>
    /// </para>
    /// </summary>
    public enum PROPSHEETPAGEFlags : uint
    {
        /// <summary>
        /// Uses the default meaning for all structure members.
        /// This flag is not supported when using the Aero-style wizard (<see cref="PSH_AEROWIZARD"/>).
        /// </summary>
        PSP_DEFAULT = 0x00000000,

        /// <summary>
        /// Creates the page from the dialog box template in memory pointed to by the <see cref="PROPSHEETPAGE.pResource"/> member.
        /// The <see cref="PropertySheet"/> function assumes that the template that is in memory is not write-protected.
        /// A read-only template will cause an exception in some versions of Windows.
        /// </summary>
        PSP_DLGINDIRECT = 0x00000001,

        /// <summary>
        /// Uses <see cref="PROPSHEETPAGE.hIcon"/> as the small icon on the tab for the page.
        /// This flag is not supported when using the Aero-style wizard (<see cref="PSH_AEROWIZARD"/>).
        /// </summary>
        PSP_USEHICON = 0x00000002,

        /// <summary>
        /// Uses <see cref="PROPSHEETPAGE.pszIcon"/> as the name of the icon resource to load and use as the small icon on the tab for the page.
        /// This flag is not supported when using the Aero-style wizard (<see cref="PSH_AEROWIZARD"/>).
        /// </summary>
        PSP_USEICONID = 0x00000004,

        /// <summary>
        /// Uses the <see cref="PROPSHEETPAGE.pszTitle"/> member as the title of the property sheet dialog box instead of the title stored in the dialog box template.
        /// This flag is not supported when using the Aero-style wizard (<see cref="PSH_AEROWIZARD"/>).
        /// </summary>
        PSP_USETITLE = 0x00000008,

        /// <summary>
        /// Reverses the direction in which <see cref="PROPSHEETPAGE.pszTitle"/> is displayed
        /// Normal windows display all text, including <see cref="PROPSHEETPAGE.pszTitle"/>, left-to-right (LTR).
        /// For languages such as Hebrew or Arabic that read right-to-left (RTL), a window can be mirrored and all text will be displayed RTL.
        /// If <see cref="PSP_RTLREADING"/> is set, pszTitle will instead read RTL in a normal parent window, and LTR in a mirrored parent window.
        /// </summary>
        PSP_RTLREADING = 0x00000010,

        /// <summary>
        /// Enables the property sheet Help button when the page is active.
        /// This flag is not supported when using the Aero-style wizard (<see cref="PSH_AEROWIZARD"/>).
        /// </summary>
        PSP_HASHELP = 0x00000020,

        /// <summary>
        /// Maintains the reference count specified by the <see cref="PROPSHEETPAGE.pcRefParent"/> member for the lifetime of the property sheet page created from this structure.
        /// </summary>
        PSP_USEREFPARENT = 0x00000040,

        /// <summary>
        /// Calls the function specified by the <see cref="PROPSHEETPAGE.pfnCallback"/> member when creating or destroying the property sheet page defined by this structure.
        /// </summary>
        PSP_USECALLBACK = 0x00000080,

        /// <summary>
        /// Version 4.71 or later.
        /// Causes the page to be created when the property sheet is created. 
        /// If this flag is not specified, the page will not be created until it is selected the first time.
        /// This flag is not supported when using the Aero-style wizard (<see cref="PSH_AEROWIZARD"/>).
        /// </summary>
        PSP_PREMATURE = 0x00000400,

        /// <summary>
        /// Version 5.80 and later.
        /// Causes the wizard property sheet to hide the header area when the page is selected.
        /// If a watermark has been provided, it will be painted on the left side of the page.
        /// This flag should be set for welcome and completion pages, and omitted for interior pages.
        /// This flag is not supported when using the Aero-style wizard (<see cref="PSH_AEROWIZARD"/>).
        /// </summary>
        PSP_HIDEHEADER = 0x00000800,

        /// <summary>
        /// Version 5.80 or later.
        /// Displays the string pointed to by the <see cref="PROPSHEETPAGE.pszHeaderTitle"/> member as the title in the header of a Wizard97 interior page.
        /// You must also set the <see cref="PSH_WIZARD97"/> flag in the <see cref="PROPSHEETHEADER.dwFlags"/> member of the associated <see cref="PROPSHEETHEADER"/> structure.
        /// The <see cref="PSP_USEHEADERTITLE"/> flag is ignored if <see cref="PSP_HIDEHEADER"/> is set.
        /// This flag is not supported when using the Aero-style wizard (<see cref="PSH_AEROWIZARD"/>).
        /// </summary>
        PSP_USEHEADERTITLE = 0x00001000,

        /// <summary>
        /// Version 5.80 or later.
        /// Displays the string pointed to by the <see cref="PROPSHEETPAGE.pszHeaderSubTitle"/> member as the subtitle of the header area of a Wizard97 page.
        /// To use this flag, you must also set the <see cref="PSH_WIZARD97"/> flag
        /// in the <see cref="PROPSHEETHEADER.dwFlags"/> member of the associated <see cref="PROPSHEETHEADER"/> structure.
        /// The <see cref="PSP_USEHEADERSUBTITLE"/> flag is ignored if <see cref="PSP_HIDEHEADER"/> is set.
        /// In Aero-style wizards, the title appears near the top of the client area.
        /// </summary>
        PSP_USEHEADERSUBTITLE = 0x00002000,

        /// <summary>
        /// Version 6.0 and later.
        /// Use an activation context.
        /// To use an activation context, you must set this flag and assign the activation context handle to <see cref="PROPSHEETPAGE.hActCtx"/>.
        /// See the Remarks.
        /// </summary>
        PSP_USEFUSIONCONTEXT = 0x00004000,
    }
}
