
using FluentValidation;

namespace Application.Book.Commands
{
    public class UpdateBookValidator : AbstractValidator<UpdateBook>
    {
        public UpdateBookValidator() 
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.Title).NotEmpty();
        }
    }
}
