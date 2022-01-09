import {HttpClient, HttpHeaders, HttpParams, HttpResponse} from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';
import { environment } from 'src/environments/environment';
import { TenderDto } from '../tenders/tender.dto';
import { TenderOfferDto } from '../tenders/tender.offer.dto';
import { FinishedTenderOfferDto } from '../tender-finishing/fisnished-tender-offer.dto';

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
    GetAllFinishedTenders(): Observable<any>{
      return this.http.get<any>(this.url + '/tenderOffer/finished');
    }

    GetAvailability(tenderOffer: TenderOfferDto): Observable<any>{
      const body = {
        id: tenderOffer.tender.id,
        tenderOfferInfo: this.TenderInfoToString(tenderOffer.tender.tenderInfo),
        price: tenderOffer.price,
        tenderId: tenderOffer.tender.id,
        isAccepted: false,
        drugstoreId: 1,
        isActive: true

      };
      let headers = new HttpHeaders({
        'Content-Type': 'application/json',
        'ApiKey': "DrugStoreSecretKey" });
      let options = { headers: headers };
      const ret = this.http.post<any>(this.url + '/tenderOffer/availability', body, options);
      return ret;
    }
    GetAvailabilityForFinish(tenderOffer: FinishedTenderOfferDto): Observable<any>{
      const body = {
        id: tenderOffer.id,
        tenderOfferInfo: this.TenderInfoToString(tenderOffer.tenderInfo),
        price: 0,
        tenderId: 0,
        isAccepted: false,
        drugstoreId: 1,
        isActive: true

      };
      let headers = new HttpHeaders({
        'Content-Type': 'application/json',
        'ApiKey': "DrugStoreSecretKey" });
      let options = { headers: headers };
      const ret = this.http.post<any>(this.url + '/tenderOffer/availability', body, options);
      return ret;
    }
    

    GetCounterAvailability(tenderOffer: TenderOfferDto): Observable<any>{
      const body = {
        id: tenderOffer.tender.id,
        tenderOfferInfo: this.TenderInfoToString(tenderOffer.tender.counterOfferInfo),
        price: tenderOffer.price,
        tenderId: tenderOffer.tender.id,
        isAccepted: false,
        drugstoreId: 1,
        isActive: true

      };
      let headers = new HttpHeaders({
        'Content-Type': 'application/json',
        'ApiKey': "DrugStoreSecretKey" });
      let options = { headers: headers };
      const ret = this.http.post<any>(this.url + '/tenderOffer/availability', body, options);
      return ret;
    }

    
    AddOffer(tenderOffer: TenderOfferDto): any{
      const body = {
        id: tenderOffer.tender.id,
        tenderOfferInfo: this.TenderInfoToString(tenderOffer.tender.tenderInfo),
        price: tenderOffer.price,
        tenderId: tenderOffer.tender.id,
        isAccepted: false,
        drugstoreId: 1,
        isActive: true

      };
      let headers = new HttpHeaders({
        'Content-Type': 'application/json',
        'ApiKey': "DrugStoreSecretKey" });
      let options = { headers: headers };
      const ret = this.http.post<any>(this.url + "/tenderOffer", body, options);
      return ret;
    }
    AddCounterOffer(tenderOffer: TenderOfferDto): any{
      const body = {
        id: tenderOffer.tender.id,
        tenderOfferInfo: this.TenderInfoToString(tenderOffer.tender.counterOfferInfo),
        price: tenderOffer.price,
        tenderId: tenderOffer.tender.id,
        isAccepted: false,
        drugstoreId: 1,
        isActive: true

      };
      let headers = new HttpHeaders({
        'Content-Type': 'application/json',
        'ApiKey': "DrugStoreSecretKey" });
      let options = { headers: headers };
      const ret = this.http.post<any>(this.url + "/tenderOffer", body, options);
      return ret;
    }
    
    TenderInfoToString(tenderInfo: TenderDto[]): string{
      var array = tenderInfo.map(a => (a.drugName + " - " + a.amount));
      var result = array.toString();
      console.log(result);
      return result;
    }
    
    FinishTender(offer : FinishedTenderOfferDto ):any{
      console.log("gas");
      const body = {
        Id : offer.id,
        TenderEnd : offer.tenderEnd,
        TenderInfo : offer.tenderInfo,
        IsWinner : offer.isWinner
      };
      console.log(body);
      let headers = new HttpHeaders({
        'Content-Type': 'application/json',
        'ApiKey': "abcde" });
      let options = { headers: headers };
      
      const ret = this.http.post<any>(this.url + '/tenderOffer/finish', body, options);
      console.log(ret);
      return ret;
    }

    

    
}
