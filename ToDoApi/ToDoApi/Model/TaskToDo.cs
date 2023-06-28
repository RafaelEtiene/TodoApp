using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ToDoApi.Model
{
    public class TaskToDo
    {
        [Key]
        public int idTask { get; set; }
        [Column]
        public string Description { get; set; }
        [Column]
        public DateTime Date { get; set; }
        [ForeignKey("userId")]
        public int idUser { get; set; }
    }
}
