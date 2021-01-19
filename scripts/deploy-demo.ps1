Push-Location $PSScriptRoot

$configDirectory = $PSScriptRoot + "\config\"
$globalConfig = $configDirectory + "run-config.ps1"

# source global configuration
. ($globalConfig)

& $PSScriptRoot\initialize-host-database.ps1

Write-Host "Loading GeoSpatial schema..." -ForegroundColor Yellow
& $PSScriptRoot\loadSchema.ps1

Write-Host "GeoSpatial System Ready!" -ForegroundColor Yellow

Pop-Location
