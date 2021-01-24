using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace FinalTaskServer.Models
{
    public class CollectionContext : DbContext
    {
        public DbSet<Client> Users { get; set; }
        public DbSet<Collection> Collections { get; set; }
        public DbSet<BiggestCollection> BiggestCollections { get; set; }
        public CollectionContext(DbContextOptions<CollectionContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
        public IQueryable GetCollectionByUserId(int user_id)
        {
            var collections = Collections.Where(c => c.user_id == user_id);
            return collections;
        }
        public object GetCollectionWithOwner(int collection_id)
        {
            var collection = Collections.Where(c => c.id == collection_id)
                                        .Join(Users,
                                              c => c.user_id,
                                              u => u.id,
                                              (col, user) => new { col.id,
                                                                   col.name,
                                                                   col.description,
                                                                   col.picture,
                                                                   owner_id = col.user_id,
                                                                   owner    = user.login}).SingleOrDefault();
            return collection;
        }
    }
}
