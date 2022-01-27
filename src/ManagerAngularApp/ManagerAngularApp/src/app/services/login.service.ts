import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';
import { UserDto } from '../login/user-dto';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class LoginService {
  url: string;
  constructor(private http: HttpClient) {   
    this.url = environment.hospitalAPI;
  }

  Login(userDTO: UserDto): Observable<any>{
    return this.http.post<any>(this.url + "/login", userDTO, { responseType: 'text' as 'json'});
  }

}
