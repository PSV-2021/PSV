import {HttpClient, HttpResponse} from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { NotificationDto } from '../notifications/notification.dto';
import { RegistrationDto } from '../registration/registration.dto';

@Injectable({
    providedIn: 'root'
  })
export class NotificationService {
    url: string;
    constructor (private http: HttpClient) {
        this.url = environment.api
    }

    GetNotifications(): Observable<NotificationDto> {
        return this.http.get<any>(this.url + '/notifications/');
    }
}