import { Observable, map } from "rxjs";
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Sexo, SexoPayload } from "../models/Sexo";

@Injectable({
  providedIn: 'root'
})

export class SexoService {

  public url = "https://localhost:7052/api/Sexo/v1";

  constructor(private http: HttpClient) { }

  public getAllSexos(): Observable<Sexo[]> {

    return this.http.get<SexoPayload>(`${this.url}/sexos`).pipe(map((res: SexoPayload) => res.data));
  }

}
