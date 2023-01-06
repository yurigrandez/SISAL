using com.da.alquileres.api.AccesoDatos.Services;
using com.da.alquileres.api.DTO;
using com.da.alquileres.api.Entidades.DTO;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace com.da.alquileres.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocalPrincipalController : ControllerBase
    {
        private readonly ILocalPrincipalServices services;

        public LocalPrincipalController(ILocalPrincipalServices services)
        {
            this.services = services;
        }

        // GET: api/<LocalPrincipalController>
        [HttpGet("listarLocalesPrincipales")]
        public async Task<IActionResult> Get()
        {
            //declarando variable para ejecutar metodo
            var resultado = await services.listarLocalesPrincipales();

            //verificando si existen errores
            if(!resultado.Success)
                return BadRequest(resultado);

            return Ok(resultado);
        }

        // GET api/<LocalPrincipalController>/5
        [HttpGet("buscarXId")]
        public async Task<IActionResult> Get(int id)
        {
            //ejecutando metodo
            var resultado = await services.buscarXId(id);

            if (!resultado.Success)
                return BadRequest(resultado);

            return Ok(resultado);
        }

        // POST api/<LocalPrincipalController>
        [HttpPost("agregarLocalPrincipal")]
        public async Task<IActionResult> Post([FromBody] LocalPrincipalDTONuevo dTONuevo)
        {
            var resultado = await services.agregarEntidad(dTONuevo);

            if(!resultado.Success)
                BadRequest(resultado);

            return Ok(resultado);
        }

        // PUT api/<LocalPrincipalController>/5
        [HttpPut("actualizarLocalPrincipal")]
        public async Task<IActionResult> Put(int id, [FromBody] LocalPrincipalDTOActualizar dTOActualizar)
        {
            //declarando variable para devolver respuesta
            var respuesta = await services.actualizarEntidad(id, dTOActualizar);

            //verificando si hubo error
            if (!respuesta.Success)
                return BadRequest(respuesta);

            //devolviendo respuesta
            return Ok(respuesta);
        }

        [HttpPut("activarLocalPrincipal")]
        public async Task<IActionResult> Put(int id)
        {
            //ejecutando metodo
            var respuesta = await services.activarLocalPrincipal(id);

            //verificando si hay errore
            if (!respuesta.Success)
                return BadRequest(respuesta);

            return Ok(respuesta);
        }

        [HttpPut("desactivarLocalPrincipal")]
        public async Task<IActionResult> desactivarLocalPrincipal(int id)
        {
            //obteniendo respuesta
            var respuesta = await services.desactivarLocalPrincipal(id);

            //verificando si hubo errores
            if (!respuesta.Success)
                return BadRequest(respuesta);

            return Ok(respuesta);
        }

        // DELETE api/<LocalPrincipalController>/5
        [HttpDelete("eliminarLocalPrincipal")]
        public async Task<IActionResult> Delete(int id)
        {
            //realizando consulta
            var respuesta = await services.eliminarLocalPrincipal(id);

            //verificando si hubo errores
            if (!respuesta.Success)
                return BadRequest(respuesta);

            return Ok(respuesta);
        }

        [HttpGet("buscarXString")]
        public async Task<IActionResult> Get(string str)
        {
            //ejecutando consulta
            var respuesta = await services.buscarXString(str);

            //verificando si hubo errores
            if (!respuesta.Success)
                return BadRequest(respuesta);

            return Ok(respuesta);
        }
    }
}
