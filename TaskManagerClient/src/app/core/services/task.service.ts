import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Task } from 'src/app/shared/models/task';
import { ApiService } from './api.service';

@Injectable({
  providedIn: 'root'
})
export class TaskService {

  //task: Task | undefined;

  constructor(private apiService: ApiService) { }

  getTasks(id: number): Observable<any[]> {
    return this.apiService.getAll('/tasks/user', id);
  }

  getTaskDetails(id: number): Observable<any> {
    return this.apiService.getOne('/tasks', id);
  }

  getHistories(id: number): Observable<any[]> {
    return this.apiService.getAll('/history/user', id);
  }

  getHistoryDetails(id: number): Observable<any> {
    return this.apiService.getOne('/history', id);
  }

  createTask(task: Task): Observable<any> {
    return this.apiService.create('/tasks/create', task);
  }

  updateTask(task: Task): Observable<any> {
    return this.apiService.create('/tasks/update', task);
  }

  completeTask(id: number): Observable<any> {
    return this.apiService.getOne('/tasks/complete', id);
  }

  revertTask(id: number): Observable<any> {
    return this.apiService.getOne('/history/revert', id);
  }

  deleteTask(id: number) {
    return this.apiService.delete('/tasks/delete', id);
  }

  deleteHistory(id: number) {
    return this.apiService.delete('/history/delete', id);
  }

}
