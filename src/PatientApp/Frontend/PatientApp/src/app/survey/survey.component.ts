import { Component, OnInit } from '@angular/core';
import { SurveyService } from '../survey.service';

@Component({
  selector: 'app-survey',
  templateUrl: './survey.component.html',
  styleUrls: ['./survey.component.css']
})
export class SurveyComponent implements OnInit {
  
  pageTitle="Survey"
  public surveys: any[];

  constructor(private data:SurveyService) { 
    this.surveys = [];
  }

  ngOnInit(): void {
    this.surveys = this.data.getSurvey();
    console.log(this.surveys);
  }

}
