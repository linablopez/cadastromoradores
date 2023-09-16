import { Observable, map } from "rxjs";
import { Apartamento, ApartamentoPayload, ApartamentoPayloadUniqueResult } from "../models/Apartamento";
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ResponseServiceAPI, ResponseServiceAPIPayload } from "../models/ResponseServiceAPI";

@Injectable({
  providedIn: 'root'
})
export class ApartamentoService {
  public url = "https://localhost:7052/api/Apartamento/v1";

  public urlDinamica: string = "";

  public validaAnd: boolean = false;

  constructor(private http: HttpClient) { }

  public getApartamentos(numeroApartamento: string, andarApartamento: string): Observable<Apartamento[]> {
    this.urlDinamica = "";
    if (numeroApartamento == "" && andarApartamento == "") {
      return this.http.get<ApartamentoPayload>(`${this.url}/apartamentos`).pipe(map((res: ApartamentoPayload) => res.data));
    }

    if (numeroApartamento != "" || andarApartamento != "") {
      this.urlDinamica += "?"

      if (numeroApartamento != "") {
        this.validaAnd = true;
        this.urlDinamica += "numeroApartamento=" + numeroApartamento;
      }

      if (andarApartamento != "") {
        if (this.validaAnd == true) {
          this.urlDinamica += "&"
        }
        this.urlDinamica += "andar=" + andarApartamento;
      }
      
      return this.http.get<ApartamentoPayload>(`${this.url}/apartamentos${this.urlDinamica}`).pipe(map((res: ApartamentoPayload) => res.data));
    }
      return this.http.get<ApartamentoPayload>(`${this.url}/apartamentos`).pipe(map((res: ApartamentoPayload) => res.data));

  }

  public getApartamento(idApartamento: string): Observable<Apartamento> {
    return this.http.get<ApartamentoPayloadUniqueResult>(`${this.url}/apartamento/${idApartamento}`).pipe(map((res: ApartamentoPayloadUniqueResult) => res.data));
  }

  public incluirApartamento(data: any): Observable<ResponseServiceAPI> {
    const httpOptions = {
      headers: new HttpHeaders({ 'Content-Type': 'application/json' })
    }
    return this.http.post<ResponseServiceAPIPayload>(`${this.url}/apartamento`, data, httpOptions).pipe(map((res: ResponseServiceAPIPayload) => res.data));
  }

  public alterarApartamento(apartamentoId:string, data: any): Observable<ResponseServiceAPI> {
    const httpOptions = {
      headers: new HttpHeaders({ 'Content-Type': 'application/json' })
    }
    return this.http.put<ResponseServiceAPIPayload>(`${this.url}/apartamento/${apartamentoId}`, data, httpOptions).pipe(map((res: ResponseServiceAPIPayload) => res.data));
  }

  public deleteApartamento(idApartamento: string): Observable<ResponseServiceAPI> {
    return this.http.delete<ResponseServiceAPIPayload>(`${this.url}/apartamento/${idApartamento}`).pipe(map((res: ResponseServiceAPIPayload) => res.data));
  }
}
