import { HttpErrorResponse, HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { AuthService } from "./auth.service"
import { tap } from 'rxjs/operators';

@Injectable()
export class Interceptor implements HttpInterceptor{
    constructor(
        private router: Router,
        private authenticationService: AuthService
    ) { }

    intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        const token = localStorage.getItem("jwtToken");

        if(token){
            const cloneRequest = req.clone({
                headers: req.headers.set('Authorization', 'Bearer' + token)
            })
            return next.handle(cloneRequest);
        }else{
            return next.handle(req).pipe( tap(() => {},
            (err: any) => {
                if(err instanceof HttpErrorResponse){
                    if(err.status == 401 || err.status == 403){
                        this.router.navigate(['/login']);
                    }
                    return;
                }
            }
            ))
        }
    }
}
