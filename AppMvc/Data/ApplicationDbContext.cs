using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using AppMvc.Models;

namespace AppMvc.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        
        public DbSet<Iphone> Iphones { get; set; } = default!;
        public DbSet<Store> Stores {get; set;} = default!;
        public DbSet<Cart> Carts {get; set;} = default!;
    }
}
