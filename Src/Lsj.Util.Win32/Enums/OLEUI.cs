using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// OLEUI
    /// </summary>
    public enum OLEUI : uint
    {
        /// <summary>
        /// OLEUI_FALSE
        /// </summary>
        OLEUI_FALSE = 0,

        /// <summary>
        /// OLEUI_SUCCESS
        /// </summary>
        OLEUI_SUCCESS = 1,

        /// <summary>
        /// OLEUI_OK
        /// </summary>
        OLEUI_OK = 1,

        /// <summary>
        /// OLEUI_CANCEL
        /// </summary>
        OLEUI_CANCEL = 2,

        /// <summary>
        /// OLEUI_ERR_STANDARDMIN
        /// </summary>
        OLEUI_ERR_STANDARDMIN = 100,

        /// <summary>
        /// OLEUI_ERR_OLEMEMALLOC
        /// </summary>
        OLEUI_ERR_OLEMEMALLOC = 100,

        /// <summary>
        /// OLEUI_ERR_STRUCTURENULL
        /// </summary>
        OLEUI_ERR_STRUCTURENULL = 101,

        /// <summary>
        /// OLEUI_ERR_STRUCTUREINVALID
        /// </summary>
        OLEUI_ERR_STRUCTUREINVALID = 102,

        /// <summary>
        /// OLEUI_ERR_CBSTRUCTINCORRECT
        /// </summary>
        OLEUI_ERR_CBSTRUCTINCORRECT = 103,

        /// <summary>
        /// OLEUI_ERR_HWNDOWNERINVALID
        /// </summary>
        OLEUI_ERR_HWNDOWNERINVALID = 104,

        /// <summary>
        /// OLEUI_ERR_LPSZCAPTIONINVALID
        /// </summary>
        OLEUI_ERR_LPSZCAPTIONINVALID = 105,

        /// <summary>
        /// OLEUI_ERR_LPFNHOOKINVALID
        /// </summary>
        OLEUI_ERR_LPFNHOOKINVALID = 106,

        /// <summary>
        /// OLEUI_ERR_HINSTANCEINVALID
        /// </summary>
        OLEUI_ERR_HINSTANCEINVALID = 107,

        /// <summary>
        /// OLEUI_ERR_LPSZTEMPLATEINVALID
        /// </summary>
        OLEUI_ERR_LPSZTEMPLATEINVALID = 108,

        /// <summary>
        /// OLEUI_ERR_HRESOURCEINVALID
        /// </summary>
        OLEUI_ERR_HRESOURCEINVALID = 109,

        /// <summary>
        /// OLEUI_ERR_FINDTEMPLATEFAILURE
        /// </summary>
        OLEUI_ERR_FINDTEMPLATEFAILURE = 110,

        /// <summary>
        /// OLEUI_ERR_LOADTEMPLATEFAILURE
        /// </summary>
        OLEUI_ERR_LOADTEMPLATEFAILURE = 111,

        /// <summary>
        /// OLEUI_ERR_DIALOGFAILURE
        /// </summary>
        OLEUI_ERR_DIALOGFAILURE = 112,

        /// <summary>
        /// OLEUI_ERR_LOCALMEMALLOC
        /// </summary>
        OLEUI_ERR_LOCALMEMALLOC = 113,

        /// <summary>
        /// OLEUI_ERR_GLOBALMEMALLOC
        /// </summary>
        OLEUI_ERR_GLOBALMEMALLOC = 114,

        /// <summary>
        /// OLEUI_ERR_LOADSTRING
        /// </summary>
        OLEUI_ERR_LOADSTRING = 115,

        /// <summary>
        /// OLEUI_ERR_STANDARDMAX
        /// </summary>
        OLEUI_ERR_STANDARDMAX = 116,
    }
}
