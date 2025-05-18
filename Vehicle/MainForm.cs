using System;
using System.Windows.Forms;

namespace VehicleManagement
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void tsmiVehicle_Click(object sender, EventArgs e)
        {
            ListVehicleForm form = new ListVehicleForm();
            form.Show();
        }

        private void tsmiStaff_Click(object sender, EventArgs e)
        {
            //StaffVehicleForm form = new StaffVehicleForm();
            //form.Show();
        }
    }
}
