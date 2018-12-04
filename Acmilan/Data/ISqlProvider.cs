using System.Data.Common;

namespace Acmilan.Data
{
    public interface ISqlProvider
    {
        DbProviderFactory Instance();

        string GetLastIdSql();

    }
}

