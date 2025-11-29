using System.Drawing;
using System.Windows.Forms;

namespace SmartTravelPlanner
{
    partial class SmartTravelPlanner
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBoxTraveler = new GroupBox();
            this.lblTravelerName = new Label();
            this.txtTravelerName = new TextBox();
            this.lblCurrentLocation = new Label();
            this.txtCurrentLocation = new TextBox();
            this.btnCreateTraveler = new Button();
            
            this.groupBoxMap = new GroupBox();
            this.btnLoadMap = new Button();
            this.lblMapStatus = new Label();
            
            this.groupBoxRoute = new GroupBox();
            this.lblDestination = new Label();
            this.txtDestination = new TextBox();
            this.btnPlanRoute = new Button();
            this.lblRoute = new Label();
            this.lstRoute = new ListBox();
            this.lblTotalDistanceCaption = new Label();
            this.lblTotalDistanceValue = new Label();
            this.btnClearRoute = new Button();
            
            this.groupBoxActions = new GroupBox();
            this.btnSaveTraveler = new Button();
            this.btnLoadTraveler = new Button();
            this.btnExit = new Button();
            
            this.groupBoxTraveler.SuspendLayout();
            this.groupBoxMap.SuspendLayout();
            this.groupBoxRoute.SuspendLayout();
            this.groupBoxActions.SuspendLayout();
            this.SuspendLayout();
            
            // 
            // groupBoxTraveler
            // 
            this.groupBoxTraveler.Controls.Add(this.btnCreateTraveler);
            this.groupBoxTraveler.Controls.Add(this.txtCurrentLocation);
            this.groupBoxTraveler.Controls.Add(this.lblCurrentLocation);
            this.groupBoxTraveler.Controls.Add(this.txtTravelerName);
            this.groupBoxTraveler.Controls.Add(this.lblTravelerName);
            this.groupBoxTraveler.Location = new Point(15, 15);
            this.groupBoxTraveler.Name = "groupBoxTraveler";
            this.groupBoxTraveler.Size = new Size(400, 130);
            this.groupBoxTraveler.TabIndex = 0;
            this.groupBoxTraveler.TabStop = false;
            this.groupBoxTraveler.Text = "Traveler";
            
            // 
            // lblTravelerName
            // 
            this.lblTravelerName.AutoSize = true;
            this.lblTravelerName.Location = new Point(6, 26);
            this.lblTravelerName.Name = "lblTravelerName";
            this.lblTravelerName.Size = new Size(49, 20);
            this.lblTravelerName.TabIndex = 0;
            this.lblTravelerName.Text = "Traveler name";
            
            // 
            // txtTravelerName
            // 
            this.txtTravelerName.Location = new Point(150, 28);
            this.txtTravelerName.Name = "txtTravelerName";
            this.txtTravelerName.Size = new Size(240, 27);
            this.txtTravelerName.TabIndex = 1;
            
            // 
            // lblCurrentLocation
            // 
            this.lblCurrentLocation.AutoSize = true;
            this.lblCurrentLocation.Location = new Point(6, 59);
            this.lblCurrentLocation.Name = "lblCurrentLocation";
            this.lblCurrentLocation.Size = new Size(113, 20);
            this.lblCurrentLocation.TabIndex = 2;
            this.lblCurrentLocation.Text = "Current location";
            
            // 
            // txtCurrentLocation
            // 
            this.txtCurrentLocation.Location = new Point(150, 65);
            this.txtCurrentLocation.Name = "txtCurrentLocation";
            this.txtCurrentLocation.Size = new Size(240, 27);
            this.txtCurrentLocation.TabIndex = 3;
            
            // 
            // btnCreateTraveler
            // 
            this.btnCreateTraveler.Location = new Point(150, 102);
            this.btnCreateTraveler.Name = "btnCreateTraveler";
            this.btnCreateTraveler.Size = new Size(240, 35);
            this.btnCreateTraveler.TabIndex = 4;
            this.btnCreateTraveler.Text = "Create Traveler";
            this.btnCreateTraveler.UseVisualStyleBackColor = true;
            this.btnCreateTraveler.Click += this.btnCreateTraveler_Click;
            
            // 
            // groupBoxMap
            // 
            this.groupBoxMap.Controls.Add(this.lblMapStatus);
            this.groupBoxMap.Controls.Add(this.btnLoadMap);
            this.groupBoxMap.Location = new Point(15, 155);
            this.groupBoxMap.Name = "groupBoxMap";
            this.groupBoxMap.Size = new Size(400, 90);
            this.groupBoxMap.TabIndex = 1;
            this.groupBoxMap.TabStop = false;
            this.groupBoxMap.Text = "Map";
            
