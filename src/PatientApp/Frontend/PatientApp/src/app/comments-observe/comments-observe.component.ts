import { Component, OnInit } from '@angular/core';
import { CommentsService } from '../comments.service';

@Component({
  selector: 'pm-comments-observe',
  templateUrl: './comments-observe.component.html',
  styleUrls: ['./comments-observe.component.css']
})

export class CommentsObserveComponent implements OnInit {

  pageTitle="Comments"
  public comments: any[];
  displayedColumns: string[] = ['comment', 'date', 'name'];

  constructor(private patientCommentService: CommentsService) {
    this.comments = [];
  }

  ngOnInit(): void {
    this.patientCommentService.GetAprovedComments().subscribe((data: any)=>{
      for(const p of (data as any)){
        this.comments.push(p);
      }
    })
  }

}
