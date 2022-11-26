using B3.API.Config;
using B3.API.Model;
using B3.Test.Config;
using Xunit.Abstractions;

namespace B3.Test
{

    public class CaculationValue
    {
        private readonly ITestOutputHelper _testOutputHelper;

        public CaculationValue(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
        }

        [Theory(DisplayName = "Calcula rendimentos")]
        [CsvTestData("data.csv")]
        [Trait("RescueFinancial", "Deve realizar o calculo do valor bruto e liquido até 6 meses")]
        public void RescueFinancial_MonthGreaterThanZero_ValueAssert(decimal initalValue, int month, decimal grossAmount, decimal netAmount)
        {
            //Arrage
            _testOutputHelper.WriteLine("Iniciando calulo!");
            RescueFinancialCommand rescueFinancialCommand = new RescueFinancialCommand(initalValue, month);

            //Act Assert
            Assert.Equal(rescueFinancialCommand.GrossAmount, grossAmount, 2);
            Assert.Equal(rescueFinancialCommand.NetAmount, netAmount, 2);

        }

        [Theory(DisplayName = "Lançar exceção")]
        [InlineData(1000, 0)]
        [InlineData(1000, -1)]
        [Trait("RescueFinancial", "Deve lançar uma excessão ao tentar converter mêses")]
        public void RescueFinancial_MonthLessThanZero_Throw(decimal initalValue, int month)
        {
            _testOutputHelper.WriteLine("Excessão!");

            //Arrage Act Assert
            Assert.Throws<EnumExcaption>(() => new RescueFinancialCommand(initalValue, month));

        }
    }
}
