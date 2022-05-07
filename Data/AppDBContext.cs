using Gadget.api.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Gadget.api.Data
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext>options): base(options)
        {

        }

        public DbSet<Gadgets> Gadgets { get; set; }

    }
}
