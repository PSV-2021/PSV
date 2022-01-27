import {HttpClient, HttpHeaders, HttpParams, HttpResponse} from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
    providedIn: 'root'
  })
export class DrugConsumptionSpecsService {
    url: string;
    constructor (private http: HttpClient) {
        this.url = environment.api;
    }

    GetAllDrugstores(): Observable<any> {
      return this.http.get<any>(this.url + '/drugstore');
    }
    
    RequestDrugSpecification(Url: string, DrugName: string): Observable<any> {
      const body = {
        pharmacyUrl : Url,
        name: DrugName
      };
      let headers = new HttpHeaders({
        'Content-Type': 'application/json',
        'ApiKey': "abcde" });
      let options = { headers: headers };
      const ret = this.http.put<any>(this.url + '/drugSpecification', body, options);
      return ret;
    }

    GenerateReport(start: Date, end: Date): Observable<any> {
      const body = {
        From : start,
        To: end
      };
      console.log(body);
      let headers = new HttpHeaders({
        'Content-Type': 'application/json',
        'ApiKey': "abcde" });
      let options = { headers: headers };
      const ret = this.http.post<any>(this.url + '/drugsConsumptionReport', body, options);
      return ret;
    }
    
}