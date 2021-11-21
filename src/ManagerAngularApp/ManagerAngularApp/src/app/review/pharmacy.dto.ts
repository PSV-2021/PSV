export class PharmacyDto{
    Id: number;
    Name: string;
    Url: string;
    City: string;
    Address: string;



    constructor(){
        this.Id = 0;
        this.Name = '';
        this.Url = '';
        this.City = '';
        this.Address = '';
    }
}