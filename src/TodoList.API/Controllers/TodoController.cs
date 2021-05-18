using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TodoList.Application.Interfaces;
using TodoList.Application.ViewModels;
using TodoList.Domain.Entities;

namespace TodoList.API.Controllers
{
    public class TodoController : Controller
    {
        private readonly ITodoAppService _todoAppService;
        private readonly IMapper _mapper;

        public TodoController(ITodoAppService todoAppService,
                              IMapper mapper)
        {
            _todoAppService = todoAppService;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("api/todos")]
        public async Task<ActionResult<IEnumerable<Todo>>> Get()
        {
            var todos = _mapper.Map<IEnumerable<TodoViewModel>>(await _todoAppService.Get());
            return Ok(todos);
        }

        [HttpGet]
        [Route("api/todos/{id:guid}")]
        public async Task<ActionResult<Todo>> GetById(Guid id)
        {
            var todo = _mapper.Map<TodoViewModel>(await _todoAppService.GetById(id));
            return Ok(todo);
        }

        [HttpPost]
        [Route("api/todos")]
        public IActionResult Post([FromBody] TodoViewModel model)
        {
            if (!ModelState.IsValid) return BadRequest();

            var todoViewModel = _todoAppService.Create(model);

            return Ok(todoViewModel);
        }

        [HttpPut]
        [Route("api/todos")]
        public IActionResult Put([FromBody] TodoViewModel model)
        {
            if (!ModelState.IsValid) return BadRequest();

            var todoViewModel = _todoAppService.Update(model);

            return Ok(todoViewModel);
        }

        [HttpPut]
        [Route("api/todos/conclude")]
        public IActionResult Conclude([FromBody] TodoViewModel model)
        {
            if (!ModelState.IsValid) return BadRequest();

            var todoViewModel = _todoAppService.Conclude(model);

            return Ok(todoViewModel);
        }

        [HttpDelete]
        [Route("api/todos")]
        public IActionResult Delete([FromBody] TodoViewModel model)
        {
            if (!ModelState.IsValid) return BadRequest();

            var todoViewModel = _todoAppService.Delete(model);

            return Ok(todoViewModel);
        }
    }
}
