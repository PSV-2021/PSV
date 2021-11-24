import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { PatientDto } from './registration/registration.dto';


@Injectable({
  providedIn: 'root'
})
export class ActivationService {
  
  url: string;
  data: string = "";
  constructor(private http: HttpClient) {
    this.url = "http://localhost:5000/api";

   }
   IsTokenValid(patient: PatientDto): Observable<any> {
    console.log(patient.Token);
    return this.http.post<any>(this.url + '/validation', patient);
  }
  
}
