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
    public partial class Base_Error_Popup : Form
    {
        private string description;
        public void setPopup(string description)
        {
            this.description = description;
        }
        public Base_Error_Popup()
        {
            InitializeComponent();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Base_Error_Popup_Load(object sender, EventArgs e)
        {
            guna2ShadowForm1.SetShadowForm(this);
            lbl_err.Text = description;
            lbl_err.AutoSize = false; // Disable automatic resizing of the label
            lbl_err.TextAlign = ContentAlignment.MiddleCenter; // Center the text horizontally
            lbl_err.Anchor = AnchorStyles.None;
        }
    }
}
