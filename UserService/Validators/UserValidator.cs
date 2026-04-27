using FluentValidation;
using UserApi.DTOs;

namespace UserApi.Validators;

public sealed class UserValidator : AbstractValidator<UserDto>
{
    public UserValidator()
    {
        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email обязателен")
            .EmailAddress().WithMessage("Некорректный формат Email");

        RuleFor(x => x.Name)
            .NotEmpty()
            .MinimumLength(2);
    }
}
