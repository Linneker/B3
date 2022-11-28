using B3.API.Config;
using B3.API.Model;
using B3.Test.Config;
using Xunit.Abstractions;

namespace B3.Test.Unit
{
    public class CaculationValueUnit
    {
        private readonly ITestOutputHelper _testOutputHelper;

        public CaculationValueUnit(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
        }

        [Theory(DisplayName = "Calcula rendimentos")]
        [CsvTestData("data.csv")]
        [Trait("RescueFinancial", "Deve realizar o calculo do valor bruto e liquido até 6 meses")]
        public void RescueFinancial_MonthGreaterThanZero_ValueAssert(decimal initalValue, int month, decimal grossAmount, decimal netAmount)
        {

            //Arrage
            _testOutputHelper.WriteLine("Iniciando o teste para calcular valor bruto e liquido!");
            _testOutputHelper.WriteLine("-------------------");
            _testOutputHelper.WriteLine("Dados fornecidos:");
            _testOutputHelper.WriteLine($"Valor Inicial: {initalValue}");
            _testOutputHelper.WriteLine($"Periodo do investimento em mês: {month}");
            _testOutputHelper.WriteLine("-------------------");

            RescueFinancialCommand rescueFinancialCommand = new RescueFinancialCommand(initalValue, month);

            //Act Assert
            _testOutputHelper.WriteLine("Valores esperados:");
            _testOutputHelper.WriteLine($"Valor Bruto: {grossAmount}");
            _testOutputHelper.WriteLine($"Valor Liquido: {netAmount}");
            _testOutputHelper.WriteLine("-------------------");
            _testOutputHelper.WriteLine("Valores calculados:");
            _testOutputHelper.WriteLine($"Valor Bruto: {rescueFinancialCommand.GrossAmount}");
            _testOutputHelper.WriteLine($"Valor Liquido: {rescueFinancialCommand.NetAmount}");
            _testOutputHelper.WriteLine("-------------------");

            Assert.Equal(rescueFinancialCommand.GrossAmount, grossAmount, 2);
            Assert.Equal(rescueFinancialCommand.NetAmount, netAmount, 2);

            _testOutputHelper.WriteLine("Fim do teste para calcular valor bruto e liqueido!");

        }

        [Theory(DisplayName = "Lançar exceção")]
        [InlineData(1000, 0)]
        [InlineData(1000, -1)]
        [Trait("RescueFinancial", "Deve lançar uma excessão ao tentar converter mêses")]
        public void RescueFinancial_MonthLessThanZero_Throw(decimal initalValue, int month)
        {
            _testOutputHelper.WriteLine("Iniciando o teste para excessão EnumException!");
            _testOutputHelper.WriteLine("-------------------");

            _testOutputHelper.WriteLine("Dados fornecidos:");
            _testOutputHelper.WriteLine($"Valor Inicial: {initalValue}");
            _testOutputHelper.WriteLine($"Periodo do investimento em mês: {month}");
            _testOutputHelper.WriteLine("-------------------");

            //Arrage Act Assert
            var excessao = Assert.Throws<EnumException>(() => new RescueFinancialCommand(initalValue, month));
            _testOutputHelper.WriteLine($"Excessão {excessao.Message}!");
            _testOutputHelper.WriteLine("-------------------");

            _testOutputHelper.WriteLine("Fim do teste para excessão EnumException!");

        }


    }
}
