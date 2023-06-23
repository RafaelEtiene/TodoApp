import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { TaskViewModel } from 'src/ViewModel/TaskViewModel';

@Injectable({
  providedIn: 'root'
})
export class TodoTaskService {
  private url: string = "https://localhost:7287/ToDo/"
  constructor(private httpClient: HttpClient) { }

  public GetTasks(): Observable<TaskViewModel[]> {
    return this.httpClient.get<TaskViewModel[]>(this.url + "GetAllTasks")
  }
}
