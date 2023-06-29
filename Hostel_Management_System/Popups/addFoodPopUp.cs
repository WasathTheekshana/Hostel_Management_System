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

namespace Hostel_Management_System
{
    public partial class addFoodPopUp : Form
    {
        public addFoodPopUp()
        {
            InitializeComponent();
        }

        private void btn_addFood_addToList_Click(object sender, EventArgs e)
        {
            Connection_Sting connection_Sting = new Connection_Sting();
            string connString = connection_Sting.getConnectionString();

            string NIC = txtBox_addFood_NIC.Text;
            string foodType = comBox_addFood_food.SelectedItem.ToString(); 
            string meal = cmbBox_meal.SelectedItem.ToString();

            DateTime date;
            if (comBox_addFood_date.SelectedItem.ToString() == "Today")
            {
                date = DateTime.Today;
            }
            else if (comBox_addFood_date.SelectedItem.ToString() == "Tomorrow")
            {
                date = DateTime.Today.AddDays(1);
            }
            else
            {
                // Handle any other cases or show an error message
                MessageBox.Show("Invalid date selection");
                return;
            }

            bool payment = chckBox_addFood_paid.Checked;

            string query = "INSERT INTO food_order(NIC, type, meal, OrderDate, paid) VALUES('"+NIC+"','"+foodType+"','"+meal+"','"+date+"','"+payment+"')";

            SqlConnection conn = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand(query, conn);

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                Base_Successfull_Popup successPop = new Base_Successfull_Popup();
                successPop.setPopup("Order Added!");
                successPop.setFoodImage();
                successPop.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            { conn.Close(); }
        }

        private void addFood_popUp_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
