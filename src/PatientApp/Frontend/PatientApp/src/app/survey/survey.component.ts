import { ThisReceiver } from '@angular/compiler';
import { Component, OnInit } from '@angular/core';
import { SurveyService } from '../survey.service';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-survey',
  templateUrl: './survey.component.html',
  styleUrls: ['./survey.component.css']
})
export class SurveyComponent implements OnInit {
  
  pageTitle="Survey"
  public surveys: any[];

  constructor(private surveyService:SurveyService, private _snackBar: MatSnackBar) { 
    this.surveys = [];
  }

  ngOnInit(): void {
    this.surveyService.GetSurveyQuestions().subscribe((data: any)=>{
      for(const p of (data as any)){
        this.surveys.push(p);
      }     
    })
  }

  onSubmit(){
    console.log(this.surveys);  
    this.surveyService.PostSurveyQuestions(this.surveys).subscribe((data: any) =>{
      this._snackBar.open('Anketa poslata!', '', {
        duration: 2000
      });;
    });

}

}
