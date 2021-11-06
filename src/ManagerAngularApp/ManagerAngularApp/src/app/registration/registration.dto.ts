export class RegistrationDto{
    DrugstoreName: string;
    Address: string;
    Email: string;
    URLAddress: string;

    constructor(){
        this.DrugstoreName = '';
        this.Address = '';
        this.Email = '';
        this.URLAddress = '';
    }
}

