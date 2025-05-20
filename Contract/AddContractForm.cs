using System;
using System.Data;
using System.Windows.Forms;

namespace VehicleManagement.Contract
{
    public partial class AddContractForm : Form
    {
        public AddContractForm()
        {
            InitializeComponent();
        }

        private void AddContractForm_Load(object sender, EventArgs e)
        {
            cboContractType.Items.AddRange(new string[] { "Rent", "Consignment", "Lease" });

            string checkConsignmentQuery = "SELECT COUNT(*) FROM Contract WHERE type = 'Consignment'";
            int consignmentCount = Convert.ToInt32(SqlHelper.ExecuteScalar(checkConsignmentQuery));
            if (consignmentCount == 0)
            {
                cboContractType.Items.Remove("Lease");
                MessageBox.Show("Cần ít nhất một hợp đồng ký gửi để tạo hợp đồng cho thuê (Lease).");
            }

            cboContractType.SelectedIndex = 0;

            LoadContractParties();
            LoadVehicles(companyVehiclesOnly: true);
            LoadStaff();

            panelRefContract.Visible = false;
        }


        private void LoadContractParties()
        {
            string selectedType = cboContractType.SelectedItem?.ToString() ?? "";
            MessageBox.Show("Selected contract type: " + selectedType); // Kiểm tra loại hợp đồng thực tế

            string query;
            if (selectedType == "Consignment")
            {
                query = "SELECT OwnerId AS id, FirstName + ' ' + LastName AS fullName FROM Owner";
            }
            else
            {
                query = "SELECT Id, FirstName + ' ' + LastName AS fullName FROM Customer";
            }

            DataTable dt = SqlHelper.GetData(query);
            cbContractParty.DataSource = dt;
            cbContractParty.DisplayMember = "fullName";
            cbContractParty.ValueMember = "id";
        }



        private void LoadVehicles(bool companyVehiclesOnly)
        {
            string query = companyVehiclesOnly
                ? "SELECT id, brand + ' - ' + type AS display FROM Vehicle WHERE OwnerId IS NULL"
                : "SELECT id, brand + ' - ' + type AS display FROM Vehicle";

            DataTable dt = SqlHelper.GetData(query);
            cboVehicleAddContract.DataSource = dt;
            cboVehicleAddContract.DisplayMember = "display";
            cboVehicleAddContract.ValueMember = "id";
        }

        private void LoadStaff()
        {
            string query = "SELECT id, firstName + ' ' + lastName AS fullName FROM Staff";
            DataTable dt = SqlHelper.GetData(query);
            cboStaff.DataSource = dt;
            cboStaff.DisplayMember = "fullName";
            cboStaff.ValueMember = "id";
        }

        private void cboContractType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboContractType.SelectedIndex < 0) return;

            string selectedType = cboContractType.SelectedItem.ToString();

