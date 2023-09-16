export class Predio {

  id: number;
  nomePredio: string;
  rua: string;
  numero: number;
  bairro: string;
  cidade: string;
  estado: string;
  pais: string;
  cep: string
  dataConstrucao: string
  numAndares: string

}

export class PredioPayload {
  data: Predio[];
}

export class PredioPayloadUniqueResult {
  data: Predio;
}
