import { formatDate } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ReserveAppointmentStandardService } from '../reserve-appointment-standard.service';
import { Calendar } from '@fullcalendar/core';
import dayGridPlugin, { DayGridView } from '@fullcalendar/daygrid'; 
import { StandardAppointmentDto } from './standard-appointment.dto';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Router } from '@angular/router';


export interface Specialty{
  Name: string;
  Id: number;
}

export interface SelectedSpecialty{
  Name: string;
  Id: number;
}
export interface SelectedDoctor{
  Name: string;
  Id: number;
}

export interface Doctor{
  Name: string;
}

export interface AppointmentDate{
  date: Date;
}

@Component({
  selector: 'app-reserve-appointment-standard',
  templateUrl: './reserve-appointment-standard.component.html',
  styleUrls: ['./reserve-appointment-standard.component.css']
})
export class ReserveAppointmentStandardComponent implements OnInit {
  calendarPlugins = [dayGridPlugin];
  dayGridView = new DayGridView;
  firstFormGroup: FormGroup;
  secondFormGroup: FormGroup;
  thirdFormGroup: FormGroup;
  forthFormGroup: FormGroup;

  specialties: any[] = []
  doctors: any[] = [];
  appointments : any[]= [] 

  appointment: AppointmentDate = {date: new Date()}
  returnAppointment: StandardAppointmentDto = new StandardAppointmentDto;
  returnDate: string = '';
  selectedDate: string = '';
  selectedSpecialty: SelectedSpecialty = {Name: "", Id: 0};
  selectedDoctor: SelectedDoctor = {Name: "", Id: 0};
  returnSpecialty: number = 0 ;

  displayedColumns : string[] = [ 'Time', '#'];

  constructor(private reserveAppointmentStandardService: ReserveAppointmentStandardService, 
    private _snackBar: MatSnackBar, private router: Router,private formBuilder: FormBuilder) { 
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
    const name = Calendar.name
    
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

    this.reserveAppointmentStandardService.GetSpecialty().subscribe((data: any)=>{
      for(const p of (data as any)){
        this.specialties.push(p);
      }
    });
  }

  onSubmit(): void{
    
    const format = "dd/MM/yyyy HH:mm:ss"
    this.returnDate = formatDate(this.appointment.date, format, "en-US")
  
    for(const d of this.specialties){
      if(d.name == this.selectedSpecialty.Name){
        this.returnSpecialty = d.id
      }
    }

  }

  chosedSpecialty(): void{

    var specialtyId = this.selectedSpecialty.Id+"";
    this.reserveAppointmentStandardService.GetThatSpecialtyDoctors(specialtyId).subscribe((data: any)=>{
      for(const p of (data as any)){
        this.doctors.push(p);
      }
    })
  }

  chosedDoctor(): void{

    var doctorId = this.selectedDoctor.Id+"";
    this.reserveAppointmentStandardService.GetAppointmentsForDoctorAndDate(doctorId, this.appointment.date).subscribe((data: any)=>{
        this.appointments=data;
      
    })
  }
  schedule(element: any): void{
    this.returnAppointment = new StandardAppointmentDto;
    this.prepareDTO(element);
    this.reserveAppointmentStandardService.scheduleAppointment(this.returnAppointment)
      .subscribe((data: any)=>{
        this._snackBar.open('AppointmentSuccessfully scheduled!', '', {
        duration: 3000
        });
      this.router.navigate(['/medicalRecord']);
      });
  }
  prepareDTO(element: any){
    this.returnAppointment.DoctorId = this.selectedDoctor.Id+"";
    this.returnAppointment.PatientId = "1";
    const format = "dd/MM/yyyy HH:mm:ss"
    this.returnAppointment.StartTime = formatDate(element.startTime, format, "en-US")
    
  }

}
