import { Predio } from '../models/Predio';;

export class Apartamento {
  id: number;
  numeroApto: number | null;
  andar: number | null;
  predioId: number | null;
  predio: Predio
}

export class ApartamentoPayload {
  data: Apartamento[];
}

export class ApartamentoPayloadUniqueResult {
  data: Apartamento;
}
