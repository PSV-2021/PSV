import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class SurveyService {

  url: string;
  constructor (private http: HttpClient) {
    this.url = "http://" + environment.apiUrl + ":" + environment.port +"/api";
  }

  GetSurveyQuestions(): Observable<any> {
      return this.http.get<any>(this.url + '/survey');
  }
  
  PostSurveyQuestions(Survey: any, id: any, ap: any): Observable<any> {
    return this.http.post<any>(this.url + "/survey/"+id +"/"+ap, Survey);
  }
}
