using com.da.alquileres.api.Entidades.Models;
using Microsoft.EntityFrameworkCore;

namespace com.da.alquileres.api
{
    public class AlquileresDbContext : DbContext
    {
        public AlquileresDbContext( DbContextOptions<AlquileresDbContext> options ) : base( options )
        {

        }

        public DbSet<tabEmpresa> tabEmpresa{ get; set; } = default!;
        public DbSet<tabSecuencia> tabSecuencia { get; set; } = default!;
        public DbSet<tabLocal_Principal> tabLocal_Principal { get; set; } = default!;
    }
}
