import { Injectable } from '@angular/core';
import { Router, CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, UrlTree } from '@angular/router';
import { JwtHelperService } from '@auth0/angular-jwt';
import { Observable } from 'rxjs';
import { AuthService } from "./auth.service"
import jwt_decode from 'jwt-decode';

@Injectable({
    providedIn: 'root'
  })
export class AuthGuard implements CanActivate{
    constructor(
        private router: Router,
        private authenticationService: AuthService,
        private jwtHelper: JwtHelperService
    ) { }

    canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean | UrlTree | Observable<boolean | UrlTree> | Promise<boolean | UrlTree>{
        const isAuthenticated = this.authenticationService.getAuthStatus();
        //let tokenInfo = this.getDecodedToken(isAuthenticated as string);
        if(isAuthenticated != null && !this.jwtHelper.isTokenExpired(isAuthenticated)) {
            return true;           
        }
        else{
            this.router.navigate(['/login']);
            return false;
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
