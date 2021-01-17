namespace JoobSpatialDemo
{
    public class LayerInfo
    {
        public LayerInfo(string name, int geomCount)
        {
            Name = name;
            GeometryCount = geomCount;
        }

        public string Name { get; set; }

        public int GeometryCount { get; set; }

        public override string ToString()
        {
            return string.Format("{0} ({1})", Name, GeometryCount);
        }
    }
}
