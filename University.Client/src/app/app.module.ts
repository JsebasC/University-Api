import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';

import { AppComponent } from './app.component';
import { CourseListComponent } from './component/course-list/course-list.component';

import { CourseService } from './service/course.service';
import { CourseSaveComponent } from './component/course-save/course-save.component';
import { FormsModule } from '@angular/forms';
import { CourseEditComponent } from './component/course-edit/course-edit.component';
import { CourseDeleteComponent } from './component/course-delete/course-delete.component';

@NgModule({
  declarations: [AppComponent, CourseListComponent, CourseSaveComponent, CourseEditComponent, CourseDeleteComponent],
  imports: [
    BrowserModule,
    AppRoutingModule,//routing : Navegar entre diferentes componentes
    HttpClientModule, 
    FormsModule
  ],
  providers: [CourseService],
  bootstrap: [AppComponent],
})
export class AppModule {}
