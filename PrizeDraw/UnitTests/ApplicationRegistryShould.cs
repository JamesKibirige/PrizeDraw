using Lamar;
using PrizeDraw.IoC;
using Xunit;
namespace UnitTests
{
    public class ApplicationRegistryShould
    {
        [Fact]
        public void HaveValidConfiguration()
        {
            //Arrange
            var registry = new ApplicationRegistry();

            //Act
            var container = new Container(registry);

            //Assert
            container.AssertConfigurationIsValid();
        }
    }
}