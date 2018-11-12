using FluentAssertions;
using Moq;
using PrizeDraw;
using PrizeDraw.CompositionRoot;
using PrizeDraw.Interfaces;
using PrizeDraw.Validation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
namespace UnitTests
{
    public class ApplicationShould
    {
        [Fact]
        public async Task Run_ValidCampaignData_VerifyCollaborators()
        {
            //Arrange
            var reader = Mock.Of<ICampaignReader>();
            var validationFactory = Mock.Of<IValidationFactory>();
            var validator = Mock.Of<IValidator>();
            var calculator = Mock.Of<IPrizeMoneyCalculator>();

            ICampaign result = new Campaign(5, new List<IDay>());
            Mock.Get(reader).Setup(m => m.ReadCampaignInputData())
                .Returns
                (
                    Task.FromResult
                    (
                        result
                    )
                );
            Mock.Get(validationFactory).Setup(m => m.CreateValidations(It.IsAny<ICampaign>()))
                .Returns
                (
                    Enumerable.Empty<Validation>()
                );
            Mock.Get(validator).Setup(m => m.Validate(It.IsAny<IEnumerable<Validation>>()))
                .Returns
                (
                    true
                );
            Mock.Get(calculator).Setup(m => m.CalculatePrizeMoney(It.IsAny<ICampaign>()))
                .Returns
                (
                    20
                );

            //Act
            await new Application(reader, validationFactory, validator, calculator).Run();

            //Assert
            Mock.Get(reader).Verify(m => m.ReadCampaignInputData());
            Mock.Get(validationFactory).Verify(m => m.CreateValidations(It.IsAny<ICampaign>()));
            Mock.Get(validator).Verify(m => m.Validate(It.IsAny<IEnumerable<Validation>>()));
            Mock.Get(calculator).Verify(m => m.CalculatePrizeMoney(It.IsAny<ICampaign>()));
        }

        [Fact]
        public void Run_InvalidCampaignData_ThrowsInvalidDataException()
        {
            //Arrange
            var reader = Mock.Of<ICampaignReader>();
            var validationFactory = Mock.Of<IValidationFactory>();
            var validator = Mock.Of<IValidator>();
            var calculator = Mock.Of<IPrizeMoneyCalculator>();

            Mock.Get(validator).Setup(m => m.Validate(It.IsAny<IEnumerable<Validation>>()))
                .Returns
                (
                    false
                );

            //Act
            Func<Task> a = async () => await new Application(reader, validationFactory, validator, calculator).Run();

            //Assert
            a.Should().Throw<InvalidDataException>();
        }
    }
}