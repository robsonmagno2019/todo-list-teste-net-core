using System.Threading.Tasks;

namespace TodoList.Infra.Interfaces
{
    public interface IUnitOfWork
    {
        void Commit();
    }
}
