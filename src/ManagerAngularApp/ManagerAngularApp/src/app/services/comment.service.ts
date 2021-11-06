import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})

export class CommentService {

  url: string;
  constructor (private http: HttpClient) {
    this.url = "http://localhost:5000/api";
  }

  GetAllComments(): Observable<any> {
      return this.http.get<any>(this.url + '/managercomments');
  }
  
  publishComment(Id: number): any {
    return this.http.post<any>(this.url + "/managercomments", Id);
  }
}
