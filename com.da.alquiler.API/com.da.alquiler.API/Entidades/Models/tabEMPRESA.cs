namespace com.da.alquiler.API.Entidades.Models
{
    public class tabEMPRESA : tabEntidadBase
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
