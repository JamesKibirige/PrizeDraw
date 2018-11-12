using FluentAssertions;
using PrizeDraw.Models;
using PrizeDraw.Validation;
using System;
using System.Collections.Generic;
using Xunit;
namespace UnitTests
{
    public class NumberOrdersInRangeShould
    {
        [Theory]
        [MemberData(nameof(InvalidRangeData))]
        public void IsValid_InvalidRange_ThrowsArgumentOutOfRangeException(int low, int high)
        {
            //Arrange
            //Act
            Action a = () => new NumberOrdersInRange
            (
                low,
                high,
                new Day(0, 5, new List<int>())
            ).IsValid();

            //Assert
            a.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Theory]
        [MemberData(nameof(OutOfRangeNumberOrdersData))]
        public void IsValid_NumberOrdersOutOfRange_ReturnsFalse(int low, int high, int numberOrders)
        {
            //Arrange
            //Act
            var result = new NumberOrdersInRange
            (
                low,
                high,
                new Day
                (
                    0,
                    numberOrders, new List<int>()
                )
            ).IsValid();

            //Assert
            Assert.False(result);
        }

        [Theory]
        [MemberData(nameof(InRangeNumberOrdersData))]
        public void IsValid_NumberOrdersInRange_ReturnsTrue(int low, int high, int numberOrders)
        {
            //Arrange
            //Act
            var result = new NumberOrdersInRange
            (
                low,
                high,
                new Day
                (
                    0,
                    numberOrders, new List<int>()
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

        public static IEnumerable<object[]> OutOfRangeNumberOrdersData()
        {
            yield return new object[] { 0, 100, 105};
            yield return new object[] { 0, 100, -5 };
        }

        public static IEnumerable<object[]> InRangeNumberOrdersData()
        {
            yield return new object[] { 0, 100, 50 };
            yield return new object[] { 0, 50, 25 };
        }
    }
}