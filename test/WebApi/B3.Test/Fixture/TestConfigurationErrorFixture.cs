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
    public class TestConfigurationErrorFixture : IDisposable
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
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                Client.Dispose();
                Factory.Dispose();
            }

        }
    }
}
