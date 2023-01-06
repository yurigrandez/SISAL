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
        public async Task activarEntidad(tabLocal_Principal entidad)
        {
            //eliminando fecha de desactivación
            entidad.fechaDesactivacion = null;

            //actualizando context
            context.tabLocal_Principal.Update(entidad);

            //guardando cambios
            await context.SaveChangesAsync();
        }

        public async Task<int> actualizarEntidad(tabLocal_Principal entidad)
        {
            context.tabLocal_Principal.Update(entidad);
            await context.SaveChangesAsync();

            return entidad.Id;
        }

        public async Task<int> agregarEntidad(tabLocal_Principal entidad)
        {
            context.Set<tabLocal_Principal>().Add(entidad);
            await context.SaveChangesAsync();

            return entidad.Id;
        }

        public async Task<tabLocal_Principal?> buscarXId(int id)
        {
            var localPrincipal = await context.tabLocal_Principal
                                                .AsNoTracking()
                                               .Include(x => x.empresa)
                                               .FirstOrDefaultAsync(x => x.Id == id);

            return localPrincipal;
        }

        public async Task<ICollection<tabLocal_Principal>> buscarXString(string? str)
        {
            var busqueda = await context.tabLocal_Principal.
                                    AsNoTracking().
                                    Include(x => x.empresa).
                                    Where(x => x.direccion.Contains(str)).
                                    ToListAsync();

            return busqueda;
        }

        public async Task desactivarEntidad(tabLocal_Principal entidad)
        {
            //asignando fecha de desactivación
            entidad.fechaDesactivacion = DateTime.Now;

            //actualizando context
            context.tabLocal_Principal.Update(entidad);

            //grabando cambios
            await context.SaveChangesAsync();
        }

        public async Task eliminarEntidad(tabLocal_Principal entidad)
        {
            //removiendo del contexto
            context.tabLocal_Principal.Remove(entidad);

            //grabando cambios
            await context.SaveChangesAsync();
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
