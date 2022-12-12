using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.da.alquileres.accesodatos
{
    public class AlquilerDBContext : DbContext
    {
        public AlquilerDBContext( DbContextOptions<AlquilerDBContext> options ) : base( options )
        {

        }
    }
}
