import { Component, Input, OnInit } from '@angular/core';
import { RegistrationService } from '../services/registration.service';
import { RegistrationDto } from './registration.dto';

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.css']
})
export class RegistrationComponent implements OnInit {
  @Input() public newDrugstore: RegistrationDto;

  constructor() {
    this.newDrugstore = new RegistrationDto();
   }

  ngOnInit(): void {
  }


  register(): void{
    console.log(this.newDrugstore);
  }

}
