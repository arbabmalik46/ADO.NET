using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


namespace Practice
{
    class Program
    {
        static void Connection()
        {
            //string cs = "Data Source=DESKTOP-7UIKS3S\\SQLEXPRESS;Initial Catalog = Bsiness; Integrated Security = true";
            string cs = ConfigurationManager.ConnectionStrings["BusinessDB"].ConnectionString;
            SqlConnection conn = null;
            try
            {
                using (conn = new SqlConnection(cs))
                {
                    conn.Open();

                    if (conn.State == ConnectionState.Open)
                    {
                        Console.WriteLine("Connection has been successfully established");
                    }
                    else
                    {
                        Console.WriteLine("Try Again!");
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                conn.Close();
            }
        }
        public static void Main(string[] args)
        {
            Connection();
            Console.WriteLine("Hello World");
        }
    }
}