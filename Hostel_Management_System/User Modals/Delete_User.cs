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

        private bool validateFood(string foodName, string mealType, int foodPrice)
        {
            if (string.IsNullOrEmpty(foodName))
            {
                MessageBox.Show("Please fill in the Food Name.", "Validation Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;

            }

            if (string.IsNullOrEmpty(mealType))
            {
                MessageBox.Show("Please select a meal type.", "Validation Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (foodPrice <= 0)
            {
                MessageBox.Show("Please enter a valid food price.", "Validation Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;

           
        }

        private void btn_addFood_item_Click(object sender, EventArgs e)
        {
            string foodName = txt_FoodName.Text;
            string meal = comBox_meal.Text;
            int foodPrice;

            if (!int.TryParse(txtBox_food_price.Text, out foodPrice))
            {
                MessageBox.Show("Please enter a valid food price.", "Validation Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (validateFood(foodName, meal, foodPrice))
            {
                Connection_Sting conStr = new Connection_Sting();

                string query = "INSERT INTO food VALUES('" + foodName + "','" + meal + "','" + foodPrice + "')";

                SqlConnection conn = new SqlConnection(conStr.getConnectionString());
                SqlCommand cmd = new SqlCommand(query, conn);

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    Base_Successfull_Popup successPop = new Base_Successfull_Popup();
                    successPop.setPopup("New Food Added!");
                    successPop.setFoodImage();
                    successPop.ShowDialog();
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);

                }
                finally
                {
                    conn.Close();
                }
            }
            
           
        }
    }
}
