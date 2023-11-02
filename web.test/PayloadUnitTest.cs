using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using web.app.utilities;

namespace web.test
{
    public class PayloadUnitTest
    {
        [Fact]
        public void LoadAddressDictionary_ReturnsValidDictionary()
        {
            var payload = new Payload(new MockCsvDataProvider());

            var addressDictionary = payload.LoadAddressDictionary();

            Assert.NotNull(addressDictionary);
            Assert.True(addressDictionary.Count > 0);
        }

        [Fact]
        public void LoadQuadTree_ConstructsValidQuadTree()
        {
            var payload = new Payload(new MockCsvDataProvider());

            var quadTree = payload.LoadQuadTree();

            Assert.NotNull(quadTree); 
        }

    }
}
