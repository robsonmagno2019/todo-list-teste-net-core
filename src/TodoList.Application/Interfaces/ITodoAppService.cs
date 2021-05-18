using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TodoList.Application.ViewModels;
using TodoList.Domain.Entities;

namespace TodoList.Application.Interfaces
{
    public interface ITodoAppService
    {
        Task<IEnumerable<Todo>> Get();
        Task<Todo> GetById(Guid id);
        TodoViewModel Create(TodoViewModel model);
        TodoViewModel Update(TodoViewModel model);
        TodoViewModel Conclude(TodoViewModel model);
        TodoViewModel Delete(TodoViewModel model);
    }
}
