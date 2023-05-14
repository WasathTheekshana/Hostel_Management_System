using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hostel_Management_System
{
    public partial class form_login : Form
    {

        string username_placeholder = "Enter the username";
        string password_placeholder = "password";
        public form_login()
        {
            InitializeComponent();

            
        }

        public void RemoveText(object sender, EventArgs e)
        {
            
        }

        public void AddText(object sender, EventArgs e)
        {
          
        }

        private void gunaTransfarantPictureBox1_Click(object sender, EventArgs e)
        {

        }


        private void txt_username_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_username.Text))
            {
                e.Cancel = true;
                txt_username.Focus();
                err_username.SetError(txt_username, "Username should not be left blank!");
            }
            else
            {
                e.Cancel = false;
                err_username.SetError(txt_username, "");
            }
        }

        private void txt_password_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_password.Text))
            {
                e.Cancel = true;
                txt_password.Focus();
                err_username.SetError(txt_password, "Password should not be left blank!");
            }
            else
            {
                e.Cancel = false;
                err_username.SetError(txt_password, "");
            }
        }
        

        private void txt_password_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            Form1Test form1Test = new Form1Test();
            
            this.Hide();
            form1Test.Show();

        }

        private void form_login_Load(object sender, EventArgs e)
        {
            txt_username.Text = username_placeholder;
            txt_password.Text = password_placeholder;
            txt_password.UseSystemPasswordChar = true;
            txt_password.PasswordChar = '.';
        }

        private void txt_username_Enter(object sender, EventArgs e)
        {
            txt_username.Text = "";
        }

        private void txt_password_Enter(object sender, EventArgs e)
        {
            txt_password.Text = "";
            txt_password.UseSystemPasswordChar = true;
            txt_password.PasswordChar = '.';
        }

        private void txt_username_Leave(object sender, EventArgs e)
        {
            txt_username.Text = username_placeholder;
        }

        private void txt_password_Leave(object sender, EventArgs e)
        {
            txt_password.Text = password_placeholder;
            
        }

        private void gunaLabel2_Click(object sender, EventArgs e)
        {

        }

        private void gunaPictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void gunaLabel1_Click(object sender, EventArgs e)
        {

        }
    }
}
