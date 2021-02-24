using System;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using DotSpatial.Topology;

namespace JoobSpatialDemo
{
    public partial class AddLayerForm : Form
    {
        private static int _layerNoCounter = 1;

        public AddLayerForm()
        {
            InitializeComponent();
            AcceptButton = null;
            cmbType.SelectedIndex = 0;
        }

        public string LayerName { get; private set; }

        public FeatureType FeatureType { get; private set; }

        public string DataPath { get; private set; }

        public bool DisplayAfterImportation { get; private set; }

        private void BrowseClick(object sender, EventArgs e)
        {
            var dialog = new OpenFileDialog
                             {
                                 Title = @"Import data from...",
                                 CheckPathExists = true,
                                 CheckFileExists = true,
                                 Multiselect = false,
                                 InitialDirectory = Path.Combine(Application.StartupPath, "Data"),
                             };

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                txtPath.Text = dialog.FileName;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (ValidateName() && ValidateDataPath())
            {
                LayerName = string.IsNullOrWhiteSpace(txtName.Text) ? string.Format("Unnamed Layer {0}", _layerNoCounter++) : txtName.Text;

                FeatureType type;
                if (Enum.TryParse(cmbType.SelectedText, out type))
                {
                    FeatureType = type;
                }

                DataPath = txtPath.Text;
                DisplayAfterImportation = chbDisplayAfterImport.Checked;

                DialogResult = DialogResult.OK;
                AcceptButton = btnOK;
            }
        }

        private void CancelClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Dispose();
        }

        private void txtName_Validating(object sender, CancelEventArgs e)
        {
            ValidateName();
        }

        private void txtPath_TextChanged(object sender, EventArgs e)
        {
            ValidateDataPath();
        }

        private bool ValidateName()
        {
            string error = null;
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                error = "Please enter a name";
            }
            else if (MapDataAdapter.GetAllLayers().Any(item => item.Name.Equals(txtName.Text, StringComparison.OrdinalIgnoreCase)))
            {
                error = "The layer name already exists";
            }

            errPrvAddLayer.DisplayError(txtName, error);
            return error == null;
        }

        private bool ValidateDataPath()
        {
            string error = null;
            if (string.IsNullOrWhiteSpace(txtPath.Text))
            {
                error = "Please enter a data path";
            }
            else if (!File.Exists(txtPath.Text))
            {
                error = "The file entered does not exist";
            }

            errPrvAddLayer.DisplayError(btnBrowse, error);
            return error == null;
        }
    }
}
