import { Component, Input, OnInit} from '@angular/core';
import { RegistrationService } from '../registration.service';
import { MatSnackBar } from '@angular/material/snack-bar';
import { PatientDto } from './registration.dto';
import { formatDate } from '@angular/common';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MustMatch } from '../helpers/must-watch.validator';


interface Type {
  value: string;
}

export interface Patient{
  name: string;
  surname: string;
  jmbg: string;
  date: Date;
  fathersName: string;
  sex: number;
  phoneNumber: string;
  adress: string;
  email: string;
  username: string;
  password: string;
  repeatPassword: string;
  bloodType: number;
  doctorId: number;

}

export interface SelectedDoctor{
  name: string;
}

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.css']
})
export class RegistrationComponent implements OnInit {
  types: Type[] = [
    {value: 'A'},
    {value: 'B'},
    {value: 'AB'},
    {value: 'O'}
  ]

  doctors: any[]=[];
  selectedDoctor: SelectedDoctor = {name: ""};
  registerForm: FormGroup;
  submitted: any;
  
  allergenList: any[]=[];
  public allergens: any[]=[];

  patient: Patient = {name: "",surname: "", jmbg: "", date: new Date(), bloodType: 0, sex: 0, fathersName: "", phoneNumber: "", adress: "", email: "", username: "", password: "", repeatPassword: "", doctorId: 0};
  public returnPatient: PatientDto;

  constructor(private registrationService: RegistrationService, private _snackBar: MatSnackBar,private formBuilder: FormBuilder) {
   this.returnPatient = new PatientDto();
   this.registerForm = formBuilder.group({
        title: formBuilder.control('initial value', Validators.required)
    });
  }
  get f() { return this.registerForm.controls; }
  public hasError = (controlName: string, errorName: string) =>{
    return this.registerForm.controls[controlName].hasError(errorName);
  }

  ngOnInit(): void {

    this.registerForm = this.formBuilder.group({
      name: ['', [Validators.required, Validators.pattern('[A-Z][a-z]*')]],
      surname: ['', [Validators.required, Validators.pattern('[A-Z][a-z]*')]],
      jmbg: ['', Validators.required],
      date: ['', Validators.required],
      father: ['',[Validators.required, Validators.pattern('[A-Z][a-z]*')]],
      phone: ['',[Validators.required, Validators.pattern('[0-9]*')]],
      address: ['',  [Validators.required, Validators.pattern('[A-Z][a-z A-z0-9]*')]],
      username: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]],
      password: ['', [Validators.required, Validators.minLength(6)]],
      confirmPassword: ['', Validators.required],
      doctor: ['', Validators.required],
      bloodType: ['', Validators.required]
  }, {
      validator: MustMatch('password', 'confirmPassword')
  });

    this.registrationService.GetDoctors().subscribe((data: any)=>{
      for(const p of (data as any)){
        this.doctors.push(p);
      }
    })

    this.registrationService.GetAllergens().subscribe((data: any)=>{
      for(const p of (data as any)){
        this.allergenList.push(p);
      }
    })
  }

  onSubmit(){


   this.PrepareDTO();
    for(const d of this.doctors){
      if(d.nameAndSurname == this.selectedDoctor.name){
        this.returnPatient.DoctorId = d.id
      }
    }

  this.registrationService.SendPatient( this.returnPatient).subscribe((data: any)=>{
      this._snackBar.open('Patient saved!', '', {
        duration: 2000
      });
    });
  
  }
  PrepareDTO(){
    this.returnPatient.Name = this.patient.name;
    this.returnPatient.Surname = this.patient.surname;
    this.returnPatient.Jmbg = this.patient.jmbg;
    this.returnPatient.FathersName = this.patient.fathersName;
    this.returnPatient.PhoneNumber = this.patient.phoneNumber;
    this.returnPatient.Address = this.patient.adress;
    this.returnPatient.Email = this.patient.email;
    this.returnPatient.Username = this.patient.username;
    this.returnPatient.Password = this.patient.password;
    this.returnPatient.RepeatPassword = this.patient.repeatPassword;
    this.returnPatient.Sex = this.patient.sex;
    this.returnPatient.BloodType = this.patient.bloodType;
    this.returnPatient.Allergens = this.allergens;

    const format = "dd/MM/yyyy HH:mm:ss"

    this.returnPatient.Date = formatDate(this.patient.date, format, "en-US")
    
  }

}
