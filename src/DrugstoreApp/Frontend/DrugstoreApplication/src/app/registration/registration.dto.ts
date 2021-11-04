export class RegistrationDto{
    hospitalName: string;
    address: string;
    email: string;
    apiAddress: string;

    constructor(){
        this.hospitalName = '';
        this.address = '';
        this.email = '';
        this.apiAddress = '';
    }
}

