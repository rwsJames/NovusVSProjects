using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration.UserSecrets;

namespace UsingADO
{
    class Program
    {
        static string cnnString = "Server=.\\SQLEXPRESS;Database=Northwind;User Id=sa;Password=pass;";

        static void Main(string[] args)
        {
            // R
            // See state before
            SelectAndPrintAllDetailsOfAllStudents("FirstName", "LastName", "Age");
            Console.ReadLine();

            // C
            InsertIntoStudents("Tester", "McGee", 77);

            // U
            UpdateStudentAgeByID(1, 99);

            // D
            DeleteEntryByID(8);

            // See state after
            SelectAndPrintAllDetailsOfAllStudents("FirstName", "LastName", "Age");
            Console.ReadLine();
        }

        // CREATE
        private static void InsertIntoStudents(string fname, string lname, int age)
        {
            string sql = "INSERT INTO Students(FirstName, LastName, Age)" +
                         "VALUES(@FirstName, @LastName, @Age);";
            using SqlConnection cnn = new SqlConnection(cnnString);
            using SqlCommand cmd = new SqlCommand(sql, cnn);
            cmd.Parameters.Add(new SqlParameter("@FirstName", fname));
            cmd.Parameters.Add(new SqlParameter("@LastName", lname));
            cmd.Parameters.Add(new SqlParameter("@Age", age));

            cnn.Open();
            cmd.ExecuteNonQuery();
        }

        // READ
        private static void SelectAndPrintAllDetailsOfAllStudents(params string[] args)
        {
            string sql = "SELECT ";
            foreach (string arg in args) // add each string passed as a parameter to the query
                sql += arg + ",";
            sql = sql.Substring(0, sql.Length-1); // remove trailing comma
            sql += " FROM Students;";

            using SqlConnection cnn = new SqlConnection(cnnString);
            using SqlCommand cmd = new SqlCommand(sql, cnn);

            cnn.Open();
            Console.WriteLine(GetConnectionInformation(cnn) + "\n");

            using SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
                Console.WriteLine(string.Format("{0,12} {1,12} ||{2,3}", dr.GetValue(0), dr.GetValue(1), dr.GetValue(2)));
        }

        //UPDATE
        private static void UpdateStudentAgeByID(int id, int age)
        {
            string sql = "UPDATE Students SET Age=@Age WHERE ID=@ID";
            using SqlConnection cnn = new SqlConnection(cnnString);
            using SqlCommand cmd = new SqlCommand(sql, cnn);
            cmd.Parameters.Add(new SqlParameter("@ID", id));
            cmd.Parameters.Add(new SqlParameter("@Age", age));

            cnn.Open();
            cmd.ExecuteNonQuery();
        }

        // DELETE
        private static void DeleteEntryByID(int id)
        {
            string sql = "DELETE FROM Students WHERE ID = @ID";
            using SqlConnection cnn = new SqlConnection(cnnString);
            using SqlCommand cmd = new SqlCommand(sql, cnn);
            cmd.Parameters.Add(new SqlParameter("@ID", id));

            cnn.Open();
            cmd.ExecuteNonQuery();
        }

        private static string GetConnectionInformation(SqlConnection cnn)
        {
            StringBuilder sb = new StringBuilder(1024);

            sb.AppendLine("Connection string: " + cnn.ConnectionString);
            sb.AppendLine("State: " + cnn.State.ToString());
            sb.AppendLine("Connection Timeout: " + cnn.ConnectionTimeout.ToString());
            sb.AppendLine("Database: " + cnn.Database);
            sb.AppendLine("Data Source: " + cnn.DataSource);
            sb.AppendLine("Server Version: " + cnn.ServerVersion);
            sb.AppendLine("Workstation ID: " + cnn.WorkstationId);

            return sb.ToString();
        }
    }
}
