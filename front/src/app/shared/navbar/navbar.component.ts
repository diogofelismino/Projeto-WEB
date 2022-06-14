import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { LoginComponent } from 'src/app/areas/Login/Login.component';
import { LoginServiceService } from 'src/services/login-service.service';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit {

  constructor(
    private router: Router,
    private login: LoginServiceService,
    
  ) { }

  ngOnInit() {

  }


  public sair(){
    this.login.limpaUsuario();
    this.router.navigate(['/login'])

  }
}
