using System::String;
#pragma once
public ref struct MyString
{
public:
	MyString(String^ str);
	MyString(array<wchar_t>^ chars);
	MyString(wchar_t* chars, int length);
	int Length;

private:
	wchar_t* chars;
};

