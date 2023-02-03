import { Component,OnInit, OnDestroy} from '@angular/core';
import { Course } from 'src/app/domain/course';
import { CourseService } from 'src/app/service/course.service';

import { subscribeOn, Subscription } from 'rxjs'; //observador oservable

@Component({
  selector: 'app-course-list',
  templateUrl: './course-list.component.html',
  styleUrls: ['./course-list.component.css'],
})
  
export class CourseListComponent implements OnInit, OnDestroy{

  public courses: Course[];
  public subCourses: Subscription = new Subscription;

  constructor(public courseService: CourseService) {
    this.courses = [];
  }

  ngOnDestroy(): void {
    this.subCourses.unsubscribe();//para que no se desuscriba 
  }

  ngOnInit(): void {
    this.getAll();
  }

  getAll() {
    this.subCourses = this.courseService.getAll().subscribe((data) => {
      //para que el componente este pendiente osbservador, pendiente escuchando
      
      this.courses = data;
    });
  }
}
