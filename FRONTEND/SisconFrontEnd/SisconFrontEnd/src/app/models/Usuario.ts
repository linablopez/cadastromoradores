export class Usuario {

  usuario: string;

  senha: string;

  nome_usuario: string | "";

  dataCriacao: string | "";

}

export class UsuarioPayload {
  data: Usuario[];
}

export class UsuarioPayloadUniqueResult {
  data: Usuario;
}

export class ValidaSenhaUsuarioPayload {
  data: ValidaSenhaUsuario ;
}

export class ValidaSenhaUsuario {
  usuario: string;
  loginValidado!: boolean;
}
