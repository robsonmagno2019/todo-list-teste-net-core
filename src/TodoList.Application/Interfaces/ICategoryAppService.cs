using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TodoList.Application.ViewModels;
using TodoList.Domain.Entities;

namespace TodoList.Application.Interfaces
{
    public interface ICategoryAppService
    {
        Task<IEnumerable<Category>> Get();
        Task<IEnumerable<Category>> Get(int skip, int take);
        Task<Category> GetById(Guid id);
        CategoryViewModel Create(CategoryViewModel model);
        CategoryViewModel Update(CategoryViewModel model);
        CategoryViewModel Delete(Guid id);
    }
}
