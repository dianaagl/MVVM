using Project_One_MVVM.Model;
using Project_One_MVVM.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Project_One_MVVM.Command;
using Project_One_MVVM.View;
using System.Windows.Controls;
using System.Windows.Data;

namespace Project_One_MVVM.ViewModel
{
    class UserControlPanelViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private Database db;
        private UserControlPanel userControlPanel;
        

        private List<Employee> employeeList = new List<Employee>();

        public ICommand Read { get; private set; }
        public ICommand Create { get; private set; }

        public UserControlPanelViewModel(UserControlPanel userControlPanel)
        {
            Read = new UCPEmployeeRead(this);
            this.userControlPanel = userControlPanel;
        }

        public void ReadEmployee()
        {
            db = new Database();
            employeeList = db.ReadEmployee(employeeList);

            DataGridTextColumn c1 = new DataGridTextColumn();
            c1.Header = "Surname";
            c1.Binding = new Binding("Surname");
            c1.Width = 110;
            userControlPanel.dataGrid.Columns.Add(c1);

            DataGridTextColumn c2 = new DataGridTextColumn();
            c2.Header = "Forename";
            c2.Width = 110;
            c2.Binding = new Binding("Forename");
            userControlPanel.dataGrid.Columns.Add(c2);

            DataGridTextColumn c3 = new DataGridTextColumn();
            c3.Header = "DOB";
            c3.Width = 110;
            c3.Binding = new Binding("DOB");
            userControlPanel.dataGrid.Columns.Add(c3);

            DataGridTextColumn c4 = new DataGridTextColumn();
            c4.Header = "Address";
            c4.Width = 110;
            c4.Binding = new Binding("Address");
            userControlPanel.dataGrid.Columns.Add(c4);

            DataGridTextColumn c5 = new DataGridTextColumn();
            c5.Header = "Email";
            c5.Width = 110;
            c5.Binding = new Binding("Email");
            userControlPanel.dataGrid.Columns.Add(c5);

            DataGridTextColumn c6 = new DataGridTextColumn();
            c6.Header = "Phone";
            c6.Width = 110;
            c6.Binding = new Binding("Phone");
            userControlPanel.dataGrid.Columns.Add(c6);

            foreach (Employee employee in employeeList)
            {
                //Console.WriteLine(employee.Surname + " " + employee.Forename + " " + employee.Dob + " " + employee.Address + " " + employee.Email + " " + employee.Phone);
                userControlPanel.dataGrid.Items.Add(new Employee(employee.Surname, employee.Forename, employee.Dob, employee.Address, employee.Email, employee.Phone, employee.Username, employee.Password));
            }
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
