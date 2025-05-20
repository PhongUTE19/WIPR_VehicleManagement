
namespace VehicleManagement
{
    partial class AddVehicleForm
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
            this.btnUpdateImage = new System.Windows.Forms.Button();
            this.lblPicture = new System.Windows.Forms.Label();
            this.lblBrand = new System.Windows.Forms.Label();
            this.lblType = new System.Windows.Forms.Label();
            this.lblOwner = new System.Windows.Forms.Label();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.cboType = new System.Windows.Forms.ComboBox();
            this.txtBrand = new System.Windows.Forms.TextBox();
            this.lblCheckIn = new System.Windows.Forms.Label();
            this.dtpCheckIn = new System.Windows.Forms.DateTimePicker();
            this.cboSubscription = new System.Windows.Forms.ComboBox();
            this.lblSubscription = new System.Windows.Forms.Label();
            this.pic = new System.Windows.Forms.PictureBox();
            this.cboOwner = new System.Windows.Forms.ComboBox();
            this.lbAddVehicle = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pic)).BeginInit();
            this.SuspendLayout();
            // 
            // btnUpdateImage
            // 
            this.btnUpdateImage.Location = new System.Drawing.Point(103, 357);
            this.btnUpdateImage.Margin = new System.Windows.Forms.Padding(2);
            this.btnUpdateImage.Name = "btnUpdateImage";
            this.btnUpdateImage.Size = new System.Drawing.Size(75, 24);
            this.btnUpdateImage.TabIndex = 6;
            this.btnUpdateImage.Text = "Update";
            this.btnUpdateImage.UseVisualStyleBackColor = true;
            this.btnUpdateImage.Click += new System.EventHandler(this.btnUpdateImage_Click);
            // 
            // lblPicture
            // 
            this.lblPicture.AutoSize = true;
            this.lblPicture.ForeColor = System.Drawing.Color.White;
            this.lblPicture.Location = new System.Drawing.Point(19, 206);
            this.lblPicture.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPicture.Name = "lblPicture";
            this.lblPicture.Size = new System.Drawing.Size(43, 13);
            this.lblPicture.TabIndex = 117;
            this.lblPicture.Text = "Picture:";
            // 
            // lblBrand
            // 
            this.lblBrand.AutoSize = true;
            this.lblBrand.ForeColor = System.Drawing.Color.White;
            this.lblBrand.Location = new System.Drawing.Point(19, 102);
            this.lblBrand.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblBrand.Name = "lblBrand";
            this.lblBrand.Size = new System.Drawing.Size(38, 13);
            this.lblBrand.TabIndex = 113;
            this.lblBrand.Text = "Brand:";
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.ForeColor = System.Drawing.Color.White;
            this.lblType.Location = new System.Drawing.Point(19, 73);
            this.lblType.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(34, 13);
            this.lblType.TabIndex = 114;
            this.lblType.Text = "Type:";
            // 
            // lblOwner
            // 
            this.lblOwner.AutoSize = true;
            this.lblOwner.ForeColor = System.Drawing.Color.White;
            this.lblOwner.Location = new System.Drawing.Point(19, 45);
            this.lblOwner.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblOwner.Name = "lblOwner";
            this.lblOwner.Size = new System.Drawing.Size(41, 13);
            this.lblOwner.TabIndex = 115;
            this.lblOwner.Text = "Owner:";
            // 
            // btnConfirm
            // 
            this.btnConfirm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(220)))), ((int)(((byte)(130)))));
            this.btnConfirm.Location = new System.Drawing.Point(82, 412);
            this.btnConfirm.Margin = new System.Windows.Forms.Padding(2);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(120, 41);
            this.btnConfirm.TabIndex = 10;
            this.btnConfirm.Text = "Confirm";
            this.btnConfirm.UseVisualStyleBackColor = false;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // cboType
            // 
            this.cboType.FormattingEnabled = true;
            this.cboType.Location = new System.Drawing.Point(82, 73);
            this.cboType.Margin = new System.Windows.Forms.Padding(2);
            this.cboType.Name = "cboType";
            this.cboType.Size = new System.Drawing.Size(151, 21);
            this.cboType.TabIndex = 2;
            // 
            // txtBrand
            // 
            this.txtBrand.Location = new System.Drawing.Point(82, 102);
            this.txtBrand.Margin = new System.Windows.Forms.Padding(2);
            this.txtBrand.Name = "txtBrand";
            this.txtBrand.Size = new System.Drawing.Size(151, 20);
            this.txtBrand.TabIndex = 3;
            // 
            // lblCheckIn
            // 
            this.lblCheckIn.AutoSize = true;
            this.lblCheckIn.ForeColor = System.Drawing.Color.White;
            this.lblCheckIn.Location = new System.Drawing.Point(19, 130);
            this.lblCheckIn.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCheckIn.Name = "lblCheckIn";
            this.lblCheckIn.Size = new System.Drawing.Size(52, 13);
            this.lblCheckIn.TabIndex = 134;
            this.lblCheckIn.Text = "Check in:";
            // 
            // dtpCheckIn
            // 
            this.dtpCheckIn.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpCheckIn.Location = new System.Drawing.Point(82, 130);
            this.dtpCheckIn.Margin = new System.Windows.Forms.Padding(2);
            this.dtpCheckIn.Name = "dtpCheckIn";
            this.dtpCheckIn.Size = new System.Drawing.Size(151, 20);
            this.dtpCheckIn.TabIndex = 4;
            // 
            // cboSubscription
            // 
            this.cboSubscription.FormattingEnabled = true;
            this.cboSubscription.Location = new System.Drawing.Point(82, 158);
            this.cboSubscription.Margin = new System.Windows.Forms.Padding(2);
            this.cboSubscription.Name = "cboSubscription";
            this.cboSubscription.Size = new System.Drawing.Size(151, 21);
            this.cboSubscription.TabIndex = 5;
            // 
            // lblSubscription
            // 
            this.lblSubscription.AutoSize = true;
            this.lblSubscription.ForeColor = System.Drawing.Color.White;
            this.lblSubscription.Location = new System.Drawing.Point(19, 158);
            this.lblSubscription.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSubscription.Name = "lblSubscription";
            this.lblSubscription.Size = new System.Drawing.Size(68, 13);
            this.lblSubscription.TabIndex = 136;
            this.lblSubscription.Text = "Subscription:";
            // 
            // pic
            // 
            this.pic.Location = new System.Drawing.Point(82, 206);
            this.pic.Margin = new System.Windows.Forms.Padding(2);
            this.pic.Name = "pic";
            this.pic.Size = new System.Drawing.Size(120, 130);
            this.pic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic.TabIndex = 108;
            this.pic.TabStop = false;
            // 
            // cboOwner
            // 
            this.cboOwner.FormattingEnabled = true;
            this.cboOwner.Location = new System.Drawing.Point(82, 42);
            this.cboOwner.Name = "cboOwner";
            this.cboOwner.Size = new System.Drawing.Size(151, 21);
            this.cboOwner.TabIndex = 137;
            // 
            // lbAddVehicle
            // 
            this.lbAddVehicle.AutoSize = true;
            this.lbAddVehicle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbAddVehicle.ForeColor = System.Drawing.Color.Transparent;
            this.lbAddVehicle.Location = new System.Drawing.Point(80, 6);
            this.lbAddVehicle.Name = "lbAddVehicle";
            this.lbAddVehicle.Size = new System.Drawing.Size(125, 24);
            this.lbAddVehicle.TabIndex = 138;
            this.lbAddVehicle.Text = "Add Vehicle";
            this.lbAddVehicle.UseMnemonic = false;
            // 
            // AddVehicleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(38)))), ((int)(((byte)(65)))));
            this.ClientSize = new System.Drawing.Size(281, 476);
            this.Controls.Add(this.lbAddVehicle);
            this.Controls.Add(this.cboOwner);
            this.Controls.Add(this.cboSubscription);
            this.Controls.Add(this.lblSubscription);
            this.Controls.Add(this.dtpCheckIn);
            this.Controls.Add(this.lblCheckIn);
            this.Controls.Add(this.txtBrand);
            this.Controls.Add(this.cboType);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.btnUpdateImage);
            this.Controls.Add(this.pic);
            this.Controls.Add(this.lblPicture);
            this.Controls.Add(this.lblBrand);
            this.Controls.Add(this.lblType);
            this.Controls.Add(this.lblOwner);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "AddVehicleForm";
            this.Text = "AddVehicleForm";
            this.Load += new System.EventHandler(this.AddVehicleForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pic)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnUpdateImage;
        private System.Windows.Forms.PictureBox pic;
        private System.Windows.Forms.Label lblPicture;
        private System.Windows.Forms.Label lblBrand;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.Label lblOwner;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.ComboBox cboType;
        private System.Windows.Forms.TextBox txtBrand;
        private System.Windows.Forms.Label lblCheckIn;
        private System.Windows.Forms.DateTimePicker dtpCheckIn;
        private System.Windows.Forms.ComboBox cboSubscription;
        private System.Windows.Forms.Label lblSubscription;
        private System.Windows.Forms.ComboBox cboOwner;
        private System.Windows.Forms.Label lbAddVehicle;
    }
}