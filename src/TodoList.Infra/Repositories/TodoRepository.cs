using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoList.Domain.Entities;
using TodoList.Domain.Interfaces.Repositories;
using TodoList.Domain.Specs;
using TodoList.Infra.Contexts;

namespace TodoList.Infra.Repositories
{
    public class TodoRepository : ITodoRepository
    {
        private readonly TodoDbContext _context;

        public TodoRepository(TodoDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Todo>> Get()
        {
            return await _context.Todos
                                 .AsNoTracking()
                                 .Include(x => x.Category)
                                 .OrderBy(x => x.Id)
                                 .ToListAsync();
        }

        public async Task<IEnumerable<Todo>> Get(int skip, int take)
        {
            return await _context.Todos
                                 .AsNoTracking()
                                 .Include(x => x.Category)
                                 .OrderBy(x => x.Id)
                                 .Skip(skip)
                                 .Take(take)
                                 .ToListAsync();
        }

        public async Task<Todo> GetById(Guid id)
        {
            return await _context.Todos
                                 .Include(x => x.Category)
                                 .Where(TodoSpecs.GetById(id))
                                 .FirstOrDefaultAsync();
        }

        public void Create(Todo todo)
        {
            _context.Todos.Add(todo);
        }

        public void Update(Todo todo)
        {
            _context.Todos.Update(todo);
        }

        public void Delete(Todo todo)
        {
            _context.Todos.Remove(todo);
        }
    }
}
