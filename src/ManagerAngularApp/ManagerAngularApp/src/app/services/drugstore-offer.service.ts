import {HttpClient, HttpHeaders, HttpParams, HttpResponse} from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';
import { catchError } from 'rxjs/operators';
import { DrugstoreOfferDto } from '../drugstore-offer/drugstore-offer.dto';
import { PublishedDrugstoreOfferDto } from '../drugstore-offer/published-drugstore-offer.dto';

@Injectable({
    providedIn: 'root'
  })
export class DrugStoreOffersService {
    url: string;
    smartphone: any = [];
    constructor (private http: HttpClient) {
      this.url = "http://"+location.hostname+":5000/api";
    }
    GetAllOffers(): Observable<any> {
        return this.http.get<any>(this.url + '/drugstoreoffer');
      }
    publishOffer(offer : PublishedDrugstoreOfferDto): any{
      
      const body = {
        OfferId : offer.Id,
      };
      let headers = new HttpHeaders({
        'Content-Type': 'application/json',
        'ApiKey': "abcde" });
      let options = { headers: headers };
      
      const ret = this.http.post<any>(this.url + '/drugstoreoffer/pls', body, options);
      console.log(ret);
      return ret;
      
    }
    }