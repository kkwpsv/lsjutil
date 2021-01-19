$ErrorActionPreference = "Stop"

nuget push Src\Lsj.Util\bin\Release\*.nupkg -Source https://api.nuget.org/v3/index.json -ApiKey %NugetKey% -SkipDuplicate
if(!$?) { Exit $LASTEXITCODE }

nuget push Src\Lsj.Util.APIs.Alipay\bin\Release\*.nupkg -Source https://api.nuget.org/v3/index.json -ApiKey %NugetKey% -SkipDuplicate
if(!$?) { Exit $LASTEXITCODE }

nuget push Src\Lsj.Util.APIs.UmeTrip\bin\Release\*.nupkg -Source https://api.nuget.org/v3/index.json -ApiKey %NugetKey% -SkipDuplicate
if(!$?) { Exit $LASTEXITCODE }

nuget push Src\Lsj.Util.APIs.WeChat\bin\Release\*.nupkg -Source https://api.nuget.org/v3/index.json -ApiKey %NugetKey% -SkipDuplicate
if(!$?) { Exit $LASTEXITCODE }

nuget push Src\Lsj.Util.AspNetCore\bin\Release\*.nupkg -Source https://api.nuget.org/v3/index.json -ApiKey %NugetKey% -SkipDuplicate
if(!$?) { Exit $LASTEXITCODE }

nuget push Src\Lsj.Util.CsBuilder\bin\Release\*.nupkg -Source https://api.nuget.org/v3/index.json -ApiKey %NugetKey% -SkipDuplicate
if(!$?) { Exit $LASTEXITCODE }

nuget push Src\Lsj.Util.Data\bin\Release\*.nupkg -Source https://api.nuget.org/v3/index.json -ApiKey %NugetKey% -SkipDuplicate
if(!$?) { Exit $LASTEXITCODE }

nuget push Src\Lsj.Util.Dynamic\bin\Release\*.nupkg -Source https://api.nuget.org/v3/index.json -ApiKey %NugetKey% -SkipDuplicate
if(!$?) { Exit $LASTEXITCODE }

nuget push Src\Lsj.Util.HtmlBuilder\bin\Release\*.nupkg -Source https://api.nuget.org/v3/index.json -ApiKey %NugetKey% -SkipDuplicate
if(!$?) { Exit $LASTEXITCODE }

nuget push Src\Lsj.Util.JSON\bin\Release\*.nupkg -Source https://api.nuget.org/v3/index.json -ApiKey %NugetKey% -SkipDuplicate
if(!$?) { Exit $LASTEXITCODE }

nuget push Src\Lsj.Util.Net\bin\Release\*.nupkg -Source https://api.nuget.org/v3/index.json -ApiKey %NugetKey% -SkipDuplicate
if(!$?) { Exit $LASTEXITCODE }

nuget push Src\Lsj.Util.Net.Web\bin\Release\*.nupkg -Source https://api.nuget.org/v3/index.json -ApiKey %NugetKey% -SkipDuplicate
if(!$?) { Exit $LASTEXITCODE }

nuget push Src\Lsj.Util.Office\bin\Release\*.nupkg -Source https://api.nuget.org/v3/index.json -ApiKey %NugetKey% -SkipDuplicate
if(!$?) { Exit $LASTEXITCODE }

nuget push Src\Lsj.Util.Protobuf\bin\Release\*.nupkg -Source https://api.nuget.org/v3/index.json -ApiKey %NugetKey% -SkipDuplicate
if(!$?) { Exit $LASTEXITCODE }

nuget push Src\Lsj.Util.SQLBuilder\bin\Release\*.nupkg -Source https://api.nuget.org/v3/index.json -ApiKey %NugetKey% -SkipDuplicate
if(!$?) { Exit $LASTEXITCODE }

nuget push src\Lsj.Util.Win32\bin\Release\*.nupkg -Source https://api.nuget.org/v3/index.json -ApiKey %NugetKey% -SkipDuplicate
if(!$?) { Exit $LASTEXITCODE }

nuget push src\Lsj.Util.Win32.NativeUI\bin\Release\*.nupkg -Source https://api.nuget.org/v3/index.json -ApiKey %NugetKey% -SkipDuplicate
if(!$?) { Exit $LASTEXITCODE }

nuget push Src\Lsj.Util.WinForm\bin\Release\*.nupkg -Source https://api.nuget.org/v3/index.json -ApiKey %NugetKey% -SkipDuplicate
if(!$?) { Exit $LASTEXITCODE }

nuget push Src\Lsj.Util.WPF\bin\Release\*.nupkg -Source https://api.nuget.org/v3/index.json -ApiKey %NugetKey% -SkipDuplicate
if(!$?) { Exit $LASTEXITCODE }


