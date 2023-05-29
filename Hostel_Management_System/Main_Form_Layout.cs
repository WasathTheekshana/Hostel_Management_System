using Guna.UI2.WinForms;
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
    public partial class Main_Form_Layout : Form
    {
        public Main_Form_Layout()
        {
            InitializeComponent();
        }

       private void container(object _form)
        {
            Form fm = _form as Form;
            fm.TopLevel = false;
            fm.FormBorderStyle = FormBorderStyle.None;
            fm.Dock = DockStyle.Fill;
            panel_container.Controls.Add(fm);
            panel_container.Tag = fm;
            fm.Show();
        }


        private void Main_Form_Layout_Load(object sender, EventArgs e)
        {
            btn_dashboard.Checked = true;
            container(new Form_Dashboard());
        }

      
        private void btn_dashboard_Click(object sender, EventArgs e)
        {
           container(new Form_Dashboard());
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            
        }
    }
}
