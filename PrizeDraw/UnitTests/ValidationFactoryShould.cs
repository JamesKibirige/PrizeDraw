using PrizeDraw;
using PrizeDraw.Validation;
using System.Collections.Generic;
using System.Linq;
using Xunit;
namespace UnitTests
{
    public class ValidationFactoryShould
    {
        [Theory]
        [MemberData(nameof(DayData))]
        public void CreateValidations_ValidCampaign_ReturnValidations(IEnumerable<IDay> days)
        {
            //Arrange
            var campaign = new Campaign
            (
                5,
                days
            );

            //Act
            var result = new ValidationFactory().CreateValidations(campaign).ToList();

            //Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Equal(23, result.Count);
        }

        public static IEnumerable<object[]> DayData()
        {
            yield return new object[]
            {
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
            };
        }
    }
}