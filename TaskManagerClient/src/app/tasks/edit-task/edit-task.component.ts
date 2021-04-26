import { DOCUMENT } from '@angular/common';
import { Component, Inject, Input, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { NgbDateStruct, NgbCalendar } from '@ng-bootstrap/ng-bootstrap';
import { TaskService } from 'src/app/core/services/task.service';
import { Task } from 'src/app/shared/models/task';
import { TaskInfo } from 'src/app/shared/models/task-info';

@Component({
  selector: 'app-edit-task',
  templateUrl: './edit-task.component.html',
  styleUrls: ['./edit-task.component.css']
})
export class EditTaskComponent implements OnInit {


  @Input() originalTask!: Task;

  invalidEdit: boolean = false;
  editSuccess: boolean = false;
  model!: NgbDateStruct;
  date!: { year: number, month: number };
  constructor(private taskService: TaskService,
    // private route: ActivatedRoute,
    // private router: Router,
    private calendar: NgbCalendar,
    @Inject(DOCUMENT) private _document: Document) { }

  ngOnInit() {
    // this.route.paramMap.subscribe(
    //   params => {
    //     this.taskEdit.userId = Number(params.get('userid'));
    //   }
    // );
  }

  Edit() {
    if (this.model) this.originalTask.dueDate = new Date(this.model.year, this.model.month - 1, this.model.day);
    this.taskService.updateTask(this.originalTask).subscribe(
      (response) => {
        // this.editSuccess = true;
        // setTimeout(() => {
        //   this.router.navigateByUrl(`users/${this.taskEdit.userId}/tasks`);
        // }, 2000);
        this.reload();
      },
      (error) => {
        this.invalidEdit = true;
        console.log(this.originalTask);
      },
      () => {
        console.log(this.originalTask);
      }
    );
  }
  reload() {
    this._document.defaultView?.location.reload();
  }
}
