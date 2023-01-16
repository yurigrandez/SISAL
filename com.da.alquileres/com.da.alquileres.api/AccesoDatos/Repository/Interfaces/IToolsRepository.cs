namespace com.da.alquileres.api.AccesoDatos.Repository.Interfaces
{
    public interface IToolsRepository
    {
        Task<string> obtenerConsecutivo(string tabTabla);
        Task<byte[]?> subirArchivo(string archivo);
    }
}
