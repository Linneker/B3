using B3.API.Model.Interface;

namespace B3.API.Model.Taxation
{
    public class UpToSixMonths : ITax
    {
        public decimal Calculate(decimal valorRendimento) => Math.Round(valorRendimento - (valorRendimento * (22.5M / 100)), 2, MidpointRounding.AwayFromZero);

    }
}
