import { Component, Input, OnInit } from '@angular/core';
import { FormControl } from '@angular/forms';

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

  doctors: Doctor[]=[
    {name: 'Pera Peric'}
  ]

  allergens = new FormControl();
  allergenList: string[]=['Panclav', 'Brufen']

  constructor() {
   
   }
  ngOnInit(): void {
  
  }

}
