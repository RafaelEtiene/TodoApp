using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ToDoApi.Model
{
    public class TaskToDo
    {
        [Key]
        public int idTask { get; set; }
        [Column]
        public String Description { get; set; }
        [Column]
        public DateTime CreateDate { get; set; } = DateTime.Now;
        [ForeignKey("userId")]
        public int idUser { get; set; }
    }
}
