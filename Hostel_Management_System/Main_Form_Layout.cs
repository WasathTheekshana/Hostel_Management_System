using Guna.UI2.WinForms;
using Hostel_Management_System.Logged_In_Users;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hostel_Management_System
{
    public partial class Main_Form_Layout : Form
    {
        public Main_Form_Layout()
        {
            InitializeComponent();


            
        }

        public string loggedInUser;

        public void setUserName(string loggedInUser)
        {
            this.loggedInUser = loggedInUser;
        } 

       private void container(object _form)
        {
            Form fm = _form as Form;
            fm.TopLevel = false;
            fm.FormBorderStyle = FormBorderStyle.None;
            fm.Dock = DockStyle.Fill;
            panel_container.Controls.Clear();
            panel_container.Controls.Add(fm);
            panel_container.Tag = fm;
            fm.Show();
        }

        private void Main_Form_Layout_Load(object sender, EventArgs e)
        {
            txt_logged_user.Text = loggedInUser;
            btn_dashboard.Checked = true;
            container(new Form_Dashboard());
        }

      
        private void btn_dashboard_Click(object sender, EventArgs e)
        {
            container(new Form_Dashboard());
     
        }

        private void btn_food_Click(object sender, EventArgs e)
        {
            container(new Form_Food());            

        }

        private void btn_studnetList_Click(object sender, EventArgs e)
        {
            container(new Form_StudentList());
        }

        private void btn_addNew_Click(object sender, EventArgs e)
        {
            container(new Form_AddNew());
        }

        private void btn_settings_Click(object sender, EventArgs e)
        {
            container(new Form_Settings());
        }

        private void gunaLabel2_Click(object sender, EventArgs e)
        {
            User_State user_State = new User_State();

        }
    }
}
