import { Component, Input, OnInit } from '@angular/core';
import { Task } from '../../models/task';

@Component({
  selector: 'app-task-entry',
  templateUrl: './task-entry.component.html',
  styleUrls: ['./task-entry.component.css']
})
export class TaskEntryComponent implements OnInit {

  @Input() task!: Task
  dueDate: string | undefined;

  constructor() { }

  ngOnInit(): void {
    this.dueDate = new Date(this.task?.dueDate).toLocaleDateString();
  }

}
