import { Component, OnInit } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { CommentsService } from '../service/comments.service';
import { CommentDTO } from './comment.dto';

@Component({
  selector: 'pm-comments-observe',
  templateUrl: './comments-observe.component.html',
  styleUrls: ['./comments-observe.component.css']
})

export class CommentsObserveComponent implements OnInit {

  pageTitle="Comments"
  public comments: any[];
  public anonymous: boolean = false;
  public publicCom: boolean = false;
  public content: string = "";
  public comment: CommentDTO;

  constructor(private patientCommentService: CommentsService,private _snackBar: MatSnackBar,) {
    this.comments = [];
    this.comment = new CommentDTO()
  }

  ngOnInit(): void {
    this.patientCommentService.GetAprovedComments().subscribe((data: any)=>{
      for(const p of (data as any)){
        this.comments.push(p);
      }
    })
  }

  onSubmit():void{
    console.log(this.anonymous);

    console.log(this.content);
    this.PrepareDTO();
    this.patientCommentService.SendComment(this.comment).subscribe((data: any)=>{
      this._snackBar.open('Comment sent!', '', {
        duration: 2000
      });
    });
  }
  PrepareDTO(){
    this.comment.Content = this.content;
    if(this.anonymous == true){
    this.comment.Name = "anonymous";
    }
    else{
      this.comment.Name = "user";
    }
  }


}
