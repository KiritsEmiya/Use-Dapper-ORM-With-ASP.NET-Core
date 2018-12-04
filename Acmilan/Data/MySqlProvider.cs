using MySql.Data.MySqlClient;
using System.Data.Common;

namespace Acmilan.Data
{
    public class MySqlProvider : ISqlProvider
    {
        public string GetLastIdSql()
        {
            return "select LAST_INSERT_ID()";
        }

        public DbProviderFactory Instance()
        {
            return MySqlClientFactory.Instance;
        }
    }
}
