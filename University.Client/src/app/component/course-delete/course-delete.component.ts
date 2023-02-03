import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Course } from 'src/app/domain/course';
import { CourseService } from 'src/app/service/course.service';

@Component({
  selector: 'app-course-delete',
  templateUrl: './course-delete.component.html',
  styleUrls: ['./course-delete.component.css'],
})
export class CourseDeleteComponent implements OnInit {
  public course: Course = new Course(0, '', 0);
  public id: number = 0;

  public showMsg: boolean = false;
  public msg: string = '';
  public type: string = '';

  constructor(
    public courseService: CourseService,
    private router: Router,
    private activatedRoute: ActivatedRoute
  ) {}

  ngOnInit(): void {
    this.getById();
  }

  public getById() {
    let param = this.activatedRoute.snapshot.paramMap.get('id'); //parametros que voy a recibir por url}
    if (param) {
      this.id = parseInt(param, 10);
      this.courseService.getById(this.id).subscribe((data) => {
        this.course = data;
      });
    } else {
      this.showMsg = true;
      this.msg = 'An error has ocurred in the procedure';
      this.type = 'danger';
    }
  }

  public delete() {
    this.courseService.Delete(this.course.CourseId).subscribe(
      (data) => {
        this.router.navigate(['/course-list']); //apenas guardo me devuelve a list
      },
      (error) => {
        console.log(error);
        this.showMsg = true;
        this.msg = 'An error has ocurred in the procedure';
        this.type = 'danger';
      }
    );
  }
}
