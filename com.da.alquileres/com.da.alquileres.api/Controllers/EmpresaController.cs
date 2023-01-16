using com.da.alquileres.api.Entidades.DTO;
using com.da.alquileres.api.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace com.da.alquileres.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpresaController : ControllerBase
    {
        private readonly IEmpresaServices services;

        public EmpresaController( IEmpresaServices services )
        {
            this.services = services;
        }

        // GET: api/<EmpresaController>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var empresas = await services.listarTodas();

            if(!empresas.Success)
            {
                return NotFound(empresas.ErrorMessage);
            }

            return Ok(empresas);
        }

        // GET api/<EmpresaController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var resultado = await services.buscarXId(id);

            if (resultado.Success)
                return Ok(resultado);

            return BadRequest(resultado);
        }

        [HttpGet("buscarXString")]
        public async Task<IActionResult> buscarXString(string str)
        {
            var resultado = await services.buscarXString(str);

            if (resultado.Success)
                return Ok(resultado);

            return BadRequest(resultado);
        }

        // POST api/<EmpresaController>
        [HttpPost("agregarEmpresa")]
        public async Task<IActionResult> Post([FromBody] EmpresaDTONuevo empresaDTONuevo)
        {
            var resultado = await services.agregarEmpresa(empresaDTONuevo);

            if( resultado.Success )
                return Ok(resultado);

            return BadRequest(resultado);
        }

        // PUT api/<EmpresaController>/5
        [HttpPut("desactivarEmpresa")]
        public async Task<IActionResult> Put(int id)
        {
            var resultado = await services.desactivarEntidad(id);

            if (resultado.Success)
                return Ok(resultado);

            return BadRequest(resultado);
        }

        [HttpPut("activarEmpresa")]
        public async Task<IActionResult> activarEntidad(int id)
        {
            var resultado = await services.activarEntidad(id);

            if (resultado.Success)
                return Ok(resultado);

            return BadRequest(resultado);
        }

        [HttpPut("actualizarEmpresa")]
        public async Task<IActionResult> actualizarEntidad(int id, [FromBody] EmpresaDTOActualizar empresaDTOActualizar)
        {

            var resultado = await services.actualizarEmpresa(id, empresaDTOActualizar);

            if (resultado.Success)
                return Ok(resultado);

            return BadRequest(resultado);
        }

        // DELETE api/<EmpresaController>/5
        [HttpDelete("eliminarEmpresa")]
        public async Task<IActionResult> Delete(int id)
        {
            var resultado = await services.eliminarEntidad(id);

            if (resultado.Success)
                return Ok(resultado);

            return BadRequest(resultado);
        }
    }
}
