Set-Location Test/Lsj.Util.Tests
dotnet test --collect:"XPlat Code Coverage"
$coverage = (Get-Content .\TestResults\*\coverage.cobertura.xml | Select-String -Pattern "coverage line-rate=`"(.+?)`"").Matches.Groups[1]
Write-Host "Coverage: $coverage"