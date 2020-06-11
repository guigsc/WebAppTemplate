using FluentValidation;
using System.Threading.Tasks;
using WebAppTemplate.CrossCutting.Results;

namespace WebAppTemplate.Model.Validation
{
    public abstract class Validator<T> : AbstractValidator<T>
    {
        private string Message { get; set; }

        public new IResult Validate(T instance)
        {
            if (instance == null)
            {
                return Result.Fail(Message ?? string.Empty);
            }

            var result = base.Validate(instance);

            if (result.IsValid)
            {
                return Result.Success();
            }

            return Result.Fail(Message ?? result.ToString());
        }

        public Task<IResult> ValidateAsync(T instance)
        {
            return Task.FromResult(Validate(instance));
        }

        public void WithMessage(string message)
        {
            Message = message;
        }
    }
}
