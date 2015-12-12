#include "stdafx.h"
#include "MyString.h"


MyString::MyString(String^ str)
{
	MyString(str->ToCharArray());
}
MyString::MyString(array<wchar_t>^ chars)
{
	this->Length = chars->Length;
	wchar_t* z = new wchar_t[Length];
	for (int i = 0; i < Length; i++)
	{

	}
}
