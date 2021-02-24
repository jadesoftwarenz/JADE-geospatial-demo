# JADE GeoSpatial Demo

These instructions will get the JADE GeoSpatial demonstration application running. The JADE GeoSpatial demo is a .NET application written in C# which uses JADE's .NET exposure functionality to expose GeoSpatial functionality.

As this demo uses .NET, you will need Visual Studio 2017 and .NET Framework 4.7.1 installed on your machine.

If you want to skip these instructions, you can run a script which will perform the steps automatically.
This script will create a dedicated JADE database for use with the demo, so you need to specify where to put that database to avoid it interfering with any existing JADE database on your computer:

- Modify the __run-config.ps1__ script in the __/scripts/config/__ folder:
  - Set the __$jadeRootDirectory__ variable to the path where you want the database generated.
- You can now run the __deploy-demo.ps1__ script from the __/scripts/__ folder.

## Set up a JADE Database

The .NET GeoSpatial demo will connect to a JADE database, which will be responsible for maintaining the geospatial data. As such, you will need a JADE Database. You can either use an existing JADE database, or you can have one generated for you.

### If you want to use your existing database

- Modify the __run-config.ps1__ script in the __/config/__ folder:
  - Set the __$jadeRootDirectory__ variable to the path of your JADE install directory.
  - If your database directory is called something other than "system", set the __$jadeDatabaseDirectory__ variable as required.
  - Set the __$jadeJournalRootDirectory__ variable to the directory where your journals are saved.
  - If your JADE ini file is called something other than __system.ini__, set the __$iniFile__ variable to the name of your JADE ini file.
  
### If you want to use a generated database

- Modify the __run-config.ps1__ script in the __/scripts/config/__ folder:
  - Set the __$jadeRootDirectory__ variable to the path where you want the database generated.
  - Update licence information if required (a default free licence key is provided)
    - Set the __$regName__ variable to the company name associated with your licence
    - Set the __$regKey__ variable to your assigned licence key

- Run the __initialize-host-database.ps1__ script from the __/scripts/__ folder. This will generate the following into the folder specified in the __$jadeRootDirectory__ variable of the __run-config.ps1__ script.
  - A __bin__ folder, with the required .bin, .dll, and executable files.
  - A __journals__ folder, which will initially be empty.
  - A __logs__ folder, which will initially be empty.
  - A __system__ folder, with a set of fresh JADE database files.
  - A __jade.ini__ file, with a set of default ini file settings.

## Loading the GeoSpatial schema

When loading the GeoSpatial schema, you don't need to start an IDE - it can be done automatically with the schema loader application.

To load the GeoSpatial schema

- Run the __loadSchema.ps1__ script from the __/scripts/__ folder.

## Building the .NET application

You can build the .NET application from the Visual Studio IDE or by using an MSBuild script.

### Building from Visual Studio

- Open __SpatialDemoExposure.sln__ in Visual Studio.
- Build the solution (default hotkey Ctrl+Shift+B).
- You can now directly run the demo application from Visual Studio with the F5 key.

### Building with MSBuild

To build the solution without starting Visual Studio you can use MSBuild. The __/scripts/build.ps1__ script will perform the necessary steps, which are to set the environment variables required for MSBuild, then uses it to restore the nuget package containing the necesssary joob dlls and build the solution.

## Running the .NET application

Once the database is ready and the .NET application is built, you can run the application either from the IDE or running the __JoobSpatialDemo.exe__ file generated in the __/bin/x64/Debug/__ directory.

## Using the .NET application

Now that the application is running, you will first want to import some example data.

- From the __File__ menu, select __Load Default Data__.
- A warning message will appear, warning that it might take a while - click Yes.

The application will automatically load geospatial data for the States, Counties and Cities of the United States of America.

To see a map of this data, select the layers that you want (for example, States and Counties) then click the __Search__ button. A zoomable map will be generated in the right-hand pane.
