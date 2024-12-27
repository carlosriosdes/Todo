using Microsoft.EntityFrameworkCore;
using TodoApp.Infraestructure.Data.Context;
using TodoApp.Infraestructure.IoC;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionStringTodoApp = builder.Configuration.GetConnectionString("SqlConecctionTodoApp");
builder.Services.AddDbContext<TodoAppDBContext>(x => x.UseSqlServer(connectionStringTodoApp), ServiceLifetime.Scoped);

DependencyContainer.RegisterServices(builder.Services);

var app = builder.Build();

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
