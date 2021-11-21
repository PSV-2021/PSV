import {HttpClient, HttpResponse} from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';
import { catchError } from 'rxjs/operators';
import { RegistrationDto } from '../registration/registration.dto';

@Injectable({
    providedIn: 'root'
  })
export class RegistrationService {
    url: string;
    constructor (private http: HttpClient) {
        this.url = "http://localhost:5000/api"
    }

    public RegisterDrugstore(drugstore: RegistrationDto){
        const body = {
            DrugstoreName : drugstore.DrugstoreName,
            City: drugstore.City,
            Address : drugstore.Address,
            URLAddress : drugstore.URLAddress,
            Email : drugstore.Email
          };
        return this.http.post<any>(this.url + "/drugstore", body);
    }
}