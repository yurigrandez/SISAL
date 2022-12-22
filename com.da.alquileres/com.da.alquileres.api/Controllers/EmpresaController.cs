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
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<EmpresaController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<EmpresaController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<EmpresaController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
