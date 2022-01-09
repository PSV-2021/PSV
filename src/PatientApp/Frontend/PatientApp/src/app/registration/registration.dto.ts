export class PatientDto{
    Name: string;
    Surname: string;
    Jmbg: string;
    Date: string;
    BloodType: number;
    FathersName: string;
    Sex: number;
    PhoneNumber: string;
    Address: string;
    Email: string;
    Username: string;
    Password: string;
    RepeatPassword: string;
    DoctorId: number;
    Allergens: any[];
    Token: string;
    Image: string;

    constructor(){
        this.Name = "",
        this.Surname = "",
        this.Jmbg = "",
        this.Date = "";
        this.FathersName = "",
        this.PhoneNumber = "",
        this.Address = "",
        this.Email = "",
        this.Username = "",
        this.Password = "",
        this.RepeatPassword = "",
        this.Sex = 0,
        this.BloodType = 0,
        this.DoctorId = 0,
        this.Allergens = [],
        this.Token = ""
        this.Image = ""
    }
}
