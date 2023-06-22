using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ToDoApi.Model
{
    public class User
    {
        [Key]
        public int idUser { get; set; }
        [Column]
        public string name { get; set; }
        [Column]
        public string email { get; set; }
        public List<TaskToDo> tasks { get; set; }
    }
}
