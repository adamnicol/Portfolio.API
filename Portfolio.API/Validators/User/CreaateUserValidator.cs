using FluentValidation;
using Portfolio.API.Dto.User;
using Portfolio.API.Common.Constants;

namespace Portfolio.API.Validators.User
{
    public class CreaateUserValidator : AbstractValidator<CreateUserRequest>
    {
        public CreaateUserValidator()
        {
            RuleFor(x => x.UserName)
                .MinimumLength(UserConstants.MinUsernameLength)
                .MaximumLength(UserConstants.MaxUsernameLength);

            RuleFor(x => x.Email)
                .EmailAddress();

            RuleFor(x => x.Password)
                .MinimumLength(UserConstants.MinPasswordLength);
        }
    }
}
