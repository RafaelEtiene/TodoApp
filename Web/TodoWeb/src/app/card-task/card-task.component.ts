import { Component, OnInit } from '@angular/core';
import { TaskViewModel } from 'src/ViewModel/TaskViewModel';
import { TodoTaskService } from 'src/api/todo-task.service';

@Component({
  selector: 'app-card-task',
  templateUrl: './card-task.component.html',
  styleUrls: ['./card-task.component.css']
})
export class CardTaskComponent implements OnInit {
  public tasks: TaskViewModel[] = [];

  constructor(private taskService: TodoTaskService){}
  ngOnInit(): void {
    this.taskService.GetTasks().subscribe(r => {
      this.tasks = r;
    })
}
}
