
namespace VehicleManagement
{
    partial class AddStaffForm
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
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.txtStaffId = new System.Windows.Forms.TextBox();
            this.lblPicture = new System.Windows.Forms.Label();
            this.lblGender = new System.Windows.Forms.Label();
            this.lblLastName = new System.Windows.Forms.Label();
            this.lblFirstName = new System.Windows.Forms.Label();
            this.lblStaffId = new System.Windows.Forms.Label();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.lblBirthdate = new System.Windows.Forms.Label();
            this.dtpBirthdate = new System.Windows.Forms.DateTimePicker();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.cboGender = new System.Windows.Forms.ComboBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.cboRole = new System.Windows.Forms.ComboBox();
            this.lblRole = new System.Windows.Forms.Label();
            this.cboJob = new System.Windows.Forms.ComboBox();
            this.lblJob = new System.Windows.Forms.Label();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.lblPhone = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.lblAddress = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pic)).BeginInit();
            this.SuspendLayout();
            // 
            // btnUpdateImage
            // 
            this.btnUpdateImage.Location = new System.Drawing.Point(110, 564);
            this.btnUpdateImage.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnUpdateImage.Name = "btnUpdateImage";
            this.btnUpdateImage.Size = new System.Drawing.Size(100, 30);
            this.btnUpdateImage.TabIndex = 10;
            this.btnUpdateImage.Text = "Update";
            this.btnUpdateImage.UseVisualStyleBackColor = true;
            this.btnUpdateImage.Click += new System.EventHandler(this.btnUpdateImage_Click);
            // 
            // pic
            // 
            this.pic.Location = new System.Drawing.Point(110, 389);
            this.pic.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pic.Name = "pic";
            this.pic.Size = new System.Drawing.Size(160, 160);
            this.pic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic.TabIndex = 108;
            this.pic.TabStop = false;
            // 
            // txtFirstName
            // 
            this.txtFirstName.Location = new System.Drawing.Point(110, 55);
            this.txtFirstName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(200, 22);
            this.txtFirstName.TabIndex = 1;
            // 
            // txtStaffId
            // 
            this.txtStaffId.Location = new System.Drawing.Point(110, 20);
            this.txtStaffId.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtStaffId.Name = "txtStaffId";
            this.txtStaffId.Size = new System.Drawing.Size(200, 22);
            this.txtStaffId.TabIndex = 0;
            // 
            // lblPicture
            // 
            this.lblPicture.AutoSize = true;
            this.lblPicture.ForeColor = System.Drawing.Color.White;
            this.lblPicture.Location = new System.Drawing.Point(25, 389);
            this.lblPicture.Name = "lblPicture";
            this.lblPicture.Size = new System.Drawing.Size(56, 17);
            this.lblPicture.TabIndex = 117;
            this.lblPicture.Text = "Picture:";
            // 
            // lblGender
            // 
            this.lblGender.AutoSize = true;
            this.lblGender.ForeColor = System.Drawing.Color.White;
            this.lblGender.Location = new System.Drawing.Point(25, 125);
            this.lblGender.Name = "lblGender";
            this.lblGender.Size = new System.Drawing.Size(60, 17);
            this.lblGender.TabIndex = 113;
            this.lblGender.Text = "Gender:";
            // 
            // lblLastName
            // 
            this.lblLastName.AutoSize = true;
            this.lblLastName.ForeColor = System.Drawing.Color.White;
            this.lblLastName.Location = new System.Drawing.Point(25, 90);
            this.lblLastName.Name = "lblLastName";
            this.lblLastName.Size = new System.Drawing.Size(78, 17);
            this.lblLastName.TabIndex = 114;
            this.lblLastName.Text = "Last name:";
            // 
            // lblFirstName
            // 
            this.lblFirstName.AutoSize = true;
            this.lblFirstName.ForeColor = System.Drawing.Color.White;
            this.lblFirstName.Location = new System.Drawing.Point(25, 55);
            this.lblFirstName.Name = "lblFirstName";
            this.lblFirstName.Size = new System.Drawing.Size(78, 17);
            this.lblFirstName.TabIndex = 115;
            this.lblFirstName.Text = "First name:";
            // 
            // lblStaffId
            // 
            this.lblStaffId.AutoSize = true;
            this.lblStaffId.ForeColor = System.Drawing.Color.White;
            this.lblStaffId.Location = new System.Drawing.Point(25, 20);
            this.lblStaffId.Name = "lblStaffId";
            this.lblStaffId.Size = new System.Drawing.Size(56, 17);
            this.lblStaffId.TabIndex = 116;
            this.lblStaffId.Text = "Staff Id:";
            // 
            // btnConfirm
            // 
            this.btnConfirm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(220)))), ((int)(((byte)(130)))));
            this.btnConfirm.Location = new System.Drawing.Point(110, 609);
            this.btnConfirm.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(140, 50);
            this.btnConfirm.TabIndex = 11;
            this.btnConfirm.Text = "Confirm";
            this.btnConfirm.UseVisualStyleBackColor = false;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // lblBirthdate
            // 
            this.lblBirthdate.AutoSize = true;
            this.lblBirthdate.ForeColor = System.Drawing.Color.White;
            this.lblBirthdate.Location = new System.Drawing.Point(25, 160);
            this.lblBirthdate.Name = "lblBirthdate";
            this.lblBirthdate.Size = new System.Drawing.Size(69, 17);
            this.lblBirthdate.TabIndex = 134;
            this.lblBirthdate.Text = "Birthdate:";
            // 
            // dtpBirthdate
            // 
            this.dtpBirthdate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpBirthdate.Location = new System.Drawing.Point(110, 160);
            this.dtpBirthdate.Name = "dtpBirthdate";
            this.dtpBirthdate.Size = new System.Drawing.Size(200, 22);
            this.dtpBirthdate.TabIndex = 4;
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.ForeColor = System.Drawing.Color.White;
            this.lblEmail.Location = new System.Drawing.Point(25, 265);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(46, 17);
            this.lblEmail.TabIndex = 136;
            this.lblEmail.Text = "Email:";
            // 
            // txtLastName
            // 
            this.txtLastName.Location = new System.Drawing.Point(110, 90);
            this.txtLastName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(200, 22);
            this.txtLastName.TabIndex = 2;
            // 
            // cboGender
            // 
            this.cboGender.FormattingEnabled = true;
            this.cboGender.Location = new System.Drawing.Point(110, 125);
            this.cboGender.Name = "cboGender";
            this.cboGender.Size = new System.Drawing.Size(200, 24);
            this.cboGender.TabIndex = 3;
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(110, 265);
            this.txtEmail.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(200, 22);
            this.txtEmail.TabIndex = 7;
            // 
            // cboRole
            // 
            this.cboRole.FormattingEnabled = true;
            this.cboRole.Location = new System.Drawing.Point(110, 300);
            this.cboRole.Name = "cboRole";
            this.cboRole.Size = new System.Drawing.Size(200, 24);
            this.cboRole.TabIndex = 8;
            // 
            // lblRole
            // 
            this.lblRole.AutoSize = true;
            this.lblRole.ForeColor = System.Drawing.Color.White;
            this.lblRole.Location = new System.Drawing.Point(25, 300);
            this.lblRole.Name = "lblRole";
            this.lblRole.Size = new System.Drawing.Size(41, 17);
            this.lblRole.TabIndex = 138;
            this.lblRole.Text = "Role:";
            // 
            // cboJob
            // 
            this.cboJob.FormattingEnabled = true;
            this.cboJob.Location = new System.Drawing.Point(110, 335);
            this.cboJob.Name = "cboJob";
            this.cboJob.Size = new System.Drawing.Size(200, 24);
            this.cboJob.TabIndex = 9;
            // 
            // lblJob
            // 
            this.lblJob.AutoSize = true;
            this.lblJob.ForeColor = System.Drawing.Color.White;
            this.lblJob.Location = new System.Drawing.Point(25, 335);
            this.lblJob.Name = "lblJob";
            this.lblJob.Size = new System.Drawing.Size(35, 17);
            this.lblJob.TabIndex = 140;
            this.lblJob.Text = "Job:";
            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(110, 195);
            this.txtPhone.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(200, 22);
            this.txtPhone.TabIndex = 5;
            // 
            // lblPhone
            // 
            this.lblPhone.AutoSize = true;
            this.lblPhone.ForeColor = System.Drawing.Color.White;
            this.lblPhone.Location = new System.Drawing.Point(25, 195);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new System.Drawing.Size(53, 17);
            this.lblPhone.TabIndex = 142;
            this.lblPhone.Text = "Phone:";
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(110, 230);
            this.txtAddress.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(200, 22);
            this.txtAddress.TabIndex = 6;
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.ForeColor = System.Drawing.Color.White;
            this.lblAddress.Location = new System.Drawing.Point(25, 230);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(64, 17);
            this.lblAddress.TabIndex = 144;
            this.lblAddress.Text = "Address:";
            // 
            // AddStaffForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(38)))), ((int)(((byte)(65)))));
            this.ClientSize = new System.Drawing.Size(332, 696);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.lblAddress);
            this.Controls.Add(this.txtPhone);
            this.Controls.Add(this.lblPhone);
            this.Controls.Add(this.cboJob);
            this.Controls.Add(this.lblJob);
            this.Controls.Add(this.cboRole);
            this.Controls.Add(this.lblRole);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.cboGender);
            this.Controls.Add(this.txtLastName);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.dtpBirthdate);
            this.Controls.Add(this.lblBirthdate);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.btnUpdateImage);
            this.Controls.Add(this.pic);
            this.Controls.Add(this.txtFirstName);
            this.Controls.Add(this.txtStaffId);
            this.Controls.Add(this.lblPicture);
            this.Controls.Add(this.lblGender);
            this.Controls.Add(this.lblLastName);
            this.Controls.Add(this.lblFirstName);
            this.Controls.Add(this.lblStaffId);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "AddStaffForm";
            this.Text = "AddStaffForm";
            this.Load += new System.EventHandler(this.AddVehicleForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pic)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnUpdateImage;
        private System.Windows.Forms.PictureBox pic;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.TextBox txtStaffId;
        private System.Windows.Forms.Label lblPicture;
        private System.Windows.Forms.Label lblGender;
        private System.Windows.Forms.Label lblLastName;
        private System.Windows.Forms.Label lblFirstName;
        private System.Windows.Forms.Label lblStaffId;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.Label lblBirthdate;
        private System.Windows.Forms.DateTimePicker dtpBirthdate;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.ComboBox cboGender;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.ComboBox cboRole;
        private System.Windows.Forms.Label lblRole;
        private System.Windows.Forms.ComboBox cboJob;
        private System.Windows.Forms.Label lblJob;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label lblAddress;
    }
}