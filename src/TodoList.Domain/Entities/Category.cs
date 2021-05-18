using System.Collections.Generic;
using TodoList.Domain.Flunt.Validations;
using TodoList.Domain.Flunt.Validations.Contracts;

namespace TodoList.Domain.Entities
{
    public class Category : Entity, IValidatable
    {
        protected Category()
        {
            this.Todos = new List<Todo>();
        }
        public Category(string description)
        {
            this.Description = description;
            this.Todos = new List<Todo>();
        }

        public string Description { get; private set; }
        public IEnumerable<Todo> Todos { get; private set; }

        public void Update(string description)
        {
            this.Description = description;

            AddNotifications(
                    new Contract()
                        .Requires()
                        .IsNotNullOrEmpty(this.Description, "Description", "A descrição é obrigatória.")
                        .HasMinLen(this.Description, 2, "Description", "A descrição deve conter no mínimo 2 caracteres.")
                );
        }

        public void Validate()
        {
            AddNotifications(
                    new Contract()
                        .Requires()
                        .IsNotNullOrEmpty(this.Description, "Description", "A descrição é obrigatória.")
                        .HasMinLen(this.Description, 2, "Description", "A descrição deve conter no mínimo 2 caracteres.")
                );
        }
    }
}
