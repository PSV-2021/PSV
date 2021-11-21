import { Component, OnInit } from '@angular/core';
import { SurveyService } from '../survey.service';
import { MatSnackBar } from '@angular/material/snack-bar';
import { SurveyDTO } from '../survey-dto';

@Component({
  selector: 'app-survey',
  templateUrl: './survey.component.html',
  styleUrls: ['./survey.component.css']
})
export class SurveyComponent implements OnInit {
  
  pageTitle="Survey"
  public surveys: any[];
  postSurvey : SurveyDTO;
  questionList : number[] = new Array();
  answers : number[] = new Array;
  questions : number[] = new Array;

  constructor(private surveyService:SurveyService, private _snackBar: MatSnackBar) { 
    this.surveys = [];
    this.postSurvey = new SurveyDTO(this.answers, this.questions);
  }

  ngOnInit(): void {
    this.surveyService.GetSurveyQuestions().subscribe((data: any)=>{
      for(const p of (data as any)){
        this.surveys.push(p);
      }     
    })
  }

  onSubmit(){
    for(var question of this.surveys)
    {
      this.questions.push(question.id);
      if(this.questionList[question.id] == undefined)
      {
        this.answers.push(0);
      }
      else
      {
        this.answers.push(this.questionList[question.id]);
      }
    }

    this.postSurvey = new SurveyDTO(this.answers, this.questions);

    console.log(this.questions);
    console.log(this.answers);
    console.log(this.postSurvey);
  
    this.surveyService.PostSurveyQuestions(this.postSurvey).subscribe((data: any) =>{
      this._snackBar.open('Anketa poslata!', '', {
        duration: 2000
      });;
    });
  }

}
