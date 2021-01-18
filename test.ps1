Set-Location Test/Lsj.Util.Tests
dotnet test --collect:"XPlat Code Coverage"
$coverage = (Get-Content .\TestResults\*\coverage.cobertura.xml | Select-String -Pattern "coverage line-rate=`"(.+?)`"").Matches.Groups[1].Value
Write-Host "Coverage: $("{0:n2}" -f ([decimal]$coverage*100))%"