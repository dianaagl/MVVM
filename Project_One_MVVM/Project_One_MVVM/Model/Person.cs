using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_One_MVVM.Model
{
    class Person : INotifyPropertyChanged
    {
        public const string SURNAME = "surname";
        public const string FORENAME = "forename";
        public const string DOB = "dob";
        public const string ADDRESS = "address";
        public const string EMAIL = "email";
        public const string PHONE = "phone";
        public event PropertyChangedEventHandler PropertyChanged;
        private string surname;

        public string Surname
        {
            get { return surname; }
            set { surname = value;
            OnPropertyChanged(Employee.SURNAME);
            }
        }
        private string forename;

        public string Forename
        {
            get { return forename; }
            set { forename = value;
            OnPropertyChanged(Employee.FORENAME);
            }
        }
        private string dob;

        public string Dob
        {
            get { return dob; }
            set { dob = value;
            OnPropertyChanged(Employee.DOB);
            }
        }
        private string address;

        public string Address
        {
            get { return address; }
            set { address = value;
            OnPropertyChanged(Employee.ADDRESS);
            }
        }
        private string email;

        public string Email
        {
            get { return email; }
            set { email = value;
            OnPropertyChanged(Employee.EMAIL);
            }
        }
        private string phone;

        public string Phone
        {
            get { return phone; }
            set { phone = value;
            OnPropertyChanged(Employee.PHONE);
            }
        }

        public Person(string surname, string forename, string dob, string address, string email, string phone)
        {
            this.Surname = surname;
            this.Forename = forename;
            this.Dob = dob;
            this.Address = address;
            this.Email = email;
            this.Phone = phone;

        }
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;

            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
