import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { PatientComment } from './comments-observe/comments';

@Injectable({
  providedIn: 'root'
})
export class CommentsService {

  //constructor() { }

  /*getProducts(): PatientComment[] {
    return [
      {comment: 'Great service.', date: '01/11/2021', name: 'Marko Markovic'},
      {comment: "I didn't like the service.", date: '02/11/2021', name: 'Petar Petrovic'},
      {comment: 'Great service.', date: '05/12/2021', name: 'Anonymus'},
      {comment: 'Great service.', date: '02/12/2021', name: 'Milica Mikic'}
    ];
  }*/
  
  url: string;
  constructor (private http: HttpClient) {
    this.url = "http://localhost:5000/api";
  }

    GetAprovedComments(): Observable<any> {
      return this.http.get<any>(this.url + '/comments');
  }

}
