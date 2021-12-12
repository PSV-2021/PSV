import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AppointmentObserveService {
  url: string;
  constructor(private http: HttpClient) { 
    this.url = "http://localhost:5000/api";
  }
  GetAppointments(id: string): Observable<any> {
    return this.http.get<any>(this.url + '/observeAppointments/',{params:{id: id}});
  }

  CancelAppointment(id: number): any {
    return this.http.post<any>(this.url + '/cancelAppointments', id);
  }
}
