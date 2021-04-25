import { DOCUMENT } from '@angular/common';
import { Component, Inject, Input, OnInit } from '@angular/core';
import { TaskService } from 'src/app/core/services/task.service';
import { Task } from '../../models/task';

@Component({
  selector: 'app-history-entry',
  templateUrl: './history-entry.component.html',
  styleUrls: ['./history-entry.component.css']
})
export class HistoryEntryComponent implements OnInit {

  @Input() history!: Task
  completed: string | undefined;
  dueDate: string | undefined;

  constructor(private taskService: TaskService,
    @Inject(DOCUMENT) private _document: Document) { }

  ngOnInit(): void {
    this.completed = new Date(this.history.completed).toLocaleDateString();
    this.dueDate = new Date(this.history.dueDate).toLocaleDateString();
  }

  deleteHistory() {
    this.taskService.deleteHistory(this.history.id).subscribe(
      (res) => {
        console.log("Deleted");
        this.reload();
      },
      (err) => {
        console.log(err);
      }
    );
  }

  revertHistory() {
    this.taskService.revertTask(this.history.id).subscribe(
      (res) => {
        console.log("Reverted");
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
