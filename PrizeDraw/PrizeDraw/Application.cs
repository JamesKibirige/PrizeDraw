using System;
using System.IO;
using System.Threading.Tasks;
using PrizeDraw.Interfaces;

namespace PrizeDraw
{
    public class Application : IApplication
    {
        private readonly ICampaignReader _inputReader;
        private readonly IValidationFactory _validationFactory;
        private readonly IValidator _validator;
        private readonly IPrizeMoneyCalculator _prizeMoneyCalculator;

        public Application
        (
            ICampaignReader inputReader,
            IValidationFactory validationFactory,
            IValidator validator,
            IPrizeMoneyCalculator prizeMoneyCalculator
        )
        {
            _inputReader = inputReader;
            _validationFactory = validationFactory;
            _validator = validator;
            _prizeMoneyCalculator = prizeMoneyCalculator;
        }

        public async Task Run()
        {
            //1.    Read Campaign Input Data
            var campaign = await _inputReader.ReadCampaignInputData();

            //2.    Generate Validations based on Campaign data
            var validations = _validationFactory.CreateValidations(campaign);

            //2.    Validate Campaign Data
            if (!_validator.Validate(validations))
            {
                throw new InvalidDataException(_validator.ValidationMessage);
            }

            //3.    Calculate and return Total prize money for campaign
            Console.WriteLine
            (
                _prizeMoneyCalculator.CalculatePrizeMoney(campaign)
            );
        }
    }
}