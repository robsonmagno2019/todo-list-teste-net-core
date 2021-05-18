using System.Linq;
using TodoList.Domain.Flunt.Notifications;
using TodoList.Infra.Interfaces;

namespace TodoList.Application
{
    public class AppServiceBase : Notifiable
    {
        private IUnitOfWork _unitOfWork;

        public AppServiceBase(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public bool Commit()
        {
            if (this.Notifications.Count() > 0)
                return false;

            _unitOfWork.Commit();
            return true;
        }
    }
}
