using System;
using System.Drawing;
using System.Windows.Forms;

namespace VehicleManagement
{
    public partial class EditStaffForm : Form
    {
        private Staff staff = new Staff();

        public EditStaffForm()
        {
            InitializeComponent();
        }

        private void AddVehicleForm_Load(object sender, EventArgs e)
        {
            FormHelper.CboSetup(cboGender, new string[] { "Male", "Female" });
            FormHelper.CboSetup(cboRole, new string[] { "Mechanic", "Washer", "ParkingAttendant" });
            //FormHelper.CboSetup(cboJob, command);
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

            if (staff.Update(id, firstName, lastName, birthdate, gender, phone, address, email, picture, role, job))
                MessageBox.Show(Const.Message.Staff.ADD_SUCCESS, Const.Title.SUCCESS, MessageBoxButtons.OK);
            else
                MessageBox.Show(Const.Message.Staff.ADD_FAIL, Const.Title.FAIL, MessageBoxButtons.OK);

            Close();
        }

        private void btnUpdateImage_Click(object sender, EventArgs e)
        {
            pic.Image = Helper.getFileImage();
        }

        public void SetData(EditStaffDTO dto)
        {
            txtStaffId.Text = dto.id;
            txtFirstName.Text = dto.firstName;
            txtLastName.Text = dto.lastName;
            dtpBirthdate.Value = dto.birthdate;
            cboGender.Text = dto.gender;
            txtPhone.Text = dto.phone;
            txtAddress.Text = dto.address;
            txtEmail.Text = dto.email;
            pic.Image = dto.picture;
            cboRole.Text = dto.role;
            cboJob.Text = dto.job;
        }
    }

    public class EditStaffDTO
    {
        public string id;
        public string firstName;
        public string lastName;
        public DateTime birthdate;
        public string gender;
        public string phone;
        public string address;
        public string email;
        public Image picture;
        public string role;
        public string job;

        public EditStaffDTO(string id, string firstName, string lastName, DateTime birthdate, string gender, string phone, string address, string email, Image picture, string role, string job)
        {
            this.id = id;
            this.firstName = firstName;
            this.lastName = lastName;
            this.birthdate = birthdate;
            this.gender = gender;
            this.phone = phone;
            this.address = address;
            this.email = email;
            this.picture = picture;
            this.role = role;
            this.job = job;
        }
    }
}
