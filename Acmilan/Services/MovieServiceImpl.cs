using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Acmilan.Models;

namespace Acmilan.Services
{
    public class MovieServiceImpl : IMovieService
    {
        public async Task AddAsync(Movie model)
        {
            using (var ctx = new Data.DbContext())
            {
                await ctx.MovieCollection.Add(model);
            }
        }


        public async Task<IEnumerable<Movie>> GetByCinemaAsync(int cinemaId)
        {
            using (var ctx = new Data.DbContext())
            {
                return await ctx.MovieCollection.GetMoviesByCinemaId(cinemaId);
            }
        }

        public async Task<Movie> GetByIdAsync(int id)
        {
            using (var ctx = new Data.DbContext())
            {
                return await ctx.MovieCollection.GetById(id);
            }
        }

        public async Task DeleteByIdAsync(int id)
        {
            using (var ctx = new Data.DbContext())
            {
                await ctx.MovieCollection.DeleteByIdAsync(id);
            }
        }

        public async Task EditAsync(Movie movie)
        {
            using (var ctx = new Data.DbContext())
            {
                await ctx.MovieCollection.EditByIdAsync(movie);
            }
        }
    }
}
