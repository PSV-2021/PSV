export class SurveyDTO {

    public surveyQuestions : number[];
    public surveyAnswers : number[];

    constructor(surveyAnswers : number[],surveyQuestions : number[]) {
        this.surveyAnswers = surveyAnswers;
        this.surveyQuestions = surveyQuestions;
    }
}
