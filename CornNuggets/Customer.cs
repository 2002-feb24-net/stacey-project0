using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CornNuggets;


namespace CornNuggets
{
    class Customer
    {
        public string CustName { get => custName; set => custName = value; }
        public int CustomerID { get; set; }
        public static List<string> Cust { get => cust; set => cust = value; }

        static List<string> cust = new List<string>() { "First Customer" };
        private string custName;
        SecretConfig code = new SecretConfig();

        public Customer()
        {
            CustomerID++;
        }

        public void AddCustomer(string firstName, string lastName, string storeName)
        {

            SqlConnection conn = new SqlConnection(code.GetConnString());
            
            SqlCommand cmd = new SqlCommand("dbo.spCustomers_AddNew", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter param1 =  new SqlParameter();
            SqlParameter param2 =  new SqlParameter();
            SqlParameter param3 =  new SqlParameter();
            param1 = cmd.Parameters.Add("@FirstName", SqlDbType.NVarChar, 50);
            param2 = cmd.Parameters.Add("@LastName",SqlDbType.NVarChar, 50);
            param3 = cmd.Parameters.Add("@PreferredStore",SqlDbType.NVarChar, 7);

            param1.Direction = ParameterDirection.Input;
            param2.Direction = ParameterDirection.Input;
            param3.Direction = ParameterDirection.Input;

            param1.Value = firstName;
            param2.Value = lastName;
            param3.Value = storeName;

            
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Console.Write(reader[0].ToString());
                Console.Write(" ");
                Console.Write(reader[1].ToString());
                Console.Write(" ");
                Console.WriteLine(reader[2].ToString());
            }
            //Console.Read();

            //Close reader and connection
            reader.Close();
            conn.Close();
        }
        public bool isCustomer(string name)
        {
            if (Cust.Contains(name))
            {
                //Console.WriteLine("Customer Found");
                return true;
            }
            else
            {
                //Console.WriteLine("No Match Found");
                return false;
            }
        }
        public void ViewOrderHistory()
        {
            SecretConfig connStr = new SecretConfig();
            using 
            (SqlDataAdapter sqlda = new SqlDataAdapter("dbo.spCustomers_DisplayOrdersByID", connStr.GetConnString()))
                {
                    DataTable dtbl = new DataTable();
                    sqlda.Fill(dtbl);
                    foreach(DataRow row in dtbl.Rows)
                    {
                    Console.Write(row["OrderID"]);
                    Console.Write("  ");
                    Console.Write(row["DateTimeStamp"]);
                    Console.Write("  ");
                    Console.Write(row["OrderID"]);
                    Console.Write("  ");
                    Console.Write(row["StoreID"]);
                    Console.Write("  ");
                    Console.Write(row["Total"]);
                    Console.WriteLine();
                    }
                    //Console.ReadKey();
                }
        

        }
        public void SearchCustomer(string fname, string lname)
        {
             SqlConnection conn = new SqlConnection(code.GetConnString());
            
            SqlCommand cmd = new SqlCommand($"select * customers", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter param1 =  new SqlParameter();
            SqlParameter param2 =  new SqlParameter();
            param1 = cmd.Parameters.Add("@FirstName", SqlDbType.NVarChar, 50);
            param2 = cmd.Parameters.Add("@LastName",SqlDbType.NVarChar, 50);

            param1.Direction = ParameterDirection.Input;
            param2.Direction = ParameterDirection.Input;

            param1.Value = fname;
            param2.Value = lname;

            
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Console.Write(reader[0].ToString());
                Console.Write(" ");
                Console.Write(reader[1].ToString());
                Console.Write(" ");
                Console.WriteLine(reader[2].ToString());
            }
            Console.Read();

            //Close reader and connection
            reader.Close();
            conn.Close();
        }
        /*public bool isCustomer(string name)
        {
            if (cust.Contains(name))
            {
                //Console.WriteLine("Customer Found");
                return true;
            }
            else
            {
                //Console.WriteLine("No Match Found");
                return false;
            }
            using 
            (SqlDataAdapter sqlda = new SqlDataAdapter("dbo.spCustomer_GetByFullName", code.GetConnString()))
                {
                    DataTable dtbl = new DataTable();
                    sqlda.Fill(dtbl);
                    foreach(DataRow row in dtbl.Rows)
                    {
                    //Console.Write(row["Preferred Store"]);
                   // Console.Write("  ");
                    Console.Write(row["FirstName"]);
                    Console.Write("  ");
                    Console.Write(row["LastName"]);
                    Console.WriteLine();

                    }
                    //Console.ReadKey();
                }
            }*/
         public void ShowAllCustomers()
        {
            using 
            (SqlDataAdapter sqlda = new SqlDataAdapter("select * from Customers", code.GetConnString()))
                {
                    DataTable dtbl = new DataTable();
                    sqlda.Fill(dtbl);
                    foreach(DataRow row in dtbl.Rows)
                    {
                    Console.Write(row["PreferredStore"]);
                    Console.Write("  ");
                    Console.Write(row["FirstName"]);
                    Console.Write("  ");
                    Console.Write(row["LastName"]);
                    Console.WriteLine();

                    }
                    //Console.ReadKey();
                }
        }
    }
}
