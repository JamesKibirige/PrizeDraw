using System.Collections.Generic;

namespace PrizeDraw.Interfaces
{
    public interface IValidator
    {
        bool Validate(IEnumerable<Validation.Validation> validations);
        string ValidationMessage { get; }
    }
}