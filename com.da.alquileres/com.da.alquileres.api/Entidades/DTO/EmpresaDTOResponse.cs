namespace com.da.alquileres.api.DTO
{
    public class EmpresaDTOResponse
    {
        public int Id { get; set; }
        public string? codigo { get; set; }
        public string? nombre { get; set; }
        public string? ruc { get; set; }
        public byte[]? imgEmpresa { get; set; }
        public string? fechaCreacion { get; set; }
        public string? fechaModificacion { get; set; }
        public string? fechaDesactivacion { get; set; }
    }
}
