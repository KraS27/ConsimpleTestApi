using ConsimpleTestApi.Models.DTO.User;
using FluentValidation;

namespace ConsimpleTestApi.Validators.User
{
    public class CreateUserRequestValidator : AbstractValidator<CreateUserRequest>
    {
        public CreateUserRequestValidator()
        {
            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage("FirstName required")
                .Length(2, 24).WithMessage("FirstName must be between 2 and 24 characters");

            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("LastName required")
                .Length(2, 24).WithMessage("LastName must be between 2 and 24 characters");

            RuleFor(x => x.Patronymic)
                .NotEmpty().WithMessage("Patronymic required")
                .Length(2, 32).WithMessage("Patronymic must be between 2 and 32 characters");
        }
    }
}
