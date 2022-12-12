using com.da.alquileres.accesodatos.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.da.alquileres.accesodatos.Implementations
{
    public class EmpresaRepository : IEmpresaRepository
    {
        public Task<IEmpresaRepository> actualizarEntidad(IEmpresaRepository entidad)
        {
            throw new NotImplementedException();
        }

        public Task<IEmpresaRepository> agregarEntidad(IEmpresaRepository entidad)
        {
            throw new NotImplementedException();
        }

        public Task<IEmpresaRepository> buscarXId(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEmpresaRepository> buscarXString(string str)
        {
            throw new NotImplementedException();
        }

        public Task eliminarEntidad(int Id)
        {
            throw new NotImplementedException();
        }

        public Task grabarCambios()
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<IEmpresaRepository>> listarAsync()
        {
            throw new NotImplementedException();
        }
    }
}
