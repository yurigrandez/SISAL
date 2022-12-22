using com.da.alquileres.accesodatos.Interfaces;
using com.da.alquileres.api;
using com.da.alquileres.api.Entidades.Models;
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

        public EmpresaRepository( AlquileresDbContext context)
        {
            this.context = context;
        }

        public Task<tabEmpresa> actualizarEntidad(tabEmpresa entidad)
        {
            throw new NotImplementedException();
        }

        public Task<tabEmpresa> agregarEntidad(tabEmpresa entidad)
        {
            throw new NotImplementedException();
        }

        public Task<tabEmpresa> buscarXId(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<tabEmpresa>> buscarXString(string str)
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

        public async Task<ICollection<tabEmpresa>> listarAsync()
        {
            return await context.tabEmpresa.ToListAsync();
        }
    }
}
