using Hostel_Management_System.User_Modals;
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
    public partial class Form_Settings : Form
    {
        public Form_Settings()
        {
            InitializeComponent();
        }

        private void Form_Settings_Load(object sender, EventArgs e)
        {

        }

        Add_New_User newUserModal = new Add_New_User();
        Delete_User deleteUser = new Delete_User();
        Edit_Rental editRental = new Edit_Rental();
        Edit_User editUser = new Edit_User();
        private void gunaShadowPanel2_Click(object sender, EventArgs e)
        {
            newUserModal.ShowDialog();
        }

        private void btn_today_dinner_view_Click(object sender, EventArgs e)
        {
            newUserModal.ShowDialog();
        }

        private void gunaShadowPanel4_Click(object sender, EventArgs e)
        {
            deleteUser.ShowDialog();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            deleteUser.ShowDialog();
        }

        private void gunaShadowPanel3_Click(object sender, EventArgs e)
        {
            editRental.ShowDialog();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            editRental.ShowDialog();
        }

        private void gunaShadowPanel1_Click(object sender, EventArgs e)
        {
            editUser.ShowDialog();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            editUser.ShowDialog();
        }
    }
}
