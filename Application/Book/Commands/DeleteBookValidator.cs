using FluentValidation;

namespace Application.Book.Commands
{
    public class DeleteBookValidator : AbstractValidator<DeleteBook>
    {
        public DeleteBookValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}