nuget push Src\Lsj.Util\bin\Release\*.nupkg -Source https://nuget.sdlsj.net/v3/index.json -ApiKey %MyNugetKey% -SkipDuplicate
if(!$?) { Exit $LASTEXITCODE }

nuget push Src\Lsj.Util.APIs.Alipay\bin\Release\*.nupkg -Source https://nuget.sdlsj.net/v3/index.json -ApiKey %MyNugetKey% -SkipDuplicate
if(!$?) { Exit $LASTEXITCODE }

nuget push Src\Lsj.Util.APIs.UmeTrip\bin\Release\*.nupkg -Source https://nuget.sdlsj.net/v3/index.json -ApiKey %MyNugetKey% -SkipDuplicate
if(!$?) { Exit $LASTEXITCODE }

nuget push Src\Lsj.Util.APIs.WeChat\bin\Release\*.nupkg -Source https://nuget.sdlsj.net/v3/index.json -ApiKey %MyNugetKey% -SkipDuplicate
if(!$?) { Exit $LASTEXITCODE }

nuget push Src\Lsj.Util.AspNetCore\bin\Release\*.nupkg -Source https://nuget.sdlsj.net/v3/index.json -ApiKey %MyNugetKey% -SkipDuplicate
if(!$?) { Exit $LASTEXITCODE }

nuget push Src\Lsj.Util.CsBuilder\bin\Release\*.nupkg -Source https://nuget.sdlsj.net/v3/index.json -ApiKey %MyNugetKey% -SkipDuplicate
if(!$?) { Exit $LASTEXITCODE }

nuget push Src\Lsj.Util.Data\bin\Release\*.nupkg -Source https://nuget.sdlsj.net/v3/index.json -ApiKey %MyNugetKey% -SkipDuplicate
if(!$?) { Exit $LASTEXITCODE }

nuget push Src\Lsj.Util.Dynamic\bin\Release\*.nupkg -Source https://nuget.sdlsj.net/v3/index.json -ApiKey %MyNugetKey% -SkipDuplicate
if(!$?) { Exit $LASTEXITCODE }

nuget push Src\Lsj.Util.HtmlBuilder\bin\Release\*.nupkg -Source https://nuget.sdlsj.net/v3/index.json -ApiKey %MyNugetKey% -SkipDuplicate
if(!$?) { Exit $LASTEXITCODE }

nuget push Src\Lsj.Util.JSON\bin\Release\*.nupkg -Source https://nuget.sdlsj.net/v3/index.json -ApiKey %MyNugetKey% -SkipDuplicate
if(!$?) { Exit $LASTEXITCODE }

nuget push Src\Lsj.Util.Net\bin\Release\*.nupkg -Source https://nuget.sdlsj.net/v3/index.json -ApiKey %MyNugetKey% -SkipDuplicate
if(!$?) { Exit $LASTEXITCODE }

nuget push Src\Lsj.Util.Net.Web\bin\Release\*.nupkg -Source https://nuget.sdlsj.net/v3/index.json -ApiKey %MyNugetKey% -SkipDuplicate
if(!$?) { Exit $LASTEXITCODE }

nuget push Src\Lsj.Util.Office\bin\Release\*.nupkg -Source https://nuget.sdlsj.net/v3/index.json -ApiKey %MyNugetKey% -SkipDuplicate
if(!$?) { Exit $LASTEXITCODE }

nuget push Src\Lsj.Util.Protobuf\bin\Release\*.nupkg -Source https://nuget.sdlsj.net/v3/index.json -ApiKey %MyNugetKey% -SkipDuplicate
if(!$?) { Exit $LASTEXITCODE }

nuget push Src\Lsj.Util.SQLBuilder\bin\Release\*.nupkg -Source https://nuget.sdlsj.net/v3/index.json -ApiKey %MyNugetKey% -SkipDuplicate
if(!$?) { Exit $LASTEXITCODE }

nuget push src\Lsj.Util.Win32\bin\Release\*.nupkg -Source https://nuget.sdlsj.net/v3/index.json -ApiKey %MyNugetKey% -SkipDuplicate
if(!$?) { Exit $LASTEXITCODE }

nuget push src\Lsj.Util.Win32.NativeUI\bin\Release\*.nupkg -Source https://nuget.sdlsj.net/v3/index.json -ApiKey %MyNugetKey% -SkipDuplicate
if(!$?) { Exit $LASTEXITCODE }

nuget push Src\Lsj.Util.WinForm\bin\Release\*.nupkg -Source https://nuget.sdlsj.net/v3/index.json -ApiKey %MyNugetKey% -SkipDuplicate
if(!$?) { Exit $LASTEXITCODE }

nuget push Src\Lsj.Util.WPF\bin\Release\*.nupkg -Source https://nuget.sdlsj.net/v3/index.json -ApiKey %MyNugetKey% -SkipDuplicate
if(!$?) { Exit $LASTEXITCODE }
