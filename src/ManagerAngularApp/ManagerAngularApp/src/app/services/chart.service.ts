import {HttpClient, HttpHeaders, HttpParams, HttpResponse} from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
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
      const ret = this.http.post<any>(this.url + '/drugTender/chartsInfo', body, options);
      return ret;
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
    const ret = this.http.post<any>(this.url + '/drugTender/chartInfo', body, options);
    return ret;
  }
    
}