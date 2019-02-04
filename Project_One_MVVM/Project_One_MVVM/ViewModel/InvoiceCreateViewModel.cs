

using Project_One_MVVM.Command;
using Project_One_MVVM.Model;
using Project_One_MVVM.Utilities;
using Project_One_MVVM.View;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows.Input;
using Project_One_MVVM.Command;
using System;
using System.Windows.Data;
namespace Project_One_MVVM.ViewModel
{
    public class InvoiceCreateViewModel 
    {
        private ObservableCollection<Product> products = new ObservableCollection<Product>();
        ObservableCollection<int> prodCount = new ObservableCollection<int>();
        public ICommand AddProduct { get; private set; }
        public ICommand AddInvoice { get; private set; }
        /// <summary>
        /// Initializes a new instance of the EmployeeCreateView class.
        /// </summary>
        public InvoiceCreateViewModel(InvoiceCreateView view)
        {
            ObservableCollection<Employee> emplList = mySQLDatabase.ReadEmployee();
            view.Employee.DisplayMemberPath = "Surname";
            view.Employee.ItemsSource = emplList;

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
                    Product selectedProd = view.Product.SelectionBoxItem as Product;
                    selectedProd.ProductCount = Convert.ToInt32(view.Count.Text.ToString());
                    products.Add(view.Product.SelectionBoxItem as Product);
                    prodCount.Add(Convert.ToInt32(view.Count.Text.ToString()));

                    view.dataGrid.ItemsSource = products;
                }
                catch(Exception e){

                }
           });

           AddInvoice = new ReadCommand(obj =>
           {
                long listId = mySQLDatabase.AddProductsList(ProductList, prodCount);
                mySQLDatabase.AddInvoice((view.customer.SelectionBoxItem as Customer).CustomerId,
                    (view.Employee.SelectionBoxItem as Employee).Id,
                    listId,
                    Invoice.INVOICE);

           });
        }
    }
}