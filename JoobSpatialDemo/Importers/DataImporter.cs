using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;

namespace JoobSpatialDemo.Importers
{
    abstract class DataImporter<T> : IDataImporter
    {
        private readonly string _filename;
        private BackgroundWorker _worker;

        protected DataImporter(string filename)
        {
            if (string.IsNullOrWhiteSpace(filename)) throw new ArgumentNullException("filename");
            if (!File.Exists(filename)) throw new ArgumentException(@"Cannot find the specified file", "filename");

            _filename = filename;
        }

        public event ProgressChangedDelegate ProgressChanged;

        public event ImportCompletedDelegate ImportCompleted;

        public int ImportAsync()
        {
            var totalLines = 0;

            var enumerator = File.ReadLines(_filename).GetEnumerator();
            if (enumerator.MoveNext())
            {
                if (!int.TryParse(enumerator.Current, out totalLines))
                {
                    throw new FormatException("Incompatible file format");
                }

                _worker = new BackgroundWorker
                {
                    WorkerReportsProgress = true,
                    WorkerSupportsCancellation = true,
                };

                _worker.DoWork += WorkerDoWork;
                _worker.ProgressChanged += WorkerProgressChanged;
                _worker.RunWorkerCompleted += WorkerRunWorkerCompleted;

                _worker.RunWorkerAsync(new WorkerParameter { Enumerator = enumerator, TotalLines = totalLines });
            }

            return totalLines;
        }

        protected bool CancellationPending
        {
            get { return _worker.CancellationPending; }
        }

        public void Cancel()
        {
            _worker.CancelAsync();
        }

        private void WorkerDoWork(object sender, DoWorkEventArgs e)
        {
            var param = (WorkerParameter)e.Argument;
            param.HasFatalError = !Import(param);

            e.Result = param;
        }

        protected abstract bool Import(WorkerParameter parameter);

        protected void ReportProgress(int progress, string userState = null)
        {
            if (_worker != null && _worker.WorkerReportsProgress)
            {
                _worker.ReportProgress(progress, userState);
            }
        }

        private void WorkerProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (ProgressChanged != null)
            {
                ProgressChanged.Invoke(this, e);
            }
        }

        private void WorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            var param = (WorkerParameter)e.Result;
            if (param.Enumerator != null)
            {
                param.Enumerator.Dispose();
            }

            if (ImportCompleted != null)
            {
                ImportCompleted.Invoke(this, new ImportCompletedEventArgs(param.ImportedObjects, param.NumIgnored, param.UserCancelled));
            }
        }

        protected class WorkerParameter
        {
            public IEnumerator<string> Enumerator;
            public int TotalLines;
            public readonly List<T> ImportedObjects = new List<T>();
            public int NumIgnored;
            public bool UserCancelled;
            public bool HasFatalError;
        }

        #region IDataImporter Members



        #endregion
    }
}
