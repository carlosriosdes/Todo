using Microsoft.EntityFrameworkCore;
using System.Reflection;
using TodoApp.API.Middlewares;
using TodoApp.Infraestructure.Data.Context;
using TodoApp.Infraestructure.IoC;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    // Añadir la documentación XML generada
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
});


var connectionStringTodoApp = builder.Configuration.GetConnectionString("SqlConecctionTodoApp");
builder.Services.AddDbContext<TodoAppDBContext>(x => x.UseSqlServer(connectionStringTodoApp), ServiceLifetime.Scoped);

DependencyContainer.RegisterServices(builder.Services);

var app = builder.Build();

app.UseMiddleware<ErrorHandlingMiddleware>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
