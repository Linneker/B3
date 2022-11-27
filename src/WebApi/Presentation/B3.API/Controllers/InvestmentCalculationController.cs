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
        [ValidationCalculationFilterAttribute]
        [HttpGet("Calculate/{initialValue}/{month}")]
        [ProducesResponseType(typeof(RescueFinancialCommand), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status410Gone)]
        [ProducesResponseType(typeof(string), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        public IActionResult Calculate(decimal initialValue, int month)
        {
            try
            {
                RescueFinancialCommand valor = new RescueFinancialCommand(initialValue,month);
                return Ok(valor);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
