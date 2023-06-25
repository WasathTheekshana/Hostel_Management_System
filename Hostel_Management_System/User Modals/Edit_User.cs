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
    public partial class Edit_User : Form
    {
        public Edit_User()
        {
            InitializeComponent();
        }

        private void Edit_User_Load(object sender, EventArgs e)
        {
            guna2ShadowForm1.SetShadowForm(this);
        }

        private void gunaButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        Edit_User_Profile userProfile = new Edit_User_Profile();    
        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            userProfile.ShowDialog();
        }
    }
}
