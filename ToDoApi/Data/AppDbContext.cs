using Microsoft.EntityFrameworkCore;
using ToDoApi.Models.Entities;

namespace ToDoApi.Data
{
    public sealed class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<ToDo> ToDos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ToDo>().HasData(

                new ToDo
                {
                    Id = 1,
                    Name = "Помыть полы",
                    Deadline = DateTime.Now.AddDays(1),
                    CreatedDate = DateTime.Now,
                },
                new ToDo
                {
                    Id = 2,
                    Name = "Сходить в магазин",
                    Deadline = DateTime.Now.AddDays(1),
                    CreatedDate = DateTime.Now,
                    Description = "Купить яблоки и бананы"
                },
                new ToDo
                {
                    Id = 3,
                    Name = "Вынести мусор",
                    Deadline = DateTime.Now.AddDays(1),
                    CreatedDate = DateTime.Now,
                    Completed = true
                }

              );
        }
    }
}
