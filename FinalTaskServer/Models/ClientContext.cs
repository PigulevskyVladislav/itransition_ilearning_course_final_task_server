using Microsoft.EntityFrameworkCore;

namespace FinalTaskServer.Models
{
    public class ClientContext : DbContext
    {
        public DbSet<Client> Clients { get; set; }
        public ClientContext(DbContextOptions<ClientContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
