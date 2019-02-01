using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_One_MVVM.Model
{
    class Customer
    {
        private string surname;
        private string forename;
        private string dob;
        private string address;
        private string email;
        private string phone;
        private string username;
        private string password;

        public Customer()
        {

        }

        public Customer(string surname, string forename, string dob, string address, string email, string phone, string username, string password)
        {
            this.Surname = surname;
            this.Forename = forename;
            this.Dob = dob;
            this.Address = address;
            this.Email = email;
            this.Phone = phone;
            this.Username = username;
            this.Password = password;
        }

        public string Surname { get { return surname; } private set { surname = value; } }
        public string Forename { get { return forename; } private set { forename = value; } }
        public string Dob { get { return dob; } private set { dob = value; } }
        public string Address { get { return address; } private set { address = value; } }
        public string Email { get { return email; } private set { email = value; } }
        public string Phone { get { return phone; } private set { phone = value; } }
        public string Username { get { return username; } private set { username = value; } }
        public string Password { get { return password; } private set { password = value; } }
    }
}
