import { Injectable } from '@angular/core';
import { Survey } from './survey';

@Injectable({
  providedIn: 'root'
})
export class SurveyService {

  constructor() { }

  surveys: Survey[] = [
    {
      'text': 'How satisfied are you with the work of your doctor?',
      'rating': 2,
      'questionType': 0
    },
    {
      'text': 'How satisfied were you with the time that your doctor spent with you?',
      'rating': 3,
      'questionType': 0
    },
    {
      'text': 'During this hospital stay, did doctor treat you with courtesy and respect?',
      'rating': 3,
      'questionType': 0
    },
    {
      'text': 'During this hospital stay, did doctor listen carefully to you?',
      'rating': 3,
      'questionType': 0
    },
    {
      'text': 'During this hospital stay, did doctor explain things in a way you could understand?',
      'rating': 3,
      'questionType': 0
    },
    {
      'text': 'During this hospital stay, did nurses treat you with courtesy and respect?',
      'rating': 3,
      'questionType': 1
    },
    {
      'text': 'During this hospital stay, did nurses listen carefully to you?',
      'rating': 3,
      'questionType': 1
    },
    {
      'text': 'During this hospital stay, did nurses explain things in a way you could understand?',
      'rating': 3,
      'questionType': 1
    },
    {
      'text': 'How easy was it to schedule an appointment with our hospital?',
      'rating': 3,
      'questionType': 2
    },
    {
      'text': 'How satisfied are you with the cleanliness and appearance of our hospital?',
      'rating': 3,
      'questionType': 2
    },
    {
      'text': 'How would you rate the professionalism of our staff?',
      'rating': 3,
      'questionType': 2
    },
    {
      'text': 'How satisfied were you with the co-ordination between different departments?',
      'rating': 3,
      'questionType': 2
    },
    {
      'text': 'Do you feel that our work hours are well suited to treat you?',
      'rating': 3,
      'questionType': 2
    },
    {
      'text': 'How likely are you to recommend our hospital to a friend or family member?',
      'rating': 3,
      'questionType': 2
    }
  ];

  getSurvey():Survey[] {
    return this.surveys;
  }


}
