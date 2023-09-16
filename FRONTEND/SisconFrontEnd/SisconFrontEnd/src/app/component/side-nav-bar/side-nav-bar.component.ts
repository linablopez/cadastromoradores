import { Component, AfterViewInit, ViewChild } from '@angular/core';
import { MatSidenav } from '@angular/material/sidenav';
import { LoginService } from 'src/app/services/login.service';

@Component({
  selector: 'app-side-nav-bar',
  templateUrl: './side-nav-bar.component.html',
  styleUrls: ['./side-nav-bar.component.css']
})
export class SideNavBarComponent implements AfterViewInit {

  @ViewChild('sidenav') sidenav!: MatSidenav;

  constructor(public loginService: LoginService) { }

  mostrarUsuario(): boolean {
    return this.loginService.usuarioLogado();
  }

  ngAfterViewInit() {
    this.sidenav.open();
  }

}
