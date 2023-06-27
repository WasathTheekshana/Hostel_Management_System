using Hostel_Management_System.Database_Connection;
using Hostel_Management_System.Popups;
using Microsoft.VisualBasic.Devices;
using System;
using System.Collections;
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
    public partial class Form_Dashboard : Form
    {
        public Form_Dashboard()
        {
            InitializeComponent();
        }

        private string userName;
        public void setUserName(string userName)
        {
            this.userName = userName;
        }

        private bool rentprivi;
        public void setRentalPrivi(bool rentalprivi)
        {
            rentprivi = rentalprivi;
        }
        

        public void updateDashBoard() 
        {
            Connection_Sting objConnectionString = new Connection_Sting();
            string connStr = objConnectionString.getConnectionString();

            string totalSlotsQuery = @"SELECT COUNT(*) AS TotalCount FROM slot";
            string unassignedSlotsQuery = @"SELECT COUNT(*) AS TotalCount
                               FROM slot s
                               LEFT JOIN student_slot ss ON s.slotID = ss.slotID
                               WHERE ss.slotID IS NULL";

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                try
                {
                    conn.Open();

                    SqlCommand totalSlotsCommand = new SqlCommand(totalSlotsQuery, conn);
                    int totalSlotsCount = (int)totalSlotsCommand.ExecuteScalar();


                    SqlCommand unassignedSlotsCommand = new SqlCommand(unassignedSlotsQuery, conn);
                    int unassignedSlotsCount = (int)unassignedSlotsCommand.ExecuteScalar();


                    lbl_availableSlotCount.Text = $"{unassignedSlotsCount.ToString()} / {totalSlotsCount.ToString()}";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            string querypendingCount = "SELECT COUNT(*) FROM student WHERE rental < 0";

            string queryTotal = "SELECT COUNT(*) FROM student";

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                try
                {
                    conn.Open();
                    SqlCommand commandPending = new SqlCommand(querypendingCount, conn);
                    int countPending = (int)commandPending.ExecuteScalar();

                    SqlCommand commandTotal = new SqlCommand(queryTotal, conn);
                    int countTotal = (int)commandTotal.ExecuteScalar();

                    lbl_pendingPayment.Text = $"{countPending} / {countTotal}";

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }


        }

        private void Form_Dashboard_Load(object sender, EventArgs e)
        {
            DateTime currentTime = DateTime.Now;
            int hour = currentTime.Hour;

            if (hour < 12)
            {
                lbl_greeting.Text = "Good Morning, " + userName;
            }
            else if (hour >= 12 && hour < 18)
            {
                lbl_greeting.Text = "Good Afternoon, " + userName;
            }
            else
            {
                lbl_greeting.Text = "Good Evening, " + userName;
            }
            updateDashBoard();

            Connection_Sting objConnectionString = new Connection_Sting();
            string connStr = objConnectionString.getConnectionString();

            string queryBreakfast = @"SELECT COUNT(*) FROM food_order WHERE meal = 'Breakfast' AND CONVERT(DATE, orderDate) = CONVERT(DATE, GETDATE())";
            string queryLunch = @"SELECT COUNT(*) FROM food_order WHERE meal = 'Lunch' AND CONVERT(DATE, orderDate) = CONVERT(DATE, GETDATE())";
            string queryDinner = @"SELECT COUNT(*) FROM food_order WHERE meal = 'Dinner' AND CONVERT(DATE, orderDate) = CONVERT(DATE, GETDATE())";

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                try
                {
                    conn.Open();
                    SqlCommand commandb = new SqlCommand(queryBreakfast, conn);
                    SqlCommand commandl = new SqlCommand(queryLunch, conn);
                    SqlCommand commandd = new SqlCommand(queryDinner, conn);

                    int countb = (int)commandb.ExecuteScalar();
                    int countl = (int)commandl.ExecuteScalar();
                    int countd = (int)commandd.ExecuteScalar();

                    lbl_today_breakfast_food.Text = Convert.ToString(countb);
                    lbl_today_lunch_food.Text = Convert.ToString(countl);
                    lbl_today_dinner_food.Text = Convert.ToString(countd);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
            }

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Pending_Payments pendingPayments = new Pending_Payments();
            pendingPayments.setRentalPrivi(rentprivi);
            pendingPayments.ShowDialog();
        }

        private void btn_today_dinner_view_Click(object sender, EventArgs e)
        {
            Available_Slots availableSlots = new Available_Slots();
            availableSlots.ShowDialog();
        }
    }
}
