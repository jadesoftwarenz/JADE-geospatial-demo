using System;
using JadeSoftware.Joob;
using SpatialDemoExposure;

namespace JoobSpatialDemo.Importers
{
    class PeopleDataImporter : JoobDataImporter<Person>
    {
        private int _counter;

        public PeopleDataImporter(string filename)
            : base(filename)
        {
        }

        protected override bool ParseLine(string line, Root root, out Person result)
        {
            try
            {
                var geom = new JoobGeometry(line);

                result = new Person
                {
                    Id = _counter++,
                    Geom = geom,
                };
                root.AllPeopleByGeom.Add(result);

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