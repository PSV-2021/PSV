import { Component, OnInit } from '@angular/core';
import { MedicalRecordService } from '../service/medical-record.service';

@Component({
  selector: 'app-medical-record',
  templateUrl: './medical-record.component.html',
  styleUrls: ['./medical-record.component.css']
})
export class MedicalRecordComponent implements OnInit {

  medicalRecord: any;

  constructor(private medicalRecordService: MedicalRecordService) { }

  ngOnInit(): void {
    
    this.medicalRecordService.GetMedicalRecord('2').subscribe((data: any)=>{
        console.log(data);
        this.medicalRecord = data;
    });
  }

}
