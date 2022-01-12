import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { LoginService } from '../services/login.service';
import { UserDto } from './user-dto';
import jwt_decode from 'jwt-decode';
import { FormBuilder, FormGroup, Validators} from '@angular/forms';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  pageTitle="Manager App";

  userDto: UserDto = { Username: "", Password: ""}

  loginForm: FormGroup;

  token: string = ""

  constructor(private loginService: LoginService, private router: Router,private formBuilder: FormBuilder) { 
    this.loginForm = formBuilder.group({
      title: formBuilder.control('initial value', Validators.required)
    });
  }

  ngOnInit(): void {
    this.loginForm = this.formBuilder.group({
      Username: ['', Validators.required],
      Password: ['', Validators.required]
    });
  }

  onSubmit() {
    console.log(this.userDto.Username);
    console.log(this.userDto.Password);

    this.loginService.Login(this.userDto).subscribe((data: any)=>{
      localStorage.setItem("jwtToken", data);
      let tokenInfo = this.getDecodedToken(data);
      localStorage.setItem('id', tokenInfo.id);
      localStorage.setItem('role', tokenInfo.role);
      console.log(tokenInfo.role);
      console.log(data);
      if(tokenInfo.role == "manager"){
      this.router.navigate(['home']);
      }
      else{
        alert("This is manager only application, please log in as a manager");
      }
    });

  
  }

  getDecodedToken(token: string): any{
    try{
      return jwt_decode(token);
    }
    catch(Error){
      token = "";
    }
  }

  register(){
    this.router.navigate(['/registration']);
  }

}
