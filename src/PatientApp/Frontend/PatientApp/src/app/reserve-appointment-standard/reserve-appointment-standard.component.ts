import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ReserveAppointmentStandardService } from '../reserve-appointment-standard.service';

export interface Specialty{
  Name: string;
  Id: number;
}

export interface Doctor{
  Name: string;
}

@Component({
  selector: 'app-reserve-appointment-standard',
  templateUrl: './reserve-appointment-standard.component.html',
  styleUrls: ['./reserve-appointment-standard.component.css']
})
export class ReserveAppointmentStandardComponent implements OnInit {
  firstFormGroup: FormGroup;
  secondFormGroup: FormGroup;
  thirdFormGroup: FormGroup;
  forthFormGroup: FormGroup;

  specialties: any[] = []
  doctors: Doctor[] = [{Name: ""}];
  appointments: any[] = [];


  constructor(private formBuilder: FormBuilder, private reserveAppointmentStandardService: ReserveAppointmentStandardService) { 
    this.firstFormGroup = formBuilder.group({
        title: formBuilder.control('initial value', Validators.required)
    });
    this.secondFormGroup = formBuilder.group({
      title: formBuilder.control('initial value', Validators.required)
    });
    this.thirdFormGroup = formBuilder.group({
      title: formBuilder.control('initial value', Validators.required)
    });
    this.forthFormGroup = formBuilder.group({
      title: formBuilder.control('initial value', Validators.required)
    });
  }

  public hasErrorFirst = (controlName: string, errorName: string) =>{
    return this.firstFormGroup.controls[controlName].hasError(errorName);
  }
  public hasErrorSecond = (controlName: string, errorName: string) =>{
    return this.secondFormGroup.controls[controlName].hasError(errorName);
  }
  public hasErrorThird = (controlName: string, errorName: string) =>{
    return this.thirdFormGroup.controls[controlName].hasError(errorName);
  }
  public hasErrorForth = (controlName: string, errorName: string) =>{
    return this.forthFormGroup.controls[controlName].hasError(errorName);
  }

  ngOnInit(): void {
    this.firstFormGroup = this.formBuilder.group({
      date: ['', Validators.required],
    });
    this.secondFormGroup = this.formBuilder.group({
      specialty: ['', Validators.required],
    });
    this.thirdFormGroup = this.formBuilder.group({
      doctor: ['', Validators.required],
    });
    this.forthFormGroup = this.formBuilder.group({
      appointment: ['', Validators.required],
    });
    this.doctors = [{Name: "Milan Mikic"}, {Name: "Danica Popovic"}];

    this.reserveAppointmentStandardService.GetSpecialty().subscribe((data: any)=>{
      for(const p of (data as any)){
        this.specialties.push(p);
      }
    })
  }
}
