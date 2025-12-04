using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Travelling;

namespace SmartTravelPlanner
{
    public partial class SmartTravelPlanner : Form
    {
        private Traveler? currentTraveler;
        private CityGraph? cityGraph;

        public SmartTravelPlanner()
        {
            InitializeComponent();
            ApplyModernStyling();
            UpdateUI();
        }

        private void ApplyModernStyling()
        {
            // Modern color scheme
            Color primaryColor = Color.FromArgb(0, 120, 215); 
            Color secondaryColor = Color.FromArgb(108, 117, 125); 
            Color successColor = Color.FromArgb(40, 167, 69); 
            Color dangerColor = Color.FromArgb(220, 53, 69); 
            Color backgroundColor = Color.FromArgb(248, 249, 250); 
            Color panelColor = Color.White;

            //styling
            this.BackColor = backgroundColor;
            this.Font = new Font("Segoe UI", 9F, FontStyle.Regular);

            // Group box
            foreach (Control control in this.Controls)
            {
                if (control is GroupBox groupBox)
                {
                    groupBox.BackColor = panelColor;
                    groupBox.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
                    groupBox.ForeColor = Color.FromArgb(33, 37, 41);
                }
            }

            //Create, Plan Route, Load Map
            btnCreateTraveler.BackColor = primaryColor;
            btnCreateTraveler.ForeColor = Color.White;
            btnCreateTraveler.FlatStyle = FlatStyle.Flat;
            btnCreateTraveler.FlatAppearance.BorderSize = 0;
            btnCreateTraveler.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnCreateTraveler.Cursor = Cursors.Hand;

            btnPlanRoute.BackColor = primaryColor;
            btnPlanRoute.ForeColor = Color.White;
            btnPlanRoute.FlatStyle = FlatStyle.Flat;
            btnPlanRoute.FlatAppearance.BorderSize = 0;
            btnPlanRoute.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnPlanRoute.Cursor = Cursors.Hand;

            btnLoadMap.BackColor = primaryColor;
            btnLoadMap.ForeColor = Color.White;
            btnLoadMap.FlatStyle = FlatStyle.Flat;
            btnLoadMap.FlatAppearance.BorderSize = 0;
            btnLoadMap.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnLoadMap.Cursor = Cursors.Hand;

            //Save, Load Traveler
            btnSaveTraveler.BackColor = successColor;
            btnSaveTraveler.ForeColor = Color.White;
            btnSaveTraveler.FlatStyle = FlatStyle.Flat;
            btnSaveTraveler.FlatAppearance.BorderSize = 0;
            btnSaveTraveler.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnSaveTraveler.Cursor = Cursors.Hand;

            btnLoadTraveler.BackColor = successColor;
            btnLoadTraveler.ForeColor = Color.White;
            btnLoadTraveler.FlatStyle = FlatStyle.Flat;
            btnLoadTraveler.FlatAppearance.BorderSize = 0;
            btnLoadTraveler.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnLoadTraveler.Cursor = Cursors.Hand;

            //Clear Route
            btnClearRoute.BackColor = secondaryColor;
            btnClearRoute.ForeColor = Color.White;
            btnClearRoute.FlatStyle = FlatStyle.Flat;
            btnClearRoute.FlatAppearance.BorderSize = 0;
            btnClearRoute.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
            btnClearRoute.Cursor = Cursors.Hand;

            // Exit
            btnExit.BackColor = dangerColor;
            btnExit.ForeColor = Color.White;
            btnExit.FlatStyle = FlatStyle.Flat;
            btnExit.FlatAppearance.BorderSize = 0;
            btnExit.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnExit.Cursor = Cursors.Hand;

            // Text box
            foreach (Control control in this.Controls)
            {
                ApplyTextBoxStyling(control);
            }

            // Label
            foreach (Control control in this.Controls)
            {
                ApplyLabelStyling(control);
            }

            // ListBox
            lstRoute.BackColor = Color.White;
            lstRoute.BorderStyle = BorderStyle.FixedSingle;
            lstRoute.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
        }

        private void ApplyTextBoxStyling(Control parent)
        {
            foreach (Control control in parent.Controls)
            {
                if (control is TextBox textBox)
                {
                    textBox.BackColor = Color.White;
                    textBox.BorderStyle = BorderStyle.FixedSingle;
                    textBox.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
                }
                else if (control.HasChildren)
                {
                    ApplyTextBoxStyling(control);
                }
            }
        }

        private void ApplyLabelStyling(Control parent)
        {
            foreach (Control control in parent.Controls)
            {
                if (control is Label label && label != lblTotalDistanceCaption && label != lblTotalDistanceValue)
                {
                    label.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
                    label.ForeColor = Color.FromArgb(73, 80, 87);
                }
                else if (control.HasChildren)
                {
                    ApplyLabelStyling(control);
                }
            }
        }

        private void SmartTravelPlanner_Load(object sender, EventArgs e)
        {
            UpdateUI();
        }

