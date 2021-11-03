import {HttpClient, HttpParams, HttpResponse} from '@angular/common/http';
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
        this.url = "http://localhost:5000/api" //ovo ne znam posto ne pisem ja backend za sad
    }

    GetAllReviews(): Observable<any> {
        return this.http.get<any>(this.url + '/hospitalreview');
    }

    GetHospitalName(id: string): Observable<string>{
      return this.http.get<any>(this.url + '/hospital/name/', {params:{id: id}});
    }
    SendResponse(response: ResponseDto): Observable<ResponseDto> {
      
      return this.http.post<ResponseDto>(this.url + '/drugstoreresponse', response);
    }
}