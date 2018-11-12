using PrizeDraw.Interfaces;

namespace PrizeDraw.Validation
{
    public class CampaignDurationMatchesDaySubmission: Validation
    {
        private readonly ICampaign _aCampaign;

        public CampaignDurationMatchesDaySubmission(ICampaign aCampaign)
        {
            _aCampaign = aCampaign;
        }

        public override bool IsValid()
        {
            var result = true;
            if (_aCampaign.Duration != _aCampaign.CountDays)
            {
                ValidationMessage = $"Campaign duration must match the number of Days that data has been input: Duration {_aCampaign.Duration}, Number days: {_aCampaign.CountDays}";
                result = false;
            }

            return result;
        }
    }
}