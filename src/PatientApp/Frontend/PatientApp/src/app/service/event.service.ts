import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { AppointmentEvent } from '../event/appointmentEvent';
import { environment } from 'src/environments/environment';
import { EventDto } from '../event/event.dto';
import { getLocaleDateTimeFormat } from '@angular/common';

@Injectable({
  providedIn: 'root'
})
export class EventService {

  url: string;
  EventDto: EventDto = new EventDto();
  constructor(private http : HttpClient) {    
    this.url = "http://"+ environment.apiUrl + ":" + environment.port +"/api";
  }

  public postEvent(data : AppointmentEvent) {
    console.log(data);
    this.EventDto.Id = data.eventIdentificator;
    this.EventDto.EventName = data.appointmentProperties.toString();

    const ret = this.http.post<any>(this.url +"/event" , this.EventDto);
    return ret;
  }
}
