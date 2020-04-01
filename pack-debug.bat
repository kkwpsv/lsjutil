nuget restore

b64 -d %SnkFile% Src\LSJ.snk

cd Src\Lsj.Util\
dotnet pack -c Debug --include-source || exit -1

cd ..\Lsj.Util.APIs.Alipay
dotnet pack -c Debug --include-source || exit -1

cd ..\Lsj.Util.APIs.UmeTrip
dotnet pack -c Debug --include-source || exit -1

cd ..\Lsj.Util.APIs.WeChat
dotnet pack -c Debug --include-source || exit -1

cd ..\Lsj.Util.AspNetCore
dotnet pack -c Debug --include-source || exit -1

cd ..\Lsj.Util.CsBuilder
dotnet pack -c Debug --include-source || exit -1

cd ..\Lsj.Util.Data
dotnet pack -c Debug --include-source || exit -1

cd ..\Lsj.Util.Dynamic
dotnet pack -c Debug --include-source || exit -1

cd ..\Lsj.Util.HtmlBuilder
dotnet pack -c Debug --include-source || exit -1

cd ..\Lsj.Util.JSON
dotnet pack -c Debug --include-source || exit -1

cd ..\Lsj.Util.Net
dotnet pack -c Debug --include-source || exit -1

cd ..\Lsj.Util.Net.Web
dotnet pack -c Debug --include-source || exit -1

cd ..\Lsj.Util.Office
"%ProgramFiles(x86)%\Microsoft Visual Studio\2019\Enterprise\MSBuild\Current\Bin\MSBuild.exe" /t:pack /p:Configuration=Debug /p:IncludeSymbols=true || exit -1

cd ..\Lsj.Util.Protobuf
dotnet pack -c Debug --include-source || exit -1

cd ..\Lsj.Util.SQLBuilder
dotnet pack -c Debug --include-source || exit -1

cd ..\Lsj.Util.Win32
dotnet pack -c Debug --include-source || exit -1

cd ..\Lsj.Util.Win32.NativeUI
dotnet pack -c Debug --include-source || exit -1

cd ..\Lsj.Util.WinForm
dotnet pack -c Debug --include-source || exit -1

cd ..\Lsj.Util.WPF
dotnet pack -c Debug --include-source || exit -1
