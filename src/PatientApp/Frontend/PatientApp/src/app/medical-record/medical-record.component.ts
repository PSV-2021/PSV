import { Component, OnInit } from '@angular/core';
import { DomSanitizer } from '@angular/platform-browser';
import { MedicalRecordService } from '../service/medical-record.service';

@Component({
  selector: 'app-medical-record',
  templateUrl: './medical-record.component.html',
  styleUrls: ['./medical-record.component.css']
})
export class MedicalRecordComponent implements OnInit {

  medicalRecord: any;
  imagePath: any;
  constructor(private medicalRecordService: MedicalRecordService, private domSanitizer: DomSanitizer) { }

  ngOnInit(): void {
    
    this.medicalRecordService.GetMedicalRecord('3').subscribe((data: any)=>{
        this.imagePath ="data:image/png;base64,"+ atob(data.image);
        this.medicalRecord = data;
    });
  }
  public getSantizeUrl(url : string) {
    return this.domSanitizer.bypassSecurityTrustUrl(url);
}

}
