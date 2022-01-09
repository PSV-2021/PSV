import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { CommentDTO } from '../comments-observe/comment.dto';
import { environment } from 'src/environments/environment';
import axios from "axios";
@Injectable({
  providedIn: 'root'
})
export class CommentsService {
 

  url: string;
  constructor (private http: HttpClient) {
    console.log(environment.apiUrl)
    this.url = "http://"+ environment.apiUrl + ":" + environment.port +"/api";
  }

    GetAprovedComments(): Observable<any> {
      console.log(this.url+"/comments");
      axios.get(this.url+"/comments").then((resp)=>{console.log(resp)})
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
