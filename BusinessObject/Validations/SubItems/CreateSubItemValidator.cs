using BusinessObject.DTOs.SubItems;
using FluentValidation;

namespace BusinessObject.Validations.SubItems
{
    public class CreateSubItemValidator : AbstractValidator<CreateSubItemRequest>
    {
        public CreateSubItemValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Title is required");
            RuleFor(x => x.Description)
                .MaximumLength(1000).WithMessage("Description Must Not Exceed 1000 Words");
            RuleFor(x => x.Status)
                .IsInEnum().WithMessage("Status must be valid");
            RuleFor(x => x.Priority)
                .IsInEnum().WithMessage("Priority must be valid");
        }
    }
}
