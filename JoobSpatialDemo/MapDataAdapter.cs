using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using DotSpatial.Data;
using DotSpatial.Projections;
using DotSpatial.Projections.Transforms;
using DotSpatial.Topology;
using DotSpatial.Topology.Utilities;
using JadeSoftware.Joob;
using JadeSoftware.Joob.Client;
using SpatialDemoExposure;

namespace JoobSpatialDemo
{
    class MapDataAdapter
    {
        public const string SRID_WGS84 = "+proj=longlat +ellps=WGS84 +datum=WGS84 +no_defs";
        public const string SRID_NAD83_GRS80 = "+proj=aea +lat_1=37 +lat_2=41 +lat_0=0 +lon_0=-79 +x_0=0 +y_0=0 +ellps=GRS80 +datum=NAD83 +units=m +no_defs";
        public const string SRID_None = "+ellps=WGS84 +no_defs";

        public const string FeatureTypeStates = "States";
        public const string FeatureTypeCounties = "Counties";
        public const string FeatureTypeCities = "Cities";

        private static MapDataAdapter _current;
        private static readonly List<LayerInfo> _predefinedLayerNames = new List<LayerInfo>();

        private MapDataAdapter()
        {
        }

        public static MapDataAdapter Current
        {
            get { return _current ?? (_current = new MapDataAdapter()); }
        }

        private static void PopulatePredefinedLayers()
        {
            _predefinedLayerNames.Clear();
            _predefinedLayerNames.AddRange(new[]
            {
                new LayerInfo(FeatureTypeStates, StateCount),
                new LayerInfo(FeatureTypeCounties, CountyCount),
                new LayerInfo(FeatureTypeCities, CityCount),
            });
        }

        private static Root TheRoot
        {
            get
            {
                Debug.Assert(JoobContext.CurrentContext != null);
                var root = JoobContext.CurrentContext.FirstInstance<Root>();

                if (root == null)
                {
                    using (var tr = JoobContext.CurrentContext.BeginTransaction())
                    {
                        root = new Root();
                        tr.Commit();
                    }
                }

                return root;
            }
        }

        private static int StateCount { get { return TheRoot.AllStatesByGeom.Count; } }

        private static int CountyCount { get { return TheRoot.AllCountiesByGeom.Count; } }

        private static int CityCount { get { return TheRoot.AllCitiesByGeom.Count; } }

        public static IEnumerable<LayerInfo> GetAllLayers()
        {
            PopulatePredefinedLayers();
            var result = new List<LayerInfo>(_predefinedLayerNames);

            var ctx = JoobContext.CurrentContext;
            Debug.Assert(ctx != null);

            var root = ctx.FirstInstance<Root>();
            if (root != null)
            {
                result.AddRange(from layer in root.OtherSpatialLayers
                                select new LayerInfo(layer.Name, layer.Geometries.Count));
            }

            return result;
        }

        public static void Reset()
        {
            //using (var tr = JoobContext.CurrentContext.BeginTransaction())
            //{
            //    TheRoot.Delete();
            //    tr.Commit();
            //}
        }

        public static JoobGeometry GetStateGeomByAbbr(string abbr)
        {
            Debug.Assert(!string.IsNullOrWhiteSpace(abbr));

            if (TheRoot.AllStatesByAbbr.TryGetValue(abbr, out State result))
            {
                return result.Geom;
            }

            return null;
        }

        public static IEnumerable<FeatureSet> SpatialSearch(IEnumerable<LayerInfo> layerInfos, SearchRegion region, MultiDimensionalObjectRelationship relationship, out long totalSearchTime)
        {
            totalSearchTime = 0;
            var result = new List<FeatureSet>();

            foreach (var info in layerInfos)
            {
                long searchTime;
                if (info.Name.Equals(FeatureTypeStates, StringComparison.OrdinalIgnoreCase))
                {
                    var featureSet = SpatialSearch(TheRoot.AllStatesByGeom, info.Name, FeatureType.Polygon, region, relationship, out searchTime);
                    if (featureSet != null)
                    {
                        result.Add(featureSet);
                    }
                }
                else if (info.Name.Equals(FeatureTypeCounties, StringComparison.OrdinalIgnoreCase))
                {
                    var featureSet = SpatialSearch(TheRoot.AllCountiesByGeom, info.Name, FeatureType.Polygon, region, relationship, out searchTime);
                    if (featureSet != null)
                    {
                        result.Add(featureSet);
                    }
                }
                else if (info.Name.Equals(FeatureTypeCities, StringComparison.OrdinalIgnoreCase))
                {
                    var featureSet = SpatialSearch(TheRoot.AllCitiesByGeom, info.Name, FeatureType.Point, region, relationship, out searchTime);
                    if (featureSet != null)
                    {
                        result.Add(featureSet);
                    }
                }
                else
                {
                    var layer = SpatialSearchOtherSpatialLayers(info.Name, region, relationship, out searchTime);
                    if (layer != null)
                    {
                        result.Add(layer);
                    }
                }

                totalSearchTime += searchTime;
            }

            return result;
        }

