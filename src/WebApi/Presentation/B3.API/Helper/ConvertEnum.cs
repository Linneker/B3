using B3.API.Config;
using B3.API.Model.Enuns;

namespace B3.API.Helper
{
    public static class ConvertEnum
    {
        public static MonthlyTax GetTaxEnum(this int month)
        {
            if (month > 0 && month <= 6) return MonthlyTax.UpToSix;
            else if (month > 6 && month <= 12) return MonthlyTax.UpToTwelve;
            else if (month > 12 && month <= 24) return MonthlyTax.UpToTwentyFour;
            else if (month > 24) return MonthlyTax.AboveTwentyFour;
            else throw new EnumExcaption("Valor fornecido invalido!", month);

        }
    }
}
