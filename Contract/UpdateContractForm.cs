using System;
using System.Data;
using System.Windows.Forms;

namespace VehicleManagement.Contract
{
    public partial class UpdateContractForm : Form
    {
        private int contractId;
        private Contract currentContract;

        public UpdateContractForm(int contractId)
        {
            InitializeComponent();
            this.contractId = contractId;
        }

        private void UpdateContractForm_Load(object sender, EventArgs e)
        {
            cboContractType.Items.AddRange(new string[] { "Rent", "Consignment", "Lease" });

            LoadParticipants("Rent"); // Mặc định là Rent
            LoadVehicles(companyVehiclesOnly: true); // mặc định
            LoadStaff();
            LoadConsignmentContracts();

            panelRefContract.Visible = false;

            LoadContractData();
        }

        private void LoadParticipants(string type)
        {
            string query = "";

            if (type == "Consignment")
            {
                query = "SELECT OwnerId AS id, FirstName + ' ' + LastName AS fullName FROM Owner";
            }
            else // Rent or Lease
            {
                query = "SELECT Id, FirstName + ' ' + LastName AS fullName FROM Customer";
            }

            DataTable dt = SqlHelper.GetTable(new System.Data.SqlClient.SqlCommand(query));
            cboCustomer.DataSource = dt;
            cboCustomer.DisplayMember = "fullName";
            cboCustomer.ValueMember = "id";
        }
        private void LoadVehicles(bool companyVehiclesOnly)
        {
            string query = companyVehiclesOnly
                ? "SELECT id, brand + ' - ' + type AS display FROM Vehicle WHERE OwnerId IS NULL"
                : "SELECT id, brand + ' - ' + type AS display FROM Vehicle";

            DataTable dt = SqlHelper.GetTable(new System.Data.SqlClient.SqlCommand(query));
            cboVehicleUpdateContract.DataSource = dt;
            cboVehicleUpdateContract.DisplayMember = "display";
            cboVehicleUpdateContract.ValueMember = "id";
        }
        private void LoadStaff()
        {
            string query = "SELECT id, firstName + ' ' + lastName AS fullName FROM Staff";
            DataTable dt = SqlHelper.GetTable(new System.Data.SqlClient.SqlCommand(query));
            cboStaff.DataSource = dt;
            cboStaff.DisplayMember = "fullName";
            cboStaff.ValueMember = "id";
        }

        private void LoadConsignmentContracts()
        {
            string query = @"
                SELECT C.id, V.brand + ' ' + V.type AS vehicle
                FROM Contract C
                JOIN Vehicle V ON C.vehicleId = V.id
                WHERE C.type = 'Consignment'";
            DataTable dt = SqlHelper.GetTable(new System.Data.SqlClient.SqlCommand(query));

            comboBoxRefContract.DataSource = dt;
            comboBoxRefContract.DisplayMember = "vehicle";
            comboBoxRefContract.ValueMember = "id";
        }

        private void LoadContractData()
        {
            currentContract = Contract.GetById(contractId);
            if (currentContract == null)
            {
                MessageBox.Show("Không tìm thấy hợp đồng.");
                this.Close();
                return;
            }

            cboContractType.SelectedItem = currentContract.Type;
            LoadParticipants(currentContract.Type); // <- THÊM DÒNG NÀY
            cboCustomer.SelectedValue = currentContract.CustomerId;
            cboStaff.SelectedValue = currentContract.StaffId;
            dtStart.Value = currentContract.StartDate;
            dtEnd.Value = currentContract.EndDate;
            txtPrice.Text = currentContract.Price.ToString();
            txtDescription.Text = currentContract.Description;

            if (currentContract.Type == "Lease")
            {
                panelRefContract.Visible = true;
                LoadConsignmentContracts();
                comboBoxRefContract.SelectedValue = currentContract.RefContractId;

                // Tự động chọn đúng xe theo RefContract
                if (currentContract.RefContractId.HasValue)
                {
                    string query = $"SELECT vehicleId FROM Contract WHERE id = {currentContract.RefContractId}";
                    object vehicleIdObj = SqlHelper.ExecuteScalar(query);
                    if (vehicleIdObj != null && vehicleIdObj != DBNull.Value)
                    {
                        int vehicleId = Convert.ToInt32(vehicleIdObj);

                        DataTable dt = new DataTable();
                        dt.Columns.Add("id", typeof(int));
                        dt.Columns.Add("display", typeof(string));

                        string vehicleDisplayQuery = $"SELECT brand + ' - ' + type FROM Vehicle WHERE id = {vehicleId}";
                        string vehicleDisplay = SqlHelper.ExecuteScalar(vehicleDisplayQuery)?.ToString() ?? "";

                        dt.Rows.Add(vehicleId, vehicleDisplay);
                        cboVehicleUpdateContract.DataSource = dt;
                        cboVehicleUpdateContract.DisplayMember = "display";
                        cboVehicleUpdateContract.ValueMember = "id";
                        cboVehicleUpdateContract.SelectedValue = vehicleId;
                    }
                }

                cboVehicleUpdateContract.Enabled = false;
            }
            else
            {
                cboVehicleUpdateContract.Enabled = true;
                LoadVehicles(companyVehiclesOnly: currentContract.Type == "Rent");
                cboVehicleUpdateContract.SelectedValue = currentContract.VehicleId;
            }
        }

