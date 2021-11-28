import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { CommentDTO } from '../comments-observe/comment.dto';

@Injectable({
  providedIn: 'root'
})
export class CommentsService {
 

  url: string;
  constructor (private http: HttpClient) {
    this.url = "http://localhost:5000/api";
  }

    GetAprovedComments(): Observable<any> {
      return this.http.get<any>(this.url + '/comments');
  }
    SendComment(comment: CommentDTO):Observable<any> {
      console.log(comment.Content);
      const body = {
        comment: comment
      }
      const ret = this.http.post<any>(this.url + "/comments", comment);
      return ret;

    }

}
