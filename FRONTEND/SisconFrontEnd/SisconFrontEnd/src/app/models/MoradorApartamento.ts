import { Apartamento } from "./Apartamento";
import { Morador } from "./Morador";

export class MoradorApartamento {
  public Id: number;
  public MoradorId: number | null;
  public ApartamentoId: number | null;

  public Morador: Morador;
  public Apartamento: Apartamento;

}

export class MoradorApartamentoPayload {
  data: MoradorApartamento[];
}

export class MoradorApartamentoPayloadUniqueResult {
  data: MoradorApartamento;
}

export class MoradorApartamentoFiltro {
  nomeMorador?: string;
  numeroApartamento?: string;
  nomePredio?: string;
}
