import { Component, Input, OnInit} from '@angular/core';
import { RegistrationService } from '../registration.service';
import { ActivationService } from '../activation.service';

import { MatSnackBar } from '@angular/material/snack-bar';
import { PatientDto } from './registration.dto';
import { formatDate } from '@angular/common';
import { Router } from '@angular/router';

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
  token: string;
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
  
  
  allergenList: any[]=[];
  public allergens: any[]=[];

  patient: Patient = {name: "",surname: "", jmbg: "", date: new Date(), bloodType: 0, sex: 0, fathersName: "", phoneNumber: "", adress: "", email: "", username: "", password: "", repeatPassword: "", doctorId: 0, token:""};
  public returnPatient: PatientDto;

  constructor(private registrationService: RegistrationService, private _snackBar: MatSnackBar, 
              private activationService: ActivationService, private router: Router) {
   this.returnPatient = new PatientDto();
  }

  ngOnInit(): void {
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
      this.router.navigate(['/registrationSuccess']);

      
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
