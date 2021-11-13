import {HttpClient, HttpHeaders, HttpResponse} from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';
import { catchError } from 'rxjs/operators';
import { RegistrationDto } from '../registration/registration.dto';

@Injectable({
    providedIn: 'root'
  })
export class PharmacyService {
    url: string;
    constructor (private http: HttpClient) {
        this.url = "http://localhost:5000/api";
    }

    GetAllDrugstores(): Observable<any> {
      return this.http.get<any>(this.url + '/drugstore');
    }

    SendDrugDemand(Url: string, DrugAmount: number, DrugName: string): Observable<any> {
      const body = {
        pharmacyUrl : Url,
        name: DrugName,
        amount : DrugAmount
      };
      let headers = new HttpHeaders({
        'Content-Type': 'application/json',
        'ApiKey': "abcde" });
      let options = { headers: headers };
      const ret = this.http.put<any>(this.url + '/drugpurchase', body, options);
      return ret;
    }
}