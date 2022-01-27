import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-navigation',
  templateUrl: './navigation.component.html',
  styleUrls: ['./navigation.component.css']
})
export class NavigationComponent implements OnInit {
  pageTitle="Manager App";
  
  constructor(private router: Router) {
   }
  ngOnInit(): void {
  }
  LogOut(){
    this.router.navigate(['/landingPage']);
  }

}
