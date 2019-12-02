using System.Collections.Generic;
using CariBengkel.Website.Models;
using FluentValidation;
using FluentValidation.AspNetCore;

namespace CariBengkel.Website.Config {
    public class InitializeValidator {
        public void Setup (FluentValidationMvcConfiguration config) {
            config.RegisterValidatorsFromAssemblyContaining<CredentialValidator> ();
            config.RegisterValidatorsFromAssemblyContaining<LoginValidator> ();
            config.RegisterValidatorsFromAssemblyContaining<UserValidator> ();
            config.RegisterValidatorsFromAssemblyContaining<MenuValidator> ();
            config.RegisterValidatorsFromAssemblyContaining<RoleValidator> ();
            config.RegisterValidatorsFromAssemblyContaining<RoleMapValidator> ();
        }
    }
    public class CredentialValidator : AbstractValidator<CredentialViewModel> {
        public CredentialValidator () {
            RuleFor (cr => cr.Username).MaximumLength (50).NotNull ();
            RuleFor (cr => cr.Email).EmailAddress ().NotNull ();
            RuleFor (cr => cr.Password).MaximumLength (20).NotNull ().When (cr => cr.Id == 0);
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

    public class RoleValidator : AbstractValidator<RoleViewModel> {
        public RoleValidator () {
            RuleFor (role => role.Name).NotNull ();
            RuleFor (role => role.Status).NotNull ();
        }
    }

    public class RoleMapValidator : AbstractValidator<RoleMapViewModel> {
        public RoleMapValidator () {
            RuleFor (role => role.CredentialId).NotNull ();
            RuleFor (role => role.RoleId).NotNull ();
        }
    }

    public class MenuMapValidator : AbstractValidator<MenuMapViewModel> {
        public MenuMapValidator () {
            RuleFor (menu => menu.MenuRoleMap.Id).NotNull ();
            RuleFor (menu => menu.MenuRoleMap.RoleId).NotNull ();
            RuleFor (menu => menu.MenuRoleMap.MenuId).NotNull ();
        }
    }
}