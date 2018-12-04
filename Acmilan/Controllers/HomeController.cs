using Acmilan.Models;
using Acmilan.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Acmilan.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICinemaService _cinemaService;

        public HomeController(ICinemaService cinemaService)
        {
            _cinemaService = cinemaService;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.Title = "电影院列表";
            return View(await _cinemaService.GetCinemasAsync());
        }

        public IActionResult Add()
        {
            ViewBag.Title = "添加电影院";
            return View(new Cinema());
        }

        [HttpPost]
        public async Task<IActionResult> Add(Cinema model)
        {
            if (ModelState.IsValid)
            {
                await _cinemaService.AddAsync(model);
            }
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int cinemaId)
        {
            return RedirectToAction("Index");
        }
    }
}
