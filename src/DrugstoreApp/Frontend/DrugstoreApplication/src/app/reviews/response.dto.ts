export class ResponseDto{
    Id: string;
    HospitalName: string;
    ResponseContent: string;

    constructor(){
        this.Id = '';
        this.HospitalName = '';
        this.ResponseContent = '';
    }
}