using Lsj.Util.Win32.BaseTypes;
using System;
using static Lsj.Util.Win32.BaseTypes.HRESULT;

namespace Lsj.Util.Win32.ComInterfaces
{
    /// <summary>
    /// <para>
    /// This interface exposes methods used to enumerate and manipulate property values.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/propsys/nn-propsys-ipropertystore"/>
    /// </para>
    /// </summary>
    public unsafe struct IPropertyStore
    {
        IntPtr* _vTable;

        /// <summary>
        /// After a change has been made, this method saves the changes.
        /// </summary>
        /// <returns>
        /// The <see cref="Commit"/> method returns any one of the following:
        /// <see cref="S_OK"/>:
        /// All of the property changes were successfully written to the stream or path.
        /// This includes the case where no changes were pending when the method was called and nothing was written.
        /// <see cref="STG_E_ACCESSDENIED"/>:
        /// The stream or file is read-only; the method was not able to set the value.
        /// <see cref="E_FAIL"/>:
        /// Some or all of the changes could not be written to the file.
        /// Another, more explanatory error can be used in place of <see cref="E_FAIL"/>.
        /// </returns>
        /// <remarks>
        /// Before the <see cref="Commit"/> method returns, it releases the file stream or path that was initialized to be used by the method.
        /// Therefore, no <see cref="IPropertyStore"/> methods succeed after <see cref="Commit"/> returns.
        /// At that point, they return <see cref="E_FAIL"/>.
        /// Property handlers must ensure that property changes result in a valid destination file,
        /// even if the <see cref="Commit"/> process terminates abnormally, or encounters any errors.
        /// </remarks>
        public HRESULT Commit()
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, HRESULT>)_vTable[7])(thisPtr);
            }
        }
    }
}
