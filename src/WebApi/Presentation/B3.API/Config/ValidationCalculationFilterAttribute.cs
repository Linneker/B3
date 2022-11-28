using B3.API.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Xml.Linq;

namespace B3.API.Config
{
    public class ValidationCalculationFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            object? initialObject;
            context.ActionArguments.TryGetValue("initialValue", out initialObject);
            object? monthObject;
            context.ActionArguments.TryGetValue("month", out monthObject);

            if (initialObject is null)
                context.Result = new BadRequestObjectResult($"Valor para investimento invalido!");
            else if (monthObject is null)
                context.Result = new BadRequestObjectResult($"Valor invalido para mês!");
            else
            {
                decimal initial = (decimal)initialObject;
                int month = (int)monthObject;

                ValueCalculateCommand valueCalculateCommand = new ValueCalculateCommand(initial, month);
                var result = valueCalculateCommand.IsValid();
                if (!result.IsValid)
                    context.Result = new BadRequestObjectResult($"Valores invalidos {string.Join(" e ", result.Errors)}");
            }
        }
    }
}