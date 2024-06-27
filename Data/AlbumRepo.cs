using Dapper;
using MusicdbCRUDAppController.Models;
using System.Data;

namespace MusicdbCRUDAppController.Data
{
    public class AlbumRepo : IAlbumRepo
    {
        private readonly IDbConnection _connection;

        public AlbumRepo (IDbConnection connection)
        {
            _connection = connection;
        }

        public void DeleteAlbum(Album album)
        {
            _connection.Execute("DELETE FROM albums WHERE id = @id;", new {id = album.id});
        }

        public Album GetAlbum(int id)
        {
            return _connection.QuerySingleOrDefault<Album>("SELECT * FROM albums WHERE id = @id;", new { id = id});
        }

        public IEnumerable<Album> GetAllAlbums()
        {
            return _connection.Query<Album>("SELECT * FROM albums;");
        }

        public Album GetRandomAlbum()
        {
            Random random = new Random();
            var randomId = random.Next(1, 19);
            return _connection.QuerySingle<Album>("SELECT * FROM albums WHERE ID = @randomId;", new { randomId });
        }

        public void InsertAlbum(Album albumToInsert)
        {
            _connection.Execute("INSERT INTO albums (ARTIST, ALBUM, GENRE, RELEASE_YEAR, SPOTIFY_LINK, APPLEMUSIC_LINK, EMBEDDED_CODE) VALUES (@artist, @album, @genre, @release_year, @spotify_link, @applemusic_link, @embedded_code);",
            new { artist = albumToInsert.artist, album = albumToInsert.album, genre = albumToInsert.genre, release_year = albumToInsert.release_year, spotify_link = albumToInsert.spotify_link, applemusic_link = albumToInsert.applemusic_link, embedded_code = albumToInsert.embedded_code});

        }

		public IEnumerable<Album> SearchAlbum(string searchString)
		{
			return _connection.Query<Album>("SELECT * FROM albums WHERE album LIKE @album OR artist LIKE @artist OR genre LIKE @genre OR release_year LIKE @release_year;", new {album = "%" + searchString + "%", artist = "%" + searchString + "%", genre = "%" + searchString + "%", release_year = "%" + searchString + "%" });
		}

		public void UpdateAlbum(Album album)
		{
			_connection.Execute("UPDATE albums SET artist = @artist, album = @album, genre = @genre, release_year = @release_year, spotify_link = @spotify_link, applemusic_link= @applemusic_link, embedded_code = @embedded_code WHERE id = @id",
            new { artist = album.artist, album = album.album, genre = album.genre, release_year = album.release_year, spotify_link = album.spotify_link, applemusic_link = album.applemusic_link, embedded_code = album.embedded_code, id = album.id });
		}
	}
}
