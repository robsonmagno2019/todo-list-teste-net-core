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
    public class CategoryAppService : AppServiceBase, ICategoryAppService
    {
        private readonly ICategoryService _categoryService;
        public IDictionary<string, string> Errors = new Dictionary<string, string>();

        public CategoryAppService(ICategoryService categoryService,
                                  IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _categoryService = categoryService;
        }

        public async Task<IEnumerable<Category>> Get()
        {
            return await _categoryService.Get();
        }

        public Task<IEnumerable<Category>> Get(int skip, int take)
        {
            throw new NotImplementedException();
        }

        public async Task<Category> GetById(Guid id)
        {
            return await _categoryService.GetById(id);
        }

        public CategoryViewModel Create(CategoryViewModel model)
        {
            var category = new Category(model.Description);

            if (category.Invalid)
            {
                foreach (var notification in category.Notifications)
                    this.Errors.Add(notification.Property, notification.Message);

                return model;
            }

            _categoryService.Create(category);

            if (Commit())
                return model;

            return null;
        }

        public CategoryViewModel Update(CategoryViewModel model)
        {
            var category = _categoryService.GetById(model.Id).Result;

            category.Update(model.Description);

            if (category.Invalid)
            {
                foreach (var notification in category.Notifications)
                    this.Errors.Add(notification.Property, notification.Message);

                return model;
            }

            _categoryService.Update(category);

            if (Commit())
                return model;

            return null;
        }

        public CategoryViewModel Delete(Guid id)
        {
            var category = _categoryService.GetById(id).Result;

            if (category.Todos.Count() > 0)
            {
                this.Errors.Add("", "A categoria não pode ser excluída, pois está relacionada com uma tarefa.");
                return null;
            }

            _categoryService.Delete(category);

            if (Commit())
                return new CategoryViewModel
                {
                    Id = category.Id,
                    Description = category.Description
                };

            return null;
        }
    }
}
