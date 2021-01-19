using Microsoft.EntityFrameworkCore;

namespace FinalTaskServer.Models
{
    public class ItemContext : DbContext
    {
        public DbSet<Item> Items { get; set; }
        public DbSet<LastAddedItem> LastAddedItems { get; set; }
        public ItemContext(DbContextOptions<ItemContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
