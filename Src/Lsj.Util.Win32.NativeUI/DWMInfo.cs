using Lsj.Util.Win32.Enums;
using Lsj.Util.Win32.Structs;
using static Lsj.Util.Win32.Enums.DWMWINDOWATTRIBUTE;

namespace Lsj.Util.Win32.NativeUI
{
    /// <summary>
    /// DWMInfo
    /// </summary>
    public partial class DWMInfo
    {
        private readonly Win32Window _window;

        internal DWMInfo(Win32Window window)
        {
            _window = window;
        }

        /// <summary>
        /// Is Non-Client Rendering Enabled
        /// </summary>
        /// <remarks>
        /// <see cref="DWMWA_NCRENDERING_ENABLED"/>
        /// </remarks>
        public bool IsNonClientRenderingEnabled => GetIsNonClientRenderingEnabled();

        /// <summary>
        /// Non-Client Rendering Policy
        /// </summary>
        /// <remarks>
        /// <see cref="DWMWA_NCRENDERING_POLICY"/>
        /// </remarks>
        public DWMNCRENDERINGPOLICY NonClientRenderingPolicy
        {
            set => SetNonClientRenderingPolicy(value);
        }

        /// <summary>
        /// Is DWM Transitions Enabled
        /// </summary>
        /// <remarks>
        /// <see cref="DWMWA_TRANSITIONS_FORCEDISABLED"/>
        /// </remarks>
        public bool IsDWMTransitionsEnabled
        {
            set => SetIsDWMTransitionsEnabled(value);
        }

        /// <summary>
        /// Is Non-Client Area Content Visible On DWM Frame
        /// </summary>
        /// <remarks>
        /// <see cref="DWMWA_ALLOW_NCPAINT"/>
        /// </remarks>
        public bool IsNonClientAreaContentVisibleOnDWMFrame
        {
            set => SetIsNonClientAreaContentVisibleOnDWMFrame(value);
        }

        /// <summary>
        /// Caption Button Bounds
        /// </summary>
        /// <remarks>
        /// <see cref="DWMWA_CAPTION_BUTTON_BOUNDS"/>
        /// </remarks>
        public RECT CaptionButtonBounds => GetCaptionButtonBounds();

        /// <summary>
        /// Is Non-Client Area Content Right-To-Left Layout
        /// </summary>
        /// <remarks>
        /// <see cref="DWMWA_NONCLIENT_RTL_LAYOUT"/>
        /// </remarks>
        public bool IsNonClientContentRightToLeftLayout
        {
            set => SetIsNonClientContentRightToLeftLayout(value);
        }

        /// <summary>
        /// Is Force Iconic Representation
        /// </summary>
        /// <remarks>
        /// <see cref="DWMWA_FORCE_ICONIC_REPRESENTATION"/>
        /// </remarks>
        public bool IsForceIconicRepresentation
        {
            set => SetIsForceIconicRepresentation(value);
        }

        /// <summary>
        /// Flip3D Policy
        /// </summary>
        /// <remarks>
        /// <see cref="DWMWA_FLIP3D_POLICY"/>
        /// </remarks>
        public DWMFLIP3DWINDOWPOLICY Flip3DPolicy
        {
            set => SetFlip3DPolicy(value);
        }

        /// <summary>
        /// Extend Frame Bounds
        /// </summary>
        /// <remarks>
        /// <see cref="DWMWA_EXTENDED_FRAME_BOUNDS"/>
        /// </remarks>
        public RECT ExtendFrameBounds => GetExtendFrameBounds();

        /// <summary>
        /// Has Iconic Bitmap
        /// </summary>
        /// <remarks>
        /// <see cref="DWMWA_HAS_ICONIC_BITMAP"/>
        /// </remarks>
        public bool HasIconicBitmap
        {
            set => SetHasIconicBitmap(value);
        }

        /// <summary>
        /// Is Disallow Peek
        /// </summary>
        /// <remarks>
        /// <see cref="DWMWA_DISALLOW_PEEK"/>
        /// </remarks>
        public bool IsDisallowPeek
        {
            set => SetIsDisallowPeek(value);
        }

        /// <summary>
        /// Is Excluded From Peek
        /// </summary>
        /// <remark>
        /// <see cref="DWMWA_EXCLUDED_FROM_PEEK"/>
        /// </remark>
        public bool IsExcludedFromPeek
        {
            set => SetIsExcludedFromPeek(value);
        }

        /// <summary>
        /// Is Cloak
        /// </summary>
        /// <remarks>
        /// <see cref="DWMWA_CLOAK"/>
        /// </remarks>
        public bool IsCloak
        {
            set => SetIsCloak(value);
        }

        /// <summary>
        /// Cloaked
        /// </summary>
        /// <remarks>
        /// <see cref="DWMWA_CLOAKED"/>
        /// </remarks>
        public DWM_CLOAKED Cloaked => GetCloaked();

        /// <summary>
        /// Is Freeze Representation
        /// </summary>
        /// <remarks>
        /// <see cref="DWMWA_FREEZE_REPRESENTATION"/>
        /// </remarks>
        public bool IsFreezeRepresentation
        {
            set => SetIsFreezeRepresentation(value);
        }
    }
}
