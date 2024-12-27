using Microsoft.Extensions.DependencyInjection;
using TodoApp.Application.Contracts;
using TodoApp.Application.Services;
using TodoApp.Domain.Contracts;
using TodoApp.Infraestructure.Data.Repositories;

namespace TodoApp.Infraestructure.IoC
{
    public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<ITodoService, TodoService>();
            services.AddScoped<ITodoRepository, TodoRepository>();
        }
    }
}
