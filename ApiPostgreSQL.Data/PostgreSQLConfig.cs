using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiPostgreSQL.Data
{
    public class PostgreSQLConfig
    {
        public string ConnectionString { get; set; }
        public PostgreSQLConfig(string connectionString) => ConnectionString = connectionString;
    }
}
