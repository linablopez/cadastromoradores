import { Sexo } from "./Sexo";
import { TipoDocumento } from "./TipoDocumento";

export class Morador {
  id: number;
  numeroDocumento: string;
  tipoDocumentoId: number | null;
  nome: string;
  dataNascimento: Date | null;
  idade: number | null;
  sexoId: number | null;
  telefone: string;
  email: string;
  sexo: Sexo | null;
  tipoDocumento: TipoDocumento | null;
}

export class MoradorPayload {
  data: Morador[];
}

export class MoradorPayloadUniqueResult {
  data: Morador;
}
