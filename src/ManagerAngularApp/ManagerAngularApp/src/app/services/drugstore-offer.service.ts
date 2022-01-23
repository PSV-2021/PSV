import {HttpClient, HttpErrorResponse, HttpHeaders, HttpParams, HttpResponse} from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, throwError } from 'rxjs';
import { PublishedDrugstoreOfferDto } from '../drugstore-offer/published-drugstore-offer.dto';
import { environment } from 'src/environments/environment';

@Injectable({
    providedIn: 'root'
  })
export class DrugStoreOffersService {
    url: string;
    smartphone: any = [];
    constructor (private http: HttpClient) {
      this.url = environment.api;
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
      
      return this.http.post<any>(this.url + '/drugstoreoffer/pls', body, options);
    }

    errorHandler(error: HttpErrorResponse) {
      return throwError(error.error);
    }
  }