using B3.API.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace B3.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvestmentCalculationController : ControllerBase
    {
        [HttpPost("Calculate")]
        [ProducesResponseType(typeof(RescueFinancialCommand), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status410Gone)]
        [ProducesResponseType(typeof(string), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        public IActionResult Calculate(ValueCalculate valueCalculate)
        {
            var valor = new RescueFinancialCommand(valueCalculate.InitialValue, valueCalculate.Month);
            return Ok(valor);
        }
    }
}
