using Microsoft.AspNetCore.Mvc;
using MusicdbCRUDAppController.Data;
using MusicdbCRUDAppController.Models;
using System.Diagnostics;

namespace MusicdbCRUDAppController.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IAlbumRepo _albumRepo;

        public HomeController(IAlbumRepo repo)
        {
            _albumRepo = repo;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
		public IActionResult GetRandomAlbum()
		{
			var album = _albumRepo.GetRandomAlbum();
			return View(album);
		}


	}
}
