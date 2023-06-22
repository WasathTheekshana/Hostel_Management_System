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
    public partial class DetailForm : Form
    {
        public DetailForm()
        {
            InitializeComponent();
        }

        private void container(object _form)
        {
            Form DFM = _form as Form;
            DFM.TopLevel = false;
            DFM.FormBorderStyle = FormBorderStyle.None;
            DFM.Dock = DockStyle.Fill;
            panel_container.Controls.Clear();
            panel_container.Controls.Add(DFM);
            panel_container.Tag = DFM;
            DFM.Show();
        }

        private void Register_Load(object sender, EventArgs e)
        {
           container(new DetailForm_StudentDetails());
        }
    }
}
