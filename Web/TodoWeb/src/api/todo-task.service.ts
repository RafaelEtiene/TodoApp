import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { TaskViewModel } from 'src/ViewModel/TaskViewModel';

@Injectable({
  providedIn: 'root'
})
export class TodoTaskService {
  private url: string = "http://localhost:7287/ToDo"
  constructor(private httpClient: HttpClient) { }

  public GetTasks(): Observable<TaskViewModel[]> {
    return this.httpClient.get<TaskViewModel[]>(`${this.url}/GetAllTasks`)
  }

  public InsertTask(task: TaskViewModel) : Observable<TaskViewModel> {
    return this.httpClient.post<TaskViewModel>(`${this.url}/InsertTask`, task)
  }

  public DeleteTask(idTask: number) : Observable<TaskViewModel> {
    return this.httpClient.delete<TaskViewModel>(`${this.url}/DeleteTask?idTask=${idTask}`)
  }

  public UpdateTask(task: TaskViewModel) : Observable<boolean> {
    return this.httpClient.put<boolean>(`${this.url}/UpdateTask?idTask=${task.idTask}`, task)
  }

  public GetTaskById(idTask: number) : Observable<TaskViewModel> {
    return this.httpClient.get<TaskViewModel>(`${this.url}/GetTaskById/${idTask}`)    
  }
}
