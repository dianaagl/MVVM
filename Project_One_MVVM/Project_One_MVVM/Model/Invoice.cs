using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_One_MVVM.Model
{
    class Invoice
    {
        public const string INVOICE = "Invoice";
        public const string ID = "id";
        public const string CUSTOMER_ID = "customerId";
        public const string EMPLOYEE_ID = "employeeId";
        public const string PRODUCT_LIST_ID = "productListId";
        private int id;
        private string employeeName;
        private string customerName;
        private string order;
        private ObservableCollection<Product> productList;
        public string Order
        {
            get { return order; }
            set { order = value; }
        }
       

        public Invoice(int id, string empName, string cusName)
        {
            this.id = id;
            this.employeeName = empName;
            this.customerName = cusName;
        }
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public string CustomerName
        {
            get { return customerName; }
            set { customerName = value; }
        }
        public string EmployeeName
        {
            get { return employeeName; }
            set { employeeName = value; }
        }
        internal ObservableCollection<Product> ProductList
        {
            get { return productList; }
            set { productList = value; }
        }

    }
}
