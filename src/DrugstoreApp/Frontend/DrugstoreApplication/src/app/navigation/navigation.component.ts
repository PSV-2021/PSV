import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { NotificationDto } from '../notifications/notification.dto';
import { NotificationService } from '../services/notification.service';
import { RegistrationService } from '../services/registration.service';
@Component({
  selector: 'app-navigation',
  templateUrl: './navigation.component.html',
  styleUrls: ['./navigation.component.css']
})
export class NavigationComponent implements OnInit {
  notifications : NotificationDto []
    numberIndicator : number
    
  constructor(private router: Router, private notificationService: NotificationService) {
    this.notifications = []
    this.numberIndicator = 0;
   }

  ngOnInit(): void {
    this.notificationService.GetNotifications().subscribe((data: any) => {
      for (const d of (data as any)) {
        this.notifications.push({
          "id": d.id,
          "hospitalName": d.hospitalName,
          "title": d.title,
          "content": d.content,
          "date": d.posted,
          "isRead":d.isRead
        });
      }
      this.getUnreadAmount()
      setTimeout(() => {
        this.RefreshNotifications();
      }, 500);
    });    
  }

  getUnreadAmount() {
    for (var i = 0; i < this.notifications.length; i++) {
      if (this.notifications[i].isRead === false)
        this.numberIndicator++;
    }
  }

  RefreshNotifications() {
    this.notificationService.RefreshNotifications().subscribe((data: any) => {
    });    
  }
  
}
