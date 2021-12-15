import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})

export class CommentService {

  url: string;
  constructor (private http: HttpClient) {
    this.url = environment.api;
  }

  GetAllComments(): Observable<any> {
      return this.http.get<any>(this.url + '/managercomments');
  }
  
  publishComment(Id: number): any {
    return this.http.post<any>(this.url + "/managercomments", Id);
  }
  
  returnComment(Id: number): any {
    return this.http.post<any>(this.url + "/managercomments", Id);
  }
}
