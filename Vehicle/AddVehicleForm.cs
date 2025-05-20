using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace VehicleManagement
{
    public partial class AddVehicleForm : Form
    {
        private readonly int bikeZone = 50;
        private readonly int motorbikeZone = 150;
        private readonly int carZone = 20;

        private Vehicle vehicle = new Vehicle();

        public AddVehicleForm()
        {
            InitializeComponent();
        }

        private void AddVehicleForm_Load(object sender, EventArgs e)
        {
            FormHelper.CboSetup(cboType, new string[] { "Bike", "Motorbike", "Car" });
            FormHelper.CboSetup(cboSubscription, new string[] { "Hour", "Day", "Week", "Month" });

            LoadOwners();

            SetRefresh();
        }
        private void LoadOwners()
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SELECT OwnerId, CONCAT(FirstName, ' ', LastName) AS fullName FROM Owner");
                DataTable dt = SqlHelper.GetTable(cmd);
                cboOwner.DataSource = dt;
                cboOwner.DisplayMember = "fullName";
                cboOwner.ValueMember = "OwnerId";
                if (dt.Rows.Count > 0)
                    cboOwner.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load owners: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            int ownerId = (int)cboOwner.SelectedValue;  // Lấy ownerId kiểu int
            string type = cboType.SelectedValue.ToString();
            string brand = txtBrand.Text.Trim();
            DateTime checkIn = dtpCheckIn.Value;
            string subscription = cboSubscription.SelectedValue.ToString();
            Image picture = pic.Image;

            SqlCommand command = new SqlCommand(@"
        SELECT COUNT(*) FROM [Vehicle]
        WHERE type = @type");
            command.Parameters.AddWithValue("@type", type);
            int count = SqlHelper.GetCount(command);
            int zone =
                type == "Bike" ? bikeZone :
                type == "Motorbike" ? motorbikeZone :
                type == "Car" ? carZone : 0;

            if (count >= zone)
            {
                MessageBox.Show($"{type} zone is full.", Const.Title.FAIL, MessageBoxButtons.OK);
                return;
            }

            if (ownerId == 0 ||   // Kiểm tra ownerId hợp lệ
                Helper.IsFieldEmpty(type) ||
                Helper.IsFieldEmpty(brand) ||
                Helper.IsFieldEmpty(picture))
                return;

            int? newVehicleId = vehicle.Insert(ownerId, type, brand, checkIn, subscription, picture);
            if (newVehicleId != null)
            {
                MessageBox.Show($"Thêm thành công. Vehicle ID: {newVehicleId}", Const.Title.SUCCESS, MessageBoxButtons.OK);
            }
            else
            {
                MessageBox.Show(Const.Message.Vehicle.ADD_FAIL, Const.Title.FAIL, MessageBoxButtons.OK);
            }
            Close();
        }

        private void btnUpdateImage_Click(object sender, EventArgs e)
        {
            pic.Image = Helper.getFileImage();
        }

        private void SetRefresh()
        {
            // Nếu bạn vẫn giữ txtOwner thì có thể ẩn hoặc xóa dòng sau
            // txtOwner.Text = "";
            cboType.SelectedIndex = 0;
            txtBrand.Text = "";
            dtpCheckIn.Value = DateTime.Now;
            pic.Image = null;
            if (cboOwner.Items.Count > 0)
                cboOwner.SelectedIndex = 0;
        }
    }
}
