import { Component, ElementRef, ViewChild } from '@angular/core';
import { ApartamentoService } from '../../services/apartamento.service';
import { Router } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { Apartamento } from '../../models/Apartamento';
import { Predio } from '../../models/Predio';
import { PredioService } from '../../services/predio.service'
import { ResponseServiceAPI } from '../../models/ResponseServiceAPI';

@Component({
  selector: 'app-apartamento-detalhe',
  templateUrl: './apartamento-detalhe.component.html',
  styleUrls: ['./apartamento-detalhe.component.css']
})
export class ApartamentoDetalheComponent {

  @ViewChild('botao-incluir') botaoIncluir: ElementRef;
  @ViewChild('botao-alterar') botaoAlterar: ElementRef;

  apartamento: Apartamento;
  apartamentoId: string;
  predios: Predio[];
  predioSelected: Predio | undefined;;
  numeroApartamento: string = "";
  andarApartamento: string = "";
  predioId: string;
  manipuladorComando: string;
  responseServiceAPI: ResponseServiceAPI;
  constructor(private apartamentoService: ApartamentoService, private predioService: PredioService, private router: Router) {
  }
  ngOnInit(): void {
    let botaoIncluir = <HTMLButtonElement>document.getElementById("botao-incluir");
    let botaoAlterar = <HTMLButtonElement>document.getElementById("botao-alterar");

    if (sessionStorage.getItem("SISCON_MANIPULADOR_CURRENT") != "") {
      if (sessionStorage.getItem("SISCON_MANIPULADOR_CURRENT") == "UPDATE")
      {
        this.apartamentoId = sessionStorage.getItem("ID_UPDATE") ?? "";
        botaoIncluir.style.display = "none";
        botaoAlterar.style.display = "block";
        sessionStorage.removeItem("SISCON_MANIPULADOR_CURRENT");
        sessionStorage.removeItem("ID_UPDATE");
        this.apartamentoService.getApartamento(this.apartamentoId).subscribe(res => {
          this.apartamento = res;
          if (this.apartamento) {
            this.numeroApartamento = this.apartamento.numeroApto?.toString() ?? "";
            this.andarApartamento = this.apartamento.andar?.toString() ?? "";
          } else {
            this.numeroApartamento = "";
            this.andarApartamento = "";
          }

        });
      }
      else
      {
        botaoIncluir.style.display = "block";
        botaoAlterar.style.display = "none";      

        if (sessionStorage.getItem("ID_UPDATE") != "")
        {
          sessionStorage.removeItem("SISCON_MANIPULADOR_CURRENT");
        }
      }
    }

    this.consultarPredios();
  }

  public consultarPredios() {
    this.predioService.getAllPredios().subscribe(res => {
      this.predios = res;
      this.predioId = res[0].id.toString();
    });
  }

  predioSelecionadoChanged() {
    this.predioSelected = this.predios
      .find(predio => predio.id === this.apartamento.predioId);
  }

  incluirDadosPredio() {

    if (this.numeroApartamento == "")
    {
      alert("É necessário preencher o número do Apartamento");
      return;
    }

    if (this.andarApartamento == "") {
      alert("É necessário preencher o andar do Apartamento");
      return;
    }

    const jsonApartamento = {
      numeroApto: this.numeroApartamento,
      andar: this.andarApartamento,
      predioId: this.predioId
    };

    this.apartamentoService.incluirApartamento(JSON.stringify(jsonApartamento)).subscribe(res => {
      this.responseServiceAPI = res;

      alert(res.mensagem);

      this.router.navigate(['/apartamentos']);
    });

  }


  alterarDadosPredio() {
    if (this.numeroApartamento == "") {
      alert("É necessário preencher o número do Apartamento");
      return;
    }

    if (this.andarApartamento == "") {
      alert("É necessário preencher o andar do Apartamento");
      return;
    }

    const jsonApartamento = {
      numeroApto: this.numeroApartamento,
      andar: this.andarApartamento,
      predioId: this.predioId
    };

    this.apartamentoService.alterarApartamento(this.apartamentoId, JSON.stringify(jsonApartamento)).subscribe(res => {
      this.responseServiceAPI = res;

      alert(res.mensagem);

      this.router.navigate(['/apartamentos']);
    });
  }

}
