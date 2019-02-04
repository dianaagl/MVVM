

using Project_One_MVVM.Command;
using Project_One_MVVM.Model;
using Project_One_MVVM.Utilities;
using Project_One_MVVM.View;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows.Input;
using Project_One_MVVM.Command;
using System;
namespace Project_One_MVVM.ViewModel
{
    /// <summary>
    /// This class contains properties that a View can data bind to.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class EmployeeCreateViewModel 
    {
        private ObservableCollection<Product> products = new ObservableCollection<Product>();
        ObservableCollection<int> prodCount = new ObservableCollection<int>();
        public ICommand AddProduct { get; private set; }
        public ICommand AddInvoice { get; private set; }
        /// <summary>
        /// Initializes a new instance of the EmployeeCreateView class.
        /// </summary>
        public EmployeeCreateViewModel(EmployeeCreateView view)
        {
            bool _canExecuteMyCommand = false;
            ObservableCollection<Employee> emplList = mySQLDatabase.ReadEmployee();
            

///foreach(Employee empl in emplList)
           // {
               // ComboBoxItem item = new ComboBoxItem();
                          
            view.Employee.DisplayMemberPath = "Surname";
            //view.Employee.SelectedValuePath = "Value";
            view.Employee.ItemsSource = emplList;
                //view.Employee.Items.Add(empl.Surname);
            //}
            ObservableCollection<Customer> cusList = mySQLDatabase.ReadCustomers();
             view.customer.DisplayMemberPath = "Surname";
            view.customer.ItemsSource = cusList;
            
            ObservableCollection<Product> ProductList = mySQLDatabase.ReadProducts();
            view.Product.DisplayMemberPath = "ProductName";
            view.Product.ItemsSource = ProductList;
           AddProduct = new ReadCommand(obj =>
            {
                try{
                    //int c = Convert.ToInt32(view.Count.Text);
                    products.Add(view.Product.SelectionBoxItem as Product);
                    prodCount.Add(Convert.ToInt32( view.Count.Text.ToString()));
                }
                catch(Exception e){

                }
            }
                );

           AddInvoice = new ReadCommand(obj =>
           {
               try
               {
                   //int c = Convert.ToInt32(view.Count.Text);
                   long listId = mySQLDatabase.Add(ProductList, prodCount);
                   mySQLDatabase.Add((view.customer.SelectionBoxItem as Customer).CustomerId,
                       (view.Employee.SelectionBoxItem as Employee).Id,
                       listId,
                       Invoice.INVOICE);
                  
               }
               catch (Exception e)
               {

               }
           }
    );
        }
    }
}