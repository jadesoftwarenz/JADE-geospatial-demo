using System;
using JadeSoftware.Joob;
using SpatialDemoExposure;

namespace JoobSpatialDemo.Importers
{
    class CountyDataImporter : JoobDataImporter<County>
    {
        public CountyDataImporter(string filename)
            : base(filename)
        {
        }

        protected override bool ParseLine(string line, Root root, out County result)
        {
            try
            {
                var tokens = line.Split(new[] { ',' }, 2);

                var name = tokens[0];
                var geom = new JoobGeometry(tokens[1]);

                result = new County
                {
                    Name = name,
                    Geom = geom,
                    MyRoot = root,
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
