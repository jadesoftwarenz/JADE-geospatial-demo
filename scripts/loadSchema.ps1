$configDirectory = $PSScriptRoot + "\config\"
$globalConfig = $configDirectory + "run-config.ps1"
$tool = "jade.exe"
$schemaDirectory = "$PSScriptRoot\Schemas"

# source global configuration
. ($globalConfig)

$command = "$jadeBinDirectory\$tool"

& $command path=$jadeDatabaseDirectory ini="$jadeRootDirectory\system.ini" `
    jadelog.logdirectory=$jadelogDirectory jadelog.logfile="schemaload" `
    schema=RootSchema app=JadeSchemaLoader `
    startAppParameters schemaFile="$schemaDirectory\GeoSpatial.mul" deletePropertiesIfAbsent=true loadStyle=onlyStructuralVersioning replayableReorg=true compileUnchangedMethods=true endAppParameters
    