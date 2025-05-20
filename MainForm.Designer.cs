
namespace VehicleManagement
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tsmiVehicle = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiStaff = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tsmiJob = new System.Windows.Forms.ToolStripMenuItem();
            this.contractToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tsmiVehicle
            // 
            this.tsmiVehicle.BackColor = System.Drawing.Color.IndianRed;
            this.tsmiVehicle.ForeColor = System.Drawing.SystemColors.ControlText;
            this.tsmiVehicle.Name = "tsmiVehicle";
            this.tsmiVehicle.Size = new System.Drawing.Size(56, 20);
            this.tsmiVehicle.Text = "Vehicle";
            this.tsmiVehicle.Click += new System.EventHandler(this.tsmiVehicle_Click);
            // 
            // tsmiStaff
            // 
            this.tsmiStaff.BackColor = System.Drawing.Color.SandyBrown;
            this.tsmiStaff.Name = "tsmiStaff";
            this.tsmiStaff.Size = new System.Drawing.Size(43, 20);
            this.tsmiStaff.Text = "Staff";
            this.tsmiStaff.Click += new System.EventHandler(this.tsmiStaff_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiVehicle,
            this.tsmiStaff,
            this.tsmiJob,
            this.contractToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(600, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // tsmiJob
            // 
            this.tsmiJob.BackColor = System.Drawing.Color.LightGreen;
            this.tsmiJob.Name = "tsmiJob";
            this.tsmiJob.Size = new System.Drawing.Size(37, 20);
            this.tsmiJob.Text = "Job";
            this.tsmiJob.Click += new System.EventHandler(this.tsmiJob_Click);
            // 
            // contractToolStripMenuItem
            // 
            this.contractToolStripMenuItem.BackColor = System.Drawing.Color.MediumTurquoise;
            this.contractToolStripMenuItem.Name = "contractToolStripMenuItem";
            this.contractToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.contractToolStripMenuItem.Text = "Contract";
            this.contractToolStripMenuItem.Click += new System.EventHandler(this.contractToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::VehicleManagement.Properties.Resources._270630319_646138706802110_9013562198811924589_n;
            this.ClientSize = new System.Drawing.Size(600, 366);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStripMenuItem tsmiVehicle;
        private System.Windows.Forms.ToolStripMenuItem tsmiStaff;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tsmiJob;
        private System.Windows.Forms.ToolStripMenuItem contractToolStripMenuItem;
    }
}