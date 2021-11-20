import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { PatientDto } from './registration/registration.dto';

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
  GetAllergens(): Observable<any> {
    return this.http.get<any>(this.url + '/ingredients');
  }
  SendPatient(patient: PatientDto): Observable<any>{
    console.log(patient.Address)
    const body = {
      patient: patient
    }
    const ret = this.http.post<any>(this.url + "/patientRegistration", patient);
    
    return ret;
  }
}
