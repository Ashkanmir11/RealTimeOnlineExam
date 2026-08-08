using System.ComponentModel.DataAnnotations;

namespace OnlineExam.Ui.Validation
{
    public class DateCompare : ValidationAttribute
    {
        private readonly string _propertyName;
        public DateCompare(string propertyName)
        {
            _propertyName = propertyName;
        }
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var endDatePropery = validationContext.ObjectInstance.GetType().GetProperty(_propertyName).GetValue(validationContext.ObjectInstance);
            if(value==null || endDatePropery==null)
            {
                return new ValidationResult("تاریخ ها نباید خالی باشد..");

            }
            var startDate = (DateTime)value;
            var endDate = (DateTime)endDatePropery;
            if (startDate < DateTime.Now)
            {
                return new ValidationResult("تاریخ شروع باید بعد از تاریخ الان باشد.");
            }
            if (endDate < startDate)
            {
                return new ValidationResult("تاریخ پایان باید بعد از تاریخ شروع باشد.");
            }
            return ValidationResult.Success;
        }
    }
}
