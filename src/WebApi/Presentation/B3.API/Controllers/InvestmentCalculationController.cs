using B3.API.Config;
using B3.API.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace B3.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvestmentCalculationController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public InvestmentCalculationController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [ValidationCalculationFilterAttribute]
        [HttpGet("Calculate/{initialValue}/{month}")]
        [ProducesResponseType(typeof(RescueFinancialCommand), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status410Gone)]
        [ProducesResponseType(typeof(string), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        public IActionResult Calculate(
            decimal initialValue, int month)
        {
            try
            {
                if(!IsValidKey())
                    return this.StatusCode(StatusCodes.Status401Unauthorized, "Por favor insira as credenciais validas");

                RescueFinancialCommand valor = new RescueFinancialCommand(initialValue,month);
                return Ok(valor);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        private bool IsValidKey()
        {
            var _apiKey = HttpContext.Request.Headers["key"].ToString();
            if (_configuration.GetSection("APIKeys").Value != _apiKey)
                return false;
            return true;
        }
    }
}
