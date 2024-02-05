using Application.Category.Commands;
using FluentValidation;

namespace Application.Category.Handlers.CommandHandlers
{
    public class DeleteCategoryValidator : AbstractValidator<DeleteCategory>
    {
        public DeleteCategoryValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}
