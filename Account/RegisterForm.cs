using System;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VehicleManagement
{
    public partial class RegisterForm : Form
    {
        private Account account = new Account();
        private string randCode;

        public RegisterForm()
        {
            InitializeComponent();
        }

        private void RegisterForm_Load(object sender, EventArgs e)
        {
            txtEmail.Text = Const.TO_EMAIL;
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();
            string rePassword = txtRePassword.Text.Trim();
            string email = txtEmail.Text.Trim();
            string code = txtCode.Text.Trim();
            if (Helper.IsFieldEmpty(username) ||
                Helper.IsFieldEmpty(password) ||
                Helper.IsFieldEmpty(rePassword) ||
                Helper.IsFieldEmpty(email) ||
                Helper.IsFieldEmpty(code))
                return;

            if (CheckUsernameExist(username))
            {
                MessageBox.Show(Const.Message.Account.USERNAME_EXIST, Const.Title.FAIL, MessageBoxButtons.OK);
                return;
            }

            if (password != rePassword)
            {
                MessageBox.Show(Const.Message.Account.REPASSWORD_NOT_MATCH, Const.Title.FAIL, MessageBoxButtons.OK);
                txtRePassword.Text = "";
                return;
            }

            if (randCode != code)
            {
                MessageBox.Show(Const.Message.Account.CODE_NOT_MATCH, Const.Title.FAIL, MessageBoxButtons.OK);
                txtCode.Text = "";
                return;
            }

            if (account.Insert(SqlHelper.GetLatestId("Login"), username, password))
            {
                txtUsername.Text = "";
                txtPassword.Text = "";
                txtRePassword.Text = "";
                txtEmail.Text = "";
                txtCode.Text = "";
                MessageBox.Show(Const.Message.Account.REGISTER_SUCCESS, Const.Title.SUCCESS, MessageBoxButtons.OK);
            }
            else
                MessageBox.Show(Const.Message.Account.REGISTER_FAIL, Const.Title.FAIL, MessageBoxButtons.OK);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private async void btnSendCode_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();
            if (Helper.IsFieldEmpty(email))
                return;

            randCode = new Random().Next(999999).ToString();
            MailMessage message = new MailMessage(Const.FROM_EMAIL, email, "Verify Account Code", $"Code: {randCode}");
            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            smtp.EnableSsl = true;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.Credentials = new NetworkCredential(Const.FROM_EMAIL, Const.FROM_PASSWORD);
            prg.Visible = true;

            try
            {
                await Task.Run(() => smtp.Send(message));
                MessageBox.Show(Const.Message.Account.SEND_CODE_SUCCESS, Const.Title.SUCCESS, MessageBoxButtons.OK);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Const.Title.FAIL, MessageBoxButtons.OK);
            }
            finally
            {
                prg.Visible = false;
            }
        }

        private bool CheckUsernameExist(string username)
        {
            SqlCommand command = new SqlCommand(@"
                SELECT * FROM [Login]
                WHERE username = @username");
            command.Parameters.AddWithValue("@username", username);
            DataTable table = SqlHelper.GetTable(command);
            return table.Rows.Count > 0;
        }
    }
}
