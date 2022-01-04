import { Component, OnInit } from '@angular/core';
import { MedicalRecordService } from '../service/medical-record.service';

@Component({
  selector: 'app-medical-record',
  templateUrl: './medical-record.component.html',
  styleUrls: ['./medical-record.component.css']
})
export class MedicalRecordComponent implements OnInit {

  medicalRecord: any;
  id: any = "";

  constructor(private medicalRecordService: MedicalRecordService) { }

  ngOnInit(): void {
    this.id = localStorage.getItem('id');
    this.medicalRecordService.GetMedicalRecord(this.id).subscribe((data: any)=>{
        this.medicalRecord = data;
    });
  }

}
