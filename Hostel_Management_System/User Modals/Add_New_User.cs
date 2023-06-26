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
    public partial class Add_New_User : Form
    {
        public Add_New_User()
        {
            InitializeComponent();
        }

        private void Add_New_User_Load(object sender, EventArgs e)
        {
            guna2ShadowForm1.SetShadowForm(this);
        }

        private void gunaButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_addUser_Click(object sender, EventArgs e)
        {
            Base_Successfull_Popup success = new Base_Successfull_Popup();
            Base_Error_Popup error = new Base_Error_Popup();

            string userName = txt_username.Text;
            string password = txt_password.Text;
            string confirmPass = txt_confirmPass.Text;
            int addEdit;

            if (check_addEdit.Checked)
            {
                addEdit = 1;
            }
            else
            {
                addEdit = 0;
            }

            if (password != confirmPass)
            {
                error.setPopup("Passwords do not match. Please re-enter.");
                error.ShowDialog();
                return;
            }

            Connection_Sting objConn = new Connection_Sting();
            string connStr = objConn.getConnectionString();

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string query = "SELECT COUNT(*) FROM admin WHERE username = @username";
                SqlCommand checkUsernameCmd = new SqlCommand(query, conn);
                checkUsernameCmd.Parameters.AddWithValue("@username", userName);

                try
                {
                    conn.Open();
                    int userCount = (int)checkUsernameCmd.ExecuteScalar();

                    if (userCount > 0)
                    {
                        error.setPopup("Username already exists. Please choose a different username.");
                        error.ShowDialog();
                    }
                    else
                    {
                        query = "INSERT INTO admin VALUES (@username, @password, 0, @addEdit, 1, 0)";
                        SqlCommand insertCmd = new SqlCommand(query, conn);
                        insertCmd.Parameters.AddWithValue("@username", userName);
                        insertCmd.Parameters.AddWithValue("@password", confirmPass);
                        insertCmd.Parameters.AddWithValue("@addEdit", addEdit);

                        insertCmd.ExecuteNonQuery();

                        success.setPopup("User Added Successfully");
                        success.ShowDialog();

                        txt_username.Text = "";
                        txt_password.Text = "";
                        txt_confirmPass.Text = "";
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

    }
}
