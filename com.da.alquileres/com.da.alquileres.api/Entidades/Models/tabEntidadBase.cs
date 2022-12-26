using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.da.alquileres.api.Entidades.Models
{
    public class tabEntidadBase
    {
        public int Id { get; set; }
        public DateTime? fechaCreacion { get; set; }
        public DateTime? fechaModificacion { get; set; }
        public DateTime? fechaDesactivacion { get; set; }
    }
}
