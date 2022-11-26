using B3.API.Helper;

namespace B3.API.Model
{
    public class RescueFinancialCommand
    {
        private const decimal TB = 1.08M;
        private const decimal CDI = 0.009M;
        private decimal _grossAmount = 0M;
        private decimal _netAmount = 0M;

        public RescueFinancialCommand(decimal initialValue, int months)
        {
            CDBGrossCalculation(initialValue, months);
            CDBNetCalculation(initialValue, months);
        }

        public decimal GrossAmount { get => _grossAmount; }
        public decimal NetAmount { get => _netAmount; }


        private void CDBGrossCalculation(decimal vi, int months)
        {
            decimal vt = 0;
            for (int i = 0; i < months; i++)
            {
                vt += Math.Round(((vi + vt) * (1 + (TB * CDI))) - (vi + vt), 2, MidpointRounding.AwayFromZero);
            }
            _grossAmount = (vi + vt);
        }
        private void CDBNetCalculation(decimal vi, int months)
        => _netAmount = Math.Round(vi + new TaxFactory().GetTax(months.GetTaxEnum(), GrossAmount - vi), 2, MidpointRounding.AwayFromZero);



    }
}
