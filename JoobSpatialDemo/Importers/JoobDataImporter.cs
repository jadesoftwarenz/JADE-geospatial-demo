using System.Data;
using System.Diagnostics;
using JadeSoftware.Joob.Client;
using SpatialDemoExposure;

namespace JoobSpatialDemo.Importers
{
    public abstract class JoobDataImporter<T> : DataImporter<T>
    {
        protected JoobDataImporter(string filename)
            : base(filename)
        {
        }

        protected override bool Import(WorkerParameter workParam)
        {
            var totalLines = workParam.TotalLines;
            var enumerator = workParam.Enumerator;
            var workBlock = totalLines < 500 ? 5 : totalLines / 100;

            try
            {
                using (var ctx = new JoobContext())
                {
                    using (var tx = ctx.BeginTransaction())
                    {
                        ReportProgress(0, "Opening database...");

                        var root = ctx.FirstInstance<Root>() ?? new Root();
                        if (!ContinueWork(tx, workParam)) return false;

                        Prepare(ctx, root);

                        var counter = 0;
                        ReportProgress(0, "Importing data...");

                        while (enumerator.MoveNext())
                        {
                            if (!ContinueWork(tx, workParam)) return false;

                            var line = enumerator.Current;

                            if (line.StartsWith("--"))
                            {
                                continue;
                            }

                            T result;
                            if (ParseLine(line, root, out result))
                            {
                                workParam.ImportedObjects.Add(result);

                                counter++;
                                if (counter % workBlock == 0)
                                {
                                    ReportProgress(counter);
                                }
                            }
                            else
                            {
                                workParam.NumIgnored++;
                            }
                        }

                        //Debug.Assert(workParam.ImportedObjects.Count + workParam.NumIgnored == totalLines);

                        ReportProgress(counter, "Committing changes...");
                        tx.Commit();
                    }
                }

                return true;
            }
            catch
            {
                workParam.ImportedObjects.Clear();
                workParam.NumIgnored = totalLines;
                return false;
            }
        }

        protected virtual void Prepare(JoobContext ctx, Root root)
        {
        }

        protected abstract bool ParseLine(string line, Root root, out T result);

        private bool ContinueWork(IDbTransaction trans, WorkerParameter workParam)
        {
            if (CancellationPending)
            {
                ReportProgress(0, "Rolling back changes...");

                if (workParam != null)
                {
                    workParam.UserCancelled = true;
                    workParam.ImportedObjects.Clear();
                }

                if (trans != null)
                {
                    trans.Rollback();
                }

                return false;
            }

            return true;
        }
    }
}
