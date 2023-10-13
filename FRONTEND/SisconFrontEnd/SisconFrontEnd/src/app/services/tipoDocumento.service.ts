import { Observable, map } from "rxjs";
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { TipoDocumento, TipoDocumentoPayload } from "../models/TipoDocumento";

@Injectable({
  providedIn: 'root'
})

export class TipoDocumentoService {
  public url = "https://localhost:7052/api/tipoDocumento/v1";

  constructor(private http: HttpClient) { }

  public getAllTipoDocumentos(): Observable<TipoDocumento[]> {

    return this.http.get<TipoDocumentoPayload>(`${this.url}/tipoDocumentos`).pipe(map((res: TipoDocumentoPayload) => res.data));
  }

}
