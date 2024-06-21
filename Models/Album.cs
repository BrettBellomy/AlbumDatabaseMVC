namespace MusicdbCRUDAppController.Models
{
    public class Album
    {
        public Album()
        {
        }
        public int id { get; set; }
        public string artist { get; set; }
        public string album { get; set; }
        public string genre { get; set; }
        public int release_year { get; set; }
        public string spotify_link { set; get; }
        public string applemusic_link { get; set; }
        public string embedded_code { get; set; }

    }
}
