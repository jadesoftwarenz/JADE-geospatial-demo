using JadeSoftware.Joob.Client;
using JoobSpatialDemo;
using System;
using System.Linq;
using System.Threading;
using System.ComponentModel;
using JoobSpatialDemo.Importers;

namespace JoobSpatialLoader
{
    class JoobLoader
    {
        private int ImportDone;

        static void Main(string[] args)
        {
            var loader = new JoobLoader();
            loader.LoadData();
        }

        public void LoadData()
        {
            using (new JoobContext())
            {
                if (MapDataAdapter.GetAllLayers().First().GeometryCount == 0)
                {
                    //////////   Load the STATES.   ///////////////////////////////////
                    Console.WriteLine("Loading States:");
                    var stateImporter = new StateDataImporter(@".\..\JoobSpatialDemo\Data\US_States.txt");
                    stateImporter.ImportCompleted += ImporterCompleted;
                    stateImporter.ProgressChanged += ImporterProgressChanged;
                    stateImporter.ImportAsync();
                    while (ImportDone < 1)
                    {
                        Thread.Sleep(1);
                    }
                    Console.WriteLine("\rStates loaded.      ");
                    ////////////////////////////////////////////////////////////////////

                    //////////   Load the COUNTIES.   //////////////////////////////////
                    Console.WriteLine("Loading Counties:");
                    var countyImporter = new CountyDataImporter(@".\..\JoobSpatialDemo\Data\US_Counties.txt");
                    countyImporter.ImportCompleted += ImporterCompleted;
                    countyImporter.ProgressChanged += ImporterProgressChanged;
                    countyImporter.ImportAsync();
                    while (ImportDone < 2)
                    {
                        Thread.Sleep(1);
                    }
                    Console.WriteLine("\rCounties loaded.        ");
                    ////////////////////////////////////////////////////////////////////

                    //////////   Load the CITIES.   ////////////////////////////////////
                    Console.WriteLine("Loading Cities:");
                    var cityImporter = new CityDataImporter(@".\..\JoobSpatialDemo\Data\US_Cities.txt");
                    cityImporter.ImportCompleted += ImporterCompleted;
                    cityImporter.ProgressChanged += ImporterProgressChanged;
                    cityImporter.ImportAsync();
                    while (ImportDone < 3)
                    {
                        Thread.Sleep(1);
                    }
                    Console.WriteLine("\rCities loaded.       ");
                    ////////////////////////////////////////////////////////////////////
                }
            }
        }

        private void ImporterCompleted(object sender, ImportCompletedEventArgs e)
        {
            ImportDone++;
        }

        private void ImporterProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            Console.Write("\r    Loaded: {0}      ", e.ProgressPercentage.ToString());
        }
    }
}
