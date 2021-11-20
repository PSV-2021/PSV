export class PatientDto{
    Name: string;
    Surname: string;
    Jmbg: string;
    Date: Date;
    BloodType: number;
    FathersName: string;
    Sex: number;
    PhoneNumber: string;
    Adress: string;
    Email: string;
    Username: string;
    Password: string;
    RepeatPassword: string;
    DoctorId: number;
    Allergens: any[];

    constructor(){
        this.Name = "",
        this.Surname = "",
        this.Jmbg = "",
        this.Date = new Date();
        this.FathersName = "",
        this.PhoneNumber = "",
        this.Adress = "",
        this.Email = "",
        this.Username = "",
        this.Password = "",
        this.RepeatPassword = "",
        this.Sex = 0,
        this.BloodType = 0,
        this.DoctorId = 0,
        this.Allergens = []
    }
}
