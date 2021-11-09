using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace Banco.Application.Test.Dobles
{
    public class SqlServerDatabaseInMemory
    {
        public static DbConnection CreateConnection()
        {
            var connection = new SqlConnection("Server=localHost\\SQLEXPRESS; Database=BancoSolucion; Trusted_Connection=True; MultipleActiveResultSets=True");

            connection.Open();

            return connection;
        }
    }
}
