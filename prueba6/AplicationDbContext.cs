using Microsoft.EntityFrameworkCore;
using prueba6.Models;

namespace prueba6
{
    public class AplicationDbContext: DbContext
    {
        public DbSet<RegistroUsuarios> RegistroUsuarios { get; set; }
        public AplicationDbContext(DbContextOptions<AplicationDbContext> options): base(options) 
        { 

        }
    }
}
