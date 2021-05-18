using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoList.Domain.Entities;
using TodoList.Domain.Interfaces.Repositories;
using TodoList.Infra.Contexts;

namespace TodoList.Infra.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly TodoDbContext _context;

        public CategoryRepository(TodoDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Category>> Get()
        {
            return await _context.Categories
                                 .AsNoTracking()
                                 .OrderBy(x => x.Id)
                                 .ToListAsync();
        }

        public async Task<IEnumerable<Category>> Get(int skip, int take)
        {
            return await _context.Categories
                                 .AsNoTracking()
                                 .OrderBy(x => x.Id)
                                 .Skip(skip)
                                 .Take(take)
                                 .ToListAsync();
        }

        public async Task<Category> GetById(Guid id)
        {
            return await _context.Categories
                                 .Where(x => x.Id == id)
                                 .FirstOrDefaultAsync();
        }

        public void Create(Category category)
        {
            _context.Categories.Add(category);
        }

        public void Update(Category category)
        {
            _context.Categories.Update(category);
        }

        public void Delete(Category category)
        {
            _context.Categories.Remove(category);
        }
    }
}
