using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.da.alquileres.accesodatos.Interfaces
{
    public interface IBaseRepository<T>
    {
        Task<ICollection<T>> listarAsync();
        Task<T?> buscarXId(int id);
        Task<ICollection<T>> buscarXString(string? str);
        Task<int> agregarEntidad(T entidad);
        Task<T> actualizarEntidad(T entidad);
        Task eliminarEntidad(int Id);
        Task grabarCambios();
        Task desactivarEntidad(T entidad);

    }
}
