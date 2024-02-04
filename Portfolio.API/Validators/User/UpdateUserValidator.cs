using FluentValidation;
using Portfolio.API.Dto.User;
using Portfolio.API.Common.Constants;

namespace Portfolio.API.Validators.User
{
    public class UpdateUserValidator : AbstractValidator<UpdateUserRequest>
    {
        public UpdateUserValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty();

            RuleFor(x => x.UserName)
                .MinimumLength(UserConstants.MinUsernameLength)
                .MaximumLength(UserConstants.MaxUsernameLength);

            RuleFor(x => x.Email)
                .EmailAddress();
        }
    }
}
