import { Component, OnInit } from '@angular/core';

import { MatSnackBar } from '@angular/material/snack-bar';
import { Router } from '@angular/router';
import { CommentService } from '../services/comment.service';


@Component({
  selector: 'app-feedbacks',
  templateUrl: './feedbacks.component.html',
  styleUrls: ['./feedbacks.component.css']
})
export class FeedbacksComponent implements OnInit {

  pageTitle="Comments"
  public comments: any[];
  displayedColumns: string[] = ['comment', 'date', 'name'];

  constructor(private commentService: CommentService, private _snackBar: MatSnackBar, private router: Router) {
    this.comments = [];
  }

  ngOnInit(): void {
    this.commentService.GetAllComments().subscribe((data: any)=>{
      for(const p of (data as any)){
        this.comments.push(p);
      }
    })
  }
  public publishComment(id:number): void{
    this.commentService.publishComment(id).subscribe((d: any) =>{
      this.router.navigate(['/feedbacks']);
      this.ngOnInit();

      this._snackBar.open('Feedback approved!', '', {
        duration: 2000
      });;

    });

  }
  public returnComment(id:number): void{
    this.commentService.returnComment(id).subscribe((d: any) =>{
      this.router.navigate(['/feedbacks']);
      this.ngOnInit();
      this._snackBar.open('Feedback returned for approval!', '', {
        duration: 2000
      });;
    });

  }

}
