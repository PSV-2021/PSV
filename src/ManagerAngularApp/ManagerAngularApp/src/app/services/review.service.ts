import {HttpClient, HttpErrorResponse, HttpParams, HttpResponse} from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { ReviewDto } from '../review/review.dto';
import { map } from 'rxjs-compat/operator/map';
import { environment } from 'src/environments/environment';

@Injectable({
    providedIn: 'root'
  })
export class ReviewService {
    url: string;
    smartphone: any = [];
    constructor (private http: HttpClient) {
      this.url = environment.api;
    }

    GetAllReviews(): Observable<any> {
        return this.http.get<any>(this.url + '/drugstorefeedback').pipe(res=> res, catchError(this.errorHandler));
    }

    GetDrugStoreName(id: string): Observable<any>{
      return this.http.get<any>(this.url + '/drugstore/name/', {params:{id: id}}).pipe(res => res, catchError(this.errorHandler));
    }

    SendNewReview(pharmacyId: number, review: string): Observable<any>{
      const body = {
        pharmacyId : pharmacyId,
        review : review
      };
      return this.http.post<any>(this.url + "/drugstorefeedback", body).pipe(res => res ,catchError(this.errorHandler))
    }

    errorHandler(error: HttpErrorResponse) {
      return throwError(error.error);
    }
}