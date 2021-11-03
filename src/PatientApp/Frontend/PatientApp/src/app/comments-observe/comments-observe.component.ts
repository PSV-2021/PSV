import { Component, OnInit } from '@angular/core';
import { CommentsService } from '../comments.service';
import { PatientComment } from './comments';
import { CommentDto } from './comments.dto';


//const PATIENT_DATA: PatientComment[] = [];

@Component({
  selector: 'pm-comments-observe',
  templateUrl: './comments-observe.component.html',
  styleUrls: ['./comments-observe.component.css']
})

export class CommentsObserveComponent implements OnInit {

  pageTitle="Comments"
  public comments: CommentDto[];
  displayedColumns: string[] = ['comment', 'date', 'name'];

  constructor(private patientCommentService: CommentsService) {
    this.comments = [];
  }
  //dataSource = PATIENT_DATA;


  ngOnInit(): void {
    //this.dataSource = this.patientCommentService.getProducts();
    this.patientCommentService.GetAprovedComments().subscribe((data: any)=>{
      console.log(data);
      for(const p of (data as any)){
        this.comments.push({
          "Comment": p.content,
          "Date": p.date,
          "Name": p.name
        });
      }
    })
  }

}
