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
            RuleFor (user => user.FirstName).NotNull ();
            RuleFor (user => user.Credential).SetValidator (new CredentialValidator ());
        }
    }

    public class MenuValidator : AbstractValidator<MenuViewModel> {
        public MenuValidator () {
            RuleFor (menu => menu.Title).NotNull ();
            RuleFor (menu => menu.Url).NotNull ();
        }
    }
}