import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class MedicalRecordService {
  url: string;

  constructor(private http: HttpClient) {
    this.url = "http://" + environment.apiUrl + ":" + environment.port +"/api";

   }


  public GetMedicalRecord(id: string): Observable<any> {
    const headers = { 'Authorization': 'Bearer' + localStorage.getItem("jwtToken")}
    return this.http.get<any>(this.url + '/medicalrecord/', {'headers':headers, params:{id: id}});
  }
}
