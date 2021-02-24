using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DotSpatial.Controls;
using DotSpatial.Data;
using DotSpatial.Symbology;
using DotSpatial.Topology;
using JadeSoftware.Joob;
using JadeSoftware.Joob.Client;
using PointShape = DotSpatial.Symbology.PointShape;

namespace JoobSpatialDemo
{
    public partial class MapSearchControl : UserControl
    {
        private const string DoubleValueRequiredError = "Please enter a double value";
        private const string MaxXSmallThanMinXError = "Min X must be smaller than or equal to Max X";
        private const string MaxYSmallThanMinYError = "Min Y must be smaller than or equal to Max Y";
        private const string NoSearchLayerSelectedError = "At least one layer must be selected";

        private bool _searchByNameWarningShown;

        private readonly MainForm _mainForm;
        private readonly IMap _map;
        private readonly Stopwatch _timer = new Stopwatch();

        public MapSearchControl(MainForm mainForm, IMap map)
        {
            InitializeComponent();

            if (mainForm == null) throw new ArgumentNullException("mainForm");
            if (map == null) throw new ArgumentNullException("map");

            _mainForm = mainForm;
            _map = map;

            _timer.Stop();
            RefreshData();
        }

        public void RefreshData()
        {
            SearchRegion.PopulatePredefinedRegions();
            searchRegionBindingSource.DataSource = null;
            searchRegionBindingSource.DataSource = SearchRegion.PredefinedSearchRegions;
            cmbSearchStrategy.SelectedIndex = 3;

            RefreshLayers();
        }

        public void RefreshLayers()
        {
            chbLayerNames.Items.Clear();
            var layers = MapDataAdapter.GetAllLayers();
            if (layers.Count() > 0)
            {
                gbxLayers.Visible = true;
                chbLayerNames.Items.AddRange(layers.ToArray());
                chbLayerNames.SetItemChecked(0, true);
            }
            else
            {
                gbxLayers.Visible = false;
            }
        }

        private void lnkSelectAll_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SelectAllSearchLayers(true);
        }

