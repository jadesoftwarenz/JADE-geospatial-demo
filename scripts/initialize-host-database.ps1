param(         
      [string] $config = 'Unicode' 
)
Import-Module BitsTransfer

$rootPath = ($PSScriptRoot)
$configDirectory = $rootPath + "/config/"

. ($configDirectory + "run-config.ps1")

$binaryRepoDirectory = "$rootPath\binaryRepo"
$binArchive = "JADE-$jadeVersion-x64-$config-binaries.zip"
$dbArchive = "JADE-$jadeVersion-$config-db.zip"
$sysArchive = "JADE-$jadeVersion-x64-$config-sysfiles.zip"
$localBinArchive = "$binaryRepoDirectory\$binArchive"
$localDbArchive = "$binaryRepoDirectory\$dbArchive"
$localSysArchive = "$binaryRepoDirectory\$sysArchive"
$baseDownloadUrl = "https://secure.jadeworld.com/JADETech/latest/2020"

if (!(Test-Path $binaryRepoDirectory)) {
      New-Item -ItemType Directory -Force -Path $binaryRepoDirectory
}

function DownloadFile { 
      param (
            [string]$source, 
            [string]$dest
      )
      try {
            Write-Host "downloading $dest ..."
            Start-BitsTransfer -Source $source -Destination $binaryRepoDirectory\$dest -ErrorAction Stop
            Write-Host "$dest downloaded." -ForegroundColor blue
      }
      catch {
            Write-Host $error -ForegroundColor red
            Write-Host "$dest download failed." -ForegroundColor red
            Exit 1 
      }
}
function ApplyLicence { 
      param (
            [string]$name, 
            [string]$key
      )
      $arguments = "path=$jadeDatabaseDirectory ini=$jadeRootDirectory\system.ini " +
      "jadelog.logdirectory=$jadelogDirectory jadelog.logfile=jadregb name='$name' key='$key'"
      $proc = (Start-Process -FilePath $jadeBinDirectory/jadregb.exe -ArgumentList $arguments -PassThru -Wait -NoNewWindow)
      if ($proc.ExitCode -ne 0)
      {
            $result = $proc.ExitCode
            Write-Host "Licence operation failed, error code=$result" -ForegroundColor red
            Exit 1 
      }
}

$startTime = Get-Date 
Write-Host "Installing an empty $config database and client binaries on container host: $hostName." -ForegroundColor Yellow

$error.clear()
if (!(Test-Path $localBinArchive -PathType leaf)) {
      DownloadFile -source "$baseDownloadUrl/$binArchive" -dest $binArchive
}

if (!(Test-Path $localDbArchive -PathType leaf)) {
      DownloadFile -source "$baseDownloadUrl/$dbArchive" -dest $dbArchive
}

if (!(Test-Path $localSysArchive -PathType leaf)) {
      DownloadFile -source "$baseDownloadUrl/$sysArchive" -dest $sysArchive
}

try {
      if (!(Test-Path $jadeRootDirectory)) {
            New-Item -ItemType Directory -Force -Path $jadeRootDirectory
      }
      if (!(Test-Path $jadeBinDirectory)) {
            New-Item -ItemType Directory -Force -Path $jadeBinDirectory
      }
      if (!(Test-Path $jadeDatabaseDirectory)) {
            New-Item -ItemType Directory -Force -Path $jadeDatabaseDirectory
      }
      if (!(Test-Path $jadeLogDirectory)) {
            New-Item -ItemType Directory -Force -Path $jadeLogDirectory
      }
      if (!(Test-Path $jadeJournalRootDirectory)) {
            New-Item -ItemType Directory -Force -Path $jadeJournalRootDirectory
      }
      
      if ((Test-Path "$jadeDatabaseDirectory\_control.dat" -PathType leaf)) {
            Write-Host "_control.dat found in directory: $jadeDatabaseDirectory, database install skipped" -ForegroundColor Green
      }
      else {
            Expand-Archive $localDbArchive -DestinationPath $jadeDatabaseDirectory -Force
            Write-Host "Empty $config database installed in directory: $jadeDatabaseDirectory..."
      }
      
      Expand-Archive $localBinArchive -DestinationPath $jadeBinDirectory -Force
      Write-Host "Client binaries installed in directory: $jadeBinDirectory"
      
      Expand-Archive $localSysArchive -DestinationPath $jadeBinDirectory -Force
      Write-Host "System binaries installed in directory: $jadeBinDirectory"

      # Apply licences
      ApplyLicence -name $regName -key $regKey1 

      Copy-Item -Path "${configDirectory}$iniFile"  -Destination $jadeRootDirectory
  
      Write-Host "Initialization of host resident database complete. Time elapsed:" $($(Get-Date) - $startTime) -ForegroundColor Yellow
}
catch {
      Write-Error $_ -ErrorAction Continue
      exit 1 
}
