using Moq;
using PrizeDraw.Interfaces;
using PrizeDraw.Validation;
using Xunit;
namespace UnitTests
{
    public class CampaignTotalOrdersInRangeShould
    {
        [Fact]
        public void IsValid_TotalOrdersOutOfRange_ReturnsFalse()
        {
            //Arrange
            var campaign = Mock.Of<ICampaign>();
            Mock.Get(campaign)
                .Setup(m => m.TotalOrders)
                .Returns(305);

            //Act
            var result = new CampaignTotalOrdersInRange(campaign, 300).IsValid();

            //Assert
            Assert.False(result);
        }

        [Fact]
        public void IsValid_TotalOrdersInRange_ReturnsTrue()
        {
            //Arrange
            var campaign = Mock.Of<ICampaign>();
            Mock.Get(campaign)
                .Setup(m => m.TotalOrders)
                .Returns(200);

            //Act
            var result = new CampaignTotalOrdersInRange(campaign, 300).IsValid();

            //Assert
            Assert.True(result);
        }
    }
}