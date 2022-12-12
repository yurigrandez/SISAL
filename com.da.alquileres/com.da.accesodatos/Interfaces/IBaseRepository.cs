using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.da.accesodatos.Interfaces
{
    public interface IBaseRepository<T>
    {
        Task<ICollection<T>> listarAsync();

        Task<T> buscarXId(int id);

        Task<T> buscarXString(string str);
        Task<T> agregarEntidad(T entidad);
        Task<T> actualizarEntidad(T entidad);
        Task eliminarEntidad(int Id);
        Task grabarCambios();

    }
}
