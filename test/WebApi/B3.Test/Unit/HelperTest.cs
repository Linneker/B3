using B3.API.Config;
using B3.API.Helper;
using B3.API.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B3.Test.Unit
{
    public class HelperTest
    {
        
        [Fact(DisplayName = "Validando Taxas")]
        [Trait("InvestmentHelper", "Deve validar CDI")]
        public void InvestmentHelper_ValidarCDI_Sucess()
        {
            //Arrage Act Assert
            Assert.Equal(0.009M, InvestmentHelper.CDI, 3);

        }
        [Fact(DisplayName = "Validando Taxas")]
        [Trait("InvestmentHelper", "Deve validar TB")]
        public void InvestmentHelper_ValidarTB_Sucess()
        {
            //Arrage Act Assert
            Assert.Equal(1.08M, InvestmentHelper.TB, 3);

        }

    }
}
