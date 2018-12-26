using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace LJLeandro.DbHelper
{
    public static class DbHelper
    {
        public static DataTable ExecuteSqlCommand(string connectionString, string queryFilePath, Dictionary<string, string> parametros)
        {
            string query = ReadQueryFile(queryFilePath);

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                foreach (KeyValuePair<string, string> parametro in parametros)
                {
                    query = query.Replace($"@{parametro.Key}", parametro.Value);
                }

                SqlCommand command = new SqlCommand(query, connection);
                IDataReader reader = command.ExecuteReader();

                connection.Close();

                DataTable table = new DataTable();
                table.Load(reader);

                return table;
            }
        }

        private static string ReadQueryFile(string queryFilePath)
        {
            using (StreamReader reader = new StreamReader(queryFilePath))
            {
                return reader.ReadToEnd();
            }
        }
    }
}
