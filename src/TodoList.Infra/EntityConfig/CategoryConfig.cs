using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;
using TodoList.Domain.Entities;

namespace TodoList.Infra.EntityConfig
{
    public class CategoryConfig : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Categories");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Description)
                .HasColumnType("varchar(50)")
                .HasMaxLength(50)
                .IsRequired();
            builder.Ignore(x => x.Todos);
            builder.Ignore(x => x.Notifications);
            builder.HasData(
                    new List<Category>
                    {
                        new Category("Estudo"),
                        new Category("Reunião")
                    }
                );
        }
    }
}
