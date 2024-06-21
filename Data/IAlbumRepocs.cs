using MusicdbCRUDAppController.Models;
using System.Net.Http.Headers;

namespace MusicdbCRUDAppController.Data
{
    public interface IAlbumRepo
    {
        public IEnumerable<Album> GetAllAlbums();
        Album GetAlbum(int id);
        Album GetRandomAlbum();
        void UpdateAlbum(Album album);
        void InsertAlbum(Album albumToInsert);
        public void DeleteAlbum(Album album);
        IEnumerable<Album> SearchAlbum(string searchString);
    }

}
