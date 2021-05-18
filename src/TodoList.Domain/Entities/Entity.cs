using System;
using TodoList.Domain.Flunt.Notifications;

namespace TodoList.Domain.Entities
{
    public abstract class Entity : Notifiable
    {
        protected Entity()
        {
            this.Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }
    }
}
