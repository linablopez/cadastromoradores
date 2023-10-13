export class TipoDocumento {
  id: number;
  descricao: string;
}

export class TipoDocumentoPayload {
  data: TipoDocumento[];
}

export class TipoDocumentoPayloadUniqueResult {
  data: TipoDocumento;
}
