using com.da.alquileres.api.AccesoDatos.Services;
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
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<LocalPrincipalController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<LocalPrincipalController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<LocalPrincipalController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
