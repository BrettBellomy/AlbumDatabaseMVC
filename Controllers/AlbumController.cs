using Microsoft.AspNetCore.Mvc;
using MusicdbCRUDAppController.Data;
using MusicdbCRUDAppController.Models;

namespace MusicdbCRUDAppController.Controllers
{
    public class AlbumController : Controller
    {
        private readonly IAlbumRepo _albumRepo;

        public AlbumController(IAlbumRepo albumRepo)
        {
            _albumRepo = albumRepo;
        }

        public IActionResult Index()
        {
            var albums = _albumRepo.GetAllAlbums();
            return View(albums);
        }

        public IActionResult ViewAlbum(int id)
        {
            var album = _albumRepo.GetAlbum(id);
            return View(album);
        }
		public IActionResult UpdateAlbum(int id)
		{
			Album album = _albumRepo.GetAlbum(id);
			if (album == null)
			{
				return View("AlbumNotFound");
			}
			return View(album);
		}
        public IActionResult UpdateAlbumToDatabase(Album album)
        {
            _albumRepo.UpdateAlbum(album);

            return RedirectToAction("ViewAlbum", new { id = album.id });
        }

        public IActionResult InsertAlbum(Album album)
        {
            return View(album);
        }

        public IActionResult InsertAlbumToDatabase(Album albumToInsert)
        {
            
            _albumRepo.InsertAlbum(albumToInsert);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteAlbum(Album album)
        {
            _albumRepo.DeleteAlbum(album);
            return RedirectToAction("Index");
        }

        public IActionResult Search(string searchString)
        {
            var searchResults = _albumRepo.SearchAlbum(searchString);
            return View(searchResults);
        }

    }
}
