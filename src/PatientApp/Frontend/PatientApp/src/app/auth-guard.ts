import { Injectable } from '@angular/core';
import { Router, CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, UrlTree } from '@angular/router';
import { Observable } from 'rxjs';
import { AuthService } from "./auth.service"
import jwt_decode from 'jwt-decode';

@Injectable({
    providedIn: 'root'
  })
export class AuthGuard implements CanActivate{
    constructor(
        private router: Router,
        private authenticationService: AuthService
    ) { }

    canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean | UrlTree | Observable<boolean | UrlTree> | Promise<boolean | UrlTree>{
        var isAuthenticated = this.authenticationService.getAuthStatus();
        var isPatient = this.authenticationService.isPatient();
        var hasExpired = this.authenticationService.hasExpired();       
        if(!isAuthenticated || !isPatient || hasExpired) {
          this.router.navigate(['/login']);   
          return false;        
        }
        else{
          return true;
        }
        
    }

    getDecodedToken(token: string): any{
        try{
          return jwt_decode(token);
        }
        catch(Error){
          token = "";
        }
      }
}
