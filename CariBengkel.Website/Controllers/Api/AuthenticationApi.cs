using AutoMapper;
using CariBengkel.Domain.Cores;
using CariBengkel.Repository.Entity.Model;
using CariBengkel.Website.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CariBengkel.Website.Controllers.Api {
    [ApiController]
    [Route ("api/auth")]
    public class AuthenticationApi : Controller {
        private IAuthServices _authService;
        private readonly IMapper _mapper;
        public AuthenticationApi (IAuthServices authServices, IMapper mapper) {
            _authService = authServices;
            _mapper = mapper;
        }

        [HttpPost]
        [ProducesResponseType (StatusCodes.Status202Accepted)]
        [ProducesResponseType (StatusCodes.Status404NotFound)]
        [Route ("login")]
        public ActionResult Login () {

            return Json (new object ());
        }

        [HttpPost]
        [ProducesResponseType (StatusCodes.Status201Created)]
        [ProducesResponseType (StatusCodes.Status400BadRequest)]
        [Route ("register")]
        public ActionResult Register (CredentialViewModel credential) {
            var modelCredentials = _mapper.Map<Credentials> (credential);

            var result = _authService.Login (modelCredentials);

            return Json (result);
        }
    }
}