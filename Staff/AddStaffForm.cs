using System;
using System.Drawing;
using System.Windows.Forms;

namespace VehicleManagement
{
    public partial class AddStaffForm : Form
    {
        private Staff staff = new Staff();

        public AddStaffForm()
        {
            InitializeComponent();
        }

        private void AddVehicleForm_Load(object sender, EventArgs e)
        {
            FormHelper.CboSetup(cboGender, new string[] { "Male", "Female" });
            FormHelper.CboSetup(cboRole, new string[] { "Mechanic", "Washer", "ParkingAttendant" });
            //FormHelper.CboSetup(cboJob, command);
            SetRefresh();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            string id = txtStaffId.Text.Trim();
            string firstName = txtFirstName.Text.Trim();
            string lastName = txtLastName.Text.Trim();
            DateTime birthdate = dtpBirthdate.Value;
            string gender = cboGender.SelectedValue.ToString();
            string phone = txtPhone.Text.Trim();
            string address = txtAddress.Text.Trim();
            string email = txtEmail.Text.Trim();
            Image picture = pic.Image;
            string role = cboRole.SelectedValue.ToString();
            string job = cboJob.SelectedValue.ToString();
            if (Helper.IsFieldEmpty(id) ||
                Helper.IsFieldEmpty(firstName) ||
                Helper.IsFieldEmpty(lastName) ||
                Helper.IsFieldEmpty(gender) ||
                Helper.IsFieldEmpty(phone) ||
                Helper.IsFieldEmpty(address) ||
                Helper.IsFieldEmpty(email) ||
                Helper.IsFieldEmpty(picture) ||
                Helper.IsFieldEmpty(role) ||
                Helper.IsFieldEmpty(job))
                return;

            if (staff.Insert(id, firstName, lastName, birthdate, gender, phone, address, email, picture, role, job))
                MessageBox.Show(Const.Message.Staff.ADD_SUCCESS, Const.Title.SUCCESS, MessageBoxButtons.OK);
            else
                MessageBox.Show(Const.Message.Staff.ADD_FAIL, Const.Title.FAIL, MessageBoxButtons.OK);

            Close();
        }

        private void btnUpdateImage_Click(object sender, EventArgs e)
        {
            pic.Image = Helper.getFileImage();
        }

        private void SetRefresh()
        {
            txtStaffId.Text = "";
            txtFirstName.Text = "";
            txtLastName.Text = "";
            dtpBirthdate.Value = DateTime.Now;
            cboGender.SelectedIndex = 0;
            txtPhone.Text = "";
            txtAddress.Text = "";
            txtEmail.Text = "";
            pic.Image = null;
            cboRole.SelectedIndex = 0;
            cboJob.SelectedIndex = 0;
        }
    }
}
