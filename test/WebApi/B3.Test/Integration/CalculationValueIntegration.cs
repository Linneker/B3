using B3.API.Config;
using B3.API.Model;
using B3.Test.Config;
using B3.Test.Fixture;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace B3.Test.Integration
{
    [Collection(nameof(ValueCalculateCollection))]
    public class CalculationValueIntegration: IClassFixture<TestConfigurationFixture>
    {
        private readonly TestConfigurationFixture _testConfigurationFixture;
        private readonly ValueCalculateFixture _valueCalculateFixture;
     
        public CalculationValueIntegration(TestConfigurationFixture testConfigurationFixture, ValueCalculateFixture valueCalculateFixture) 
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
            HttpResponseMessage response = await _testConfigurationFixture.Client.GetAsync($"api/InvestmentCalculation/Calculate/{value.InitialValue}/{value.Month}");

            //Assert
            Assert.True(response.IsSuccessStatusCode);
        }


        [Fact(DisplayName = "Não seve calcular o valor informado")]
        [Trait("InvestmentCalculation", "Não calcular o valor de rendimento")]
        public async Task InvestmentCalculation_RequestCalcElement_Error()
        {
            //Arrange
            var value = _valueCalculateFixture.GenerateValueError();

            //Act
            HttpResponseMessage response = await _testConfigurationFixture.Client.GetAsync($"api/InvestmentCalculation/Calculate/{value.InitialValue}/{value.Month}");

            //Assert
            Assert.True(response.StatusCode == System.Net.HttpStatusCode.BadRequest);
        }


        [Fact(DisplayName = "Deve dar erro com Elemento Initial Nulo")]
        [Trait("InvestmentCalculation", "Não calcular o valor de rendimento")]
        public async Task InvestmentCalculation_RequestCalcElementInitialValueNull_Error()
        {
            //Arrange
            var value = _valueCalculateFixture.GenerateValueErrorZero();

            //Act
            HttpResponseMessage response = await _testConfigurationFixture.Client.GetAsync($"api/InvestmentCalculation/Calculate/ABC/{value.Month}");

            //Assert
            Assert.True(response.StatusCode == System.Net.HttpStatusCode.BadRequest);
        }
        [Fact(DisplayName = "Deve dar erro com Elemento Initial Nulo")]
        [Trait("InvestmentCalculation", "Não calcular o valor de rendimento")]
        public async Task InvestmentCalculation_RequestCalcElementInitialValueZero_Error()
        {
            //Arrange
            var value = _valueCalculateFixture.GenerateValueErrorZero();
            
            //Act
            HttpResponseMessage response = await _testConfigurationFixture.Client.GetAsync($"api/InvestmentCalculation/Calculate/{value.InitialValue}/{value.Month}");

            //Assert
            Assert.True(response.StatusCode == System.Net.HttpStatusCode.BadRequest);
        }
        [Fact(DisplayName = "Não seve calcular o valor informado")]
        [Trait("InvestmentCalculation", "Não calcular o valor de rendimento")]
        public async Task InvestmentCalculation_RequestCalcElementMonthNull_Error()
        {
            //Arrange
            var value = _valueCalculateFixture.GenerateValueErrorZero();

            //Act
            HttpResponseMessage response = await _testConfigurationFixture.Client.GetAsync($"api/InvestmentCalculation/Calculate/{value.InitialValue}/ERRO");

            //Assert
            Assert.True(response.StatusCode == System.Net.HttpStatusCode.BadRequest);
        }


    }
}
