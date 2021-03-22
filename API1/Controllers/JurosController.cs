using API1.Services;
using API1.Configurations;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;

namespace API1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class JurosController : ControllerBase
    {
        private readonly IJurosService _jurosService;
        public JurosController(IJurosService jurosService)
        {
            _jurosService = jurosService;
        }

        [HttpGet("taxaJuros")]
        public IActionResult taxaJuros()
        {
            try
            {
                var result = _jurosService.CalcularJuros();
                return Ok(result);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
