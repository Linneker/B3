using B3.Test.Fixture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace B3.Test.Integration
{
    [Collection(nameof(ValueCalculateCollection))]
    public class CaculationValueIntegration: IClassFixture<TestConfigurationFixture>
    {
        private readonly TestConfigurationFixture _testConfigurationFixture;
        private readonly ValueCalculateFixture _valueCalculateFixture;
     
        public CaculationValueIntegration(TestConfigurationFixture testConfigurationFixture, ValueCalculateFixture valueCalculateFixture) 
        {
            _testConfigurationFixture = testConfigurationFixture;
            _valueCalculateFixture = valueCalculateFixture;
        }

        [Fact(DisplayName = "Deve calcular com sucesso o valor informado")]
        [Trait("InvestmentCalculation", "Calcular o valor de rendimento")]
        public async Task InvestmentCalculation_RequestCalcElement_Success()
        {
            //Arrange
            var value = _valueCalculateFixture.GenerateValue();

            //Act
            var response = await _testConfigurationFixture.Client.PostAsJsonAsync($"api/InvestmentCalculation/Calculate", value);

            //Assert
            response.EnsureSuccessStatusCode();
        }
    }
}
