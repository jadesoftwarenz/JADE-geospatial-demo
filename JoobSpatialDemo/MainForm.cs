using System;
using System.Windows.Forms;
using DotSpatial.Controls;
using DotSpatial.Data;
using DotSpatial.Symbology;
using JadeSoftware.Joob;
using JoobSpatialDemo.Importers;

namespace JoobSpatialDemo
{
    public partial class MainForm : Form
    {
        private readonly MapSearchControl _searchCtrl;

        public MainForm()
        {
            InitializeComponent();

            if (toolBar != null && toolBar.Items.Count >= 13)
            {
                //Hide unsupported actions
                toolBar.Items[0].Visible = false;
                toolBar.Items[1].Visible = false;
                toolBar.Items[2].Visible = false;
                toolBar.Items[3].Visible = false;
                toolBar.Items[4].Visible = false;
                toolBar.Items[11].Visible = false;
                toolBar.Items[12].Visible = false;
                //toolBar.Items[5].Visible = true;     // Hand
                //toolBar.Items[6].Visible = true;     // Select
                //toolBar.Items[7].Visible = true;     // Zoom in
                //toolBar.Items[8].Visible = true;     // Zoom out
                //toolBar.Items[9].Visible = true;     // Zoom prev
                //toolBar.Items[10].Visible = true;    // Zoom next
                //toolBar.Items[13].Visible = true;    // Zoom max
                //toolBar.Items[14].Visible = true;    // Measure distance
            }

            if (legend.RootNodes.Count > 0)
            {
                var ctxMenuItems = legend.RootNodes[0].ContextMenuItems;
                ctxMenuItems.Clear();
                ctxMenuItems.Add(new SymbologyMenuItem("Add Layer...", AddLayerHandler));
            }

            _searchCtrl = new MapSearchControl(this, map);
            tabSearch.Controls.Add(_searchCtrl);
        }

        private void MenuItemExit_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void MenuItemToolBar_Click(object sender, EventArgs e)
        {
            mItemToolBar.Checked = !mItemToolBar.Checked;
            toolBar.Visible = mItemToolBar.Checked;
            if (toolBar.Visible)
            {
                switch (map.FunctionMode)
                {
                    case FunctionMode.Select:
                        toolBar.Items[6].Select();
                        break;
                    case FunctionMode.ZoomIn:
                        toolBar.Items[7].Select();
                        break;
                    default:
                        //Select "Pan" by default
                        toolBar.Items[5].Select();
                        map.FunctionMode = FunctionMode.Pan;
                        break;
                }
            }
            else
            {
                map.FunctionMode = FunctionMode.Pan;
            }
        }

        private void MenuItemStatusBar_Click(object sender, EventArgs e)
        {
            mItemStatusBar.Checked = !mItemStatusBar.Checked;
            statusBar.Visible = mItemStatusBar.Checked;
        }

        private void MenuItemLoadDefaultData_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show(this, @"Loading default data may take a long time, do you want to continue?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            if (result == DialogResult.Yes)
            {
                try
                {
                    MapDataAdapter.Reset();

                    var importForm = new ImportProgressForm(new StateDataImporter(@"Data\US_States.txt"), MapDataAdapter.FeatureTypeStates);
                    var toContinue = importForm.ShowDialog(this) == DialogResult.OK;

                    if (toContinue)
                    {
                        importForm = new ImportProgressForm(new CountyDataImporter(@"Data\US_Counties.txt"), MapDataAdapter.FeatureTypeCounties);
                        toContinue = importForm.ShowDialog(this) == DialogResult.OK;
                    }

                    if (toContinue)
                    {
                        importForm = new ImportProgressForm(new CityDataImporter(@"Data\US_Cities.txt"), MapDataAdapter.FeatureTypeCities);
                        importForm.ShowDialog(this);
                    }
                }
                catch
                {
                    MessageBox.Show(this, @"Failed to import the default data, please try again.", @"Importation Failure", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }

                _searchCtrl.RefreshData();
            }
        }

        private void Map_KeyPress(object sender, KeyPressEventArgs e)
        {
            var key = e.KeyChar;
            switch (key)
            {
                case 'h':
                case 'H':
                    toolBar.Items[5].Select();
                    map.FunctionMode = FunctionMode.Pan;
                    e.Handled = true;
                    break;
                case 's':
                case 'S':
                    toolBar.Items[6].Select();
                    map.FunctionMode = FunctionMode.Select;
                    e.Handled = true;
                    break;
                case 'z':
                case 'Z':
                    toolBar.Items[7].Select();
                    map.FunctionMode = FunctionMode.ZoomIn;
                    e.Handled = true;
                    break;
            }
        }

        private void Map_GeoMouseMove(object sender, GeoMouseArgs e)
        {
            lblCoord.Text = String.Format("X: {0}, Y: {1}", e.GeographicLocation.X, e.GeographicLocation.Y);
        }

        private void AddLayerHandler(object sender, EventArgs e)
        {
            var addLayerForm = new AddLayerForm();
            if (addLayerForm.ShowDialog(this) == DialogResult.OK)
            {
                var featureSet = new FeatureSet(addLayerForm.FeatureType) { Name = addLayerForm.LayerName };
                var dataPath = addLayerForm.DataPath;
                var displayLayer = addLayerForm.DisplayAfterImportation;

                var importForm = new ImportProgressForm(new SpatialLayerDataImporter(featureSet.Name, dataPath));
                if (importForm.ShowDialog(this) == DialogResult.OK)
                {
                    if (displayLayer)
                    {
                        var geometries = importForm.GetImportedObjects<JoobGeometry>();
                        MapDataAdapter.PopulateFeatureSet(geometries, featureSet);

                        var layer = map.Layers.Add(featureSet);
                        if (layer != null)
                        {
                            layer.LegendText = featureSet.Name;
                        }
                        map.ViewExtents.ExpandToInclude(featureSet.Extent);
                    }

                    _searchCtrl.RefreshLayers();
                }
            }
        }

        internal void UpdatePerformanceCounter(long searchTime, long totalTime)
        {
            lblPerformance.Text = string.Format("Performance: {0}/{1}ms {2:P1}", searchTime, totalTime, searchTime / (double)totalTime);
        }
    }
}
