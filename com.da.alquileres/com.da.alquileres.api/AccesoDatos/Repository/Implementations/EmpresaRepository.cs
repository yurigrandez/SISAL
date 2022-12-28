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

        public EmpresaRepository( AlquileresDbContext context)
        {
            this.context = context;
        }

        public Task<tabEmpresa> actualizarEntidad(tabEmpresa entidad)
        {
            throw new NotImplementedException();
        }

        public async Task<int> agregarEntidad(tabEmpresa entidad)
        {
            //obteniendo el consecutivo
            //declarando parametros sql
            var tabla = new SqlParameter
            {
                ParameterName = "tabla",
                SqlDbType = System.Data.SqlDbType.VarChar,
                Direction = System.Data.ParameterDirection.Input,
                Value = "tabEMPRESA"
            };

            var secuencia = new SqlParameter
            {
                ParameterName = "secuencia",
                SqlDbType = System.Data.SqlDbType.Char,
                Size = 8,
                Direction = System.Data.ParameterDirection.Output,
                Value = "",
            };

            //ejecutando procedimiento que obtiene correlativo
            var rejecutarProcedimiento = context.Database.ExecuteSqlRaw("Exec upsS_obtenerSecuencia {0}, {1} output", tabla, secuencia);

            //recuperando consecutivo
            var consecutivo = (string)secuencia.Value;

            //asignando consecutivo a la entidad
            entidad.codigo = consecutivo;

            await context.Set<tabEmpresa>().AddAsync(entidad);
            await context.SaveChangesAsync();
            return entidad.Id;
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
