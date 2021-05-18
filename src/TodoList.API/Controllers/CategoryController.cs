using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TodoList.Application.Interfaces;
using TodoList.Application.ViewModels;
using TodoList.Domain.Entities;

namespace TodoList.API.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryAppService _categoryAppService;

        public CategoryController(ICategoryAppService categoryAppService)
        {
            _categoryAppService = categoryAppService;
        }

        [HttpGet]
        [Route("api/categories")]
        public async Task<ActionResult<IEnumerable<Category>>> Get()
        {
            var categories = await _categoryAppService.Get();

            return Ok(categories);
        }

        [HttpGet]
        [Route("api/categories/{id:guid}")]
        public async Task<ActionResult<Category>> Get(Guid id)
        {
            var category = await _categoryAppService.GetById(id);

            return Ok(category);
        }

        [HttpPost]
        [Route("api/categories")]
        public IActionResult Post([FromBody] CategoryViewModel model)
        {
            if (!ModelState.IsValid) return BadRequest();

            var categoryViewModel = _categoryAppService.Create(model);

            return Ok(categoryViewModel);
        }

        [HttpPut]
        [Route("api/categories")]
        public IActionResult Put([FromBody] CategoryViewModel model)
        {
            if (!ModelState.IsValid) return BadRequest();

            var categoryViewModel = _categoryAppService.Update(model);

            return Ok(categoryViewModel);
        }

        [HttpDelete]
        [Route("api/categories")]
        public IActionResult Delete([FromBody] CategoryViewModel model)
        {
            if (!ModelState.IsValid) return BadRequest();

            var categoryViewModel = _categoryAppService.Delete(model.Id);

            return Ok(categoryViewModel);
        }
    }
}
