import {HttpClient, HttpErrorResponse, HttpHeaders, HttpParams, HttpResponse} from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, throwError } from 'rxjs';
import { catchError, map} from 'rxjs/operators';
import { environment } from 'src/environments/environment';

@Injectable({
    providedIn: 'root'
  })
export class ChartService {
    url: string;
    constructor (private http: HttpClient) {
        this.url = environment.api;
    }

    GetChartInfo(start: Date, end: Date): Observable<any> {
        const body = {
          From : start,
          To: end
        };
        console.log(body);
      let headers = new HttpHeaders({
        'Content-Type': 'application/json',
        'ApiKey': "abcde" });
      let options = { headers: headers };
      return this.http.post<any>(this.url + '/drugTender/chartsInfo', body, options).pipe(map(res => res), catchError(this.errorHandler));
    }
    GetSingleChartInfo(start: Date, end: Date, id: number): Observable<any> {
      const body = {
        From : start,
        To: end,
        Id: id
      };
      console.log(body);
    let headers = new HttpHeaders({
      'Content-Type': 'application/json',
      'ApiKey': "abcde" });
    let options = { headers: headers };
    return this.http.post<any>(this.url + '/drugTender/chartInfo', body, options).pipe(map(res => res), catchError(this.errorHandler));
  }

  errorHandler(error: HttpErrorResponse) {
    return throwError(error.error);
  }
    
}