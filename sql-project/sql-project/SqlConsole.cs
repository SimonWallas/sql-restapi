using System;
using System.Data;
using System.Data.SqlClient;


namespace TestProjectWebApi
{

    class SqlConsole
    {
        public void Main()
        {
            string str = "Data Source=WI3S03\\SQLEXPRESS;Initial Catalog=restDB;"
                + "Integrated Security=true";
            ReadOrderData(str);
        }

        public void ReadOrderData(string connectionString)
        {
            string queryString =
                "SELECT ID, Name FROM dbo.Cars;";

            using (SqlConnection connection =
                       new SqlConnection(connectionString))
            {
                SqlCommand command =
                    new SqlCommand(queryString, connection);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                
                while (reader.Read())
                {
                    ReadSingleRow((IDataRecord)reader);
                }

                
                reader.Close();
            }
        }

        public static void ReadSingleRow(IDataRecord dataRecord)
        {
            Console.WriteLine(String.Format("{0}, {1}", dataRecord[0], dataRecord[1]));
        }
    }
}