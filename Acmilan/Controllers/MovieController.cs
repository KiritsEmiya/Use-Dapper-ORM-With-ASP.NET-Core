using Acmilan.Models;
using Acmilan.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Acmilan.Controllers
{
    public class MovieController : Controller
    {
        private readonly IMovieService _movieService;
        private readonly ICinemaService _cinemaService;
        public MovieController(IMovieService movieService, ICinemaService cinemaService)
        {
            _movieService = movieService;
            _cinemaService = cinemaService;
        }

        public async Task<IActionResult> Index(int cinemaId)
        {
            var cinema = await _cinemaService.GetByIdAsync(cinemaId);
            ViewBag.Title = $"{cinema.Name}这个电影院上映的电影有：";
            ViewBag.CinemaId = cinemaId;

            return View(await _movieService.GetByCinemaAsync(cinemaId));
        }

        public IActionResult Add(int cinemaId)
        {
            ViewBag.Title = "添加电影";
            return View(new Movie { CinemaId = cinemaId });
        }

        [HttpPost]
        public async Task<IActionResult> Add(Movie movie)
        {
            if (ModelState.IsValid)
            {
                await _movieService.AddAsync(movie);
            }
            return RedirectToAction("Index",new { cinemaId = movie.CinemaId});
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Movie movie)
        {
            if (ModelState.IsValid)
            {
                await _movieService.EditAsync(movie);
            }
            return RedirectToAction("Index", new { cinemaId = movie.CinemaId });
        }

        public async Task<IActionResult> Edit(int id)
        {
            ViewBag.Title = "编辑电影";
            var movie = await _movieService.GetByIdAsync(id);
            return View(movie);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var movie = await _movieService.GetByIdAsync(id);
            int CinemaId = movie.CinemaId;
            await _movieService.DeleteByIdAsync(id);
            return RedirectToAction("Index", new { cinemaId = CinemaId });
        }
    }
}
