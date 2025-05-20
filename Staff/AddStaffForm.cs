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
            cboRole.SelectedIndexChanged += cboRole_SelectedIndexChanged;
        }

        private void AddStaffForm_Load(object sender, EventArgs e)
        {
            FormHelper.CboSetup(cboGender, new string[] { "Male", "Female", "Other" });
            FormHelper.CboSetup(cboRole, new string[] { "Mechanic", "Washer", "ParkingAttendant" });

            // Load danh sách Job từ DB vào cboJob
            var jobs = JobHelper.GetJobs(); // giả sử trả về DataTable

            cboJob.DataSource = null;
            cboJob.DisplayMember = "Name";
            cboJob.ValueMember = "Id";

            if (jobs != null && jobs.Rows.Count > 0)
            {
                cboJob.DataSource = jobs;          // ✅ Gán DataSource trước
                cboJob.SelectedIndex = 0;          // ✅ Sau đó mới chọn dòng đầu tiên
            }
            else
            {
                MessageBox.Show("No jobs found. Please add jobs first.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            SetRefresh();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            // Bỏ lấy id
            string firstName = txtFirstName.Text.Trim();
            string lastName = txtLastName.Text.Trim();
            DateTime birthdate = dtpBirthdate.Value;
            string gender = cboGender.SelectedValue.ToString();
            string phone = txtPhone.Text.Trim();
            string address = txtAddress.Text.Trim();
            string email = txtEmail.Text.Trim();
            Image picture = pic.Image;
            string role = cboRole.SelectedValue.ToString();

            // jobId lấy từ SelectedValue của cboJob
            int jobId = (int)cboJob.SelectedValue;

            if (Helper.IsFieldEmpty(firstName) ||
                Helper.IsFieldEmpty(lastName) ||
                Helper.IsFieldEmpty(gender) ||
                Helper.IsFieldEmpty(phone) ||
                Helper.IsFieldEmpty(address) ||
                Helper.IsFieldEmpty(email) ||
                picture == null ||  // Kiểm tra hình ảnh khác chút, không dùng IsFieldEmpty
                Helper.IsFieldEmpty(role))
                return;

            if (staff.Insert(firstName, lastName, birthdate, gender, phone, address, email, picture, role, jobId))
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
        private void cboRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboRole.SelectedItem != null)
            {
                string selectedRole = cboRole.SelectedItem.ToString();
                var jobs = JobHelper.GetJobsByRole(selectedRole);
                cboJob.DataSource = jobs;
                cboJob.DisplayMember = "Name";
                cboJob.ValueMember = "Id";

                if (jobs.Rows.Count > 0)
                    cboJob.SelectedIndex = 0;
                else
                    cboJob.Text = "";  // Clear nếu không có job phù hợp
            }
        }

    }
}
