using LJLeandro.DbHelper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExemploDbHelper
{
    class Program
    {
        static void Main(string[] args)
        {
            string minhaConnectionString = "";
            string nomeArquivoQuery = "query_exemplo.sql";
            int id = 523;

            Dictionary<string, string> parametros = new Dictionary<string, string>
            {
                { "@id", id.ToString() }
            };

            DataTable table = DbHelper.ExecuteSqlCommand(minhaConnectionString, nomeArquivoQuery, parametros);
            Console.WriteLine($"Count: {table.Rows.Count}");
        }
    }
}
