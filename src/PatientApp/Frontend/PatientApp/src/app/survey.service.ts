import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { SurveyDTO } from './survey-dto';

@Injectable({
  providedIn: 'root'
})
export class SurveyService {

  url: string;
  constructor (private http: HttpClient) {
    this.url = "http://localhost:5000/api";
  }

  GetSurveyQuestions(): Observable<any> {
      return this.http.get<any>(this.url + '/survey');
  }
  
  PostSurveyQuestions(Survey: SurveyDTO): Observable<any> {
    return this.http.post<any>(this.url + "/survey", Survey);
  }
}
