using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Acmilan.Models;
using Dapper;

namespace Acmilan.Data
{
    public class CinemaCollection
    {
        private readonly DbContext _context;

        public CinemaCollection(DbContext context) {
            _context = context;
        }

        public async Task<IEnumerable<Cinema>> GetAll()
        {
            string sQuery = "SELECT * FROM CINEMA ";
            var result = await this._context.Conn.QueryAsync<Cinema>(sQuery);
            return result;
        }

        public async Task<Cinema> GetById(int id)
        {

            string sQuery = "SELECT * FROM CINEMA WHERE id = @Id";
            var result = await this._context.Conn.QueryAsync<Cinema>(sQuery,new { Id = id});
            return result.FirstOrDefault();
        }
    }
}
