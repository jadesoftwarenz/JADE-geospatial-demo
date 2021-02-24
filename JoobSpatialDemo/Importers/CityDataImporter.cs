using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using JadeSoftware.Joob;
using JadeSoftware.Joob.Client;
using SpatialDemoExposure;

namespace JoobSpatialDemo.Importers
{
    public class CityDataImporter : JoobDataImporter<City>
    {
        public CityDataImporter(string filename)
            : base(filename)
        {
        }

        protected override bool ParseLine(string line, Root root, out City result)
        {
            try
            {
                var tokens = line.Split(new[] { ',' }, 6);

                var id = int.Parse(tokens[0]);
                var name = tokens[1];
                var population = int.Parse(tokens[2]);
                var stateAbbr = tokens[3];
                var countyName = tokens[4];
                var geom = new JoobGeometry(tokens[5]);

                State state;
                if (!root.AllStatesByAbbr.TryGetValue(stateAbbr, out state))
                {
                    state = null;
                }

                County county;
                if (!root.AllCountiesByName.TryGetValue(countyName, out county))
                {
                    county = null;
                }

                result = new City
                {
                    Id = id,
                    Name = name,
                    Population = population,
                    Geom = geom,
                    MyRoot = root,
                    MyState = state,
                    MyCounty = county,
                };

                return true;
            }
            catch (Exception)
            {
                result = null;
                return false;
            }
        }
    }
}
