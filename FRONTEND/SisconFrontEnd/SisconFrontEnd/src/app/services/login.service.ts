import { Injectable } from '@angular/core';
import { Usuario, UsuarioPayloadUniqueResult, ValidaSenhaUsuario, ValidaSenhaUsuarioPayload } from '../models/Usuario';
import { Router } from '@angular/router';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { map, Observable } from 'rxjs';


@Injectable({
  providedIn: 'root'
})
export class LoginService {
  public url = "https://localhost:7052/api/Usuario/v1";
  validateUsuario: ValidaSenhaUsuario;

  constructor(private router: Router, private http:HttpClient) { }

  realizarLogin(usuario: Usuario): any {
    if (usuario.usuario == '' || usuario.senha == '') {
      return 'Os campos usuário e senha devem ser preenchidos';
    }
    else {
      const loginNome: string = usuario.usuario;
      const senha: string = usuario.senha;

      const usuarioJSON = {
        loginNome,
        senha
      };

      try {
        this.postValidaUsuario(usuarioJSON).subscribe(responseValidateUsuario => {
          this.validateUsuario = responseValidateUsuario;
          if (this.validateUsuario.loginValidado == true) {
            localStorage.setItem('usuario', btoa(JSON.stringify(usuario)));
            this.router.navigate(['home']);
            window.location.reload();
          }
        });
      } catch (error) {
        console.error('Ocorreu um erro durante a chamada a postValidaUsuario:', error);
      }
    }
    return 'Entre com o usuário e senha válidos'
  }

  usuarioLogado(): boolean {
    const usuarioString = localStorage.getItem('usuario');
 
    return usuarioString != null;
  }

  get usuarioNome(): string {
    const usuarioString = localStorage.getItem('usuario');

    return usuarioString
      ? (JSON.parse(atob(usuarioString)) as Usuario).usuario
      : "";
  }

  logout(): void {
    localStorage.clear();
    this.router.navigate(['login'])
    window.location.reload();
  }

  public postValidaUsuario(data: any): Observable<ValidaSenhaUsuario> {
    const httpOptions = {
      headers: new HttpHeaders({ 'Content-Type': 'application/json' })
    }
    return this.http.post<ValidaSenhaUsuarioPayload>(`${this.url}/validaSenhaUsuario`, JSON.stringify(data), httpOptions).pipe(map((res: ValidaSenhaUsuarioPayload) => res.data));
  }
  public getUsuario(usuario: string): Observable<Usuario> {
    return this.http.get<UsuarioPayloadUniqueResult>(`${this.url}/usuario/${usuario}`).pipe(map((res: UsuarioPayloadUniqueResult) => res.data));
  }
}
