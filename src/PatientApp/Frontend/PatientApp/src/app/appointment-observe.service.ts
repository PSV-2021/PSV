import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class AppointmentObserveService {
  url: string;
  constructor(private http: HttpClient) { 
    this.url = "http://" + environment.apiUrl + ":" + environment.port +"/api";
  }
  GetAppointments(id: string): Observable<any> {
    return this.http.get<any>(this.url + '/observeAppointments/',{params:{id: id}});
  }
}
