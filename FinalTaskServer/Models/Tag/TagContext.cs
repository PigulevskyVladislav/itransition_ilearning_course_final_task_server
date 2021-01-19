using Microsoft.EntityFrameworkCore;

namespace FinalTaskServer.Models
{
    public class TagContext : DbContext
    {
        public DbSet<Tag> Tags { get; set; }
        public TagContext(DbContextOptions<TagContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
