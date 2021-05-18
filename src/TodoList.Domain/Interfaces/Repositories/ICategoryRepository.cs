using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TodoList.Domain.Entities;

namespace TodoList.Domain.Interfaces.Repositories
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> Get();
        Task<IEnumerable<Category>> Get(int skip, int take);
        Task<Category> GetById(Guid id);
        void Create(Category category);
        void Update(Category category);
        void Delete(Category category);
    }
}
