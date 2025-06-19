using FluentValidation.Results;

namespace Pacagroup.Trade.Application.UsesCases.Commons.Exceptions
{
    public class ValidationExceptionCustom : Exception
    {
        public List<string> Errors { get; set; }

        public ValidationExceptionCustom() : base("One or more validation failures have occurred.")
        {
            Errors = [];
        }

        public ValidationExceptionCustom(IEnumerable<ValidationFailure> errors) : this()
        {
            Errors = errors.Select(x => x.ErrorMessage).ToList();
        }
    }
}
