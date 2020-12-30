using hgcrawler.util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace hgcrawlerform.Forms
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            chkSavePwd.Checked = Properties.Settings.Default.SavePwdFlag;
            txtUsername.Text = Properties.Settings.Default.Username;
            txtPassword.Text = Properties.Settings.Default.Password;

            InitLogForm();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            var uname = txtUsername.Text;
            var pwd = txtPassword.Text;
            if (string.IsNullOrEmpty(uname) || string.IsNullOrEmpty(pwd))
            {
                MessageBox.Show("账号密码为空");
                return;
            }

            if (chkSavePwd.Checked)
            {
                Properties.Settings.Default.Username = uname;
                Properties.Settings.Default.Password = pwd;
                Properties.Settings.Default.Save();
            }

            IWebapiClient webclientApi = new WebapiClient();
            var dto = webclientApi.Login(uname, pwd);
            if (dto != null)
            {
                HomeForm form = new HomeForm();
                this.Hide();
                form.Show();
            }
            else
            {
                MessageBox.Show("登录失败");
            }
        }

        private void InitLogForm()
        {
            if (FormsBuff.LogForm == null)
                FormsBuff.LogForm = new LogForm();
            FormsBuff.LogForm.Show();
            FormsBuff.LogForm.Hide();
        }
    }
}
