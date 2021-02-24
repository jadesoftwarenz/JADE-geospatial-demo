using System;
using JadeSoftware.Joob;
using SpatialDemoExposure;

namespace JoobSpatialDemo.Importers
{
    public class StateDataImporter : JoobDataImporter<State>
    {
        public StateDataImporter(string filename)
            : base(filename)
        {
        }

        protected override bool ParseLine(string line, Root root, out State result)
        {
            try
            {
                var tokens = line.Split(new[] { ',' }, 3);

                var abbr = tokens[0];
                var name = tokens[1];
                var geom = new JoobGeometry(tokens[2]);

                result = new State
                {
                    Abbr = abbr,
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
