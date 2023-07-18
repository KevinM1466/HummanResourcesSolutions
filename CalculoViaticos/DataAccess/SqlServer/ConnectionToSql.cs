using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DataAccess
{
    public abstract class ConnectionToSql
    {

        private readonly string connectionString;
        public ConnectionToSql()
        {
            connectionString = "Data Source=THEDARKSARCO;Initial Catalog=dbTecnasa;Integrated Security=True";
        }

        protected SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }

    }
}
