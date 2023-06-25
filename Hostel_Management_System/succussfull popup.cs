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
    public partial class succussfull_popup : Form
    {
        public succussfull_popup()
        {
            InitializeComponent();
            string lblmessage="";
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {

        }

        private void succussfull_popup_Load(object sender, EventArgs e)
        {
            gunaLabel3.Text = lblmessage;
        }
    }
}
