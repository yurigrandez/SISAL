namespace com.da.alquiler.API.AccesoDatos.Repositories.Interfaces
{
    public interface IBaseRepository<T>
    {
        Task<ICollection<T>> listarAsync();
        Task<T> buscarXId(int id);
        Task<ICollection<T>> buscarXString(string str);
        Task<T> agregarEntidad(T entidad);
        Task<T> actualizarEntidad(T entidad);
        Task eliminarEntidad(int Id);
        Task grabarCambios();
    }
}
