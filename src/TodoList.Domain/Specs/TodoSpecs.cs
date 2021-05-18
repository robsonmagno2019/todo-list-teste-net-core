using System;
using System.Linq.Expressions;
using TodoList.Domain.Entities;

namespace TodoList.Domain.Specs
{
    public static class TodoSpecs
    {
        public static Expression<Func<Todo, bool>> GetById(Guid id)
        {
            return x => x.Id == id;
        }
    }
}
