import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class MedicalRecordService {
  url: string;

  constructor(private http: HttpClient) {
    this.url = "http://localhost:5000/api";

   }


  public GetMedicalRecord(id: string): Observable<any> {
    console.log(id);
    return this.http.get<any>(this.url + '/medicalrecord/' ,{params:{id: id}});
  }
}
