import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, UrlTree, Router } from '@angular/router';
import { Observable } from 'rxjs';
import { LoginService } from './services/login.service'; // Replace with the correct path

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {
  constructor(private loginService: LoginService, private router: Router) { }

  canActivate(
    next: ActivatedRouteSnapshot,
    state: RouterStateSnapshot
  ): Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree {
    return this.checkUserLoggedIn();
  }

  private checkUserLoggedIn(): boolean {
    const usuarioLogado = this.loginService.usuarioLogado();
    if (!usuarioLogado) {
      this.router.navigate(['/login']);
    }
    return usuarioLogado;
  }
}
