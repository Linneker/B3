using B3.Test.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B3.Test.Fixture
{
    [CollectionDefinition(nameof(TesteFixtureErrorConfigurationCollection))]
    public class TesteFixtureErrorConfigurationCollection : ICollectionFixture<TestConfigurationErrorFixture>
    {

    }
    public class TestConfigurationErrorFixture
    {
        public readonly TestIntegrationFactory Factory;
        public HttpClient Client;

        public TestConfigurationErrorFixture()
        {
            Factory = new TestIntegrationFactory();
            Client = Factory.CreateClient();
            Client.DefaultRequestHeaders.Add("Key", "");
        }

        public void Dispose()
        {
            Client.Dispose();
            Factory.Dispose();
        }

    }
}
