import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { TaskService } from '../core/services/task.service';
import { Task } from '../shared/models/task';

@Component({
  selector: 'app-tasks',
  templateUrl: './tasks.component.html',
  styleUrls: ['./tasks.component.css']
})
export class TasksComponent implements OnInit {

  tasks: Task[] | undefined;
  histories: Task[] | undefined;
  private id: number = 0;

  constructor(private taskService: TaskService,
    private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.getTasks();
    this.getHistories();
  }

  getTasks() {
    this.route.paramMap.subscribe(
      params => {
        this.id = Number(params.get('userid'));
        this.taskService.getTasks(this.id).subscribe(
          t => {
            this.tasks = t;
            console.table(this.tasks);
          }
        )
      }
    )
  }

  getHistories() {
    this.route.paramMap.subscribe(
      params => {
        this.id = Number(params.get('userid'));
        this.taskService.getHistories(this.id).subscribe(
          h => {
            this.histories = h;
            console.table(this.histories);
          }
        )
      }
    )
  }

}
