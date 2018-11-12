using System.Collections.Generic;

namespace PrizeDraw.Interfaces
{
    public interface IValidationFactory
    {
        IEnumerable<Validation.Validation> CreateValidations(ICampaign campaign);
    }
}