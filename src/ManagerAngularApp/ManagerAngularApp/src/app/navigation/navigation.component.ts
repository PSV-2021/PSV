import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'pm-navigation',
  templateUrl: './navigation.component.html',
  styleUrls: ['./navigation.component.css']
})
export class NavigationComponent implements OnInit {
  pageTitle="Manager App";
  
  constructor() { }
  ngOnInit(): void {
  }
}
