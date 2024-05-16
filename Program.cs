using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Globalization;
using System.ComponentModel.DataAnnotations;
using System.Transactions;


namespace Practice
{
    class Program
    {
        /// <summary>
        /// This method will be used to run ExecuteReader() method and other
        /// </summary>
        /// <returns>Null</returns>
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
                        #region ExecuteReader

                        //string query = "SelectAllCities";
                        //SqlCommand cmd = new SqlCommand();
                        //cmd.CommandText = query;
                        //cmd.Connection = conn;
                        //cmd.CommandType = CommandType.StoredProcedure;
                        //var results = cmd.ExecuteReader();
                        //while (results.Read())
                        //{
                        //    Console.WriteLine("ID" +" |" + results[0] +"| Name |" + results[1] + " " + results[2]);
                        //}
                        #endregion

                        #region ExecuteNonQuery
                        #region InsertingData
                        //SqlCommand command = new SqlCommand();
                        //command.Connection = conn;
                        //Console.WriteLine("Enter ID:");
                        //int ID = Convert.ToInt32(Console.ReadLine());
                        //Console.WriteLine("\nEnter First Name:");
                        //string fname = Console.ReadLine();
                        //Console.WriteLine("\nEnter Last Name:");
                        //string lname = Console.ReadLine();
                        //Console.WriteLine("\nEnter Address Name:");
                        //string address = Console.ReadLine();
                        //Console.WriteLine("\nEnter City Name:");
                        //string city = Console.ReadLine();
                        //string query = "INSERT INTO dbo.PRSN VALUES(@id, @firstName, @lastName, @address, @city)";
                        //command.CommandText = query;
                        //command.Parameters.AddWithValue("@id",ID);
                        //command.Parameters.AddWithValue("@firstName",fname);
                        //command.Parameters.AddWithValue("@lastName",lname);
                        //command.Parameters.AddWithValue("@address",address);
                        //command.Parameters.AddWithValue("@city",city);
                        //int number = command.ExecuteNonQuery();
                        //if(number>0)
                        //{
                        //    Console.WriteLine(number +" rows are affected");
                        //}
                        //else
                        //{
                        //    Console.WriteLine("Try Again");
                        //}
                        #endregion
                        #region UpdatingData
                        //SqlCommand cmd = new SqlCommand();
                        //cmd.Connection = conn;
                        //Console.WriteLine("Enter FirstName: ");
                        //string name = Console.ReadLine();
                        //Console.WriteLine("Enter ID:");
                        //int ID = Convert.ToInt32(Console.ReadLine());
                        //string query = "Update PRSN Set FirstName = @name where PersonID = @ID";
                        //cmd.CommandText = query;
                        //cmd.Parameters.AddWithValue("@name",name);
                        //cmd.Parameters.AddWithValue("@ID",ID);
                        //cmd.CommandType = CommandType.Text;
                        //int num = cmd.ExecuteNonQuery();
                        //if(num>0)
                        //{
                        //    Console.WriteLine(num + " rows affected");
                        //}
                        //else
                        //{
                        //    Console.WriteLine("Try Again");
                        //}
                        #endregion
                        #region DeletingData
                        //SqlCommand cmd = new SqlCommand();
                        //cmd.Connection = conn;
                        //cmd.CommandType = CommandType.Text;
                        //Console.WriteLine("Enter ID number:");
                        //string id =Console.ReadLine();
                        //string query = "Delete from PRSN where PersonID = @ID";
                        //cmd.Parameters.Add(
                        //    new SqlParameter("@ID", id)
                        //    );
                        //cmd.CommandText = query;
                        //int num = cmd.ExecuteNonQuery();
                        //if (num > 0)
                        //{
                        //    Console.WriteLine(num + "rows affected");
                        //}
                        //else
                        //{
                        //    Console.WriteLine("Try Again");
                        //}
                        #endregion
                        #endregion

                        #region ExecuteScalar
                        //SqlCommand con = new SqlCommand();
                        //con.Connection = conn;
                        //string query = "select max(PersonID) from PRSN";
                        //con.CommandText = query;
                        //var max = con.ExecuteScalar();
                        //Console.WriteLine(max.GetType());
                        //Console.WriteLine(max);
                        #endregion

