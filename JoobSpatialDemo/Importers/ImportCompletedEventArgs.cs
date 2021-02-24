using System.Collections;

namespace JoobSpatialDemo.Importers
{
    public class ImportCompletedEventArgs
    {
        public ImportCompletedEventArgs(IEnumerable importedObjects) : this(importedObjects, 0) { }

        public ImportCompletedEventArgs(IEnumerable importedObjects, int numIgnored) : this(importedObjects, numIgnored, false) { }

        public ImportCompletedEventArgs(IEnumerable importedObjects, int numIgnored, bool cancelled)
        {
            UserCancelled = cancelled;
            ImportedObjects = importedObjects;
            NumIgnored = numIgnored;
        }

        public bool UserCancelled { get; private set; }

        public IEnumerable ImportedObjects { get; private set; }

        public int NumIgnored { get; private set; }
    }
}
