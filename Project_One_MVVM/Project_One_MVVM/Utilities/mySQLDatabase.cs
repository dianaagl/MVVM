using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using MySql.Data.MySqlClient;

namespace Project_One_MVVM.Utilities
{
    class mySQLDatabase
    {
        MySqlConnection conn;
        string connString = "SERVER=sql7.freemysqlhosting.net;PORT=3306;DATABASE=sql7276935;UID=sql7276935;PASSWORD=AZakbfz1JY;";

        private string databseHost = "sql7.freemysqlhosting.net";
        private string databaseName = "sql7276935";
        private string databseUserName = "sql7276935";
        private string databasePassword = "AZakbfz1JY";
        private int databasePort = 3306;

        /* 
         * Server: sql7.freemysqlhosting.net 
         * Name: sql7276935
         * Username: sql7276935
         * Password: AZakbfz1JY
         * Port number: 3306 
         */

        public void Connect()
        {
            
            try
            {
                conn = new MySqlConnection();
                conn.ConnectionString = connString;
                conn.Open();
                MessageBox.Show("Connection was successful!");
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            conn.Close();
        }

        public bool Login(string username, string password)
        {
            try
            {
                conn = new MySqlConnection();
                conn.ConnectionString = connString;
                conn.Open();

                string query = "SELECT * FROM Employee";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataReader dataReader = cmd.ExecuteReader();

                while (dataReader.Read())
                {
                    Console.WriteLine(dataReader["username"]);
                    Console.WriteLine(dataReader["Password"]);

                    if (username == Convert.ToString(dataReader["username"]) && password == Convert.ToString(dataReader["password"]))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                    
                }
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            return false;
        }

        /*
        public List<Employee> ReadEmployee(List<Employee> employeeList)
        {
            conn = new MySqlConnection();
            conn.ConnectionString = connString;
            conn.Open();

            string query = "SELECT * FROM Employee";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            MySqlDataReader dataReader = cmd.ExecuteReader();
        }

    */

    }
}
