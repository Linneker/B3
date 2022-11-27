using B3.API.Model;
using FluentValidation;

namespace B3.API.Validation
{
    public class ValueCalculateValidation : AbstractValidator<ValueCalculate>
    {
        public ValueCalculateValidation()
        {
            RuleFor(t => t.InitialValue)
                   .GreaterThan(0).WithMessage("Valor deve ser maior que zero!");

            RuleFor(t => t.Month)
                .NotEmpty().WithMessage("Mês deve ser informado!")
                .GreaterThan(0).WithMessage("Quantidade mês(es) Invalido(s)!");
        }
    }
}
