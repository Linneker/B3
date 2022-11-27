using B3.API.Model.Interface;

namespace B3.API.Model.Taxation
{
    public class AboveTwentyFourMonthsCommand : ITaxCommand
    {
        public decimal Calculate(decimal valorRendimento) => Math.Round(valorRendimento - (valorRendimento * (15M / 100)), 2, MidpointRounding.AwayFromZero);
    }
}
