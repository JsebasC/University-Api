import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CourseDeleteComponent } from './component/course-delete/course-delete.component';
import { CourseEditComponent } from './component/course-edit/course-edit.component';
import { CourseListComponent } from './component/course-list/course-list.component';
import { CourseSaveComponent } from './component/course-save/course-save.component';

const routes: Routes = [
  {path : 'course-list', component: CourseListComponent  },
  { path: 'course-save', component: CourseSaveComponent },
  { path: 'course-edit/:id', component: CourseEditComponent },
  {path : 'course-delete/:id', component: CourseDeleteComponent  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
