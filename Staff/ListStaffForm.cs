using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace VehicleManagement
{
    public partial class ListStaffForm : Form
    {
        private Staff staff = new Staff(); // Dùng Staff thay vì Vehicle

        public ListStaffForm()
        {
            InitializeComponent();
        }

        private void ListStaffForm_Load(object sender, EventArgs e)
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

            int id = Convert.ToInt32(row.Cells["id"].Value); // chuyển sang int
            string firstName = row.Cells["firstName"].Value.ToString();
            string lastName = row.Cells["lastName"].Value.ToString();
            DateTime birthdate = (DateTime)row.Cells["birthdate"].Value;
            string gender = row.Cells["gender"].Value.ToString();
            string phone = row.Cells["phone"].Value.ToString();
            string address = row.Cells["address"].Value.ToString();
            string email = row.Cells["email"].Value.ToString();
            string role = row.Cells["role"].Value.ToString();
            string job = row.Cells["job"].Value.ToString();

            Image picture = null;
            if (row.Cells["picture"].Value != DBNull.Value)
                picture = Helper.byteArrayToImage((byte[])row.Cells["picture"].Value);

            // Truyền id dạng string nếu DTO hiện tại yêu cầu
            EditStaffDTO dto = new EditStaffDTO(id.ToString(), firstName, lastName, birthdate, gender, phone, address, email, picture, role, job);
            EditStaffForm form = new EditStaffForm();
            form.SetData(dto);
            form.ShowDialog();
            SetRefresh();
        }

        private void tsmiDelete_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = dgv.CurrentRow;
            if (row == null || row.Index == -1)
                return;

            int staffId = Convert.ToInt32(row.Cells["id"].Value);
            if (staff.Delete(staffId)) // dùng Staff.Delete(int id)
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

            string query = @"
                SELECT 
                    C.id, 
                    C.type, 
                    CASE 
                        WHEN C.type = 'Consignment' THEN O.FirstName + ' ' + O.LastName
                        ELSE Cst.FirstName + ' ' + Cst.LastName
                    END AS customer, 
                    V.brand + ' ' + V.type AS vehicle, 
                    S.firstName + ' ' + S.lastName AS staff, 
                    C.startDate, 
                    C.endDate, 
                    C.price, 
                    C.description
                FROM Contract C
                LEFT JOIN Owner O ON C.customerId = O.OwnerId
                LEFT JOIN Customer Cst ON C.customerId = Cst.Id
                JOIN Vehicle V ON C.vehicleId = V.id
                JOIN Staff S ON C.staffId = S.id";

            SqlCommand command = new SqlCommand(query);
            command.Parameters.AddWithValue("@search", "%" + search + "%");

            FormHelper.DgvSetup(dgv, command);
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        private void SetRefresh()
        {
            string query = @"
                SELECT s.Id, s.FirstName, s.LastName, s.BirthDate, s.Gender, s.Phone,
                       s.Address, s.Email, s.Role, s.Picture,
                       j.Name AS job
                FROM Staff s
                LEFT JOIN Job j ON s.JobId = j.Id";

            SqlCommand command = new SqlCommand(query);
            FormHelper.DgvSetup(dgv, command);
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            txtSearch.Text = "";
        }

    }
}
