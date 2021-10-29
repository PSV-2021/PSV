export class RegistrationDto{
    hospitalName: string;
    address: string;
    email: string;
    apiAddress: string;
    password: string;  //treba da se enktriptuje!!!

    constructor(){
        this.hospitalName = '';
        this.address = '';
        this.email = '';
        this.apiAddress = '';
        this.password = '';
    }
}