            if (selectedType == "Consignment")
            {
                panelRefContract.Visible = false;
                cboVehicleAddContract.Enabled = true;
                LoadVehicles(companyVehiclesOnly: false);
                LoadContractParties();
            }
            else if (selectedType == "Lease")
            {
                panelRefContract.Visible = true;
                LoadConsignmentContracts();

                if (comboBoxRefContract.Items.Count == 0)
                {
                    MessageBox.Show("Không có hợp đồng ký gửi nào để tạo hợp đồng cho thuê!");
                    cboContractType.SelectedIndex = 0;
                    return;
                }

                cboVehicleAddContract.Enabled = false;
                LoadContractParties();
            }
            else // Rent
            {
                panelRefContract.Visible = false;
                cboVehicleAddContract.Enabled = true;
                LoadVehicles(companyVehiclesOnly: true);
                LoadContractParties();
            }
        }


        private void LoadConsignmentContracts()
        {
            string query = @"
                SELECT C.id, V.brand + ' ' + V.type AS vehicle
                FROM Contract C
                JOIN Vehicle V ON C.vehicleId = V.id
                WHERE C.type = 'Consignment'";

            DataTable dt = SqlHelper.GetData(query);

            if (dt.Rows.Count == 0)
            {
                comboBoxRefContract.DataSource = null;
                return;
            }

            comboBoxRefContract.DataSource = dt;
            comboBoxRefContract.DisplayMember = "vehicle";
            comboBoxRefContract.ValueMember = "id";
        }

        private void cboVehicleAddContract_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboVehicleAddContract.SelectedValue == null) return;

            int vehicleId = Convert.ToInt32(cboVehicleAddContract.SelectedValue);
            string ownerQuery = @"
                SELECT O.FirstName + ' ' + O.LastName
                FROM Vehicle V
                JOIN Owner O ON V.OwnerId = O.OwnerId
                WHERE V.Id = @vehicleId";

            var cmd = new System.Data.SqlClient.SqlCommand(ownerQuery);
            cmd.Parameters.AddWithValue("@vehicleId", vehicleId);
            string owner = SqlHelper.ExecuteScalar(cmd)?.ToString();

            string selectedType = cboContractType.SelectedItem.ToString();

            if (selectedType == "Consignment")
            {
                int customerId = Convert.ToInt32(cbContractParty.SelectedValue);
                string customerQuery = $"SELECT FirstName + ' ' + LastName FROM Customer WHERE Id = {customerId}";
                string customerName = SqlHelper.ExecuteScalar(customerQuery)?.ToString();

                if (owner != customerName)
                {
                    MessageBox.Show("Xe không thuộc sở hữu khách hàng được chọn!");
                    cboVehicleAddContract.SelectedIndex = -1;
                }
            }
            else if (selectedType == "Rent")
            {
                string usedQuery = $"SELECT COUNT(*) FROM Contract WHERE vehicleId = {vehicleId} AND endDate >= GETDATE()";
                int inUse = Convert.ToInt32(SqlHelper.ExecuteScalar(usedQuery));

                if (inUse > 0)
                {
                    MessageBox.Show("Xe đang được sử dụng trong hợp đồng khác!");
                    cboVehicleAddContract.SelectedIndex = -1;
                }
            }
        }

        private void comboBoxRefContract_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxRefContract.SelectedValue == null) return;

            int refContractId = Convert.ToInt32(comboBoxRefContract.SelectedValue);
            string query = $"SELECT vehicleId FROM Contract WHERE id = {refContractId}";
            object vehicleIdObj = SqlHelper.ExecuteScalar(query);

            if (vehicleIdObj == null || vehicleIdObj == DBNull.Value)
            {
                MessageBox.Show("Không tìm thấy hợp đồng ký gửi hợp lệ.");
                return;
            }

            int vehicleId = Convert.ToInt32(vehicleIdObj);

            DataTable dt = new DataTable();
            dt.Columns.Add("id", typeof(int));
            dt.Columns.Add("display", typeof(string));

            string vehicleDisplayQuery = $"SELECT brand + ' - ' + type FROM Vehicle WHERE id = {vehicleId}";
            string vehicleDisplay = SqlHelper.ExecuteScalar(vehicleDisplayQuery)?.ToString() ?? "";

            dt.Rows.Add(vehicleId, vehicleDisplay);
            cboVehicleAddContract.DataSource = dt;
            cboVehicleAddContract.DisplayMember = "display";
            cboVehicleAddContract.ValueMember = "id";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidateForm()) return;

                string selectedType = cboContractType.SelectedItem.ToString();

                if (cbContractParty.SelectedValue == null)
                {
                    MessageBox.Show("Vui lòng chọn khách hàng hoặc chủ xe.");
                    return;
                }
                int partyId = Convert.ToInt32(cbContractParty.SelectedValue);

                if (cboStaff.SelectedValue == null)
                {
                    MessageBox.Show("Vui lòng chọn nhân viên.");
                    return;
                }
                int staffId = Convert.ToInt32(cboStaff.SelectedValue);

                DateTime startDate = dtStart.Value;
                DateTime endDate = dtEnd.Value;

                if (!decimal.TryParse(txtPrice.Text, out decimal price))
                {
                    MessageBox.Show("Giá hợp đồng không hợp lệ.");
                    return;
                }

                string description = txtDescription.Text;
                int vehicleId = 0;
                int? refContractId = null;

                if (selectedType == "Lease")
                {
                    if (comboBoxRefContract.SelectedValue == null)
                    {
                        MessageBox.Show("Vui lòng chọn hợp đồng ký gửi.");
                        return;
                    }
                    refContractId = Convert.ToInt32(comboBoxRefContract.SelectedValue);

                    string query = "SELECT vehicleId FROM Contract WHERE id = @refId";
                    var cmd = new System.Data.SqlClient.SqlCommand(query);
                    cmd.Parameters.AddWithValue("@refId", refContractId);
                    object result = SqlHelper.ExecuteScalar(cmd);
                    if (result == null || result == DBNull.Value)
                    {
                        MessageBox.Show("Không tìm thấy hợp đồng ký gửi.");
                        return;
                    }
                    vehicleId = Convert.ToInt32(result);
                }
                else
                {
                    if (cboVehicleAddContract.SelectedValue == null)
                    {
                        MessageBox.Show("Vui lòng chọn xe.");
                        return;
                    }
                    vehicleId = Convert.ToInt32(cboVehicleAddContract.SelectedValue);
                }

                if (selectedType == "Consignment")
                {
                    string ownerQuery = @"
                SELECT O.FirstName + ' ' + O.LastName
                FROM Vehicle V
                JOIN Owner O ON V.OwnerId = O.OwnerId
                WHERE V.Id = @vehicleId";

                    var ownerCmd = new System.Data.SqlClient.SqlCommand(ownerQuery);
                    ownerCmd.Parameters.AddWithValue("@vehicleId", vehicleId);
                    string owner = SqlHelper.ExecuteScalar(ownerCmd)?.ToString();

                    string selectedOwnerQuery = "SELECT FirstName + ' ' + LastName FROM Owner WHERE OwnerId = @ownerId";
                    var selectedCmd = new System.Data.SqlClient.SqlCommand(selectedOwnerQuery);
                    selectedCmd.Parameters.AddWithValue("@ownerId", partyId);
                    string selectedOwner = SqlHelper.ExecuteScalar(selectedCmd)?.ToString();

                    if (owner != selectedOwner)
                    {
                        MessageBox.Show("Xe không thuộc sở hữu khách hàng được chọn!");
                        return;
                    }
                }

                var newContract = new Contract
                {
                    Type = selectedType,
                    VehicleId = vehicleId,
                    StaffId = staffId,
                    StartDate = startDate,
                    EndDate = endDate,
                    Price = price,
                    Description = description,
                    RefContractId = refContractId
                };

                if (selectedType == "Consignment")
                {
                    newContract.OwnerId = partyId;
                    newContract.CustomerId = 0;
                }
                else
                {
                    newContract.CustomerId = partyId;
                    newContract.OwnerId = null;
                }

                if (newContract.Insert())
                {
                    MessageBox.Show("Thêm hợp đồng thành công!");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Thêm hợp đồng thất bại!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private bool ValidateForm()
        {
            if (cboContractType.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn loại hợp đồng.");
                return false;
            }

            string selectedType = cboContractType.SelectedItem.ToString();

            if (cboVehicleAddContract.SelectedValue == null && selectedType != "Lease")
            {
                MessageBox.Show("Vui lòng chọn xe.");
                return false;
            }

            if (cbContractParty.SelectedValue == null)
            {
                if (selectedType == "Consignment")
                    MessageBox.Show("Vui lòng chọn chủ xe ký gửi.");
                else
                    MessageBox.Show("Vui lòng chọn khách thuê.");
                return false;
            }

            if (!decimal.TryParse(txtPrice.Text, out decimal price) || price <= 0)
            {
                MessageBox.Show("Giá hợp đồng phải lớn hơn 0.");
                return false;
            }

            if (dtStart.Value >= dtEnd.Value)
            {
                MessageBox.Show("Ngày bắt đầu phải trước ngày kết thúc.");
                return false;
            }

            if (selectedType == "Lease" && comboBoxRefContract.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn hợp đồng ký gửi.");
                return false;
            }

            return true;
        }

    }
}
