using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Domain.ValidationAttributes
{
    public class DateInFutureAttribute : ValidationAttribute
    {
        private readonly Func<DateTime> _dateTimeNowProvider;
        public DateInFutureAttribute(): this(() => DateTime.Now) { }

        public DateInFutureAttribute(Func<DateTime> dateTimeNowProvider)
        {
            _dateTimeNowProvider = dateTimeNowProvider;
            ErrorMessage = "La fecha debe ser futura";
        }

        public override bool IsValid(object? value)
        {
            if (value == null) return true; 

            if(value is DateTime dateTime)
            {
                return dateTime > _dateTimeNowProvider();
            }
            return false;
        }
    }
}
