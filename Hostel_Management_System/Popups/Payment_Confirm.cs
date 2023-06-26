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
    public partial class Payment_Confirm : Form
    {
        public Payment_Confirm()
        {
            InitializeComponent();
        }

        string studentNIC;

        public void getNIC(string NIC)
        {
            studentNIC = NIC;
        }


        private void gunaButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_login_Click(object sender, EventArgs e)
        {

            int payment = int.Parse(txt_payment.Text);

            Connection_Sting objConnectionString = new Connection_Sting();
            string connStr = objConnectionString.getConnectionString();

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();

                string query = @"UPDATE student
                         SET rental = rental + @Payment
                         WHERE NIC = @StudentNIC";

                SqlCommand command = new SqlCommand(query, conn);
                command.Parameters.AddWithValue("@Payment", payment);
                command.Parameters.AddWithValue("@StudentNIC", studentNIC); // Add the studentNIC parameter
                command.ExecuteNonQuery();

                Properties.Settings.Default.rentalAdd = true;
                Properties.Settings.Default.Save();

                MessageBox.Show("Rentals updated successfully.");
                this.Close();
            }
        }

        private void txt_payment_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '\b' && e.KeyChar != '\u007F')
            {
                // Suppress the key press event
                e.Handled = true;
            }
        }

        private void Payment_Confirm_Load(object sender, EventArgs e)
        {
            guna2ShadowForm1.SetShadowForm(this);
        }
    }
}
