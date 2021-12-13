import { formatDate } from '@angular/common';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { StandardAppointmentDto } from './reserve-appointment-standard/standard-appointment.dto';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ReserveAppointmentStandardService {
  
  url: string;
  constructor(private http: HttpClient) { 
    this.url = "http://" + environment.apiUrl + ":" + environment.port +"/api";
  }
  
  GetSpecialty(): Observable<any> {
    return this.http.get<any>(this.url + '/specialty');
  }
  GetThatSpecialtyDoctors(id: string): Observable<any> {
    console.log(id);
    return this.http.get<any>(this.url + '/doctors/' +id);
  }
  GetAppointmentsForDoctorAndDate(idDoctor: string, dateAppointment: Date):Observable<any> {
    console.log(dateAppointment);

    
    const format = "dd.MM.yyyy"

    var chosenDate = formatDate(dateAppointment, format, "en-US")
    console.log(chosenDate);
    return this.http.get<any>(this.url + '/standardappointment/' +idDoctor+"/"+chosenDate);
  }
  scheduleAppointment(appointment: StandardAppointmentDto):Observable<any> {

    const ret = this.http.post<any>(this.url + "/standardAppointment/schedule", appointment);
    
    return ret;
  }
}
