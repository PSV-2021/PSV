import {HttpClient, HttpHeaders, HttpParams, HttpResponse} from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';
import { environment } from 'src/environments/environment';

@Injectable({
    providedIn: 'root'
  })
export class FileService {
    url: string;
    constructor (private http: HttpClient) {
        this.url = environment.api;
    }
    
    GetAllFiles(): Observable<any> {
        return this.http.get<any>(this.url + '/drugSpecification');
    }

    DownloadFile(filename: string): Observable<any> {
        console.log(filename);
        let responseData = this.http.get<any>(this.url + '/drugSpecification/files', {params:{filename: filename}});
        console.log(responseData);
        return responseData;
    }

    OpenFile(filename: string) {
        var URL = "../../assets/DrugsSpecifications/" + filename;
        window.open(URL, '_blank');
    }
}
