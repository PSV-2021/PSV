import { Component, Input, OnInit } from '@angular/core';
import { RegistrationService } from '../services/registration.service';
import { RegistrationDto } from './registration.dto';

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.css'],
  providers: [RegistrationService]
})
export class RegistrationComponent implements OnInit {
  @Input() public newHospital: RegistrationDto;

  constructor() {
    this.newHospital = new RegistrationDto();
   }

  register(): void{
    console.log(this.newHospital);
  }

  ngOnInit(): void {
  }

}
