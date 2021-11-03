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
        this.url = "http://localhost:5000/api/registration" //ovo ne znam posto ne pisem ja backend za sad
    }

    registerNewHospital(hospital: RegistrationDto): Observable<string> {
        return this.http.post<string>(this.url + '/new', hospital);
    }
}