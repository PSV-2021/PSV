import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'pm-navigation',
  templateUrl: './navigation.component.html',
  styleUrls: ['./navigation.component.css']
})
export class NavigationComponent implements OnInit {
  pageTitle="Patient App";
  
  constructor(private router: Router) { }
  ngOnInit(): void {
  }

  navigate() {
    this.router.navigate(['/registration']);
  }
  
  login() {
  this.router.navigate(['/login']);
  }

  LogOut(){
    this.router.navigate(['']);
  }
}
