import { Observable, map } from "rxjs";
import { Apartamento, ApartamentoPayload, ApartamentoPayloadUniqueResult } from "../models/Apartamento";
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ResponseServiceAPI, ResponseServiceAPIPayload } from "../models/ResponseServiceAPI";
import { Morador, MoradorPayload, MoradorPayloadUniqueResult } from "../models/Morador";
import { MoradorApartamento, MoradorApartamentoFiltro, MoradorApartamentoPayload } from "../models/MoradorApartamento";

@Injectable({
  providedIn: 'root'
})
export class MoradorApartamentoService {
  public url = "https://localhost:7052/api/MoradorApartamento/v1";

  constructor(private http: HttpClient) { }

  public getMoradoresApartamentos(filtro: MoradorApartamentoFiltro): Observable<MoradorApartamento[]> {
    let params = new HttpParams();

    if (filtro.nomeMorador != null && filtro.nomeMorador != '') {
      params = params.set('nomeMorador', filtro.nomeMorador);
    }

    if (filtro.numeroApartamento != null && filtro.numeroApartamento != '') {
      params = params.set('numeroApartamento', filtro.numeroApartamento);
    }

    if (filtro.nomePredio != null && filtro.nomePredio != '') {
      params = params.set('nomePredio', filtro.nomePredio);
    }

    return this.http.get<MoradorApartamentoPayload>(`${this.url}/moradoresApartamentos`, { params }).pipe(map((res: MoradorApartamentoPayload) => res.data));
  }

  public incluirMoradorApartamento(data: any): Observable<ResponseServiceAPI> {
    const httpOptions = {
      headers: new HttpHeaders({ 'Content-Type': 'application/json' })
    }
    return this.http.post<ResponseServiceAPIPayload>(`${this.url}/moradorApartamento`, data, httpOptions).pipe(map((res: ResponseServiceAPIPayload) => res.data));
  }

  public alterarMoradorApartamento(moradorApartamentoId: string, data: any): Observable<ResponseServiceAPI> {
    const httpOptions = {
      headers: new HttpHeaders({ 'Content-Type': 'application/json' })
    }
    return this.http.put<ResponseServiceAPIPayload>(`${this.url}/moradorApartamento/${moradorApartamentoId}`, data, httpOptions).pipe(map((res: ResponseServiceAPIPayload) => res.data));
  }

  public deleteMoradorApartamento(moradorApartamentoId: string): Observable<ResponseServiceAPI> {
    return this.http.delete<ResponseServiceAPIPayload>(`${this.url}/moradorApartamento/${moradorApartamentoId}`).pipe(map((res: ResponseServiceAPIPayload) => res.data));
  }
}
