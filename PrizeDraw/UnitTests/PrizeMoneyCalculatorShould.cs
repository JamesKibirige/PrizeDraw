using PrizeDraw;
using PrizeDraw.Interfaces;
using PrizeDraw.Models;
using System.Collections.Generic;
using System.Linq;
using Xunit;
namespace UnitTests
{
    public class PrizeMoneyCalculatorShould
    {
        [Theory]
        [MemberData(nameof(Campaign_Data))]
        public void CalculatePrizeMoney_ValidCampaign_ExpectedTotalPrizeMoney(ICampaign campaign)
        {
            //Arrange
            //Act
            var result = new PrizeMoneyCalculator().CalculatePrizeMoney(campaign);

            //Assert
            Assert.Equal(19, result);
        }

        public static IEnumerable<object[]> Campaign_Data()
        {

            yield return new object[]
            {
                new Campaign
                (
                    5,
                    new List<IDay>()
                    {
                        new Day
                        (
                            0,
                            3,
                            new List<int>() {1, 2, 3}
                        ),
                        new Day
                        (
                            1,
                            2,
                            new List<int>() {1, 1}
                        ),
                        new Day
                        (
                            2,
                            4,
                            new List<int>() {10, 5, 5, 1}
                        ),
                        new Day
                        (
                            3,
                            0,
                            Enumerable.Empty<int>()
                        ),
                        new Day
                        (
                            4,
                            1,
                            new List<int>() {2}
                        )
                    }
                )
            };
        }
    }
}