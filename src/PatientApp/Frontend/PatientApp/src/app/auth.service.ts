import { JwtHelperService } from '@auth0/angular-jwt';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(private jwtHelper: JwtHelperService) {}

  getAuthStatus() {
    return !!localStorage.getItem("jwtToken");
  }

  isPatient() {
    if(localStorage.getItem("role") == "patient"){
      return true;
    }
    else{
      return false;
    }
  }
  
  hasExpired() {
    var token = localStorage.getItem("jwtToken");
    if(this.jwtHelper.isTokenExpired(token || '{}')){
      return true;
    }
    else{
      return false;
    }
  }

}
