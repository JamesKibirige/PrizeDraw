using PrizeDraw.Interfaces;

namespace PrizeDraw.Validation
{
    public class CampaignTotalOrdersInRange: Validation
    {
        private readonly int _totalOrderLimit;
        private readonly ICampaign _aCampaign;

        public CampaignTotalOrdersInRange(ICampaign aCampaign, int totalOrderLimit)
        {
            _aCampaign = aCampaign;
            _totalOrderLimit = totalOrderLimit;
        }

        public override bool IsValid()
        {
            var result = true;

            if (!(_aCampaign.TotalOrders <= _totalOrderLimit))
            {
                ValidationMessage = $"Campaign TotalOrders is Out of range: {_aCampaign.TotalOrders} is greater than the limit {_totalOrderLimit}";
                result = false;
            }

            return result;
        }
    }
}