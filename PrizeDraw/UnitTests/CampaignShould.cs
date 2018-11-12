using PrizeDraw;
using PrizeDraw.Models;
using System.Collections.Generic;
using Xunit;
namespace UnitTests
{
    public class CampaignShould
    {
        [Theory]
        [MemberData(nameof(DayTestData))]
        public void TotalOrders_SumNumberOrders_CorrectTotal(IEnumerable<Day> days)
        {
            //Arrange
            //Act
            var result = new Campaign
            (
                4,
                days
            ).TotalOrders;

            //Assert
            Assert.Equal(17, result);
        }

        public static IEnumerable<object[]> DayTestData()
        {
            yield return new object[]
            {
                new[]
                {
                    new Day(0,3,new List<int>()),
                    new Day(1,5,new List<int>()),
                    new Day(2,2,new List<int>()),
                    new Day(3,7,new List<int>()),
                }
            };
        }
    }
}