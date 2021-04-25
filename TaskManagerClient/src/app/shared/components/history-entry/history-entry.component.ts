import { Component, Input, OnInit } from '@angular/core';
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

  constructor() { }

  ngOnInit(): void {
    this.completed = new Date(this.history.completed).toLocaleDateString();
    this.dueDate = new Date(this.history.dueDate).toLocaleDateString();
  }

}
