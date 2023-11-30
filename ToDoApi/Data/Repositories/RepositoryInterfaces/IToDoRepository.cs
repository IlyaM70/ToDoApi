using ToDoApi.Models.Entities;

namespace ToDoApi.Data.Repositories.RepositoryInterfaces
{
    public interface IToDoRepository : IRepository<ToDo>
    {
        Task<ToDo> UpdateAsync(ToDo entity);
    }
}
