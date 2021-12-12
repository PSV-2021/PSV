import {HttpClient, HttpParams, HttpResponse} from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';
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
        return this.http.get<any>(this.url + '/drugstorefeedback');
    }

    GetDrugStoreName(id: string): Observable<string>{
      return this.http.get<any>(this.url + '/drugstore/name/', {params:{id: id}});
    }

    SendNewReview(pharmacyId: number, review: string): any{
      const body = {
        pharmacyId : pharmacyId,
        review : review
      };
      const ret = this.http.post<any>(this.url + "/drugstorefeedback", body);
      return ret;
    }
}