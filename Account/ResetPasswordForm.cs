using System;
using System.Windows.Forms;

namespace VehicleManagement
{
    public partial class ResetPasswordForm : Form
    {
        private Account account = new Account();
        private Form prevForm;
        private string username;

        public ResetPasswordForm(Form prevForm)
        {
            InitializeComponent();
            this.prevForm = prevForm;
        }

        private void ResetPasswordForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            prevForm.Show();
        }

        private void btnVerify_Click(object sender, EventArgs e)
        {
            string password = txtPassword.Text.Trim();
            string rePassword = txtRePassword.Text.Trim();
            if (Helper.IsFieldEmpty(password) ||
                Helper.IsFieldEmpty(rePassword))
                return;

            if (password != rePassword)
            {
                txtRePassword.Text = "";
                MessageBox.Show(Const.Message.Account.REPASSWORD_NOT_MATCH, Const.Title.FAIL, MessageBoxButtons.OK);
                return;
            }

            if (account.Update(username, password))
            {
                txtPassword.Text = "";
                txtRePassword.Text = "";
                MessageBox.Show(Const.Message.Account.RESET_PASSWORD_SUCCESS, Const.Title.SUCCESS, MessageBoxButtons.OK);
            }
            else
                MessageBox.Show(Const.Message.Account.RESET_PASSWORD_FAIL, Const.Title.FAIL, MessageBoxButtons.OK);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        public void SetUsername(string username)
        {
            this.username = username;
        }
    }
}
