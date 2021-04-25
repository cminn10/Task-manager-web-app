import { DOCUMENT } from '@angular/common';
import { Component, Inject, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { NgbDateStruct, NgbCalendar } from '@ng-bootstrap/ng-bootstrap';
import { TaskService } from 'src/app/core/services/task.service';
import { TaskInfo } from 'src/app/shared/models/task-info';

@Component({
  selector: 'app-edit-task',
  templateUrl: './edit-task.component.html',
  styleUrls: ['./edit-task.component.css']
})
export class EditTaskComponent implements OnInit {

  taskEdit: TaskInfo = {
    userId: 0,
    title: '',
    description: '',
    dueDate: undefined,
    priority: undefined,
    remarks: ''
  }
  invalidEdit: boolean = false;
  editSuccess: boolean = false;
  model!: NgbDateStruct;
  date!: { year: number, month: number };
  constructor(private taskService: TaskService,
    private route: ActivatedRoute,
    private router: Router,
    private calendar: NgbCalendar) { }

  ngOnInit() {
    this.route.paramMap.subscribe(
      params => {
        this.taskEdit.userId = Number(params.get('userid'));
      }
    );
  }

  Edit() {
    this.taskEdit.dueDate = new Date(this.model.year, this.model.month - 1, this.model.day);
    this.taskService.createTask(this.taskEdit).subscribe(
      (response) => {
        this.editSuccess = true;
        setTimeout(() => {
          this.router.navigateByUrl(`users/${this.taskEdit.userId}/tasks`);
        }, 2000);
      },
      (error) => {
        this.invalidEdit = true;
      },
      () => {
        console.log(this.taskEdit);
      }
    );
  }
}
