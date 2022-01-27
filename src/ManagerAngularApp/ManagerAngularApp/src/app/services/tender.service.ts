import {HttpClient, HttpHeaders, HttpParams, HttpResponse} from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { TenderDto } from '../tender/tender.dto';

@Injectable({
    providedIn: 'root'
  })
export class TenderService {
    url: string;
    constructor (private http: HttpClient) {
        this.url = environment.api;
    }
    
    GetAllFiles(): Observable<any> {
        return this.http.get<any>(this.url + '/drugTender');
    }

    GetAllActiveTenders(): Observable<any>{
      return this.http.get<any>(this.url + '/drugTender/ongoing');
    }

    GetAllOffersForTender(id: string): Observable<any>{
      return this.http.get<any>(this.url + '/drugTender/offer/' + id);
    }

    GetAllOffersForDrugstore(id: number): Observable<any>{
      return this.http.get<any>(this.url + '/drugTender/offers/' + id);
    }

    SaveTender(tenderEnd: Date, tenderInfo: TenderDto[]): Observable<any> {
      const body = {
        TenderEnd : tenderEnd,
        TenderInfo: tenderInfo
      };
      console.log(body);
      let headers = new HttpHeaders({
        'Content-Type': 'application/json',
        'ApiKey': "abcde" });
      let options = { headers: headers };
      return this.http.post<any>(this.url + '/drugTender', body, options);
    }
  }
