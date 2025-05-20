using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace VehicleManagement.Contract
{
    public partial class ListContractForm : Form
    {
        public ListContractForm()
        {
            InitializeComponent();
        }

        private void ListContractForm_Load(object sender, EventArgs e)
        {
            LoadContracts();
        }

        private void LoadContracts()
        {
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

            var command = new SqlCommand(query);
            dataGridViewContract.DataSource = SqlHelper.GetTable(command);
            dataGridViewContract.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddContractForm form = new AddContractForm();
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadContracts();
            }
        }

        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridViewContract.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(dataGridViewContract.SelectedRows[0].Cells["id"].Value);

                UpdateContractForm form = new UpdateContractForm(id); // Giả sử bạn có form cập nhật
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadContracts();
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một hợp đồng để cập nhật.");
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridViewContract.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(dataGridViewContract.SelectedRows[0].Cells["id"].Value);
                DialogResult dr = MessageBox.Show("Bạn có chắc muốn xoá hợp đồng này?", "Xác nhận", MessageBoxButtons.YesNo);

                if (dr == DialogResult.Yes)
                {
                    string query = "DELETE FROM Contract WHERE id = @id";
                    var parameters = new Dictionary<string, object>()
                    {
                        { "@id", id }
                    };

                    bool result = SqlHelper.Execute(query, parameters);
                    if (result)
                    {
                        MessageBox.Show("Xoá thành công!");
                        LoadContracts();
                    }
                    else
                    {
                        MessageBox.Show("Xoá thất bại!");
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một hợp đồng để xoá.");
            }
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadContracts();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text.Trim();
            if (string.IsNullOrEmpty(keyword))
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
                JOIN Staff S ON C.staffId = S.id
                WHERE 
                    CAST(C.id AS NVARCHAR) LIKE @search OR
                    C.type LIKE @search OR
                    (O.FirstName + ' ' + O.LastName) LIKE @search OR
                    (Cst.FirstName + ' ' + Cst.LastName) LIKE @search OR
                    (V.brand + ' ' + V.type) LIKE @search OR
                    (S.FirstName + ' ' + S.LastName) LIKE @search OR
                    C.description LIKE @search";

            var command = new SqlCommand(query);
            command.Parameters.AddWithValue("@search", "%" + keyword + "%");

            dataGridViewContract.DataSource = SqlHelper.GetTable(command);
            dataGridViewContract.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

    }
}
