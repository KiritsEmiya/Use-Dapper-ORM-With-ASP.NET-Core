using System;
using System.Data.Common;

namespace Acmilan.Data
{
    public class DbContext : IDisposable
    {

        public static ISqlProvider provider;
        public static string defaultString = string.Empty;

        public DbContext()
        {
            Provider = provider;
            ConnString = defaultString;
        }

        public ISqlProvider Provider { get; set; }

        protected string ConnString { get; set; }

        private DbConnection _conn;
        public DbConnection Conn
        {
            get
            {
                if (_conn == null)
                {
                    _conn = Provider.Instance().CreateConnection();
                    _conn.ConnectionString = ConnString;
                    _conn.Open();
                }
                return _conn;
            }
            set
            {
                _conn = value;
            }
        }

        public void Dispose()
        {
            if (_conn != null)
            {
                _conn.Close();
                _conn.Dispose();
                _conn = null;
            }
        }

        private CinemaCollection _cinemaCollection;
        public CinemaCollection CinemaCollection
        {
            get
            {
                if (_cinemaCollection == null)
                    _cinemaCollection = new CinemaCollection(this);
                return _cinemaCollection;
            }
        }

        private MovieCollection _movieCollection;
        public MovieCollection MovieCollection
        {
            get
            {
                if (_movieCollection == null)
                    _movieCollection = new MovieCollection(this);
                return _movieCollection;
            }
        }
    }
}
