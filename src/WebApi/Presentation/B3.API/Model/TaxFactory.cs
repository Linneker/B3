using B3.API.Config;
using B3.API.Model.Enum;
using B3.API.Model.Interface;
using B3.API.Model.Taxation;

namespace B3.API.Model
{
    public class TaxFactory
    {
        private readonly Dictionary<MonthlyTax, Func<ITax>> _entityTypeMapper;

        public TaxFactory()
        {
            _entityTypeMapper = new Dictionary<MonthlyTax, Func<ITax>>();
            _entityTypeMapper.Add(MonthlyTax.UpToSix, () => new UpToSixMonths());
            _entityTypeMapper.Add(MonthlyTax.UpToTwelve, () => new UpToTwelveMonths());
            _entityTypeMapper.Add(MonthlyTax.UpToTwentyFour, () => new UpToTwentyFourMonths());
            _entityTypeMapper.Add(MonthlyTax.AboveTwentyFour, () => new AboveTwentyFourMonths());
        }

        public decimal GetTax(MonthlyTax entityType, decimal monetaryIncome)
        {
            if (_entityTypeMapper.TryGetValue(entityType, out var factory))
                return _entityTypeMapper[entityType]().Calculate(monetaryIncome);
            else
                throw new TaxException("Mês não contem uma a taxa");

        }

    }
}

