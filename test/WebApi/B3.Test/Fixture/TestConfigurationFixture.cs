using B3.Test.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B3.Test.Fixture
{

    [CollectionDefinition(nameof(TesteFixtureConfigurationCollection))]
    public class TesteFixtureConfigurationCollection : ICollectionFixture<TestConfigurationFixture>
    {

    }
    public class TestConfigurationFixture : IDisposable
    {

        public readonly TestIntegrationFactory Factory;
        public HttpClient Client;

        public TestConfigurationFixture()
        {
            Factory = new TestIntegrationFactory();
            Client = Factory.CreateClient();
        }

        public void Dispose()
        {
            Client.Dispose();
            Factory.Dispose();
        }

    }
}
