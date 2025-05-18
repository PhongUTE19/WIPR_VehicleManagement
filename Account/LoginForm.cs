using System;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;

namespace VehicleManagement
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            picLogo.Image = Image.FromFile("../../Resources/images.png");
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();
            if (Helper.IsFieldEmpty(username) ||
                Helper.IsFieldEmpty(password))
                return;

            SqlCommand command = new SqlCommand(@"
                SELECT * FROM [Login]
                WHERE username = @username AND password = @password");

            command.Parameters.Add("@username", SqlDbType.VarChar).Value = username;
            command.Parameters.Add("@password", SqlDbType.VarChar).Value = password;
            DataTable table = SqlHelper.GetTable(command);
            if (table.Rows.Count > 0)
            {
                Form form = new MainForm();
                Global.SetGlobalUserId(int.Parse(table.Rows[0][0].ToString()), username, table.Rows[0]["firstname"].ToString(), table.Rows[0]["lastname"].ToString());
                form.Show();
            }
            else
                MessageBox.Show(Const.Message.Account.LOGIN_FAIL, Const.Title.FAIL, MessageBoxButtons.OK);
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            RegisterForm form = new RegisterForm();
            form.Show();
        }

        private void btnForgetPassword_Click(object sender, EventArgs e)
        {
            ForgetPasswordForm form = new ForgetPasswordForm();
            form.Show();
        }

        private void chkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = !chkShowPassword.Checked;
        }
    }
}
