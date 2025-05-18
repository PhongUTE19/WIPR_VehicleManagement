using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace VehicleManagement
{
    public class FormHelper
    {
        public static void DgvSetup(DataGridView dgv, SqlCommand command)
        {
            dgv.ReadOnly = true;
            dgv.AllowUserToAddRows = false;
            dgv.DataSource = SqlHelper.GetTable(command);
        }

        public static void DgvSetup(DataGridView dgv, DataTable table)
        {
            dgv.ReadOnly = true;
            dgv.AllowUserToAddRows = false;
            dgv.DataSource = table;
        }

        public static void LstSetup(ListBox lst, SqlCommand command, string displayValue, string displayMember)
        {
            lst.DataSource = SqlHelper.GetTable(command);
            lst.ValueMember = displayValue;
            lst.DisplayMember = displayMember;
            lst.SelectedItem = null;
        }

        public static void LstSetup(ListBox lst, DataTable table, string displayValue, string displayMember)
        {
            lst.DataSource = table;
            lst.ValueMember = displayValue;
            lst.DisplayMember = displayMember;
            lst.SelectedItem = null;
        }

        public static void CboSetup(ComboBox cbo, SqlCommand command, string displayValue, string displayMember)
        {
            cbo.DataSource = SqlHelper.GetTable(command);
            cbo.ValueMember = displayValue;
            cbo.DisplayMember = displayMember;
        }

        public static void CboSetup(ComboBox cbo, DataTable table, string displayValue, string displayMember)
        {
            cbo.DataSource = table;
            cbo.ValueMember = displayValue;
            cbo.DisplayMember = displayMember;
        }

        public static void CboSetup(ComboBox cbo, string[] list)
        {
            cbo.DataSource = null;
            cbo.DataSource = list;
        }
    }
}
