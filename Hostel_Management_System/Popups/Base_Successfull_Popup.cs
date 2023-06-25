using Hostel_Management_System.Database_Connection;
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
    public partial class Base_Successfull_Popup : Form
    {
        private string description;
        public void setPopup(string description)
        {
            this.description = description;
        }
        public Base_Successfull_Popup()
        {
            InitializeComponent();

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Base_Successfull_Popup_Load(object sender, EventArgs e)
        {
            guna2ShadowForm1.SetShadowForm(this);
            lbl_succ.Text = description;
            lbl_succ.AutoSize = false; // Disable automatic resizing of the label
            lbl_succ.TextAlign = ContentAlignment.MiddleCenter; // Center the text horizontally
            lbl_succ.Anchor = AnchorStyles.None;
        }

    }
}
    