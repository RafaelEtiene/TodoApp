import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { TaskViewModel } from 'src/ViewModel/TaskViewModel';
import { TodoTaskService } from 'src/api/todo-task.service';

@Component({
  selector: 'app-card-task',
  templateUrl: './card-task.component.html',
  styleUrls: ['./card-task.component.css']
})
export class CardTaskComponent implements OnInit {
  public description: string = "";
  public tasks: TaskViewModel[] = [];
  public mostrarModal: boolean = false;

  constructor(private taskService: TodoTaskService) { }
  ngOnInit(): void {
    this.getTasks();
  }

  getTasks(){
    this.taskService.GetTasks().subscribe(r => {
      this.tasks = r;
    })
  }
  adicionarTask(){
    this.mostrarModal = true;
  }

  insertNewTask(): void {
    var taskData: TaskViewModel =
    {
      idTask: 0,
      idUser: 1,
      description: this.description,
      createDate: new Date()
    }
    this.taskService.InsertTask(taskData).subscribe(r => {
      this.mostrarModal = false;
      this.getTasks();
    })
    
  }
  deleteTask(idTask: number){
    this.taskService.DeleteTask(idTask).subscribe(r => {
      this.getTasks();
    });
  }
}
