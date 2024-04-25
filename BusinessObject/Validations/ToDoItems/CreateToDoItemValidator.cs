using BusinessObject.DTOs.ToDoItems;
using FluentValidation;

namespace BusinessObject.Validations.ToDoItems
{
    public class CreateToDoItemValidator : AbstractValidator<CreateToDoItemRequest>
    {
        public CreateToDoItemValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Title is required");
        }
    }
}
