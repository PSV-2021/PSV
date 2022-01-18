import { Component, OnInit } from '@angular/core';
import { NotificationService } from '../services/notification.service';
import { NotificationDto } from './notification.dto';

@Component({
  selector: 'app-notifications',
  templateUrl: './notifications.component.html',
  styleUrls: ['./notifications.component.css']
})
export class NotificationsComponent implements OnInit {

  notifications : NotificationDto []

  constructor(private notificationService: NotificationService) { 
    this.notifications = []
  }

  ngOnInit(): void {
    // this.notificationService.GetNotifications().subscribe((data: any) => {
    //   for (const d of (data as any)) {
    //     this.notifications.push({
    //       "title": d.title,
    //       "content": d.content,
    //       "date": d.date
          
    //     });
    //   }
    // });
    this.notifications.push(new NotificationDto("notification1", "content 1", new Date(2022, 1, 18)));
    this.notifications.push(new NotificationDto("notification2", "content 2", new Date(2022, 1, 18)));
    this.notifications.push(new NotificationDto("notification3", "content 3", new Date(2022, 1, 18)));

  }

}
