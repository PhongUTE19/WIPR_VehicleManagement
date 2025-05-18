using System;
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
            SetRefresh();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            string vehicleId = txtVehicleId.Text.Trim();
            string owner = txtOwner.Text.Trim();
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
                
            if (Helper.IsFieldEmpty(vehicleId) ||
                Helper.IsFieldEmpty(owner) ||
                Helper.IsFieldEmpty(type) ||
                Helper.IsFieldEmpty(brand) ||
                Helper.IsFieldEmpty(picture))
                return;

            if (vehicle.Insert(vehicleId, owner, type, brand, checkIn, subscription, picture))
                MessageBox.Show(Const.Message.Vehicle.ADD_SUCCESS, Const.Title.SUCCESS, MessageBoxButtons.OK);
            else
                MessageBox.Show(Const.Message.Vehicle.ADD_FAIL, Const.Title.FAIL, MessageBoxButtons.OK);

            Close();
        }

        private void btnUpdateImage_Click(object sender, EventArgs e)
        {
            pic.Image = Helper.getFileImage();
        }

        private void SetRefresh()
        {
            txtVehicleId.Text = "";
            txtOwner.Text = "";
            cboType.SelectedIndex = 0;
            txtBrand.Text = "";
            dtpCheckIn.Value = DateTime.Now;
            pic.Image = null;
        }
    }
}
