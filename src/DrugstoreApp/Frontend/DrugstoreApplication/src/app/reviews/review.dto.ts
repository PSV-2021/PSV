export class ReviewDto{
    HospitalName: string;
    ReviewContent: string;
    ReviewResponse: string;

    constructor(){
        this.HospitalName = '';
        this.ReviewContent = '';
        this.ReviewResponse = '';
    }
}