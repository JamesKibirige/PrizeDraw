using FluentAssertions;
using PrizeDraw;
using PrizeDraw.Models;
using PrizeDraw.Validation;
using System;
using System.Collections.Generic;
using Xunit;
namespace UnitTests
{
    public class CampaignDurationInRangeShould
    {
        [Theory]
        [MemberData(nameof(InvalidRangeData))]
        public void IsValid_InvalidRange_ThrowsArgumentOutOfRangeException(int low, int high)
        {
            //Arrange
            //Act
            Action a = () => new CampaignDurationInRange
            (
                low,
                high,
                new Campaign
                (
                    5,
                    new List<Day>()
                )
            ).IsValid();

            //Assert
            a.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Theory]
        [MemberData(nameof(OutOfRangeCampaignDurationData))]
        public void IsValid_CampaignDurationOutOfRange_ReturnsFalse(int low, int high, int campaignDuration)
        {
            //Arrange
            //Act
            var result = new CampaignDurationInRange
            (
                low,
                high,
                new Campaign
                (
                    campaignDuration,
                    new List<Day>()
                )
            ).IsValid();

            //Assert
            Assert.False(result);
        }

        [Theory]
        [MemberData(nameof(InRangeCampaignDurationData))]
        public void IsValid_CampaignDurationInRange_ReturnsTrue(int low, int high, int campaignDuration)
        {
            //Arrange
            //Act
            var result = new CampaignDurationInRange
            (
                low,
                high,
                new Campaign
                (
                    campaignDuration,
                    new List<Day>()
                )
            ).IsValid();

            //Assert
            Assert.True(result);
        }

        public static IEnumerable<object[]> InvalidRangeData()
        {
            yield return new object[] { 1,1 };
            yield return new object[] { 20,5 };
        }

        public static IEnumerable<object[]> OutOfRangeCampaignDurationData()
        {
            yield return new object[] { 0, 100, 105};
            yield return new object[] { 0, 100, -5 };
        }

        public static IEnumerable<object[]> InRangeCampaignDurationData()
        {
            yield return new object[] { 0, 100, 50 };
            yield return new object[] { 0, 50, 25 };
        }
    }
}