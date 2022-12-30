using com.da.alquileres.accesodatos.Interfaces;
using com.da.alquileres.api;
using com.da.alquileres.api.Entidades.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.da.alquileres.accesodatos.Implementations
{
    public class EmpresaRepository : IEmpresaRepository
    {
        private readonly AlquileresDbContext context;

        public EmpresaRepository( AlquileresDbContext context )
        {
            this.context = context;
        }

        public async Task activarEntidad(tabEmpresa entidad)
        {
            entidad.fechaDesactivacion = null;
            await context.SaveChangesAsync();
        }

        public async Task<int> actualizarEntidad(tabEmpresa entidad)
        {
            context.tabEmpresa.Update(entidad);
            await context.SaveChangesAsync();

            return entidad.Id;
        }

        public async Task<int> agregarEntidad(tabEmpresa entidad)
        {

            await context.Set<tabEmpresa>().AddAsync(entidad);
            await context.SaveChangesAsync();
            return entidad.Id;
         }

        public Task<tabEmpresa?> buscarXId(int id)
        {
            var empresa = context.tabEmpresa.AsNoTracking().FirstOrDefaultAsync( x => x.Id == id);

            return empresa;
        }

        public async Task<ICollection<tabEmpresa>> buscarXString(string? str)
        {
            var empresas = await context.tabEmpresa.Where( x => x.nombre.Contains(str) ).ToListAsync();

            return empresas;

        }

        public async Task desactivarEntidad(tabEmpresa empresa)
        {

            //asignando fecha de desactivacion
            empresa.fechaDesactivacion = DateTime.Now;
            await context.SaveChangesAsync();

        }

        public async Task eliminarEntidad(tabEmpresa empresa)
        {
            context.tabEmpresa.Remove(empresa);
            await context.SaveChangesAsync();
        }

        public async Task grabarCambios()
        {
            await context.SaveChangesAsync();
        }

        public async Task<ICollection<tabEmpresa>> listarAsync()
        {
            return await context.tabEmpresa.ToListAsync();
        }
    }
}
