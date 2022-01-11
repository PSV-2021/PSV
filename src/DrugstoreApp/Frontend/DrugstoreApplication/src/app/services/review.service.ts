import {HttpClient, HttpHeaders, HttpParams, HttpResponse} from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { ReviewDto } from '../reviews/review.dto';
import { ResponseDto } from '../reviews/response.dto';
import { map } from 'rxjs-compat/operator/map';
import { environment } from 'src/environments/environment';

@Injectable({
    providedIn: 'root'
  })
export class ReviewsService {
    url: string;
    smartphone: any = [];
    constructor (private http: HttpClient) {
      this.url = environment.api //ovo ne znam posto ne pisem ja backend za sad
    }

    GetAllMyReviews(): Observable<any> {
      let headers = new HttpHeaders({
        'Content-Type': 'application/json',
        'ApiKey': "DrugStoreSecretKey" });
      let options = { headers: headers };
        return this.http.get<any>(this.url + '/drugstoreresponse/getAllMyFeedbacks', options);
    }

    GetHospitalName(id: string): Observable<string>{
      return this.http.get<any>(this.url + '/hospital/name/', {params:{id: id}});
    }
    SendResponse(review: ReviewDto): any{
      const body = {
        response : review.ReviewResponse,
        Id : review.Id,
        hospitalName: review.HospitalName,
      };
      let headers = new HttpHeaders({
        'Content-Type': 'application/json',
        'ApiKey': "DrugStoreSecretKey" });
      let options = { headers: headers };
      const ret = this.http.post<any>(this.url + "/drugstoreresponse/new", body, options);
      return ret;
    }
}