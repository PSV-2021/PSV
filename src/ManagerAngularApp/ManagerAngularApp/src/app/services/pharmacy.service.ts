import {HttpClient, HttpHeaders, HttpParams, HttpErrorResponse} from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { RegistrationDto } from '../registration/registration.dto';
import { DrugstoreSearchDto } from '../purchase-drugs/drugstore.search.dto';
import { environment } from 'src/environments/environment';

@Injectable({
    providedIn: 'root'
  })
export class PharmacyService {
    url: string;
    constructor (private http: HttpClient) {
      this.url = environment.api;
    }

    GetAllDrugstoresWithImage(): Observable<any> {
      return this.http.get<any>(this.url + '/drugstore/withimage');
    }

    GetAllDrugstores(): Observable<any> {
      return this.http.get<any>(this.url + '/drugstore');
    }

    GetOneDrugstore(id: number): Observable<any> {
      let headers = new HttpHeaders({
        'Content-Type': 'application/json',
        'ApiKey': "abcde" });

      const params = new HttpParams()
      .set('id', id)
      return this.http.get<any>(this.url + '/drugstore/one', {params, headers});
    }

    EditPharmacy(Id: number, ImageBase64: string, Comment: string) {
      const body = {
        id : Id,
        imageBase64: ImageBase64,
        comment : Comment
      };
      let headers = new HttpHeaders({
        'Content-Type': 'application/json',
        'ApiKey': "abcde" });
      let options = { headers: headers };
      const ret = this.http.put<any>(this.url + '/drugstore/edit', body, options);
      return ret;
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
      return this.http.put<any>(this.url + '/drugpurchase', body, options).pipe(catchError(this.errorHandler))
    }

    SendUrgentDrugPurchase(Url: string, DrugAmount: number, DrugName: string): Observable<any> {
      const body = {
        pharmacyUrl : Url,
        name: DrugName,
        amount : DrugAmount
      };
      let headers = new HttpHeaders({
        'Content-Type': 'application/json',
        'ApiKey': "abcde" });
      let options = { headers: headers };
      const ret = this.http.put<any>(this.url + '/drugpurchase/urgent', body, options);
      return ret;
    }

    SendFilter(searchDto: DrugstoreSearchDto): Observable<any>{
      let headers = new HttpHeaders({
        'Content-Type': 'application/json',
        'ApiKey': "abcde" });

      const params = new HttpParams()
      .set('city', searchDto.City)
      .set('address', searchDto.Address);

      const ret = this.http.get<any>(this.url + '/drugstore/filter', {params, headers});

      return ret;
    }

    errorHandler(error: HttpErrorResponse) {
      alert(error.error)
      return Observable.throw(error.error)
  }
}