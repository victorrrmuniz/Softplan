using API2.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API2.Controllers
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

        [HttpGet("calculajuros")]
        public IActionResult CalculaJuros(double valorinicial, int meses)
        {
            try 
            {
                double juros = _jurosService.GetJuros();
                var result = _jurosService.CalculaJuros(valorinicial, juros, meses);
                return Ok(result);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("showmethecode")]
        public IActionResult ShowMeTheCode()
        {
            return Ok(_jurosService.ShowMeTheCode());
        }
    }
}
