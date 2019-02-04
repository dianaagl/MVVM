using Project_One_MVVM.Commands;
using Project_One_MVVM.Model;
using Project_One_MVVM.Utilities;
using Project_One_MVVM.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Project_One_MVVM.ViewModel
{
    class LoginViewModel : INotifyPropertyChanged
    {
        private Employee _Employee;
        private string username;
        private string password;
        MainWindow parentWindow;

        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand LoginCommand { get; private set; }
        public ICommand ClearCommand { get; private set; }
        

        public string UsernameTextbox {
            get
            {
                return username;
            }
            set
            {
                username = value;
                OnPropertyChanged("UsernameTextbox");
            }
        }
        public string PasswordTextBox
        {
            get
            {
                return password;
            }
            set
            {
                password = value;
                OnPropertyChanged("PasswordTextBox");
            }
        }

        public Employee GetEmployee { get { return _Employee; } }


        public LoginViewModel(MainWindow window)
        {
            parentWindow = window;
            //_Employee = new Employee("Heathcote", "Joshua", "07/08/1987", "15 Milldale Avenue", "JoshuaHeathcote1987@gmail.com", "01298 79867", "admin", "12345");
            LoginCommand = new LoginCommand(this);
            ClearCommand = new ClearCommand(this);

        }

        public void Login()
        {
            

            if (mySQLDatabase.Login(username, password)) {
                if (username.Equals("admin"))
                {
                    ((App)Application.Current).User = App.ADMIN;
                }
                else ((App)Application.Current).User = App.EMPLOYEE;

                UserControlPanel frm = new UserControlPanel();
                frm.Show();
                parentWindow.Hide();
            }
            else
            {
                MessageBox.Show("Error: Wrong Username and Password!");
            }
        }

        public void Clear()
        {
            UsernameTextbox = "";
            PasswordTextBox = "";
            OnPropertyChanged("UserNameTextBox");
            OnPropertyChanged("PasswordTextBox");
        }
       

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;

            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

    }
}
