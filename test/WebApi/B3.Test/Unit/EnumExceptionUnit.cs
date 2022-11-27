using B3.API.Config;
using B3.API.Model;
using B3.API.Model.Enuns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit.Abstractions;

namespace B3.Test.Unit
{
    public class EnumExceptionUnit
    {
        private readonly ITestOutputHelper _testOutputHelper;

        public EnumExceptionUnit(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
        }

        [Fact(DisplayName ="Gerar Excessão de Imposto")]
        [Trait("RescueFinancial", "Deve lançar uma excessão ao tentar converter mêses")]
        public void TaxException_GenenationExption_Sucess()
        {
            //Arrage Act Assert
            var excessao = Assert.Throws<TaxException>(() => new TaxFactoryCommand().GetTax(MonthlyTax.ForceError, 1000));
            _testOutputHelper.WriteLine($"Excessão {excessao.Message}!");

        }
    }
}
