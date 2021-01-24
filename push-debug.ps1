$ErrorActionPreference = "Stop"

nuget push Src\Lsj.Util\bin\Debug\*.nupkg -Source https://nuget.sdlsj.net/v3/index.json -ApiKey $env:MyNugetKey -SkipDuplicate
if(!$?) { Exit $LASTEXITCODE }

nuget push Src\Lsj.Util.APIs.Alipay\bin\Debug\*.nupkg -Source https://nuget.sdlsj.net/v3/index.json -ApiKey $env:MyNugetKey -SkipDuplicate
if(!$?) { Exit $LASTEXITCODE }

nuget push Src\Lsj.Util.APIs.UmeTrip\bin\Debug\*.nupkg -Source https://nuget.sdlsj.net/v3/index.json -ApiKey $env:MyNugetKey -SkipDuplicate
if(!$?) { Exit $LASTEXITCODE }

nuget push Src\Lsj.Util.APIs.WeChat\bin\Debug\*.nupkg -Source https://nuget.sdlsj.net/v3/index.json -ApiKey $env:MyNugetKey -SkipDuplicate
if(!$?) { Exit $LASTEXITCODE }

nuget push Src\Lsj.Util.AspNetCore\bin\Debug\*.nupkg -Source https://nuget.sdlsj.net/v3/index.json -ApiKey $env:MyNugetKey -SkipDuplicate
if(!$?) { Exit $LASTEXITCODE }

nuget push Src\Lsj.Util.CsBuilder\bin\Debug\*.nupkg -Source https://nuget.sdlsj.net/v3/index.json -ApiKey $env:MyNugetKey -SkipDuplicate
if(!$?) { Exit $LASTEXITCODE }

nuget push Src\Lsj.Util.Data\bin\Debug\*.nupkg -Source https://nuget.sdlsj.net/v3/index.json -ApiKey $env:MyNugetKey -SkipDuplicate
if(!$?) { Exit $LASTEXITCODE }

nuget push Src\Lsj.Util.Dynamic\bin\Debug\*.nupkg -Source https://nuget.sdlsj.net/v3/index.json -ApiKey $env:MyNugetKey -SkipDuplicate
if(!$?) { Exit $LASTEXITCODE }

nuget push Src\Lsj.Util.HtmlBuilder\bin\Debug\*.nupkg -Source https://nuget.sdlsj.net/v3/index.json -ApiKey $env:MyNugetKey -SkipDuplicate
if(!$?) { Exit $LASTEXITCODE }

nuget push Src\Lsj.Util.JSON\bin\Debug\*.nupkg -Source https://nuget.sdlsj.net/v3/index.json -ApiKey $env:MyNugetKey -SkipDuplicate
if(!$?) { Exit $LASTEXITCODE }

nuget push Src\Lsj.Util.Net\bin\Debug\*.nupkg -Source https://nuget.sdlsj.net/v3/index.json -ApiKey $env:MyNugetKey -SkipDuplicate
if(!$?) { Exit $LASTEXITCODE }

nuget push Src\Lsj.Util.Net.Web\bin\Debug\*.nupkg -Source https://nuget.sdlsj.net/v3/index.json -ApiKey $env:MyNugetKey -SkipDuplicate
if(!$?) { Exit $LASTEXITCODE }

nuget push Src\Lsj.Util.Office\bin\Debug\*.nupkg -Source https://nuget.sdlsj.net/v3/index.json -ApiKey $env:MyNugetKey -SkipDuplicate
if(!$?) { Exit $LASTEXITCODE }

nuget push Src\Lsj.Util.Protobuf\bin\Debug\*.nupkg -Source https://nuget.sdlsj.net/v3/index.json -ApiKey $env:MyNugetKey -SkipDuplicate
if(!$?) { Exit $LASTEXITCODE }

nuget push Src\Lsj.Util.SQLBuilder\bin\Debug\*.nupkg -Source https://nuget.sdlsj.net/v3/index.json -ApiKey $env:MyNugetKey -SkipDuplicate
if(!$?) { Exit $LASTEXITCODE }

nuget push src\Lsj.Util.Win32\bin\Debug\*.nupkg -Source https://nuget.sdlsj.net/v3/index.json -ApiKey $env:MyNugetKey -SkipDuplicate
if(!$?) { Exit $LASTEXITCODE }

nuget push src\Lsj.Util.Win32.NativeUI\bin\Debug\*.nupkg -Source https://nuget.sdlsj.net/v3/index.json -ApiKey $env:MyNugetKey -SkipDuplicate
if(!$?) { Exit $LASTEXITCODE }

nuget push Src\Lsj.Util.WinForm\bin\Debug\*.nupkg -Source https://nuget.sdlsj.net/v3/index.json -ApiKey $env:MyNugetKey -SkipDuplicate
if(!$?) { Exit $LASTEXITCODE }

nuget push Src\Lsj.Util.WPF\bin\Debug\*.nupkg -Source https://nuget.sdlsj.net/v3/index.json -ApiKey $env:MyNugetKey -SkipDuplicate
if(!$?) { Exit $LASTEXITCODE }
