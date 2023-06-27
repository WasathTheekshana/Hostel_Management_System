using Hostel_Management_System.Database_Connection;
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

namespace Hostel_Management_System.Popups
{
    public partial class Room_Available : Form
    {
        public Room_Available()
        {
            InitializeComponent();
        }

        string slotID;
        public void getSlotID(string slotid)
        {
            slotID = slotid;
        }

        private void Room_Available_Load(object sender, EventArgs e)
        {
            guna2ShadowForm1.SetShadowForm(this);
            lbl_slotID.Text = slotID;
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            string stNIC = txt_username.Text;

            Connection_Sting stconn = new Connection_Sting();
            string connectionString = stconn.getConnectionString();
            SqlConnection connection = new SqlConnection(connectionString);

            string checkquery = @"SELECT COUNT(*) FROM student_slot WHERE NIC = @StudentNIC";
            SqlCommand checkcommand = new SqlCommand(checkquery, connection);
            checkcommand.Parameters.AddWithValue("@StudentNIC", stNIC);

            string deletequery = @"DELETE FROM student_slot WHERE NIC = @StudentNIC";
            SqlCommand deletecommand = new SqlCommand(deletequery, connection);
            deletecommand.Parameters.AddWithValue("@StudentNIC", stNIC);

            string query = $"INSERT INTO student_slot VALUES('" + stNIC + "','" + slotID + "')";
            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();
                int count = (int)checkcommand.ExecuteScalar();
                if (count > 0)
                {
                    deletecommand.ExecuteNonQuery(); // Delete the existing record

                    Base_Successfull_Popup successfull_Popup = new Base_Successfull_Popup();
                    successfull_Popup.setPopup("Successfully changed Room;");
                    successfull_Popup.ShowDialog();
                }
                else
                {
                    command.ExecuteNonQuery(); // Insert the new record

                    Base_Successfull_Popup successfull_Popup = new Base_Successfull_Popup();
                    successfull_Popup.setPopup("Successfully assigned with Room;");
                    successfull_Popup.ShowDialog();
                }

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }


        private void gunaButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
