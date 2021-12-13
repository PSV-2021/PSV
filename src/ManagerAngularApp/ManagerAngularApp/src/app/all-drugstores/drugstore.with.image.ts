export class DrugstoreWithImageDto{
    Id: number;
    Name: string;
    Url: string;
    City: string;
    Address: string;
    Comment: string;
    ImageBase64: string;



    constructor(){
        this.Id = 0;
        this.Name = '';
        this.Url = 'http://localhost:5001';
        this.City = '';
        this.Address = '';
        this.Comment = '';
        this.ImageBase64 = '';
    }
}