            // 
            // btnLoadMap
            // 
            this.btnLoadMap.Location = new Point(10, 28);
            this.btnLoadMap.Name = "btnLoadMap";
            this.btnLoadMap.Size = new Size(380, 35);
            this.btnLoadMap.TabIndex = 0;
            this.btnLoadMap.Text = "Load Map…";
            this.btnLoadMap.UseVisualStyleBackColor = true;
            this.btnLoadMap.Click += this.btnLoadMap_Click;
            
            // 
            // lblMapStatus
            // 
            this.lblMapStatus.AutoSize = true;
            this.lblMapStatus.Location = new Point(10, 70);
            this.lblMapStatus.Name = "lblMapStatus";
            this.lblMapStatus.Size = new Size(95, 20);
            this.lblMapStatus.TabIndex = 1;
            this.lblMapStatus.Text = "No map loaded";
            
            // 
            // groupBoxRoute
            // 
            this.groupBoxRoute.Controls.Add(this.btnClearRoute);
            this.groupBoxRoute.Controls.Add(this.lblTotalDistanceValue);
            this.groupBoxRoute.Controls.Add(this.lblTotalDistanceCaption);
            this.groupBoxRoute.Controls.Add(this.lstRoute);
            this.groupBoxRoute.Controls.Add(this.lblRoute);
            this.groupBoxRoute.Controls.Add(this.btnPlanRoute);
            this.groupBoxRoute.Controls.Add(this.txtDestination);
            this.groupBoxRoute.Controls.Add(this.lblDestination);
            this.groupBoxRoute.Location = new Point(430, 15);
            this.groupBoxRoute.Name = "groupBoxRoute";
            this.groupBoxRoute.Size = new Size(400, 420);
            this.groupBoxRoute.TabIndex = 2;
            this.groupBoxRoute.TabStop = false;
            this.groupBoxRoute.Text = "Route planning";
            
            // 
            // lblDestination
            // 
            this.lblDestination.AutoSize = true;
            this.lblDestination.Location = new Point(6, 26);
            this.lblDestination.Name = "lblDestination";
            this.lblDestination.Size = new Size(88, 20);
            this.lblDestination.TabIndex = 0;
            this.lblDestination.Text = "Destination";
            
            // 
            // txtDestination
            // 
            this.txtDestination.Location = new Point(100, 28);
            this.txtDestination.Name = "txtDestination";
            this.txtDestination.Size = new Size(290, 27);
            this.txtDestination.TabIndex = 1;
            
            // 
            // btnPlanRoute
            // 
            this.btnPlanRoute.Location = new Point(10, 65);
            this.btnPlanRoute.Name = "btnPlanRoute";
            this.btnPlanRoute.Size = new Size(380, 38);
            this.btnPlanRoute.TabIndex = 2;
            this.btnPlanRoute.Text = "Plan Route";
            this.btnPlanRoute.UseVisualStyleBackColor = true;
            this.btnPlanRoute.Click += this.btnPlanRoute_Click;
            
            // 
            // lblRoute
            // 
            this.lblRoute.AutoSize = true;
            this.lblRoute.Location = new Point(6, 100);
            this.lblRoute.Name = "lblRoute";
            this.lblRoute.Size = new Size(52, 20);
            this.lblRoute.TabIndex = 3;
            this.lblRoute.Text = "Route:";
            
            // 
            // lstRoute
            // 
            this.lstRoute.FormattingEnabled = true;
            this.lstRoute.ItemHeight = 22;
            this.lstRoute.Location = new Point(10, 133);
            this.lstRoute.Name = "lstRoute";
            this.lstRoute.Size = new Size(380, 200);
            this.lstRoute.TabIndex = 4;
            
            // 
            // lblTotalDistanceCaption
            // 
            this.lblTotalDistanceCaption.AutoSize = true;
            this.lblTotalDistanceCaption.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            this.lblTotalDistanceCaption.Location = new Point(10, 345);
            this.lblTotalDistanceCaption.Name = "lblTotalDistanceCaption";
            this.lblTotalDistanceCaption.Size = new Size(130, 25);
            this.lblTotalDistanceCaption.TabIndex = 5;
            this.lblTotalDistanceCaption.Text = "Total distance:";
            this.lblTotalDistanceCaption.ForeColor = Color.FromArgb(33, 37, 41);
            
