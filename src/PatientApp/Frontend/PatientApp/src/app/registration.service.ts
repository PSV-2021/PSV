import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class RegistrationService {

  url: string;
  constructor(private http: HttpClient) {
    this.url = "http://localhost:5000/api";
   }
   GetDoctors(): Observable<any> {
      return this.http.get<any>(this.url + '/doctors');
  }
}

