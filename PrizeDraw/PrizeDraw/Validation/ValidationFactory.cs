using PrizeDraw.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace PrizeDraw.Validation
{
    public class ValidationFactory: IValidationFactory
    {
        private int _validationOrder;
        public IEnumerable<Validation> CreateValidations(ICampaign campaign)
        {
            _validationOrder = 0;
            var validations = new List<Validation>();
            validations.Add(GetCampaignDurationInRangeValidation(campaign));
            validations.Add(GetCampaignDurationMatchesDaySubmissionValidation(campaign));
            validations.AddRange(GetNumberOrdersInRangeValidations(campaign));
            validations.AddRange(GetNumberOrdersMatchesSubmissionValidation(campaign));
            validations.AddRange(GetAmountInRangeValidations(campaign));
            validations.Add(GetCampaignTotalOrdersInRangeValidation(campaign));

            return validations;
        }

        private Validation GetCampaignDurationInRangeValidation(ICampaign campaign)
        {
            return new CampaignDurationInRange(1, 5000, campaign)
            {
                Order = _validationOrder + 1
            };
        }

        private Validation GetCampaignDurationMatchesDaySubmissionValidation(ICampaign campaign)
        {
            return new CampaignDurationMatchesDaySubmission(campaign)
            {
                Order = _validationOrder + 1
            };
        }

        private IEnumerable<Validation> GetNumberOrdersInRangeValidations(ICampaign campaign)
        {
            return campaign.Days.Select
            (
                day => new NumberOrdersInRange(0, 100000, day)
                {
                    Order = _validationOrder + 1
                }
            );
        }

        private IEnumerable<Validation> GetNumberOrdersMatchesSubmissionValidation(ICampaign campaign)
        {
            return campaign.Days.Select
            (
                day => new NumberOrdersMatchesSubmission(day)
                {
                    Order = _validationOrder + 1
                }
            );
        }

        private IEnumerable<Validation> GetAmountInRangeValidations(ICampaign campaign)
        {
            return
            (
                from day in campaign.Days
                from orderAmount in day.OrderAmounts
                select new AmountInRange(1000000, day)
                {
                    Order = _validationOrder + 1
                }
            );
        }

        private Validation GetCampaignTotalOrdersInRangeValidation(ICampaign campaign)
        {
            return new CampaignTotalOrdersInRange(campaign, 1000000)
            {
                Order = _validationOrder + 1
            };
        }
    }
}