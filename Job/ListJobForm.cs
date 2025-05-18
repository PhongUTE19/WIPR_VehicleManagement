using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace VehicleManagement
{
    public partial class ListJobForm : Form
    {
        private Job job = new Job();

        public ListJobForm()
        {
            InitializeComponent();
        }

        private void ListJobForm_Load(object sender, EventArgs e)
        {
            SetRefresh();
        }

        private void tsmiAdd_Click(object sender, EventArgs e)
        {
            AddJobForm form = new AddJobForm();
            form.ShowDialog();
            SetRefresh();
        }

        private void tsmiUpdate_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = dgv.CurrentRow;
            if (row == null || row.Index == -1)
                return;

            EditJobForm form = new EditJobForm();
            string id = row.Cells["id"].Value.ToString();
            string name = row.Cells["name"].Value.ToString();
            string description = row.Cells["description"].Value.ToString();
            EditJobDTO dto = new EditJobDTO(id, name, description);
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

            if (job.Delete(vehicleId))
                MessageBox.Show(Const.Message.Job.DELETE_SUCCESS, Const.Title.SUCCESS, MessageBoxButtons.OK);
            else
                MessageBox.Show(Const.Message.Job.DELETE_FAIL, Const.Title.FAIL, MessageBoxButtons.OK);

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
                SELECT * FROM [Job]");
            FormHelper.DgvSetup(dgv, command);
            txtSearch.Text = "";
        }
    }
}
