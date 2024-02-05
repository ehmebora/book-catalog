using Application.Category.Commands;
using FluentValidation;

namespace Application.Category.Handlers.CommandHandlers
{
    public class CreateCategoryValidator : AbstractValidator<CreateCategory>
    {
        public CreateCategoryValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
        }
    }
}
