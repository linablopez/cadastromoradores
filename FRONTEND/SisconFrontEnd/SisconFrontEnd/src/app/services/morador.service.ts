import { Observable, map } from "rxjs";
import { Apartamento, ApartamentoPayload, ApartamentoPayloadUniqueResult } from "../models/Apartamento";
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ResponseServiceAPI, ResponseServiceAPIPayload } from "../models/ResponseServiceAPI";
import { Morador, MoradorPayload, MoradorPayloadUniqueResult } from "../models/Morador";

@Injectable({
  providedIn: 'root'
})
export class MoradorService {
  public url = "https://localhost:7052/api/Morador/v1";

  public urlDinamica: string = "";

  constructor(private http: HttpClient) { }

  public getMoradores(nomeMorador: string): Observable<Morador[]> {

    if (nomeMorador == "") {
      return this.http.get<MoradorPayload>(`${this.url}/moradores`).pipe(map((res: MoradorPayload) => res.data));
    }

    return this.http.get<MoradorPayload>(`${this.url}/moradores?nomeMorador=${nomeMorador}`).pipe(map((res: MoradorPayload) => res.data));
  }

  public getMorador(moradorId: string): Observable<Morador> {
    return this.http.get<MoradorPayloadUniqueResult>(`${this.url}/morador/${moradorId}`).pipe(map((res: MoradorPayloadUniqueResult) => res.data));
  }

  public incluirMorador(data: any): Observable<ResponseServiceAPI> {
    const httpOptions = {
      headers: new HttpHeaders({ 'Content-Type': 'application/json' })
    }
    return this.http.post<ResponseServiceAPIPayload>(`${this.url}/morador`, data, httpOptions).pipe(map((res: ResponseServiceAPIPayload) => res.data));
  }

  public alterarMorador(moradorId: string, data: any): Observable<ResponseServiceAPI> {
    const httpOptions = {
      headers: new HttpHeaders({ 'Content-Type': 'application/json' })
    }
    return this.http.put<ResponseServiceAPIPayload>(`${this.url}/morador/${moradorId}`, data, httpOptions).pipe(map((res: ResponseServiceAPIPayload) => res.data));
  }

  public deleteMorador(moradorId: string): Observable<ResponseServiceAPI> {
    return this.http.delete<ResponseServiceAPIPayload>(`${this.url}/morador/${moradorId}`).pipe(map((res: ResponseServiceAPIPayload) => res.data));
  }

}
