using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ToDoApi.Models.Entities
{
    public class ToDo
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string Description { get; set; } = "";
        public bool Completed { get; set; } = false;
        public DateTime? Deadline { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
