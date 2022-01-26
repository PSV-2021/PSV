import {HttpClient, HttpErrorResponse, HttpHeaders, HttpParams, HttpResponse} from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, throwError } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
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
        return this.http.get<any>(this.url + '/drugTender').pipe(map(res => res), catchError(this.errorHandler));
    }

    GetAllActiveTenders(): Observable<any>{
      return this.http.get<any>(this.url + '/drugTender/ongoing').pipe(map(res => res), catchError(this.errorHandler));
    }

    GetAllOffersForTender(id: string): Observable<any>{
      return this.http.get<any>(this.url + '/drugTender/offer/' + id).pipe(map(res => res), catchError(this.errorHandler));
    }

    GetAllOffersForDrugstore(id: number): Observable<any>{
      return this.http.get<any>(this.url + '/drugTender/offers/' + id).pipe(map(res => res), catchError(this.errorHandler));
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
      return this.http.post<any>(this.url + '/drugTender', body, options).pipe(map(res => res), catchError(this.errorHandler));
    }

    errorHandler(error: HttpErrorResponse) {
      return throwError(error.error);
    }
  }
