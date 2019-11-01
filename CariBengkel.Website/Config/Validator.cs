using CariBengkel.Website.Models;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;

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
}