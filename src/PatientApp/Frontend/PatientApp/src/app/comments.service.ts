import { Injectable } from '@angular/core';
import { PatientComment } from './comments-observe/comments';

@Injectable({
  providedIn: 'root'
})
export class CommentsService {

  constructor() { }

  getProducts(): PatientComment[] {
    return [
      {comment: 'Great service.', date: '01/11/2021', name: 'Marko Markovic'},
      {comment: "I didn't like the service.", date: '02/11/2021', name: 'Petar Petrovic'},
      {comment: 'Great service.', date: '05/12/2021', name: 'Anonymus'},
      {comment: 'Great service.', date: '02/12/2021', name: 'Milica Mikic'}
    ];
  }
}
