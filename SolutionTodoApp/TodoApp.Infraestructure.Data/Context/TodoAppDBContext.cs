using Microsoft.EntityFrameworkCore;
using TodoApp.Domain.Models;

namespace TodoApp.Infraestructure.Data.Context
{
    public class TodoAppDBContext : DbContext
    {
        public TodoAppDBContext(DbContextOptions options) : base(options) { }
        public DbSet<TodoStates> TodoStates { get; set; }
        public DbSet<Todo> Todo { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TodoStates>(entity =>
            {
                entity.ToTable("TodoStates");
                entity.HasKey(c => c.IdTodoState);
                entity.Property(c => c.IdTodoState);
                entity.Property(c => c.Description);
            });

            modelBuilder.Entity<Todo>(entity =>
            {
                entity.ToTable("Todo");
                entity.HasKey(c => c.IdTodo);
                entity.Property(c => c.IdTodo);
                entity.Property(c => c.PendingApproval);
                entity.Property(c => c.Title);
            });

            modelBuilder.Entity<Todo>()
                .HasOne(d => d.TodoState)
                .WithMany(c => c.Todos)
                .HasForeignKey(d => d.IdTodoState)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
