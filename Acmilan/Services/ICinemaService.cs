using Acmilan.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Acmilan.Services
{
    public interface ICinemaService
    {
        Task AddAsync(Cinema model);
        Task<IEnumerable<Cinema>> GetCinemasAsync();
        Task<Cinema> GetByIdAsync(int cinemaId);
    }
}
