using System.Collections.Generic;
using System.Diagnostics;
using JadeSoftware.Joob;

namespace JoobSpatialDemo
{
    public class SearchRegion
    {
        public static readonly List<SearchRegion> PredefinedSearchRegions = new List<SearchRegion>();

        static SearchRegion()
        {
            PopulatePredefinedRegions();
        }

        public static void PopulatePredefinedRegions()
        {
            if (PredefinedSearchRegions.Count == 0)
            {
                var geom = MapDataAdapter.GetStateGeomByAbbr("CA");
                if (geom != null) PredefinedSearchRegions.Add(new SearchRegion("CA", "California", geom));

                geom = MapDataAdapter.GetStateGeomByAbbr("FL");
                if (geom != null) PredefinedSearchRegions.Add(new SearchRegion("FL", "Florida", geom));

                geom = MapDataAdapter.GetStateGeomByAbbr("HI");
                if (geom != null) PredefinedSearchRegions.Add(new SearchRegion("HI", "Hawaii", geom));

                geom = MapDataAdapter.GetStateGeomByAbbr("KY");
                if (geom != null) PredefinedSearchRegions.Add(new SearchRegion("KY", "Kentucky", geom));

                geom = MapDataAdapter.GetStateGeomByAbbr("NV");
                if (geom != null) PredefinedSearchRegions.Add(new SearchRegion("NV", "Nevada", geom));

                geom = MapDataAdapter.GetStateGeomByAbbr("TX");
                if (geom != null) PredefinedSearchRegions.Add(new SearchRegion("TX", "Texas", geom));

                geom = MapDataAdapter.GetStateGeomByAbbr("WA");
                if (geom != null) PredefinedSearchRegions.Add(new SearchRegion("WA", "Washington", geom));
            }
        }

        private readonly double _minX;
        private readonly double _minY;
        private readonly double _maxX;
        private readonly double _maxY;
        private JoobGeometry _envelope;

        public SearchRegion(string abbr, string name, JoobGeometry geometry)
        {
            Debug.Assert(geometry != null);

            Abbr = abbr;
            Name = name;
            _envelope = geometry;
        }

        public SearchRegion(string name, double minX, double minY, double maxX, double maxY)
        {
            Name = name;
            _minX = minX;
            _minY = minY;
            _maxX = maxX;
            _maxY = maxY;
        }

        public string Abbr { get; private set; }

        public string Name { get; private set; }

        public JoobGeometry Envelope
        {
            get
            {
                if (_envelope == null)
                {
                    var builder = new JoobGeometryBuilder();
                    builder.BeginGeometry(GeometryType.Polygon);
                    builder.BeginFigure(_minX, _minY);
                    builder.AddLine(_maxX, _minY);
                    builder.AddLine(_maxX, _maxY);
                    builder.AddLine(_minX, _maxY);
                    builder.AddLine(_minX, _minY);
                    builder.EndFigure();
                    builder.EndGeometry();

                    _envelope = builder.GetConstructedGeometry(ClassPersistence.Transient);
                }

                return _envelope;
            }
        }
    }
}
