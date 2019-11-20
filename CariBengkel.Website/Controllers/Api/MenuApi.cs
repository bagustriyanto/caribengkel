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
        [ProducesResponseType (StatusCodes.Status201Created)]
        [ProducesResponseType (StatusCodes.Status404NotFound)]
        public IActionResult Create (MenuViewModel model) {
            var validator = new MenuValidator ();
            var validate = validator.Validate (model);
            if (!validate.IsValid)
                return BadRequest (validate.Errors.ToString ());

            var userModel = _mapper.Map<Menu> (model);
            var result = _menuService.Create (userModel);
            result.Message = _localizer[result.Message].Value;

            return Json (result);
        }

        [HttpPut ("{id}")]
        [ProducesResponseType (StatusCodes.Status200OK)]
        [ProducesResponseType (StatusCodes.Status404NotFound)]
        public IActionResult Update (MenuViewModel model) {
            var validator = new MenuValidator ();
            var validate = validator.Validate (model);
            if (!validate.IsValid)
                return BadRequest (validate.Errors.ToString ());

            var userModel = _mapper.Map<Menu> (model);
            var result = _menuService.Update (userModel);
            result.Message = _localizer[result.Message].Value;

            return Json (result);
        }

        [HttpDelete]
        [ProducesResponseType (StatusCodes.Status200OK)]
        [ProducesResponseType (StatusCodes.Status404NotFound)]
        public IActionResult Delete (MenuViewModel model) {
            if (model.Id == 0)
                return BadRequest ("Id Not found");

            var userModel = _mapper.Map<Menu> (model);
            var result = _menuService.Delete (userModel);
            result.Message = _localizer[result.Message].Value;

            return Json (result);
        }

        [HttpGet ("{id}")]
        [ProducesResponseType (StatusCodes.Status200OK)]
        [ProducesResponseType (StatusCodes.Status404NotFound)]
        public IActionResult Get (MenuViewModel model) {
            if (model.Id == 0)
                return BadRequest ("Id Not found");

            var userModel = _mapper.Map<Menu> (model);
            var result = _menuService.Get (userModel);
            result.Message = _localizer[result.Message].Value;

            return Json (result);
        }

        [HttpGet]
        [ProducesResponseType (StatusCodes.Status200OK)]
        [ProducesResponseType (StatusCodes.Status404NotFound)]
        public IActionResult GetAll () {
            var result = _menuService.GetAll ();
            result.Message = _localizer[result.Message].Value;

            return Json (result);
        }
    }
}