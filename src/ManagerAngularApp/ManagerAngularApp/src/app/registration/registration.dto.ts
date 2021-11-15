export class RegistrationDto{
    DrugstoreName: string;
    City: string;
    Address: string;
    Email: string;
    URLAddress: string;

    constructor(){
        this.DrugstoreName = '';
        this.City = '';
        this.Address = '';
        this.Email = '';
        this.URLAddress = '';
    }
}

