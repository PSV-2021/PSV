import { Component, Input, OnInit } from '@angular/core';
import { FormControl } from '@angular/forms';
import { RegistrationService} from '../registration.service';

interface Type {
  value: string;
}

interface Doctor{
  name: string;
}

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.css']
})
export class RegistrationComponent implements OnInit {
  types: Type[] = [
    {value: 'A'},
    {value: 'B'},
    {value: 'AB'},
    {value: 'O'}
  ]

  doctors: any[]

  allergens = new FormControl();
  allergenList: any[] = ['Panclav', 'Brufen'];

  constructor(private registrationService: RegistrationService) {
    this.doctors = []
   }
  ngOnInit(): void {
    this.registrationService.GetDoctors().subscribe((data: any)=>{
      for(const p of (data as any)){
        this.doctors.push(p);
        console.log(p);
      }
    })
  }
  

}
