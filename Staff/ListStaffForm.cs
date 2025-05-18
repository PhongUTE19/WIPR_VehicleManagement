using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace VehicleManagement
{
    public partial class ListStaffForm : Form
    {
        private Vehicle vehicle = new Vehicle();

        public ListStaffForm()
        {
            InitializeComponent();
        }

        private void ManageVehicleForm_Load(object sender, EventArgs e)
        {
            SetRefresh();
        }

        private void tsmiAdd_Click(object sender, EventArgs e)
        {
            AddStaffForm form = new AddStaffForm();
            form.ShowDialog();
            SetRefresh();
        }

        private void tsmiUpdate_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = dgv.CurrentRow;
            if (row == null || row.Index == -1)
                return;

            EditStaffForm form = new EditStaffForm();
            string id = row.Cells["id"].Value.ToString();
            string firstName = row.Cells["firstName"].Value.ToString();
            string lastName = row.Cells["lastName"].Value.ToString();
            DateTime birthdate = (DateTime)row.Cells["birthdate"].Value;
            string gender = row.Cells["gender"].Value.ToString();
            string phone = row.Cells["phone"].Value.ToString();
            string address = row.Cells["address"].Value.ToString();
            string email = row.Cells["email"].Value.ToString();
            string role = row.Cells["role"].Value.ToString();
            string job = row.Cells["job"].Value.ToString();
            Image picture;
            if (row.Cells["picture"].Value != DBNull.Value)
                picture = Helper.byteArrayToImage((byte[])row.Cells["picture"].Value);
            else
                picture = null;
            EditStaffDTO dto = new EditStaffDTO(id, firstName, lastName, birthdate, gender, phone, address, email, picture, role, job);
            form.SetData(dto);
            form.ShowDialog();
            SetRefresh();
        }

        private void tsmiDelete_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = dgv.CurrentRow;
            if (row == null || row.Index == -1)
                return;

            string vehicleId = row.Cells["id"].Value.ToString();
            if (Helper.IsFieldEmpty(vehicleId))
                return;

            if (vehicle.Delete(vehicleId))
                MessageBox.Show(Const.Message.Staff.DELETE_SUCCESS, Const.Title.SUCCESS, MessageBoxButtons.OK);
            else
                MessageBox.Show(Const.Message.Staff.DELETE_FAIL, Const.Title.FAIL, MessageBoxButtons.OK);

            SetRefresh();
        }

        private void tsmiRefresh_Click(object sender, EventArgs e)
        {
            SetRefresh();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string search = txtSearch.Text.Trim();
            if (Helper.IsFieldEmpty(search))
                return;
        }

        private void SetRefresh()
        {
            SqlCommand command = new SqlCommand(@"
                SELECT * FROM [Staff]");
            FormHelper.DgvSetup(dgv, command);
            txtSearch.Text = "";
        }
    }
}
