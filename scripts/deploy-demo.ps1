Push-Location $PSScriptRoot

$configDirectory = $PSScriptRoot + "\config\"
$globalConfig = $configDirectory + "run-config.ps1"

# source global configuration
. ($globalConfig)

if ((Test-Path "$jadeDatabaseDirectory\_control.dat" -PathType leaf)) {
    Write-Host "_control.dat found in directory: $jadeDatabaseDirectory, database install skipped" -ForegroundColor Green
} else {
    & $PSScriptRoot\initialize-host-database.ps1
}

if ((Test-Path "$jadeDatabaseDirectory\JoobSpatialDemo.dat" -PathType leaf)) {
    Write-Host "JoobSpatialDemo.dat found in directory: $jadeDatabaseDirectory, GeoSpatial schema already loaded." -ForegroundColor Green
} else {
    Write-Host "Loading GeoSpatial schema..." -ForegroundColor Yellow
    & $PSScriptRoot\loadSchema.ps1
}

# Replace the path to the nuget package with the selected jade bin directory.
(Get-Content -Path ".\..\NuGet.Config").Replace("c:\jade\bin", $jadeBinDirectory) | Set-Content -Path ".\..\NuGet.Config"

Write-Host "Building .NET projects" -ForegroundColor Yellow
& $PSScriptRoot\build.ps1

Write-Host "Starting GeoSpatial Application..." -ForegroundColor Yellow

Push-Location $PSScriptRoot\..\JoobSpatialDemo
& .\bin\x64\Debug\JoobSpatialDemo.exe
Pop-Location

Write-Host "GeoSpatial System Ready!" -ForegroundColor Yellow

Pop-Location
