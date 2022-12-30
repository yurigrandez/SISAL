using com.da.alquileres.api.AccesoDatos.Repository.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace com.da.alquileres.api.AccesoDatos.Repository.Implementations
{
    public class ToolsRepository : IToolsRepository
    {
        private readonly AlquileresDbContext context;

        public ToolsRepository( AlquileresDbContext context )
        {
            this.context = context;
        }
        public async Task<string> obtenerConsecutivo(string tbTabla)
        {
            //declarando parametros sql
            var tabla = new SqlParameter
            {
                ParameterName = "tabla",
                SqlDbType = System.Data.SqlDbType.VarChar,
                Direction = System.Data.ParameterDirection.Input,
                Value = tbTabla
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
            var ejecutarProcedimiento = await context.Database.ExecuteSqlRawAsync("Exec upsS_obtenerSecuencia {0}, {1} output", tabla, secuencia);

            //recuperando consecutivo
            var consecutivo = (string)secuencia.Value;

            return consecutivo;

        }
    }
}
