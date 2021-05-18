using AutoMapper;
using TodoList.Application.ViewModels;
using TodoList.Domain.Entities;

namespace TodoList.Web.Config
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Category, CategoryViewModel>();
            CreateMap<CategoryViewModel, Category>();
            CreateMap<Todo, TodoViewModel>();
            CreateMap<TodoViewModel, Todo>();
        }
    }
}
