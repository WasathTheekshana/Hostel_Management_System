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
    public partial class Delete_User : Form
    {
        public Delete_User()
        {
            InitializeComponent();
        }

        private void Delete_User_Load(object sender, EventArgs e)
        {
            guna2ShadowForm1.SetShadowForm(this);
        }

        private void gunaButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
