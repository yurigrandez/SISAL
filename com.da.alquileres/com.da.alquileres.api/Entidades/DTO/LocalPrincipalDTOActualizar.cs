namespace com.da.alquileres.api.Entidades.DTO
{
    public class LocalPrincipalDTOActualizar
    {
        public string? direccion { get; set; }
        public int nroLocales { get; set; }
        public decimal totalM2 { get; set; }
        public string? dimensiones { get; set; }
        public int nroPisos { get; set; }
        public byte[]? imgFrontis { get; set; }
        public int idEmpresa { get; set; }
    }
}
