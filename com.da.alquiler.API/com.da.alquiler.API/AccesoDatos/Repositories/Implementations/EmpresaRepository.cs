using com.da.alquiler.API.AccesoDatos.Repositories.Interfaces;
using com.da.alquiler.API.Entidades.Models;
using Microsoft.EntityFrameworkCore;

namespace com.da.alquiler.API.AccesoDatos.Repositories.Implementations
{
    public class EmpresaRepository : IEmpresaRepository
    {
        private readonly AlquileresDbContext context;

        public EmpresaRepository(AlquileresDbContext context)
        {
            this.context = context;
        }
        public Task<tabEMPRESA> actualizarEntidad(tabEMPRESA entidad)
        {
            throw new NotImplementedException();
        }

        public Task<tabEMPRESA> agregarEntidad(tabEMPRESA entidad)
        {
            throw new NotImplementedException();
        }

        public Task<tabEMPRESA> buscarXId(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<tabEMPRESA>> buscarXString(string str)
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

        public async Task<ICollection<tabEMPRESA>> listarAsync()
        {
            var empresas = new List<tabEMPRESA>();
            try
            {
                empresas = await context.tabEMPRESA.ToListAsync();
            }
            catch (Exception ex)
            {

                throw;
            }
            

            return empresas;
        }
    }
}
