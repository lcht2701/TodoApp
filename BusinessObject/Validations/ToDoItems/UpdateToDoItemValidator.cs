using BusinessObject.DTOs.ToDoItems;
using FluentValidation;

namespace BusinessObject.Validations.ToDoItems
{
    public class UpdateToDoItemValidator : AbstractValidator<UpdateToDoItemRequest>
    {
        public UpdateToDoItemValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Title is required");
        }
    }
}
