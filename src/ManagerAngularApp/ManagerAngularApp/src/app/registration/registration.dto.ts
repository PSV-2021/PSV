export class RegistrationDto{
    DrugStorename: string;
    address: string;
    email: string;
    apiAddress: string;

    constructor(){
        this.DrugStorename = '';
        this.address = '';
        this.email = '';
        this.apiAddress = '';
    }
}

