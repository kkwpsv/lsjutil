$ErrorActionPreference = "Stop"

Set-Location Src\Lsj.Util\
dotnet build
if(!$?) { Exit $LASTEXITCODE }

Set-Location ..\Lsj.Util.APIs.Alipay
dotnet build
if(!$?) { Exit $LASTEXITCODE }

Set-Location ..\Lsj.Util.APIs.UmeTrip 
dotnet build
if(!$?) { Exit $LASTEXITCODE }

Set-Location ..\Lsj.Util.APIs.WeChat
dotnet build
if(!$?) { Exit $LASTEXITCODE }

Set-Location ..\Lsj.Util.AspNetCore
dotnet build
if(!$?) { Exit $LASTEXITCODE }

Set-Location ..\Lsj.Util.CsBuilder
dotnet build
if(!$?) { Exit $LASTEXITCODE }

Set-Location ..\Lsj.Util.Data
dotnet build
if(!$?) { Exit $LASTEXITCODE }

Set-Location ..\Lsj.Util.Dynamic
dotnet build
if(!$?) { Exit $LASTEXITCODE }

Set-Location ..\Lsj.Util.HtmlBuilder
dotnet build
if(!$?) { Exit $LASTEXITCODE }

Set-Location ..\Lsj.Util.JSON
dotnet build
if(!$?) { Exit $LASTEXITCODE }

Set-Location ..\Lsj.Util.Net
dotnet build
if(!$?) { Exit $LASTEXITCODE }

Set-Location ..\Lsj.Util.Net.Web
dotnet build
if(!$?) { Exit $LASTEXITCODE }

Set-Location ..\Lsj.Util.Office
&${env:ProgramFiles}'\Microsoft Visual Studio\2022\Enterprise\MSBuild\Current\Bin\MSBuild.exe' -restore
if(!$?) { Exit $LASTEXITCODE }

Set-Location ..\Lsj.Util.Protobuf
dotnet build
if(!$?) { Exit $LASTEXITCODE }

Set-Location ..\Lsj.Util.SQLBuilder
dotnet build
if(!$?) { Exit $LASTEXITCODE }

Set-Location ..\Lsj.Util.Win32
dotnet build
if(!$?) { Exit $LASTEXITCODE }

Set-Location ..\Lsj.Util.Win32.NativeUI
dotnet build
if(!$?) { Exit $LASTEXITCODE }

Set-Location ..\Lsj.Util.WinForm
dotnet build
if(!$?) { Exit $LASTEXITCODE }

Set-Location ..\Lsj.Util.WPF
dotnet build
if(!$?) { Exit $LASTEXITCODE }