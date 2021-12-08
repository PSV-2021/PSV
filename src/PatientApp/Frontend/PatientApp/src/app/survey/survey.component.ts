import { Component, OnInit } from '@angular/core';
import { SurveyService } from '../survey.service';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Route } from '@angular/compiler/src/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-survey',
  templateUrl: './survey.component.html',
  styleUrls: ['./survey.component.css']
})
export class SurveyComponent implements OnInit {
  
  pageTitle="Survey"
  public surveys: any[];

  constructor(private surveyService:SurveyService, private _snackBar: MatSnackBar, private route: ActivatedRoute) { 
    this.surveys = [];
  }

  id: any;
  ap: any;

  ngOnInit(): void {
    this.surveyService.GetSurveyQuestions().subscribe((data: any)=>{
      for(const p of (data as any)){
        this.surveys.push(p);
      }     
    })
    this.id = this.route.snapshot.paramMap.get('id');
    this.ap = this.route.snapshot.paramMap.get('ap');
  }

  onSubmit(){ 
    this.surveyService.PostSurveyQuestions(this.surveys, this.id, this.ap).subscribe((data: any) =>{
      this._snackBar.open('Anketa poslata!', '', {
        duration: 2000
      });;
    });
  }

}
