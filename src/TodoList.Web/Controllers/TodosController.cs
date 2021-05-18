using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoList.Application.Interfaces;
using TodoList.Application.ViewModels;

namespace TodoList.Web.Controllers
{
    public class TodosController : Controller
    {
        private readonly ITodoAppService _todoAppService;
        private readonly ICategoryAppService _CategoryAppService;
        private readonly IMapper _mapper;

        public TodosController(ITodoAppService todoAppService,
                               ICategoryAppService CategoryAppService,
                               IMapper mapper)
        {
            _todoAppService = todoAppService;
            _CategoryAppService = CategoryAppService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Index(string ordenar = "", string filtrar = "")
        {
            var todos = _mapper.Map<IEnumerable<TodoViewModel>>(await _todoAppService.Get());

            if (!String.IsNullOrEmpty(ordenar))
            {
                if(ordenar.TrimStart().TrimEnd() == "Data")
                {
                    todos = todos.OrderBy(x => x.CreateDate);

                    return View(todos);
                }

                if (ordenar.TrimStart().TrimEnd() == "Categoria")
                {
                    todos = todos.OrderBy(x => x.Category.Description);

                    return View(todos);
                }
                else
                {
                    return View(todos);
                }

            }

            if (!String.IsNullOrEmpty(filtrar))
            {
                ViewData["SelectedFilter"] = filtrar;

                if (filtrar == "Created")
                {

                    todos = todos.Where(x => x.Status == 1).ToList();

                    return View(todos);
                }

                if(filtrar == "Completed")
                {
                    todos = todos.Where(x => x.Status == 2).ToList();

                    return View(todos);
                }

                if(filtrar == "Todos")
                {
                    return View(todos);
                }
            }


            return View(todos);

        }

        [HttpGet]
        public async Task<IActionResult> Details(Guid id)
        {
            var todo = _mapper.Map<TodoViewModel>(await _todoAppService.GetById(id));

            return View(todo);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var todoViewModel = this.LodingInformations(new TodoViewModel());

            return View(todoViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(TodoViewModel model)
        {
            var todoViewModel = this.LodingInformations(model);

            if (!ModelState.IsValid) return View(model);

            var todo = _todoAppService.Create(model);

            TempData["Success"] = "Tarefa adicionada com successo!";

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Conclude(Guid id)
        {
            var todo = _mapper.Map<TodoViewModel>(await _todoAppService.GetById(id));

            var todoViewModel = _todoAppService.Conclude(todo);

            TempData["Success"] = "Tarefa concluída com successo!";

            return RedirectToAction(nameof(Index));
        }

        private TodoViewModel LodingInformations(TodoViewModel model)
        {
            var categories = _mapper.Map<IEnumerable<CategoryViewModel>>(_CategoryAppService.Get().Result);
            model.Categories = categories;

            return model;
        }
    }
}
