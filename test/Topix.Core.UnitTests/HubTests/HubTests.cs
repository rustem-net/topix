using Xunit;
using Topix.Core.Base;

namespace Topix.Core.UnitTests.HubTests
{
    public class HubTests
    {
        [Fact]
        public void Hub_Always_AssertsTrue()
        {
            var hub = new HubBase();

            Assert.True(true);
        }
    }
}
