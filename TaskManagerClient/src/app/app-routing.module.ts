import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './auth/login/login.component';
import { RegisterComponent } from './auth/register/register.component';
import { UpdateProfileComponent } from './auth/update-profile/update-profile.component';
import { HomeComponent } from './home/home.component';
import { CreateTaskComponent } from './tasks/create-task/create-task.component';
import { EditTaskComponent } from './tasks/edit-task/edit-task.component';
import { TasksComponent } from './tasks/tasks.component';

const routes: Routes = [
  { path: "", component: HomeComponent },
  { path: "login", component: LoginComponent },
  { path: "sign-up", component: RegisterComponent },
  { path: "update-profile", component: UpdateProfileComponent },
  { path: "users/:userid/tasks", component: TasksComponent }
  // { path: "users/:userid/tasks/edit-task", component: EditTaskComponent },
  // { path: "users/:userid/tasks/create-task", component: CreateTaskComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
