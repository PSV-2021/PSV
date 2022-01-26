import {HttpClient, HttpHeaders, HttpResponse} from '@angular/common/http';
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
        return this.http.get<any>(this.url + '/notification');
    }
    RemoveNotification(notification: NotificationDto): any{
        const body = {
          id : notification.id,
          hospitalName : notification.id,
          posted : notification.date,
          title: notification.title,
          content: notification.content,
          isRead: notification.isRead
        };
        let headers = new HttpHeaders({
          'Content-Type': 'application/json',
          'ApiKey': "DrugStoreSecretKey" });
        let options = { headers: headers };
        const ret = this.http.post<any>(this.url + "/notification/remove", body, options);
        return ret;
      }

      RefreshNotifications(): Observable<NotificationDto> {
        return this.http.get<any>(this.url + '/notification/refresh');
    }
}