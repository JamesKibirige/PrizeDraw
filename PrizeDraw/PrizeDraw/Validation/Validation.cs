using PrizeDraw.Interfaces;

namespace PrizeDraw.Validation
{
    public abstract class Validation: IValidation
    {
        public int  Order { get; set; }
        public string ValidationMessage { get; set; }
        public abstract bool IsValid();
    }
}