using PrizeDraw.Interfaces;

namespace PrizeDraw.Validation
{
    public class AmountInRange: Validation
    {
        private readonly int _orderAmountLimit;
        private readonly IDay _aDay;

        public AmountInRange(int orderAmountLimit, IDay aDay)
        {
            _orderAmountLimit = orderAmountLimit;
            _aDay = aDay;
        }

        public override bool IsValid()
        {
            var result = true;
            foreach (var amount in _aDay.OrderAmounts)
            {
                if (!(amount <= _orderAmountLimit))
                {
                    ValidationMessage = $"OrderAmount Out of range: Day: {_aDay.Index} OrderAmount {amount} is larger than the limit {_orderAmountLimit}";
                    result = false;
                }
            }

            return result;
        }
    }
}