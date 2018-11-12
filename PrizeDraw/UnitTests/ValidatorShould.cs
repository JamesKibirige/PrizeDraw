using Moq;
using PrizeDraw.Validation;
using System.Collections.Generic;
using Xunit;
namespace UnitTests
{
    public class ValidatorShould
    {
        [Fact]
        public void Validate_InvalidValidations_ReturnsFalse()
        {
            //Arrange
            var validation = Mock.Of<Validation>();
            Mock.Get(validation)
                .Setup(m => m.IsValid())
                .Returns(false);

            //Act
            var result = new Validator()
                .Validate
                (
                    new List<Validation>()
                    {
                        validation
                    }
                );

            //Assert
            Assert.False(result);
        }

        [Fact]
        public void Validate_ValidValidations_ReturnsTrue()
        {
            //Arrange
            var validation = Mock.Of<Validation>();
            Mock.Get(validation)
                .Setup(m => m.IsValid())
                .Returns(true);

            //Act
            var result = new Validator()
                .Validate
                (
                    new List<Validation>()
                    {
                        validation
                    }
                );

            //Assert
            Assert.True(result);
        }
    }
}