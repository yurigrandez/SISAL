namespace com.da.alquileres.api.DTO
{
    public class EmpresaDTOResponse
    {
        public int Id { get; set; }
        public string codigo { get; set; } = default!;
        public string nombre { get; set; } = default!;
        public string ruc { get; set; } = default!;
    }
}
