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
# Replace the paths in app.config with the selected jade bin directory.
(Get-Content -Path ".\..\JoobSpatialDemo\App.config").Replace("C:\Jade", $jadeRootDirectory) | Set-Content -Path ".\..\JoobSpatialDemo\App.config"

# C:\Jade
Write-Host "Building .NET projects" -ForegroundColor Yellow
& $PSScriptRoot\build.ps1


Push-Location $PSScriptRoot\..\JoobSpatialLoader
Write-Host "Loading GeoSpatial Data..." -ForegroundColor Yellow
& .\bin\x64\Debug\JoobSpatialLoader.exe
Pop-Location

Push-Location $PSScriptRoot\..\JoobSpatialDemo
Write-Host "Starting GeoSpatial Application..." -ForegroundColor Yellow
& .\bin\x64\Debug\JoobSpatialDemo.exe
Pop-Location

Write-Host "GeoSpatial System Ready!" -ForegroundColor Yellow

Pop-Location
