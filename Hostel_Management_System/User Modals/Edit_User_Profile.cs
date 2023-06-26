using Hostel_Management_System.Database_Connection;
using Hostel_Management_System.Popups;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hostel_Management_System.User_Modals
{
    public partial class Edit_User_Profile : Form
    {
        public Edit_User_Profile()
        {
            InitializeComponent();
        }

        private string username;

        public Edit_User_Profile(string username)
        {
            InitializeComponent();
            this.username = username;
        }


        private void gunaButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Edit_User_Profile_Load(object sender, EventArgs e)
        {
            guna2ShadowForm1.SetShadowForm(this);

            txt_username.Text = username;
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            Base_Error_Popup error = new Base_Error_Popup();
            Base_Successfull_Popup success = new Base_Successfull_Popup();
            success.setPopup("Password Updated Succuessfully!");
            error.setPopup("Password doesn't match!");

            if(txt_passwod.Text == txt_confirmPass.Text)
            {
               
                Connection_Sting objConn = new Connection_Sting();
                string connStr = objConn.getConnectionString();

                SqlConnection conn = new SqlConnection(connStr);
                string qry = "UPDATE admin set password= '" + txt_confirmPass.Text + "' WHERE username = '" + username + "'";
                SqlCommand cmd = new SqlCommand(qry, conn);

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    success.ShowDialog();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally { conn.Close(); }
            }
            else
            {
                error.ShowDialog();
            }
        }
    }
}
