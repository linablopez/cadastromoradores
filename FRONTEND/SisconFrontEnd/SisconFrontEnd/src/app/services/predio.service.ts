import { Observable, map } from "rxjs";
import { Predio, PredioPayload } from "../models/Predio";
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class PredioService {
  public url = "https://localhost:7052/api/Predio/v1";

  constructor(private http: HttpClient) { }

  public getAllPredios(): Observable<Predio[]> {

    return this.http.get<PredioPayload>(`${this.url}/predios`).pipe(map((res: PredioPayload) => res.data));
  }
}
