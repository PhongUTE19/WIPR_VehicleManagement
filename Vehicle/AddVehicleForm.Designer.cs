
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
            this.pic = new System.Windows.Forms.PictureBox();
            this.txtOwner = new System.Windows.Forms.TextBox();
            this.txtVehicleId = new System.Windows.Forms.TextBox();
            this.lblPicture = new System.Windows.Forms.Label();
            this.lblBrand = new System.Windows.Forms.Label();
            this.lblType = new System.Windows.Forms.Label();
            this.lblOwnerId = new System.Windows.Forms.Label();
            this.lblVehicleId = new System.Windows.Forms.Label();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.cboType = new System.Windows.Forms.ComboBox();
            this.txtBrand = new System.Windows.Forms.TextBox();
            this.lblCheckIn = new System.Windows.Forms.Label();
            this.dtpCheckIn = new System.Windows.Forms.DateTimePicker();
            this.cboSubscription = new System.Windows.Forms.ComboBox();
            this.lblSubscription = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pic)).BeginInit();
            this.SuspendLayout();
            // 
            // btnUpdateImage
            // 
            this.btnUpdateImage.Location = new System.Drawing.Point(110, 429);
            this.btnUpdateImage.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnUpdateImage.Name = "btnUpdateImage";
            this.btnUpdateImage.Size = new System.Drawing.Size(100, 30);
            this.btnUpdateImage.TabIndex = 6;
            this.btnUpdateImage.Text = "Update";
            this.btnUpdateImage.UseVisualStyleBackColor = true;
            this.btnUpdateImage.Click += new System.EventHandler(this.btnUpdateImage_Click);
            // 
            // pic
            // 
            this.pic.Location = new System.Drawing.Point(110, 254);
            this.pic.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pic.Name = "pic";
            this.pic.Size = new System.Drawing.Size(160, 160);
            this.pic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic.TabIndex = 108;
            this.pic.TabStop = false;
            // 
            // txtOwner
            // 
            this.txtOwner.Location = new System.Drawing.Point(110, 55);
            this.txtOwner.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtOwner.Name = "txtOwner";
            this.txtOwner.Size = new System.Drawing.Size(200, 22);
            this.txtOwner.TabIndex = 1;
            // 
            // txtVehicleId
            // 
            this.txtVehicleId.Location = new System.Drawing.Point(110, 20);
            this.txtVehicleId.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtVehicleId.Name = "txtVehicleId";
            this.txtVehicleId.Size = new System.Drawing.Size(200, 22);
            this.txtVehicleId.TabIndex = 0;
            // 
            // lblPicture
            // 
            this.lblPicture.AutoSize = true;
            this.lblPicture.ForeColor = System.Drawing.Color.White;
            this.lblPicture.Location = new System.Drawing.Point(25, 254);
            this.lblPicture.Name = "lblPicture";
            this.lblPicture.Size = new System.Drawing.Size(56, 17);
            this.lblPicture.TabIndex = 117;
            this.lblPicture.Text = "Picture:";
            // 
            // lblBrand
            // 
            this.lblBrand.AutoSize = true;
            this.lblBrand.ForeColor = System.Drawing.Color.White;
            this.lblBrand.Location = new System.Drawing.Point(25, 125);
            this.lblBrand.Name = "lblBrand";
            this.lblBrand.Size = new System.Drawing.Size(50, 17);
            this.lblBrand.TabIndex = 113;
            this.lblBrand.Text = "Brand:";
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.ForeColor = System.Drawing.Color.White;
            this.lblType.Location = new System.Drawing.Point(25, 90);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(44, 17);
            this.lblType.TabIndex = 114;
            this.lblType.Text = "Type:";
            // 
            // lblOwnerId
            // 
            this.lblOwnerId.AutoSize = true;
            this.lblOwnerId.ForeColor = System.Drawing.Color.White;
            this.lblOwnerId.Location = new System.Drawing.Point(25, 55);
            this.lblOwnerId.Name = "lblOwnerId";
            this.lblOwnerId.Size = new System.Drawing.Size(68, 17);
            this.lblOwnerId.TabIndex = 115;
            this.lblOwnerId.Text = "Owner Id:";
            // 
            // lblVehicleId
            // 
            this.lblVehicleId.AutoSize = true;
            this.lblVehicleId.ForeColor = System.Drawing.Color.White;
            this.lblVehicleId.Location = new System.Drawing.Point(25, 20);
            this.lblVehicleId.Name = "lblVehicleId";
            this.lblVehicleId.Size = new System.Drawing.Size(73, 17);
            this.lblVehicleId.TabIndex = 116;
            this.lblVehicleId.Text = "Vehicle Id:";
            // 
            // btnConfirm
            // 
            this.btnConfirm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(220)))), ((int)(((byte)(130)))));
            this.btnConfirm.Location = new System.Drawing.Point(110, 474);
            this.btnConfirm.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(140, 50);
            this.btnConfirm.TabIndex = 10;
            this.btnConfirm.Text = "Confirm";
            this.btnConfirm.UseVisualStyleBackColor = false;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // cboType
            // 
            this.cboType.FormattingEnabled = true;
            this.cboType.Location = new System.Drawing.Point(110, 90);
            this.cboType.Name = "cboType";
            this.cboType.Size = new System.Drawing.Size(200, 24);
            this.cboType.TabIndex = 2;
            // 
            // txtBrand
            // 
            this.txtBrand.Location = new System.Drawing.Point(110, 125);
            this.txtBrand.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtBrand.Name = "txtBrand";
            this.txtBrand.Size = new System.Drawing.Size(200, 22);
            this.txtBrand.TabIndex = 3;
            // 
            // lblCheckIn
            // 
            this.lblCheckIn.AutoSize = true;
            this.lblCheckIn.ForeColor = System.Drawing.Color.White;
            this.lblCheckIn.Location = new System.Drawing.Point(25, 160);
            this.lblCheckIn.Name = "lblCheckIn";
            this.lblCheckIn.Size = new System.Drawing.Size(66, 17);
            this.lblCheckIn.TabIndex = 134;
            this.lblCheckIn.Text = "Check in:";
            // 
            // dtpCheckIn
            // 
            this.dtpCheckIn.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpCheckIn.Location = new System.Drawing.Point(110, 160);
            this.dtpCheckIn.Name = "dtpCheckIn";
            this.dtpCheckIn.Size = new System.Drawing.Size(200, 22);
            this.dtpCheckIn.TabIndex = 4;
            // 
            // cboSubscription
            // 
            this.cboSubscription.FormattingEnabled = true;
            this.cboSubscription.Location = new System.Drawing.Point(110, 195);
            this.cboSubscription.Name = "cboSubscription";
            this.cboSubscription.Size = new System.Drawing.Size(200, 24);
            this.cboSubscription.TabIndex = 5;
            // 
            // lblSubscription
            // 
            this.lblSubscription.AutoSize = true;
            this.lblSubscription.ForeColor = System.Drawing.Color.White;
            this.lblSubscription.Location = new System.Drawing.Point(25, 195);
            this.lblSubscription.Name = "lblSubscription";
            this.lblSubscription.Size = new System.Drawing.Size(90, 17);
            this.lblSubscription.TabIndex = 136;
            this.lblSubscription.Text = "Subscription:";
            // 
            // AddVehicleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(38)))), ((int)(((byte)(65)))));
            this.ClientSize = new System.Drawing.Size(332, 553);
            this.Controls.Add(this.cboSubscription);
            this.Controls.Add(this.lblSubscription);
            this.Controls.Add(this.dtpCheckIn);
            this.Controls.Add(this.lblCheckIn);
            this.Controls.Add(this.txtBrand);
            this.Controls.Add(this.cboType);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.btnUpdateImage);
            this.Controls.Add(this.pic);
            this.Controls.Add(this.txtOwner);
            this.Controls.Add(this.txtVehicleId);
            this.Controls.Add(this.lblPicture);
            this.Controls.Add(this.lblBrand);
            this.Controls.Add(this.lblType);
            this.Controls.Add(this.lblOwnerId);
            this.Controls.Add(this.lblVehicleId);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
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
        private System.Windows.Forms.TextBox txtOwner;
        private System.Windows.Forms.TextBox txtVehicleId;
        private System.Windows.Forms.Label lblPicture;
        private System.Windows.Forms.Label lblBrand;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.Label lblOwnerId;
        private System.Windows.Forms.Label lblVehicleId;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.ComboBox cboType;
        private System.Windows.Forms.TextBox txtBrand;
        private System.Windows.Forms.Label lblCheckIn;
        private System.Windows.Forms.DateTimePicker dtpCheckIn;
        private System.Windows.Forms.ComboBox cboSubscription;
        private System.Windows.Forms.Label lblSubscription;
    }
}