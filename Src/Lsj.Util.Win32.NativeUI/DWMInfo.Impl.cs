using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Enums;
using Lsj.Util.Win32.Structs;
using static Lsj.Util.Win32.Dwmapi;
using static Lsj.Util.Win32.Enums.DWMWINDOWATTRIBUTE;
using static Lsj.Util.Win32.UnsafePInvokeExtensions;

namespace Lsj.Util.Win32.NativeUI
{
    public partial class DWMInfo
    {
        private bool GetIsNonClientRenderingEnabled()
        {
            BOOL result = default;
            var hresult = DwmGetWindowAttribute(_window.Handle, DWMWA_NCRENDERING_ENABLED, AsPointer(ref result), SizeOf<BOOL>());
            if (!hresult)
            {
                _window.OnComException(hresult);
            }
            return result;
        }

        private void SetNonClientRenderingPolicy(DWMNCRENDERINGPOLICY value)
        {
            var hresult = DwmSetWindowAttribute(_window.Handle, DWMWA_NCRENDERING_POLICY, AsPointer(ref value), SizeOf<DWMNCRENDERINGPOLICY>());
            if (!hresult)
            {
                _window.OnComException(hresult);
            }
        }

        private void SetIsDWMTransitionsEnabled(bool value)
        {
            BOOL tempVal = !value;
            var hresult = DwmSetWindowAttribute(_window.Handle, DWMWA_TRANSITIONS_FORCEDISABLED, AsPointer(ref tempVal), SizeOf<BOOL>());
            if (!hresult)
            {
                _window.OnComException(hresult);
            }
        }

        private void SetIsNonClientAreaContentVisibleOnDWMFrame(bool value)
        {
            BOOL tempVal = value;
            var hresult = DwmSetWindowAttribute(_window.Handle, DWMWA_ALLOW_NCPAINT, AsPointer(ref tempVal), SizeOf<BOOL>());
            if (!hresult)
            {
                _window.OnComException(hresult);
            }
        }

        private RECT GetCaptionButtonBounds()
        {
            RECT result = default;
            var hresult = DwmGetWindowAttribute(_window.Handle, DWMWA_CAPTION_BUTTON_BOUNDS, AsPointer(ref result), SizeOf<RECT>());
            if (!hresult)
            {
                _window.OnComException(hresult);
            }
            return result;
        }

        private void SetIsNonClientContentRightToLeftLayout(bool value)
        {
            BOOL tempVal = value;
            var hresult = DwmSetWindowAttribute(_window.Handle, DWMWA_NONCLIENT_RTL_LAYOUT, AsPointer(ref tempVal), SizeOf<BOOL>());
            if (!hresult)
            {
                _window.OnComException(hresult);
            }
        }

        private void SetIsForceIconicRepresentation(bool value)
        {
            BOOL tempVal = value;
            var hresult = DwmSetWindowAttribute(_window.Handle, DWMWA_FORCE_ICONIC_REPRESENTATION, AsPointer(ref tempVal), SizeOf<BOOL>());
            if (!hresult)
            {
                _window.OnComException(hresult);
            }
        }

        private void SetFlip3DPolicy(DWMFLIP3DWINDOWPOLICY value)
        {
            var hresult = DwmSetWindowAttribute(_window.Handle, DWMWA_FLIP3D_POLICY, AsPointer(ref value), SizeOf<DWMFLIP3DWINDOWPOLICY>());
            if (!hresult)
            {
                _window.OnComException(hresult);
            }
        }

        private RECT GetExtendFrameBounds()
        {
            RECT result = default;
            var hresult = DwmGetWindowAttribute(_window.Handle, DWMWA_EXTENDED_FRAME_BOUNDS, AsPointer(ref result), SizeOf<RECT>());
            if (!hresult)
            {
                _window.OnComException(hresult);
            }
            return result;
        }

        private void SetHasIconicBitmap(bool value)
        {
            BOOL tempVal = value;
            var hresult = DwmSetWindowAttribute(_window.Handle, DWMWA_HAS_ICONIC_BITMAP, AsPointer(ref tempVal), SizeOf<BOOL>());
            if (!hresult)
            {
                _window.OnComException(hresult);
            }
        }

        private void SetIsDisallowPeek(bool value)
        {
            BOOL tempVal = value;
            var hresult = DwmSetWindowAttribute(_window.Handle, DWMWA_DISALLOW_PEEK, AsPointer(ref tempVal), SizeOf<BOOL>());
            if (!hresult)
            {
                _window.OnComException(hresult);
            }
        }

        private void SetIsExcludedFromPeek(bool value)
        {
            BOOL tempVal = value;
            var hresult = DwmSetWindowAttribute(_window.Handle, DWMWA_EXCLUDED_FROM_PEEK, AsPointer(ref tempVal), SizeOf<BOOL>());
            if (!hresult)
            {
                _window.OnComException(hresult);
            }
        }

        private void SetIsCloak(bool value)
        {
            BOOL tempVal = value;
            var hresult = DwmSetWindowAttribute(_window.Handle, DWMWA_CLOAK, AsPointer(ref tempVal), SizeOf<BOOL>());
            if (!hresult)
            {
                _window.OnComException(hresult);
            }
        }

        private DWM_CLOAKED GetCloaked()
        {
            DWM_CLOAKED result = default;
            var hresult = DwmGetWindowAttribute(_window.Handle, DWMWA_CLOAKED, AsPointer(ref result), SizeOf<DWM_CLOAKED>());
            if (!hresult)
            {
                _window.OnComException(hresult);
            }
            return result;
        }

        private void SetIsFreezeRepresentation(bool value)
        {
            BOOL tempVal = value;
            var hresult = DwmSetWindowAttribute(_window.Handle, DWMWA_FREEZE_REPRESENTATION, AsPointer(ref tempVal), SizeOf<BOOL>());
            if (!hresult)
            {
                _window.OnComException(hresult);
            }
        }
    }
}
