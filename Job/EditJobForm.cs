using System;
using System.Windows.Forms;

namespace VehicleManagement
{
    public partial class EditJobForm : Form
    {
        private Job job = new Job();

        public EditJobForm()
        {
            InitializeComponent();
        }

        private void EditJobForm_Load(object sender, EventArgs e)
        {
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
                MessageBox.Show(Const.Message.Job.EDIT_SUCCESS, Const.Title.SUCCESS, MessageBoxButtons.OK);
            else
                MessageBox.Show(Const.Message.Job.EDIT_FAIL, Const.Title.FAIL, MessageBoxButtons.OK);

            Close();
        }

        public void SetData(EditJobDTO dto)
        {
            txtJobId.Text = dto.id;
            txtName.Text = dto.name;
            txtDescription.Text = dto.description;
        }
    }

    public class EditJobDTO
    {
        public string id;
        public string name;
        public string description;

        public EditJobDTO(string id, string name, string description)
        {
            this.id = id;
            this.name = name;
            this.description = description;
        }
    }
}
