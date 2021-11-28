import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { PatientDto } from '../registration/registration.dto';
import { ActivationService } from '../service/activation.service';

@Component({
  selector: 'app-activation-account',
  templateUrl: './activation-account.component.html',
  styleUrls: ['./activation-account.component.css']
})
export class ActivationAccountComponent implements OnInit {
  public returnPatient: PatientDto;
  isValidToken :boolean = false;
  constructor(private router: Router, private activationService: ActivationService) {
    this.returnPatient = new PatientDto();

   }

  ngOnInit(): void {
    console.log(this.router.url);
    var splitted = this.router.url.split("=", 2); 
    this.returnPatient.Token = splitted[1];
    this.activationService.IsTokenValid( this.returnPatient).subscribe((data: any)=>{
      this.isValidToken = true;
      this.router.navigate(['/login']);

    });

  }

}
