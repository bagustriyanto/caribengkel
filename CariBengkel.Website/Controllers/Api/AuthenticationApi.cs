using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using CariBengkel.Domain.Cores;
using CariBengkel.Repository.Entity.Model;
using CariBengkel.Website.Config;
using CariBengkel.Website.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Localization;

namespace CariBengkel.Website.Controllers.Api {
    [Authorize (AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    [Route ("api/auth")]
    public class AuthenticationApi : Controller {
        private IAuthServices _authService;
        private readonly IMapper _mapper;
        private readonly IHtmlLocalizer<AuthenticationApi> _localizer;
        public AuthenticationApi (IAuthServices authServices, IMapper mapper, IHtmlLocalizer<AuthenticationApi> localizer) {
            _authService = authServices;
            _mapper = mapper;
            _localizer = localizer;
        }

        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route ("login")]
        public async Task<ActionResult> Login (CredentialViewModel credential) {
            var modelCredentials = _mapper.Map<Credentials> (credential);
            var result = await _authService.Login (modelCredentials);

            var claims = new [] {
                new Claim (ClaimTypes.Name, result.Data.Username),
                new Claim (ClaimTypes.Role, result.Data.RoleMap.FirstOrDefault ().Role.Name)
            };

            var identity = new ClaimsIdentity (claims, "login");

            ClaimsPrincipal principal = new ClaimsPrincipal (identity);

            await AuthenticationHttpContextExtensions.SignInAsync (HttpContext, CookieAuthenticationDefaults.AuthenticationScheme, principal);

            result.Message = _localizer[result.Message].Value;

            return Json (result);
        }

        [AllowAnonymous]
        [HttpPost]
        [Route ("register")]
        public ActionResult Register (CredentialViewModel credential) {
            credential.Status = true;
            var modelCredentials = _mapper.Map<Credentials> (credential);

            var result = _authService.Register (modelCredentials);
            result.Message = _localizer[result.Message].Value;

            return Json (result);
        }
    }
}