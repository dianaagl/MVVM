using Project_One_MVVM.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Project_One_MVVM.Utilities
{
    class Database
    {
        private static string connectionString = @"Data Source=THIS-PC\SQLEXPRESS;User ID=sa;Password=12345;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        SqlConnection cnn = new SqlConnection(connectionString);
        Employee employee;

        public Database() { }

        public void Connect()
        {
            cnn.Open();
        }

        public void Disconnect()
        {
            cnn.Close();
        }

        public bool Login(string username, string password)
        {
            using (cnn)
            {
                SqlCommand command = new SqlCommand("USE [MVVMDatabase] SELECT * FROM dbo.employee", cnn);
                cnn.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        // Do not delete the code below
                        // Console.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}\t{5}\t{6}\t{7}", reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetString(5), reader.GetString(6), reader.GetString(7), reader.GetString(8));

                        if (username == reader.GetString(7) && password == reader.GetString(8))
                        {
                            return true;
                        }                      
                    }
                }
                else
                {
                    Console.WriteLine("No rows found.");
                }
                reader.Close();
            }
            return false;
        }

        public void CreateEmployee()
        {

        }

        public List<Employee> ReadEmployee(List<Employee> employeeList)
        {
            using (cnn)
            {
                SqlCommand command = new SqlCommand("USE [MVVMDatabase] SELECT * FROM dbo.employee", cnn);
                cnn.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        // Console.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}\t{5}\t{6}\t{7}", reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetString(5), reader.GetString(6), reader.GetString(7), reader.GetString(8));

                        employee = new Employee(reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetString(5), reader.GetString(6), reader.GetString(7), reader.GetString(8));
                        employeeList.Add(employee);
                    }
                }
                else
                {
                    Console.WriteLine("No rows found.");
                }
                reader.Close();
            }
            return employeeList;
        }       
    }
}
