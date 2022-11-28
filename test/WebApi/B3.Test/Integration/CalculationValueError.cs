using B3.Test.Fixture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B3.Test.Integration
{
    [Collection(nameof(ValueCalculateCollection))]
    public class CalculationValueError : IClassFixture<TestConfigurationErrorFixture>
    {
        private readonly TestConfigurationErrorFixture _testConfigurationFixture;
        private readonly ValueCalculateFixture _valueCalculateFixture;

        public CalculationValueError(TestConfigurationErrorFixture testConfigurationFixture, ValueCalculateFixture valueCalculateFixture)
        {
            _testConfigurationFixture = testConfigurationFixture;
            _valueCalculateFixture = valueCalculateFixture;
        }

        [Fact(DisplayName = "Deve calcular erro 401")]
        [Trait("InvestmentCalculation", "Calcular o valor de rendimento")]
        public async Task InvestmentCalculation_RequestCalcElement_Success()
        {
            //Arrange
            var value = _valueCalculateFixture.GenerateValue();

            //Act
            HttpResponseMessage response = await _testConfigurationFixture.Client.GetAsync($"api/InvestmentCalculation/Calculate/{value.InitialValue}/{value.Month}");

            //Assert
            Assert.True(response.StatusCode == System.Net.HttpStatusCode.Unauthorized);
        }
    }
}
