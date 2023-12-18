using System;
using System.Data;

namespace assignment8_part2

{
    class Program
    {
        static DataTable productsTable;

        static void Main()
        {
            // Initialize DataTable
            InitializeDataTable();

            // Insert sample records
            InsertRecord("P00001", 19, DateTime.Parse("2022-01-01"), DateTime.Parse("2023-01-01"));
            InsertRecord("P00002", 29, DateTime.Parse("2022-02-15"), DateTime.Parse("2023-02-15"));
            InsertRecord("P00003", 39, DateTime.Parse("2022-03-20"), DateTime.Parse("2023-03-20"));

            // Display all records
            DisplayRecords();

            // Update a record
            UpdateRecord("P00001", 24);

            // Display updated records
            Console.WriteLine("After update:");
            DisplayRecords();

            // Search for a record
            DataRow searchResult = SearchRecord("P00002");
            if (searchResult != null)
            {
                Console.WriteLine("Search Result: Pid = {0}, PPrice = {1}, MnfDate = {2}, ExpDate = {3}",
                                  searchResult["Pid"], searchResult["PPrice"], searchResult["MnfDate"], searchResult["ExpDate"]);
            }
            else
            {
                Console.WriteLine("Record not found.");
            }

            // Delete a record
            DeleteRecord("P00003");

            // Display records after delete
            Console.WriteLine("After delete:");
            DisplayRecords();
            Console.ReadKey();
        }

        static void InitializeDataTable()
        {
            // Create DataTable
            productsTable = new DataTable("Products");

            // Define columns
            productsTable.Columns.Add("Pid", typeof(string));
            productsTable.Columns.Add("PPrice", typeof(decimal));
            productsTable.Columns.Add("MnfDate", typeof(DateTime));
            productsTable.Columns.Add("ExpDate", typeof(DateTime));

            // Set Pid as the primary key
            productsTable.PrimaryKey = new DataColumn[] { productsTable.Columns["Pid"] };
        }

        static void InsertRecord(string pid, decimal pPrice, DateTime mnfDate, DateTime expDate)
        {
            DataRow newRow = productsTable.NewRow();
            newRow["Pid"] = pid;
            newRow["PPrice"] = pPrice;
            newRow["MnfDate"] = mnfDate;
            newRow["ExpDate"] = expDate;

            productsTable.Rows.Add(newRow);
        }

        static void UpdateRecord(string pid, decimal newPPrice)
        {
            DataRow rowToUpdate = productsTable.Rows.Find(pid);

            if (rowToUpdate != null)
            {
                rowToUpdate["PPrice"] = newPPrice;
            }
        }

        static DataRow SearchRecord(string pid)
        {
            DataRow foundRow = productsTable.Rows.Find(pid);
            return foundRow;
        }

        static void DeleteRecord(string pid)
        {
            DataRow rowToDelete = productsTable.Rows.Find(pid);

            if (rowToDelete != null)
            {
                productsTable.Rows.Remove(rowToDelete);
            }
        }

        static void DisplayRecords()
        {
            Console.WriteLine("Products Table:");

            foreach (DataRow row in productsTable.Rows)
            {
                Console.WriteLine("Pid = {0}, PPrice = {1}, MnfDate = {2}, ExpDate = {3}",
                                  row["Pid"], row["PPrice"], row["MnfDate"], row["ExpDate"]);
            }

            Console.WriteLine();
        }
    }

}