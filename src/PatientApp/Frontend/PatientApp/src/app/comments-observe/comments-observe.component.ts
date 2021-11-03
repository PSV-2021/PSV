import { Component, OnInit } from '@angular/core';
import { CommentsService } from '../comments.service';
import { PatientComment } from './comments';

const PATIENT_DATA: PatientComment[] = [];

@Component({
  selector: 'pm-comments-observe',
  templateUrl: './comments-observe.component.html',
  styleUrls: ['./comments-observe.component.css']
})

export class CommentsObserveComponent implements OnInit {

  pageTitle="Comments"
  displayedColumns: string[] = ['comment', 'date', 'name'];

  constructor(private patientCommentService: CommentsService) {}
  dataSource = PATIENT_DATA;

  ngOnInit(): void {
    this.dataSource = this.patientCommentService.getProducts();
  }

}
