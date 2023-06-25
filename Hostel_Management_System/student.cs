using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hostel_Management_System
{
    internal class student
    {
        public string StudentFName
        {
            get; set;
        }
        public string StudentLName
        {
            get;set;
        }
        public DateTime StudentBirthday
        {
            get; set;
        }
        public string StudentNIC
        {
            get; set;
        }
        public char StudentGender
        {
            get; set;
        }
        public double StudentBatch
        {
            get; set;
        }
        public string StudentEmail
        {
            get; set;
        }
        public string StudentPhone
        {
            get; set;
        }
        public string StudentAddress
        {
            get; set;
        }
        public string StudentHomePhone
        {
            get; set;
        }
        public DateTime StudentRegisterDate
        {
            get; set;
        }
        public int StudentKeyMoney
        {
            get; set;
        }

        public student
            (string Fname,
            string Lname,
            DateTime birthday,
            string NIC,
            char gender,
            double batch,
            string email,
            string phone,
            string address,
            string homePhone,
            DateTime registerDate,
            int keyMoney)
        {
            this.StudentFName = Fname;
            this.StudentLName = Lname;
            this.StudentBirthday = birthday;
            this.StudentNIC = NIC;
            this.StudentGender = gender;
            this.StudentBatch = batch;
            this.StudentEmail = email;
            this.StudentPhone = phone;
            this.StudentAddress = address;
            this.StudentHomePhone = homePhone;
            this.StudentRegisterDate = registerDate;
            this.StudentKeyMoney = keyMoney;
        }

        public override string ToString()
        {
            return this.StudentNIC;
        }
    }
}
