using PrizeDraw;
using PrizeDraw.Validation;
using System.Collections.Generic;
using Xunit;

namespace UnitTests
{
    public class AmountInRangeShould
    {
        [Theory]
        [MemberData(nameof(OutOfRangeAmountData))]
        public void IsValid_AmountOutOfRange_ReturnsFalse(int amountLimit, IEnumerable<int> orderAmounts)
        {
            //Arrange
            //Act
            var result = new AmountInRange
            (
                amountLimit,
                new Day(0, 4, orderAmounts)
            ).IsValid();

            //Assert
            Assert.False(result);
        }

        [Theory]
        [MemberData(nameof(InRangeAmountData))]
        public void IsValid_AmountInRange_ReturnsTrue(int amountLimit, IEnumerable<int> orderAmounts)
        {
            //Arrange
            //Act
            var result = new AmountInRange
            (
                amountLimit,
                new Day(0,4, orderAmounts)
            ).IsValid();

            //Assert
            Assert.True(result);
        }

        public static IEnumerable<object[]> OutOfRangeAmountData()
        {
            yield return new object[]
            {
                5,
                new List<int>() {6, 10, 7, 9}
            };
        }

        public static IEnumerable<object[]> InRangeAmountData()
        {
            yield return new object[]
            {
                15,
                new List<int>() {6, 10, 7, 9}
            };
        }
    }
}