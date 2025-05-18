using System;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VehicleManagement
{
    public partial class ForgetPasswordForm : Form
    {
        private string randCode;

        public ForgetPasswordForm()
        {
            InitializeComponent();
        }

        private void ForgetPasswordForm_Load(object sender, EventArgs e)
        {
            txtEmail.Text = Const.TO_EMAIL;
        }

        private void btnVerify_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string email = txtEmail.Text.Trim();
            string code = txtCode.Text.Trim();
            if (Helper.IsFieldEmpty(username) ||
                Helper.IsFieldEmpty(email) ||
                Helper.IsFieldEmpty(code))
                return;

            if (randCode != code)
            {
                MessageBox.Show(Const.Message.Account.CODE_NOT_MATCH, Const.Title.FAIL, MessageBoxButtons.OK);
                txtCode.Text = "";
                return;
            }

            ResetPasswordForm form = new ResetPasswordForm(this);
            form.Show();
            form.SetUsername(username);
            Hide();
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
    }
}