                        #region ExecuteReader
                        SqlCommand sqlCommand = new SqlCommand();
                        sqlCommand.Connection = conn;
                        string query = "select * from PRSN";
                        sqlCommand.CommandText = query;
                        SqlDataReader reader = sqlCommand.ExecuteReader();
                        while(reader.Read())
                        {
                            Console.WriteLine("ID" + " |" + reader["PersonID"] + "| Name |" + reader["FirstName"] + " " + reader["LastName"]);
                        }
                        #endregion

                        
                        
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
        /// <summary>
        /// This method is for DataAdapter tutorial's practice
        /// </summary>
        /// <returns>Null</returns>
        static void DataAdapter()
        {
            string cs = ConfigurationManager.ConnectionStrings["BusinessDB"].ConnectionString;
            SqlConnection con = new SqlConnection(cs);
            #region Simple Query Data Fetching
            //SqlDataAdapter sqlData = new SqlDataAdapter("select * from PRSN",cs);
            //DataSet dataSet = new DataSet();
            //sqlData.Fill(dataSet);
            //foreach (DataRow item in dataSet.Tables[0].Rows)
            //{
            //    Console.WriteLine(item[1]);
            //}
            #endregion
            #region Store Procedure
            //Console.WriteLine("Enter City Name:");
            //string city = Console.ReadLine();
            //Console.Beep();
            //SqlDataAdapter dataAdapter = new SqlDataAdapter();
            //dataAdapter.SelectCommand = new SqlCommand("SelectCity", con);
            //dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            //dataAdapter.SelectCommand.Parameters.AddWithValue("@City",city);
            //DataSet dataSet = new DataSet();
            //dataAdapter.Fill(dataSet);
            //foreach (DataRow item in dataSet.Tables[0].Rows)
            //{
            //    Console.WriteLine(item["PersonID"]);
            //}
            #endregion
            #region ADO.NET Data Table
            //try
            //{
            //    DataTable dataTable = new DataTable("employees");
            //    DataColumn dataColumn = new DataColumn("id");
            //    dataColumn.ColumnName = "ID";
            //    dataColumn.Caption = "ID";
            //    dataColumn.AutoIncrement = true;
            //    dataColumn.AutoIncrementSeed = 1;
            //    dataColumn.AutoIncrementStep = 1;
            //    dataColumn.AllowDBNull = false;
            //    dataColumn.Unique = true;
            //    dataColumn.DataType = typeof(int);
            //    dataTable.Columns.Add(dataColumn);

            //    DataColumn dataColumn2 = new DataColumn("name");
            //    dataColumn2.ColumnName = "Name";
            //    dataColumn2.DefaultValue = null;
            //    dataColumn2.Caption = "Name";
            //    dataColumn2.AllowDBNull = false;
            //    dataColumn2.DataType = typeof(string);
            //    dataTable.Columns.Add(dataColumn2);

            //    DataRow dataRow = dataTable.NewRow();
            //    dataRow["id"] = 1;
            //    dataRow["name"] = "Ali";
            //    dataTable.Rows.Add(dataRow);
            //    dataTable.Rows.Add(2,"Arbab");
            //    dataTable.Rows.Add(3,"Hamza");
            //    dataTable.Rows.Add(4,"Adil");

            //    dataTable.PrimaryKey = new DataColumn[] { dataColumn };


            //    foreach (DataRow item in dataTable.Rows)
            //    {
            //        Console.WriteLine("ID: " + item["ID"] + " Name: " + item["name"]);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    throw ex;
            //}
            #endregion
            #region DataSet
            string query = "SelectAllCities";
            SqlDataAdapter dataAdapter = new SqlDataAdapter(query,con);
            dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataSet dataSet = new DataSet();
            dataAdapter.Fill(dataSet);
            foreach (DataRow item in dataSet.Tables["."].Rows)
            {
                Console.WriteLine(item[0]);
            }
            #endregion

        }
        public static void Main(string[] args)
        {
            //Connection();
            DataAdapter();
        }
    }
}