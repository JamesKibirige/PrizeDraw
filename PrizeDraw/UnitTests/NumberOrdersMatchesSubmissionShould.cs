using Moq;
using PrizeDraw.Interfaces;
using PrizeDraw.Validation;
using System.Collections.Generic;
using Xunit;
namespace UnitTests
{
    public class NumberOrdersMatchesSubmissionShould
    {
        [Theory]
        [MemberData(nameof(NumberOrdersNotMatchSubmission_Data))]
        public void IsValid_NumberOrdersNotMatchSubmission_ReturnsFalse(int numOrders, int countOrderAmounts)
        {
            //Arrange
            var day = Mock.Of<IDay>();

            Mock.Get(day)
                .Setup(m => m.NumberOrders)
                .Returns(numOrders);

            Mock.Get(day)
                .Setup(m => m.CountOrderAmounts)
                .Returns(countOrderAmounts);

            //Act
            var result = new NumberOrdersMatchesSubmission(day).IsValid();

            //Assert
            Assert.False(result);
        }

        [Theory]
        [MemberData(nameof(NumberOrdersMatchedSubmission_Data))]
        public void IsValid_NumberOrdersMatchedSubmission_ReturnsTrue(int numOrders, int countOrderAmounts)
        {
            //Arrange
            var day = Mock.Of<IDay>();

            Mock.Get(day)
                .Setup(m => m.NumberOrders)
                .Returns(numOrders);

            Mock.Get(day)
                .Setup(m => m.CountOrderAmounts)
                .Returns(countOrderAmounts);

            //Act
            var result = new NumberOrdersMatchesSubmission(day).IsValid();

            //Assert
            Assert.True(result);
        }

        public static IEnumerable<object[]> NumberOrdersNotMatchSubmission_Data()
        {
            yield return new object[] { 5, 0 };
            yield return new object[] { 2, 5 };
            yield return new object[] { 5, 10 };
        }

        public static IEnumerable<object[]> NumberOrdersMatchedSubmission_Data()
        {
            yield return new object[] { 5, 5 };
            yield return new object[] { 2, 2 };
            yield return new object[] { 10, 10 };
        }
    }
}