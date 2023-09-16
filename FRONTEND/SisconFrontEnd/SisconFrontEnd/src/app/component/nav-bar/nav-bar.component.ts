import { Component } from '@angular/core';
import { LoginService } from 'src/app/services/login.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-nav-bar',
  templateUrl: './nav-bar.component.html',
  styleUrls: ['./nav-bar.component.css']
})
export class NavBarComponent {

  constructor(public loginService: LoginService, private router: Router) { }

  mostrarUsuario(): boolean {
    return this.loginService.usuarioLogado();
  }

  sair() {
    this.loginService.logout();
  }

}
