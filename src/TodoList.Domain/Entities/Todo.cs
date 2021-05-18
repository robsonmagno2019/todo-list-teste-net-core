using System;
using TodoList.Domain.Enums;
using TodoList.Domain.Flunt.Validations;

namespace TodoList.Domain.Entities
{
    public class Todo : Entity
    {
        protected Todo() { }
        public Todo(string description, DateTime date, Category category)
        {
            this.Description = description;
            this.CreateDate = date;
            this.Status = EStatusTodo.Created;
            this.CategoryId = category.Id;
            this.Category = category;

            AddNotifications(
                    new Contract()
                        .Requires()
                        .IsNotNullOrEmpty(this.Description, "Description", "A descrição é obrigatória.")
                        .HasMinLen(this.Description, 2, "Description", "A descrição deve conter no mínimo 2 caracteres.")
                        .IsNotNull(this.CreateDate, "CreateDate", "A data é obrigatória.")
                        .IsTrue(this.Status == EStatusTodo.Created, "Status", "O status não é criado.")
                        .IsNotNull(this.CategoryId, "CategoryId", "A categoria é obrigatória.")
                );
        }

        public string Description { get; private set; }
        public DateTime CreateDate { get; private set; }
        public DateTime? DateOfTheConclusion { get; private set; }
        public EStatusTodo Status { get; private set; }
        public Guid CategoryId { get; private set; }
        public Category Category { get; private set; }

        public void UpdateToCompleted()
        {
            this.Status = EStatusTodo.Completed;
            this.DateOfTheConclusion = DateTime.Now;

            AddNotifications(
                    new Contract()
                        .Requires()
                        .IsTrue(this.Status == EStatusTodo.Completed, "Status", "O status não foi concluído.")
                        .IsNotNull(this.DateOfTheConclusion, "DateOfTheConclusion", "A data é obrigatória.")
                );
        }

        public void UpdateDate(DateTime date)
        {
            this.DateOfTheConclusion = date;

            AddNotifications(
                    new Contract()
                        .Requires()
                        .IsNotNull(this.DateOfTheConclusion, "DateOfTheConclusion", "A data é obrigatória.")
                );
        }

        public void Update(string description, Category category)
        {
            this.Description = description;
            this.CategoryId = category.Id;
            this.Category = category;

            AddNotifications(
                    new Contract()
                        .Requires()
                        .IsNotNullOrEmpty(this.Description, "Description", "A descrição é obrigatória.")
                        .HasMinLen(this.Description, 2, "Description", "A descrição deve conter no mínimo 2 caracteres.")
                        .IsNotNull(this.CategoryId, "CategoryId", "A categoria é obrigatória.")
                );
        }

        public override string ToString()
        {
            return $"{this.Description}";
        }
    }
}
