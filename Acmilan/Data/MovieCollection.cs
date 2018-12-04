using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Acmilan.Models;
using Dapper;

namespace Acmilan.Data
{
    public class MovieCollection
    {
        private readonly DbContext _context;

        public MovieCollection(DbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Movie>> GetMoviesByCinemaId(int cinemaId)
        {
            string sQuery= "SELECT * FROM MOVIE WHERE cinemaid = @cinemaId";
            var result = await this._context.Conn.QueryAsync<Movie>(sQuery,new { cinemaid = cinemaId });
            return result;
        }

        public async Task Add(Movie model)
        {
            string sQuery = "INSERT INTO MOVIE (Id, CinemaId, Name,Starring,DateTime)"
                            + " VALUES(@Id, @CinemaId, @Name,@Starring,@ReleaseDate)";
            await this._context.Conn.ExecuteAsync(sQuery, model);
        }

        public async Task<Movie> GetById(int id)
        {
            string sQuery = "SELECT * FROM MOVIE WHERE id = @Id";
            var result = await this._context.Conn.QueryAsync<Movie>(sQuery, new { Id = id });
            return result.FirstOrDefault();
        }

        public async Task DeleteByIdAsync(int id)
        {
            string sQuery = "DELETE FROM MOVIE WHERE id = @Id";
            await this._context.Conn.ExecuteAsync(sQuery, new { Id = id });
        }

        public async Task EditByIdAsync(Movie model)
        {
            string sQuery = "UPDATE MOVIE SET name = @Name,"
                           + " cinemaId = @CinemaId, starring= @Starring, DateTime=@ReleaseDate"
                           + " WHERE id = @Id";
            await this._context.Conn.ExecuteAsync(sQuery, model);
        }
    }
}
