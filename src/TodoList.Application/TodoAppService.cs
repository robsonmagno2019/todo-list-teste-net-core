using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoList.Application.Interfaces;
using TodoList.Application.ViewModels;
using TodoList.Domain.Entities;
using TodoList.Domain.Interfaces.Services;
using TodoList.Infra.Interfaces;

namespace TodoList.Application
{
    public class TodoAppService: AppServiceBase, ITodoAppService
    {
        private readonly ITodoService _todoService;
        private readonly ICategoryService _categoryService;
        public IDictionary<string, string> Errors = new Dictionary<string, string>();

        public TodoAppService(ITodoService todoService,
                              ICategoryService categoryService,
                              IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _todoService = todoService;
            _categoryService = categoryService;
        }

        public async Task<IEnumerable<Todo>> Get()
        {
            return await _todoService.Get();
        }

        public async Task<Todo> GetById(Guid id)
        {
            return await _todoService.GetById(id);
        }

        public TodoViewModel Create(TodoViewModel model)
        {
            var category = _categoryService.GetById(model.CategoryId).Result;

            var todo = new Todo(model.Description, model.CreateDate, category);

            if(todo.Invalid)
            {
                foreach (var notification in todo.Notifications)
                    this.Errors.Add(notification.Property, notification.Message);

                return model;
            }

            _todoService.Create(todo);

            if (Commit())
                return model;

            return null;
        }

        public TodoViewModel Update(TodoViewModel model)
        {
            var category = _categoryService.GetById(model.CategoryId).Result;
            var todo = _todoService.GetById(model.Id).Result;

            todo.Update(model.Description, category);
            todo.UpdateDate(model.CreateDate);

            if (todo.Invalid)
            {
                foreach (var notification in todo.Notifications)
                    this.Errors.Add(notification.Property, notification.Message);

                return model;
            }

            _todoService.Update(todo);

            if (Commit())
                return model;

            return null;
        }

        public TodoViewModel Delete(TodoViewModel model)
        {
            var todo = _todoService.GetById(model.Id).Result;

            _todoService.Delete(todo);

            if (Commit())
                return model;

            return null;
        }

        public TodoViewModel Conclude(TodoViewModel model)
        {
            var todo = _todoService.GetById(model.Id).Result;

            todo.UpdateToCompleted();

            _todoService.Update(todo);

            if (Commit())
                return model;

            return null;
        }
    }
}
