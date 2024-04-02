using Avaliacao1.JonStore.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Avaliacao1.JonStore.Repository.Context
{
    public class JonStoreDbContext : DbContext
    {
        public JonStoreDbContext(DbContextOptions<JonStoreDbContext> options) : base(options) { }

        public DbSet<Product> Product { get; set; }
    }
}
