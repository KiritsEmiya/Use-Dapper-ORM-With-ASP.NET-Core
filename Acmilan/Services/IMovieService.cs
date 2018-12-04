using Acmilan.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Acmilan.Services
{
    public interface IMovieService
    {
        Task AddAsync(Movie model);
        Task<IEnumerable<Movie>> GetByCinemaAsync(int cinemaId);
        Task<Movie> GetByIdAsync(int id);
        Task DeleteByIdAsync(int id);
        Task EditAsync(Movie movie);
    }
}
