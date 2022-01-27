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
  

  constructor(private rs : RegistrationService) {
    this.newDrugstore = new RegistrationDto();
   }

  ngOnInit(): void {
  }

  register(): void{
    if (this.validate() == true){
      console.log(this.newDrugstore);
      this.sendRegistration();
      alert("Uspesno ste registrovali novu apoteku !");
    }
    else 
      alert("Niste uneli sve potrebne podatke !");
}

validate() : boolean{
  if (
    this.newDrugstore.Address == "" || this.newDrugstore.DrugstoreName == "" ||
    this.newDrugstore.Email == "" || this.newDrugstore.URLAddress == "" || this.newDrugstore.Address == ""
  )
    return false;
  else 
    return true;
}

public sendRegistration(): void{
  this.rs.RegisterDrugstore(this.newDrugstore).subscribe();
}

}
