import { formatDate } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ReserveAppointmentStandardService } from '../reserve-appointment-standard.service';
import { StandardAppointmentDto } from './standard-appointment.dto';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Router } from '@angular/router';
import { AppointmentScheduleProperties } from '../event/appointmentScheduleProperties';
import { AppointmentEvent } from '../event/appointmentEvent';
import { EventService } from '../service/event.service';


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
  firstFormGroup: FormGroup;
  secondFormGroup: FormGroup;
  thirdFormGroup: FormGroup;
  forthFormGroup: FormGroup;

  specialties: any[] = []
  doctors: any[] = [];
  appointments : any[]= [] 
  eventId: number = 0;

  appointment: AppointmentDate = {date: new Date()}
  appointmentProperties: AppointmentScheduleProperties = 0;
  returnAppointment: StandardAppointmentDto = new StandardAppointmentDto;
  appointmentEvent : AppointmentEvent = new AppointmentEvent(this.appointmentProperties,this.eventId);
  returnDate: string = '';
  selectedDate: string = '';
  selectedSpecialty: SelectedSpecialty = {Name: "", Id: 0};
  selectedDoctor: SelectedDoctor = {Name: "", Id: 0};
  returnSpecialty: number = 0 ;
  displayedColumns : string[] = [ 'Time', '#'];
  range = new FormGroup({
    start: new FormControl(),
    end: new FormControl(),
  });

  constructor(private reserveAppointmentStandardService: ReserveAppointmentStandardService, 
    private _snackBar: MatSnackBar, private router: Router,private formBuilder: FormBuilder,
    private eventService: EventService) { 
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

    this.reserveAppointmentStandardService.GetSpecialty().subscribe((data: any)=>{
      for(const p of (data as any)){
        this.specialties.push(p);
      }
    });
    
    this.eventId = this.makeid();
    this.startEvent();  
  }
  ngOnDestroy(): void {
    
    this.appointmentEvent = new AppointmentEvent(AppointmentScheduleProperties.Quit, this.eventId);
    this.sendEvent();
  }
  makeid() : number {
    var number = 0;
    var possible = "0123456789";
  
    number = Math.floor( Math.random() * 1000 ) 
    return number;
  }

  startEvent(){
    this.appointmentEvent = new AppointmentEvent(AppointmentScheduleProperties.Started, this.eventId);
    this.sendEvent();
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
    this.createFromSelectSpecializationToSelectDoctor()
    this.reserveAppointmentStandardService.GetThatSpecialtyDoctors(specialtyId).subscribe((data: any)=>{
      for(const p of (data as any)){
        this.doctors.push(p);
      }
    })
  }

  chosedDoctor(): void{

    var doctorId = this.selectedDoctor.Id+"";
    this.createFromSelectDoctorToSelectAppointment();
    this.reserveAppointmentStandardService.GetAppointmentsForDoctorAndDate(doctorId, this.appointment.date).subscribe((data: any)=>{
        this.appointments=data;
      
    })
  }
  schedule(element: any): void{
    this.createCreatedEvent();
    
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
  sendEvent() {
    this.eventService.postEvent(this.appointmentEvent).subscribe();
  }
  
  createFromStartedToSelectSpecializationEvent() {
    this.appointmentEvent = new AppointmentEvent(AppointmentScheduleProperties.FromStartedToSelectSpecialization, this.eventId);
    this.sendEvent()
  }
  createFromSelectSpecializationToStarted() {
    this.appointmentEvent = new AppointmentEvent(AppointmentScheduleProperties.FromSelectSpecializationToStarted, this.eventId);
    this.sendEvent();
  }
  createFromSelectSpecializationToSelectDoctor() {
    this.appointmentEvent = new AppointmentEvent(AppointmentScheduleProperties.FromSelectSpecializationToSelectDoctor, this.eventId);
    this.sendEvent();
  }
  createFromSelectDoctorToSelectSpecialization() {
    this.appointmentEvent = new AppointmentEvent(AppointmentScheduleProperties.FromSelectDoctorToSelectSpecialization, this.eventId);
    this.sendEvent();
  }
  createFromSelectDoctorToSelectAppointment() {
    this.appointmentEvent = new AppointmentEvent(AppointmentScheduleProperties.FromSelectDoctorToSelectAppointment, this.eventId);
    this.sendEvent();
  }
  createFromSelectAppointmentToSelectDoctor() {
    this.appointmentEvent = new AppointmentEvent(AppointmentScheduleProperties.FromSelectAppointmentToSelectDoctor, this.eventId);
    this.sendEvent();
  }
  createCreatedEvent() {
    this.appointmentEvent = new AppointmentEvent(AppointmentScheduleProperties.Created, this.eventId);
    this.sendEvent();
  }

}
