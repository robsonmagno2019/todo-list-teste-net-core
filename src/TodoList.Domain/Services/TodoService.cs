using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TodoList.Domain.Entities;
using TodoList.Domain.Interfaces.Repositories;
using TodoList.Domain.Interfaces.Services;

namespace TodoList.Domain.Services
{
    public class TodoService : ITodoService
    {
        private readonly ITodoRepository _todoRepository;

        public TodoService(ITodoRepository todoRepository)
        {
            _todoRepository = todoRepository;
        }

        public async Task<IEnumerable<Todo>> Get()
        {
            return await _todoRepository.Get();
        }

        public async Task<Todo> GetById(Guid id)
        {
            return await _todoRepository.GetById(id);
        }

        public Todo Create(Todo todo)
        {
            if (todo.Invalid)
                return todo;

            _todoRepository.Create(todo);

            return todo;
        }

        public Todo Update(Todo todo)
        {
            if (todo.Invalid)
                return todo;

            _todoRepository.Update(todo);

            return todo;
        }

        public Todo Delete(Todo todo)
        {
            if (todo.Invalid)
                return todo;

            _todoRepository.Delete(todo);

            return todo;
        }
    }
}
