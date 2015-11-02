// 这是主 DLL 文件。

#include "stdafx.h"
#include "Lsj.Util.Native.h"
#include <Windows.h>


bool Lsj::Util::Native::NativeMethod::WritePrivateProfileStringSafe(String ^ section, String ^ key, String ^ val, String ^ filepath)
{
	wchar_t* aa;
	SystemStringToWChar(section, aa);
	wchar_t* bb;
	SystemStringToWChar(key, bb);
	wchar_t* cc;
	SystemStringToWChar(val, cc);
	wchar_t* dd;
	SystemStringToWChar(filepath, dd);
	LPCWSTR a = aa;
	LPCWSTR b = bb;
	LPCWSTR c = cc;
	LPCWSTR d = dd;	
	return WritePrivateProfileString(a, b, c, d);
}

DWORD Lsj::Util::Native::NativeMethod::GetPrivateProfileStringSafe(String ^ section, String ^ key, String ^ def, StringBuilder ^ retVal, DWORD size, String ^ filepath)
{
	wchar_t* aa;
	SystemStringToWChar(section, aa);
	wchar_t* bb;
	SystemStringToWChar(key, bb);
	wchar_t* cc;
	SystemStringToWChar(def, cc);
	wchar_t* dd;
	SystemStringToWChar(filepath, dd);
	LPCWSTR a = aa;
	LPCWSTR b = bb;
	LPCWSTR c = cc;
	LPCWSTR d = dd;

	LPTSTR returnstring = new wchar_t[size];

	DWORD result = GetPrivateProfileString(a, b, c, returnstring, size, d);
	retVal->Clear();
	retVal->Append(returnstring);
	return result;
}

void Lsj::Util::Native::NativeMethod::SystemStringToChar(String ^ str, char* ch)
{
	ch = (char*)(void*)System::Runtime::InteropServices::Marshal::StringToHGlobalAnsi(str);
}

void Lsj::Util::Native::NativeMethod::SystemStringToWChar(String ^ str, wchar_t * wch)
{
	wch = (wchar_t*)(void*)System::Runtime::InteropServices::Marshal::StringToHGlobalUni(str);
}
