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
  public task: TaskViewModel = { idTask: 0 };

  constructor(private taskService: TodoTaskService) { }
  ngOnInit(){
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

  insertNewTask(){
    this.task =
    {
      idTask: 0,
      idUser: 1,
      description: "",
      date: new Date(),
      check: 0,
    }
    this.taskService.InsertTask(this.task).subscribe(r => {
      this.mostrarModal = false;
      this.getTasks();
    })
  }
  deleteTask(idTask: number){
    this.taskService.DeleteTask(idTask).subscribe(r => {
      this.getTasks();
    });
  }

  getTaskById(idTask: number){
    this.taskService.GetTaskById(idTask).subscribe(r => {
      this.task = r;
    })
  }

  editTask(idTask: number){

    this.mostrarModal = true;
    this.getTaskById(idTask);
  }

  cancelar(){
    this.mostrarModal = false;
  }
}
