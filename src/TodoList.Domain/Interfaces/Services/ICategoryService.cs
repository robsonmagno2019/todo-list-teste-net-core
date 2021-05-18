using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TodoList.Domain.Entities;

namespace TodoList.Domain.Interfaces.Services
{
    public interface ICategoryService
    {
        Task<IEnumerable<Category>> Get();
        Task<Category> GetById(Guid id);
        Category Create(Category category);
        Category Update(Category category);
        Category Delete(Category category);
    }
}
