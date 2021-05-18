using System;
using System.Threading.Tasks;
using TodoList.Infra.Contexts;
using TodoList.Infra.Interfaces;

namespace TodoList.Infra.UoW
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private TodoDbContext _context;

        public UnitOfWork(TodoDbContext context)
        {
            _context = context;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
        }

        private void Dispose(bool disposing)
        {
            if (disposing)
            {
                if(_context != null)
                {
                    _context.Dispose();
                    _context = null;
                }
            }
        }
    }
}
