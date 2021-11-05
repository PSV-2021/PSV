import { Component, OnInit } from '@angular/core';
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

  constructor(private commentService: CommentService) {
    this.comments = [];
  }

  ngOnInit(): void {
    this.commentService.GetAllComments().subscribe((data: any)=>{
      for(const p of (data as any)){
        this.comments.push(p);
      }
    })
  }

}
