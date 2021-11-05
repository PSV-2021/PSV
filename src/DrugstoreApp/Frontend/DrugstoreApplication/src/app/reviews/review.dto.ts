export class ReviewDto{
    Id: number;
    HospitalName: string;
    ReviewContent: string;
    ReviewResponse: string;

    constructor(){
        this.Id = 0;
        this.HospitalName = '';
        this.ReviewContent = '';
        this.ReviewResponse = '';
    }
}