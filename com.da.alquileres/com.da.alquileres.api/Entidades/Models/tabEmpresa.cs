using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.da.alquileres.api.Entidades.Models
{
    public class tabEmpresa : tabEntidadBase
    {

        public string codigo { get; set; } = default!;
        public string nombre { get; set; } = default!;
        public string direccion { get; set; } = default!;
        public string ruc { get; set; } = default!;
        public string telefono { get; set; } = default!;
        public string movil { get; set; } = default!;
        public string nombreContacto { get; set; } = default!;
        public string correoContacto { get; set; } = default!;
        public string tlfContacto { get; set; } = default!;
        public string movilContacto { get; set; } = default!;
        public string imgEmpresa { get; set; } = default!;

    }
}
