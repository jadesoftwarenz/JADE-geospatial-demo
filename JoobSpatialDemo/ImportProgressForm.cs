using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using JoobSpatialDemo.Importers;

namespace JoobSpatialDemo
{
    partial class ImportProgressForm : Form
    {
        private readonly IDataImporter _importer;
        private IEnumerable _importedObjects;

        public ImportProgressForm(IDataImporter importer, string dataName = null)
        {
            InitializeComponent();

            if (!string.IsNullOrEmpty(dataName))
            {
                Text = string.Format(@"Importing {0}...", dataName);
            }

            _importer = importer;
            _importer.ProgressChanged += ImporterProgressChanged;
            _importer.ImportCompleted += ImporterCompleted;

            lblStatus.Visible = true;
            lblIgnoredCount.Visible = false;
            lblIgnored.Visible = false;

            btnContiue.Visible = false;
            lnkCancel.Visible = true;
        }

        public override sealed string Text
        {
            get { return base.Text; }
            set { base.Text = value; }
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            var totalWork = _importer.ImportAsync();
            if (totalWork > 0)
            {
                pgbImport.Maximum = totalWork;
            }
        }

        private void ImporterProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            pgbImport.Value = e.ProgressPercentage;
            lblImportCount.Text = e.ProgressPercentage.ToString();

            var status = e.UserState == null ? "Importing..." : e.UserState.ToString();
            lblStatus.Text = status;
            if (status.StartsWith("Committing", StringComparison.OrdinalIgnoreCase))
            {
                lnkCancel.Visible = false;
            }
        }

        public void ImporterCompleted(object sender, ImportCompletedEventArgs e)
        {
            pgbImport.Value = pgbImport.Maximum;

            _importedObjects = e.ImportedObjects;
            var count = _importedObjects == null ? 0 : _importedObjects.Cast<object>().Count();
            lblImportCount.Text = count.ToString();

            lblStatus.Visible = false;
            lnkCancel.Visible = false;
            btnContiue.Visible = true;

            if (e.NumIgnored > 0)
            {
                lblIgnoredCount.Text = e.NumIgnored.ToString();
                lblIgnoredCount.Visible = true;
                lblIgnored.Visible = true;
            }
            else
            {
                DialogResult = DialogResult.OK;
                Dispose();
            }
        }

        public IEnumerable<T> GetImportedObjects<T>()
        {
            if (_importedObjects == null)
            {
                return new T[0];
            }

            return _importedObjects.Cast<T>();
        }

        private void CancelClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (MessageBox.Show(this, @"Are you sure you want to cancel the importation?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                _importer.Cancel();
                lnkCancel.Enabled = false;
            }
        }
    }
}
