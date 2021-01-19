$ErrorActionPreference = "Stop"

Set-Location Test/Lsj.Util.Tests

dotnet test --no-build --collect:"XPlat Code Coverage"
if(!$?) { Exit $LASTEXITCODE }

$coverage = (Get-Content .\TestResults\*\coverage.cobertura.xml | Select-String -Pattern "coverage line-rate=`"(.+?)`"").Matches.Groups[1].Value
Write-Host "Coverage: $("{0:n2}" -f ([decimal]$coverage*100))%"