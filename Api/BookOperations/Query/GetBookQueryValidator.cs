using FluentValidation;

namespace Api.BookOperations.Query
{
    public class GetBookQueryValidator:AbstractValidator<GetBookByIdQuery>
    {
        public GetBookQueryValidator()
        {
            RuleFor(x => x.ModelId).NotEmpty().GreaterThan(0)     ;
        }
    }
}
