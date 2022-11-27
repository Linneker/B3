using B3.API.Model.Interface;

namespace B3.API.Model.Taxation
{
    public class UpToTwelveMonthsCommand : ITaxCommand
    {
        public decimal Calculate(decimal valorRendimento) => Math.Round(valorRendimento - (valorRendimento * (20M / 100)), 2, MidpointRounding.AwayFromZero);

    }
}
