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
    [Route ("api/menu")]
    public class MenuApi : Controller {
        private readonly IMapper _mapper;
        private readonly IMenuServices _menuService;
        private readonly IHtmlLocalizer<MenuApi> _localizer;
        public MenuApi (IMapper mapper, IMenuServices menuService, IHtmlLocalizer<MenuApi> localizer) {
            _mapper = mapper;
            _menuService = menuService;
            _localizer = localizer;
        }

        [HttpPost]
        public IActionResult Create (MenuViewModel model) {
            var userModel = _mapper.Map<Menu> (model);
            var result = _menuService.Create (userModel);
            result.Message = _localizer[result.Message].Value;

            return Json (result);
        }

        [HttpPut ("{id}")]
        public IActionResult Update (MenuViewModel model) {
            var userModel = _mapper.Map<Menu> (model);
            var result = _menuService.Update (userModel);
            result.Message = _localizer[result.Message].Value;

            return Json (result);
        }

        [HttpDelete]
        public IActionResult Delete (long id) {
            if (id == 0)
                return NotFound ();

            var result = _menuService.Delete (id);
            result.Message = _localizer[result.Message].Value;

            return Json (result);
        }

        [HttpGet ("{id}")]
        public IActionResult Get (MenuViewModel model) {
            if (model.Id == 0)
                return NotFound ();

            var userModel = _mapper.Map<Menu> (model);
            var result = _menuService.Get (userModel);
            result.Message = _localizer[result.Message].Value;

            return Json (result);
        }

        [HttpGet]
        public IActionResult GetAll (string title, int limit = 10, int index = 0) {
            if (index != 0)
                index--;

            var result = _menuService.GetList (title, limit, index);
            result.Message = _localizer[result.Message].Value;

            return Json (result);
        }
    }
}