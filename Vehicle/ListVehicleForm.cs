using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace VehicleManagement
{
    public partial class ListVehicleForm : Form
    {
        private readonly double bikeFee = 500;
        private readonly double motorbikeFee = 1000;
        private readonly double carFee = 1500;

        private readonly int bikeZone = 50;
        private readonly int motorbikeZone = 150;
        private readonly int carZone = 20;

        private Vehicle vehicle = new Vehicle();

        public ListVehicleForm()
        {
            InitializeComponent();
        }

        private void ListVehicleForm_Load(object sender, EventArgs e)
        {
            SetRefresh();
        }

        private void tsmiAdd_Click(object sender, EventArgs e)
        {
            AddVehicleForm form = new AddVehicleForm();
            form.ShowDialog();
            SetRefresh();
        }

        private void tsmiUpdate_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = dgv.CurrentRow;
            if (row == null || row.Index == -1)
                return;

            EditVehicleForm form = new EditVehicleForm();
            string id = row.Cells["id"].Value.ToString();

            int ownerId = 0;
            if (row.Cells["ownerId"].Value != DBNull.Value)
                ownerId = Convert.ToInt32(row.Cells["ownerId"].Value);

            string ownerName = row.Cells["OwnerName"].Value.ToString();
            string type = row.Cells["type"].Value.ToString();
            string brand = row.Cells["brand"].Value.ToString();
            DateTime checkIn = (DateTime)row.Cells["checkIn"].Value;
            string subscription = row.Cells["subscription"].Value.ToString();

            Image picture;
            if (row.Cells["picture"].Value != DBNull.Value)
                picture = Helper.byteArrayToImage((byte[])row.Cells["picture"].Value);
            else
                picture = null;

            // Gọi constructor đúng với 8 tham số
            EditVehicleDTO dto = new EditVehicleDTO(id, ownerId, ownerName, type, brand, checkIn, subscription, picture);
            form.SetData(dto);
            form.ShowDialog();
            SetRefresh();
        }

        private void tsmiDelete_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = dgv.CurrentRow;
            if (row == null || row.Index == -1)
                return;

            string vehicleIdStr = row.Cells["id"].Value.ToString();
            if (Helper.IsFieldEmpty(vehicleIdStr))
                return;

            int vehicleId = int.Parse(vehicleIdStr); // hoặc int.TryParse để an toàn

            if (vehicle.Delete(vehicleId))
                MessageBox.Show(Const.Message.Vehicle.DELETE_SUCCESS, Const.Title.SUCCESS, MessageBoxButtons.OK);
            else
                MessageBox.Show(Const.Message.Vehicle.DELETE_FAIL, Const.Title.FAIL, MessageBoxButtons.OK);

            SetRefresh();
        }

        private void tsmiRefresh_Click(object sender, EventArgs e)
        {
            SetRefresh();
        }

        private void tsmiPrint_Click(object sender, EventArgs e)
        {
            MsHelper.PrintWord(dgv, "Vehicle");
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SetRefresh();
        }

        private void SetRefresh()
        {
            string search = txtSearch.Text.Trim();

            SqlCommand command = new SqlCommand(@"
                SELECT v.*, u.firstName, u.lastName
                FROM Vehicle v
                LEFT JOIN [Owner] u ON v.ownerId = u.OwnerId
                WHERE 
                    CAST(v.id AS NVARCHAR) LIKE @search OR
                    u.firstName LIKE @search OR
                    u.lastName LIKE @search OR
                    v.type LIKE @search OR
                    v.brand LIKE @search OR
                    v.subscription LIKE @search");

            // Nếu search trống thì truyền '%' để lấy toàn bộ
            if (string.IsNullOrEmpty(search))
                command.Parameters.AddWithValue("@search", "%");
            else
                command.Parameters.AddWithValue("@search", "%" + search + "%");

            SetList(command);
        }


        private void SetList(SqlCommand command)
        {
            int day = 24;
            int week = day * 7;
            int month = week * 4;

            DataTable table = SqlHelper.GetTable(command);
            NewCol(table, "HourDiff");
            NewCol(table, "Status");
            NewCol(table, "TotalFee");
            // Tạo cột OwnerName để hiển thị họ tên chủ xe
            if (!table.Columns.Contains("OwnerName"))
                table.Columns.Add("OwnerName", typeof(string));

            foreach (DataRow row in table.Rows)
            {
                string type = row["type"].ToString();
                double fee =
                    type == "Bike" ? bikeFee :
                    type == "Motorbike" ? motorbikeFee :
                    type == "Car" ? carFee : 0;

                DateTime checkInTime = Convert.ToDateTime(row["checkIn"]);
                int hourDiff = (int)(DateTime.Now - checkInTime).TotalHours;
                double hourFee = hourDiff * fee;
                double dayFee = fee * 8;
                double weekFee = dayFee * 3;
                double monthFee = weekFee * 2;

                string subscription = row["subscription"].ToString();
                bool isOverdue = false;
                double totalFee = 0;
                if (subscription == "Hour")
                {
                    isOverdue = hourDiff >= 24;
                    totalFee = isOverdue ? dayFee * 2 : hourFee;
                }
                else if (subscription == "Day")
                {
                    isOverdue = hourDiff >= day;
                    totalFee = isOverdue ? weekFee : dayFee;
                }
                else if (subscription == "Week")
                {
                    isOverdue = hourDiff >= day * 10 && day < day * 30;
                    totalFee = isOverdue ? monthFee : weekFee;
                }

                string status = isOverdue ? "Overdue" : "Normal";

                row["HourDiff"] = hourDiff.ToString();
                row["Status"] = status;
                row["TotalFee"] = totalFee.ToString();
                row["OwnerName"] = $"{row["firstName"]} {row["lastName"]}";
            }
            FormHelper.DgvSetup(dgv, table);
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            int countBike = table.Select("type = 'Bike'").Length;
            int countMotorbike = table.Select("type = 'Motorbike'").Length;
            int countCar = table.Select("type = 'Car'").Length;
            lblTotal.Text = $@"
                Total: {dgv.Rows.Count}
                Bike: {countBike}/{bikeZone}
                Motorbike: {countMotorbike}/{motorbikeZone}
                Car: {countCar}/{carZone}";
        }

        private void NewCol(DataTable table, string columnName)
        {
            if (!table.Columns.Contains(columnName))
                table.Columns.Add(columnName);
        }
    }
}
