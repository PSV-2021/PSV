import { Component, OnInit } from '@angular/core';
import {FormGroup, FormControl, FormBuilder, Validators} from '@angular/forms';
import { RecommendAppointmentService } from '../service/recommend-appointment.service';
import { RecommendAppointmentDto } from './recommend-appointment-dto';
import { DatePipe, formatDate } from '@angular/common';
import { MatSnackBar } from '@angular/material/snack-bar';
import { AvailableRecommendedAppointments } from './available-recommended-appointments';

export interface SelectedDoctor{
  name: string;
}

export interface RecommendedAppointment{
  startDate: Date;
  endDate: Date;
  doctorId: number;
  specializationId: number;
  priority: number;
}

@Component({
  selector: 'app-recommend-appointment',
  templateUrl: './recommend-appointment.component.html',
  styleUrls: ['./recommend-appointment.component.css']
})
export class RecommendAppointmentComponent implements OnInit {

  doctors: any[]=[];
  selectedDoctor: SelectedDoctor = {name: ""};
  recommendForm: FormGroup;
  appointmentsRecomended: AvailableRecommendedAppointments[] = new Array();

  appointment: RecommendedAppointment = {startDate: new Date(),endDate: new Date(), doctorId: 0, specializationId: 0, priority: 1};
  public returnAppointment: RecommendAppointmentDto;

  constructor(private recommendAppointmentService: RecommendAppointmentService,private formBuilder: FormBuilder, private _snackBar: MatSnackBar) {
    this.returnAppointment = new RecommendAppointmentDto(); 
    this.recommendForm = formBuilder.group({
      title: formBuilder.control('initial value', Validators.required)
    });
  }

  get f() { return this.recommendForm.controls; }

  public hasError = (controlName: string, errorName: string) =>{
    return this.recommendForm.controls[controlName].hasError(errorName);
  }

  ngOnInit(): void {

    this.recommendForm = this.formBuilder.group({
      startDate: ['', Validators.required],
      endDate: ['', Validators.required],
      doctor: ['', Validators.required],
      priority: ['', Validators.required]
    });

    this.recommendAppointmentService.GetAllDoctors().subscribe((data: any)=>{
      for(const p of (data as any)){
        this.doctors.push(p);
        
      }
    })
  }

  onSubmit(){

    this.PrepareDTO();
     for(const d of this.doctors){
       if(d.nameAndSurname == this.selectedDoctor.name){
         this.returnAppointment.DoctorId = d.id
         this.returnAppointment.SpecializationId = d.specialityId;
       }
     }

    console.log(this.returnAppointment.DoctorId);
    console.log(this.returnAppointment.SpecializationId);
    console.log(this.returnAppointment.Priority);
    console.log(this.returnAppointment.StartInterval);
    console.log(this.returnAppointment.EndInterval);

    console.log(this.returnAppointment);

    
    this.recommendAppointmentService.FindAppointments(this.returnAppointment).subscribe((data: any)=>{
      this._snackBar.open('Appointments found!', '', {
        duration: 2000
      });
      this.appointmentsRecomended = data;
    });

    console.log(this.appointmentsRecomended);
     
  }

  PrepareDTO(){
    this.returnAppointment.Priority = this.appointment.priority;

    const format = "MM/dd/yyyy HH:mm:ss a"

    this.returnAppointment.StartInterval = formatDate(this.appointment.startDate, format, "en-US");
    this.returnAppointment.EndInterval = formatDate(this.appointment.endDate, format, "en-US");

  }

}
