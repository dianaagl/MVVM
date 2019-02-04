using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_One_MVVM.Model
{
    class Customer: Person
    {
        public const string CUSTOMER = "Customer";
        public const string CUSTOMER_ID = "id";
        int customerId;

        public int CustomerId
        {
            get { return customerId; }
            set { customerId = value; }
        }

        public Customer(string surname, string forename, string dob, string address, string email, string phone, int customerId)
            :base(surname, forename,dob,address,email,phone)
        {
            this.customerId = customerId;
        }

    }
}
