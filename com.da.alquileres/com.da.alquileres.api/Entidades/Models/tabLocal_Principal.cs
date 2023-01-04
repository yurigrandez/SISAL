using System.ComponentModel.DataAnnotations.Schema;

namespace com.da.alquileres.api.Entidades.Models
{
    public class tabLocal_Principal : tabEntidadBase
    {
        public string? codigo { get; set; }
        public string? direccion { get; set; }
        public int nroLocales { get; set; }
        public decimal totalM2 { get; set; }
        public string? dimensiones { get; set; }
        public int nroPisos { get; set; }
        public byte[]? imgFrontis { get; set; }
        public int idEmpresa { get; set; }
        [ForeignKey("idEmpresa")]
        public tabEmpresa? empresa { get; set; }

    }
}
