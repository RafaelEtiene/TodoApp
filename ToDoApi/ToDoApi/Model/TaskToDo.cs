using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ToDoApi.Model
{
    public class TaskToDo
    {
        [Key]
        public int idTask { get; set; }

        [Column]
        public string description { get; set; }

        [Column]
        public DateTime date { get; set; }

        public int idUser { get; set; }

        public int check { get; set; }
    }
}
