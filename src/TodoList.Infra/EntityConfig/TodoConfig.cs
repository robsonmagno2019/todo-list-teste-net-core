using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TodoList.Domain.Entities;

namespace TodoList.Infra.EntityConfig
{
    public class TodoConfig : IEntityTypeConfiguration<Todo>
    {
        public void Configure(EntityTypeBuilder<Todo> builder)
        {
            builder.ToTable("Todos");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Description)
                .HasColumnType("varchar(100)")
                .HasMaxLength(100)
                .IsRequired();
            builder.Property(x => x.CreateDate)
                .HasColumnType("datetime2")
                .IsRequired();
            builder.Property(x => x.DateOfTheConclusion)
                .HasColumnType("datetime2")
                .IsRequired(false);
            builder.Property(x => x.Status).IsRequired();
            builder.HasOne(x => x.Category)
                .WithMany(c => c.Todos)
                .HasForeignKey(x => x.CategoryId)
                .IsRequired();
            builder.Ignore(x => x.Notifications);
        }
    }
}
