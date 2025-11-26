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
            btnClickThis = new Button();
            SuspendLayout();
            // 
            // btnClickThis
            // 
            btnClickThis.AutoSize = true;
            btnClickThis.Location = new Point(245, 172);
            btnClickThis.Name = "btnClickThis";
            btnClickThis.Size = new Size(358, 113);
            btnClickThis.TabIndex = 0;
            btnClickThis.Text = "Поприветствоваться с Дедушкой";
            btnClickThis.UseVisualStyleBackColor = true;
            btnClickThis.Click += btnClickThis_Click;
            // 
            // SmartTravelPlanner
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(829, 461);
            Controls.Add(btnClickThis);
            Name = "SmartTravelPlanner";
            Text = "Form1";
            Load += SmartTravelPlanner_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnClickThis;
    }
}
