export class Sexo {
  id: number;
  descricao: string;
}

export class SexoPayload {
  data: Sexo[];
}

export class SexoPayloadUniqueResult {
  data: Sexo;
}
