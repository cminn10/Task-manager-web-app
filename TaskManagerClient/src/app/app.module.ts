import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { AppRoutingModule } from './app-routing.module';
import { FormsModule } from '@angular/forms';

import { AppComponent } from './app.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { TaskEntryComponent } from './shared/components/task-entry/task-entry.component';
import { HeaderComponent } from './core/layout/header/header.component';
import { TokenInterceptorService } from './core/services/token-interceptor.service';
import { HomeComponent } from './home/home.component';
import { LoginComponent } from './auth/login/login.component';
import { RegisterComponent } from './auth/register/register.component';
import { TasksComponent } from './tasks/tasks.component';
import { EditTaskComponent } from './tasks/edit-task/edit-task.component';
import { UpdateProfileComponent } from './auth/update-profile/update-profile.component';
import { HistoryEntryComponent } from './shared/components/history-entry/history-entry.component';

@NgModule({
  declarations: [
    AppComponent,
    TaskEntryComponent,
    HeaderComponent,
    HomeComponent,
    LoginComponent,
    RegisterComponent,
    TasksComponent,
    EditTaskComponent,
    UpdateProfileComponent,
    HistoryEntryComponent
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    AppRoutingModule,
    NgbModule,
    HttpClientModule,
    FormsModule
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: TokenInterceptorService, multi: true }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
