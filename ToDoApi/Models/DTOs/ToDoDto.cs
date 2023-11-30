using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System;

namespace ToDoApi.Models.DTOs
{
    public class ToDoDto
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(30)]
        [DefaultValue("Task name")]
        public string Name { get; set; } = "";

        [DefaultValue("")]
        [MaxLength(150)]
        public string Description { get; set; } = "";

        [DefaultValue(false)]
        public bool Completed { get; set; } = false;

        [Required]
        [DefaultValue("dd-MM-yyyy hh:mm")]
        public string? Deadline { get; set; }

        [DefaultValue(null)]
        public string? CreatedDate { get; set; }

        public override bool Equals(object o)
        {
            if (!(o is ToDoDto)) { return false; }

            if(((ToDoDto)o).Id == this.Id &&
                ((ToDoDto)o).Name == this.Name &&
                ((ToDoDto)o).Description == this.Description &&
                ((ToDoDto)o).Completed == this.Completed &&
                ((ToDoDto)o).Deadline == this.Deadline &&
                ((ToDoDto)o).CreatedDate == this.CreatedDate)
            { return true; }

            return false;
        }

        public override int GetHashCode()
        {
            return this.Id;
        }


    }
}
