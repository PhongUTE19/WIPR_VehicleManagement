using System;
using System.Windows.Forms;

namespace VehicleManagement
{
    public partial class AddJobForm : Form
    {
        private Job job = new Job();

        public AddJobForm()
        {
            InitializeComponent();
        }

        private void AddJobForm_Load(object sender, EventArgs e)
        {
            SetRefresh();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            string id = txtJobId.Text.Trim();
            string name = txtName.Text.Trim();
            string description = txtDescription.Text.Trim();
            if (Helper.IsFieldEmpty(id) ||
                Helper.IsFieldEmpty(name) ||
                Helper.IsFieldEmpty(description))
                return;

            if (job.Insert(id, name, description))
                MessageBox.Show(Const.Message.Job.ADD_SUCCESS, Const.Title.SUCCESS, MessageBoxButtons.OK);
            else
                MessageBox.Show(Const.Message.Job.ADD_FAIL, Const.Title.FAIL, MessageBoxButtons.OK);

            Close();
        }

        private void SetRefresh()
        {
            txtJobId.Text = "";
            txtName.Text = "";
            txtDescription.Text = "";
        }
    }
}
