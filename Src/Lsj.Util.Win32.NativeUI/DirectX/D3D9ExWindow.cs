using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Structs;

namespace Lsj.Util.Win32.NativeUI.DirectX
{
    /// <summary>
    /// Direct3D9Ex window
    /// </summary>
    public class D3D9ExWindow : Win32Window
    {
        protected override LRESULT OnCreate(HWND hWnd, WPARAM wParam, LPARAM lParam, ref CREATESTRUCT createStruct)
        {
            try
            {
            }
            catch
            {
                return -1;
            }

            return base.OnCreate(hWnd, wParam, lParam, ref createStruct);
        }
    }
}
