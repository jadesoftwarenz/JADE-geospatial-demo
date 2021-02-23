using System.ComponentModel;

namespace JoobSpatialDemo.Importers
{
    public delegate void ProgressChangedDelegate(object sender, ProgressChangedEventArgs e);

    public delegate void ImportCompletedDelegate(object sender, ImportCompletedEventArgs e);

    interface IDataImporter
    {
        event ProgressChangedDelegate ProgressChanged;

        event ImportCompletedDelegate ImportCompleted;

        int ImportAsync();

        void Cancel();
    }
}
