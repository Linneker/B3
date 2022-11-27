using B3.API.Model;
using Bogus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B3.Test.Fixture
{
    [CollectionDefinition(nameof(ValueCalculateCollection))]
    public class ValueCalculateCollection : ICollectionFixture<ValueCalculateFixture>
    {

    }
    public class ValueCalculateFixture: IDisposable
    {
        public ValueCalculateFixture() { }

        public ValueCalculate GenerateValue(string local="pt_BR")
        {
            var elemento = new Faker<ValueCalculate>(local);
            elemento.RuleFor(t => t.InitialValue, _ => _.Random.Decimal(1, 2147483647));
            elemento.RuleFor(t => t.Month, _ => _.Random.Int(0,900));

            return elemento;
        }
        public void Dispose()
        {
            GC.Collect();
        }
    }
}
