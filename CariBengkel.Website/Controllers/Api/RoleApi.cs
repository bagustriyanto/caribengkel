using System;
using AutoMapper;
using CariBengkel.Domain.Cores;
using CariBengkel.Repository.Entity.Model;
using CariBengkel.Website.Config;
using CariBengkel.Website.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Localization;

namespace CariBengkel.Website.Controllers.Api {
    [Authorize (AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    [Route ("api/role")]
    public class RoleApi : Controller {
        private IRoleServices _roleServices;
        private IHtmlLocalizer<RoleApi> _localizer;
        private IMapper _mapper;
        public RoleApi (IRoleServices roleServices, IHtmlLocalizer<RoleApi> localizer, IMapper mapper) {
            _roleServices = roleServices;
            _localizer = localizer;
            _mapper = mapper;
        }

        [HttpGet ("{id}")]
        public IActionResult Get (long id) {
            if (id == 0)
                return NotFound ();

            var result = _roleServices.Get (id);
            result.Message = _localizer[result.Message].Value;

            return Json (result);
        }

        [HttpGet]
        public IActionResult GetAll (string name, int limit = 20, int index = 0) {
            var result = _roleServices.GetAll (name, limit, index);
            result.Message = _localizer[result.Message].Value;

            return Json (result);
        }

        [HttpPost]
        public IActionResult Create (RoleViewModel model) {
            var mapper = _mapper.Map<Role> (model);
            var result = _roleServices.Create (mapper);
            result.Message = _localizer[result.Message].Value;

            return Json (result);
        }

        [HttpPut ("{id}")]
        public IActionResult Update (RoleViewModel model) {
            var mapper = _mapper.Map<Role> (model);
            var result = _roleServices.Update (mapper);
            result.Message = _localizer[result.Message].Value;

            return Json (result);
        }

        [HttpDelete]
        public IActionResult Delete (long id) {
            if (id == 0)
                return NotFound ();

            var result = _roleServices.Delete (id);
            result.Message = _localizer[result.Message].Value;

            return Json (result);
        }
    }
}