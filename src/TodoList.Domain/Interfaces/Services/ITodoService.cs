using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TodoList.Domain.Entities;

namespace TodoList.Domain.Interfaces.Services
{
    public interface ITodoService
    {
        Task<IEnumerable<Todo>> Get();
        Task<Todo> GetById(Guid id);
        Todo Create(Todo todo);
        Todo Update(Todo todo);
        Todo Delete(Todo todo);
    }
}