        private void lnkSelectNone_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SelectAllSearchLayers(false);
        }

        private void SelectAllSearchLayers(bool value)
        {
            for (var i = 0; i < chbLayerNames.Items.Count; i++)
            {
                chbLayerNames.SetItemChecked(i, value);
            }
        }

        private void rdoPredefinedRegion_CheckedChanged(object sender, EventArgs e)
        {
            cmbPredefinedRegions.Enabled = rdoPredefinedRegion.Checked;
        }

        private void rdoCustomRegion_CheckedChanged(object sender, EventArgs e)
        {
            pnlCustomRegion.Visible = rdoCustomRegion.Checked;
        }

        private void rdoSearchByGeom_CheckedChanged(object sender, EventArgs e)
        {
            cmbSearchStrategy.Enabled = rdoSearchByGeom.Checked;
            rdoInfinityRegion.Enabled = rdoSearchByGeom.Checked;
            rdoCustomRegion.Enabled = rdoSearchByGeom.Checked;
        }

        private void rdoSearchByName_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoSearchByName.Checked)
            {
                rdoPredefinedRegion.Checked = true;
                if (!_searchByNameWarningShown)
                {
                    MessageBox.Show(this, @"In this demo, 'Search by Name' is only supported by the 'States' and 'Cities' layers.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _searchByNameWarningShown = true;
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (ValidateSearchEntries())
            {
                SearchRegion region = null;
                if (rdoPredefinedRegion.Checked)
                {
                    region = cmbPredefinedRegions.SelectedItem as SearchRegion;
                }
                else if (rdoCustomRegion.Checked)
                {
                    var minX = double.Parse(txtRegionMinX.Text);
                    var minY = double.Parse(txtRegionMinY.Text);
                    var maxX = double.Parse(txtRegionMaxX.Text);
                    var maxY = double.Parse(txtRegionMaxY.Text);

                    region = new SearchRegion("Custom", minX, minY, maxX, maxY);
                }

                MultiDimensionalObjectRelationship relationship;
                if (!Enum.TryParse(cmbSearchStrategy.Text, out relationship))
                {
                    relationship = MultiDimensionalObjectRelationship.Intersect;
                }

                SearchAsync(chbLayerNames.CheckedItems.Cast<LayerInfo>().ToArray(), region, relationship);
            }
        }

        private void ValidatingDoubleValue(object sender, CancelEventArgs e)
        {
            var txtBox = (TextBox)sender;
            string error = null;

            double val;
            if (!string.IsNullOrEmpty(txtBox.Text) && !double.TryParse(txtBox.Text, out val))
            {
                error = DoubleValueRequiredError;
                e.Cancel = true;
            }

            errPrvSearchRegion.DisplayError(txtBox, error);
        }

        private bool ValidateSearchEntries()
        {
            string layerError, minXError, minYError, maxXError, maxYError;
            string btnSearchError = layerError = minXError = minYError = maxXError = maxYError = null;

            if (chbLayerNames.CheckedItems.Count == 0)
            {
                layerError = NoSearchLayerSelectedError;
            }

            if (rdoCustomRegion.Checked)
            {
                double minX, minY, maxX, maxY;
                if (!double.TryParse(txtRegionMinX.Text, out minX))
                {
                    minXError = DoubleValueRequiredError;
                }

                if (!double.TryParse(txtRegionMinY.Text, out minY))
                {
                    minYError = DoubleValueRequiredError;
                }

                if (!double.TryParse(txtRegionMaxX.Text, out maxX))
                {
                    maxXError = DoubleValueRequiredError;
                }

                if (!double.TryParse(txtRegionMaxY.Text, out maxY))
                {
                    maxYError = DoubleValueRequiredError;
                }

                if (minX > maxX)
                {
                    btnSearchError = MaxXSmallThanMinXError;
                }
                else if (minY > maxY)
                {
                    btnSearchError = MaxYSmallThanMinYError;
                }
            }

            errPrvSearchRegion.DisplayError(txtRegionMinX, minXError);
            errPrvSearchRegion.DisplayError(txtRegionMinY, minYError);
            errPrvSearchRegion.DisplayError(txtRegionMaxX, maxXError);
            errPrvSearchRegion.DisplayError(txtRegionMaxY, maxYError);
            errPrvSearchRegion.DisplayError(btnSearch, btnSearchError);
            errPrvSearchRegion.DisplayError(chbLayerNames, layerError);

            return minXError == null && minYError == null && maxXError == null && maxYError == null
                && btnSearchError == null && layerError == null;
        }

        private void SearchAsync(IEnumerable<LayerInfo> layerInfos, SearchRegion region, MultiDimensionalObjectRelationship relationship)
        {
            btnSearch.Enabled = false;
            btnSearch.Text = @"Searching...";

            var searchWorker = new BackgroundWorker();
            searchWorker.DoWork += SearchWorker_DoWork;
            searchWorker.RunWorkerCompleted += SearchWorker_RunWorkerCompleted;

            _timer.Restart();
            searchWorker.RunWorkerAsync(Tuple.Create(layerInfos, region, relationship, rdoSearchByGeom.Checked));
        }

        static void SearchWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            var tuple = e.Argument as Tuple<IEnumerable<LayerInfo>, SearchRegion, MultiDimensionalObjectRelationship, bool>;
            if (tuple != null)
            {
                using (new JoobContext())
                {
                    var layerInfos = tuple.Item1;
                    var region = tuple.Item2;
                    var relationship = tuple.Item3;
                    var spatialSearch = tuple.Item4;

                    long totalSearchTime;
                    IEnumerable<FeatureSet> featureSets;

                    var watch = new Stopwatch();
                    watch.Start();

                    if (spatialSearch)
                    {
                        featureSets = MapDataAdapter.SpatialSearch(layerInfos, region, relationship, out totalSearchTime);
                    }
                    else
                    {
                        featureSets = MapDataAdapter.NameSearch(layerInfos, region, out totalSearchTime);
                    }

                    e.Result = Tuple.Create(featureSets, totalSearchTime);
                }
            }
        }

        void SearchWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            btnSearch.Text = @"Search";
            btnSearch.Enabled = true;

            if (e.Error != null || e.Cancelled)
                return;

            var tuple = e.Result as Tuple<IEnumerable<FeatureSet>, long>;
            if (tuple == null)
                return;

            var featureSets = tuple.Item1;
            var searchTime = tuple.Item2;

            _map.Layers.Clear();
            if (featureSets != null)
            {
                foreach (var featureSet in featureSets)
                {
                    var addedToMap = false;
                    IMapFeatureLayer layer;
                    switch (featureSet.FeatureType)
                    {
                        case FeatureType.Point:
                        case FeatureType.MultiPoint:
                            layer = new MapPointLayer(featureSet);
                            break;
                        case FeatureType.Line:
                            layer = new MapLineLayer(featureSet);
                            break;
                        case FeatureType.Polygon:
                            layer = new MapPolygonLayer(featureSet);
                            break;
                        default:
                            layer = _map.Layers.Add(featureSet);
                            addedToMap = true;
                            break;
                    }

                    if (layer != null)
                    {
                        if (featureSet.Name == MapDataAdapter.FeatureTypeStates)
                        {
                            layer.Symbolizer = new PolygonSymbolizer(Color.FromArgb(216, 250, 216), Color.FromArgb(71, 178, 102));
                        }
                        else if (featureSet.Name == MapDataAdapter.FeatureTypeCounties)
                        {
                            layer.Symbolizer = new PolygonSymbolizer(Color.FromArgb(198, 215, 247), Color.FromArgb(70, 112, 197));
                        }
                        else if (featureSet.Name == MapDataAdapter.FeatureTypeCities)
                        {
                            layer.Symbolizer = new PointSymbolizer(Color.Yellow, PointShape.Ellipse, 6);
                            layer.Symbolizer.SetOutline(Color.OrangeRed, 1);
                        }

                        layer.LegendText = string.Format("{0} ({1})", featureSet.Name, featureSet.Features.Count);

                        if (!addedToMap)
                        {
                            _map.Layers.Add(layer);
                        }
                    }
                }
            }

            _timer.Stop();
            _mainForm.UpdatePerformanceCounter(searchTime, _timer.ElapsedMilliseconds);
        }
    }
}
