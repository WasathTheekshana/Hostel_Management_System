using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hostel_Management_System.User_Modals
{
    public partial class Edit_Rental : Form
    {
        public Edit_Rental()
        {
            InitializeComponent();
        }

        private void Edit_Rental_Load(object sender, EventArgs e)
        {
            guna2ShadowForm1.SetShadowForm(this);
            txt_rental.Text = Convert.ToString(Properties.Settings.Default.rental);

        }

        private void gunaButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txt_rental_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '\b' && e.KeyChar != 127)
            {
                e.Handled = true; // Prevent the character from being entered
            }
               
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.rental=int.Parse(txt_rental.Text);
            Properties.Settings.Default.Save();
            this.Close();
        }
    }
}
