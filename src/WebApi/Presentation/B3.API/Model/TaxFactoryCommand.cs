using B3.API.Config;
using B3.API.Model.Enuns;
using B3.API.Model.Interface;
using B3.API.Model.Taxation;

namespace B3.API.Model
{
    public class TaxFactoryCommand
    {
        private readonly Dictionary<MonthlyTax, Func<ITaxCommand>> _entityTypeMapper;

        public TaxFactoryCommand()
        {
            _entityTypeMapper = new Dictionary<MonthlyTax, Func<ITaxCommand>>();
            _entityTypeMapper.Add(MonthlyTax.UpToSix, () => new UpToSixMonthsCommand());
            _entityTypeMapper.Add(MonthlyTax.UpToTwelve, () => new UpToTwelveMonthsCommand());
            _entityTypeMapper.Add(MonthlyTax.UpToTwentyFour, () => new UpToTwentyFourMonthsCommand());
            _entityTypeMapper.Add(MonthlyTax.AboveTwentyFour, () => new AboveTwentyFourMonthsCommand());
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

