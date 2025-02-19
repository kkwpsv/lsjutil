$ErrorActionPreference = "Stop"

$msbuildPath = ${env:ProgramFiles} + '\Microsoft Visual Studio\2022\Enterprise\MSBuild\Current\Bin\MSBuild.exe'
if (-Not (Test-Path $msbuildPath)) {
    $msbuildPath = ${env:ProgramFiles(x86)} + '\Microsoft Visual Studio\2022\BuildTools\MSBuild\Current\Bin\MSBuild.exe'
    if (-Not (Test-Path $msbuildPath)) {
        Write-Output "MSBuild not found"
        exit -1
    }
}

$commitCount = git rev-list HEAD --count

$env:VersionSuffix = "debug" + $commitCount

b64 -d $env:SnkFile Src\LSJ.snk
if (!$?) { Exit $LASTEXITCODE }

Set-Location Src\Lsj.Util\
dotnet pack -c Debug --include-source
if (!$?) { Exit $LASTEXITCODE }

Set-Location ..\Lsj.Util.AspNetCore
dotnet pack -c Debug --include-source
if (!$?) { Exit $LASTEXITCODE }

Set-Location ..\Lsj.Util.CsBuilder
dotnet pack -c Debug --include-source
if (!$?) { Exit $LASTEXITCODE }

Set-Location ..\Lsj.Util.Data
dotnet pack -c Debug --include-source
if (!$?) { Exit $LASTEXITCODE }

Set-Location ..\Lsj.Util.Dynamic
dotnet pack -c Debug --include-source
if (!$?) { Exit $LASTEXITCODE }

Set-Location ..\Lsj.Util.HtmlBuilder
dotnet pack -c Debug --include-source
if (!$?) { Exit $LASTEXITCODE }

Set-Location ..\Lsj.Util.JSON
dotnet pack -c Debug --include-source
if (!$?) { Exit $LASTEXITCODE }

Set-Location ..\Lsj.Util.Net
dotnet pack -c Debug --include-source
if (!$?) { Exit $LASTEXITCODE }

Set-Location ..\Lsj.Util.Net.Web
dotnet pack -c Debug --include-source
if (!$?) { Exit $LASTEXITCODE }

Set-Location ..\Lsj.Util.Protobuf
dotnet pack -c Debug --include-source
if (!$?) { Exit $LASTEXITCODE }

Set-Location ..\Lsj.Util.SQLBuilder
dotnet pack -c Debug --include-source
if (!$?) { Exit $LASTEXITCODE }

Set-Location ..\Lsj.Util.Win32
dotnet pack -c Debug --include-source
if (!$?) { Exit $LASTEXITCODE }

Set-Location ..\Lsj.Util.Win32.NativeUI
dotnet pack -c Debug --include-source
if (!$?) { Exit $LASTEXITCODE }

Set-Location ..\Lsj.Util.WinForm
dotnet pack -c Debug --include-source
if (!$?) { Exit $LASTEXITCODE }

Set-Location ..\Lsj.Util.WPF
dotnet pack -c Debug --include-source
if (!$?) { Exit $LASTEXITCODE }

Set-Location ..\..\