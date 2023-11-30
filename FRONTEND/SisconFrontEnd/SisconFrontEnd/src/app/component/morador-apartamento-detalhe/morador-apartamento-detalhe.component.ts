import { Component } from '@angular/core';
import { Predio } from '../../models/Predio';
import { Morador } from '../../models/Morador';
import { Apartamento } from '../../models/Apartamento';
import { MoradorService } from '../../services/morador.service';
import { ApartamentoService } from '../../services/apartamento.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-morador-apartamento-detalhe',
  templateUrl: './morador-apartamento-detalhe.component.html',
  styleUrls: ['./morador-apartamento-detalhe.component.css']
})
export class MoradorApartamentoDetalheComponent {
  moradores: Morador[];
  moradorId: string;
  apartamentos: Apartamento[];
  apartamentoId: string;

  constructor(private moradorService: MoradorService, private apartamentoService: ApartamentoService, private router: Router) {
  }

  ngOnInit(): void {
    //this.consultarMoradores();
    //this.consultarApartamentos();
  }
  //public consultarMoradores() {
  //  this.moradorService.getMoradores('').subscribe(res => {
  //    this.moradores = res;
  //    this.moradorId = res[0].id.toString();
  //  });
  //}

  //public consultarApartamentos() {
  //  this.apartamentoService.getApartamentos('','').subscribe(res => {
  //    this.apartamentos = res;
  //    this.apartamentoId = res[0].id.toString();
  //  });
  //}

  incluirDadosMoradorApartamento() {

  }
}
