using System.Data.Entity;

namespace Music_Store.Models
{
    public class MusicStoreContext : DbContext
    {
        public MusicStoreContext() : base("name=myconn") { }

        public DbSet<Genre> AllGenres { get; set; }
        public DbSet<Album> AllAlbums { get; set; }
        public DbSet<Artist> AllArtists { get; set; }
    }

}