using System;
using System.Data.SqlClient;
namespace assignment8_part1
{
    class Program
    {
        static void Main()
        {
            string conStr = "server=DESKTOP-LVRAQ1E;database=Assignment8;trusted_connection=true;";

            using (SqlConnection connection = new SqlConnection(conStr))
            {
                connection.Open();

                string query = "SELECT TOP 5 * FROM Products ORDER BY PName DESC";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        Console.WriteLine("Top 5 records from Products table:");

                        while (reader.Read())
                        {
                            string pid = reader["Pid"].ToString();
                            string pName = reader["PName"].ToString();
                            decimal pPrice = Convert.ToDecimal(reader["PPrice"]);
                            DateTime mnfDate = Convert.ToDateTime(reader["MnfDate"]);
                            DateTime expDate = Convert.ToDateTime(reader["ExpDate"]);

                            Console.WriteLine($"Pid: {pid}, PName: {pName}, PPrice: {pPrice}, MnfDate: {mnfDate}, Exp Date: {expDate}");
                        }
                    }
                }
                Console.ReadKey();
            }
        }
    }
}