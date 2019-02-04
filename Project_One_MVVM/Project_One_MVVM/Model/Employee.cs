using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_One_MVVM.Model
{

    class Employee : Person 
    {
        public const  string EMPLOYEE = "Employee";
        public const string USER_NAME = "username";
        public const string PASSWORD = "password";
        public const string ID = "id";
        int id;
        
        public int Id
        {
            get { return id; }
            set { id = value;
            OnPropertyChanged(Employee.ID);
            }
        }
        string username;
        string password;

        public string Password
        {
            get { return password; }
            set { password = value;
            OnPropertyChanged(Employee.PASSWORD);
            }
        }
        public string Username
        {
            get { return username; }
            set { username = value;
            OnPropertyChanged(Employee.USER_NAME);
            }
        }
        public Employee(string surname, string forename, string dob, string address, string email, string phone, string username, string password, int id) 
            : base(surname, forename, dob, address, email, phone)
        {
            this.id = id;
            this.username = username;
            this.password = password;
        }
       
    }
}
