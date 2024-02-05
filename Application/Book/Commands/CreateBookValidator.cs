using FluentValidation;

namespace Application.Book.Commands
{
    public class CreateBookValidator : AbstractValidator<CreateBook>
    {
        public CreateBookValidator()
        {
            RuleFor(x => x.Title).NotEmpty();
        }
    }
}
