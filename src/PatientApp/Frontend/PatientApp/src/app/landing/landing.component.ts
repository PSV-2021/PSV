import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { CommentsService } from '../service/comments.service';

@Component({
  selector: 'app-landing',
  templateUrl: './landing.component.html',
  styleUrls: ['./landing.component.css']
})
export class LandingComponent implements OnInit {
  pageTitle="Patient App";

  public comments: any[];

  constructor(private router: Router, private patientCommentService: CommentsService) { 
    this.comments = [];
  }

  ngOnInit(): void {
    this.patientCommentService.GetAprovedComments().subscribe((data: any)=>{
      for(const p of (data as any)){
        this.comments.push(p);
        console.log(data);
      }
    })
  }

  register() {
    this.router.navigate(['/registration']);
  }
  
  login() {
  this.router.navigate(['/login']);
  }
 

}
