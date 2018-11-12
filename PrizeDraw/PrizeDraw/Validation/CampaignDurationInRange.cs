using System;

namespace PrizeDraw.Validation
{
    public class CampaignDurationInRange: Validation
    {
        private readonly int _low;
        private readonly int _high;
        private readonly ICampaign _aCampaign;

        public CampaignDurationInRange(int low, int high, ICampaign aCampaign)
        {
            _low = low;
            _high = high;
            _aCampaign = aCampaign;
        }

        public override bool IsValid()
        {
            if (_low >= _high)
            {
                throw new ArgumentOutOfRangeException($"Error during {GetType()} Validation, Invalid Range specified {nameof(_low)}: {_low}, {nameof(_high)}: {_high}. {nameof(_low)} must be less than {nameof(_high)}");
            }

            var result = true;

            if (!(_aCampaign.Duration >= _low && _aCampaign.Duration <= _high))
            {
                ValidationMessage = $"Campaign duration Out of range: {_aCampaign.Duration} is outside of range {_low} to {_high}";
                result = false;
            }

            return result;
        }
    }
}