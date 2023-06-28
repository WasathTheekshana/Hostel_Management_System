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

namespace Hostel_Management_System
{
    public partial class Form_Food : Form
    {
        private string formattedTodayDate;
        private string formattedTomorrowDate;
        public Form_Food()
        {
            InitializeComponent();

            // Today's date
            DateTime today = DateTime.Today;
            int todayDay = today.Day;
            string todayDaySuffix = GetDaySuffix(todayDay);
            formattedTodayDate = $"{todayDay}{todayDaySuffix} {today.ToString("MMMM, yyyy")}";

            // Tomorrow's date
            DateTime tomorrow = DateTime.Today.AddDays(1);
            int tomorrowDay = tomorrow.Day;
            string tomorrowDaySuffix = GetDaySuffix(tomorrowDay);
            formattedTomorrowDate = $"{tomorrowDay}{tomorrowDaySuffix} {tomorrow.ToString("MMMM, yyyy")}";
        }

        // Helper method to get the day suffix
        private string GetDaySuffix(int day)
        {
            if (day >= 11 && day <= 13)
                return "th";
            else if (day % 10 == 1)
                return "st";
            else if (day % 10 == 2)
                return "nd";
            else if (day % 10 == 3)
                return "rd";
            else
                return "th";
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            lbl_Today.Text = "| " + formattedTodayDate;
            lbl_Tomorrow.Text = "| " + formattedTomorrowDate;

            updateFoodCounts();
        }

        DateTime today = DateTime.Today;

        DateTime tomorrow = DateTime.Today.AddDays(1);

        private void btn_today_breakfast_view_Click(object sender, EventArgs e)
        {
            Food_List fdList = new Food_List();
            fdList.getOrderDay(today);
            fdList.Show();
        }

        private void btn_today_breakfast_add_Click(object sender, EventArgs e)
        {
            addFoodPopUp addFoodPop = new addFoodPopUp();
            addFoodPop.Show();
        }

        private void btn_today_lunch_add_Click(object sender, EventArgs e)
        {
            addFoodPopUp addFoodPop = new addFoodPopUp();
            addFoodPop.Show();
        }

        private void btn_today_dinner_add_Click(object sender, EventArgs e)
        {
            addFoodPopUp addFoodPop = new addFoodPopUp();
            addFoodPop.Show();
        }

        private void btn_tomorrow_breakfast_add_Click(object sender, EventArgs e)
        {
            addFoodPopUp addFoodPop = new addFoodPopUp();
            addFoodPop.Show();
        }

        private void btn_tomorrow_lunch_add_Click(object sender, EventArgs e)
        {
            addFoodPopUp addFoodPop = new addFoodPopUp();
            addFoodPop.Show();
        }

        private void btn_tomorrow_dinner_add_Click(object sender, EventArgs e)
        {
            addFoodPopUp addFoodPop = new addFoodPopUp();
            addFoodPop.Show();
        }

        private void btn_today_lunch_view_Click(object sender, EventArgs e)
        {
            Food_List fdList = new Food_List();
            fdList.getOrderDay(today);
            fdList.Show();
        }

        private void btn_today_dinner_view_Click(object sender, EventArgs e)
        {
            Food_List fdList = new Food_List();
            fdList.getOrderDay(today);
            fdList.Show();
        }

        private void btn_tomorrow_breakfast_view_Click(object sender, EventArgs e)
        {
            Food_List fdList = new Food_List();
            fdList.getOrderDay(tomorrow);
            fdList.Show();
        }

        private void btn_tomorrow_lunch_view_Click(object sender, EventArgs e)
        {
            Food_List fdList = new Food_List();
            fdList.getOrderDay(tomorrow);
            fdList.Show();
        }

        private void btn_tomorrow_dinner_view_Click(object sender, EventArgs e)
        {
            Food_List fdList = new Food_List();
            fdList.getOrderDay(tomorrow);
            fdList.Show();
        }

        public void updateFoodCounts()
        {
            Connection_Sting connection_Sting = new Connection_Sting();
            string connStr = connection_Sting.getConnectionString();

            // Get today's and tomorrow's breakfast counts
            string query = "SELECT " +
                "(SELECT COUNT(*) FROM food_order WHERE OrderDate = CAST(GETDATE() AS DATE) AND meal = 'breakfast') AS TodayBreakfastCount, " +
                "(SELECT COUNT(*) FROM food_order WHERE OrderDate = CAST(GETDATE() AS DATE) AND meal = 'lunch') AS TodayLunchCount, " +
                "(SELECT COUNT(*) FROM food_order WHERE OrderDate = CAST(GETDATE() AS DATE) AND meal = 'dinner') AS TodayDinnerCount, " +
                "(SELECT COUNT(*) FROM food_order WHERE OrderDate = DATEADD(DAY, 1, CAST(GETDATE() AS DATE)) AND meal = 'breakfast') AS TomorrowBreakfastCount, " +
                "(SELECT COUNT(*) FROM food_order WHERE OrderDate = DATEADD(DAY, 1, CAST(GETDATE() AS DATE)) AND meal = 'lunch') AS TomorrowLunchCount, " +
                "(SELECT COUNT(*) FROM food_order WHERE OrderDate = DATEADD(DAY, 1, CAST(GETDATE() AS DATE)) AND meal = 'dinner') AS TomorrowDinnerCount";

            int todayBreakfastCount = 0;
            int todayLunchCount = 0;
            int todayDinnerCount = 0;
            int tomorrowBreakfastCount = 0;
            int tomorrowLunchCount = 0;
            int tomorrowDinnerCount = 0;

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                SqlCommand command = new SqlCommand(query, conn);
                conn.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        todayBreakfastCount = reader.GetInt32(0);
                        todayLunchCount = reader.GetInt32(1);
                        todayDinnerCount = reader.GetInt32(2);
                        tomorrowBreakfastCount = reader.GetInt32(3);
                        tomorrowLunchCount = reader.GetInt32(4);
                        tomorrowDinnerCount = reader.GetInt32(5);
                    }
                }
            }

            lbl_today_breakfast_food.Text = todayBreakfastCount.ToString();
            lbl_today_lunch_food.Text = todayLunchCount.ToString();
            lbl_today_dinner_food.Text = todayDinnerCount.ToString();
            lbl_tomorrow_breakfast_food.Text = tomorrowBreakfastCount.ToString();
            lbl_tomorrow_lunch_food.Text = tomorrowLunchCount.ToString();
            lbl_tomorrow_dinner_food.Text = tomorrowDinnerCount.ToString();
        }
    }
    }
