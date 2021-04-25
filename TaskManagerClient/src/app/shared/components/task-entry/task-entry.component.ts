import { DOCUMENT } from '@angular/common';
import { Component, Inject, Input, OnInit } from '@angular/core';
import { TaskService } from 'src/app/core/services/task.service';
import { Task } from '../../models/task';

@Component({
  selector: 'app-task-entry',
  templateUrl: './task-entry.component.html',
  styleUrls: ['./task-entry.component.css']
})
export class TaskEntryComponent implements OnInit {

  @Input() task!: Task
  dueDate: string | undefined;

  constructor(private taskService: TaskService,
    @Inject(DOCUMENT) private _document: Document) {
  }

  ngOnInit(): void {
    this.dueDate = new Date(this.task?.dueDate).toLocaleDateString();
  }

  deleteTask() {
    this.taskService.deleteTask(this.task.id).subscribe(
      (res) => {
        console.log("Deleted");
        this.reload();
      },
      (err) => {
        console.log(err);
      }
    );
  }

  completeTask() {
    this.taskService.completeTask(this.task.id).subscribe(
      (res) => {
        console.log("Completed");
        this.reload();
      },
      (err) => {
        console.log(err);
      }
    );
  }

  reload() {
    this._document.defaultView?.location.reload();
  }
}