            // 
            // lblTotalDistanceValue
            // 
            this.lblTotalDistanceValue.AutoSize = true;
            this.lblTotalDistanceValue.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            this.lblTotalDistanceValue.Location = new Point(145, 345);
            this.lblTotalDistanceValue.Name = "lblTotalDistanceValue";
            this.lblTotalDistanceValue.Size = new Size(55, 25);
            this.lblTotalDistanceValue.TabIndex = 6;
            this.lblTotalDistanceValue.Text = "0 km";
            this.lblTotalDistanceValue.ForeColor = Color.FromArgb(0, 120, 215);
            
            // 
            // btnClearRoute
            // 
            this.btnClearRoute.Location = new Point(10, 375);
            this.btnClearRoute.Name = "btnClearRoute";
            this.btnClearRoute.Size = new Size(380, 32);
            this.btnClearRoute.TabIndex = 7;
            this.btnClearRoute.Text = "Clear Route";
            this.btnClearRoute.UseVisualStyleBackColor = true;
            this.btnClearRoute.Click += this.btnClearRoute_Click;
            
            // 
            // groupBoxActions
            // 
            this.groupBoxActions.Controls.Add(this.btnExit);
            this.groupBoxActions.Controls.Add(this.btnLoadTraveler);
            this.groupBoxActions.Controls.Add(this.btnSaveTraveler);
            this.groupBoxActions.Location = new Point(15, 255);
            this.groupBoxActions.Name = "groupBoxActions";
            this.groupBoxActions.Size = new Size(400, 130);
            this.groupBoxActions.TabIndex = 3;
            this.groupBoxActions.TabStop = false;
            this.groupBoxActions.Text = "Actions";
            
            // 
            // btnSaveTraveler
            // 
            this.btnSaveTraveler.Location = new Point(10, 28);
            this.btnSaveTraveler.Name = "btnSaveTraveler";
            this.btnSaveTraveler.Size = new Size(190, 35);
            this.btnSaveTraveler.TabIndex = 0;
            this.btnSaveTraveler.Text = "Save Traveler…";
            this.btnSaveTraveler.UseVisualStyleBackColor = true;
            this.btnSaveTraveler.Click += this.btnSaveTraveler_Click;
            
            // 
            // btnLoadTraveler
            // 
            this.btnLoadTraveler.Location = new Point(210, 28);
            this.btnLoadTraveler.Name = "btnLoadTraveler";
            this.btnLoadTraveler.Size = new Size(180, 35);
            this.btnLoadTraveler.TabIndex = 1;
            this.btnLoadTraveler.Text = "Load Traveler…";
            this.btnLoadTraveler.UseVisualStyleBackColor = true;
            this.btnLoadTraveler.Click += this.btnLoadTraveler_Click;
            
            // 
            // btnExit
            // 
            this.btnExit.Location = new Point(10, 73);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new Size(380, 35);
            this.btnExit.TabIndex = 2;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += this.btnExit_Click;
            
            // 
            // SmartTravelPlanner
            // 
            this.AutoScaleDimensions = new SizeF(8F, 20F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(850, 450);
            this.Controls.Add(this.groupBoxActions);
            this.Controls.Add(this.groupBoxRoute);
            this.Controls.Add(this.groupBoxMap);
            this.Controls.Add(this.groupBoxTraveler);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = true;
            this.Name = "SmartTravelPlanner";
            this.Padding = new Padding(15);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Smart Travel Planner";
            this.Load += this.SmartTravelPlanner_Load;
            this.groupBoxTraveler.ResumeLayout(false);
            this.groupBoxTraveler.PerformLayout();
            this.groupBoxMap.ResumeLayout(false);
            this.groupBoxMap.PerformLayout();
            this.groupBoxRoute.ResumeLayout(false);
            this.groupBoxRoute.PerformLayout();
            this.groupBoxActions.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBoxTraveler;
        private Label lblTravelerName;
        private TextBox txtTravelerName;
        private Label lblCurrentLocation;
        private TextBox txtCurrentLocation;
        private Button btnCreateTraveler;
        
        private GroupBox groupBoxMap;
        private Button btnLoadMap;
        private Label lblMapStatus;
        
        private GroupBox groupBoxRoute;
        private Label lblDestination;
        private TextBox txtDestination;
        private Button btnPlanRoute;
        private Label lblRoute;
        private ListBox lstRoute;
        private Label lblTotalDistanceCaption;
        private Label lblTotalDistanceValue;
        private Button btnClearRoute;
        
        private GroupBox groupBoxActions;
        private Button btnSaveTraveler;
        private Button btnLoadTraveler;
        private Button btnExit;
    }
}
