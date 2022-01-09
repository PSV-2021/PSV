import {HttpClient, HttpResponse} from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { RegistrationDto } from '../registration/registration.dto';
import { environment } from 'src/environments/environment';

@Injectable({
    providedIn: 'root'
  })
export class RegistrationService {
    url: string;
    constructor (private http: HttpClient) {
      this.url = environment.api;
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