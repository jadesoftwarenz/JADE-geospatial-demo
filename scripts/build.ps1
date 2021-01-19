param(
    [bool] $runTest = $false, 
    [string] $buildPlatform = "x64",
    [string] $buildConfig = 'U',
    [string] $packageSubdir = "x64\Unicode"
)

Push-Location $PSScriptRoot

# locate msbuild and set path and environments variables for command line
. .\find-msbuild.ps1

# build exposure
Push-Location .\..\JoobSpatialExposure
MsBuild  SpatialDemoExposure.csproj -t:Build -property:Configuration=Debug -property:Platform=x64 
Pop-Location

# build demo
Push-Location .\..\JoobSpatialDemo
MsBuild  JoobSpatialDemo.csproj -t:Build -property:Configuration=Debug -property:Platform=x64 
Pop-Location

Pop-Location