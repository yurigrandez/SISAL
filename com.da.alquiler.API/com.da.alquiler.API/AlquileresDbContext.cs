using com.da.alquiler.API.Entidades.Models;
using Microsoft.EntityFrameworkCore;

namespace com.da.alquiler.API
{
    public class AlquileresDbContext : DbContext
    {
        public AlquileresDbContext(DbContextOptions<AlquileresDbContext> options) : base(options)
        {

        }

        public DbSet<tabEMPRESA> tabEMPRESA { get; set; } = default!;
    }
}