        private static FeatureSet SpatialSearch<TMdo, TVal>(JoobRTree<TMdo, TVal> rtree, string name, FeatureType type, SearchRegion region, MultiDimensionalObjectRelationship relationship, out long searchTime)
            where TMdo : JoobObject, IMultiDimensionalObject
            where TVal : JoobObject
        {
            if (rtree.Count > 0)
            {
                var projection = ProjectionInfo.FromProj4String(SRID_WGS84);
                projection.Transform = new Transform();
                var featureSet = new FeatureSet(type)
                {
                    Name = name,
                    Projection = projection       
                };
                
                var watch = new Stopwatch();
                watch.Start();

                var result = region == null
                    ? rtree.Where(item => item as ObjectWithSpatialInfo != null).Cast<ObjectWithSpatialInfo>().Select(item => item.Geom).ToList()
                    : rtree.Search(region.Envelope as TMdo, relationship).Select(item => item.Key as JoobGeometry).ToList();

                watch.Stop();
                searchTime = watch.ElapsedMilliseconds;

                PopulateFeatureSet(result, featureSet);
                return featureSet;
            }

            searchTime = 0;
            return null;
        }

        private static FeatureSet SpatialSearchOtherSpatialLayers(string layerName, SearchRegion region, MultiDimensionalObjectRelationship relationship, out long searchTime)
        {
            var layer = TheRoot.OtherSpatialLayers[layerName];
            if (layer != null)
            {
                var featureSet = new FeatureSet(FeatureType.Unspecified)
                {
                    Name = layerName,
                    //Projection = new ProjectionInfo(SRID_None) { Transform = new Transform() }
                };

                var watch = new Stopwatch();
                watch.Start();

                var result = region == null ? layer.Geometries.Cast<JoobGeometry>().ToList()
                    : layer.Geometries.Search(region.Envelope, relationship).Select(item => item.Key);

                watch.Stop();
                searchTime = watch.ElapsedMilliseconds;

                PopulateFeatureSet(result, featureSet);
                return featureSet;
            }

            searchTime = 0;
            return null;
        }

        public static IEnumerable<FeatureSet> NameSearch(IEnumerable<LayerInfo> layerInfos, SearchRegion region, out long totalSearchTime)
        {
            Debug.Assert(region != null);

            totalSearchTime = 0;
            var result = new List<FeatureSet>();

            foreach (var info in layerInfos)
            {
                long searchTime = 0;
                if (info.Name.Equals(FeatureTypeStates, StringComparison.OrdinalIgnoreCase))
                {
                    var featureSet = NameSearchState(info.Name, FeatureType.Polygon, region, out searchTime);
                    if (featureSet != null)
                    {
                        result.Add(featureSet);
                    }
                }
                else if (info.Name.Equals(FeatureTypeCities, StringComparison.OrdinalIgnoreCase))
                {
                    var featureSet = NameSearchCity(info.Name, FeatureType.Point, region, out searchTime);
                    if (featureSet != null)
                    {
                        result.Add(featureSet);
                    }
                }

                totalSearchTime += searchTime;
            }

            return result;
        }

        private static FeatureSet NameSearchState(string name, FeatureType type, SearchRegion region, out long searchTime)
        {
            var watch = new Stopwatch();
            watch.Start();

            if (TheRoot.AllStatesByAbbr.TryGetValue(region.Abbr, out State result))
            {
                watch.Stop();
                searchTime = watch.ElapsedMilliseconds;
                var projection = ProjectionInfo.FromProj4String(SRID_WGS84);
                projection.Transform = new Transform();
                var featureSet = new FeatureSet(type)
                {
                    Name = name,
                    Projection = projection,
                };
                PopulateFeatureSet(new[] { result.Geom }, featureSet);
                return featureSet;
            }

            watch.Stop();
            searchTime = 0;
            return null;
        }

        private static FeatureSet NameSearchCity(string name, FeatureType type, SearchRegion region, out long searchTime)
        {
            if (TheRoot.AllStatesByAbbr.TryGetValue(region.Abbr, out State state))
            {
                var projection = ProjectionInfo.FromProj4String(SRID_WGS84);
                projection.Transform = new Transform();
                var featureSet = new FeatureSet(type)
                {
                    Name = name,
                    Projection = projection,
                };
                var watch = new Stopwatch();
                watch.Start();

                var result = state.AllCitiesByName.Select(item => item.Geom).ToList();

                watch.Stop();
                searchTime = watch.ElapsedMilliseconds;

                PopulateFeatureSet(result, featureSet);
                return featureSet;
            }

            searchTime = 0;
            return null;
        }

        public static void PopulateFeatureSet(IEnumerable<JoobGeometry> geometries, IFeatureSet featureSet)
        {
            if (geometries != null && geometries.Count() > 0)
            {
                var reader = new WkbReader();

                var minX = double.PositiveInfinity;
                var minY= double.PositiveInfinity;
                var maxX = double.NegativeInfinity;
                var maxY = double.NegativeInfinity;

                foreach (var geom in geometries.Where(g => g != null))
                {
                    var feature = reader.Read(geom.GeoData);
                    var envelope = feature.Envelope;
                    if (envelope != null)
                    {
                        if (envelope.Minimum.X < minX)
                            minX = envelope.Minimum.X;

                        if (envelope.Minimum.Y < minY)
                            minY = envelope.Minimum.Y;

                        if (envelope.Maximum.X > maxX)
                            maxX = envelope.Maximum.X;

                        if (envelope.Maximum.Y > maxY)
                            maxY = envelope.Maximum.Y;
                    }

                    featureSet.AddFeature(feature);
                }

                if (!double.IsInfinity(minX)) featureSet.Extent.MinX = minX;
                if (!double.IsInfinity(minY)) featureSet.Extent.MinY = minY;
                if (!double.IsInfinity(maxX)) featureSet.Extent.MaxX = maxX;
                if (!double.IsInfinity(maxY)) featureSet.Extent.MaxY = maxY;
            }
        }
    }
}
