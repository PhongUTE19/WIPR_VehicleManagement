
namespace VehicleManagement
{
    partial class EditJobForm
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
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtJobId = new System.Windows.Forms.TextBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.lblJobId = new System.Windows.Forms.Label();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(110, 55);
            this.txtName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(200, 22);
            this.txtName.TabIndex = 1;
            // 
            // txtJobId
            // 
            this.txtJobId.Location = new System.Drawing.Point(110, 20);
            this.txtJobId.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtJobId.Name = "txtJobId";
            this.txtJobId.Size = new System.Drawing.Size(200, 22);
            this.txtJobId.TabIndex = 0;
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.ForeColor = System.Drawing.Color.White;
            this.lblDescription.Location = new System.Drawing.Point(25, 90);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(83, 17);
            this.lblDescription.TabIndex = 114;
            this.lblDescription.Text = "Description:";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.ForeColor = System.Drawing.Color.White;
            this.lblName.Location = new System.Drawing.Point(25, 55);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(53, 17);
            this.lblName.TabIndex = 115;
            this.lblName.Text = "Owner:";
            // 
            // lblJobId
            // 
            this.lblJobId.AutoSize = true;
            this.lblJobId.ForeColor = System.Drawing.Color.White;
            this.lblJobId.Location = new System.Drawing.Point(25, 20);
            this.lblJobId.Name = "lblJobId";
            this.lblJobId.Size = new System.Drawing.Size(73, 17);
            this.lblJobId.TabIndex = 116;
            this.lblJobId.Text = "Vehicle Id:";
            // 
            // btnConfirm
            // 
            this.btnConfirm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(220)))), ((int)(((byte)(130)))));
            this.btnConfirm.Location = new System.Drawing.Point(110, 320);
            this.btnConfirm.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(140, 50);
            this.btnConfirm.TabIndex = 10;
            this.btnConfirm.Text = "Confirm";
            this.btnConfirm.UseVisualStyleBackColor = false;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(110, 90);
            this.txtDescription.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(200, 200);
            this.txtDescription.TabIndex = 117;
            // 
            // EditJobForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(38)))), ((int)(((byte)(65)))));
            this.ClientSize = new System.Drawing.Size(332, 403);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.txtJobId);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.lblJobId);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "EditJobForm";
            this.Text = "EditJobForm";
            this.Load += new System.EventHandler(this.EditJobForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtJobId;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblJobId;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.TextBox txtDescription;
    }
}