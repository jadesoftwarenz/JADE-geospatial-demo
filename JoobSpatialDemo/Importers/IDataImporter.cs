using System.ComponentModel;

namespace JoobSpatialDemo.Importers
{
    delegate void ProgressChangedDelegate(object sender, ProgressChangedEventArgs e);

    delegate void ImportCompletedDelegate(object sender, ImportCompletedEventArgs e);

    interface IDataImporter
    {
        event ProgressChangedDelegate ProgressChanged;

        event ImportCompletedDelegate ImportCompleted;

        int ImportAsync();

        void Cancel();
    }
}
