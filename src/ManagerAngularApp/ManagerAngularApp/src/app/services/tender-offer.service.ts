import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { environment } from "src/environments/environment";
import { TenderOfferDto } from "../tender-offers/tender-offer.dto";

@Injectable({
    providedIn: 'root'
  })
export class TenderOfferService {
    url: string;
    constructor (private http: HttpClient) {
        this.url = environment.api;
    }

    completeTransaction(offer:TenderOfferDto){
        let headers = new HttpHeaders({
            'Content-Type': 'application/json',
            'ApiKey': "abcde" });
          let options = { headers: headers };
          return this.http.post<any>(this.url + '/drugTender/complete', offer, options);
    }
}