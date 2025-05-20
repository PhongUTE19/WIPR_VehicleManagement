namespace VehicleManagement.Contract
{
    partial class AddContractForm
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
            this.cboContractType = new System.Windows.Forms.ComboBox();
            this.lbType = new System.Windows.Forms.Label();
            this.lbCustomer = new System.Windows.Forms.Label();
            this.cbContractParty = new System.Windows.Forms.ComboBox();
            this.cboVehicle = new System.Windows.Forms.Label();
            this.cboVehicleAddContract = new System.Windows.Forms.ComboBox();
            this.lbStaff = new System.Windows.Forms.Label();
            this.cboStaff = new System.Windows.Forms.ComboBox();
            this.dtStart = new System.Windows.Forms.DateTimePicker();
            this.dtEnd = new System.Windows.Forms.DateTimePicker();
            this.lbDateStart = new System.Windows.Forms.Label();
            this.lbDateEnd = new System.Windows.Forms.Label();
            this.lbPrice = new System.Windows.Forms.Label();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.lbDescription = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.lbAddContract = new System.Windows.Forms.Label();
            this.panelRefContract = new System.Windows.Forms.Panel();
            this.comboBoxRefContract = new System.Windows.Forms.ComboBox();
            this.panelRefContract.SuspendLayout();
            this.SuspendLayout();
            // 
            // cboContractType
            // 
            this.cboContractType.FormattingEnabled = true;
            this.cboContractType.Location = new System.Drawing.Point(163, 70);
            this.cboContractType.Name = "cboContractType";
            this.cboContractType.Size = new System.Drawing.Size(200, 21);
            this.cboContractType.TabIndex = 0;
            // 
            // lbType
            // 
            this.lbType.AutoSize = true;
            this.lbType.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbType.ForeColor = System.Drawing.Color.Crimson;
            this.lbType.Location = new System.Drawing.Point(41, 71);
            this.lbType.Name = "lbType";
            this.lbType.Size = new System.Drawing.Size(88, 16);
            this.lbType.TabIndex = 1;
            this.lbType.Text = "Contract type:";
            // 
            // lbCustomer
            // 
            this.lbCustomer.AutoSize = true;
            this.lbCustomer.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCustomer.ForeColor = System.Drawing.Color.Crimson;
            this.lbCustomer.Location = new System.Drawing.Point(41, 111);
            this.lbCustomer.Name = "lbCustomer";
            this.lbCustomer.Size = new System.Drawing.Size(67, 16);
            this.lbCustomer.TabIndex = 2;
            this.lbCustomer.Text = "Customer:";
            // 
            // cbContractParty
            // 
            this.cbContractParty.FormattingEnabled = true;
            this.cbContractParty.Location = new System.Drawing.Point(163, 110);
            this.cbContractParty.Name = "cbContractParty";
            this.cbContractParty.Size = new System.Drawing.Size(200, 21);
            this.cbContractParty.TabIndex = 3;
            // 
            // cboVehicle
            // 
            this.cboVehicle.AutoSize = true;
            this.cboVehicle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboVehicle.ForeColor = System.Drawing.Color.Crimson;
            this.cboVehicle.Location = new System.Drawing.Point(41, 147);
            this.cboVehicle.Name = "cboVehicle";
            this.cboVehicle.Size = new System.Drawing.Size(55, 16);
            this.cboVehicle.TabIndex = 4;
            this.cboVehicle.Text = "Vehicle:";
            // 
            // cboVehicleAddContract
            // 
            this.cboVehicleAddContract.FormattingEnabled = true;
            this.cboVehicleAddContract.Location = new System.Drawing.Point(163, 146);
            this.cboVehicleAddContract.Name = "cboVehicleAddContract";
            this.cboVehicleAddContract.Size = new System.Drawing.Size(200, 21);
            this.cboVehicleAddContract.TabIndex = 5;
            // 
            // lbStaff
            // 
            this.lbStaff.AutoSize = true;
            this.lbStaff.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbStaff.ForeColor = System.Drawing.Color.Crimson;
            this.lbStaff.Location = new System.Drawing.Point(41, 186);
            this.lbStaff.Name = "lbStaff";
            this.lbStaff.Size = new System.Drawing.Size(36, 16);
            this.lbStaff.TabIndex = 6;
            this.lbStaff.Text = "Staff:";
            // 
            // cboStaff
            // 
            this.cboStaff.FormattingEnabled = true;
            this.cboStaff.Location = new System.Drawing.Point(163, 185);
            this.cboStaff.Name = "cboStaff";
            this.cboStaff.Size = new System.Drawing.Size(200, 21);
            this.cboStaff.TabIndex = 7;
            // 
            // dtStart
            // 
            this.dtStart.Location = new System.Drawing.Point(163, 221);
            this.dtStart.Name = "dtStart";
            this.dtStart.Size = new System.Drawing.Size(200, 20);
            this.dtStart.TabIndex = 8;
            // 
            // dtEnd
            // 
            this.dtEnd.Location = new System.Drawing.Point(163, 254);
            this.dtEnd.Name = "dtEnd";
            this.dtEnd.Size = new System.Drawing.Size(200, 20);
            this.dtEnd.TabIndex = 9;
            // 
            // lbDateStart
            // 
            this.lbDateStart.AutoSize = true;
            this.lbDateStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDateStart.ForeColor = System.Drawing.Color.Crimson;
            this.lbDateStart.Location = new System.Drawing.Point(41, 221);
            this.lbDateStart.Name = "lbDateStart";
            this.lbDateStart.Size = new System.Drawing.Size(67, 16);
            this.lbDateStart.TabIndex = 10;
            this.lbDateStart.Text = "Date start:";
            // 
            // lbDateEnd
            // 
            this.lbDateEnd.AutoSize = true;
            this.lbDateEnd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDateEnd.ForeColor = System.Drawing.Color.Crimson;
            this.lbDateEnd.Location = new System.Drawing.Point(41, 258);
            this.lbDateEnd.Name = "lbDateEnd";
            this.lbDateEnd.Size = new System.Drawing.Size(65, 16);
            this.lbDateEnd.TabIndex = 11;
            this.lbDateEnd.Text = "Date end:";
            // 
            // lbPrice
            // 
            this.lbPrice.AutoSize = true;
            this.lbPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPrice.ForeColor = System.Drawing.Color.Crimson;
            this.lbPrice.Location = new System.Drawing.Point(41, 291);
            this.lbPrice.Name = "lbPrice";
            this.lbPrice.Size = new System.Drawing.Size(41, 16);
            this.lbPrice.TabIndex = 12;
            this.lbPrice.Text = "Price:";
            // 
            // txtPrice
            // 
            this.txtPrice.Location = new System.Drawing.Point(163, 290);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(200, 20);
            this.txtPrice.TabIndex = 13;
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(163, 328);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(200, 51);
            this.txtDescription.TabIndex = 14;
            // 
            // lbDescription
            // 
            this.lbDescription.AutoSize = true;
            this.lbDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDescription.ForeColor = System.Drawing.Color.Crimson;
            this.lbDescription.Location = new System.Drawing.Point(41, 329);
            this.lbDescription.Name = "lbDescription";
            this.lbDescription.Size = new System.Drawing.Size(78, 16);
            this.lbDescription.TabIndex = 15;
            this.lbDescription.Text = "Description:";
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.LightGreen;
            this.btnSave.Location = new System.Drawing.Point(221, 399);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 16;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lbAddContract
            // 
            this.lbAddContract.AutoSize = true;
            this.lbAddContract.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbAddContract.ForeColor = System.Drawing.Color.Crimson;
            this.lbAddContract.Location = new System.Drawing.Point(198, 24);
            this.lbAddContract.Name = "lbAddContract";
            this.lbAddContract.Size = new System.Drawing.Size(131, 24);
            this.lbAddContract.TabIndex = 17;
            this.lbAddContract.Text = "Add Contract";
            // 
            // panelRefContract
            // 
            this.panelRefContract.Controls.Add(this.comboBoxRefContract);
            this.panelRefContract.Location = new System.Drawing.Point(387, 71);
            this.panelRefContract.Name = "panelRefContract";
            this.panelRefContract.Size = new System.Drawing.Size(147, 60);
            this.panelRefContract.TabIndex = 18;
            // 
            // comboBoxRefContract
            // 
            this.comboBoxRefContract.FormattingEnabled = true;
            this.comboBoxRefContract.Location = new System.Drawing.Point(19, 19);
            this.comboBoxRefContract.Name = "comboBoxRefContract";
            this.comboBoxRefContract.Size = new System.Drawing.Size(121, 21);
            this.comboBoxRefContract.TabIndex = 19;
            // 
            // AddContractForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.RosyBrown;
            this.ClientSize = new System.Drawing.Size(547, 464);
            this.Controls.Add(this.panelRefContract);
            this.Controls.Add(this.lbAddContract);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lbDescription);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.txtPrice);
            this.Controls.Add(this.lbPrice);
            this.Controls.Add(this.lbDateEnd);
            this.Controls.Add(this.lbDateStart);
            this.Controls.Add(this.dtEnd);
            this.Controls.Add(this.dtStart);
            this.Controls.Add(this.cboStaff);
            this.Controls.Add(this.lbStaff);
            this.Controls.Add(this.cboVehicleAddContract);
            this.Controls.Add(this.cboVehicle);
            this.Controls.Add(this.cbContractParty);
            this.Controls.Add(this.lbCustomer);
            this.Controls.Add(this.lbType);
            this.Controls.Add(this.cboContractType);
            this.Name = "AddContractForm";
            this.Text = "AddContractForm";
            this.Load += new System.EventHandler(this.AddContractForm_Load);
            this.panelRefContract.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboContractType;
        private System.Windows.Forms.Label lbType;
        private System.Windows.Forms.Label lbCustomer;
        private System.Windows.Forms.ComboBox cbContractParty;
        private System.Windows.Forms.Label cboVehicle;
        private System.Windows.Forms.ComboBox cboVehicleAddContract;
        private System.Windows.Forms.Label lbStaff;
        private System.Windows.Forms.ComboBox cboStaff;
        private System.Windows.Forms.DateTimePicker dtStart;
        private System.Windows.Forms.DateTimePicker dtEnd;
        private System.Windows.Forms.Label lbDateStart;
        private System.Windows.Forms.Label lbDateEnd;
        private System.Windows.Forms.Label lbPrice;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label lbDescription;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lbAddContract;
        private System.Windows.Forms.Panel panelRefContract;
        private System.Windows.Forms.ComboBox comboBoxRefContract;
    }
}