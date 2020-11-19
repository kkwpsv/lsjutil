cd Src\Lsj.Util\
dotnet build -c Release || exit -1

cd ..\Lsj.Util.APIs.Alipay
dotnet build -c Release || exit -1

cd ..\Lsj.Util.APIs.UmeTrip 
dotnet build -c Release || exit -1

cd ..\Lsj.Util.APIs.WeChat
dotnet build -c Release || exit -1

cd ..\Lsj.Util.AspNetCore
dotnet build -c Release || exit -1

cd ..\Lsj.Util.CsBuilder
dotnet build -c Release || exit -1

cd ..\Lsj.Util.Data
dotnet build -c Release || exit -1

cd ..\Lsj.Util.Dynamic
dotnet build -c Release || exit -1

cd ..\Lsj.Util.HtmlBuilder
dotnet build -c Release || exit -1

cd ..\Lsj.Util.JSON
dotnet build -c Release || exit -1

cd ..\Lsj.Util.Net
dotnet build -c Release || exit -1

cd ..\Lsj.Util.Net.Web
dotnet build -c Release || exit -1

cd ..\Lsj.Util.Office
"%ProgramFiles(x86)%\Microsoft Visual Studio\2019\Enterprise\MSBuild\Current\Bin\MSBuild.exe" /p:Configuration=Release -restore || exit -1

cd ..\Lsj.Util.Protobuf
dotnet build -c Release || exit -1

cd ..\Lsj.Util.SQLBuilder
dotnet build -c Release || exit -1

cd ..\Lsj.Util.Win32
dotnet build -c Release || exit -1

cd ..\Lsj.Util.Win32.NativeUI
dotnet build -c Release || exit -1

cd ..\Lsj.Util.WinForm
dotnet build -c Release || exit -1

cd ..\Lsj.Util.WPF
dotnet build -c Release || exit -1
