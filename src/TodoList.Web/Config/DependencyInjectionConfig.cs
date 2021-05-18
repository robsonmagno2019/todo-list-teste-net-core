using Microsoft.Extensions.DependencyInjection;
using TodoList.Application;
using TodoList.Application.Interfaces;
using TodoList.Domain.Interfaces.Repositories;
using TodoList.Domain.Interfaces.Services;
using TodoList.Domain.Services;
using TodoList.Infra.Contexts;
using TodoList.Infra.Interfaces;
using TodoList.Infra.Repositories;
using TodoList.Infra.UoW;

namespace TodoList.Web.Config
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolverDependencies(this IServiceCollection services)
        {
            services.AddScoped<TodoDbContext>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ITodoRepository, TodoRepository>();

            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<ITodoService, TodoService>();

            services.AddScoped<ICategoryAppService, CategoryAppService>();
            services.AddScoped<ITodoAppService, TodoAppService>();

            return services;
        }
    }
}
