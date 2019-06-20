using Microsoft.EntityFrameworkCore;

namespace TestLoymax.Models
{
    public class ClientsContext : DbContext
    {
        public DbSet<Client> Clients { get; set; }
        public ClientsContext(DbContextOptions<ClientsContext> options)
            : base(options)
        { }
    }
}