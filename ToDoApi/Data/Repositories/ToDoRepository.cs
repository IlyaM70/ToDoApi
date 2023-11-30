using System;
using ToDoApi.Data.Repositories.RepositoryInterfaces;
using ToDoApi.Models.Entities;

namespace ToDoApi.Data.Repositories
{
    public sealed class ToDoRepository : Repository<ToDo>, IToDoRepository
    {
        private readonly AppDbContext _db;
        public ToDoRepository(AppDbContext db) : base(db)
        {
            _db = db;
        }

        public async Task<ToDo> UpdateAsync(ToDo entity)
        {
           ToDo toDoToUpdate = _db.ToDos.FirstOrDefault(x => x.Id == entity.Id);
            
            toDoToUpdate.Name = entity.Name;
            toDoToUpdate.Description = entity.Description;
            toDoToUpdate.Completed = entity.Completed;
            toDoToUpdate.Deadline = entity.Deadline;
            if (entity.CreatedDate != null && entity.CreatedDate != default(DateTime))
            {
                toDoToUpdate.CreatedDate = entity.CreatedDate;
            }

            await _db.SaveChangesAsync();
            return toDoToUpdate;
        }
    }
}
