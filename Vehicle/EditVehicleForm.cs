using System;
using System.Drawing;
using System.Windows.Forms;

namespace VehicleManagement
{
    public partial class EditVehicleForm : Form
    {
        private Vehicle vehicle = new Vehicle();

        public EditVehicleForm()
        {
            InitializeComponent();
        }

        private void AddVehicleForm_Load(object sender, EventArgs e)
        {
            FormHelper.CboSetup(cboType, new string[] { "Bike", "Motorbike", "Car" });
            FormHelper.CboSetup(cboSubscription, new string[] { "Hour", "Day", "Week", "Month" });
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            string id = txtVehicleId.Text.Trim();
            string owner = txtOwner.Text.Trim();
            string type = cboType.SelectedValue.ToString();
            string brand = txtBrand.Text.Trim();
            DateTime checkIn = dtpCheckIn.Value;
            string subscription = cboSubscription.SelectedValue.ToString();
            Image picture = pic.Image;
            if (Helper.IsFieldEmpty(id) ||
                Helper.IsFieldEmpty(owner) ||
                Helper.IsFieldEmpty(type) ||
                Helper.IsFieldEmpty(brand) ||
                Helper.IsFieldEmpty(picture))
                return;

            if (vehicle.Update(id, owner, type, brand, checkIn, subscription, picture))
                MessageBox.Show(Const.Message.Vehicle.EDIT_SUCCESS, Const.Title.SUCCESS, MessageBoxButtons.OK);
            else
                MessageBox.Show(Const.Message.Vehicle.EDIT_FAIL, Const.Title.FAIL, MessageBoxButtons.OK);

            Close();
        }

        private void btnUpdateImage_Click(object sender, EventArgs e)
        {
            pic.Image = Helper.getFileImage();
        }

        public void SetData(EditVehicleDTO dto)
        {
            txtVehicleId.Text = dto.id;
            txtOwner.Text = dto.owner;
            cboType.SelectedIndex = cboType.FindStringExact(dto.type);
            txtBrand.Text = dto.brand;
            dtpCheckIn.Value = dto.checkIn;
            cboSubscription.SelectedIndex = cboSubscription.FindStringExact(dto.subscription);
            pic.Image = dto.picture;
        }
    }

    public class EditVehicleDTO
    {
        public string id;
        public string owner;
        public string type;
        public string brand;
        public DateTime checkIn;
        public string subscription;
        public Image picture;

        public EditVehicleDTO(string id, string owner, string type, string brand, DateTime checkIn, string subscription, Image picture)
        {
            this.id = id;
            this.owner = owner;
            this.type = type;
            this.brand = brand;
            this.checkIn = checkIn;
            this.subscription = subscription;
            this.picture = picture;
        }
    }
}
