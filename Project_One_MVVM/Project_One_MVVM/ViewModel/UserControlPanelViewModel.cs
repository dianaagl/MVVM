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
using MySql.Data.MySqlClient;
using System.Windows;
using System.Collections.ObjectModel;
using System.Data;

namespace Project_One_MVVM.ViewModel
{
    class UserControlPanelViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private UserControlPanel userControlPanel;
        public ICommand ReadCustomers{get; private set;}
        private string editTableName;

        private ObservableCollection<Employee> employeeList = new ObservableCollection<Employee>();
        private ObservableCollection<Product> productList = new ObservableCollection<Product>();
        private ObservableCollection<Customer> customerList = new ObservableCollection<Customer>();
        public ICommand ReadEmployees { get; private set; }
        public ICommand ReadProducts { get; private set; } 
        public ICommand ReadInvoices { get; private set; }
        public ICommand Create { get; private set; }
        public ICommand AddCommand { get; private set; }

        public UserControlPanelViewModel(UserControlPanel userControlPanel)
        {

            userControlPanel.dataGrid.CellEditEnding += dataGrid_RowEditEnding;
            ReadEmployees =  new ReadCommand(obj =>
                  {
                      editTableName = Employee.EMPLOYEE;
                    this.Read();
                  },this);
            ReadProducts =  new ReadCommand(obj =>
                  {
                      editTableName = Product.PRODUCT;
                     this.Read();
                  }, this);
            ReadCustomers = new ReadCommand(obj =>
                {
                    editTableName = Customer.CUSTOMER;
                    this.Read();
                }, this);
            ReadInvoices = new ReadCommand(obj =>
            {
                editTableName = Invoice.INVOICE;
                this.Read();
            }, this);

            AddCommand = new ReadCommand(obj =>
            {
                switch (editTableName)
                {
                    case Customer.CUSTOMER:
                        mySQLDatabase.Add(Customer.CUSTOMER_ID, Customer.CUSTOMER);
                        mySQLDatabase.ReadCustomers();
                        break;
                    case Employee.EMPLOYEE:
                        mySQLDatabase.Add(Employee.ID, Employee.EMPLOYEE);
                        mySQLDatabase.ReadEmployee();
                        break;
                    case Product.PRODUCT:
                        mySQLDatabase.Add(Product.PRODUCT_ID, Product.PRODUCT);
                        mySQLDatabase.ReadProducts();
                        break;
                }
              
            }, this);
            this.userControlPanel = userControlPanel;
            Create = new ReadCommand(obj =>
                {
                    EmployeeCreateView frm = new EmployeeCreateView();
                    frm.Show();
                }, this
                );
        }
        private void setColumns(List<string> columnNames)
        {
            userControlPanel.dataGrid.Columns.Clear();
            foreach(string columnName in columnNames){
                DataGridTextColumn col = new DataGridTextColumn();
                col.Header = columnName;
                col.Width = 110;
                col.Binding = new Binding(col.Header + " UpdateSourceTrigger = PropertyChanged"); 
                userControlPanel.dataGrid.Columns.Add(col);
            }
        }
        public void Read()
        {
            switch (editTableName)
            {
                case Employee.EMPLOYEE:
                    employeeList = mySQLDatabase.ReadEmployee();
                    userControlPanel.dataGrid.ItemsSource = employeeList;
                    break;
                case Customer.CUSTOMER:
                    customerList = mySQLDatabase.ReadCustomers();
                    userControlPanel.dataGrid.ItemsSource = customerList;
                    break;
                case Product.PRODUCT:
                    productList = mySQLDatabase.ReadProducts();
                    userControlPanel.dataGrid.ItemsSource = productList;
                    break;
                case Invoice.INVOICE:
                    ObservableCollection<Invoice> InvoiceList = mySQLDatabase.ReadInvoices();
                    DataGridTemplateColumn col = new DataGridTemplateColumn();// col = new DataGridTextColumn();
                    userControlPanel.dataGrid.ItemsSource = InvoiceList;
                    break;
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
        private void dataGrid_RowEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            DataGrid dc = (DataGrid)sender;
            DataGridRow row1 = e.Row;
            string header = (string)e.Column.Header;
            int id = 0;
            string idN = "id";
            switch (editTableName){
                    
                case Employee.EMPLOYEE:
                    Employee rowE = dc.SelectedItems[0] as Employee;
                     id = rowE.Id;
                    break;
                case Customer.CUSTOMER:
                    Customer rowC = dc.SelectedItems[0] as Customer;
                    id = rowC.CustomerId;
                    break;
                case Product.PRODUCT:
                    Product rowP = dc.SelectedItems[0] as Product;
                    id = rowP.ProductId;
                    idN = Product.PRODUCT_ID;
                    break;
            }
                
           
            TextBox value = e.EditingElement as TextBox;
            mySQLDatabase.UpdateField(header, value.Text, id, editTableName, idN);
            
        }
    }
}
