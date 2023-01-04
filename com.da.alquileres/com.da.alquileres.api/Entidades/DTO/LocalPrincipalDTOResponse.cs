namespace com.da.alquileres.api.Entidades.DTO
{
    public class LocalPrincipalDTOResponse
    {
        public int Id { get; set; }
        public string? codigo { get; set; }
        public int idEmpresa { get; set; }
        public string? nombreEmpresa { get; set; }
        public string? direccion { get; set; }
        public int nroLocales { get; set; }
        public decimal totalM2 { get; set; }
    }
}
