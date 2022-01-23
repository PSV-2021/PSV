import {HttpClient, HttpErrorResponse, HttpHeaders, HttpParams, HttpResponse} from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, throwError } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
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
        return this.http.get<any>(this.url + '/drugSpecification').pipe(map(res => res), catchError(this.errorHandler));
    }

    DownloadFile(filename: string): Observable<any> {
        console.log(filename);
        return this.http.get<any>(this.url + '/drugSpecification/files', {params:{filename: filename}}).pipe(map(res => res), catchError(this.errorHandler));
    }

    OpenFile(reportName: string): any {
        var mediaType = 'application/pdf';
        this.http.get(this.url + '/drugSpecification/pdf/' + reportName, { responseType: 'blob' }).subscribe(
            (response) => {
                var blob = new Blob([response], { type: mediaType });
                const url= window.URL.createObjectURL(blob);
                window.open(url);
            }
        );
    }

    errorHandler(error: HttpErrorResponse) {
        return throwError(error.error);
    }
}
