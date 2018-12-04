using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Acmilan.Models;
using Microsoft.Extensions.Configuration;

namespace Acmilan.Services
{
    public class CinemaServiceImpl : ICinemaService
    {

        public Task AddAsync(Cinema model)
        {
            return Task.CompletedTask;
        }

        public async Task<Cinema> GetByIdAsync(int cinemaId)
        {
            using (var ctx = new Data.DbContext())
            {
                return await ctx.CinemaCollection.GetById(cinemaId);
            }
        }

        public async Task<IEnumerable<Cinema>> GetCinemasAsync()
        {
            using(var ctx = new Data.DbContext())
            {
                return await ctx.CinemaCollection.GetAll();
            }
        }

    }
}
