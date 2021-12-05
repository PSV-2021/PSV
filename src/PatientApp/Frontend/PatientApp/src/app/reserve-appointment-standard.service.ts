import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ReserveAppointmentStandardService {
  
  url: string;
  constructor(private http: HttpClient) { 
    this.url = "http://localhost:5000/api";
  }
  
  GetSpecialty(): Observable<any> {
    return this.http.get<any>(this.url + '/specialty');
  }
}
