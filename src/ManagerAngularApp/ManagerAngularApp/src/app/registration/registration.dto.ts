export class RegistrationDto{
    DrugstoreName: string;
    Country: string;
    City: string;
    Address: string;
    Email: string;
    URLAddress: string;

    constructor(){
        this.DrugstoreName = '';
        this.Country = "Srbija";
        this.City = '';
        this.Address = '';
        this.Email = '';
        this.URLAddress = '';
    }
}

