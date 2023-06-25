using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hostel_Management_System.Popups
{
    public partial class Logout_Popup : Form
    {
        public Logout_Popup()
        {
            InitializeComponent();
        }

        private void Logout_Popup_Load(object sender, EventArgs e)
        {
            guna2ShadowForm1.SetShadowForm(this);
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            Main_Form_Layout mainForm = Application.OpenForms.OfType<Main_Form_Layout>().FirstOrDefault();
            form_login login = new form_login();

            if (mainForm != null)
            {
                mainForm.Close();
            }

            login.Show();
            this.Close();
        }

        private void gunaButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