        private void cboContractType_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedType = cboContractType.SelectedItem.ToString();
            LoadParticipants(selectedType); // <== Thêm dòng này

            if (selectedType == "Lease")
            {
                panelRefContract.Visible = true;
                LoadConsignmentContracts();
                cboVehicleUpdateContract.Enabled = false;
            }
            else
            {
                panelRefContract.Visible = false;
                cboVehicleUpdateContract.Enabled = true;
                LoadVehicles(companyVehiclesOnly: selectedType == "Rent");
            }
        }

        private void comboBoxRefContract_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxRefContract.SelectedValue is int refContractId)
            {
                string query = $"SELECT vehicleId FROM Contract WHERE id = {refContractId}";
                object result = SqlHelper.ExecuteScalar(query);

                if (result != null && result != DBNull.Value)
                {
                    int vehicleId = Convert.ToInt32(result);
                    string vehicleDisplayQuery = $"SELECT brand + ' - ' + type FROM Vehicle WHERE id = {vehicleId}";
                    string vehicleDisplay = SqlHelper.ExecuteScalar(vehicleDisplayQuery)?.ToString() ?? "";

                    DataTable dt = new DataTable();
                    dt.Columns.Add("id", typeof(int));
                    dt.Columns.Add("display", typeof(string));
                    dt.Rows.Add(vehicleId, vehicleDisplay);

                    cboVehicleUpdateContract.DataSource = dt;
                    cboVehicleUpdateContract.DisplayMember = "display";
                    cboVehicleUpdateContract.ValueMember = "id";
                    cboVehicleUpdateContract.SelectedValue = vehicleId;
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                currentContract.Type = cboContractType.SelectedItem.ToString();
                currentContract.CustomerId = Convert.ToInt32(cboCustomer.SelectedValue);
                currentContract.StaffId = Convert.ToInt32(cboStaff.SelectedValue);
                currentContract.StartDate = dtStart.Value;
                currentContract.EndDate = dtEnd.Value;
                currentContract.Price = Convert.ToDecimal(txtPrice.Text);
                currentContract.Description = txtDescription.Text;

                if (currentContract.Type == "Lease")
                {
                    if (comboBoxRefContract.SelectedValue == null)
                    {
                        MessageBox.Show("Vui lòng chọn hợp đồng ký gửi!");
                        return;
                    }

                    if (comboBoxRefContract.SelectedValue is int refContractId)
                    {
                        currentContract.RefContractId = refContractId;

                        // Lấy VehicleId từ hợp đồng ký gửi
                        string query = $"SELECT vehicleId FROM Contract WHERE id = {refContractId}";
                        object vehicleIdObj = SqlHelper.ExecuteScalar(query);

                        if (vehicleIdObj == null || vehicleIdObj == DBNull.Value)
                        {
                            MessageBox.Show("Hợp đồng ký gửi không hợp lệ!");
                            return;
                        }

                        currentContract.VehicleId = Convert.ToInt32(vehicleIdObj);
                    }
                    else
                    {
                        MessageBox.Show("Hợp đồng ký gửi không hợp lệ!");
                        return;
                    }
                }
                else
                {
                    currentContract.RefContractId = null;
                    currentContract.VehicleId = Convert.ToInt32(cboVehicleUpdateContract.SelectedValue);
                }


                bool result = currentContract.Update();

                if (result)
                {
                    MessageBox.Show("Cập nhật hợp đồng thành công!");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Cập nhật thất bại!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }
    }
}
