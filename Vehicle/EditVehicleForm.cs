using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace VehicleManagement
{
    public partial class EditVehicleForm : Form
    {
        private Vehicle vehicle = new Vehicle();

        public EditVehicleForm()
        {
            InitializeComponent();
        }

        private void EditVehicleForm_Load(object sender, EventArgs e)
        {
            FormHelper.CboSetup(cboType, new string[] { "Bike", "Motorbike", "Car" });
            FormHelper.CboSetup(cboSubscription, new string[] { "Hour", "Day", "Week", "Month" });

            LoadOwners();
        }
        private void LoadOwners()
        {
            // Lấy danh sách user từ database (ví dụ):
            SqlCommand command = new SqlCommand("SELECT id, firstName + ' ' + lastName AS FullName FROM [User]");
            DataTable dtUsers = SqlHelper.GetTable(command);

            cboOwner.DisplayMember = "FullName";
            cboOwner.ValueMember = "id";
            cboOwner.DataSource = dtUsers;
        }
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            // Chuyển đổi VehicleId từ string sang int
            if (!int.TryParse(txtVehicleId.Text.Trim(), out int id))
            {
                MessageBox.Show("ID xe không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int ownerId = (int)cboOwner.SelectedValue;
            string type = cboType.SelectedValue.ToString();
            string brand = txtBrand.Text.Trim();
            DateTime checkIn = dtpCheckIn.Value;
            string subscription = cboSubscription.SelectedValue.ToString();
            Image picture = pic.Image;

            // Kiểm tra dữ liệu đầu vào
            if (ownerId == 0 ||
                Helper.IsFieldEmpty(type) ||
                Helper.IsFieldEmpty(brand) ||
                Helper.IsFieldEmpty(picture))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thiếu dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Gọi hàm cập nhật
            if (vehicle.Update(id, ownerId, type, brand, checkIn, subscription, picture))
            {
                MessageBox.Show(Const.Message.Vehicle.EDIT_SUCCESS, Const.Title.SUCCESS, MessageBoxButtons.OK);
            }
            else
            {
                MessageBox.Show(Const.Message.Vehicle.EDIT_FAIL, Const.Title.FAIL, MessageBoxButtons.OK);
            }

            Close();
        }

        private void btnUpdateImage_Click(object sender, EventArgs e)
        {
            pic.Image = Helper.getFileImage();
        }

        public void SetData(EditVehicleDTO dto)
        {
            txtVehicleId.Text = dto.id;
            cboOwner.SelectedValue = dto.ownerId;
            cboType.SelectedIndex = cboType.FindStringExact(dto.type);
            txtBrand.Text = dto.brand;
            dtpCheckIn.Value = dto.checkIn;
            cboSubscription.SelectedIndex = cboSubscription.FindStringExact(dto.subscription);
            pic.Image = dto.picture;
        }
    }

    public class EditVehicleDTO
    {
        public string id;
        public int ownerId;  // Thêm
        public string ownerName; // Tùy chọn, nếu muốn hiện tên
        public string type;
        public string brand;
        public DateTime checkIn;
        public string subscription;
        public Image picture;

        public EditVehicleDTO(string id, int ownerId, string ownerName, string type, string brand, DateTime checkIn, string subscription, Image picture)
        {
            this.id = id;
            this.ownerId = ownerId;
            this.ownerName = ownerName;
            this.type = type;
            this.brand = brand;
            this.checkIn = checkIn;
            this.subscription = subscription;
            this.picture = picture;
        }
    }

}
