using PrizeDraw.Interfaces;
using System;

namespace PrizeDraw.Validation
{
    public class NumberOrdersInRange: Validation
    {
        private readonly int _low;
        private readonly int _high;
        private readonly IDay _aDay;

        public NumberOrdersInRange(int low, int high, IDay aDay)
        {
            _low = low;
            _high = high;
            _aDay = aDay;
        }

        public override bool IsValid()
        {
            if (_low >= _high)
            {
                throw new ArgumentOutOfRangeException($"Error during {GetType()} Validation, Invalid Range specified {nameof(_low)}: {_low}, {nameof(_high)}: {_high}. {nameof(_low)} must be less than {nameof(_high)}");
            }

            var result = true;
            if (!(_aDay.NumberOrders >= _low && _aDay.NumberOrders <= _high))
            {
                ValidationMessage = $"Number of Orders for day: {_aDay.Index} Out of range: {_aDay.NumberOrders} is outside of range {_low} to {_high}";
                result = false;
            }

            return result;
        }
    }
}