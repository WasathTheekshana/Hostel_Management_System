using Hostel_Management_System.Popups;
using Microsoft.VisualBasic.Devices;
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

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Pending_Payments pendingPayments = new Pending_Payments();
            pendingPayments.ShowDialog();
        }

        private void btn_today_dinner_view_Click(object sender, EventArgs e)
        {
            Available_Slots availableSlots = new Available_Slots();
            availableSlots.ShowDialog();
        }
    }
}
