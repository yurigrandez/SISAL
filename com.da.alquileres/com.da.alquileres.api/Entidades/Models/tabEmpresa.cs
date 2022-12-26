using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.da.alquileres.api.Entidades.Models
{
    public class tabEmpresa : tabEntidadBase
    {

        public string? codigo { get; set; } 
        public string? nombre { get; set; } 
        public string? direccion { get; set; } 
        public string? ruc { get; set; } 
        public string? telefono { get; set; }
        public string? movil { get; set; } 
        public string? nombreContacto { get; set; } 
        public string? correoContacto { get; set; } 
        public string? tlfContacto { get; set; } 
        public string? movilContacto { get; set; }
        public byte[]? imgEmpresa { get; set; } 

    }
}
