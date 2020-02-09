nuget restore

b64 -d %SnkFile% Src\LSJ.snk

cd Src\Lsj.Util\
dotnet pack -c Release --include-source || exit -1

cd ..\Lsj.Util.APIs.Alipay
dotnet pack -c Release --include-source || exit -1

cd ..\Lsj.Util.APIs.UmeTrip
dotnet pack -c Release --include-source || exit -1

cd ..\Lsj.Util.APIs.WeChat
dotnet pack -c Release --include-source || exit -1

cd ..\Lsj.Util.AspNetCore
dotnet pack -c Release --include-source || exit -1

cd ..\Lsj.Util.CsBuilder
dotnet pack -c Release --include-source || exit -1

cd ..\Lsj.Util.Data
dotnet pack -c Release --include-source || exit -1

cd ..\Lsj.Util.Dynamic
dotnet pack -c Release --include-source || exit -1

cd ..\Lsj.Util.HtmlBuilder
dotnet pack -c Release --include-source || exit -1

cd ..\Lsj.Util.JSON
dotnet pack -c Release --include-source || exit -1

cd ..\Lsj.Util.Net
dotnet pack -c Release --include-source || exit -1

cd ..\Lsj.Util.Net.Web
dotnet pack -c Release --include-source || exit -1

cd ..\Lsj.Util.Office
"%ProgramFiles(x86)%\Microsoft Visual Studio\2019\Enterprise\MSBuild\Current\Bin\MSBuild.exe" /t:pack /p:Configuration=Release /p:IncludeSymbols=true || exit -1

cd ..\Lsj.Util.Protobuf
dotnet pack -c Release --include-source || exit -1

cd ..\Lsj.Util.SQLBuilder
dotnet pack -c Release --include-source || exit -1

cd ..\Lsj.Util.Win32
dotnet pack -c Release --include-source || exit -1

cd ..\Lsj.Util.WinForm
dotnet pack -c Release --include-source || exit -1

cd ..\Lsj.Util.WPF
dotnet pack -c Release --include-source || exit -1
