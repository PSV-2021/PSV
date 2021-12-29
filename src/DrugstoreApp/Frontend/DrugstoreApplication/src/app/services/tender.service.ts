import {HttpClient, HttpHeaders, HttpParams, HttpResponse} from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';
import { environment } from 'src/environments/environment';
import { TenderDto } from '../tenders/tender.dto';

@Injectable({
    providedIn: 'root'
  })
export class TenderService {
    url: string;
    constructor (private http: HttpClient) {
        this.url = environment.api;
    }
    

    GetAllActiveTenders(): Observable<any>{
      return this.http.get<any>(this.url + '/tenderOffer/ongoing');
    }   
    
}
