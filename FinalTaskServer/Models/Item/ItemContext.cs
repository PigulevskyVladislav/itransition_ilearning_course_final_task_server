using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace FinalTaskServer.Models
{
    public class ItemContext : DbContext
    {
        public DbSet<Item> Items { get; set; }
        public DbSet<ItemsTag> ItemsTags { get; set; }
        public DbSet<LastAddedItem> LastAddedItems { get; set; }        
        public ItemContext(DbContextOptions<ItemContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ItemsTag>()
                .HasKey(o => new { o.item_id, o.tag_id });
        }
        public IQueryable GetItemsByTagId(int tag_id)
        {
            var items = Items.Where(i => (ItemsTags.Where(
                                              it => it.tag_id == tag_id)
                                              .Select(it => it.item_id)
                                              .Distinct()
                                              )
                                          .Contains(i.id));
            return items;
        }

        public IQueryable GetItemsByCollectionId(int collection_id)
        {
            var items = Items.Where(i => i.collection_id == collection_id);
            return items;
        }
    }
}
