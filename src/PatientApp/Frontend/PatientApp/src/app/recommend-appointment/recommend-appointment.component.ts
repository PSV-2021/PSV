import { Component, OnInit } from '@angular/core';
import {FormGroup, FormControl} from '@angular/forms';

@Component({
  selector: 'app-recommend-appointment',
  templateUrl: './recommend-appointment.component.html',
  styleUrls: ['./recommend-appointment.component.css']
})
export class RecommendAppointmentComponent implements OnInit {

  range = new FormGroup({
    start: new FormControl(),
    end: new FormControl(),
  });

  constructor() { }

  ngOnInit(): void {
  }

}
