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
            // Arrange
            var payload = new Payload(new MockCsvDataProvider());

            // Act
            var addressDictionary = payload.LoadAddressDictionary();

            // Assert
            Assert.NotNull(addressDictionary);
            Assert.True(addressDictionary.Count > 0);
        }

        [Fact]
        public void LoadQuadTree_ConstructsValidQuadTree()
        {
            // Arrange
            var payload = new Payload(new MockCsvDataProvider());

            // Act
            var quadTree = payload.LoadQuadTree();

            // Assert
            Assert.NotNull(quadTree); 
        }

    }
}
