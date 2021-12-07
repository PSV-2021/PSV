import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { RecommendAppointmentDto } from '../recommend-appointment/recommend-appointment-dto';

@Injectable({
  providedIn: 'root'
})
export class RecommendAppointmentService {
  url: string;
  constructor(private http: HttpClient) { 
    this.url = "http://localhost:5000/api";
  }

  GetAllDoctors(): Observable<any> {
    return this.http.get<any>(this.url + '/doctors/findDoctors');
  }
  
  FindAppointments(appointment: RecommendAppointmentDto): Observable<any>{
    return this.http.post<any>(this.url + "/recommendedAppointment", appointment);
  }
}
