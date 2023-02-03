import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Course } from '../domain/course';
import { environment } from 'src/environments/environment';


@Injectable({
  providedIn: 'root',
})
export class CourseService {

  public url: string ;

  constructor(public httpClient: HttpClient) {
    this.url = environment.apiUrl + 'api/Courses/';
    //this.url = 'http://localhost/University.API/api/Courses';
    //this.url = '../../assets/MOCK_DATA.json';
  }

  public getById(id: number): Observable<any>{        
    return  this.httpClient.get(this.url +'/'+ id);
  }

  //GetAll, Recibe cualquier objeto
  public getAll(): Observable<any> {
    return this.httpClient.get(this.url);
  }

  public Post(course : Course): Observable<any>{
    return this.httpClient.post(this.url,course);
  }

  public Put(course: Course): Observable<any>{
    return this.httpClient.put(this.url+course.CourseId, course);
  }

  public Delete(id: number){
    return this.httpClient.delete(this.url + id);
  }

}
