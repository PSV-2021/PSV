import { Component, OnInit } from '@angular/core';
import { AppointmentObserveService } from '../appointment-observe.service';


export interface Appointment {
  id: number;
  startTime: Date;
  appointmentDescription: string;
  doctorId: number;
  surveyId: number;
}
@Component({
  selector: 'app-appointments-observe',
  templateUrl: './appointments-observe.component.html',
  styleUrls: ['./appointments-observe.component.css']
  
})
export class AppointmentsObserveComponent implements OnInit {
  displayedColumns: string[] = ['id', 'start time', 'description', 'doctor', 'survey'];
  appointments: any[]=[];
  dataSource = [];

  constructor(private observeAppointemntsService: AppointmentObserveService) { }

  ngOnInit(): void {
    this.observeAppointemntsService.GetAppointments('2').subscribe((data: any)=>{
     this.dataSource = data;
  });    
  }

}
