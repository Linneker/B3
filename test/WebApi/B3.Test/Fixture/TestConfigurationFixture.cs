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
            Client.DefaultRequestHeaders.Add("Key", "MIIEowIBAAKCAQEAxyVBOmPABNg34FKmRxESerhSf7GLjJuupyOflhAZpatuRK3vAON4UqIHS0drci2CgeKlyJxEJEgwf9gKoOhHfwZ0lJAr89me0Ks8ag0exJ7xZBBiPtijfoqChOuxKFvKkKSy+g2jVcmCtWYOxlgh58PdFE098dyKoWC3nwXF/B6IIjWBo7rOnj8xnScXgLve0U8s8L8kwBoq2uXPHFLQH5J3MKZThntdrkLTHHWU5PYajwbXl615rnV8ClPfwIuF9F2ePPyF+ck6vM3vx5sbuMPMKIcq1oBAqianIoFkHcLS2jlXynX5cAobS/c9LQ9Xqv3U1weHUtnG922raD7/8QIDAQABAoIBAQCMsAIL2Qp/oayf2mPD0wjGD8+gjHJ0zEsvotgMMKWdx6Vn+aTecNTBM9yJTxRWHlaToeXS+qqdIy64Mo0XreFMmOflSJD0fapX6pEMruYsq8kHExgFJBEkxX99nfCS/X32f5Q9WUMpyOmBc28+qmaRkGpv/D2lz1NUvLocKvz6pewpGETQBun63Dv8h0ty02qjDr3Pun8R+Ox7fxITm6chHXwAJ1vYgk4uhNE0YBVoKOWju5ZmHQCxjT1Ns463yyf3GRRoFcn7oG995S9/E9xvc2zWgkECt7XDi3ax51QSQDjhg7avhHL+IbB52zGYZzOR+6F/gIolKBgiEEsRbx09AoGBAOK2GLLH1NE/7ZqNvlHKOfp7FVIbSc5gHb/pI6hpgnAy5k95cHnlTEnETXPpiG+y3U28v32xJOOEiZzv32lutHhv68ZyKiwH6rmS5i15TZa7eTPNESp6JKlh8lTvg+0948HHC8mJUYPvY+NwclXxxYFYFkmpIDz7U284oaiScz9zAoGBAODffVVI/heARGz71BtVRpq+u5bG4ag0pcbpF0mtsJgIByfEdkhkkMr6aeLmU+LQvFXInL6eMoNtcJMvyw3K06z9yjsuHB33aDz5jbZqncNXYt34orr6xIAzkV85YFP1ncr4fYka/VpmfIvT3lNkWwF5KnvlSYrFTT2E4YOCKiILAoGAcH/eJ7FD6QYpGN2niJyqQqKbROAnstI9UQMW37ZjtNt9MAjaCJMBVUWlDZTgUFVYvf+gonWqEYCubQMXQRFfWrhnLlVumeTf1HCR6hTcrKShE1R6ZTKxSKBDCWTFeY+RmpH0RnDu02KSlcUx53YPBQ06Ghlj1v78Ox/GEImDyQMCgYBplSWwzIPZHvWBwj/V0ZVEBPfpFFpRct6/ZSP1CSNYTrSlXF45IVbGpwreaUzLuzwifv3xli+be+AWi6MoR6pZmBPC86RqAYck0ftSwf5vAHHATQSDDEkE9LF152euJC3BZijzHgQE1Qf3UzQZLY55Q53J7F86U+cvUlvcNlp3/wKBgF7qaOjNcbz1Y5AIDIGm3kSgkqsXf2OU03qxAMt2nA/hPeRQf2I4Q0DaGP406tV3Z4/PLUE+dsV/Y33cvTp0Id83cLiA1X4uwFufEa8EN0vdpaiT13nSomh5rh5fflOcJ9JvBET9rZ5Cn4BTkm2zp4BAfqU+veAXunDInJLTecFA");
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
