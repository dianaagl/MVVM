using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_One_MVVM.Model
{
    class Employee : Customer
    {
        public Employee(string surname, string forename, string dob, string address, string email, string phone, string username, string password) : base(surname, forename, dob, address, email, phone, username, password)
        {

        }
    }
}
