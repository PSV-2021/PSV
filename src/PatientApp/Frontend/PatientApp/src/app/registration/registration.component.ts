import { Component, Input, OnInit } from '@angular/core';
import { FormControl } from '@angular/forms';
import { RegistrationService } from '../registration.service';

interface Type {
  value: string;
}

export interface Patient{
  name: string;
  surname: string;
  jmbg: string;
  //date: date;
  fathersName: string;
  //sex: number;
  phoneNumber: string;
  adress: string;
  email: string;
  username: string;
  password: string;
  repeatPassword: string;
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
  
  allergens = new FormControl();
  allergenList: any[]=[];

  patient: Patient = {name: "",surname: "", jmbg: "", fathersName: "", phoneNumber: "", adress: "", email: "", username: "", password: "", repeatPassword: ""};


  constructor(private registrationService: RegistrationService) {
   
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
   console.log(this.patient.name)
   console.log(this.patient.surname)
   console.log(this.patient.jmbg)
   console.log(this.patient.fathersName)
   console.log(this.patient.phoneNumber)
   console.log(this.patient.adress)
   console.log(this.patient.email)
   console.log(this.patient.username)
   console.log(this.patient.password)
   console.log(this.patient.repeatPassword)
  }
}
