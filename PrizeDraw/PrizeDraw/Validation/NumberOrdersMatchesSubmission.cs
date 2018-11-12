using PrizeDraw.Interfaces;

namespace PrizeDraw.Validation
{
    public class NumberOrdersMatchesSubmission: Validation
    {
        private readonly IDay _aDay;

        public NumberOrdersMatchesSubmission(IDay aDay)
        {
            _aDay = aDay;
        }

        public override bool IsValid()
        {
            var result = true;
            if (_aDay.NumberOrders != _aDay.CountOrderAmounts)
            {
                ValidationMessage =
                    $"The Number of Orders for day: {_aDay.Index} doesn't match the number of orders submitted - Number Of Orders: {_aDay.NumberOrders}, Number Orders submitted: {_aDay.CountOrderAmounts}";
                result = false;
            }

            return result;
        }
    }
}