import {HttpClient, HttpHeaders, HttpParams, HttpResponse} from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';
import { catchError } from 'rxjs/operators';
import { ReviewDto } from '../reviews/review.dto';
import { ResponseDto } from '../reviews/response.dto';

import { map } from 'rxjs-compat/operator/map';

@Injectable({
    providedIn: 'root'
  })
export class ReviewsService {
    url: string;
    smartphone: any = [];
    constructor (private http: HttpClient) {
        this.url = "http://localhost:5001/api" //ovo ne znam posto ne pisem ja backend za sad
    }

    GetAllMyReviews(): Observable<any> {
      let headers = new HttpHeaders({
        'Content-Type': 'application/json',
        'ApiKey': "DrugstoreSecretKey" });
      let options = { headers: headers };
        return this.http.get<any>(this.url + '/drugstoreresponse/getAllMyFeedbacks', options);
    }

    GetHospitalName(id: string): Observable<string>{
      return this.http.get<any>(this.url + '/hospital/name/', {params:{id: id}});
    }
    SendResponse(response: string, review: ReviewDto): any{
      const body = {
        response : response,
        reviewId : review.Id
      };
      const ret = this.http.post<any>(this.url + "/drugstoreresponse", body);
      return ret;
    }
}