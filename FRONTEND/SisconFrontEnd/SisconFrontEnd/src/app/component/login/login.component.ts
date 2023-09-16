import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Usuario } from 'src/app/models/Usuario';
import { LoginService } from 'src/app/services/login.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  constructor(private loginService: LoginService,
    private router: Router) { }
  ngOnInit(): void {
    if (!this.loginService.usuarioLogado()) {
      this.router.navigate(['/login']);
    } else {
      this.router.navigate(['/home']);
    }
  }

  usuario: Usuario = new Usuario();
  loginInvalido!: String;

  realizarLogin(): void {
    this.loginInvalido = this.loginService.realizarLogin(this.usuario);
  }

}
