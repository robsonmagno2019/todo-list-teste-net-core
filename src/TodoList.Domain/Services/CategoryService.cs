using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TodoList.Domain.Entities;
using TodoList.Domain.Interfaces.Repositories;
using TodoList.Domain.Interfaces.Services;

namespace TodoList.Domain.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<IEnumerable<Category>> Get()
        {
            return await _categoryRepository.Get();
        }

        public async Task<Category> GetById(Guid id)
        {
            return await _categoryRepository.GetById(id);
        }

        public Category Create(Category category)
        {
            if (category.Invalid)
                return category;

            _categoryRepository.Create(category);

            return category;
        }

        public Category Update(Category category)
        {
            if (category.Invalid)
                return category;

            _categoryRepository.Update(category);

            return category;
        }

        public Category Delete(Category category)
        {
            if (category.Invalid)
                return category;

            _categoryRepository.Delete(category);

            return category;
        }
    }
}
