using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using MySql.Data.MySqlClient;
using Project_One_MVVM.Model;
using System.Collections.ObjectModel;

namespace Project_One_MVVM.Utilities
{
    static class mySQLDatabase
    {
        static MySqlConnection conn;
        // = "SERVER=sql7.freemysqlhosting.net;PORT=3306;DATABASE=sql7276935;UID=sql7276935;PASSWORD=AZakbfz1JY;";

        static private string databseHost = "sql7.freemysqlhosting.net";
        static private string databaseName = "sql7276935";
        static private string databseUserName = "sql7276935";
        static private string databasePassword = "AZakbfz1JY";
        static private int databasePort = 3306;

        /* 
         * Server: sql7.freemysqlhosting.net 
         * Name: sql7276935
         * Username: sql7276935
         * Password: AZakbfz1JY
         * Port number: 3306 
         */
        static mySQLDatabase()
        {
            conn = new MySqlConnection();
            conn.ConnectionString = String.Format("SERVER={0};PORT={1};DATABASE={2};UID={3};PASSWORD={4};", databseHost, databasePort, databaseName, databseUserName, databasePassword);

        }
        public static void Connect()
        {
            
            try
            {
                conn.Open();
                MessageBox.Show("Connection was successful!");
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
        public static void CloseConnection()
        {
            conn.Close();
        }

        public static bool Login(string username, string password)
        {
            try
            {
                conn.Open();

                string query = "SELECT * FROM Employee";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataReader dataReader = cmd.ExecuteReader();

                while (dataReader.Read())
                {
                    Console.WriteLine(dataReader["username"]);
                    Console.WriteLine(dataReader["password"]);

                    if (username == Convert.ToString(dataReader["username"]) && password == Convert.ToString(dataReader["password"]))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                    
                }
                return false;
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return false;
        }

        public static ObservableCollection<Employee> ReadEmployee()
        {
            ObservableCollection<Employee> myList = new ObservableCollection<Employee>();
            try
            {
                conn.Open();

                string query = "SELECT * FROM Employee";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataReader dataReader = cmd.ExecuteReader();

                while (dataReader.Read())
                {
                    myList.Add(new Employee(
                        Convert.ToString(dataReader[Employee.SURNAME]),
                        Convert.ToString(dataReader[Employee.FORENAME]),
                        Convert.ToString(dataReader[Employee.DOB]),
                        Convert.ToString(dataReader[Employee.ADDRESS]),
                        Convert.ToString(dataReader[Employee.EMAIL]),
                        Convert.ToString(dataReader[Employee.PHONE]),
                        Convert.ToString(dataReader[Employee.USER_NAME]), 
                        Convert.ToString(dataReader[Employee.PASSWORD]),
                        Convert.ToInt32(dataReader[Employee.ID])));
                }
                
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return myList;
        }
    
        public static ObservableCollection<Product> ReadProducts()
        {
            ObservableCollection<Product> myList = new ObservableCollection<Product>();
            try
            {
                conn.Open();

                string query = "SELECT * FROM Product";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataReader dataReader = cmd.ExecuteReader();

                while (dataReader.Read())
                {
                    myList.Add(new Product(
                        Convert.ToInt32(dataReader[Product.PRODUCT_ID]),
                        Convert.ToString(dataReader[Product.PRODUCT_NAME]),                     
                        Convert.ToString(dataReader[Product.MEASURE]),
                        Convert.ToInt32(dataReader[Product.PRODUCT_COUNT])
                        ));
                }
                
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return myList;
        }
    
    public static ObservableCollection<Customer> ReadCustomers()
        {
            ObservableCollection<Customer> myList = new ObservableCollection<Customer>();
            try
            {
                conn.Open();

                string query = "SELECT * FROM Customer";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataReader dataReader = cmd.ExecuteReader();

                while (dataReader.Read())
                { 
                    myList.Add(new Customer(
                        
                        Convert.ToString(dataReader[Customer.SURNAME]),
                        Convert.ToString(dataReader[Customer.FORENAME]),
                        Convert.ToString(dataReader[Customer.DOB]),
                        Convert.ToString(dataReader[Customer.ADDRESS]),
                        Convert.ToString(dataReader[Customer.EMAIL]),
                        Convert.ToString(dataReader[Customer.PHONE]),
                        Convert.ToInt32(dataReader[Customer.CUSTOMER_ID])
                        
                  ));
                }
                
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return myList;
        }

    public static ObservableCollection<Invoice> ReadInvoices()
    {
        ObservableCollection<Invoice> myList = new ObservableCollection<Invoice>();
        try
        {
            conn.Open();

            string query = String.Format(
                "SELECT inv.{0} , cus.{1} as {9}, cus.{2} as {10}, emp.{3}, emp.{4}, inv.{11} " + 
                " FROM Invoice inv INNER JOIN Customer cus on cus.{5} = inv.{6}" +
                " INNER JOIN Employee emp on emp.{7} = inv.{8}", 
                Invoice.ID, Customer.SURNAME, Customer.FORENAME, Employee.SURNAME, Employee.FORENAME,
                Customer.CUSTOMER_ID, Invoice.CUSTOMER_ID,
                Employee.ID, Invoice.EMPLOYEE_ID,
                "cusName", "cusLastName", Invoice.PRODUCT_LIST_ID);
                         

            MySqlCommand cmd = new MySqlCommand(query, conn);
            MySqlDataReader dataReader = cmd.ExecuteReader();
            ObservableCollection<int> prodListIds = new ObservableCollection<int>();

            while (dataReader.Read())
            {

                myList.Add(new Invoice(
                    Convert.ToInt32(dataReader[Invoice.ID]),

                    Convert.ToString(dataReader["cusName"]) +
                    Convert.ToString(dataReader[ "cusLastName"]),
                    Convert.ToString(dataReader[Employee.SURNAME]) +
                    Convert.ToString(dataReader[Employee.FORENAME])                    )

              );
                prodListIds.Add(Convert.ToInt32(dataReader[Invoice.PRODUCT_LIST_ID]));
                
            }

            conn.Close();
            
            //SELECT Product.productName  FROM Product INNER JOIN ProductsList on ProductsList.productId = 
//Product.productId WHERE  ProductsList.id = 1
            int k = 0;
            foreach (int prodLI in prodListIds)
            {
                conn.Open();
                query = String.Format("SELECT * FROM Product INNER JOIN ProductsList on ProductsList.{1} = Product.{2} where ProductsList.id = {3}",
               Product.PRODUCT_NAME, "productId", "productId", prodLI);
                MySqlCommand cmd2 = new MySqlCommand(query, conn);
                MySqlDataReader dataReader2 = cmd2.ExecuteReader();
                ObservableCollection<Product> prod = new ObservableCollection<Product>();
                string orderList = "";
                while (dataReader2.Read())
                {
                    prod.Add(new Product(Convert.ToInt32(dataReader2[Product.PRODUCT_ID]),
                        Convert.ToString(dataReader2[Product.PRODUCT_NAME]), 0, ""));
                    orderList += Convert.ToString(dataReader2[Product.PRODUCT_NAME]) + " " + 
                        Convert.ToString(dataReader2[Product.PRODUCT_COUNT]) + 
                        Convert.ToString(dataReader2[Product.MEASURE]) +"\n";
                }

                    myList[k].Order = orderList;
                    k++;

                    conn.Close();
            }
            
           

        }
        catch (MySql.Data.MySqlClient.MySqlException ex)
        {
            MessageBox.Show(ex.Message);
        }
        finally
        {
            conn.Close();
        }
        return myList;
    }
    public static void UpdateField(string fieldName, string value, int id, string tableName, string idN)
    {
        try
        {
            conn.Open();
            string comText = String.Format(
                "UPDATE {3} SET {0} = '{1}' WHERE {4} = {2}", fieldName, value, id, tableName,idN);

            MySqlCommand cmd = new MySqlCommand(comText, conn);
            //connection.Open();
            //SqlCommand command = new SqlCommand(sqlExpression, connection);
          
           
            
            
            int numRowsUpdated = cmd.ExecuteNonQuery(); 

        }
        catch(MySqlException e){
            MessageBox.Show(e.Message);
        }
        finally{
            conn.Close();
        }
    }
    public static void Add(string id, string tableName)
    {
        try
        {
            conn.Open();
            string comText = String.Format(
                "INSERT INTO {0} ({1})" +
                    "VALUES ( NULL )" , tableName, id);

            MySqlCommand cmd = new MySqlCommand(comText, conn);
            int numRowsUpdated = cmd.ExecuteNonQuery();

        }
        catch (Exception e)
        {

        }
        finally
        {
            conn.Close();
        }
    }
    public static long Add(ObservableCollection<Product> products, ObservableCollection<int> prodNumber)
    {
        long id = -1;
        try
        {
            conn.Open();

            string comText = 
                "SELECT ID FROM ProductsList";

            MySqlCommand cmd = new MySqlCommand(comText, conn);
            MySqlDataReader dataReader = cmd.ExecuteReader();
            ObservableCollection<long> prodListIds = new ObservableCollection<long>();

            while (dataReader.Read())
            {

                prodListIds.Add(
                    Convert.ToInt64(dataReader["id"])

              );
            }
            id = prodListIds.Max();
            id ++;
            conn.Close();
            for (int i = 0; i < prodNumber.Count; i++)
            {
                conn.Open();
                string comText2 = String.Format(
                            "INSERT INTO {0} (id , productId , productCount)" +
                            "VALUES ( {1}, {2}, {3} )", "ProductsList",
                            id, products[i].ProductId, prodNumber[i]);

                MySqlCommand cmd2 = new MySqlCommand(comText2, conn);
                cmd2.ExecuteNonQuery();
                conn.Close();
            }
           

        }
        catch (Exception e)
        {

        }
        finally
        {
            conn.Close();
        }
        return id;
    }
    public static void Add( int customerId,int employeeId, long prodListId, string tableName)
    {

        try
        {
            conn.Open();
            string comText = String.Format(
                "INSERT INTO {0} ( id, customerId , productListId)" +
                    "VALUES (NULL ,  {1}, {2} )", tableName,customerId, prodListId);

            MySqlCommand cmd = new MySqlCommand(comText, conn);
            int numRowsUpdated = cmd.ExecuteNonQuery();

        }
        catch (Exception e)
        {

        }
        finally
        {
            conn.Close();
        }
    }
            
    }
}
