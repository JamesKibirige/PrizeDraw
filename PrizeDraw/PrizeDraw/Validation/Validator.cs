using PrizeDraw.Interfaces;
using System.Collections.Generic;

namespace PrizeDraw.Validation
{
    public class Validator : IValidator
    {
        public string ValidationMessage { get; private set; }

        public bool Validate(IEnumerable<Validation> validations)
        {
            var result = true;
            foreach (var validation in validations)
            {
                if (!validation.IsValid())
                {
                    ValidationMessage = validation.ValidationMessage;
                    result = false;
                }
            }

            return result;
        }
    }
}