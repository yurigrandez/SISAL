using com.da.alquileres.entidades;
using Microsoft.EntityFrameworkCore;

namespace com.da.alquileres.api
{
    public class AlquileresDbContext : DbContext
    {
        public AlquileresDbContext( DbContextOptions<AlquileresDbContext> options ) : base( options )
        {

        }

        public DbSet<tabEmpresa> tabEmpresa { get; set; } = default!;
    }
}
