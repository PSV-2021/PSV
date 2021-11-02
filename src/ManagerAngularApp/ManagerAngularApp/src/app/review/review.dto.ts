export class ReviewDto{
    DrugstoreName: string;
    ReviewContent: string;
    ReviewResponse: string;

    constructor(){
        this.DrugstoreName = '';
        this.ReviewContent = '';
        this.ReviewResponse = '';
    }
}