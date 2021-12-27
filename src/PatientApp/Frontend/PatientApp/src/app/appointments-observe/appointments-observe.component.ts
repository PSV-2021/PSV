import { Component, Input, OnInit } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Router } from '@angular/router';
import { AppointmentObserveService } from '../appointment-observe.service';


export interface Appointment {
  id: number;
  patientId: number;
}
@Component({
  selector: 'app-appointments-observe',
  templateUrl: './appointments-observe.component.html',
  styleUrls: ['./appointments-observe.component.css']
  
})
export class AppointmentsObserveComponent implements OnInit {
  displayedColumns: string[] = ['id', 'start time', 'description', 'doctor', 'status','survey','cancel'];
  dataSource = [];
  surveys: any[] = []
  appointmentId: any;


  constructor(private observeAppointemntsService: AppointmentObserveService, private router: Router, private _snackBar: MatSnackBar) { }

  TakeSurvey($myParam: number = 0, $myParam1: number = 0): void {
    const navigationDetails: string[] = ['/survey'];
    if($myParam && $myParam1) {
      navigationDetails.push($myParam.toString());
      navigationDetails.push($myParam1.toString());
    }
    this.router.navigate(navigationDetails);
  }

  CancelAppointment(element: { id: number }){
    this.appointmentId = element.id;
    
    this.observeAppointemntsService.CancelAppointment(element.id).subscribe((data: any) =>{
      this.ngOnInit();
      this._snackBar.open('Appointment cancelled!', '', {
        duration: 2000
      });
    });
    
  }

  ngOnInit(): void {
    this.observeAppointemntsService.GetAppointments('2').subscribe((data: any)=>{
      console.log(data);
    this.dataSource = data;
  });
  }
 

}
