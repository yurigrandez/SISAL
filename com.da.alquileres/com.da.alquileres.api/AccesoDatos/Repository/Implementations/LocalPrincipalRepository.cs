using com.da.alquileres.api.AccesoDatos.Repository.Interfaces;
using com.da.alquileres.api.Entidades.Models;
using Microsoft.EntityFrameworkCore;

namespace com.da.alquileres.api.AccesoDatos.Repository.Implementations
{
    public class LocalPrincipalRepository : ILocalPrincipalRepository
    {
        private readonly AlquileresDbContext context;

        public LocalPrincipalRepository(AlquileresDbContext context)
        {
            this.context = context;
        }
        public Task activarEntidad(tabLocal_Principal entidad)
        {
            throw new NotImplementedException();
        }

        public Task<int> actualizarEntidad(tabLocal_Principal entidad)
        {
            throw new NotImplementedException();
        }

        public Task<int> agregarEntidad(tabLocal_Principal entidad)
        {
            throw new NotImplementedException();
        }

        public Task<tabLocal_Principal?> buscarXId(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<tabLocal_Principal>> buscarXString(string? str)
        {
            throw new NotImplementedException();
        }

        public Task desactivarEntidad(tabLocal_Principal entidad)
        {
            throw new NotImplementedException();
        }

        public Task eliminarEntidad(tabLocal_Principal entidad)
        {
            throw new NotImplementedException();
        }

        public Task grabarCambios()
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<tabLocal_Principal>> listarAsync()
        {
            var locales = await context.tabLocal_Principal.
                                        Include(x => x.empresa).
                                        ToListAsync();

            return locales;
        }
    }
}
