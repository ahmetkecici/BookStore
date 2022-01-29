using FluentValidation;

namespace Api.BookOperations.CreateData
{
    public class CreateBookValidator:AbstractValidator<CreateBookCommand>
    {
        public CreateBookValidator()
        {
            RuleFor(x=>x.Model.GenreId).NotEmpty().GreaterThan(0);
        }
    }
}
