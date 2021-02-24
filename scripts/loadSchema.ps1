$configDirectory = $PSScriptRoot + "\config\"
$globalConfig = $configDirectory + "run-config.ps1"
$tool = "jadclient.exe"
$schemaDirectory = "$PSScriptRoot\Schemas"

# source global configuration
. ($globalConfig)

$command = "$jadeBinDirectory\$tool"
   
$arguments = "path=$jadeDatabaseDirectory ini=$jadeRootDirectory\$iniFile " +
    "jadelog.logdirectory=$jadelogDirectory jadelog.logfile=schemaload " +
    "schema=RootSchema app=JadeSchemaLoader server=localServer " +
    "startAppParameters schemaFile=$schemaDirectory\GeoSpatial.mul deletePropertiesIfAbsent=true loadStyle=onlyStructuralVersioning replayableReorg=true compileUnchangedMethods=true endAppParameters"
Start-Process -FilePath $command -ArgumentList $arguments -PassThru -Wait -NoNewWindow