        private void UpdateUI()
        {
            if (cityGraph != null)
            {
                var cities = cityGraph.GetAllCities();
                lblMapStatus.Text = $"Map loaded from file ({cities.Count} cities)";
            }
            else
            {
                lblMapStatus.Text = "No map loaded";
            }
        }

        private void btnCreateTraveler_Click(object sender, EventArgs e)
        {
            try
            {
                string name = txtTravelerName.Text.Trim();
                string location = txtCurrentLocation.Text.Trim();

                if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(location))
                {
                    MessageBox.Show("Traveler field empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                currentTraveler = new Traveler(name);
                currentTraveler.SetLocation(location);

                UpdateUI();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error creating traveler: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLoadMap_Click(object sender, EventArgs e)
        {
            try
            {
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
                    openFileDialog.FilterIndex = 1;
                    openFileDialog.RestoreDirectory = true;

                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        string filePath = openFileDialog.FileName;
                        cityGraph = CityGraph.LoadFromFile(filePath);
                        UpdateUI();
                    }
                }
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("Map file not found or invalid format", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (FormatException)
            {
                MessageBox.Show("Map file not found or invalid format", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception)
            {
                MessageBox.Show("Map file not found or invalid format", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPlanRoute_Click(object sender, EventArgs e)
        {
            try
            {
                if (currentTraveler == null)
                {
                    MessageBox.Show("Please create a traveler first.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (cityGraph == null)
                {
                    MessageBox.Show("Please load a map first.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string destination = txtDestination.Text.Trim();
                if (string.IsNullOrEmpty(destination))
                {
                    MessageBox.Show("Destination field empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Check if destination is in map
                var allCities = cityGraph.GetAllCities();
                string normalizedDestination = destination[0].ToString().ToUpper() + destination.Substring(1).ToLower();
                bool destinationInMap = allCities.Any(c => c.Equals(normalizedDestination, StringComparison.OrdinalIgnoreCase));
                
                if (!destinationInMap)
                {
                    MessageBox.Show("Destination not in map", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    lstRoute.Items.Clear();
                    lblTotalDistanceValue.Text = "0 km";
                    return;
                }

                bool success = currentTraveler.PlanRouteTo(destination, cityGraph);
                
                if (!success)
                {
                    MessageBox.Show("Destination not reachable", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    lstRoute.Items.Clear();
                    lblTotalDistanceValue.Text = "0 km";
                    return;
                }

                var route = currentTraveler.GetRouteItems();
                lstRoute.Items.Clear();
                
                foreach (var city in route)
                {
                    lstRoute.Items.Add(city);
                }

                int totalDistance = cityGraph.GetPathDistance(route);
                lblTotalDistanceValue.Text = $"{totalDistance} km";

                // Optionally update traveler's current location to the destination
                currentTraveler.SetLocation(destination);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error planning route: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClearRoute_Click(object sender, EventArgs e)
        {
            lstRoute.Items.Clear();
            lblTotalDistanceValue.Text = "0 km";
            
            if (currentTraveler != null)
            {
                currentTraveler.ClearRoute();
            }
        }

        private void btnSaveTraveler_Click(object sender, EventArgs e)
        {
            try
            {
                if (currentTraveler == null)
                {
                    MessageBox.Show("Please create a traveler first.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Filter = "JSON files (*.json)|*.json|All files (*.*)|*.*";
                    saveFileDialog.FilterIndex = 1;
                    saveFileDialog.RestoreDirectory = true;
                    saveFileDialog.FileName = "traveler.json";

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        string filePath = saveFileDialog.FileName;
                        currentTraveler.SaveToFile(filePath);
                    }
                }
            }
            catch (UnauthorizedAccessException)
            {
                MessageBox.Show("Error saving traveler file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (DirectoryNotFoundException)
            {
                MessageBox.Show("Error saving traveler file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception)
            {
                MessageBox.Show("Error saving traveler file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLoadTraveler_Click(object sender, EventArgs e)
        {
            try
            {
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.Filter = "JSON files (*.json)|*.json|All files (*.*)|*.*";
                    openFileDialog.FilterIndex = 1;
                    openFileDialog.RestoreDirectory = true;

                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        string filePath = openFileDialog.FileName;
                        currentTraveler = Traveler.LoadFromFile(filePath);
                        
                        txtTravelerName.Text = currentTraveler.GetName();
                        txtCurrentLocation.Text = currentTraveler.GetLocation();
                        
                        var route = currentTraveler.GetRouteItems();
                        lstRoute.Items.Clear();
                        foreach (var city in route)
                        {
                            lstRoute.Items.Add(city);
                        }

                        if (cityGraph != null && route.Count > 0)
                        {
                            int totalDistance = cityGraph.GetPathDistance(route);
                            lblTotalDistanceValue.Text = $"{totalDistance} km";
                        }
                        else
                        {
                            lblTotalDistanceValue.Text = "0 km";
                        }

                        UpdateUI();
                    }
                }
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("Invalid traveler file. Please select a valid .json file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (FileLoadException)
            {
                MessageBox.Show("Invalid .json file during loading", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception)
            {
                MessageBox.Show("Invalid traveler file. Please select a valid .json file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
