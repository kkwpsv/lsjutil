$ErrorActionPreference = "Stop"

$commitCount = git rev-list HEAD --count

$env:VersionSuffix = "debug" + $commitCount

b64 -d $env:SnkFile Src\LSJ.snk
if (!$?) { Exit $LASTEXITCODE }

Set-Location Src\Lsj.Util\
dotnet pack --include-source
if (!$?) { Exit $LASTEXITCODE }

Set-Location ..\Lsj.Util.APIs.Alipay
dotnet pack --include-source
if (!$?) { Exit $LASTEXITCODE }

Set-Location ..\Lsj.Util.APIs.UmeTrip
dotnet pack --include-source
if (!$?) { Exit $LASTEXITCODE }

Set-Location ..\Lsj.Util.APIs.WeChat
dotnet pack --include-source
if (!$?) { Exit $LASTEXITCODE }

Set-Location ..\Lsj.Util.AspNetCore
dotnet pack --include-source
if (!$?) { Exit $LASTEXITCODE }

Set-Location ..\Lsj.Util.CsBuilder
dotnet pack --include-source
if (!$?) { Exit $LASTEXITCODE }

Set-Location ..\Lsj.Util.Data
dotnet pack --include-source
if (!$?) { Exit $LASTEXITCODE }

Set-Location ..\Lsj.Util.Dynamic
dotnet pack --include-source
if (!$?) { Exit $LASTEXITCODE }

Set-Location ..\Lsj.Util.HtmlBuilder
dotnet pack --include-source
if (!$?) { Exit $LASTEXITCODE }

Set-Location ..\Lsj.Util.JSON
dotnet pack --include-source
if (!$?) { Exit $LASTEXITCODE }

Set-Location ..\Lsj.Util.Net
dotnet pack --include-source
if (!$?) { Exit $LASTEXITCODE }

Set-Location ..\Lsj.Util.Net.Web
dotnet pack --include-source
if (!$?) { Exit $LASTEXITCODE }

Set-Location ..\Lsj.Util.Office
&${env:ProgramFiles}'\Microsoft Visual Studio\2022\Enterprise\MSBuild\Current\Bin\MSBuild.exe' -restore /t:pack /p:IncludeSymbols=true
if (!$?) { Exit $LASTEXITCODE }

Set-Location ..\Lsj.Util.Protobuf
dotnet pack --include-source
if (!$?) { Exit $LASTEXITCODE }

Set-Location ..\Lsj.Util.SQLBuilder
dotnet pack --include-source
if (!$?) { Exit $LASTEXITCODE }

Set-Location ..\Lsj.Util.Win32
dotnet pack --include-source
if (!$?) { Exit $LASTEXITCODE }

Set-Location ..\Lsj.Util.Win32.NativeUI
dotnet pack --include-source
if (!$?) { Exit $LASTEXITCODE }

Set-Location ..\Lsj.Util.WinForm
dotnet pack --include-source
if (!$?) { Exit $LASTEXITCODE }

Set-Location ..\Lsj.Util.WPF
dotnet pack --include-source
if (!$?) { Exit $LASTEXITCODE }

Set-Location ..\..\