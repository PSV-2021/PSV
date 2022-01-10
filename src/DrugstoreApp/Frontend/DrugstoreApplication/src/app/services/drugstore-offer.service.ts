import {HttpClient, HttpHeaders, HttpParams, HttpResponse} from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { DrugstoreOfferDto } from '../drugstore-offer/drugstore-offer.dto';

@Injectable({
    providedIn: 'root'
  })
export class DrugStoreOfferService {
    url: string;
    smartphone: any = [];
    constructor (private http: HttpClient) {
        this.url = "http://localhost:5001/api" //ovo ne znam posto ne pisem ja backend za sad
        //this.url = "http://"+location.hostname+":5001/api";
    }
    SendOffer(offer: DrugstoreOfferDto): any{
        const body = {
          Id : offer.Id,
          Title : offer.Title,
          Content : offer.Content,
          DrugstoreName: offer.DrugstoreName,
          StartDate : offer.StartDate,
          EndDate : offer.EndDate,

        };
        let headers = new HttpHeaders({
          'Content-Type': 'application/json',
          'ApiKey': "DrugStoreSecretKey" });
        let options = { headers: headers };
        const ret = this.http.post<any>(this.url + "/DrugstoreOffer", body, options);
        return ret;
      }
    }