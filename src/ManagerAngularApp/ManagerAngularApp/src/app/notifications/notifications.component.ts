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
    this.notificationService.GetNotifications().subscribe((data: any) => {
      for (const d of (data as any)) {
        this.notifications.push({
          "id": d.id,
          "drugstoreName": d.drugstoreName,
          "title": d.title,
          "content": d.content,
          "date": d.posted,
          "isRead":d.isRead
        });
      }
    });    
  }
  removeNotification(notification: NotificationDto){
    alert("You are about to delete notification. Proceed?");
    for (var i = 0; i < this.notifications.length; i++) {
      if (this.notifications[i].id === notification.id) {
        this.notifications.splice(i,1)
        i--;
      }
    }
    this.notificationService.RemoveNotification(notification).subscribe((d: any) =>{});
  }

  RefreshNotifications() {
    this.notificationService.RefreshNotifications().subscribe((data: any) => {
      window.location.reload();
    });    
  }
}
