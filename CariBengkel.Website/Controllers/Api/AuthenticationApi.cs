using System;
using AutoMapper;
using CariBengkel.Domain.Cores;
using CariBengkel.Repository.Entity.Model;
using CariBengkel.Website.Config;
using CariBengkel.Website.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Localization;

namespace CariBengkel.Website.Controllers.Api {
    [ApiController]
    [Route ("[controller]")]
    public class AuthenticationApi : Controller {
        private IAuthServices _authService;
        private readonly IMapper _mapper;
        private readonly IHtmlLocalizer<AuthenticationApi> _localizer;
        public AuthenticationApi (IAuthServices authServices, IMapper mapper, IHtmlLocalizer<AuthenticationApi> localizer) {
            _authService = authServices;
            _mapper = mapper;
            _localizer = localizer;
        }

        [HttpPost]
        [Route ("login")]
        public ActionResult Login (CredentialViewModel credential) {
            var modelCredentials = _mapper.Map<Credentials> (credential);
            var result = _authService.Login (modelCredentials);

            result.Message = _localizer[result.Message].Value;

            return Json (result);
        }

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