using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TodoList.Domain.Entities;

namespace TodoList.Domain.Interfaces.Repositories
{
    public interface ITodoRepository
    {
        Task<IEnumerable<Todo>> Get();
        Task<IEnumerable<Todo>> Get(int skip, int take);
        Task<Todo> GetById(Guid id);
        void Create(Todo todo);
        void Update(Todo todo);
        void Delete(Todo todo);
    }
}
