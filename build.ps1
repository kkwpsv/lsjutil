$ErrorActionPreference = "Stop"

$msbuildPath = ${env:ProgramFiles} + '\Microsoft Visual Studio\2022\Enterprise\MSBuild\Current\Bin\MSBuild.exe'
if (-Not (Test-Path $msbuildPath)) {
    $msbuildPath = ${env:ProgramFiles(x86)} + '\Microsoft Visual Studio\2022\BuildTools\MSBuild\Current\Bin\MSBuild.exe'
    if (-Not (Test-Path $msbuildPath)) {
        Write-Output "MSBuild not found"
        exit -1
    }
}

Set-Location Src\Lsj.Util\
dotnet build -c Release
if (!$?) { Exit $LASTEXITCODE }

Set-Location ..\Lsj.Util.AspNetCore
dotnet build -c Release
if (!$?) { Exit $LASTEXITCODE }

Set-Location ..\Lsj.Util.CsBuilder
dotnet build -c Release
if (!$?) { Exit $LASTEXITCODE }

Set-Location ..\Lsj.Util.Data
dotnet build -c Release
if (!$?) { Exit $LASTEXITCODE }

Set-Location ..\Lsj.Util.Dynamic
dotnet build -c Release
if (!$?) { Exit $LASTEXITCODE }

Set-Location ..\Lsj.Util.HtmlBuilder
dotnet build -c Release
if (!$?) { Exit $LASTEXITCODE }

Set-Location ..\Lsj.Util.JSON
dotnet build -c Release
if (!$?) { Exit $LASTEXITCODE }

Set-Location ..\Lsj.Util.Net
dotnet build -c Release
if (!$?) { Exit $LASTEXITCODE }

Set-Location ..\Lsj.Util.Net.Web
dotnet build -c Release
if (!$?) { Exit $LASTEXITCODE }

Set-Location ..\Lsj.Util.Protobuf
dotnet build -c Release
if (!$?) { Exit $LASTEXITCODE }

Set-Location ..\Lsj.Util.SQLBuilder
dotnet build -c Release
if (!$?) { Exit $LASTEXITCODE }

Set-Location ..\Lsj.Util.Win32
dotnet build -c Release
if (!$?) { Exit $LASTEXITCODE }

Set-Location ..\Lsj.Util.Win32.NativeUI
dotnet build -c Release
if (!$?) { Exit $LASTEXITCODE }

Set-Location ..\Lsj.Util.WinForm
dotnet build -c Release
if (!$?) { Exit $LASTEXITCODE }

Set-Location ..\Lsj.Util.WPF
dotnet build -c Release
if (!$?) { Exit $LASTEXITCODE }