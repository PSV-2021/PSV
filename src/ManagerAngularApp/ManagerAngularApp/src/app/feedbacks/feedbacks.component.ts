import { Component, OnInit } from '@angular/core';

import { MatSnackBar } from '@angular/material/snack-bar';
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

  constructor(private commentService: CommentService, private _snackBar: MatSnackBar) {
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
      this._snackBar.open('Komentar odobren!', '', {
        duration: 2000
      });;

    });
  }

}
