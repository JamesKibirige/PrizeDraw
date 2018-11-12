using Moq;
using PrizeDraw;
using PrizeDraw.Validation;
using System.Collections.Generic;
using Xunit;

namespace UnitTests
{
    public class CampaignDurationMatchesDaySubmissionShould
    {
        [Theory]
        [MemberData(nameof(CampaignDurationNotMatchDaySubmission_Data))]
        public void IsValid_CampaignDurationNotMatchSubmission_ReturnsFalse(int campaignDuration, int countCampaignDays)
        {
            //Arrange
            var day = Mock.Of<ICampaign>();

            Mock.Get(day)
                .Setup(m => m.Duration)
                .Returns(campaignDuration);

            Mock.Get(day)
                .Setup(m => m.CountDays)
                .Returns(countCampaignDays);

            //Act
            var result = new CampaignDurationMatchesDaySubmission(day).IsValid();

            //Assert
            Assert.False(result);
        }

        [Theory]
        [MemberData(nameof(CampaignDurationMatchedSubmission_Data))]
        public void IsValid_CampaignDurationMatchedSubmission_ReturnsTrue(int campaignDuration, int countCampaignDays)
        {
            //Arrange
            var day = Mock.Of<ICampaign>();

            Mock.Get(day)
                .Setup(m => m.Duration)
                .Returns(campaignDuration);

            Mock.Get(day)
                .Setup(m => m.CountDays)
                .Returns(countCampaignDays);

            //Act
            var result = new CampaignDurationMatchesDaySubmission(day).IsValid();

            //Assert
            Assert.True(result);
        }

        public static IEnumerable<object[]> CampaignDurationNotMatchDaySubmission_Data()
        {
            yield return new object[] { 5, 0 };
            yield return new object[] { 2, 5 };
            yield return new object[] { 15, 35 };
        }

        public static IEnumerable<object[]> CampaignDurationMatchedSubmission_Data()
        {
            yield return new object[] { 5, 5 };
            yield return new object[] { 2, 2 };
            yield return new object[] { 10, 10 };
        }
    }
}