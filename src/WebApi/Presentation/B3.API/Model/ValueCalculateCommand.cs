using B3.API.Validation;
using FluentValidation.Results;

namespace B3.API.Model
{
    public class ValueCalculateCommand
    {
        public ValueCalculateCommand() { }
        public ValueCalculateCommand(decimal initialValue, int month)
        {
            Month = month;
            InitialValue = initialValue;
        }

        public int Month { get; set; }
        public decimal InitialValue { get; set; }

        public ValidationResult IsValid()
        {
            ValueCalculateValidation validationRules = new ValueCalculateValidation();
            return validationRules.Validate(this);
        }
    }
}
