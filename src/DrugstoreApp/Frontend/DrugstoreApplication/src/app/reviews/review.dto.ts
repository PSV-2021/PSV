export class ReviewDto{
    Id: string;
    HospitalName: string;
    ReviewContent: string;
    ReviewResponse: string;

    constructor(){
        this.Id = '';
        this.HospitalName = '';
        this.ReviewContent = '';
        this.ReviewResponse = '';
    }
}