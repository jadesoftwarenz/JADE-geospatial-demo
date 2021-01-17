using System.Diagnostics;
using JadeSoftware.Joob;
using JadeSoftware.Joob.Client;
using SpatialDemoExposure;

namespace JoobSpatialDemo.Importers
{
    class SpatialLayerDataImporter : JoobDataImporter<JoobGeometry>
    {
        private readonly string _layerName;
        private SpatialLayer _layer;

        public SpatialLayerDataImporter(string layerName, string dataPath)
            : base(dataPath)
        {
            _layerName = layerName;
        }

        protected override void Prepare(JoobContext ctx, Root root)
        {
            _layer = new SpatialLayer { Name = _layerName };
            root.OtherSpatialLayers.Add(_layer);
        }

        protected override bool ParseLine(string line, Root root, out JoobGeometry result)
        {
            Debug.Assert(_layer != null);

            try
            {
                result = new JoobGeometry(line);
                _layer.Geometries.Add(result, result);

                return true;
            }
            catch
            {
                result = null;
                return false;
            }
        }
    }
}
