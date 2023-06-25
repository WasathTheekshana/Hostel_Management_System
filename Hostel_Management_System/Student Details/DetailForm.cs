using Hostel_Management_System.Database_Connection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Hostel_Management_System
{
    public partial class DetailForm : Form
    {
        public DetailForm()
        {
            InitializeComponent();
        }

        private void Register_Load(object sender, EventArgs e)
        {
            ComboStudentGender.SelectedIndex = 0;
            DateStudentRegisterDate.Value = DateTime.Today;
        }

        #region StudentValidate
        private bool ValidateForm()
        {
            //Check if all fields are filled
            if (string.IsNullOrEmpty(txtStudentFName.Text.Trim()) ||
                string.IsNullOrEmpty(txtStudentLName.Text.Trim()) ||
                string.IsNullOrEmpty(txtStudentNIC.Text.Trim()) ||
                string.IsNullOrEmpty(txtStudentBatch.Text.Trim()) ||
                string.IsNullOrEmpty(txtStudentEmail.Text.Trim()) ||
                string.IsNullOrEmpty(txtStudentContactNo.Text.Trim()) ||
                string.IsNullOrEmpty(txtStudentAddress.Text.Trim()) ||
                string.IsNullOrEmpty(txtStudentHomeNo.Text.Trim()) ||
                string.IsNullOrEmpty(txtStudentKeyMoney.Text.Trim()) ||
                DateBirthDay.Value == null ||
                DateStudentRegisterDate.Value == null)
            {
                MessageBox.Show("Please fill in all Student Details.", "Validation Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            //Check if birthday is minimum 15 years before today
            DateTime birthday = DateBirthDay.Value;
            DateTime minBirthday = DateTime.Today.AddYears(-15);
            if (birthday >= minBirthday)
            {
                MessageBox.Show("Birthday Seems Incorrect", "Validation Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            //Check NIC number pattern
            string nic = txtStudentNIC.Text.Trim();
            if (!Regex.IsMatch(nic, @"^\d{9}(x|v)?$") && !Regex.IsMatch(nic, @"^\d{12}$"))
            {
                MessageBox.Show("Invalid student NIC Number", "Validation Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            //Check university batch pattern
            string batch = txtStudentBatch.Text.Trim();
            if (!Regex.IsMatch(batch, @"^\d{1,2}\.\d{1}$"))
            {
                MessageBox.Show("Invalid University Batch", "Validation Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            //Check email validity
            string email = txtStudentEmail.Text.Trim();
            if (!IsValidEmail(email))
            {
                MessageBox.Show("Student Email address is not valid.", "Validation Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            //Check contact number pattern
            string contactNumber = txtStudentContactNo.Text.Trim();
            if (!Regex.IsMatch(contactNumber, @"^(070|071|072|074|075|076|077|078)\d{7}$"))
            {
                MessageBox.Show("Invalid Mobile Number for Student", "Validation Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            string homePhoneNumber = txtStudentHomeNo.Text.Trim();
            if (!Regex.IsMatch(homePhoneNumber, @"^0\d{9}$"))
            {
                MessageBox.Show("Invalid Home Phone Number", "Validation Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }
        #endregion

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (ValidateForm())
            {
                flowLayoutPanel1.AutoScrollPosition = new Point(0, flowLayoutPanel1.VerticalScroll.Maximum);
                flowLayoutPanel1.PerformLayout();
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            flowLayoutPanel1.AutoScrollPosition = new Point(0, 0);
            flowLayoutPanel1.PerformLayout();
        }
        #region KeyPress

        private void ValidateNumericInput(Guna.UI2.WinForms.Guna2TextBox textBox, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Ignore non-numeric characters
            }

            if (textBox.Text.Length >= 10 && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Ignore input after reaching max length
            }
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                MailAddress mailAddress = new MailAddress(email);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }

        private void NameKeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != '\b' && e.KeyChar != '\t' && e.KeyChar != '\u007F')
            {
                e.Handled = true;
            }
        }

        private void NICKeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != 'x' && e.KeyChar != 'v')
            {
                e.Handled = true;
            }
        }

        #region studetKeyPress
        private void txtStudentContactNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidateNumericInput(txtStudentContactNo, e);
        }

        private void txtStudentHomeNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidateNumericInput(txtStudentHomeNo, e);
        }

        private void txtStudentBatch_KeyPress(object sender, KeyPressEventArgs e)
        {
            char decimalSeparator = CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator[0];

            
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '\b' && e.KeyChar != decimalSeparator)
            {
                e.Handled = true;
            }

            if (e.KeyChar == decimalSeparator && txtStudentBatch.Text.Contains(decimalSeparator))
            {
                e.Handled = true;
            }
        }

        private void txtStudentKeyMoney_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Ignore non-numeric characters
            }
        }
        #endregion

        #region parentKeyPress

        private void txtParent1No_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidateNumericInput(txtParent1No, e);
        }

        private void txtParent2No_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidateNumericInput(txtParent2No, e);
        }
        #endregion

        #endregion

        #region detailsVariables

        #region studentDetailVariable
        public string StudentFName
        {
            get { return txtStudentFName.Text; }
            set { txtStudentFName.Text = value; }
        }
        public string StudentLName
        {
            get { return txtStudentLName.Text; }
            set { txtStudentLName.Text = value; }
        }
        public DateTime StudentBirthday
        {
            get { return DateBirthDay.Value; }
            set { DateBirthDay.Value = value; }
        }
        public string StudentNIC
        {
            get { return txtStudentNIC.Text; }
            set { txtStudentNIC.Text = value;}
        }
        public char StudentGender
        {
            get
            {
                if (ComboStudentGender.SelectedItem.ToString() == "Male")
                {
                    return 'M';
                }
                else
                {
                    return 'F';
                }
            }
            set
            {
                if (value == 'M')
                {
                    ComboStudentGender.SelectedItem = "Male";
                }
                else
                {
                    ComboStudentGender.SelectedItem = "Female";
                }
            }
        }

        public double StudentBatch
        {
            get { return double.Parse(txtStudentBatch.Text); }
            set { txtStudentBatch.Text = value.ToString();}
        }
        public string StudentEmail
        {
            get { return txtStudentEmail.Text; }
            set { txtStudentEmail.Text = value;}
        }
        public string StudentPhone
        {
            get { return txtStudentContactNo.Text; }
            set { txtStudentContactNo.Text = value; }
        }
        public string StudentAddress
        {
            get { return txtStudentAddress.Text; }
            set { txtStudentAddress.Text = value;}
        }
        public string StudentHomePhone
        {
            get { return txtStudentHomeNo.Text; }
            set { txtStudentHomeNo.Text = value; }
        }
        public DateTime StudentRegisterDate
        {
            get { return DateStudentRegisterDate.Value; }
            set { DateStudentRegisterDate.Value = value; }
        }
        public int StudentKeyMoney
        {
            get { return int.Parse(txtStudentKeyMoney.Text); }
            set { txtStudentKeyMoney.Text=value.ToString(); }
        }
        #endregion


        #region parent1DetailVariables

        public string Parent1Name
        {
            get { return txtParent1Name.Text; }
            set { txtParent1Name.Text = value; }
        }
        public string Parent1ContactNo
        {
            get { return txtParent1No.Text; }
            set { txtParent1No.Text = value; }
        }
        public string Parent1NIC
        {
            get { return txtParent1NIC.Text;}
            set { txtParent1NIC.Text = value;}
        }
        public string Parent1Email
        {
            get { return txtParent1Email.Text; }
            set { txtParent1Email.Text=value;}
        }
        public string Parent1Job
        {
            get { return txtParent1Job.Text;}
            set { txtParent1Job.Text = value;}
        }

        #endregion

        #region parent2DetailVariables

        public string Parent2Name
        {
            get { return txtParent2Name.Text; }
            set { txtParent2Name.Text = value; }
        }
        public string Parent2ContactNo
        {
            get { return txtParent2No.Text; }
            set { txtParent2No.Text = value; }
        }
        public string Parent2NIC
        {
            get { return txtParent2NIC.Text; }
            set { txtParent2NIC.Text = value; }
        }
        public string Parent2Email
        {
            get { return txtParent2Email.Text; }
            set { txtParent2Email.Text = value; }
        }
        public string Parent2Job
        {
            get { return txtParent2Job.Text; }
            set { txtParent2Job.Text = value; }
        }

        #endregion

        #endregion

        #region parentValidation
        private bool ValidateParentFields()
        {
            // Check if either Mother's/Guardian's or Father's/Guardian's fields are filled
            bool isMotherGuardianFilled = !string.IsNullOrWhiteSpace(txtParent1Name.Text) &&
                                          !string.IsNullOrWhiteSpace(txtParent1No.Text) &&
                                          !string.IsNullOrWhiteSpace(txtParent1NIC.Text) &&
                                          !string.IsNullOrWhiteSpace(txtParent1Job.Text) &&
                                          !string.IsNullOrWhiteSpace(txtParent1Email.Text);

            bool isFatherGuardianFilled = !string.IsNullOrWhiteSpace(txtParent2Name.Text) &&
                                          !string.IsNullOrWhiteSpace(txtParent2No.Text) &&
                                          !string.IsNullOrWhiteSpace(txtParent2NIC.Text) &&
                                          !string.IsNullOrWhiteSpace(txtParent2Job.Text) &&
                                          !string.IsNullOrWhiteSpace(txtParent2Email.Text);

            if (!isMotherGuardianFilled && !isFatherGuardianFilled)
            {
                MessageBox.Show("Please fill either Mother's/Guardian's fields or Father's/Guardian's fields.", "Validation Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Check if all fields of Mother's/Guardian's are filled
            if (isMotherGuardianFilled &&
                (string.IsNullOrWhiteSpace(txtParent1Name.Text) ||
                 string.IsNullOrWhiteSpace(txtParent1No.Text) ||
                 string.IsNullOrWhiteSpace(txtParent1NIC.Text) ||
                 string.IsNullOrWhiteSpace(txtParent1Job.Text) ||
                 string.IsNullOrWhiteSpace(txtParent1Email.Text)))
            {
                MessageBox.Show("Please fill all fields of Mother's/Guardian's.", "Validation Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Check if all fields of Father's/Guardian's are filled
            if (isFatherGuardianFilled &&
                (string.IsNullOrWhiteSpace(txtParent2Name.Text) ||
                 string.IsNullOrWhiteSpace(txtParent2No.Text) ||
                 string.IsNullOrWhiteSpace(txtParent2NIC.Text) ||
                 string.IsNullOrWhiteSpace(txtParent2Job.Text) ||
                 string.IsNullOrWhiteSpace(txtParent2Email.Text)))
            {
                MessageBox.Show("Please fill all fields of Father's/Guardian's.", "Validation Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Check contact number pattern for Mother's/Guardian's
            if (isMotherGuardianFilled && !Regex.IsMatch(txtParent1No.Text.Trim(), @"^0\d{9}$"))
            {
                MessageBox.Show("Invalid Contact Number For Mother's/Guardian's", "Validation Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Check contact number pattern for Father's/Guardian's
            if (isFatherGuardianFilled && !Regex.IsMatch(txtParent2No.Text.Trim(), @"^0\d{9}$"))
            {
                MessageBox.Show("Invalid Contact Number For Father's/Guardian's", "Validation Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Check NIC number pattern for Mother's/Guardian's
            if (isMotherGuardianFilled && !Regex.IsMatch(txtParent1NIC.Text.Trim(), @"^\d{9}(x|v)?$") && !Regex.IsMatch(txtParent1NIC.Text.Trim(), @"^\d{12}$"))
            {
                MessageBox.Show("Invalid NIC Number For Mother's/Guardian's", "Validation Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Check NIC number pattern for Father's/Guardian's
            if (isFatherGuardianFilled && !Regex.IsMatch(txtParent2NIC.Text.Trim(), @"^\d{9}(x|v)?$") && !Regex.IsMatch(txtParent2NIC.Text.Trim(), @"^\d{12}$"))
            {
                MessageBox.Show("Invalid NIC Number For Father's/Guardian's", "Validation Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Check email validity for Mother's/Guardian's (if filled)
            if (!string.IsNullOrWhiteSpace(txtParent1Email.Text) && !IsValidEmail(txtParent1Email.Text.Trim()))
            {
                MessageBox.Show("Mother's/Guardian's email is not valid.", "Validation Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Check email validity for Father's/Guardian's (if filled)
            if (!string.IsNullOrWhiteSpace(txtParent2Email.Text) && !IsValidEmail(txtParent2Email.Text.Trim()))
            {
                MessageBox.Show("Father's/Guardian's email is not valid.", "Validation Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }
        #endregion

        private void btnAccept_Click_1(object sender, EventArgs e)
        {
            if (ValidateForm() && ValidateParentFields())
            {
                Connection_Sting objConnectionString = new Connection_Sting();
                string connStr = objConnectionString.getConnectionString();

                SqlConnection conn = new SqlConnection(connStr);

                MessageBox.Show("All validations passed. Form submitted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                student objstudent = new student
                    (StudentFName,
                    StudentLName,
                    StudentBirthday, 
                    StudentNIC, 
                    StudentGender, 
                    StudentBatch, 
                    StudentEmail, 
                    StudentPhone, 
                    StudentAddress, 
                    StudentHomePhone, 
                    StudentRegisterDate, 
                    StudentKeyMoney);

                string queryStudent = $"INSERT INTO student(NIC,FName,LName,Email,Address,MobileNo,gender,DOB,keymoney,Batch,HomeTeleNo, RegisterDate) VALUES('"+StudentNIC+ "','"+StudentFName+ "','"+StudentLName+"','"+StudentEmail+"','"+StudentAddress+"','"+StudentPhone+"','"+StudentGender+"','"+StudentBirthday+"','"+StudentKeyMoney+"','"+StudentBatch+"','"+ StudentHomePhone + "','"+StudentRegisterDate+"')";
                SqlCommand commandStudent = new SqlCommand(queryStudent, conn);



                try
                {
                    conn.Open();
                    commandStudent.ExecuteNonQuery();
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                finally
                {
                    conn.Close();
                }


                if (!string.IsNullOrEmpty(txtParent1NIC.Text))
                {
                    parent objparent1 = new parent(objstudent, Parent1Name, Parent1ContactNo, Parent1NIC, Parent1Email, Parent1Job);

                    string queryParent1 = "INSERT INTO guardian VALUES('" + Parent1NIC + "','" + Parent1Name + "','" + Parent1ContactNo + "','" + Parent1Email +"','"+Parent1Job+"')";
                    SqlCommand commandParent1 = new SqlCommand(queryParent1, conn);

                    string queryStudentParent1 = "INSERT INTO student_guardian values('"+StudentNIC+"','"+Parent1NIC+"')";
                    SqlCommand commandStudentParent1 = new SqlCommand(queryStudentParent1, conn);

                    try
                    {
                        conn.Open();
                        commandParent1.ExecuteNonQuery();
                        commandStudentParent1.ExecuteNonQuery();
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
                if(!string.IsNullOrEmpty(txtParent2NIC.Text))
                {
                    parent objparent2 = new parent(objstudent, Parent2Name, Parent2ContactNo, Parent2NIC, Parent2Email, Parent2Job);

                    string queryParent2 = "INSERT INTO guardian VALUES('"+Parent2NIC+"','" + Parent2Name + "','" + Parent2ContactNo + "','" + Parent2Email + "','" + Parent2Job + "')";
                    SqlCommand commandParent2 = new SqlCommand(queryParent2, conn);

                    string queryStudentParent2 = "INSERT INTO student_guardian values('" + StudentNIC + "','" + Parent2NIC + "')";
                    SqlCommand commandStudentParent2 = new SqlCommand(queryStudentParent2, conn);

                    try
                    {
                        conn.Open();
                        commandParent2.ExecuteNonQuery();
                        commandStudentParent2.ExecuteNonQuery();
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
}
