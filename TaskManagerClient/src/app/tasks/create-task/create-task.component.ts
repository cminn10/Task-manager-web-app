import { DOCUMENT } from '@angular/common';
import { Component, Inject, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { NgbCalendar, NgbDateStruct } from '@ng-bootstrap/ng-bootstrap';
import { TaskService } from 'src/app/core/services/task.service';
import { TaskInfo } from 'src/app/shared/models/task-info';

@Component({
  selector: 'app-create-task',
  templateUrl: './create-task.component.html',
  styleUrls: ['./create-task.component.css']
})
export class CreateTaskComponent implements OnInit {

  taskCreate: TaskInfo = {
    userId: 0,
    title: '',
    description: '',
    dueDate: undefined,
    priority: undefined,
    remarks: ''
  }
  invalidCreate: boolean = false;
  createSucess: boolean = false;
  model!: NgbDateStruct;
  date!: { year: number, month: number };

  constructor(private taskService: TaskService,
    private route: ActivatedRoute,
    private calendar: NgbCalendar,
    @Inject(DOCUMENT) private _document: Document) { }

  ngOnInit() {
    this.route.paramMap.subscribe(
      params => {
        this.taskCreate.userId = Number(params.get('userid'));
      }
    );
  }

  create() {
    this.taskCreate.dueDate = new Date(this.model.year, this.model.month - 1, this.model.day);
    this.taskService.createTask(this.taskCreate).subscribe(
      (response) => {
        this.reload();
      },
      (error) => {
        this.invalidCreate = true;
      },
      () => {
        console.log(this.taskCreate);
      }
    );
  }
  reload() {
    this._document.defaultView?.location.reload();
  }
}
