using Microsoft.EntityFrameworkCore;

namespace FinalTaskServer.Models
{
    public class CollectionContext : DbContext
    {
        public DbSet<Collection> Collections { get; set; }
        public DbSet<BiggestCollection> BiggestCollections { get; set; }
        public CollectionContext(DbContextOptions<CollectionContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
