$ErrorActionPreference = "Stop"

b64 -d $env:SnkFile Src\LSJ.snk
if(!$?) { Exit $LASTEXITCODE }

Set-Location Src\Lsj.Util\
dotnet pack -c Release --include-source
if(!$?) { Exit $LASTEXITCODE }

Set-Location ..\Lsj.Util.APIs.Alipay
dotnet pack -c Release --include-source
if(!$?) { Exit $LASTEXITCODE }

Set-Location ..\Lsj.Util.APIs.UmeTrip
dotnet pack -c Release --include-source
if(!$?) { Exit $LASTEXITCODE }

Set-Location ..\Lsj.Util.APIs.WeChat
dotnet pack -c Release --include-source
if(!$?) { Exit $LASTEXITCODE }

Set-Location ..\Lsj.Util.AspNetCore
dotnet pack -c Release --include-source
if(!$?) { Exit $LASTEXITCODE }

Set-Location ..\Lsj.Util.CsBuilder
dotnet pack -c Release --include-source
if(!$?) { Exit $LASTEXITCODE }

Set-Location ..\Lsj.Util.Data
dotnet pack -c Release --include-source
if(!$?) { Exit $LASTEXITCODE }

Set-Location ..\Lsj.Util.Dynamic
dotnet pack -c Release --include-source
if(!$?) { Exit $LASTEXITCODE }

Set-Location ..\Lsj.Util.HtmlBuilder
dotnet pack -c Release --include-source
if(!$?) { Exit $LASTEXITCODE }

Set-Location ..\Lsj.Util.JSON
dotnet pack -c Release --include-source
if(!$?) { Exit $LASTEXITCODE }

Set-Location ..\Lsj.Util.Net
dotnet pack -c Release --include-source
if(!$?) { Exit $LASTEXITCODE }

Set-Location ..\Lsj.Util.Net.Web
dotnet pack -c Release --include-source
if(!$?) { Exit $LASTEXITCODE }

Set-Location ..\Lsj.Util.Office
&${env:ProgramFiles(x86)}'\Microsoft Visual Studio\2019\Enterprise\MSBuild\Current\Bin\MSBuild.exe' -restore /p:Configuration=Release /t:pack /p:IncludeSymbols=true
if(!$?) { Exit $LASTEXITCODE }

Set-Location ..\Lsj.Util.Protobuf
dotnet pack -c Release --include-source
if(!$?) { Exit $LASTEXITCODE }

Set-Location ..\Lsj.Util.SQLBuilder
dotnet pack -c Release --include-source
if(!$?) { Exit $LASTEXITCODE }

Set-Location ..\Lsj.Util.Win32
dotnet pack -c Release --include-source
if(!$?) { Exit $LASTEXITCODE }

Set-Location ..\Lsj.Util.Win32.NativeUI
dotnet pack -c Release --include-source
if(!$?) { Exit $LASTEXITCODE }

Set-Location ..\Lsj.Util.WinForm
dotnet pack -c Release --include-source
if(!$?) { Exit $LASTEXITCODE }

Set-Location ..\Lsj.Util.WPF
dotnet pack -c Release --include-source
if(!$?) { Exit $LASTEXITCODE }

Set-Location ..\..\