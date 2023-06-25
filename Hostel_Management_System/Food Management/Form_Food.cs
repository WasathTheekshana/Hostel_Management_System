using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
        }

        
    }
}
