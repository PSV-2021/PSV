import { Component, Inject, Input, OnInit } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Router } from '@angular/router';
import { AppointmentObserveService } from '../appointment-observe.service';
import { ReportService } from '../service/report.service';
import {MatDialog, MatDialogConfig} from "@angular/material/dialog";
import { DialogComponent } from '../dialog/dialog.component';


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
  displayedColumns: string[] = ['id', 'start time', 'description', 'doctor', 'status','survey','cancel','report'];
  dataSource = [];
  surveys: any[] = []
  appointmentId: any;
  id: any = "";
  report: any;


  constructor(private observeAppointemntsService: AppointmentObserveService, private observeReportService: ReportService, private router: Router, private _snackBar: MatSnackBar, private dialog: MatDialog) { }

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
    this.id = localStorage.getItem('id');
    this.observeAppointemntsService.GetAppointments(this.id).subscribe((data: any)=>{
      console.log(data);
    this.dataSource = data;
  });
  }

  Report(element: { id: number }){
    this.appointmentId = element.id;
    
    this.observeReportService.GetReport(this.appointmentId).subscribe((data: any)=>{
      this.report = data;
      console.log(this.report);
    });


    let dialogRef = this.dialog.open(DialogComponent, {
      width: '350px',
      data: {
        id: this.report.id,
        apointmentDescription: this.report.apointmentDescription,
        patientId: this.report.patientId,
        startTime: this.report.startTime
      }
    })
  
    dialogRef.afterClosed().subscribe(res => {
      // received data from dialog-component
      console.log(res.data)
    })
    
  }
 
}

