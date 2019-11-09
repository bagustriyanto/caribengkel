using CariBengkel.Website.Models;
using FluentValidation;
using FluentValidation.AspNetCore;

namespace CariBengkel.Website.Config {
    public class InitializeValidator {
        public void Setup (FluentValidationMvcConfiguration config) {
            config.RegisterValidatorsFromAssemblyContaining<CredentialValidator> ();
        }
    }
    public class CredentialValidator : AbstractValidator<CredentialViewModel> {
        public CredentialValidator () {
            RuleFor (cr => cr.Username).MaximumLength (50).NotNull ();
            RuleFor (cr => cr.Email).EmailAddress ().NotNull ();
            RuleFor (cr => cr.Password).MaximumLength (20).NotNull ();
        }
    }

    public class LoginValidator : AbstractValidator<CredentialViewModel> {
        public LoginValidator () {
            RuleFor (cr => cr.Username).MaximumLength (50).NotNull ();
            RuleFor (cr => cr.Password).MaximumLength (20).NotNull ();
        }
    }

    public class UserValidator : AbstractValidator<UserViewModel> {
        public UserValidator () {
            RuleFor (user => user.Credential.Email).NotNull ().EmailAddress ();
            RuleFor (user => user.Credential.Username).NotNull ();
            RuleFor (user => user.Credential.Password).NotNull ();
            RuleFor (user => user.FirstName).NotNull ();
        }
    }
}