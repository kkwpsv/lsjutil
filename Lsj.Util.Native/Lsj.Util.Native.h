// Lsj.Util.Native.h

#pragma once
#include <Windows.h>
using System::String;
using System::Text::StringBuilder;

namespace Lsj {
	namespace Util
	{
		namespace Native
		{
			public ref class NativeMethod
			{
			public:
				static bool WritePrivateProfileStringSafe(String^ section,String^ key,String^ val,String^ filepath);
				static DWORD GetPrivateProfileStringSafe(String^ section, String^ key, String^ def,StringBuilder^ retVal,DWORD size, String^ filepath);
			private:
				static void SystemStringToChar(String^ str, char* ch);
				static void SystemStringToWChar(String^ str, wchar_t* wch);
			};
		}
	}
}
